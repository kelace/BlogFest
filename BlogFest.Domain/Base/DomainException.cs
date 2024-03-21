namespace BlogFest.Web.Domain.Base
{
    [Serializable]
    public class DomainException : Exception
    {
        public List<object> AdditionalMessages { get; set; }
        public DomainException(string message) : base(message)
        {

        } 
    }
}
