using BlogFest.Domain.Content;
using BlogFest.Infrastruction.Persistance.DataModels;

namespace BlogFest.Infrastructure.Persistance.DataModels
{
    public class PostDataModel : BaseDataModel
    {
        public string Slug { get; set; }
        public string Title { get; set; }
        public string ContentText { get; set; }
        public string ContentHTML { get; set; }
        public Guid UserId {get; set;}
        public List<PostFileData> Files { get; set; }   
        public PostStatus PostStatus { get; set; }
        public UserModel User { get; set; }
        public List<CommentDataModel> Comments { get; set; }
        public List<CategoryPostDataModel> Categories { get; set; }
        public List<PostReactionData> Reactions { get; set; }
        public string TitleSlugify { get; set; }
    }
}
