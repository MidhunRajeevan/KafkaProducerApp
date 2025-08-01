

using kafkaproducerapp.Models;

namespace kafkaproducerapp.Services
{
    public interface IOrderService
    {
        Task CreateOrder(OrderModel order);
    }
}
