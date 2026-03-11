using Microsoft.EntityFrameworkCore;
using SchoolManagement.Application.Abstractions.Persistence;
using SchoolManagement.Application.RR_Models.SchoolClass;
using SchoolManagement.Domain.Entities;
using SchoolManagement.Persistence.Data;

namespace SchoolManagement.Persistence.Repository
{
    public class SchoolClassRepository(SchoolManagementDbContext context) : BaseRepository<SchoolClass>(context), ISchoolClassRepository
    {
        public async Task<List<SchoolClassResponse>> GetSchoolClasses()
        {
            return await context.SchoolClasses.Select(sc => new SchoolClassResponse
            {
                Id = sc.Id,
                Name = sc.Name
            }).ToListAsync();
        }
    }
}
