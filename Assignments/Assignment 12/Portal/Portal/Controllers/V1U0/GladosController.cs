using Microsoft.AspNetCore.Mvc;
using Portal.Services.V1U0;

namespace Portal.Controllers.V1U0
{
    [Route("api/[controller]")]
    [TypeFilter(typeof(AuthorizationFilter))]
    [ApiController]
    public class GladosController : Controller
    {
        private readonly QuoteDatabase quoteDatabase;

        public GladosController(QuoteDatabase quoteDatabase)
        {
            this.quoteDatabase = quoteDatabase;
        }

        [HttpGet]
        public IActionResult Get()
        {
            return Json(quoteDatabase.GetQuote());
        }
    }
}