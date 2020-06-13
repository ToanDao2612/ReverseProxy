using System;
using System.Collections.Generic;
using System.Text;

namespace ProxyReverse.Web.Core.InternalyImplementedServices.Tunnel.Models
{
    public struct Tunnel
    {
        public Tunnel(TunnelType tunelType, string userUrl, int userId)
        {
            TunelType = tunelType;
            UserUrl = userUrl;
            UserId = userId;
        }

        public TunnelType TunelType { get; }
        public string UserUrl { get; set; }
        public int UserId { get; set; }

        public override bool Equals(object obj)
        {
            return obj is Tunnel tunnel &&
                   TunelType == tunnel.TunelType &&
                   UserUrl == tunnel.UserUrl &&
                   UserId == tunnel.UserId;
        }

        public override int GetHashCode() => ToString().GetHashCode();
        public override string ToString() => $"{TunelType}-{UserId}-{UserUrl}";
    }

    public enum TunnelType
    {
        Http,
        Tcp,
        Ftp
    }
}
