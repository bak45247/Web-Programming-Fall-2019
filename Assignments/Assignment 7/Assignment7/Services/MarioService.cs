using Microsoft.Practices.EnterpriseLibrary.TransientFaultHandling;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Net;
using System.Threading.Tasks;

namespace Assignment7.Services
{
    public class MarioService : IMarioService
    {
        RetryPolicy retryPolicy = new RetryPolicy(new DetectionStrategy(), 5);

        public async Task<string> GetAsync(string move)
        {
            retryPolicy.Retrying += (sender, args) =>
            {
                Debug.WriteLine($"Retry count is: {args.CurrentRetryCount} + {args.LastException.Message}");
            };

            var result = await retryPolicy.ExecuteAsync(async () =>
            {
                var request = WebRequest.Create($"https://webprogrammingassignment7.azurewebsites.net/api/mario/{ move }");
                request.Method = "GET";

                var response = await request.GetResponseAsync();

                var responseString = await new StreamReader(response.GetResponseStream()).ReadToEndAsync();
                return responseString;
            });

            return result;
        }
    }
}
