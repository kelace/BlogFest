using BlogFest.Infrastructure.Persistance.DataModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlogFest.Infrastruction.Persistance.DataModels
{
    public class CategoryPostDataModel : BaseDataModel
    {
        public Guid PostId { get; set; }
        public PostDataModel Post { get; set; }
        public Guid CategoryId { get; set; }
        public CategoryDataModel Category { get; set; }
    }
}
