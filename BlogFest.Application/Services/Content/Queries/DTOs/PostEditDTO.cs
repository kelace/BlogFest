using BlogFest.Domain.Content;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BlogFest.Application.Services.Administration.Queries.DTOs;

namespace BlogFest.Application.Services.Content.Queries.DTOs
{
    public class PostEditDTO
    {
        public Guid Id { get; set; }
        public string Title { get; set; }
        public string ContentText { get; set; }
        public string ContentHTML { get; set; }
        public Guid UserId { get; set; }
        public DateTime DateCreated { get; set; }
        public PostStatus Status { get; set; }
        public List<Guid> UpdateCategories { get; set; }
        public List<CategoryDTO> Categories { get; set; }
        public string ImagePath { get; set; }
    }
}
