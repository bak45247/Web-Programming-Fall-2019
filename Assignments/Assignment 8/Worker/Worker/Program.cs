using Amazon;
using Amazon.Runtime;
using Amazon.SQS;
using Amazon.SQS.Model;
using Kuscotopia.Entities;
using Newtonsoft.Json;
using System;
using System.Threading.Tasks;

namespace Worker
{
    class Program
    {
        private static BasicAWSCredentials credentials;
        private static AmazonSQSClient amazonSQSClient;

        private static string QueueUrl = "https://sqs.us-east-2.amazonaws.com/097193507962/temple";

        static void Main(string[] args)
        {
            Console.WriteLine("Starting to read messages...");

            credentials = new BasicAWSCredentials("key id", "secret key"); // place these before running, but remove before committing
            amazonSQSClient = new AmazonSQSClient(credentials, RegionEndpoint.USEast2);

            ReadMessagesAsync().Wait();
        }

        public static async Task ReadMessagesAsync()
        {
            var request = new ReceiveMessageRequest();
            request.QueueUrl = QueueUrl;
            request.MaxNumberOfMessages = 10;
            request.WaitTimeSeconds = 10;

            while (true)
            {
                var messages = await amazonSQSClient.ReceiveMessageAsync(request);

                foreach (var message in messages.Messages)
                {
                    var work = JsonConvert.DeserializeObject<WorkEntity>(message.Body);
                    Console.WriteLine(work.Message);

                    if(work.Type.Equals("Building"))
                    {
                        Console.WriteLine(work.Data);

                        if (work.Data > 0)
                        {
                            work.Data -= 1;
                            var sendMessageRequest = new SendMessageRequest()
                            {
                                QueueUrl = QueueUrl,
                                MessageBody = JsonConvert.SerializeObject(work)
                            };

                            await amazonSQSClient.SendMessageAsync(sendMessageRequest);
                        }
                    }
                    else if (work.Type.Equals("Surveying"))
                    {
                        Console.WriteLine("Starting to survey");
                        await Task.Delay(work.Data);
                        Console.WriteLine("Survey complete");
                    }

                        var deleteTask = amazonSQSClient.DeleteMessageAsync(new DeleteMessageRequest()
                    {
                        QueueUrl = QueueUrl,
                        ReceiptHandle = message.ReceiptHandle
                    });
                }
            }
        }
    }
}
