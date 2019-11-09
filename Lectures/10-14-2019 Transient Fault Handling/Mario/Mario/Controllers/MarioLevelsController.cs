using System.Collections.Generic;
using System.Linq;
using Microsoft.AspNetCore.Mvc;
using System.Net;
using Mario.Services;
using Mario.Entities;
using Mario.Filters;

namespace Mario.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [TypeFilter(typeof(RequestIdFilter))]
    public class MarioLevelsController : Controller
    {
        private MarioLevelDatabase marioLevels;
        private readonly ILogger logger;

        public MarioLevelsController(MarioLevelDatabase marioLevels, ILogger logger)
        {
            this.marioLevels = marioLevels;
            this.logger = logger;
        }

        [HttpGet]
        public IEnumerable<MarioLevelEntity> Get()
        {
            var result = marioLevels.Get().Select(mm => new MarioLevelEntity(mm));

            return result;
        }

        [HttpGet("{id}")]
        public MarioLevelEntity Get(int id)
        {
            return new MarioLevelEntity(marioLevels.Get(id));
        }

        [HttpPost]
        public IActionResult Post([FromBody]MarioLevelEntity marioLevel)
        {
            if (marioLevels.Add(marioLevel.ToModel()))
            {
                return Json(marioLevel);
            }
            else
            {
                return new ContentResult()
                {
                    StatusCode = (int)HttpStatusCode.BadRequest,
                    Content = "Could not add your mario level"
                };
            }
        }
    }
}
