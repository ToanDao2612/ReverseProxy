using ProxyReverse.DependencyInjection;
using ProxyReverse.Web.Core.ExternalyImplementedServices;
using System;
using System.Collections.Generic;
using System.Text;

namespace ProxyReverse.RabitMqInterface
{
    public class RabitMqDependencyies : IDependencyConfigurator
    {
        public void ConfigureService(IContainer container)
        {
            container.RegisterType<ITunnelRequestedQueueExposer, RabbitQueueExposer>();
            container.RegisterType<IRabitMqConfigs, RabitMqConfigs>();
        }
    }
}
