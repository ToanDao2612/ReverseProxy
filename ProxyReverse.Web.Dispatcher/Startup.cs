using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using ProxyReverse.Web.DependencyInjection;
using Unity;

namespace ProxyReverse.Web.Dispatcher
{
    public class Startup
    {
        public Startup()
        {
            WebApplicationContext = new WebApplicationContext();
        }

        public WebApplicationContext WebApplicationContext { get; }
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddHostedService<ConsumerService>();
        }

        public void ConfigureContainer(IUnityContainer container)
            => WebApplicationContext.Build(container);

        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseRouting()
               .UseEndpoints(endpoints =>
            {
                endpoints.MapGet("/", async context =>
                {
                    await context.Response.WriteAsync("Hello World!");
                });
            });
        }
    }
}
