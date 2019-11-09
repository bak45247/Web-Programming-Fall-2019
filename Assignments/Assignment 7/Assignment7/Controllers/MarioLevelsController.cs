using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Assignment7.Entities;
using Assignment7.Services;
using System.Net;
using Newtonsoft.Json;

namespace Assignment7.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MarioLevelsController : Controller
    {
        public IMarioService marioService;

        public MarioLevelsController(IMarioService marioService)
        {
            this.marioService = marioService;
        }

        [HttpGet("{move}")]
        public async Task<IActionResult> Get(string move)
        {
            // Check to ensure I'm getting a valid move
            if (move.Equals("walk") || move.Equals("wait") || move.Equals("run") || move.Equals("jump"))
            {
                return Json(JsonConvert.DeserializeObject(await marioService.GetAsync(move)));
            }
            else
            {
                return StatusCode((int) HttpStatusCode.BadRequest);
            }
        }
    }
}
