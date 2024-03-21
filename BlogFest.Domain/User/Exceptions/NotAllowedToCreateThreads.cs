using BlogFest.Web.Domain.Base;

namespace BlogFest.Domain.Users.Exceptions
{
    [Serializable]
    public class NotAllowedToCreateThreads : DomainException
    {
        public NotAllowedToCreateThreads(string message) : base(message) { }
    }
}
