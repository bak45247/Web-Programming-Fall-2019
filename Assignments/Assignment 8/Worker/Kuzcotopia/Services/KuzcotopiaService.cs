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
    public class KuzcotopiaService
    {
        private BasicAWSCredentials credentials;
        private AmazonSQSClient amazonSQSClient;

        private static string QueueUrl = "https://sqs.us-east-2.amazonaws.com/097193507962/temple";

        public KuzcotopiaService()
        {
            credentials = new BasicAWSCredentials("key id", "secret key"); // place these before running, but remove before committing
            amazonSQSClient = new AmazonSQSClient(credentials, RegionEndpoint.USEast2);
        }

        public async Task QueueWorkAsync(int work)
        {
            Random random = new Random();

            // loop through and create a number of queue message based on the amount of work we want to recieve
            for(int i = 0; i < work; i++)
            {
                var type = random.Next(0, 3);
                WorkEntity workEntity;

                if(type == 0)
                {
                    workEntity = new WorkEntity() { Type = "carrying", Message = "Peasants are carrying wood!" };
                }
                else if(type == 1)
                {
                    workEntity = new WorkEntity() { Type = "Building", Message = "Peasants are building the waterslides!", Data = random.Next(1, 6) };
                }
                else
                {
                    workEntity = new WorkEntity() { Type = "Surveying", Message = "Peasants are doing a great job!", Data = random.Next(500, 1001) };
                }

                var sendMessageRequest = new SendMessageRequest()
                {
                    QueueUrl = QueueUrl,
                    MessageBody = JsonConvert.SerializeObject(workEntity)
                };

                await amazonSQSClient.SendMessageAsync(sendMessageRequest);
            }
        }
    }
}
