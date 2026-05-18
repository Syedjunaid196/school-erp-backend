using SchoolManagement.Application.RR_Models.Student;
using SchoolManagement.Application.Utils;

namespace SchoolManagement.Application.Abstractions.Services
{
    public interface IStudentService
    {
        Task<Result<StudentResponse>> CreateStudent(StudentRequest model);

        Task<Result<List<StudentListResponse>>> GetAllStudents();

        Task<Result<StudentResponse>> DeleteStudentByIdAsync(Guid id);


    }
}
