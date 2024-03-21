using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlogFest.Application.Services.Content.Queries.DTOs
{
    public class ReactionDTO
    {
        public int LikesCount { get; set; }
        public int DislikesCount { get; set; }
        public string Type { get; set; }
    }
}
