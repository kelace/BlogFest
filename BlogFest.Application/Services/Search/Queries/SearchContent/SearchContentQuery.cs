using BlogFest.Application.Services.Abstract;
using BlogFest.Application.Services.Search.Queries.DTOs;
using MediatR;

namespace BlogFest.Application.Services.Search.Queries.SearchContent
{
    public class SearchContentQuery : IRequest<SearchDTO>,IApplicationQuery
    {
        public string Key { get; set; }
        public int Page { get; set; }
    }
}
