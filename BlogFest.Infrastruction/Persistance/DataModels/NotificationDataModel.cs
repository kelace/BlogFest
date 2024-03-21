using BlogFest.Infrastructure.Persistance.DataModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlogFest.Infrastruction.Persistance.DataModels
{
    public class NotificationDataModel : BaseDataModel
    {
        public Guid UserId { get; set; }
        public string Message { get; set; }
        public bool IsRead { get; set; }
    }
}
