using SchoolManagement.Application.RR_Models.Section;
using SchoolManagement.Application.Utils;

namespace SchoolManagement.Application.Abstractions.Services
{
    public interface ISectionService
    {
        Task<Result<SectionResponse>> CreateSection(SectionRequest request);

        Task<Result<List<SectionResponse>>> GetSections();
    }
}
