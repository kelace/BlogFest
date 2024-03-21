using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlogFest.Application.Services.Content.Queries.DTOs
{
    public class PostCommentsDTO
    {
        public List<CommentDto> Comments { get; set; }
        public int TotalAmount { get; set; }
        public int Offset { get; set; }
    }
}
