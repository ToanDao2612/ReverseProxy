using Microsoft.Extensions.DependencyInjection;
using System;
using System.Linq;

namespace DependencyInjection
{
    public interface IContainer
    {
        void RegisterSingleton<TInterface, TClass>()
           where TInterface : class
           where TClass : class, TInterface;
        void RegisterType<TInterface, TClass>()

           where TInterface : class
           where TClass : class, TInterface;
        object Resolve(Type type);
        void RegisterInstance<TInterface, TClass>(TClass instance)
           where TInterface : class
           where TClass : class, TInterface;

        void RegisterInstance(Type interfaceType, object instance);
        void RegisterType(Type interfaceType, Type implementationType);
        void RegisterInstance<TInterface>(TInterface instance)
            where TInterface : class;
    }
    public class Container : IContainer
    {
        protected IServiceCollection ServiceCollection { get; }
        protected IServiceProvider _serviceProvider;
        protected IServiceProvider ServiceProvider => _serviceProvider ?? (_serviceProvider = ServiceCollection.BuildServiceProvider());
        internal Container(IServiceCollection serviceCollection = null) 
            =>  ServiceCollection = serviceCollection ?? new ServiceCollection();

        public void RegisterSingleton<TInterface, TClass>()
            where TInterface: class
            where TClass : class,TInterface 
            => ServiceCollection.AddSingleton<TInterface, TClass>();
        public void RegisterType<TInterface, TClass>()
            where TInterface : class
            where TClass : class, TInterface
             => ServiceCollection.AddTransient<TInterface, TClass>();
        public object Resolve(Type type) => ServiceProvider.GetService(type);

        public void RegisterInstance<TInterface, TClass>(TClass instance)
            where TInterface : class
            where TClass : class, TInterface
            => ServiceCollection.AddSingleton<TInterface>(instance);

        public void RegisterInstance<TInterface>(TInterface instance)
            where TInterface : class
            => ServiceCollection.AddSingleton(instance);

        public void RegisterInstance(Type interfaceType, object instance) 
            => ServiceCollection.AddSingleton(interfaceType, instance);

        public void RegisterType(Type interfaceType, Type implementationType)
            => ServiceCollection.AddTransient(interfaceType, implementationType);
    }
}
