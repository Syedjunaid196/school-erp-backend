using SchoolManagement.Application;
using SchoolManagement.Infrastructure;
using SchoolManagement.Persistence;

namespace SchoolManagement.API
{
    public static class AssemblyReference
    {
        public static IServiceCollection AddApiServices(this IServiceCollection services)
        {
            services.AddApplicationServices()
                    .AddPersistenceServices()
                    .AddInfrastructureServices();
            return services;
        }
    }
}
