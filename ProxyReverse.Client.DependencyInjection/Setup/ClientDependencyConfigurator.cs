using ProxyReverse.Client.ConfigReader;
using ProxyReverse.Client.Connection;
using ProxyReverse.Client.Connectors;
using ProxyReverse.Client.HttpRequester;
using ProxyReverse.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Text;

namespace ProxyReverse.Client.DependencyInjection.Setup
{
    internal class ClientDependencyConfigurator : IDependencyConfigurator
    {
        public ClientDependencyConfigurator()
        {
        }

        public void ConfigureService(IContainer container)
        {
            container.RegisterType<IApplicationConfigReader, ApplicationConfigReader>();
            container.RegisterType<IWebRequest, WebRequest>();
            container.RegisterType<IConectionRequestProvider, ConectionRequestProvider>();
            container.RegisterType<IConnectorFactory, ConnectorFactory>();
        }
    }
}
