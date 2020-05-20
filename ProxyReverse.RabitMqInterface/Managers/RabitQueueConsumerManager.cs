using Base.Core.Services;
using ProxyReverse.RabitMqInterface.Entities;
using ProxyReverse.Web.Core.ExternalyImplementedServices;
using RabbitMQ.Client;
using RabbitMQ.Client.Events;
using System.Text;

namespace ProxyReverse.RabitMqInterface.Managers
{
    internal interface IQueueConsumerManager
    {
        void ConsumeQueue(string queueName, IMessageHandler<string> messageHandler);
    }
    internal class RabitQueueConsumerManager : QueueBase, IQueueConsumerManager
    {
        public RabitQueueConsumerManager(IQueueConfigs queueConfigs,IJsonConvertor jsonConvertor) : base(queueConfigs)
        {
            JsonConvertor = jsonConvertor;
        }

        protected IJsonConvertor JsonConvertor { get; }

        public void ConsumeQueue(string queueName,IMessageHandler<string> messageHandler)
        {
            DeclareQueue(queueName);
            var consumer = new EventingBasicConsumer(Channel);
            consumer.Received += (model, eventArguments) =>
            {
                var body = eventArguments.Body;
                var message = Encoding.UTF8.GetString(body.ToArray());
                messageHandler.HandleMessage(message);
            };

            Channel.BasicConsume(queue: queueName,
                                 autoAck: true,
                                 consumer: consumer);
        }
    }


}