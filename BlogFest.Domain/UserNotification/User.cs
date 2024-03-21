using BlogFest.Domain.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlogFest.Domain.NotificationUser
{
    public class User : Entity
    {
        public bool IsActive { get; private set; }
        public bool IsAllowedToCreatePost { get; private set; }
        public bool IsAllowedToComment { get; private set; }

        public User(Guid id, bool isActive, bool isAllowedTocreatePost, bool isAllowedToComment) : base(id)
        {
            IsActive = isActive;
            IsAllowedToCreatePost = isAllowedTocreatePost;
            IsAllowedToComment = isAllowedToComment;    
        }

        public List<Notification> Notify(bool isActive, bool isAllowedToCreatePost, bool isAllowedToComment)
        {
            var notifications = new List<Notification>();

            if (IsActive != isActive) notifications.Add(NotificationFactory.CreateNotificationUserActive(IsActive));
            if (IsAllowedToCreatePost != isAllowedToCreatePost) notifications.Add(NotificationFactory.CreateNotificationUserActive(isAllowedToCreatePost));
            if (IsAllowedToComment != isAllowedToComment) notifications.Add(NotificationFactory.CreateNotificationUserActive(isAllowedToComment));

            return notifications;
		}
    }
}
