using BlogFest.Domain;
using BlogFest.Infrastruction.Persistance.DataModels;

namespace BlogFest.Infrastructure.Persistance.DataModels
{
    public class FileDataModel : BaseDataModel
    {
        public string Path { get; set; }
        public string Name { get; set; }
        public Guid? UserId { get; set; }
        public UserModel User { get; set; }
        public MediaTypes Type { get; set; }
        public PostFileData PostFile { get; set; }
    }
}
