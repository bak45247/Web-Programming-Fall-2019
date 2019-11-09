using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Hobbits.Services;
using Microsoft.AspNetCore.Mvc.Filters;

namespace Hobbits.Filters
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
            throw new NotImplementedException();
        }

        public void OnActionExecuting(ActionExecutingContext context)
        {
            context.HttpContext.Response.Headers["request-id"] = this.requestIdGenerator.RequestId;
        }
    }
}
