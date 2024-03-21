using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlogFest.Infrastruction.Files
{
    public interface IFileExtensionChecker
    {
        bool IsFileAllowed(byte[] file);
    }
}
