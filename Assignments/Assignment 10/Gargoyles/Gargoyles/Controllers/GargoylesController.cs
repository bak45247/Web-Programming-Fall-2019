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
        public IActionResult Get()
        {
            // return all gargoyles here

            return null;
        }


        [HttpGet("{index}")]
        public IActionResult Get(string index)
        {
            // we aren't doing index checking for the lecture. don't forget it

            var model = this.gargoylesDatabase.Get(index);

            Response.Headers["ETag"] = model.ETag();

            return Json(new GargoyleEntity(model));
        }

        [HttpPost]
        public IActionResult Post([FromBody] GargoyleEntity gargoyleEntity)
        {
            // return a 4xx status code here if the gargoyle at that index already exists
            // there is a better status code to use than the generic 400-BadRequest.

            this.gargoylesDatabase.AddOrReplace(gargoyleEntity.ToModel());

            return Json(gargoyleEntity);
        }

        [HttpPut("{index}")]
        public IActionResult Put(string index, [FromBody] GargoyleEntity gargoyleEntity)
        {
            // we aren't doing index checking for the lecture. don't forget it

            // add the ETag check if the gargoyle already exists.

            this.gargoylesDatabase.AddOrReplace(gargoyleEntity.ToModel());

            return Json(gargoyleEntity);
        }

        [HttpPatch("{index}")]
        public IActionResult Patch(string index, [FromBody] GargoyleEntity gargoyleEntity)
        {
            // check if model exists first

            if (!Request.Headers.TryGetValue("If-Match", out StringValues ifMatch))
            {
                return StatusCode((int)HttpStatusCode.PreconditionFailed);
            }

            var model = this.gargoylesDatabase.Get(gargoyleEntity.Name);

            // add support for the wildcard if-match header here 
            if (model.ETag() != ifMatch)
            {
                return StatusCode((int)HttpStatusCode.PreconditionFailed);
            }

            var updatedModel = this.gargoylesDatabase.Update(index, gargoyleEntity.ToModel());

            return Json(new GargoyleEntity(updatedModel));
        }

    }
}
