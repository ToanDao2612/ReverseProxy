using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.SpaServices.AngularCli;
using Microsoft.EntityFrameworkCore;
using ProxyReverse.WebApp.Data;
using ProxyReverse.WebApp.Models;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using ProxyReverse.Web.DependencyInjection;
using ProxyReverse.Web.Services.BackgroundWorkers;
using ProxyReverse.Web.Core.ExternalyImplementedServices;
using ProxyReverse.Web.Services.WebImplementedServices;
using ProxyReverse.Web.Services.Orchestrator;
using ProxyReverse.Web.Services.Identity;
using ProxyReverse.Web.Services.Middlewares;
using ProxyReverse.Web.Services.SignalRHubs;
using ProxyReverse.WebApp.Services.WebImplementedServices.Models;
using ProxyReverse.WebApp.Services.WebImplementedServices;

namespace ProxyReverse.WebApp
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
            WebApplicationContext = new WebApplicationContext();
        }
        public WebApplicationContext WebApplicationContext { get; }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddDbContext<ApplicationDbContext>(options =>
                options.UseSqlServer(
                    Configuration.GetConnectionString("DefaultConnection")));

            //services.AddDbContext<ApplicationDbContext>(options =>
            //    options.UseInMemoryDatabase("InMemeory"));


            services.AddDefaultIdentity<ApplicationUser>(options => options.SignIn.RequireConfirmedAccount = true)
                .AddEntityFrameworkStores<ApplicationDbContext>();

            services.AddIdentityServer()
                .AddApiAuthorization<ApplicationUser, ApplicationDbContext>();

            services.AddAuthentication()
                .AddIdentityServerJwt();

            services.AddSignalR();
            services.AddControllersWithViews();
            services.AddRazorPages();
            // In production, the Angular files will be served from this directory
            services.AddSpaStaticFiles(configuration =>
            {
                configuration.RootPath = "ClientApp/dist";
            });

            services.AddHttpContextAccessor();
            services.AddScoped<IIdentityProvider, IdentityProvider>();
            
            var appplicationDefaultConfigs = new ApplicationDefaultConfig();
            Configuration.Bind(ApplicationDefaultConfig.ApplicationDefaultConfigKey, appplicationDefaultConfigs);
            services.AddSingleton(appplicationDefaultConfigs);

            WebApplicationContext.Build(services,x => {
                    x.RegisterSingleton<IMessageHandler<string>, NewConnectorRequestMessageHandler>();
                    x.RegisterSingleton<IRequestsDictionaryAccesor, RequestsDictionaryAccesor>();
                    x.RegisterSingleton<IRequestOrchestrator, RequestOrchestrator>();
                    x.RegisterSingleton<Web.Core.ExternalyImplementedServices.IConfigurationProvider, ConfigProvider>();
                    
                    x.RegisterType<IContextProvider, ContextProvider>();
                    x.RegisterType<ICurrentTunnelsAccesor, CurrentTunnelsAccesor>();
            });

            services.AddHostedService<QueueConsumerBackgroundService>();
        }

        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
                app.UseDatabaseErrorPage();
            }
            else
            {
                app.UseExceptionHandler("/Error");
                app.UseHsts();
            }

            app.UseMiddleware<TenantMiddleware>();
            app.UseHttpsRedirection();
            app.UseStaticFiles();
            if (!env.IsDevelopment())
            {
                app.UseSpaStaticFiles();
            }

            app.UseRouting();

            app.UseAuthentication();
            app.UseIdentityServer();
            app.UseAuthorization();
            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllerRoute(
                    name: "default",
                    pattern: "{controller}/{action=Index}/{id?}");
                endpoints.MapRazorPages();
                endpoints.MapHub<TunnelWebSocketHub>("/tunnel");
            });

            app.UseSpa(spa =>
            {
                spa.Options.SourcePath = "ClientApp";

                if (env.IsDevelopment())
                {
                    spa.UseAngularCliServer(npmScript: "start");
                }
            });
        }
    }
}
