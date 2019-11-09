using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Threading.Tasks;

namespace Spells.Controllers
{
    public class SpellsController : Controller
    {

        public IActionResult Index(int id)
        {
            return View();
        }

        [Route("newRoute")]
        public IActionResult NewRoute()
        {

            return new ContentResult()
            {
                StatusCode = (int) HttpStatusCode.Accepted,
                Content = "You called new route! Yay!"
            };
        }
    }
}
