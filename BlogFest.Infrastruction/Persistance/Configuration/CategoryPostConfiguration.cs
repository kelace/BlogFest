using BlogFest.Application;
using BlogFest.Infrastruction.Persistance.DataModels;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlogFest.Infrastruction.Persistance.Configuration
{
    public class CategoryPostConfiguration : IEntityTypeConfiguration<CategoryPostDataModel>
    {
        public void Configure(EntityTypeBuilder<CategoryPostDataModel> builder)
        {

            builder.ToTable(DbConstants.CategoryPostTable);

            builder.Property(x => x.No).HasDefaultValueSql("NEXT VALUE FOR No");
            builder.Property(x => x.DateCreated).HasDefaultValue(DateTime.UtcNow);
            builder.HasOne(x => x.Post).WithMany(x => x.Categories).HasForeignKey(x => x.PostId);
            builder.HasOne(x => x.Category).WithMany(x => x.Posts).HasForeignKey(x => x.CategoryId);
        }
    }
}
