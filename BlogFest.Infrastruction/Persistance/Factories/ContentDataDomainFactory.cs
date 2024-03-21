using BlogFest.Infrastructure.Persistance.DataModels;
using BlogFest.Domain.Content.ContentCreating;

namespace BlogFest.Infrastruction.Persistance.Factories
{
    public static class ContentDataDomainFactory
    {
        public static ContentCreator CreateContentCreator(UserModel user)
        {
            var posts = user.Posts.Select(x => new Post(x.Id, x.ContentText, x.Title, x.PostStatus, x.UserId, x.Categories?.Select(c => c.Id ).ToList(), x.Slug)).ToList();

            return new ContentCreator(user.Id, user.IsCreatePostAllowed, posts);
        }
    }
}
