using Microsoft.AspNetCore.SignalR;
using Microsoft.Extensions.Hosting;
using ProxyReverse.Web.Core.ExternalyImplementedServices;
using ProxyReverse.Web.Services.SignalRHubs;
using System.Threading;
using System.Threading.Tasks;

namespace ProxyReverse.Web.Services.BackgroundWorkers
{

    internal class QueueConsumerBackgroundService : BackgroundService
    {
        public QueueConsumerBackgroundService(
            ITunnelExternalQueueAccessor tunnelExternalQueueAccessor,
            IHubContext<TunnelWebSocketHub> hubContext
            )
        {
            TunnelExternalQueueAccessor = tunnelExternalQueueAccessor;
            HubContext = hubContext;
        }

        public ITunnelExternalQueueAccessor TunnelExternalQueueAccessor { get; }
        public IHubContext<TunnelWebSocketHub> HubContext { get; }

        protected override async Task ExecuteAsync(CancellationToken stoppingToken)
            => 
            await TunnelExternalQueueAccessor.ReceiveWorkAsync();
    }
}