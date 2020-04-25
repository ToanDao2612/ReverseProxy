using System;
using System.Collections.Generic;
using System.Text;
using Unity;

namespace ProxyReverse.DependencyInjection
{
    public interface IServiceProvider : System.IServiceProvider
    {
        T GetService<T>();
    }
    internal class ServiceProvider : IServiceProvider
    {
        internal IContainer Container { get; private set; }

        internal ServiceProvider() {
            Container = new Container();
        }

        public T GetService<T>() =>(T) GetService(typeof(T));
        public object GetService(Type serviceType) => Container.Resolve(serviceType);
    }
}
