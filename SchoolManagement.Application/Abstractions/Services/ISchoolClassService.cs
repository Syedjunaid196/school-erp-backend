using SchoolManagement.Application.RR_Models.SchoolClass;
using SchoolManagement.Application.Utils;

namespace SchoolManagement.Application.Abstractions.Services
{
    public interface ISchoolClassService
    {
        Task<Result<SchoolClassResponse>> CreateSchoolClass(SchoolClassRequest model);

        Task<Result<List<SchoolClassResponse>>> GetSchoolClasses();
    }
}
