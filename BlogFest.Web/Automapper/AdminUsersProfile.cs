using AutoMapper;
using BlogFest.Application.Services.Administration.Queries.DTOs;
using BlogFest.Domain.Administration;
using BlogFest.Web.ViewModels.Administration;

namespace BlogFest.Web.Automapper
{
    public class AdminUsersProfile : Profile
    {
        public AdminUsersProfile()
        {
            CreateMap<AdminUserForEditDTO, UserViewModel>();
        }
    }
}
