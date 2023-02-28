using MassTransit;
using Models;
using Newtonsoft.Json;

namespace ConsumerConsoleApp;

public class OrderCreatedConsumer : IConsumer<Order>
{
    public Task Consume(ConsumeContext<Order> context)
    {
        var jsonMessage = JsonConvert.SerializeObject(context.Message);
        Console.WriteLine($"OrderCreated message: {jsonMessage}");
        return Task.CompletedTask;
    }
}