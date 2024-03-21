using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlogFest.Domain.Base
{
    public record Error(string Code, string Description = null);
}
