using SchoolManagement.Application.RR_Models.Section;
using SchoolManagement.Domain.Entities;

namespace SchoolManagement.Application.Abstractions.Persistence
{
    public interface ISectionRepository : IBaseRepository<Section>
    {
        Task<List<SectionResponse>> GetSections();
    }
}
