using ProxyReverse.SubdomainCreator;

namespace GoDaddy.SubdomainCreator
{
    internal class FailResponse : IDomainOperationResponse
    {
        public bool IsSuccessful => false;
    }
}