
using MassTransit;
using Newtonsoft.Json;
using SharedModels;
using System.Text.Json.Serialization;

var busControl = Bus.Factory.CreateUsingRabbitMq(cfg =>
{
    cfg.ReceiveEndpoint("order-created-event", e =>
    {
        e.Consumer<OrderCreatedConsumer>();
    });
});

await busControl.StartAsync(new CancellationToken());
try
{
    Console.WriteLine("Press enter to exit");
    await Task.Run(() => Console.ReadLine());
}
finally
{
    await busControl.StopAsync();
}


public class OrderCreatedConsumer : IConsumer<OrderCreated>
{
    public async Task Consume(ConsumeContext<OrderCreated> context)
    {
        var jsonMessage = JsonConvert.SerializeObject(context.Message);

        Console.WriteLine($"Order Created Message : {jsonMessage}");
    }
}
