using BlogFest.Infrastructure.Persistance.DataModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlogFest.Infrastruction.Persistance.DataModels
{
    public class CategoryDataModel : BaseDataModel
    {
        public string Title { get; set; }
        public string EncodedTitle { get; set; }
        public List<CategoryPostDataModel> Posts { get; set; }
        public bool Enabled { get; set; }
    }
}
