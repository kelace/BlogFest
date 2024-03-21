using BlogFest.Application.Services.Media.Results;
using BlogFest.Domain.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlogFest.Application.Abstract
{
    public interface IPostImageLoader
    {
        Task<Result<SuccesUploadResult, Error>> LoadTitleImage(byte[] photo, Guid postId);
        Task<Result<bool, Error>> RemoveTitleImage(Guid id);
    }
}
