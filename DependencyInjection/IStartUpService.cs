using System.Threading.Tasks;

namespace DependencyInjection
{
    public interface IStartUpService
    {
        Task RunAsync();
    }
}
