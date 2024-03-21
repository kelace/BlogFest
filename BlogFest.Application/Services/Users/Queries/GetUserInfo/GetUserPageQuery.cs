using BlogFest.Application.Abstract;
using MediatR;
using BlogFest.Application.Services.Users.DTOs;

namespace BlogFest.Application.Users.Queries.GetUserInfo
{
    public class GetUserPageQuery : IRequest<UserPageDTO>
    {
        public Guid Id { get; set; }
        public Guid CurrentUserId { get; set; }
        public string UserName { get; set; }
        public int Page { get; set; }
        public string Key => $"user-page-{Id}";
    }
}
