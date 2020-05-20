using Base.Core.Services;
using DependencyInjection;
using System;
using System.Collections.Generic;
using System.Text;

namespace Json.NewtonSoft.ThirdParty
{
    public class JsonDependencyies : IDependencyConfigurator
    {
        public void ConfigureService(IContainer container)
        {
            container.RegisterType<IJsonConvertor, JsonConvertor>();
        }
    }
}
