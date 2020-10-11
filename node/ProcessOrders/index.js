module.exports = async function(context, orders) {
    
    context.log('JavaScript ServiceBus queue trigger function invoked');
    context.log('Number of orders: ' + orders.length);
    
    // orders.forEach((msg, index) => {
    //     context.log(`Index: ${index}`);
    //     context.log(`Message: ${msg}`);
    // });    
};