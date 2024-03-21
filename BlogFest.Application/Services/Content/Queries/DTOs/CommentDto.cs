using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlogFest.Application.Services.Content.Queries.DTOs
{
    public class CommentDto
    {
        public Guid Id { get; set; }
        public string Content { get; set; }
        public Guid? CommentParentId { get; set; }
        public Guid PostId { get; set; }
        public Guid UserId { get; set; }
        public string UserName { get; set; }
        public DateTime DateCreated { get; set; }
        public Guid ImageId { get; set; }
        public string Path { get; set; }
    }
}
