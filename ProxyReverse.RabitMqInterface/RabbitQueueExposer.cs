using Base.Core.Services;
using ProxyReverse.RabitMqInterface.Entities;
using ProxyReverse.RabitMqInterface.Managers;
using ProxyReverse.Web.Core.ExternalyImplementedServices;
using ProxyReverse.Web.Core.InternalyImplementedServices.Tunnel.Models;
using System.Text;
using System.Threading.Tasks;

namespace ProxyReverse.RabitMqInterface
{
    internal class RabbitQueueExposer : ITunnelExternalQueueAccessor
    {
        public RabbitQueueExposer(
            IQueueConfigs queueConfigs,
            IQueueProducerManager queueManager,
            IQueueConsumerManager queueConsumerManager,
            IJsonConvertor jsonConvertor)
        {
            QueueConfigs = queueConfigs;
            QueueProducerManager = queueManager;
            QueueConsumerManager = queueConsumerManager;
            JsonConvertor = jsonConvertor;
        }

        protected IQueueConfigs QueueConfigs { get; }
        protected IQueueProducerManager QueueProducerManager { get; }
        protected IQueueConsumerManager QueueConsumerManager { get; }
        protected IJsonConvertor JsonConvertor { get; }

        public void SendDataToQueue(Tunnel tunnel)
            => QueueProducerManager.PublishMessage(GetSerializedMessage(tunnel), QueueConfigs.QueueName);

        public async Task ReceiveWorkAsync()
            => await QueueConsumerManager.ConsumeQueueAsync(QueueConfigs.QueueName);

        private byte[] GetSerializedMessage(object data)
            => Encoding.UTF8.GetBytes(JsonConvertor.ConvertToJson(data));
      
    }
}
