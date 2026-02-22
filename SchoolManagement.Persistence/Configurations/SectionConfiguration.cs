using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using SchoolManagement.Domain.Entities;

namespace SchoolManagement.Persistence.Configurations
{
    public class SectionConfiguration : BaseEntityConfiguration<Section>
    {
        public override void Configure(EntityTypeBuilder<Section> builder)
        {
            base.Configure(builder);

            builder.ToTable("Sections");

            builder.Property(s => s.Name)
                   .IsRequired()
                   .HasMaxLength(30);

            builder.HasOne(s => s.SchoolClass)
                   .WithMany()
                   .HasForeignKey(s => s.SchoolClassId)
                   .OnDelete(DeleteBehavior.Cascade);
        }
    }
}
