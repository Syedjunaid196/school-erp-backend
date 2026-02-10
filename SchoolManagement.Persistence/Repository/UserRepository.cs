using SchoolManagement.Application.Abstractions.Persistence;
using SchoolManagement.Domain.Entities;
using SchoolManagement.Persistence.Data;

namespace SchoolManagement.Persistence.Repository
{
    public class UserRepository(SchoolManagementDbContext context): BaseRepository<User>(context), IUserRepository
    {
    }
}
