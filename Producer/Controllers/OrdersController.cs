using MassTransit;
using Microsoft.AspNetCore.Mvc;
using SharedModels;

namespace Producer.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class OrdersController : Controller
    {
        private readonly IPublishEndpoint _publishEndpoint;

        public OrdersController(IPublishEndpoint publishEndpoint)
        {
            _publishEndpoint = publishEndpoint;
        }

        [HttpPost]
        public async Task<IActionResult> CreateOrder(OrderDto orderDto)
        {
            await _publishEndpoint.Publish<OrderCreated>(new
            {
                Id = 1,
                orderDto.ProductName,
                orderDto.Price,
                orderDto.Quantity,
            });

            return Ok();
        }
    }
}
