using ProxyReverse.Web.Core.InternalyImplementedServices.Tunnel.Models;
using System.Threading.Tasks;

namespace ProxyReverse.Web.Core.ExternalyImplementedServices
{
    public interface ITunnelExternalQueueAccessor
    {
        void SendDataToQueue(Tunnel httpTunelRequest);
        Task ReceiveWorkAsync();
    }
}
