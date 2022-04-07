using Microsoft.EntityFrameworkCore;
using OnionArchitecture.Domain.Identity;

namespace OnionArchitecture.Repository.EntitiesConfig
{
    public class ApplicationUserConfig :  IEntityTypeConfiguration<ApplicationUser>
    {
        public void Configure(Microsoft.EntityFrameworkCore.Metadata.Builders.EntityTypeBuilder<ApplicationUser> builder)
        {
            builder.HasKey(p => p.Id);
            builder.Property(p => p.Id).IsRequired().ValueGeneratedOnAdd();
            builder.Property(p => p.FirstName).IsRequired().HasColumnType("nvarchar").HasMaxLength(100);
            builder.Property(p => p.LastName).IsRequired().HasColumnType("nvarchar").HasMaxLength(100);
            builder.Property(p => p.PhoneNumber).HasColumnType("varchar").HasMaxLength(11);
            builder.Property(p => p.Email).IsRequired().IsUnicode().HasColumnType("nvarchar").HasMaxLength(200);
        }
    }

}
