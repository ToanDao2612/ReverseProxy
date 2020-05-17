using ProxyReverse.DependencyInjection;
using ProxyReverse.RabitMqInterface;
using ProxyReverse.Web.Core;
using System;
using System.Collections.Generic;
using System.Text;

namespace ProxyReverse.Web.DependencyInjection
{
    public class WebApplicationContext : AbstractApplicationContext
    {
        public WebApplicationContext()
        {
            this.UseContext()
                .ConfigureServices<WebDependencyConfigurator>()
                .ConfigureServices<RabitMqDependencyies>();
        }
    }
}
