using ProxyReverse.Web.Core.InternalyImplementedServices.Tenant.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ProxyReverse.Web.Core.InternalyImplementedServices.Request
{
    public struct ApplicationRequest
    {
        public ApplicationRequest(ApplicationTenant applicationTenant)
        {
            ApplicationTenant = applicationTenant;
            RequestId = Guid.NewGuid();
        }

        public ApplicationTenant ApplicationTenant { get; }
        public Guid RequestId { get; }

        public override bool Equals(object obj)
        {
            return obj is ApplicationRequest request &&
                   EqualityComparer<ApplicationTenant>.Default.Equals(ApplicationTenant, request.ApplicationTenant) &&
                   RequestId.Equals(request.RequestId);
        }

        public override int GetHashCode() => ToString().GetHashCode();
        public override string ToString() => $"{ApplicationTenant}-{RequestId}";
    }
}
