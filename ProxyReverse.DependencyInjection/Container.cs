using Microsoft.Extensions.DependencyInjection;
using System;
using System.Linq;
using Unity;

namespace ProxyReverse.DependencyInjection
{
    public interface IContainer
    {
        void RegisterSingleton<TInterface, TClass>()
           where TClass : TInterface;
        void RegisterType<TInterface, TClass>()
           where TClass : TInterface;
        object Resolve(Type type);
        void RegisterInstance<TInterface, TClass>(TClass instance)
            where TClass : TInterface;

        void RegisterInstance(Type interfaceType, object instance);
        void RegisterType(Type interfaceType, Type implementationType);
        void RegisterFactory(Type type, Func<System.IServiceProvider, object> func);
    }
    public class Container : IContainer
    {
        protected IUnityContainer UnityContainer { get; }
        internal Container(IUnityContainer unityContainer) 
            => UnityContainer = unityContainer ?? new UnityContainer();

        public void RegisterSingleton<TInterface, TClass>()
            where TClass : TInterface => UnityContainer.RegisterSingleton<TInterface, TClass>();
        public void RegisterType<TInterface, TClass>()
            where TClass : TInterface => UnityContainer.RegisterType<TInterface, TClass>();
        public object Resolve(Type type) => UnityContainer.Resolve(type);

        public void RegisterInstance<TInterface, TClass>(TClass instance)
            where TClass : TInterface => UnityContainer.RegisterInstance<TInterface>(instance);

        public void RegisterInstance(Type interfaceType, object instance) 
            => UnityContainer.RegisterInstance(interfaceType, instance);

        public void RegisterType(Type interfaceType, Type implementationType)
            => UnityContainer.RegisterType(interfaceType, implementationType);

        public void RegisterFactory(Type type,Func<System.IServiceProvider, object> func) 
            => UnityContainer.RegisterFactory(type, x =>
            {
                var s = x.Resolve<System.IServiceProvider>();
                var  r = func(s);
                return r;
            });
    }
}
