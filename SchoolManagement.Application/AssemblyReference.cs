using Microsoft.Extensions.DependencyInjection;

namespace SchoolManagement.Application
{
    public static class AssemblyReference
    {
        public static IServiceCollection AddApplicationServices(this IServiceCollection services)
        {
            return services;
        }
    }
}
