using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Net;
using System.Threading.Tasks;
using Microsoft.Practices.EnterpriseLibrary.TransientFaultHandling;

namespace Mario.Services
{
    public class ExternalMarioService
    {
        RetryPolicy retryPolicy = new RetryPolicy(new DetectionStrategy(), 5); // Adding the three timespans to add a timeout to the retry policy

        public string Get()
        {
            retryPolicy.Retrying += (sender, args) => // Must register retrying before the ExecuteAction to actually receive the information from it.
            {
                Debug.WriteLine($"Current retry count is: {args.CurrentRetryCount} + {args.LastException}");
            };

            var result = retryPolicy.ExecuteAction(() =>
            {
                // for assignment 7 we'll request to the assignment 7 server rather than google
                var request = WebRequest.Create("https://google.com");
                // does not start the request yet
                request.Method = "GET";

                // this is the line that makes the request
                // BLOCKS the currenth thread until the current request is done
                // h8 this
                // this throws an exception on any 4 or 500 status code
                var response = request.GetResponse();

                // blocks the thread while it downloads the entire reponse at once
                var responseString = new StreamReader(response.GetResponseStream()).ReadToEnd();
                return responseString;
            });

            return result;
        }
    }
}
