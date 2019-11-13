using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using SurvivorRefactor.Entities;
using SurvivorRefactor.Entities.V1U1;

namespace SurvivorRefactor.Controllers.V1U1
{
    [Route("api/[controller]")]
    [ApiController]
    [ApiVersion("1.1")]
    public class ValuesController : ControllerBase
    {
        // POST api/values
        [HttpPost]
        public void Post([FromBody] ValueEntity value)
        {
            // add the new entity to the database here
        }
    }
}
