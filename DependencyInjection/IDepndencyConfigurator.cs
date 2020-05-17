namespace DependencyInjection
{
    public interface IDependencyConfigurator
    {
        void ConfigureService(IContainer container);
    }
}
