using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using SchoolManagement.Persistence.Data;

namespace SchoolManagement.Persistence
{
    public static class AssemblyReferance
    {
        public static IServiceCollection AddPersistenceServices(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddDbContext<SchoolManagementDbContext>(options =>
            {
                options.UseSqlServer(configuration.GetConnectionString(nameof(SchoolManagementDbContext)));
            });
            return services;
        }
    }
}