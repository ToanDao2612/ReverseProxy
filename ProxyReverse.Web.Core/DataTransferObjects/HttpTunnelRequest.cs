namespace ProxyReverse.Web.Core.DataTransferObjects
{
    public class HttpTunelRequest : AbstractTunnelRequest
    {
        public int Port { get; set; }

        public override TunnelType TunelType => TunnelType.Http;
    }
}