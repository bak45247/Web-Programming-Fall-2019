using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Threading.Tasks;
using Gargoyles.Entities;
using Gargoyles.Model;
using Gargoyles.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Primitives;

namespace Gargoyles.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class GargoylesController : Controller
    {
        private readonly GargoylesDatabase gargoylesDatabase;

        public GargoylesController(GargoylesDatabase gargoylesDatabase)
        {
            this.gargoylesDatabase = gargoylesDatabase;
        }

        [HttpGet]
        public IEnumerable<GargoyleEntity> Get()
        {
            var result = gargoylesDatabase.Get().Select(gargoyle => new GargoyleEntity(gargoyle.Value));
            return result;
        }


        [HttpGet("{index}")]
        public IActionResult Get(string index)
        {
            if (!gargoylesDatabase.Get().ContainsKey(index))
            {
                return StatusCode((int)HttpStatusCode.NotFound);
            }

            var model = this.gargoylesDatabase.Get(index);

            Response.Headers["ETag"] = model.ETag();

            return Json(new GargoyleEntity(model));
        }

        [HttpPost]
        public IActionResult Post([FromBody] GargoyleEntity gargoyleEntity)
        {
            if (gargoylesDatabase.Get().ContainsKey(gargoyleEntity.Name))
            {
                return StatusCode((int)HttpStatusCode.Conflict);
            }

            this.gargoylesDatabase.AddOrReplace(gargoyleEntity.ToModel());

            return Json(gargoyleEntity);
        }

        [HttpPut("{index}")]
        public IActionResult Put(string index, [FromBody] GargoyleEntity gargoyleEntity)
        {
            if (!gargoylesDatabase.Get().ContainsKey(index))
            {
                return StatusCode((int)HttpStatusCode.NotFound);
            }

            if (!Request.Headers.TryGetValue("If-Match", out StringValues ifMatch))
            {
                return StatusCode((int)HttpStatusCode.PreconditionFailed);
            }

            var model = this.gargoylesDatabase.Get(gargoyleEntity.Name);

            if (model.ETag() != ifMatch && model.ETag() != "*")
            {
                return StatusCode((int)HttpStatusCode.PreconditionFailed);
            }

            this.gargoylesDatabase.AddOrReplace(gargoyleEntity.ToModel());

            return Json(gargoyleEntity);
        }

        [HttpPatch("{index}")]
        public IActionResult Patch(string index, [FromBody] GargoyleEntity gargoyleEntity)
        {
            if (!gargoylesDatabase.Get().ContainsKey(index))
            {
                return StatusCode((int)HttpStatusCode.NotFound);
            }

            if (!Request.Headers.TryGetValue("If-Match", out StringValues ifMatch))
            {
                return StatusCode((int)HttpStatusCode.PreconditionFailed);
            }

            var model = this.gargoylesDatabase.Get(gargoyleEntity.Name);

            if (model.ETag() != ifMatch && model.ETag() != "*")
            {
                return StatusCode((int)HttpStatusCode.PreconditionFailed);
            }

            var updatedModel = this.gargoylesDatabase.Update(index, gargoyleEntity.ToModel());

            return Json(new GargoyleEntity(updatedModel));
        }

    }
}
