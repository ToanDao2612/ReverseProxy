namespace ProxyReverse.Web.Core.ExternalyImplementedServices
{
    public interface IMessageHandler<T>
    {
        void HandleMessage(T data);
    }

}
