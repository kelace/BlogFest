using System.ComponentModel.DataAnnotations;

namespace BlogFest.Models.Thread
{
    public class CreateCommentViewModel
    {
        [Required]
        public string CommentContent { get; set; }
        [Required]
        public Guid PostId { get; set; }
    }
}
