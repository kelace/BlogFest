using BlogFest.Application;
using BlogFest.Infrastruction.Persistance.DataModels;
using BlogFest.Infrastructure.Persistance.DataModels;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;


namespace BlogFest.Infrastruction.Persistance.Configuration
{
    public class UserModelConfiguration : IEntityTypeConfiguration<UserModel>
    {
        public void Configure(EntityTypeBuilder<UserModel> builder)
        {
            builder.ToTable(DbConstants.UserTable);
            builder.Property(x => x.Active)
                .HasDefaultValue(true);

            builder.Property(x => x.IsCreatePostAllowed)
               .HasDefaultValue(true);

            builder.Property(x => x.IsCommentAllowed)
                .HasDefaultValue(true);

            builder
                .HasMany(u => u.Posts)
                .WithOne(t => t.User)
                .HasForeignKey(t => t.UserId)
                .HasPrincipalKey(x => x.Id).OnDelete(DeleteBehavior.Restrict);

            builder.Property(x => x.Id).HasDefaultValue(Guid.NewGuid());

            builder.HasMany<UserFileData>().WithOne().HasForeignKey(x => x.UserId).OnDelete(DeleteBehavior.Restrict);
            
            builder.HasMany(x => x.Reactions).WithOne(x => x.User).HasForeignKey(x => x.UserId).OnDelete(DeleteBehavior.Restrict);
            builder.HasMany(x => x.Notifications).WithOne().HasForeignKey(x => x.UserId).OnDelete(DeleteBehavior.Restrict);
            builder.Property(x => x.DateCreated).HasDefaultValue(DateTime.UtcNow);
            builder.Property(x => x.No).HasDefaultValueSql("NEXT VALUE FOR NO");
        }
    }
}
