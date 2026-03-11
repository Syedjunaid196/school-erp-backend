using Microsoft.EntityFrameworkCore;
using SchoolManagement.Application.Abstractions.Persistence;
using SchoolManagement.Application.RR_Models.Section;
using SchoolManagement.Domain.Entities;
using SchoolManagement.Persistence.Data;

namespace SchoolManagement.Persistence.Repository
{
    public class SectionRepository(SchoolManagementDbContext context) : BaseRepository<Section>(context), ISectionRepository
    {
        public async Task<List<SectionResponse>> GetSections()
        {
            return await context.Sections
                 .AsNoTracking()
                 .Select(s => new SectionResponse
                 {
                     Id = s.Id,
                     Name = s.Name,
                     SchoolClassId = s.SchoolClassId,
                     SchoolClassName = s.SchoolClass.Name
                 })
                 .ToListAsync();
        }
    }
}
