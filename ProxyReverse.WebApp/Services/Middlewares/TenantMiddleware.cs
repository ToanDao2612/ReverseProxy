using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.DependencyInjection;
using ProxyReverse.Web.Core.InternalyImplementedServices.Request;
using ProxyReverse.Web.Core.InternalyImplementedServices.Tenant;
using ProxyReverse.Web.Services.Orchestrator;
using System.Threading.Tasks;

namespace ProxyReverse.Web.Services.Middlewares
{
    public class TenantMiddleware
    {
        private readonly RequestDelegate _next;

        public TenantMiddleware(RequestDelegate next, 
            ITenantProvider tenantProvider, 
            IRequestOrchestrator requestOrchestrator)
        {
            _next = next;
            TenantProvider = tenantProvider;
            RequestOrchestrator = requestOrchestrator;
        }

        public ITenantProvider TenantProvider { get; }
        public IRequestOrchestrator RequestOrchestrator { get; }

        public async Task InvokeAsync(HttpContext context)
        {
            var tenant = TenantProvider.GetTenant();
            if(tenant.IsUserTenant)
            {
                await RequestOrchestrator.RedirectRequestToClient(context, new ApplicationRequest(tenant));
            }
            else
            {
                await _next(context);
            }
        }
    }
}