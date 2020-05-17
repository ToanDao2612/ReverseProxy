using Newtonsoft.Json;
using ProxyReverse.Web.Core.DataTransferObjects;
using ProxyReverse.Web.Core.ExternalyImplementedServices;
using RabbitMQ.Client;
using System.Text;

namespace ProxyReverse.RabitMqInterface
{

    public class RabbitQueueExposer : ITunnelRequestedQueueExposer
    {
        public RabbitQueueExposer(IRabitMqConfigs configs)
        {
            Configs = configs;
        }

        public IRabitMqConfigs Configs { get; }

        public void SendRequest(AbstractTunnelRequest httpTunelRequest)
        {

            var channel = GetChannel();
            DeclareQueue(channel);
            byte[] body = GetSerializedMessage(httpTunelRequest);
            PublishMessage(channel, body);
        }

        private void PublishMessage(IModel channel, byte[] body)
        {
            channel.BasicPublish(exchange: "",
                                                routingKey: Configs.QueueName,
                                                basicProperties: null,
                                                body: body);
        }

        private void DeclareQueue(IModel channel)
        {
            channel.QueueDeclare(queue: Configs.QueueName,
                                                durable: false,
                                                exclusive: false,
                                                autoDelete: false,
                                                arguments: null);
        }

        private ConnectionFactory GetConnectionFactory()
        {
            return new ConnectionFactory()
            {
                HostName = Configs.HostName,
                UserName = Configs.UserName,
                Password = Configs.Password
            };
        }

        private IModel GetChannel()
        {
            ConnectionFactory factory = GetConnectionFactory();
            var connection = factory.CreateConnection();
            return connection.CreateModel();
        }

        private static byte[] GetSerializedMessage(AbstractTunnelRequest httpTunelRequest)
        {
            string message = JsonConvert.SerializeObject(httpTunelRequest);
            var body = Encoding.UTF8.GetBytes(message);
            return body;
        }
    }
}
