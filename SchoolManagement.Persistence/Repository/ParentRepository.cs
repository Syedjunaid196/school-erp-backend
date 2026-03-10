using Microsoft.EntityFrameworkCore;
using SchoolManagement.Application.Abstractions.Persistence;
using SchoolManagement.Application.RR_Models.Parent;
using SchoolManagement.Domain.Entities;
using SchoolManagement.Persistence.Data;

namespace SchoolManagement.Persistence.Repository
{
    public class ParentRepository(SchoolManagementDbContext context) : BaseRepository<Parent>(context), IParentRepository
    {
        public async Task<List<ParentListResponse>> GetParentList()
        {
            return await context.Parents.Select(p => new ParentListResponse
            {
                Id = p.Id,
                FirstName = p.User.FirstName,
                LastName = p.User.LastName,
                Gender = p.User.Gender,
                Email = p.User.Email,
                Occupation = p.Occupation,
                Address = p.Address
            }).ToListAsync();
        }
    }
}
