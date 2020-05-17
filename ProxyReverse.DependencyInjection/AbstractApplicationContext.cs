using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Unity;

namespace ProxyReverse.DependencyInjection
{

    public abstract class AbstractApplicationContext 
    {
        internal ServiceProviderBuilder ServiceProviderBuilder { get; set; }
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
