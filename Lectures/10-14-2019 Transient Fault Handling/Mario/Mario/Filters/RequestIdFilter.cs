using Mario.Services;
using Microsoft.AspNetCore.Mvc.Filters;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Mario.Filters
{
    public class RequestIdFilter : IActionFilter
    {
        private readonly RequestIdGenerator requestIdGenerator;

        public RequestIdFilter(RequestIdGenerator requestIdGenerator)
        {
            this.requestIdGenerator = requestIdGenerator;
        }

        public void OnActionExecuted(ActionExecutedContext context)
        {

        }

        public void OnActionExecuting(ActionExecutingContext context)
        {
            context.HttpContext.Response.Headers["request-id"] = this.requestIdGenerator.RequestId;
        }
    }
}
