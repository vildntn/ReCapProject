using Core.Utilities.IoC;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Text;

namespace Core.Extensions
{

    public static class ServiceCollectionExtentions
    {   //birden fazla modulü eklemek için
        //yani birden fazla module'ü bir array'de toplayarak onları yüklemek için(exp:coreModule, aspectModule,..)
        public static IServiceCollection AddDependencyResolvers(this IServiceCollection serviceCollection, ICoreModule[] modules)
        {
            foreach (var module in modules)
            {
                module.Load(serviceCollection);  
            }
            return ServiceTool.Create(serviceCollection);  //Projemize Ekleyeceğimiz bütün injectionları bir arada toplayabileceğimiz bir yapıya dönüştürdük.
        }
    }
}
