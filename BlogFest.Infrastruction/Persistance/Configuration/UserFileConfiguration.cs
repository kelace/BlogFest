using BlogFest.Application;
using BlogFest.Infrastruction.Persistance.DataModels;
using BlogFest.Infrastructure.Persistance.DataModels;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace BlogFest.Infrastruction.Persistance.Configuration
{
    public class UserFileConfiguration : IEntityTypeConfiguration<UserFileData>
    {
        public void Configure(EntityTypeBuilder<UserFileData> builder)
        {
            builder.ToTable(DbConstants.UserFileTable);
            builder.HasOne<FileDataModel>().WithOne().HasForeignKey<UserFileData>(x => x.FileId).OnDelete(DeleteBehavior.Restrict);
            builder.Property(x => x.Id).HasDefaultValue(Guid.NewGuid());
            builder.Property(x => x.DateCreated).HasDefaultValue(DateTime.UtcNow);
            builder.Property(x => x.No).HasDefaultValueSql("NEXT VALUE FOR NO");
            builder.HasIndex(x => x.UserId).IsUnique(false);

        }
    }
}
