using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlogFest.Application.Services.Media.Results
{
    public class SuccesUploadResult
    {
        public Guid ImageId { get; set; }
        public string ImagePath { get; set; }
    }
}
