using SchoolManagement.Application.Abstractions.Persistence;
using SchoolManagement.Domain.Entities;
using SchoolManagement.Persistence.Data;

namespace SchoolManagement.Persistence.Repository
{
    public class ParentRepository(SchoolManagementDbContext context) : BaseRepository<Parent>(context), IParentRepository
    {
    }
}
