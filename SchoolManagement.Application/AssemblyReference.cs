using Microsoft.Extensions.DependencyInjection;
using SchoolManagement.Application.Abstractions.Persistence;
using SchoolManagement.Application.Abstractions.Services;
using SchoolManagement.Application.Services;

namespace SchoolManagement.Application
{
    public static class AssemblyReference
    {
        public static IServiceCollection AddApplicationServices(this IServiceCollection services)
        {
            services.AddScoped<IAuthService, AuthService>();
            services.AddScoped<IStudentService, StudentService>();
            services.AddScoped<ITeacherService, TeacherService>();
            services.AddScoped<IParentService, ParentService>();
            services.AddScoped<IAcademicYearService, AcademicYearService>();
            services.AddScoped<ISchoolClassService, SchoolClassService>();
            services.AddScoped<ISectionService, SectionService>();
            services.AddScoped<IStudentEnrollmentService, StudentEnrollmentService>();
            return services;
        }
    }
}
