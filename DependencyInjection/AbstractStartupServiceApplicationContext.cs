using System.Threading.Tasks;

namespace DependencyInjection
{
    public abstract class AbstractStartupServiceApplicationContext : AbstractApplicationContext
    {
        public async Task StartAsync<TStartUpService>()
           where TStartUpService : class,IStartUpService
        {
            ServiceProviderBuilder.ConfigureServices(x =>
            {
                x.RegisterSingleton<IStartUpService, TStartUpService>();
            });

            var serviceProvider = Build();

            var startUpService = (IStartUpService)serviceProvider.GetService(typeof(IStartUpService));
            await startUpService.RunAsync();
        }
    }
}
