using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace ProxyReverse.DependencyInjection
{
    public abstract class AbstractApplicationContext 
    {
        internal ServiceProviderBuilder ServiceProviderBuilder { get; set; }
        protected async Task OnStartAsync() { }
        protected async Task OnEndAsync() { }
        public async Task StartAsync<TStartUpService>()
            where TStartUpService : IStartUpService
        {
            ServiceProviderBuilder.ConfigureService(x =>
            {
                x.RegisterSingleton<IStartUpService, TStartUpService>();
            });
            var serviceProvider = ServiceProviderBuilder.Build();
            await OnStartAsync();
            var startUpService = serviceProvider.GetService<IStartUpService>();
            await startUpService.RunAsync();
            await OnEndAsync();
        }
    }
}
