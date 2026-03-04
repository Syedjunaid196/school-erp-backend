using SchoolManagement.Application.RR_Models.Student;
using SchoolManagement.Domain.Entities;

namespace SchoolManagement.Application.Abstractions.Persistence
{
    public interface IStudentRepository: IBaseRepository<Student>
    {
        Task<List<StudentListResponse>> GetStudentListAsync();
    }
}
