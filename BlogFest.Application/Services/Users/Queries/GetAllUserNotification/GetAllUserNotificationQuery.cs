using BlogFest.Application.Services.Abstract;
using BlogFest.Application.Services.Users.DTOs;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlogFest.Application.Services.Users.Queries.GetAllNotification
{
    public class GetAllUserNotificationQuery : IRequest<List<NotificationDTO>>,  IApplicationQuery
    {
    }
}
