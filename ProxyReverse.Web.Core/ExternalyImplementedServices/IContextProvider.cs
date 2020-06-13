using System;
using System.Collections.Generic;
using System.Text;

namespace ProxyReverse.Web.Core.ExternalyImplementedServices
{
    public interface IContextProvider
    {
        string GetRequestUrl();
    }
}
