namespace ProxyReverse.Web.Core.DataTransferObjects
{
    public class HttpTunelRequest : TunnelRequest
    {
        public int Port { get; set; }

        public override TunnelType TunelType => TunnelType.Http;
    }
}