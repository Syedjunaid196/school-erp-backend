using SchoolManagement.Application.RR_Models.SchoolClass;
using SchoolManagement.Domain.Entities;

namespace SchoolManagement.Application.Abstractions.Persistence
{
    public interface ISchoolClassRepository : IBaseRepository<SchoolClass>
    {
        Task<List<SchoolClassResponse>> GetSchoolClasses();
    }
}
