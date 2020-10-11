using System;
using Microsoft.Azure.WebJobs;
using Microsoft.Azure.WebJobs.Host;
using Microsoft.Extensions.Logging;
using Microsoft.Azure.ServiceBus;

namespace dotnet
{
    public static class ProcessOrders
    {
        [FunctionName("ProcessOrders")]
        public static void Run(
            [ServiceBusTrigger("orders", Connection = "ServiceBusConnection")]Message[] orders, 
            ILogger log)
        {
            log.LogInformation($"C# ServiceBus queue trigger function invoked");
            log.LogInformation($"Number of orders: {orders.Length}");
        }
    }
}
