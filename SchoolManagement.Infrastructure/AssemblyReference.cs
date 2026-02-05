using Microsoft.Extensions.DependencyInjection;

namespace SchoolManagement.Infrastructure
{
    public static class AssemblyReference
    {
        public static IServiceCollection AddInfrastructureServices(this IServiceCollection services)
        {
            return services;
        }
    }
}
