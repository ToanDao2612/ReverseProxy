using System;
using System.Collections.Generic;
using System.Text;
using Unity;

namespace ProxyReverse.DependencyInjection
{
    public delegate void ConfigureServiceDelegate(IContainer container);
    public interface IServiceProviderBuilder
    {
        IServiceProviderBuilder ConfigureService(ConfigureServiceDelegate configureServiceDelegate);
        IServiceProviderBuilder ConfigureServices<TDependencyConfigurator>()
            where TDependencyConfigurator : IDependencyConfigurator, new();
    }

    public class ServiceProviderBuilder : IServiceProviderBuilder
    {
        internal ServiceProviderBuilder()
        {
        }
        public IServiceProviderBuilder _instance { get; set; }
        public IServiceProviderBuilder Instance { get => _instance ?? (_instance = new ServiceProviderBuilder()); }
        public event ConfigureServiceDelegate ServiceConfiguratorsEvent; 
        public IServiceProvider Build()
        {
            var serviceProvider = new ServiceProvider();
            serviceProvider.Container.RegisterSingleton<IServiceProvider, ServiceProvider>();
            ServiceConfiguratorsEvent.Invoke(serviceProvider.Container);
            return serviceProvider;
        }

        public IServiceProviderBuilder ConfigureService(ConfigureServiceDelegate configureServiceDelegate)
        {
            ServiceConfiguratorsEvent += configureServiceDelegate;
            return this;
        }

        public IServiceProviderBuilder ConfigureServices<TDependencyConfigurator>()
            where TDependencyConfigurator : IDependencyConfigurator, new()
        {
            var dependencyConfigurator = new TDependencyConfigurator();
            ServiceConfiguratorsEvent += dependencyConfigurator.ConfigureService;
            return this;
        }
    }
}
