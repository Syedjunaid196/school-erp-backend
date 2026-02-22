using SchoolManagement.Application.Abstractions.Persistence;
using SchoolManagement.Application.Abstractions.Security;
using SchoolManagement.Domain.Entities;
using SchoolManagement.Domain.Enums;
using SchoolManagement.Persistence.Data;
using System;
using System.Collections.Generic;
using System.Text;

namespace SchoolManagement.Persistence.Seed
{
    public static class DataSeeder
    {
        public static async Task SeedAdminAsync(
            IUserRepository userRepository,
            SchoolManagementDbContext context,
            IPasswordHasher passwordHasher)
        {
            if (await userRepository.IsExists(u => u.Role == UserRole.Admin))
                return;

            var admin = new User(
                "System",
                "Admin",
                "admin@school.com",
                passwordHasher.HashPassword("Admin@123"),
                Gender.Male,
                UserRole.Admin
            );

            context.Users.Add(admin);

            await context.SaveChangesAsync();
        }
    }
}
