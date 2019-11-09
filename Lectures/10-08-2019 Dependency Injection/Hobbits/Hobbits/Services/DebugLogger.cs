using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;

namespace Hobbits.Services
{
    public class DebugLogger : ILogger
    {
        private readonly RequestIdGenerator requestIdGenerator;

        public DebugLogger(RequestIdGenerator requestIdGenerator)
        {
            this.requestIdGenerator = requestIdGenerator;
        }

        // in a real-world situation, this would log to a database somewhere
        public void Log(string message)
        {
            Debug.WriteLine(message + " - " + this.requestIdGenerator.RequestId);
        }
    }
}
