using BlogFest.Application.Services.Configuration.Queries.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlogFest.Application.Configuration.Queries
{
    public interface IConfigurationProcedures
    {
        Task<UserConfigurationDto> GetUserConfiguration(Guid UserId);
    }
}
