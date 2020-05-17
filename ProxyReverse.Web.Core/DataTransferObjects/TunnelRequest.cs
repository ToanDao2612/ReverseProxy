using System;
using System.Collections.Generic;
using System.Text;

namespace ProxyReverse.Web.Core.DataTransferObjects
{
    public abstract class TunnelRequest
    {
        public abstract TunnelType TunelType { get; }
    }

    public enum TunnelType
    {
        Http,
        Tcp,
        Ftp
    }
}
