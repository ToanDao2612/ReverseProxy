using System;
using System.Collections.Generic;
using System.Text;

namespace ProxyReverse.Client.Connectors
{
    public class ConnectorFactory : IConnectorFactory
    {
        public Tunnel CreateTunnel(HttpRequester.Models.ConnectionResponse connectionResponse)
        {
            return new Tunnel();
        }
    }

    public interface IConnectorFactory
    {
        Tunnel CreateTunnel(HttpRequester.Models.ConnectionResponse connectionResponse);
    }
}
