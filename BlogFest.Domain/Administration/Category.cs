using BlogFest.Domain.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlogFest.Domain.Administration
{
    public class Category : Entity
    {
        public string Title { get; set; }
        public bool Enabled { get; set; }
        public Category(Guid id, string title, bool enabled) : base(id)
        {
            Title = title;
            Enabled = enabled;
        }

        public static List<Category> Empty
        {
            get
            {
                return new List<Category>();
            }
        }
    }
}
