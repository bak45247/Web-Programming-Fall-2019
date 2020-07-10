using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using Microsoft.Extensions.Primitives;
using System.Net;

namespace Portal.Services.V1U0
{
    public class AuthorizationFilter : IAuthorizationFilter
    {
        public ISecurityProvider securityProvider;

        public AuthorizationFilter(ISecurityProvider securityProvider)
        {
            this.securityProvider = securityProvider;
        }

        public void OnAuthorization(AuthorizationFilterContext context)
        {
            if (!context.HttpContext.Request.Headers.TryGetValue("authorization", out StringValues authHeader))
            {
                context.Result = new StatusCodeResult((int)HttpStatusCode.Unauthorized);
                return;
            }

            var authorization = authHeader.ToString();

            if (!authorization.StartsWith("Bearer "))
            {
                context.Result = new StatusCodeResult((int)HttpStatusCode.Unauthorized);
                return;
            }

            authorization = authorization.Substring(7);

            if (!securityProvider.ValidateToken(authorization))
            {
                context.Result = new StatusCodeResult((int)HttpStatusCode.Unauthorized);
                return;
            }
        }
    }
}
