using Microsoft.AspNetCore.Mvc.Rendering;
using BlogFest.Domain.Content;
using System.ComponentModel.DataAnnotations;
using System.Diagnostics.CodeAnalysis;

namespace BlogFest.Web.ViewModels.Thread
{
    public class EditPostViewModel
    {
        [Required]
        public Guid Id { get; set;}
        public string Title { get; set;}
        public string ContentText{ get; set;}
        public string ContentHTML { get; set;}
        public Guid UserId { get; set; }
        public List<SelectListItem>? Categories { get; set; }
        public List<Guid>? UpdateCategories { get; set; }
        public string? Status { get; set; }
        public string? ImagePath { get; set; }
        public Guid? ImageId { get; set; }
    }
}
