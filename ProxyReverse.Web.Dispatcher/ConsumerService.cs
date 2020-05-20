using Microsoft.Extensions.Hosting;
using ProxyReverse.Web.Core.ExternalyImplementedServices;
using System.Threading;
using System.Threading.Tasks;

namespace ProxyReverse.Web.Dispatcher
{
    internal class ConsumerService : BackgroundService
    {
        public ConsumerService(ITunnelExternalQueueAccessor tunnelExternalQueueAccessor)
        {
            TunnelExternalQueueAccessor = tunnelExternalQueueAccessor;
        }

        public ITunnelExternalQueueAccessor TunnelExternalQueueAccessor { get; }

        protected override async Task ExecuteAsync(CancellationToken stoppingToken)
        {
            TunnelExternalQueueAccessor.ReceiveWork(new NewConnectorRequestMessageHandler());
        }
    }
}