using AutoMapper;
using BlogFest.Web.ViewModels.Administration;
using BlogFest.Application.Services.Administration.Queries.DTOs;

namespace BlogFest.Web.Automapper
{
    public class CategoryProfile : Profile
    {
        public CategoryProfile()
        {
            CreateMap<CategoryDTO, CategoryViewModel>();
            CreateMap<CategoryViewModel, CategoryDTO>();
        }
    }
}
