using BlogFest.Application.Services.Abstract;
using BlogFest.Application.Services.Configuration.Queries.DTOs;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlogFest.Application.Services.Configuration.Queries.GetConfigurationInfo
{
    public class GetConfigurationInfoQuery : IRequest<UserConfigurationDto>, IApplicationQuery
    {
        public Guid UserId { get; set; }
    }
}
