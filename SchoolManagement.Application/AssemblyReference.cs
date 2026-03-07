using Microsoft.Extensions.DependencyInjection;
using SchoolManagement.Application.Abstractions.Services;
using SchoolManagement.Application.Services;

namespace SchoolManagement.Application
{
    public static class AssemblyReference
    {
        public static IServiceCollection AddApplicationServices(this IServiceCollection services)
        {
            services.AddScoped<IAuthService, AuthService>();
            services.AddScoped<IStudentService, StudentService>();
            return services;
        }
    }
}
