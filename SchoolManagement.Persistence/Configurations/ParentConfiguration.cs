using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using SchoolManagement.Domain.Entities;

namespace SchoolManagement.Persistence.Configurations
{
    public class ParentConfiguration
     : BaseEntityConfiguration<Parent>
    {
        public override void Configure(EntityTypeBuilder<Parent> builder)
        {
            base.Configure(builder);

            builder.ToTable("Parents");

            builder.Property(p => p.Occupation)
                   .IsRequired()
                   .HasMaxLength(100);

            builder.Property(p => p.Address)
                   .IsRequired()
                   .HasMaxLength(250);

            builder.HasOne(p => p.User)
                   .WithOne()
                   .HasForeignKey<Parent>(p => p.UserId)
                   .OnDelete(DeleteBehavior.Cascade);
        }
    }
}
