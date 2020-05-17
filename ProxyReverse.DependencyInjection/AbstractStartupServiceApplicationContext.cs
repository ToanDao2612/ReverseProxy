using System.Threading.Tasks;

namespace ProxyReverse.DependencyInjection
{
    public abstract class AbstractStartupServiceApplicationContext : AbstractApplicationContext
    {
        public async Task StartAsync<TStartUpService>()
           where TStartUpService : IStartUpService
        {
            ServiceProviderBuilder.ConfigureServices(x =>
            {
                x.RegisterSingleton<IStartUpService, TStartUpService>();
            });

            var serviceProvider = Build();

            var startUpService = serviceProvider.GetService<IStartUpService>();
            await startUpService.RunAsync();
        }
    }
}
