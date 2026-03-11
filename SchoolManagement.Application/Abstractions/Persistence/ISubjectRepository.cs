using SchoolManagement.Application.RR_Models.Subject;
using SchoolManagement.Domain.Entities;

namespace SchoolManagement.Application.Abstractions.Persistence
{
    public interface ISubjectRepository : IBaseRepository<Subject>
    {
        Task<List<SubjectResponse>> GetAllSubjects();
    }
}
