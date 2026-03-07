using SchoolManagement.Application.RR_Models.Teacher;
using SchoolManagement.Application.Utils;
using SchoolManagement.Domain.Entities;

namespace SchoolManagement.Application.Abstractions.Persistence
{
    public interface ITeacherRepository : IBaseRepository<Teacher>
    {
        public Task<List<TeacherListResponse>> GetTeacherList();
    }
}
