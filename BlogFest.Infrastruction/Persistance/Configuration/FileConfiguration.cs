using BlogFest.Application;
using BlogFest.Infrastruction.Persistance.DataModels;
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
    public class FileConfiguration : IEntityTypeConfiguration<FileDataModel>
    {
        public void Configure(EntityTypeBuilder<FileDataModel> builder)
        {
            builder.ToTable(DbConstants.FileTable);
            builder
              .HasOne(x => x.User)
              .WithMany(x => x.Files)
              .HasForeignKey(x => x.UserId)
              .OnDelete(DeleteBehavior.Cascade);

            builder.Property(x => x.DateCreated).HasDefaultValue(DateTime.UtcNow);
            builder.Property(x => x.No).HasDefaultValueSql("NEXT VALUE FOR NO");


            builder.Property(x => x.UserId).IsRequired(false);

            builder.HasOne(x => x.PostFile).WithOne(x => x.File).HasForeignKey<PostFileData>(x => x.FileId).OnDelete(DeleteBehavior.Restrict);
        }
    }
}
