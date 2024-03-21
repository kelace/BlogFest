using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;
using BlogFest.Domain.Administration;
using BlogFest.Domain.Administration.Events;
using System.Text;
using System.Text.Encodings.Web;
using System.Web;
using BlogFest.Application.Abstract;
using BlogFest.Data;

namespace BlogFest.Infrastructure.Persistance.Repositories
{
    public class ManagerRepository : IManagerRepository
    {
        ApplicationDbContext _context;
        IUserContext _userContext;
        IDomainEventStorage _eventSrorage;
        public ManagerRepository(ApplicationDbContext context, IUserContext userContext, IDomainEventStorage eventStorage)
        {
            _context = context;
            _userContext = userContext;
            _eventSrorage = eventStorage;
        }
        public async Task<Manager> GetManagerByIdAsync(Guid Id)
        {

            return await (
                       from user in _context.Users
                       join userRole in _context.UserRoles on user.Id equals userRole.UserId
                       join role in _context.Roles on userRole.RoleId equals role.Id
                       where user.Id == Id
                       where role.Name == "Admin"
                       select new Manager(user.Id, AdministrationType.Admin, _context.Categories.Select(x => new Category(x.Id, x.Title, x.Enabled) ).ToList())
                       ).FirstOrDefaultAsync();
        }

        public async Task<UserSettings> GetUserSettingsByIdAsync(Guid Id)
        {

            return await (

                from user in _context.Users
                    //join userRole in _context.UserRoles on user.Id equals userRole.UserId
                    //join role in _context.Roles on userRole.RoleId equals role.Id
                where user.Id == Id
                select new UserSettings
                {
                    UserId = user.Id,
                    IsAllowedToComment = user.IsCommentAllowed,
                    IsAllowedToCreateThread = user.IsCreatePostAllowed,
                    IsActive = user.Active,
                }

                ).FirstOrDefaultAsync();
        }

        public async Task Update(Manager model)
        {
            var events = model.GetEvents();
            model.ClearEvents();

            _eventSrorage.AddEvent(events);

            foreach (var @event in events)
            {
                if(@event is CategoryHaveBeenRemoved)
                {
                    var domainEvent = (CategoryHaveBeenRemoved)@event;

                    var paramItems = new object[]
                    {
                        new SqlParameter("@Id", domainEvent.Id)
                    };

                    try
                    {
                        await _context.Database.ExecuteSqlRawAsync($@"DELETE FROM dbo.Categories WHERE Id = @Id", paramItems);
                    }
                    catch (Exception ex)
                    {
                        
                        throw;
                    }
                }

                if (@event is CategoriesHaveBeenAdded)
                {
                    var domainEvent = (CategoriesHaveBeenAdded)@event;

                    var sqlParameters = new List<SqlParameter>();

                    var sqlCommand = new StringBuilder();

                    for (int i = 0; i < domainEvent.Categories.Count; i++)
                    {
                        var insertCommand = $@"insert dbo.Categories (Id, Title, Enabled, DateCreated, EncodedTitle) Values(@Id{i}, @Title{i}, @Enabled{i}, @DateCreated{i}, @EncodedTitle{i});";
                        var updateCommand = $@"update dbo.Categories set Enabled = @Enabled{i}, Title = @Title{i} where Id = @Id{i};";

                        var command = domainEvent.Categories[i].ModifiedEntity ? updateCommand : insertCommand;

                        sqlCommand.Append(command);

                        sqlParameters.Add(new SqlParameter("@Id" + i, domainEvent.Categories[i].Id));
                        sqlParameters.Add(new SqlParameter("@Title" + i, domainEvent.Categories[i].Title));
                        sqlParameters.Add(new SqlParameter("@Enabled" + i, domainEvent.Categories[i].Enabled));
                        sqlParameters.Add(new SqlParameter("@DateCreated" + i, DateTime.Now));
                        sqlParameters.Add(new SqlParameter("@EncodedTitle" + i, HttpUtility.UrlEncode(domainEvent.Categories[i].Title)));
                    }

                    try
                    {
                        await _context.Database.ExecuteSqlRawAsync(sqlCommand.ToString(), sqlParameters.ToArray());
                    }
                    catch (Exception ex)
                    {

                        throw;
                    }
                }

                if (@event is UserSettingsHasBeenEditedEvent)
                {
                    var domainEvent = (UserSettingsHasBeenEditedEvent)@event;

                    var sqlParameters = new List<SqlParameter>();

                    var sqlCommand = new StringBuilder();

                    for (int i = 0; i < domainEvent.NewUserSettings.Count; i++)
                    {
                        sqlCommand.Append($@" 

                        update dbo.Users set Active = @Active{i}, IsCommentAllowed = @IsCommentAllowed{i}, IsCreatePostAllowed = @IsCreateThreadAllowed{i} where Id = @UserId{i}; ");

                        sqlParameters.Add(new SqlParameter("@UserId" + i, domainEvent.NewUserSettings[i].UserId));
                        sqlParameters.Add(new SqlParameter("@Active" + i, domainEvent.NewUserSettings[i].IsActive));
                        sqlParameters.Add(new SqlParameter("@IsCommentAllowed" + i, domainEvent.NewUserSettings[i].IsAllowedToComment));
                        sqlParameters.Add(new SqlParameter("@IsCreateThreadAllowed" + i, domainEvent.NewUserSettings[i].IsAllowedToCreateThread));
                    }

                    await _context.Database.ExecuteSqlRawAsync(sqlCommand.ToString(), sqlParameters.ToArray());
                }
            }
        }

    }
}
