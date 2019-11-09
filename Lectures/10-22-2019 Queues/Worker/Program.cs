using System;
using System.Threading.Tasks;
using Amazon;
using Amazon.Runtime;
using Amazon.SQS;
using Amazon.SQS.Model;

namespace Worker
{
    class Program
    {
        private static BasicAWSCredentials credentials;
        private static AmazonSQSClient amazonSQSClient;

        private static string QueueURL = "queue url found in the Queues sqs page";

        static void Main(string[] args)
        {
            Console.WriteLine("Starting to read messages");

            credentials = new BasicAWSCredentials("accesskey", "secretkey"); // do not check these keys in
            amazonSQSClient = new AmazonSQSClient(credentials, RegionEndpoint.USEast1);

            ReadMessagesAsync().Wait();
        }

        public static async Task ReadMessagesAsync()
        {
            var request = new ReceiveMessageRequest();
            request.QueueUrl = QueueURL;
            request.MaxNumberOfMessages = 10; // says we'll grab 10 messages every request if there are 10 messages to grab
            request.WaitTimeSeconds = 10; // how long to block on the call before we loop again

            while (true)
            {
                var messages = await amazonSQSClient.ReceiveMessageAsync(request);

                foreach (var message in messages.Messages)
                {
                    // assigment 8, i need to do a JSON convert on the body
                    Console.WriteLine(message.Body);

                    var deleteTask = amazonSQSClient.DeleteMessageAsync(new DeleteMessageRequest()
                    {
                        QueueUrl = QueueURL,
                        ReceiptHandle = message.ReceiptHandle
                    });

                    // deleteTask.ContinueWith
                    // use this for stretch level in kuzcotopia
                    // able to call it only if the message fails to delete
                }
            }
        }
    }
}
