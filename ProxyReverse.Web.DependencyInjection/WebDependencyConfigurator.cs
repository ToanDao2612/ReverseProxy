using ProxyReverse.DependencyInjection;

namespace ProxyReverse.Web.DependencyInjection
{
    public interface IDummyService
    {
        string GetData();
    }

    internal class DummyService : IDummyService
    {
        public string GetData()
        {
            return "This is the data you need";
        }
    }

    public class WebDependencyConfigurator : IDependencyConfigurator
    {
        public void ConfigureService(IContainer container)
        {
            container.RegisterType<IDummyService, DummyService>();
        }
    }
}