# Node

1. Update the local settings to include the Service Bus connection string.

    local.settings.json

    ```json
    {
    "IsEncrypted": false,
    "Values": {
        "FUNCTIONS_WORKER_RUNTIME": "node",
        "AzureWebJobsStorage": "<storage-account-connection-string>",
        "ServiceBusConnection":  "<service-bus-connection-string>"
       }
    }
    ```

2. Set the `cardinality` property to `many` in the function settings.

    function.json

    ```json
    {
        "bindings": [
          {
             "name": "orders",
             "type": "serviceBusTrigger",
             "direction": "in",
             "queueName": "orders",
             "cardinality": "many",
             "connection": "ServiceBusConnection"
          }
        ]
    }
    ```

3. Update the extension bundle version in the `host.json`. Configure additional optional settings under `extensions`, if necessary.

    host.json

    ```json
    {
    "version": "2.0",  
    "logging": {
        "applicationInsights": {
        "samplingSettings": {
            "isEnabled": true,
            "excludedTypes": "Request"
        }
        }
    },
    "extensions": {
        "serviceBus": {
            "prefetchCount": 4,
            "messageHandlerOptions": {
                "autoComplete": true,
                "maxConcurrentCalls": 4,
                "maxAutoRenewDuration": "00:05:00"
            }
        }
    },
    "extensionBundle": {
        "id": "Microsoft.Azure.Functions.ExtensionBundle",
        "version": "[2.*, 3.0.0)"
        }
    }
    ```
