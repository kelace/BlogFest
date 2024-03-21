using BlogFest.Application.Services.Abstract;
using BlogFest.Domain.Administration;
using BlogFest.Domain.Base;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlogFest.Application.Services.Administration.Commands.EditUser
{
    public class EditUserCommand : IRequest<Result<SuccessInfo, Error>>, IApplicationCommand
    {
        public List<UserSettings> UserSettings { get; set; }    
    }
}
