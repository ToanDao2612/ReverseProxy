using ProxyReverse.RabitMqInterface.Entities;
using RabbitMQ.Client;
using System;

namespace ProxyReverse.RabitMqInterface.Managers
{
    internal interface IQueueProducerManager : IDisposable
    {
        void PublishMessage(byte[] body, string queueName);
    }

    internal class RabitQueueProducerManager : QueueBase,IQueueProducerManager
    {
        public RabitQueueProducerManager(IQueueConfigs queueConfigs) : base(queueConfigs) { }

        public void PublishMessage(byte[] body, string queueName)
        {
            DeclareQueue(queueName);
            Channel.BasicPublish(exchange: "",
                                                routingKey: QueueConfigs.QueueName,
                                                basicProperties: null,
                                                body: body);
        }
    }

}