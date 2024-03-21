using BlogFest.Domain.Users;
using BlogFest.Infrastructure.Persistance.DataModels;

namespace BlogFest.Infrastructure.Persistance.Factories
{
    public static class UserFactory
    {
        public static User CreateUser(UserModel model, Guid? image = null)
        {

            var userInfo = new UserInformation(model.FirstName, model.LastName, image, model.Bio);
            var user = new User(model.Id, model.Active, model.IsCommentAllowed,model.IsCreatePostAllowed, userInfo);

            return user;
        }
    }
}
