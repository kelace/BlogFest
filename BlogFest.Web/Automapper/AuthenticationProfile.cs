using AutoMapper;
using BlogFest.Application.Services.Identity.DTOs;
using BlogFest.Models.Authorization;
using BlogFest.Web.ViewModels.Authorization;

namespace BlogFest.Web.Automapper
{
	public class AuthenticationProfile : Profile
	{
		public AuthenticationProfile()
		{
			CreateMap<RegisterUserViewModel, RegisterUserDTO>();
			CreateMap<ResetPasswordViewModel, ResetPasswordDTO>();
			CreateMap<ResetPasswordViewModel, ResetPasswordDTO>();
			CreateMap<RecoveryPasswordViewModel, RecoveryPasswordDTO>();
			CreateMap<LoginUserViewModel, LoginUserDTO>();
		}
	}
}
