using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Threading.Tasks;
using Kuscotopia.Services;
using Microsoft.AspNetCore.Mvc;

namespace Kuzcotopia.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class KuzcotopiaController : Controller
    {
        private readonly KuzcotopiaService kuzcotopiaService;

        public KuzcotopiaController(KuzcotopiaService kuzcotopiaService)
        {
            this.kuzcotopiaService = kuzcotopiaService;
        }

        [HttpPost("{WorkCount:int}")]
        public async Task<IActionResult> PostAsync(int WorkCount)
        {
            await kuzcotopiaService.QueueWorkAsync(WorkCount);

            return StatusCode((int)HttpStatusCode.Accepted);
        }

        [HttpGet]
        public async Task<IActionResult> GetAsync()
        {
            await kuzcotopiaService.QueueWorkAsync(5);

            return StatusCode((int)HttpStatusCode.Accepted);
        }
    }
}
