using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BlogFest.Application.Services.Content.Queries.DTOs;
using BlogFest.Application.Services.Abstract;

namespace BlogFest.Application.Services.Content.Queries.GetPostInfoForEdit
{
    public class GetPostInfoForEditQuery : IRequest<PostEditDTO>, IApplicationQuery
    {
        public string Slug { get; set; }

    }
}
