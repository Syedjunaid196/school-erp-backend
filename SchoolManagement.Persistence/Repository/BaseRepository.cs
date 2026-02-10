using SchoolManagement.Application.Abstractions.Persistence;
using SchoolManagement.Domain.common;
using SchoolManagement.Persistence.Data;

namespace SchoolManagement.Persistence.Repository
{
    public class BaseRepository<T>(SchoolManagementDbContext context) : IBaseRepository<T> where T : BaseEntity, new()
    {
        public async Task AddAsync(T Model)
        {
            await context.AddAsync(Model);
        }

        public Task DeleteAsync(T Model)
        {
            throw new NotImplementedException();
        }

        public Task<IEnumerable<T>> GetAllAsync()
        {
            throw new NotImplementedException();
        }

        public Task UpdateAsync(T Model)
        {
            throw new NotImplementedException();
        }
    }
}
