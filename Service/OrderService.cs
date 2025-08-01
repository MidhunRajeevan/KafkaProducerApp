using Confluent.Kafka;
using kafkaproducerapp.Models;

namespace kafkaproducerapp.Services
{
    public class OrderService : IOrderService
    {
        private readonly IProducer<string, string> _producer;

        public OrderService(IProducer<string, string> producer)
        {
            _producer = producer;
        }

        public async Task CreateOrder(OrderModel order)
        {
            var message = new Message<string, string>
            {
                Key = order.Id.ToString(),
                Value = order.ToString()
            };
            try
            {
                var deliveryResult = await _producer.ProduceAsync("orders", message);
                Console.WriteLine($"Message delivered to {deliveryResult.TopicPartitionOffset}");
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Exception occurred while producing message: {ex.Message}");
            }
        }
    }
}
