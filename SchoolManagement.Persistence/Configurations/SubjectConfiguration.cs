using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using SchoolManagement.Domain.Entities;

namespace SchoolManagement.Persistence.Configurations
{
    public class SubjectConfiguration : BaseEntityConfiguration<Subject>
    {
        public override void Configure(EntityTypeBuilder<Subject> builder)
        {
            base.Configure(builder);

            builder.ToTable("Subjects");

            builder.Property(s => s.Name)
                   .IsRequired()
                   .HasMaxLength(100);

            builder.Property(s => s.Code)
                   .IsRequired()
                   .HasMaxLength(20);

            builder.HasIndex(s => s.Code)
                   .IsUnique();
        }
    }
}
