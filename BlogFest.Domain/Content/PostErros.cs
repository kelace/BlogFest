using BlogFest.Domain.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlogFest.Domain.Content
{
    public static class PostErros
    {
        public static Error TitleImageIsNull = new Error("Post.TitleImage.TitleImageIsNull", "Provide title image");
        public static Error PostDoesntExist = new Error("Post.PostDoesntExist", "Post doesnt exist");
        public static Error UserNotAllowedWriteComment = new Error("Post.UserNotAllowedWriteComment", "User not allowed to write comment");
        public static Error NotPossibleToInteract = new Error("Post.NotPossibleToInteract", "You cannot to interact with post now. Because the post is not published");
        public static Error NotAllowedSize = new Error("Post.NotAllowedSize", "Post content size surpass allowed size");
    }
}
