using BlogFest.Web.Domain.Base;
using System.Runtime.Serialization;

namespace BlogFest.Domain.Users.Exceptions
{
    [Serializable]
    public class NotAllowedTocreateCategoryException : DomainException
    {
        public NotAllowedTocreateCategoryException(string message) : base(message) { }
    }
}