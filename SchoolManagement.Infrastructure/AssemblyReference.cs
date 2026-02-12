using Microsoft.Extensions.DependencyInjection;
using SchoolManagement.Application.Abstractions.Security;
using SchoolManagement.Infrastructure.Security;

namespace SchoolManagement.Infrastructure
{
    public static class AssemblyReference
    {
        public static IServiceCollection AddInfrastructureServices(this IServiceCollection services)
        {
            services.AddScoped<IPasswordHasher, BCryptPasswordHasher>();
            return services;
        }
    }
}
