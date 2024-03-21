using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlogFest.Infrastruction
{
    public interface IWebHostEnvironmentAccessor
    {
        string ContentRootPath { get; }
    }
}
