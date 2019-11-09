using System.Collections.Generic;
using System.Net;
using DependencyInjection.Filters;
using DependencyInjection.Services;
using Microsoft.AspNetCore.Mvc;

namespace DependencyInjection.Controllers
{
	/*
	* The main endpoint controller. Stores and allows updates to a list of strings (hobbit names).
	*/
	[Route("api/[controller]")]
	[TypeFilter(typeof(StopwatchFilter))]
	[TypeFilter(typeof(RequestIdFilter))]
	public class HobbitsController : Controller
	{
		private IDatabase database;
        private readonly ILogger logger;
		private StopwatchService watchService;

        public HobbitsController(IDatabase database, ILogger logger, StopwatchService watchService)
        {
            this.database = database;
            this.logger = logger;
            this.watchService = watchService;
        }

		[HttpGet]
		public IEnumerable<string> Get()
		{
			logger.Log("GET hobbits returning " + database.Size);
			watchService.Lap("Controller");

			return database.GetData("Hobbit");
		}

		[HttpPost]
		public string Post([FromQuery] string hobbit)
		{
			logger.Log("POST hobbits adding " + hobbit);
			watchService.Lap("Controller");

			database.AddString("Hobbit", hobbit);

			return hobbit;
		}

		[HttpDelete]
		public IActionResult Delete()
		{
			logger.Log("Delete hobbits");
			watchService.Lap("Controller");

			database.DeleteAll();

			return StatusCode((int)HttpStatusCode.NoContent);
		}
	}
}
