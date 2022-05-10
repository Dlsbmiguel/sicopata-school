using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using SicopataSchool.Services.Services;
using SicopataSchool.Services.Services;

namespace SicopataSchool.Services.IoC
{
    public static class ServiceRegistry
    {
        public static void AddServicesRegistry(this IServiceCollection services)
        {
            services.AddScoped<INoteService, NoteService>();
            services.AddScoped<IStudentService, StudentService>();
            services.AddScoped<IJWTManagerService, JWTManagerService>();
        }
    }
}
