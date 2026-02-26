using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using SchoolManagement.Application.Abstractions.Security;
using SchoolManagement.Persistence.Data;
using SchoolManagement.Persistence.Seed;

namespace SchoolManagement.Persistence.Extensions
{
    public static class DatabaseInitializationExtensions
    {
        public static async Task SeedDataBaseAsync(this IServiceProvider serviceProvider)
        {
            using var scope = serviceProvider.CreateScope();
            var context = scope.ServiceProvider.GetRequiredService<SchoolManagementDbContext>();

            var passwordhasher = scope.ServiceProvider.GetRequiredService<IPasswordHasher>();

            var configuration = scope.ServiceProvider.GetRequiredService<IConfiguration>();

            await context.Database.MigrateAsync();

            await DataSeeder.SeedAdminAsync(context,  passwordhasher, configuration);


        }
    }
}
