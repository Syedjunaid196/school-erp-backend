using Microsoft.EntityFrameworkCore;
using SchoolManagement.Application.Abstractions.Persistence;
using SchoolManagement.Application.RR_Models.Subject;
using SchoolManagement.Domain.Entities;
using SchoolManagement.Persistence.Data;

namespace SchoolManagement.Persistence.Repository
{
    public class SubjectRepository(SchoolManagementDbContext context) : BaseRepository<Subject>(context), ISubjectRepository
    {
        public async Task<List<SubjectResponse>> GetAllSubjects()
        {
            return await context.Subjects.Select(s => new SubjectResponse
            {
                Id = s.Id,
                Name = s.Name,
                Code = s.Code
            }).ToListAsync();
        }
    }
}
