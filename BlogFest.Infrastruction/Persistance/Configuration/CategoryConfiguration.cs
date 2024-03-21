using BlogFest.Application;
using BlogFest.Infrastruction.Persistance.DataModels;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace BlogFest.Infrastruction.Persistance.Configuration
{
    public class CategoryConfiguration : IEntityTypeConfiguration<CategoryDataModel>
    {
        public void Configure(EntityTypeBuilder<CategoryDataModel> builder)
        {
            builder.ToTable(DbConstants.CategoryTable);
            builder.Property(x => x.No).HasDefaultValueSql("NEXT VALUE FOR No");
        }
    }
}
