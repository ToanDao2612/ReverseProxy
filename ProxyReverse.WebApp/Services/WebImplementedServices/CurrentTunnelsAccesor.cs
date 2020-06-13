using ProxyReverse.Web.Core.InternalyImplementedServices.Tunnel.Models;
using System;
using System.Collections.Concurrent;
using System.Linq;

namespace ProxyReverse.Web.Services.WebImplementedServices
{
    public interface ICurrentTunnelsAccesor 
    {
        void AddTunnel(Tunnel tunnel);
        Tunnel GetTunnelByUrl(string url);
    }

    public class CurrentTunnelsAccesor : ICurrentTunnelsAccesor
    {
        protected ConcurrentBag<Tunnel> Tunnels { get; }
        public CurrentTunnelsAccesor()
        {
            Tunnels = new ConcurrentBag<Tunnel>();
        }

        public void AddTunnel(Tunnel tunnel)
            => Tunnels.Add(tunnel);

        public Tunnel GetTunnelByUrl(string url)
            => Tunnels.FirstOrDefault(x => x.UserUrl.Equals(url, StringComparison.InvariantCultureIgnoreCase));

    }
}
