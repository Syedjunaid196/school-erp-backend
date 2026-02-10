using SchoolManagement.Domain.common;
using System;
using System.Collections.Generic;
using System.Text;

namespace SchoolManagement.Application.Abstractions.Persistence
{
    public interface IBaseRepository<T> where T : BaseEntity
    {
        Task AddAsync(T Model);

        Task UpdateAsync(T Model);

        Task DeleteAsync(T Model);

        Task<IEnumerable<T>> GetAllAsync();
    }
}
