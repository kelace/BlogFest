using BlogFest.Data;
using BlogFest.Domain.NotificationUser;
using BlogFest.Domain.NotificationUser.Events;
using BlogFest.Infrastruction.Persistance.DataModels;
using BlogFest.Infrastructure.Persistance;
using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;

namespace BlogFest.Infrastruction.Persistance.Repositories
{
	public class UserNotificationRepository : IUserNotificationRepository
	{
		private readonly ApplicationDbContext _context;
		private readonly IDomainEventStorage _eventSrorage;
		private readonly OldDataApplicationDbContext _oldDataContext;
		public UserNotificationRepository(ApplicationDbContext context, IDomainEventStorage eventSrorage, OldDataApplicationDbContext oldDataContext)
		{
			_context = context;
			_oldDataContext = oldDataContext;
			_eventSrorage = eventSrorage;
		}
		public async Task<UserNotification> GetByIdAsync(Guid managerId, List<Guid> usersToNotifyIds)
		{

				return await (
			   from user in _oldDataContext.Users
			   join userRole in _oldDataContext.UserRoles on user.Id equals userRole.UserId
			   join role in _oldDataContext.Roles on userRole.RoleId equals role.Id
			   where user.Id == managerId
			   where role.Name == "Admin"
			   select new UserNotification(user.Id, _oldDataContext.Users.Where(x => usersToNotifyIds.Contains(x.Id)).Select(x => new User(x.Id, x.Active, x.IsCreatePostAllowed, x.IsCommentAllowed)).ToList())
			   ).FirstOrDefaultAsync();

		}

		public async Task UpdateAsync(UserNotification user)
		{

			var events = user.GetEvents();
			user.ClearEvents();

			_eventSrorage.AddEvent(events);

			foreach (var @event in events)
			{

				if (@event is UserHasBeenNotifiedEvent)
				{
					var domainEvent = (UserHasBeenNotifiedEvent)@event;
					var notifications = domainEvent.UserNotifications.Select(x => new NotificationDataModel { Id = x.Id, Message = x.Message, UserId = domainEvent.UserId });

					await _context.Notifications.AddRangeAsync(notifications);
				}
			}
		}
	}
}
