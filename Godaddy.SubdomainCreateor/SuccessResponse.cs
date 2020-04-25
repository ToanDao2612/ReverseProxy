using ProxyReverse.SubdomainCreator;

namespace GoDaddy.SubdomainCreator
{
    internal class SuccessResponse : IDomainOperationResponse
    {
        public bool IsSuccessful => true;
    }
}