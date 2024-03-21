using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlogFest.Application.Services.Administration.Queries.DTOs
{
    public class CategoryDTO
    {
        public Guid Id { get; set; }
        public string Title { get; set; }
        public string EncodedTitle { get; set; }
        public bool Enabled { get; set; }
        public int PostsCount { get; set; }
        public Guid PostId { get; set; }
        public bool Selected { get; set; }
    }
}
