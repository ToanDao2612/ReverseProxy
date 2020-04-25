using System;
using System.Collections.Generic;
using System.Text;

namespace ProxyReverse.DependencyInjection
{
    public interface IDependencyConfigurator
    {
        void ConfigureService(IContainer container);
    }
}
