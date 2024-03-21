using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;
using BlogFest.Infrastruction.Persistance.DataModels;

namespace BlogFest.Infrastruction.Persistance.Configuration
{
	public class NotificationConfiguration : IEntityTypeConfiguration<NotificationDataModel>
	{
		public void Configure(EntityTypeBuilder<NotificationDataModel> builder)
		{
			builder.Property(x => x.No).HasDefaultValueSql("NEXT VALUE FOR No");
			builder.Property(x => x.DateCreated).HasDefaultValue(DateTime.UtcNow) ;
		}
	}
}
