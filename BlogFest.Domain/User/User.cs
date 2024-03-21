using BlogFest.Domain.Base;
using BlogFest.Domain.User.Events;

namespace BlogFest.Domain.Users
{
    public class User : AggregateRoot
    {
        private List<Guid> _forumThreads;
        private bool _isUserAllowedToComment;
        private bool _isUserAllowedToCreatePost;
        private bool _active;
        public string Name { get; set; }
        public UserInformation UserInformation { get; private set;}
        public User(Guid id, string name) : base(id)
        {
            Name = name;
        }
        public User(Guid id, bool isUserActive, bool isUserAllowedToComment,bool isUserAllowedToCreatePost, UserInformation information) : base (id)
        {

            _isUserAllowedToComment = isUserAllowedToComment;
            _isUserAllowedToCreatePost = isUserAllowedToCreatePost;
            _active = isUserActive;
            UserInformation = information;
        }


        public void ReadAllNotifications()
        {
            AddEvent(new ReadAllUserNotificationsEvent
            {
                UserId = Id
            });
        }

        public Result<Guid, Error> EditInformation(UserInformation settings)
        {
            if(settings.FirstName != null) UserInformation.FirstName = settings.FirstName;
            if(settings.LastName != null) UserInformation.LastName = settings.LastName;
            if(settings.Bio != null) UserInformation.Bio = settings.Bio;
            if(settings.PhotoId != null) UserInformation.PhotoId = settings.PhotoId;

            AddEvent(new UserInformationHasBeenChanged
            {
                UserId = Id,
                FirstName = UserInformation.FirstName,
                LastName = UserInformation.LastName,
                PhotoId = UserInformation.PhotoId,
                Bio = UserInformation.Bio
            });

            return Id;
        }
    }
}
