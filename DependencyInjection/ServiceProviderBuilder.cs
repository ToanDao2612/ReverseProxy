using Microsoft.Extensions.DependencyInjection;
using System;

namespace DependencyInjection
{
    public delegate void ConfigureServiceDelegate(IContainer container);
    public interface IServiceProviderBuilder
    {
        IServiceProviderBuilder ConfigureServices(ConfigureServiceDelegate configureServiceDelegate);
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
            => GetServiceProvider(new ServiceProvider(null));

        public IServiceProvider Build(IServiceCollection serviceCollection)
            =>GetServiceProvider(new ServiceProvider(serviceCollection));

        private IServiceProvider GetServiceProvider(ServiceProvider serviceProvider)
        {
            this.RegisterSelf();
            ServiceConfiguratorsEvent.Invoke(serviceProvider.Container);
            return serviceProvider;
        }


        public IServiceProviderBuilder RegisterSelf() =>
            this.ConfigureServices(x => x.RegisterType<IServiceProvider, ServiceProvider>());

        public IServiceProviderBuilder ConfigureServices(ConfigureServiceDelegate configureServiceDelegate)
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
