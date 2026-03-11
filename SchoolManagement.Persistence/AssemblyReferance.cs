using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using SchoolManagement.Application.Abstractions.IunitOfWork;
using SchoolManagement.Application.Abstractions.Persistence;
using SchoolManagement.Persistence.Data;
using SchoolManagement.Persistence.Repository;

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
            services.AddScoped<IUnitOfWork, UnitOfWork>();
            services.AddScoped<IAuthRepository, AuthRepository>();
            services.AddScoped<ITeacherRepository, TeacherRepository>();
            services.AddScoped<IStudentRepository, StudentRepository>();
            services.AddScoped<IParentRepository, ParentRepository>();
            services.AddScoped<IAcademicYearRepository, AcademicYearRepository>();
            services.AddScoped<ISchoolClassRepository, SchoolClassRepository>();
            services.AddScoped<ISectionRepository, SectionRepository>();
            services.AddScoped<IStudentEnrollmentRepository, StudentEnrollmentRepository>();
            return services;
        }
    }
}