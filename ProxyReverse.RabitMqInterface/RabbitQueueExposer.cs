using Base.Core.Services;
using ProxyReverse.RabitMqInterface.Entities;
using ProxyReverse.RabitMqInterface.Managers;
using ProxyReverse.Web.Core.DataTransferObjects;
using ProxyReverse.Web.Core.ExternalyImplementedServices;
using System.Text;

namespace ProxyReverse.RabitMqInterface
{
    internal class RabbitQueueExposer : ITunnelExternalQueueAccessor
    {
        internal RabbitQueueExposer(
            IQueueConfigs queueConfigs,
            IQueueProducerManager queueManager,
            IQueueConsumerManager queueConsumerManager,
            IJsonConvertor jsonConvertor)
        {
            QueueConfigs = queueConfigs;
            QueueProducerManagerQueueManager = queueManager;
            QueueConsumerManager = queueConsumerManager;
            JsonConvertor = jsonConvertor;
        }

        private IQueueConfigs QueueConfigs { get; }
        private IQueueProducerManager QueueProducerManagerQueueManager { get; }
        public IQueueConsumerManager QueueConsumerManager { get; }
        public IJsonConvertor JsonConvertor { get; }

        public void SendRequest(AbstractTunnelRequest abstractTunelRequest)
            => QueueProducerManagerQueueManager.PublishMessage(GetSerializedMessage(abstractTunelRequest), QueueConfigs.QueueName);


        public void ReceiveWork(IMessageHandler<string> messageHandler)
            => QueueConsumerManager.ConsumeQueue(QueueConfigs.QueueName,messageHandler);

        private byte[] GetSerializedMessage(object data)
            => Encoding.UTF8.GetBytes(JsonConvertor.ConvertToJson(data));
    }
}
