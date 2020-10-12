# .NET

1. Update the local settings to include the Service Bus connection string.

    local.settings.json

    ```json
    {
      "IsEncrypted": false,
      "Values": {
          "FUNCTIONS_WORKER_RUNTIME": "python",
          "AzureWebJobsStorage": "<storage-account-connection-string>",
          "ServiceBusConnection":  "<service-bus-connection-string>"
      }
    }
    ```

2. Get the latest Service Bus extension

    ``` bash
    dotnet add package Microsoft.Azure.WebJobs.Extensions.ServiceBus --version 4.2.0
    ```

3. Update the attribute's constructor to use an array of `Message`.

    ``` csharp
    using Microsoft.Azure.WebJobs;
    using Microsoft.Extensions.Logging;
    using Microsoft.Azure.ServiceBus;

    [FunctionName("ProcessOrders")]
    public static void Run(
        [ServiceBusTrigger("orders", Connection = "ServiceBusConnection")]Message[] orders,
        ILogger log)
    {
        log.LogInformation($"C# ServiceBus queue trigger function invoked");
        log.LogInformation($"Number of orders: {orders.Length}");
    }
    ```
