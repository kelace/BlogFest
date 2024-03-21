using System.ComponentModel.DataAnnotations;

namespace BlogFest.Web.ViewModels.Administration
{
    public class UserViewModel
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        [Display(Name = "Is Active")]
        public bool IsActived { get; set; }
        [Display(Name = "Is Create Thread Allowed")]
        public bool IsCreatePostAllowed { get; set; }
        [Display(Name = "Is Comment Allowed ")]
        public bool IsCommentAllowed { get; set; }
    }
}
