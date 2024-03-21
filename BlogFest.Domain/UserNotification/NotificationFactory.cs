using System.Text;

namespace BlogFest.Domain.NotificationUser
{
    public static class NotificationFactory
    {

        public static Notification CreateNotificationUserActive(bool active)
        {
            if(active) return new Notification(Guid.NewGuid(), "Your account has been activated");
			return new Notification(Guid.NewGuid(), "Your account has been deactivated. You still can see other posts.");
		}

        public static Notification CreateNotificationPostCreation(bool active)
        {
			if (active) return new Notification(Guid.NewGuid(), "Your are allowed to create post.");
			return new Notification(Guid.NewGuid(), "Your are not allowed to create post.");
		}

        public static Notification CreateNotificationCommentCreation(bool active)
        {
			if (active) return new Notification(Guid.NewGuid(), "Your are allowed to comment.");
			return new Notification(Guid.NewGuid(), "Your are not allowed to comment.");
		}

    }
}
