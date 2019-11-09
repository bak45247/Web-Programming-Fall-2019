using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Threading.Tasks;
using Gargoyles.Models;
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
        // GET api/values/5
        [HttpGet("{index}")]
        public IActionResult Get(string index)
        {
            // not doing index checking here, but will need to do for assignment 10

            var model = this.gargoylesDatabase.Get(index);

            Response.Headers["ETag"] = model.ETag();

            return Json(model);
        }

        // GET api/values/5
        [HttpPut("{index}")]
        public IActionResult Put(string index, [FromBody] GargoyleModel gargoyleModel)
        {
            // not doing index checking here, but will need to do for assignment 10

            if(!Request.Headers.TryGetValue("If-Match", out StringValues ifMatch))
            {
                return StatusCode((int)HttpStatusCode.PreconditionFailed);
            }

            var model = this.gargoylesDatabase.Get(index);

            if(model.ETag() != ifMatch)
            {
                return StatusCode((int)HttpStatusCode.PreconditionFailed);
            }

            this.gargoylesDatabase.AddOrReplace(model);

            return Json(model);
        }

        public IActionResult Patch(string index, [FromBody] GargoylesModel gargoyleModel)
        {
            var model = new GargoylesModel();

            if(gargoyleModel.Color != null)
            {
                model.Color = gargoyleModel.Color;
            }
        }
    }
}
