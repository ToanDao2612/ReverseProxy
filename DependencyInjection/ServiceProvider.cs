using Microsoft.Extensions.DependencyInjection;
using System;

namespace DependencyInjection
{
    internal class ServiceProvider : IServiceProvider
    {
        internal IContainer Container { get; private set; }

        public ServiceProvider() =>
            Container = new Container();

        public ServiceProvider(IServiceCollection serviceCollection)=>
            Container = new Container(serviceCollection);

        public T GetService<T>() =>(T) GetService(typeof(T));
        public object GetService(Type serviceType) => Container.Resolve(serviceType);
    }
}
