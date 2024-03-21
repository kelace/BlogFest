using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlogFest.Application.Services.Content.Commands.UploadTitleImage
{
    public class UploadTitleImageResultValue
    {
        public Guid ImageId { get; set; }
        public string ImageUrl { get; set; }
    }
}
