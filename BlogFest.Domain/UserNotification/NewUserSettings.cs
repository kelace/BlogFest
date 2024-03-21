using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlogFest.Domain.NotificationUser
{
    public class NewUserSettings
    {
        public Guid Id { get; set; }
        public bool IsActive { get; set; }
        public bool IsAllowedToCreatePost { get; set; }
        public bool IsAllowedToComment { get; set; }
    }
}
