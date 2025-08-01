using kafkaproducerapp.Models;
using kafkaproducerapp.Services;
using Microsoft.AspNetCore.Mvc;

namespace kafkaproducerapp.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class OrderController : ControllerBase
    {
        private readonly IOrderService _orderService;

        public OrderController(IOrderService orderService)
        {
            _orderService = orderService;
        }

        [HttpPost]
        public IActionResult CreateOrder(OrderModel order)
        {
            _orderService.CreateOrder(order);
            return CreatedAtAction(nameof(CreateOrder), order);
        }
    }
}
