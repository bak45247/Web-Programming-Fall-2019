using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Hobbits.Services
{
    public class DatabaseLogger : ILogger
    {
        public void Log(string message)
        {
            // here we would connect to a database and log this message
        }
    }
}
