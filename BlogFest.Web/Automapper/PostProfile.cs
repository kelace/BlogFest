using AutoMapper;
using Microsoft.AspNetCore.Mvc.Rendering;
using BlogFest.Domain.Administration;
using BlogFest.Web.ViewModels.Administration;
using BlogFest.Web.ViewModels.Thread;
using BlogFest.Application.Services.Content.Queries.DTOs;
using BlogFest.Application.Services.Administration.Queries.DTOs;

namespace BlogFest.Web.Automapper
{
    public class PostProfile : Profile
    {
        public PostProfile()
        {
            CreateMap<CategoryDTO, CategoryViewModel>();
            CreateMap<PostEditDTO, EditPostViewModel>()
                .ForMember(dest => dest.Categories, opt => opt.MapFrom(x => x.Categories.Select(c => new SelectListItem { Text = c.Title, Value = c.Id.ToString(), Selected = c.Selected })));
        }
    }
}
