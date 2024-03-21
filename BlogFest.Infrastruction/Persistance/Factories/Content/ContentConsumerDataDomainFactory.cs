using BlogFest.Infrastruction.Persistance.Factories;
using BlogFest.Infrastructure.Persistance.DataModels;
using BlogFest.Domain.Content.ContentConsuming;

namespace BlogFest.Infrastruction.Persistance.Factories.Content
{
    public static class ContentConsumerDataDomainFactory
    {
        public static ContentConsumer CreateContentConsumer(UserModel user, PostDataModel post)
        {
            var postDomain = new Post(post.Id, post.PostStatus, post.Slug);

            return new ContentConsumer(user.Id, user.IsCommentAllowed, postDomain);
        }
    }
}
