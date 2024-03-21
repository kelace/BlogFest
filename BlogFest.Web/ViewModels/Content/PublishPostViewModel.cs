using Microsoft.AspNetCore.Mvc.Rendering;
using BlogFest.Domain.Base;
using System.ComponentModel.DataAnnotations;

namespace BlogFest.Models.Thread
{
    public class PublishPostViewModel
    {
        public Guid PostId { get; set; }
    }
}
