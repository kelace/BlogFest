using MediatR;
using BlogFest.Application.Services.Content.Queries.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BlogFest.Application.Services.Abstract;

namespace BlogFest.Application.Services.Content.Queries.GetPostCommentsQuery
{
    public class GetPostCommentsQuery : IRequest<PostCommentsDTO>, IApplicationQuery
    {
        public Guid PostId { get; set; }
        public int Offset { get; set; }
        public int Count { get; set; }
    }
}
