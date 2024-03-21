using BlogFest.Infrastructure.Persistance.DataModels;

namespace BlogFest.Infrastruction.Persistance.DataModels
{
	public class PostReactionData : BaseDataModel
	{
		public Guid PostId { get; set; }
		public PostDataModel Post { get; set; }
		public UserModel User { get; set; }
		public Guid UserId { get; set; }
		public ReactionTypeId ReactionTypeId { get; set; }
		public ReactionTypeData ReactionType { get; set; }
	}
}
