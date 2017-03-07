using System;
using System.IO;
using System.Text;
using Amazon;
using Amazon.Lambda;
using Amazon.Lambda.Model;

namespace ConsoleApplication
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var client = new AmazonLambdaClient(RegionEndpoint.EUWest1);
            var request = new InvokeRequest()
            {
                FunctionName = "HelloWorld-CB",
                Payload = "\"Pat\"",
                LogType = LogType.Tail,
            };

            var result = client.InvokeAsync(request).Result;
            var payload = new StreamReader(result.Payload).ReadToEnd();
            var logOutput = UTF8Encoding.UTF8.GetString(Convert.FromBase64String(result.LogResult));

            Console.WriteLine($"Request returned HTTP {result.StatusCode}: {result.HttpStatusCode}");
            Console.WriteLine($"Result was: '{payload}'");
            Console.WriteLine($"Logging output is shown below:");
            foreach (var line in logOutput.Trim().Split('\r', '\n'))
                Console.WriteLine($"> {line}");
        }
    }
}
