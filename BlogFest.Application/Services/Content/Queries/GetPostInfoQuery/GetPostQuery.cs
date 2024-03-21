using BlogFest.Application.Services.Abstract;
using BlogFest.Application.Services.Content.Queries.DTOs;
using MediatR;

namespace BlogFest.Application.Services.Content.Queries.GetThreadInfoQuery
{
    public class GetPostQuery : IRequest<PostPageDTO>, IApplicationQuery
    {
        public Guid PostId{ get; set; }
    }
}
