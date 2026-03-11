using SchoolManagement.Application.RR_Models.StudentEnrollment;
using SchoolManagement.Domain.Entities;

namespace SchoolManagement.Application.Abstractions.Persistence
{
    public interface IStudentEnrollmentRepository : IBaseRepository<StudentEnrollment>
    {
        Task<List<StudentEnrollmentResponse>> GetEnrollments();
    }
}
