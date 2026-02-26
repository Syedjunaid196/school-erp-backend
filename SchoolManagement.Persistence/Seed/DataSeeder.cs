using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using SchoolManagement.Application.Abstractions.Security;
using SchoolManagement.Domain.Entities;
using SchoolManagement.Domain.Enums;
using SchoolManagement.Persistence.Data;

namespace SchoolManagement.Persistence.Seed
{
    public static class DataSeeder
    {
        public static async Task SeedAdminAsync(SchoolManagementDbContext context,
            IPasswordHasher passwordHasher, 
            IConfiguration configuration)
        {
            if (await context.Users.AnyAsync(u => u.Role == UserRole.Admin))
            {
                return; // Admin user already exists
            }

            var adminEmail = configuration["seedData:AdminEmail"];
            var adminPassword = configuration["seedData:AdminPassword"];

            var hashpassword = passwordHasher.HashPassword(adminPassword);

            var adminUser = new User(
                "system",
                "admin",
                adminEmail,
                hashpassword,
                Gender.Male,
                UserRole.Admin
                );

            context.Users.Add(adminUser);
            await context.SaveChangesAsync();
        }

      
    }
}
