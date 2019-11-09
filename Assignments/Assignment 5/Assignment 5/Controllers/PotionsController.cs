using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Assignment_5.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Primitives;

namespace Assignment_5.Controllers
{
    public class PotionsController : Controller
    {
        public static PotionsDatabase potionsDatabase = new PotionsDatabase();
        // This will be replaced with dependency injection later on

        static PotionsController()
        {
            potionsDatabase.Add("ant");
            potionsDatabase.Add("bug");
            potionsDatabase.Add("Nirnroot");
            potionsDatabase.Add("Histcarp");
            potionsDatabase.Add("Honeycomb");
            potionsDatabase.Add("Deathbell");
            potionsDatabase.Add("Ectoplasm");
        }

        public IActionResult Index()
        {
            return View(potionsDatabase);
        }

        [HttpPost]
        public IActionResult AddIngredient()
        {
            if (Request.HasFormContentType)
            {
                if (Request.Form.Keys.Count == 2)
                {
                    if (Request.Form.TryGetValue(Request.Form.Keys.ElementAt(0), out StringValues first) &&
                    Request.Form.TryGetValue(Request.Form.Keys.ElementAt(1), out StringValues second))
                    {
                        potionsDatabase.Add(first.ToString(), second.ToString());
                    }
                }
                
            }
            return RedirectToAction("index");
        }
    }
}