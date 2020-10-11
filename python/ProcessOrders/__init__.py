import logging
import json
import azure.functions as func

def main(orders: func.ServiceBusMessage):
    
    logging.info('Python ServiceBus queue trigger function invoked')    

    orders_data_bytes = orders.get_body().decode('utf-8')
    
    data = json.loads(orders_data_bytes)
    print('Number of orders: ' + str(len(data)))
    
    #for o in data:
    #   print(o)
