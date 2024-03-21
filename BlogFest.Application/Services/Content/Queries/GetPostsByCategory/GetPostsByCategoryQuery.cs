using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BlogFest.Application.Services.Content.Queries.DTOs;
using BlogFest.Application.Services.Abstract;

namespace BlogFest.Application.Services.Content.Queries.GetPostsByCategory
{
    public class GetPostsByCategoryQuery : IRequest<List<PostDTO>>, IApplicationQuery
    {
        public string CategoryTitle { get; set; }
        public int Page { get; set; }   
    }
}
