using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Security.Claims;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Portal.Entities.V1U0;
using Portal.Services.V1U0;

namespace Portal.Controllers.V1U0
{
    [Route("api/[controller]")]
    [ApiController]
    public class LoginController : Controller
    {
        public ISecurityProvider securityProvider;
        private readonly UsersDatabase users;

        public LoginController(ISecurityProvider securityProvider, UsersDatabase users)
        {
            this.securityProvider = securityProvider;
            this.users = users;
        }

        [HttpPost]
        public IActionResult Post([FromBody] UserEntity user)
        {
            if (!users.IsValidUser(user.Username))
            {
                return StatusCode((int)HttpStatusCode.Unauthorized);
            }

            if (users.GetUser(user.Username).Password != user.Password)
            {
                return StatusCode((int)HttpStatusCode.Unauthorized);
            }

            Response.Headers["authorization"] = "Bearer " + securityProvider.GetToken(new List<Claim>());
            return Json("okay");
        }
    }
}
