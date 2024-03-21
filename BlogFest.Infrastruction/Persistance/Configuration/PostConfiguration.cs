using BlogFest.Application;
using BlogFest.Domain.Base;
using BlogFest.Domain.Content;
using BlogFest.Infrastructure.Persistance.DataModels;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace BlogFest.Infrastruction.Persistance.Configuration
{
    public class PostConfiguration : IEntityTypeConfiguration<PostDataModel>
    {
        public void Configure(EntityTypeBuilder<PostDataModel> builder)
        {
            builder.ToTable(DbConstants.PostTable);
            builder.Property(x => x.No).HasDefaultValueSql("NEXT VALUE FOR No");
            builder.Property(x => x.PostStatus).HasConversion(v => v.ToString(), v => Enumeration.GetAll<PostStatus>().Where(x => x.Name == v).Select(x => x).FirstOrDefault());
            builder.HasMany(x => x.Files).WithOne(x => x.Post).HasForeignKey(x => x.PostId).OnDelete(DeleteBehavior.Restrict);
            builder.Property(x => x.DateCreated).HasDefaultValue(DateTime.UtcNow);
            builder.HasMany(x => x.Reactions).WithOne(x => x.Post).HasForeignKey(x => x.PostId).OnDelete(DeleteBehavior.Restrict);
            builder.HasIndex(x => x.Slug).IsUnique();
            builder.HasMany(x => x.Comments).WithOne(x => x.PostModel).HasForeignKey(x => x.PostId).OnDelete(DeleteBehavior.Restrict);
        }
    }
}
