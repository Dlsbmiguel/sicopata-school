using Microsoft.Extensions.DependencyInjection;
using System.Reflection;

namespace SicopataSchool.Bl.IoC
{
    public static class BlRegistry
    {
        public static void AddBlRegistry(this IServiceCollection services, Assembly[] assemblies)
        {
            services.AddAutoMapper(assemblies);
        }
    }
}
