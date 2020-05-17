using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using ProxyReverse.Web.DependencyInjection;
using Unity;

namespace ProxyReverse.WebApi
{
    public class Startup 
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
            WebApplicationContext = new WebApplicationContext();
        }

        public IConfiguration Configuration { get; }
        public WebApplicationContext WebApplicationContext { get; }

        public void ConfigureServices(IServiceCollection services)
            => services.AddControllers();

        public void ConfigureContainer(IUnityContainer container)
            => WebApplicationContext.Build(container);

        public void Configure(IApplicationBuilder app)
            => app.UseDeveloperExceptionPage()
                    .UseHttpsRedirection()
                    .UseRouting()
                    .UseAuthorization()
                    .UseEndpoints(endpoints =>
                {
                    endpoints.MapControllers();
                });
    }
}
