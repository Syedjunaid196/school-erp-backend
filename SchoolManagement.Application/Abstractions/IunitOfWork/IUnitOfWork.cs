using System.Data;

namespace SchoolManagement.Application.Abstractions.IunitOfWork
{
    public interface IUnitOfWork
    {
        IDbTransaction BeginTrancaction();

        Task<int> SaveChangesAsync(CancellationToken cancellationToken = default);
    }
}
