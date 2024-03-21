using BlogFest.Application.Services.Administration.Queries.DTOs;
using MediatR;


namespace BlogFest.Application.Services.Administration.Queries.GetAllUsers
{
    public class GetAllUsersQuery : IRequest<List<AdminUserForEditDTO>>
    {
    }
}
