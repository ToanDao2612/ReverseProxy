using DependencyInjection;
using ProxyReverse.RabitMqInterface.Entities;
using ProxyReverse.RabitMqInterface.Managers;
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
            container.RegisterType<ITunnelExternalQueueAccessor, RabbitQueueExposer>();
            container.RegisterType<IQueueConfigs, RabitMqConfigs>();
            container.RegisterType<IQueueProducerManager, RabitQueueProducerManager>();
            container.RegisterType<IQueueConsumerManager, RabitQueueConsumerManager>();
        }
    }
}