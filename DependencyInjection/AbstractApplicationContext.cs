using System;
using Unity;

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

        public IServiceProvider Build(IUnityContainer unityContainer)
        {
            OnStart();
            var serviceProvider = ServiceProviderBuilder.Build(unityContainer);
            OnEnd();
            return serviceProvider;
        }
    }
}
