using Microsoft.Extensions.DependencyInjection;
using System;

namespace DependencyInjection
{

    public abstract class AbstractApplicationContext 
    {
        protected AbstractApplicationContext()
        {
            var serviceProvderBuilder = new ServiceProviderBuilder();
            serviceProvderBuilder.ConfigureServices(ConfigureServiceDelegate =>
            {
                ConfigureServiceDelegate.RegisterInstance(this);
            });
            ServiceProviderBuilder = serviceProvderBuilder;
        }

        protected ServiceProviderBuilder ServiceProviderBuilder { get; set; }
        protected void OnStart() { }
        protected void OnEnd() { }

        public IServiceProvider Build()
        {
            OnStart();
            var serviceProvider = ServiceProviderBuilder.Build();
            OnEnd();
            return serviceProvider;
        }

        public IServiceProvider Build(IServiceCollection serviceCollection, ConfigureServiceDelegate configureServiceDelegate = null)
        {
            ConfigureServiceDelegate emptyConfigureFunction = x => { };
            ServiceProviderBuilder.ConfigureServices(configureServiceDelegate ?? emptyConfigureFunction);
            OnStart();
            var serviceProvider = ServiceProviderBuilder.Build(serviceCollection);
            OnEnd();
            return serviceProvider;
        }
    }
}
