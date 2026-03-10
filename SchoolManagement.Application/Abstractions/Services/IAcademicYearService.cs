using SchoolManagement.Application.RR_Models.AcademicYear;
using SchoolManagement.Application.Utils;

namespace SchoolManagement.Application.Abstractions.Services
{
    public interface IAcademicYearService
    {
        Task<Result<AcademicYearResponse>> CreateAcademicYear(AcademicYearRequest model);

        Task<Result<List<AcademicYearResponse>>> GetAcademicYears();
    }
}
