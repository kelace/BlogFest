using BlogFest.Application.Services.Administration.Queries.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlogFest.Application.Services.Content.Queries.DTOs
{
    public class ExplorePostsDTO
    {
        public List<PostDTO> Posts { get; set; }
        public int Count { get; set; }
        public int PageIndex { get; set; }
    }
}
