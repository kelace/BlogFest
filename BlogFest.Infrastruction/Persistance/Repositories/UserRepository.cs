using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;
using BlogFest.Data;
using BlogFest.Domain.Users;
using BlogFest.Infrastructure.Persistance.DataModels;
using BlogFest.Infrastructure.Persistance.Factories;
using BlogFest.Domain.User.Events;
using BlogFest.Application;

namespace BlogFest.Infrastructure.Persistance.Repositories
{
    public class UserRepository : IUserRepository
    {
        ApplicationDbContext _context;
        IDomainEventStorage _eventSrorage;
        public UserRepository(ApplicationDbContext context, IDomainEventStorage eventSrorage)
        {
            _context = context;
            _eventSrorage = eventSrorage;
        }

        public async Task Add(User user)
        {

            var userModel = new UserModel
            {
                Id = user.Id,
                Name = user.Name,
            };

            await _context.Users.AddAsync(userModel);
        }

        public async Task<List<User>> GetUsers(List<Guid> ids)
        {
            return await _context.Users.Where(x => ids.Contains(x.Id)).Select(x => UserFactory.CreateUser(x, null)).ToListAsync();
        }

        public async Task<User> GetUserByIdAsync(Guid id)
        {
            var imageId = await _context.UserFiles.Where(x => x.UserId == id).Select(x => x.Id).FirstOrDefaultAsync();
            return await _context.Users.Include(x => x.Posts).Where(x => x.Id == id).Select(x => UserFactory.CreateUser(x, imageId)).FirstOrDefaultAsync();
        }

        public async Task Remove(Guid id)
        {
            var user = new UserModel { Id = id };   
            _context.Users.Remove(user);
        }

        public async Task Update(User user)
        {

            var events = user.GetEvents();
            user.ClearEvents();

            _eventSrorage.AddEvent(events);

            foreach (var @event in events)
            {

                if(@event is ReadAllUserNotificationsEvent)
                {
                    var domainEvent = (ReadAllUserNotificationsEvent)@event;
                    await _context.Database.ExecuteSqlRawAsync(@$"UPDATE {DbConstants.NotificationTable} SET IsRead = 1 WHERE UserId = @UserId", new object[]
                    {
                        new SqlParameter("UserId", domainEvent.UserId)
                    });
                }


                if (@event is UserInformationHasBeenChanged)
                {
                    var domainEvent = (UserInformationHasBeenChanged)@event;

                    object[] paramItems = new object[]
                    {
                        // User
                        new SqlParameter("@Id", domainEvent.UserId) ,
                        new SqlParameter("@FirstName", domainEvent.FirstName) ,
                        new SqlParameter("@SecondName", domainEvent.LastName),
                        new SqlParameter("@Bio", domainEvent.Bio),


                       new SqlParameter("@PhotoId", domainEvent.PhotoId == null || domainEvent.PhotoId == Guid.Empty ? null  : domainEvent.PhotoId),
                    };


                    await _context.Database.ExecuteSqlRawAsync($@"

                    Update dbo.Users set FirstName = @FirstName, LastName = @SecondName, Bio = @Bio 
                        where Id = @Id;

                    update dbo.UserFiles set Choosed = 0 where UserId = @Id and Choosed = 1;
                    update dbo.UserFiles set Choosed = 1 where UserId = @Id and Id = @PhotoId;

                ", paramItems);


                }
            }
        }
    }
}
