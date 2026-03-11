using SchoolManagement.Application.RR_Models.AcademicYear;
using SchoolManagement.Domain.Entities;

namespace SchoolManagement.Application.Abstractions.Persistence
{
    public interface IAcademicYearRepository: IBaseRepository<AcademicYear>
    {
        Task<List<AcademicYearResponse>> GetAcademicYears();
    }
}
