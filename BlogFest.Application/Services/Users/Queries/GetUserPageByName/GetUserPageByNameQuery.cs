using BlogFest.Application.Abstract;
using BlogFest.Application.Users.Queries.GetUserInfo;
using MediatR;
using BlogFest.Application.Services.Users.DTOs;

namespace BlogFest.Application.Services.Users.Queries.GetUserPageByName
{
    public class GetUserPageByNameQuery : IRequest<UserPageDTO>
    {
        public string Name { get; set; }
        public int Page { get; set; }
        public Guid CurrentUserId { get; set; }
    }
}
