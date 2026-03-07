using SchoolManagement.Application.RR_Models.Teacher;
using SchoolManagement.Application.Utils;

namespace SchoolManagement.Application.Abstractions.Services
{
    public interface ITeacherService
    {
        Task<Result<TeacherResponse>> CreateTeacher(TeacherRequest model);

        Task<Result<List<TeacherListResponse>>> GetTeachersList();
    }
}
