using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Portal.Services;

namespace Portal.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ValuesController : ControllerBase
    {
        public ISecurityProvider securityProvider;

        public ValuesController(ISecurityProvider securityProvider)
        {
            this.securityProvider = securityProvider;
        }
        // GET api/values
        [HttpGet]
        public string Get()
        {
            return this.securityProvider.GetToken(new List<Claim>());
        }
    }
}
