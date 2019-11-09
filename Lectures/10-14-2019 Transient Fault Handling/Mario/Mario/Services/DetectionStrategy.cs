using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Threading.Tasks;
using Microsoft.Practices.EnterpriseLibrary.TransientFaultHandling;

namespace Mario.Services
{
    public class DetectionStrategy : ITransientErrorDetectionStrategy
    {
        public bool IsTransient(Exception ex)
        {
            var webException = ex as WebException;
            // ? = null coalescing operator - checks if the object before is null
            var response = webException?.Response as HttpWebResponse;
            return response?.StatusCode == HttpStatusCode.ServiceUnavailable;
        }
    }
}
