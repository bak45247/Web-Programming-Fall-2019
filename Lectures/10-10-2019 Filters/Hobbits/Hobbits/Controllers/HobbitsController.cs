using System.Collections.Generic;
using System.Linq;
using Microsoft.AspNetCore.Mvc;
using Hobbits.Entities;
using Hobbits.Services;
using System.Net;
using Hobbits.Filters;

namespace Hobbits.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [TypeFilter(typeof(RequestIdFilter))]
    [TypeFilter(typeof(ModelStateFilter))]
    public class HobbitsController : Controller
    {
        private HobbitDatabase hobbits;
        private readonly ILogger logger;

        public HobbitsController(HobbitDatabase hobbits, ILogger logger)
        {
            this.hobbits = hobbits;
            this.logger = logger;
        }

        [HttpGet]
        public IEnumerable<HobbitEntity> Get()
        {
            logger.Log("Starting to get all hobbits ");

            var result = hobbits.Get().Select(hm => hm.ToEntity());

            logger.Log($"Ending getting all hobbits. Count: {result.Count()}");

            return result;
        }

        [HttpGet("{id}")]
        public HobbitEntity Get(int id)
        {
            return hobbits.Get(id).ToEntity();
        }

        [HttpPost]
        public IActionResult Post([FromBody]HobbitEntity hobbit)
        {
            if (hobbits.Add(hobbit.ToModel()))
            {
                return Json(hobbit);
            }
            else
            {
                return new ContentResult()
                {
                    StatusCode = (int)HttpStatusCode.BadRequest,
                    Content = "Could not add your hobbit"
                };
            }
        }
    }
}
