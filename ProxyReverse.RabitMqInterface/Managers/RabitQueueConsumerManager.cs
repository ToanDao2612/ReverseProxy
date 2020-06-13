using Base.Core.Services;
using ProxyReverse.RabitMqInterface.Entities;
using ProxyReverse.Web.Core.ExternalyImplementedServices;
using RabbitMQ.Client;
using RabbitMQ.Client.Events;
using System.Text;
using System.Threading.Tasks;

namespace ProxyReverse.RabitMqInterface.Managers
{
    internal interface IQueueConsumerManager
    {
        Task ConsumeQueueAsync(string queueName);
    }
    internal class RabitQueueConsumerManager : QueueBase, IQueueConsumerManager
    {
        public RabitQueueConsumerManager(IQueueConfigs queueConfigs,IJsonConvertor jsonConvertor, IMessageHandler<string> messageHandler) : base(queueConfigs)
        {
            JsonConvertor = jsonConvertor;
            MessageHandler = messageHandler;
        }

        protected IJsonConvertor JsonConvertor { get; }
        public IMessageHandler<string> MessageHandler { get; }

        public async Task ConsumeQueueAsync(string queueName)
        {
            DeclareQueue(queueName);
            var consumer = new EventingBasicConsumer(Channel);
            consumer.Received += (model, eventArguments) =>
            {
                var body = eventArguments.Body;
                var message = Encoding.UTF8.GetString(body.ToArray());
                MessageHandler.HandleMessage(message);
            };

            Channel.BasicConsume(queue: queueName,
                                 autoAck: true,
                                 consumer: consumer);
        }
    }


}