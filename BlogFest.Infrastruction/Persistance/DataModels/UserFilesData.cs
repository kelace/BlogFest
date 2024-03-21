using BlogFest.Infrastructure.Persistance.DataModels;

namespace BlogFest.Infrastruction.Persistance.DataModels
{
    public class UserFileData : BaseDataModel
    {
        public Guid UserId { get; set; }
        public Guid FileId { get; set; }
        public bool Choosed { get; set; }
    }
}
