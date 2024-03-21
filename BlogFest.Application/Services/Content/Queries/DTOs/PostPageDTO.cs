using BlogFest.Application.Services.Administration.Queries.DTOs;
using BlogFest.Application.Services.Users.DTOs;

namespace BlogFest.Application.Services.Content.Queries.DTOs
{
    public class PostPageDTO
    {
        public Guid Id { get; set; }
        public Guid PostId { get; set; }
        public string ImagePath { get; set; }
        public string Slug { get; set; }
        public string Title { get; set; }
        public string Content { get; set; }
        public Guid UserId { get; set; }
        public string UserName { get; set; }
        public UserDTO User { get; set; }
        public Guid CreatedById { get; set; }
        public string CreatedByName { get; set; }
        public List<CommentDto> Comments { get; set; }
        public Guid? ImageId { get; set; }
        public Guid? ImgId { get; set; }
        public List<CategoryDTO> Categories { get; set; } = new List<CategoryDTO>();
        public int LikesCount { get; set; }
        public int DislikeCount { get; set; }
        public string CurrentUserReactionType { get; set; }
        public int CommentsCommonAmount { get; set; }
        public int CommentsCurrent { get; set; }
        public int Offset { get; set; } = 3;
    }
}
