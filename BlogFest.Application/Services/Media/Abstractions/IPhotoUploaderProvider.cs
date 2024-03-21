using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlogFest.Application.Services.Media.Abstractions
{
    public interface IPhotoUploaderProvider
    {
        public Task UploadPhoto(byte[] photo, string name, string userDomain);
    }
}
