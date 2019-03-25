using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.DependencyInjection;
using Zadataka03.Atributi;
using Zadataka03.Filters;

namespace Zadataka03.Services
{
    public static class FilterService
    {
        public static void AddFiltersService(this IServiceCollection services)
        {
            Assembly filterAssembly = Assembly.GetExecutingAssembly();
            var types = filterAssembly.GetTypes().Where(x => x.GetCustomAttributes<RegistracijaFiltera>().Any());
            services.AddMvc(option =>
            {
                foreach (var type in types)
                {
                    option.Filters.Add(type);
                }
            }).SetCompatibilityVersion(CompatibilityVersion.Version_2_2);
        }
    }
}
