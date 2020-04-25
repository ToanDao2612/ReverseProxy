using System.Threading.Tasks;

namespace ProxyReverse.DependencyInjection
{
    public interface IStartUpService
    {
        Task RunAsync();
    }
}
