namespace BlogFest.Infrastructure.Persistance.DataModels
{
    public abstract class BaseDataModel
    {
        public Guid Id { get; set; }
        public int No { get; set; }
        public DateTime DateCreated { get; set; }
    }
}
