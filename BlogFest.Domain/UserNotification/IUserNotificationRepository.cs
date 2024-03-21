using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlogFest.Domain.NotificationUser
{
	public interface IUserNotificationRepository
	{
		Task<UserNotification> GetByIdAsync(Guid managerId, List<Guid> usersToNotifyIds);
		Task UpdateAsync(UserNotification userNotification);
	}
}
