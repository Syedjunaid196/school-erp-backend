using SchoolManagement.Application.RR_Models.StudentEnrollment;
using SchoolManagement.Application.Utils;

namespace SchoolManagement.Application.Abstractions.Services
{
    public interface IStudentEnrollmentService
    {
        Task<Result<StudentEnrollmentResponse>> EnrollStudent(StudentEnrollmentRequest model);
        Task<Result<List<StudentEnrollmentResponse>>> GetEnrollments();
    }
}
