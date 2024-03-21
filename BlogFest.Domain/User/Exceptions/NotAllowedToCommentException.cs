using BlogFest.Web.Domain.Base;

namespace BlogFest.Domain.Users.Exceptions
{
    [Serializable]
    public class NotAllowedToCommentException : DomainException
    {
        public NotAllowedToCommentException(string message = "Not allowed to comment") : base(message)
        {

        }
    }
}
