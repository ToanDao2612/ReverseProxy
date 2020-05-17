using System;
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

        internal ServiceProvider(IUnityContainer unityContainer)=>
            Container = new Container(unityContainer);

        public T GetService<T>() =>(T) GetService(typeof(T));
        public object GetService(Type serviceType) => Container.Resolve(serviceType);
    }
}
