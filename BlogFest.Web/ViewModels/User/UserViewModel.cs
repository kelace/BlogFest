using BlogFest.Infrastructure.Persistance.DataModels;

namespace BlogFest.Models.User
{
    public class UserViewModel
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public List<PostDataModel> Threads { get; set;} 
        public bool IsUserAccount { get; set; }
        public bool IsAdmin{ get; set; }
    }
}
