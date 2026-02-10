using Microsoft.EntityFrameworkCore;

namespace SchoolManagement.Persistence.Data
{
    public class SchoolManagementDbContext: DbContext
    {
        public SchoolManagementDbContext(DbContextOptions<SchoolManagementDbContext> options) : base(options)
        {
            
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
        }
    }
}
