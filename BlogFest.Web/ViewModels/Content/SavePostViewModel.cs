using System.ComponentModel.DataAnnotations;

namespace BlogFest.Web.ViewModels.Content
{
    public class SavePostViewModel
    {
        [Required]
        public string Title { get; set; }
        [Required]
        public string ContentText { get; set; }
        [Required]
        public string ContentHTML{ get; set; }
        public Guid ImageId { get; set; }
        public List<Guid> Categories { get; set; }
        public Guid PostId { get; set; }
    }
}
