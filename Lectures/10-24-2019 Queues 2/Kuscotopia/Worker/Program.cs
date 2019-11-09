using Amazon;
using Amazon.Runtime;
using Amazon.SQS;
using Amazon.SQS.Model;
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

            credentials = new BasicAWSCredentials("id", "key"); // place these before running, but remove before committing
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
                    // for assignment 8, you'll need to do a JSON convert on the body
                    Console.WriteLine(message.Body);

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
