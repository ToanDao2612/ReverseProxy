using Newtonsoft.Json;
using ProxyReverse.Web.Core.DataTransferObjects;
using ProxyReverse.Web.Core.ExternalyImplementedServices;
using RabbitMQ.Client;
using System;
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

        public void SendRequest(TunnelRequest httpTunelRequest)
        {
            ConnectionFactory factory = GetConnectionFactory();

            using (var connection = factory.CreateConnection())
            using (var channel = connection.CreateModel())
            {
                channel.QueueDeclare(queue: Configs.QueueName,
                                     durable: false,
                                     exclusive: false,
                                     autoDelete: false,
                                     arguments: null);

                byte[] body = GetSerializedMessage(httpTunelRequest);

                channel.BasicPublish(exchange: "",
                                     routingKey: Configs.QueueName,
                                     basicProperties: null,
                                     body: body);
            }
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

        private static byte[] GetSerializedMessage(TunnelRequest httpTunelRequest)
        {
            string message = JsonConvert.SerializeObject(httpTunelRequest);
            var body = Encoding.UTF8.GetBytes(message);
            return body;
        }
    }
}
