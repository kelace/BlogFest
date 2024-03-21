using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlogFest.Application.Abstract
{
    public interface ISlugCreator
    {
        string CreateSlug(string word);
    }
}
