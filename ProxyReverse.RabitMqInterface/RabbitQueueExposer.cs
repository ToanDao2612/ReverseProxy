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
        public void SendRequest(TunnelRequest httpTunelRequest)
        {
            string UserName = "rabitmquser";
            string Password = "Dev1234@";
            string HostName = "proxyreverse.queue";

            var factory = new ConnectionFactory() { 
                HostName = HostName,
                UserName = UserName,
                Password = Password
            };
            using (var connection = factory.CreateConnection())
            using (var channel = connection.CreateModel())
            {
                channel.QueueDeclare(queue: "hello",
                                     durable: false,
                                     exclusive: false,
                                     autoDelete: false,
                                     arguments: null);

                string message = JsonConvert.SerializeObject(httpTunelRequest);
                var body = Encoding.UTF8.GetBytes(message);

                channel.BasicPublish(exchange: "",
                                     routingKey: "hello",
                                     basicProperties: null,
                                     body: body);
            }

        }
    }
}
