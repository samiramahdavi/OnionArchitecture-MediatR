using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using OnionArchitecture.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OnionArchitecture.Repository.EntitiesConfig
{
    public class CommentConfig : IEntityTypeConfiguration<Comment>
    {
        public void Configure(EntityTypeBuilder<Comment> builder)
        {
            builder.HasKey(c => c.Id);
            //builder.Property(c => c.Id).ValueGeneratedOnAddOrUpdate();
            builder.Property(c=>c.Name).IsRequired().HasColumnType("nvarchar").HasMaxLength(100);
            builder.Property(c => c.Family).IsRequired().HasColumnType("nvarchar").HasMaxLength(100);
            builder.Property(c => c.EmailAddress).IsRequired().HasColumnType("nvarchar").HasMaxLength(100);
            builder.Property(c => c.Message).IsRequired().HasColumnType("nvarchar").HasMaxLength(1000);
        }
    }
}
