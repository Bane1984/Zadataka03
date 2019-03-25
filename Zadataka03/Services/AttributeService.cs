using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Threading.Tasks;
using Microsoft.Extensions.DependencyInjection;
using Zadataka03.Atributi;

namespace Zadataka03.Services
{
    public static class AttributeService
    {
        public static void AddDIService(this IServiceCollection services)
        {
            Assembly assembly = Assembly.GetExecutingAssembly();
            var types = assembly.GetTypes().Where(c => c.GetCustomAttributes<Univerzalni>().Any());

            foreach (var type in types)
            {
                var getEnum = type.GetCustomAttribute<Univerzalni>().Name;
                Type t = type;
                Type[] getInterfaces = t.GetInterfaces();
                foreach (var inf in getInterfaces)
                {
                    if (inf.IsGenericTypeDefinition && type.IsGenericTypeDefinition)
                    {
                        switch (getEnum)
                        {
                            case DIEnum.Scoped:
                                services.AddScoped(inf, t);
                                break;
                            case DIEnum.Singleton:
                                services.AddSingleton(inf, type);
                                break;
                            default:
                                services.AddTransient(inf, type);
                                break;
                        }
                    }
                    else
                    {
                        switch (getEnum)
                        {
                            case DIEnum.Scoped:
                                services.AddScoped(inf, t);
                                break;
                            case DIEnum.Singleton:
                                services.AddSingleton(inf, type);
                                break;
                            default:
                                services.AddTransient(inf, type);
                                break;
                        }
                    }
                }

            }
        }
    }
}
