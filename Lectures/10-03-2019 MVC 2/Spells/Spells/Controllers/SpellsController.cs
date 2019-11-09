using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Primitives;
using Spells.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Threading.Tasks;

namespace Spells.Controllers
{
    public class SpellsController : Controller
    {
        // remember, this will be replaced with dependency injection in assignment 6
        public static SpellsDatabase spellsDatabase = new SpellsDatabase();

        static SpellsController()
        {
            spellsDatabase.Add("Wingardium Levosia");
            spellsDatabase.Add("Aloha mora");
        }

        public IActionResult Index()
        {
            return View(spellsDatabase);
        }

        public IActionResult ViewSpell(string id)
        {
            if (int.TryParse(id, out int result))
            {
                ViewData["id"] = result;
                return View(spellsDatabase.Get(result));
            }

            return RedirectToAction("index");
        }

        public IActionResult Delete()
        {
            if (!Request.HasFormContentType)
            {
                return RedirectToAction("index");
            }

            if (!Request.Form.TryGetValue("spellIndex", out StringValues spellIndex))
            {
                return RedirectToAction("index");
            }
            else
            {
                if (int.TryParse(spellIndex, out int result))
                {
                    spellsDatabase.RemoveAt(result);
                    return RedirectToAction("index");
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

        public IActionResult Add(string first, string second)
        {
            spellsDatabase.Mix(first, second);
            return null;
        }
    }
}
