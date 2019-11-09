using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Threading.Tasks;
using Kuscotopia.Entities;
using Kuscotopia.Services;
using Microsoft.AspNetCore.Mvc;

namespace Kuscotopia.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ValuesController : Controller
    {
        private readonly QueueService queueService;

        public ValuesController(QueueService queueService)
        {
            this.queueService = queueService;
        }

        [HttpPost]
        public async Task<IActionResult> PostAsync([FromBody] int workCount)
        {
            Random random = new Random();

            for (int i = 0; i < workCount; i++)
            {
                await queueService.QueueWorkAsync(random.Next(0, 3));
            }

            return StatusCode((int)HttpStatusCode.Accepted);
        }
    }
}
