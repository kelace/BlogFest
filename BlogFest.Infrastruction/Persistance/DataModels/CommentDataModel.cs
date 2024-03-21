namespace BlogFest.Infrastructure.Persistance.DataModels
{
    public class CommentDataModel : BaseDataModel
    {
        public string Content { get; set; }
        public Guid PostId { get; set; }
        public Guid UserId { get; set; }
        public UserModel User { get; set; }
        public PostDataModel PostModel { get; set; }
    }
}
