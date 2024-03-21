using BlogFest.Application.Services.Content.Queries.DTOs;
using BlogFest.Infrastructure.Persistance.DataModels;
using System.ComponentModel.DataAnnotations;

namespace BlogFest.Models.Thread
{
    public class ThreadViewModel
    {
        public PostPageDTO Post { get; set; }
        public CreateCommentViewModel CreateComment { get; set; }

    }
}
