using DependencyInjection.Services;
using Microsoft.AspNetCore.Mvc.Filters;

namespace DependencyInjection.Filters
{
	public class RequestIdFilter : IActionFilter
    {
        private readonly IRequestIdGenerator requestIdGenerator;
        private readonly ILogger logger;

		public RequestIdFilter(IRequestIdGenerator requestIdGenerator, ILogger logger)
		{
			this.requestIdGenerator = requestIdGenerator;
            this.logger = logger;
        }

		public void OnActionExecuted(ActionExecutedContext context)
		{
			logger.Log("Adding a request-id to the response: " + this.requestIdGenerator.RequestId);
            context.HttpContext.Response.Headers["request-id"] = this.requestIdGenerator.RequestId;
        }

		public void OnActionExecuting(ActionExecutingContext context)
		{
			// nothing to do here, but have to have this method because the interface requires it
		}
	}
}
