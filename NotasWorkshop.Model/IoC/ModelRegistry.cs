using Microsoft.Extensions.DependencyInjection;
using SicopataSchool.Model.Contexts.SicopataSchool;
using SicopataSchool.Model.UnitOfWorks;
using SicopataSchool.Model.UnitOfWorks.SicopataSchool;

namespace SicopataSchool.Model.IoC
{
    public static class ModelRegistry
    {
        public static void AddModelRegistry(this IServiceCollection services)
        {
            services.AddTransient<ISicopataSchoolDbContext, SicopataSchoolDbContext>();
            services.AddScoped<IUnitOfWork<ISicopataSchoolDbContext>, SicopataSchoolUnitOfWork>();
        }
    }
}
