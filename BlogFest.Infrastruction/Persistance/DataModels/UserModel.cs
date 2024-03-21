using BlogFest.Infrastruction.Persistance.DataModels;

namespace BlogFest.Infrastructure.Persistance.DataModels
{
    public class UserModel : BaseDataModel
    {
        public  Guid UserAuthId { get; set; }
        public string Name { get; set; }
        public string? FirstName { get; set; }
        public string? LastName { get; set; }
        public bool Active { get; set; }
        public bool IsCommentAllowed { get; set; }
        public bool IsCreatePostAllowed { get; set; }
        public List<PostDataModel> Posts { get; set; }
        public List<CommentDataModel> Comments { get; set; }
        public List<FileDataModel> Files { get; set; }
        public List<PostReactionData> Reactions { get; set; }
        public string? Bio { get; set; }
        public List<NotificationDataModel> Notifications { get; set; }
    }
}
