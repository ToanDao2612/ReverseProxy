using System.Threading.Tasks;

namespace ProxyReverse.SubdomainCreator
{
    public interface IDomainManager
    {
        public Task<IDomainOperationResponse> CreateSubdomainAsnyc(CreateDomainModel createDomainModel);
    }
}
