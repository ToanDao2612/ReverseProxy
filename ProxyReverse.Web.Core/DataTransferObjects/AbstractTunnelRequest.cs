using System;
using System.Collections.Generic;
using System.Text;

namespace ProxyReverse.Web.Core.DataTransferObjects
{
    public abstract class AbstractTunnelRequest
    {
        public abstract TunnelType TunelType { get; }
        public string UserUrl { get; set; }
    }

    public enum TunnelType
    {
        Http,
        Tcp,
        Ftp
    }
}
