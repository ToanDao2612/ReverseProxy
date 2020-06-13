using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Http.Extensions;
using ProxyReverse.Web.Core.ExternalyImplementedServices;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ProxyReverse.WebApp.Services.WebImplementedServices
{
    public class ContextProvider : IContextProvider
    {
        public ContextProvider(IHttpContextAccessor httpContextAccessor)
        {
            HttpContextAccessor = httpContextAccessor;
        }

        public IHttpContextAccessor HttpContextAccessor { get; }

        public string GetRequestUrl()
        {
            return HttpContextAccessor.HttpContext.Request.GetEncodedUrl();
        }
    }
}
