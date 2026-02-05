using Microsoft.Extensions.DependencyInjection;

namespace SchoolManagement.Persistence
{
    public static class AssemblyReferance
    {
        public static IServiceCollection AddPersistenceServices(this IServiceCollection services)
        {
            return services;
        }
    }
}
