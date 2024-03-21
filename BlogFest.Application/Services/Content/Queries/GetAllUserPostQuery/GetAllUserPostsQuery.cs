using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BlogFest.Application.Services.Content.Queries.DTOs;
using BlogFest.Application.Services.Abstract;

namespace BlogFest.Application.Services.Content.Queries.GetAllUserThreadsQuery
{
    public class GetAllUserPostsQuery : IRequest<ExplorePostsDTO>, IApplicationQuery
    {
        public Guid UserId { get; set; }
        public int Offset { get; set; }
    }
}
