using BlogFest.Domain.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlogFest.Application.Abstract
{
    public interface IUserImageLoader
    {
        Task<Result<(Guid, Guid, string), Error>> UploadFileAsync(byte[] source, string fileName);
        Task RemoveFileAsync(Guid id);
        Task RemoveFileAsync(string path);
        Task<byte[]> GetFileAsync(Guid id);
    }
}
