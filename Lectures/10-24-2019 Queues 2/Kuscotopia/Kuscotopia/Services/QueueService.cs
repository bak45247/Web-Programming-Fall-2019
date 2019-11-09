using Amazon;
using Amazon.Runtime;
using Amazon.SQS;
using Amazon.SQS.Model;
using Kuscotopia.Entities;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Kuscotopia.Services
{
    public class QueueService
    {
        private BasicAWSCredentials credentials;
        private AmazonSQSClient amazonSQSClient;

        private static string QueueUrl = "https://sqs.us-east-2.amazonaws.com/097193507962/temple";

        public QueueService()
        {
            credentials = new BasicAWSCredentials("id", "key"); // add these to run, but remove before committing
            amazonSQSClient = new AmazonSQSClient(credentials, RegionEndpoint.USEast2);
        }

        public async Task QueueWorkAsync(int workType)
        {
            var workEntity = new WorkEntity(workType);

            var sendMessageRequest = new SendMessageRequest()
            {
                QueueUrl = QueueUrl,
                MessageBody = JsonConvert.SerializeObject(workEntity)
            };

            await amazonSQSClient.SendMessageAsync(sendMessageRequest);
        }
    }
}
