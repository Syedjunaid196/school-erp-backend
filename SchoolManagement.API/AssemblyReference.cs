using SchoolManagement.Application;
using SchoolManagement.Infrastructure;
using SchoolManagement.Persistence;

namespace SchoolManagement.API
{
    public static class AssemblyReference
    {
        public static IServiceCollection AddApiServices(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddApplicationServices()
                    .AddPersistenceServices(configuration)
                    .AddInfrastructureServices();
            return services;
        }
    }
}
