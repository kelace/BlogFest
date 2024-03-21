using BlogFest.Infrastruction.ImageResizer;
using BlogFest.Services.FileStorage;
using BlogFest.Web.Infrastructure.FileStorage;
using BlogFest.Application.Services.Media.Abstractions;

namespace BlogFest.Web.Services.Media
{
    public class PhotoUploaderProvider : IPhotoUploaderProvider
    {
        private readonly IFileStorageSystem _fileStorage;
        private readonly IImageResizer _imageResizer;
        public PhotoUploaderProvider(IFileStorageSystem fileStorage, IImageResizer imageResizer)
        {
            _fileStorage = fileStorage;
            _imageResizer = imageResizer;
        }
        public async Task UploadPhoto(byte[] photo, string name, string userDomain)
        {
            var list = new List<FileToUpload>();

            list.Add(new FileToUpload
            {
                Body = _imageResizer.ResizeImage(photo, 500, 500),
                Name = name + "-large",
            });

            list.Add(new FileToUpload
            {
                Body = _imageResizer.ResizeImage(photo, 250, 250),
                Name = name + "-medium",
            });

            list.Add(new FileToUpload
            {
                Body = _imageResizer.ResizeImage(photo, 100, 100),
                Name = name + "-small",
            });

            await _fileStorage.UploadFileRange(list);
        }
    }
}
