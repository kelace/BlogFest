using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlogFest.Application.Behaviors.Abstract
{
    public interface ICacheable
    {
        public string Key { get; }
    }
}
