using Microsoft.EntityFrameworkCore.Storage;
using SchoolManagement.Application.Abstractions.IunitOfWork;
using SchoolManagement.Persistence.Data;
using System;
using System.Collections.Generic;
using System.Data;
using System.Runtime.InteropServices;
using System.Text;

namespace SchoolManagement.Persistence.Repository
{
    public class UnitOfWork(SchoolManagementDbContext context) : IUnitOfWork
    {
        public IDbTransaction BeginTrancaction()
        {
           return  context.Database.BeginTransaction().GetDbTransaction();
        }

        public async Task<int> SaveChangesAsync(CancellationToken cancellationToken = default)
        {
            return await context.SaveChangesAsync(cancellationToken);
        }
    }
}
