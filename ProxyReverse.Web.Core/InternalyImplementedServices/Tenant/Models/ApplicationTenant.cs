using System;
using System.Collections.Generic;
using System.Text;

namespace ProxyReverse.Web.Core.InternalyImplementedServices.Tenant.Models
{
    public struct ApplicationTenant
    {
        public string Url { get; }
        public bool IsUserTenant { get; }
        public ApplicationTenant(string url,bool isUserTenant)
        {
            Url = url;
            IsUserTenant = isUserTenant; 
        }
        public override bool Equals(object obj)
        {
            return obj is ApplicationTenant tenant &&
                   Url.Equals(tenant.Url,StringComparison.InvariantCultureIgnoreCase)&&
                   Url.Equals(tenant.Url, StringComparison.InvariantCultureIgnoreCase);
        }

        public override int GetHashCode() => ToString().GetHashCode();
        public override string ToString() => $"{Url}-{IsUserTenant}";
    }
}
