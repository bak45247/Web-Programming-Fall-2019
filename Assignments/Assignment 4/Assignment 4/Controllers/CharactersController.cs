using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Threading.Tasks;
using Assignment_4.Entities;
using Assignment_4.Models;
using Microsoft.AspNetCore.Mvc;

namespace Assignment_4.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class CharactersController : Controller
    {
        public static List<CharacterModel> characters = new List<CharacterModel>(); // This will break dependency injection rules

       [HttpGet]
       public IEnumerable<CharacterEntity> Get()
        {
            return characters.Select(element => new CharacterEntity(element));
        }

       [HttpGet("{id:int}")]
       public IActionResult GetOne(int id)
        {
            if (id < 0 || id >= characters.Count)
            {
                return StatusCode((int)HttpStatusCode.NotFound);
            }

            return Json(new CharacterEntity(characters[id]));
        }

       [HttpPost]
       public CharacterEntity Post([FromBody] CharacterEntity character)
        {
            characters.Add(character.ToModel());
            return character;
        }


        [HttpGet("{id:int}/views")]
        public IActionResult GetViews(int id)
        {
            if (id < 0 || id >= characters.Count)
            {
                return StatusCode((int)HttpStatusCode.NotFound);
            }

            return Json(characters[id].Views);
        }

        // post/{index}/views
        [HttpPost("{id:int}/views")]
        public IActionResult PostViews([FromBody] ViewEntity view, int id)
        {
            if (id < 0 || id >= characters.Count)
            {
                return StatusCode((int)HttpStatusCode.NotFound);
            }

            characters[id].Views.Add(view.ViewDate);
            return Json(new CharacterEntity(characters[id]).Views);
        }
    }
}
