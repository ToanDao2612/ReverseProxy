using System;
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
    }
    public class Container : IContainer
    {
        protected UnityContainer UnityContainer { get; }
        internal Container()
        {
            UnityContainer = new UnityContainer();
        }
        public void RegisterSingleton<TInterface, TClass>()
            where TClass : TInterface => UnityContainer.RegisterSingleton<TInterface, TClass>();
        public void RegisterType<TInterface, TClass>()
            where TClass : TInterface => UnityContainer.RegisterType<TInterface, TClass>();
        public object Resolve(Type type) => UnityContainer.Resolve(type);

        public void RegisterInstance<TInterface, TClass>(TClass instance)
            where TClass : TInterface => UnityContainer.RegisterInstance<TInterface>(instance);
    }
}
