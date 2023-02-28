using Microsoft.AspNetCore.Mvc;
using Models;
using ProducerAPI.MessageBroker;
using ProducerAPI.Models;

namespace ProducerAPI.Controllers;

[ApiController]
[Route("api/[controller]")]
public class OrderController : ControllerBase
{
    private readonly IEventBus _eventBus;

    public OrderController(IEventBus eventBus)
    {
        _eventBus = eventBus;
    }

    [HttpPost]
    public async Task<IActionResult> CreateOrder(OrderDto orderDto)
    {
        var order = new Order
        {
            Id = Guid.NewGuid(),
            ProductName = orderDto.ProductName,
            Quantity = orderDto.Quantity,
            Price = orderDto.Price
        };
        await _eventBus.PublishAsync(order);
        return Ok();
    }
}