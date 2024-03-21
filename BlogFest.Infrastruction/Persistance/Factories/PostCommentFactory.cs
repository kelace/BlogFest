using BlogFest.Infrastructure.Persistance.DataModels;
using BlogFest.Domain.Content.ContentConsuming;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlogFest.Infrastruction.Persistance.Factories
{
    public static class PostCommentFactory
    {
        public static PostComment CreateComment(CommentDataModel comment)
        {
            return new PostComment(comment.Id, comment.Content, comment.PostId, comment.UserId);
        }

        public static List<PostComment> CreateComment(List<CommentDataModel> comments)
        {
            return comments?.Select(x => new PostComment(x.Id, x.Content, x.PostId, x.UserId)).ToList();
        }
    }
}
