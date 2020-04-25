namespace ProxyReverse.DependencyInjection
{
    public static class ServiceProviderBuilderExtension
    {
        public static IServiceProviderBuilder UseContext<TContext>(this TContext instance)
            where TContext: AbstractApplicationContext, new ()
        {
            var serviceProvderBuilder = new ServiceProviderBuilder();
            serviceProvderBuilder.ConfigureService(ConfigureServiceDelegate =>
            {
                ConfigureServiceDelegate.RegisterInstance<AbstractApplicationContext, TContext>(instance);
            });
            instance.ServiceProviderBuilder = serviceProvderBuilder;
            return serviceProvderBuilder;
        }
    }
}
