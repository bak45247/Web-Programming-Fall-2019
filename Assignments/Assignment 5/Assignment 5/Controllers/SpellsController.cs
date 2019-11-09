using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Primitives;
using Assignment_5.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Threading.Tasks;

namespace Assignment_5.Controllers
{
    public class SpellsController : Controller
    {
        public static SpellsDatabase spellsDatabase = new SpellsDatabase();
        // This will be replaced with dependency injection later on

        static SpellsController()
        {
            spellsDatabase.Add("Sparks");
            spellsDatabase.Add("Flames");
            spellsDatabase.Add("Incinerate");
            spellsDatabase.Add("Transmogrify");
        }

        public IActionResult Index()
        {
            return View(spellsDatabase);
        }

        [HttpPost]
        public IActionResult Delete()
        {
            if (Request.HasFormContentType)
            {
                if (Request.Form.TryGetValue("spellIndex", out StringValues spellIndex))
                {
                    if (int.TryParse(spellIndex, out int index))
                    {
                        spellsDatabase.RemoveAt(index);
                    }
                }
            }
            return RedirectToAction("index");
        }

        [HttpPost]
        public IActionResult Add()
        {
            if (Request.HasFormContentType)
            {
                if (Request.Form.TryGetValue("spellName", out StringValues spellName))
                {
                    spellsDatabase.Add(spellName.ToString());
                }
            }
            return RedirectToAction("index");
        }

        public IActionResult ViewSpell(string id)
        {
            if (int.TryParse(id, out int result))
            {
                ViewData["id"] = id;
                return View(spellsDatabase.Get(result));
            }
            return RedirectToAction("index");
        }
    }
}
