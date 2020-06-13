using ProxyReverse.Web.Core.ExternalyImplementedServices;
using ProxyReverse.Web.Core.InternalyImplementedServices.Tenant.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ProxyReverse.Web.Core.InternalyImplementedServices.Tenant
{
    public interface ITenantProvider
    {
        ApplicationTenant GetTenant();
    }
    public class TenantProvider : ITenantProvider
    {
        private IConfigurationProvider ConfigProvider { get; }
        private IContextProvider ContextProvider { get; }
        private string _tenantUrl;
        private bool _isUserTenant;
        public TenantProvider(
            IContextProvider contextProvider,
            IConfigurationProvider configProvider)
        {
            ContextProvider = contextProvider;
            ConfigProvider = configProvider;
        }

        public ApplicationTenant GetTenant()
            => new ApplicationTenant(TenantUrl,IsUserTenant);

        private string TenantUrl { get => _tenantUrl ?? (_tenantUrl = ContextProvider.GetRequestUrl()); }

        public bool IsUserTenant
        {
            get
            {
                var applicationMainUrls = ConfigProvider.GetMainUrls();
                var isMainUrl = applicationMainUrls.Any(x => x.Equals(TenantUrl, StringComparison.InvariantCultureIgnoreCase));
                return !isMainUrl;
            }
        }
    }
}
