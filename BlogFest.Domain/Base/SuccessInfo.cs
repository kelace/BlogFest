using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlogFest.Domain.Base
{
    public class SuccessInfo
    {
        public Guid Id { get; set; }
        public string Slug { get; set; }
        public string Message { get; set; }
        public List<string> AdditionalData { get; set; }    
    }
}
