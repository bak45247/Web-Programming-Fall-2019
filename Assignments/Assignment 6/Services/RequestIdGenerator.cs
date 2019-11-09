using System;

namespace DependencyInjection.Services
{
    /*
     * A class that generates unique request ids
     */
    public class RequestIdGenerator : IRequestIdGenerator
    {
        public RequestIdGenerator()
        {
            this.RequestId = Guid.NewGuid().ToString();
        }

        public string RequestId { get; }
    }
}
