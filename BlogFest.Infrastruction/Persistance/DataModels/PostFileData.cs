using BlogFest.Infrastructure.Persistance.DataModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlogFest.Infrastruction.Persistance.DataModels
{
    public class PostFileData : BaseDataModel
    {
        public PostDataModel Post { get; set; }
        public Guid PostId { get; set; }
        public FileDataModel File { get; set; }
        public Guid FileId { get; set; }
        public bool Active { get; set; }
    }
}
