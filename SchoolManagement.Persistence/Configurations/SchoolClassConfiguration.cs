using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using SchoolManagement.Domain.Entities;

namespace SchoolManagement.Persistence.Configurations
{
    public class SchoolClassConfiguration : BaseEntityConfiguration<SchoolClass>
    {
        public override void Configure(EntityTypeBuilder<SchoolClass> builder)
        {
            base.Configure(builder);

            builder.ToTable("SchoolClasses");

            builder.Property(c => c.Name)
                   .IsRequired()
                   .HasMaxLength(50);

            builder.HasIndex(c => c.Name)
                   .IsUnique();
        }
    }
}
