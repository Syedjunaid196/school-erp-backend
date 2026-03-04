using Microsoft.EntityFrameworkCore;
using SchoolManagement.Application.Abstractions.Persistence;
using SchoolManagement.Domain.common;
using SchoolManagement.Persistence.Data;
using System.Linq.Expressions;

namespace SchoolManagement.Persistence.Repository
{
    public class BaseRepository<T>(SchoolManagementDbContext context) : IBaseRepository<T> where T : BaseEntity
    {
        public async Task AddAsync(T Model)
        {
            await context.AddAsync(Model);
        }

        public Task DeleteAsync(T Model)
        {
            throw new NotImplementedException();
        }

        public async Task<T> FirstOrDefaultAsync(Expression<Func<T, bool>> expression)
        {
            return await context.Set<T>().FirstOrDefaultAsync(expression);
        }

        public async Task<IEnumerable<T>> GetAllAsync()
        {
            return await context.Set<T>().AsNoTracking().ToListAsync();
        }

        public async Task<T?> GetByIdAsync(Guid id)
        {
            return await context.Set<T>().AsNoTracking().FirstAsync(e => e.Id == id);
        }

        public async Task<bool> IsExists(Expression<Func<T, bool>> expression)
        {
            return await context.Set<T>().AnyAsync(expression);
        }

        public Task UpdateAsync(T Model)
        {
            throw new NotImplementedException();
        }
    }
}
