using BlogFest.Domain.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlogFest.Domain.User
{
    public static class UserErrors
    {
        public static readonly Error NotAllowedToCreatePost = new("User.NotAllowedTocreatePost", "You are not allowed to create post. Please contact administrator");
        public static readonly Error PostDoesntExist = new("User.PostDoesntExist", "Post you are trying to update doesnt exist");
        public static readonly Error PostAlreadyExist = new("User.PostAlreadyExist", "Post you are trying to add is already exist");
    }
}
