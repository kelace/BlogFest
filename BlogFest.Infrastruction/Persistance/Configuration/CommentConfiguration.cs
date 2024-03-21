using BlogFest.Application;
using BlogFest.Infrastructure.Persistance.DataModels;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlogFest.Infrastruction.Persistance.Configuration
{
    public class CommentConfiguration : IEntityTypeConfiguration<CommentDataModel>
    {
        public void Configure(EntityTypeBuilder<CommentDataModel> builder)
        {
            builder.ToTable(DbConstants.CommentTable);
            builder.Property(x => x.No).HasDefaultValueSql("NEXT VALUE FOR No");
            builder.Property(x => x.DateCreated).HasDefaultValue(DateTime.UtcNow);
            builder
                .HasOne(x => x.User)
                .WithMany(x => x.Comments)
                .HasForeignKey(x => x.UserId)
                .OnDelete(DeleteBehavior.Restrict);
        }
    }
}
