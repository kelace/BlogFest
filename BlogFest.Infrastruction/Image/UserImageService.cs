using Microsoft.EntityFrameworkCore;
using BlogFest.Domain;
using BlogFest.Infrastructure.Persistance;
using BlogFest.Infrastructure.Persistance.DataModels;
using BlogFest.Services.FileStorage;
using BlogFest.Domain.Base;
using BlogFest.Infrastruction.Persistance.DataModels;
using System.Drawing;
using BlogFest.Application.Abstract;
using BlogFest.Infrastruction.ImageResizer;
using BlogFest.Infrastruction.ImageResizer.Strategy;
using BlogFest.Infrastruction.Files;

namespace BlogFest.Infrastruction
{
    public class UserImageService : IUserImageLoader
    {

        const int DefaultTitleImageWidth = 185;
        const int DefaultTitleImageHeight = 185;

        private readonly IFileStorageSystem _fileStorage;
        private readonly ApplicationDbContext _db;
        private readonly IUserContext _userContext;
        private readonly IImageResizer _imageResizer;
        private readonly IFileExtensionChecker _fileChecker;
        public UserImageService(IFileStorageSystem fileStorage, ApplicationDbContext db, IUserContext userContext, IImageResizer imageResizer, IFileExtensionChecker fileChecker)
        {
            _fileStorage = fileStorage;
            _db = db;
            _userContext = userContext;
            _imageResizer = imageResizer;
            _fileChecker = fileChecker;
        }

        public async Task<byte[]> GetFileAsync(Guid Id)
        {
            var file = await _db.Files.Where(x => x.Id == Id).FirstOrDefaultAsync();

            if (file == null) return new byte[0];

            var result = await _fileStorage.GetFile(file.Path);

            return result;
        }

        public async Task RemoveFileAsync(Guid id)
        {
            var contentResult = await(from pf in _db.UserFiles
                                      join f in _db.Files on pf.FileId equals f.Id
                                      where pf.Id == id
                                      select new { path = f.Path, fileId = f.Id, userFileId = pf.Id }).FirstOrDefaultAsync();

            _fileStorage.RemoveFile(contentResult.path);

            var userFile = new UserFileData
            {
                Id = contentResult.userFileId,

            };

            _db.UserFiles.Attach(userFile);
            _db.UserFiles.Remove(userFile);
        }

        public Task RemoveFileAsync(string path)
        {
            throw new NotImplementedException();
        }

        public async Task<Result<(Guid, Guid, string), Error>> UploadFileAsync(byte[] source, string fileName)
        {
            var user = _userContext.GetUser();
            byte[] bytes;

            if (!_fileChecker.IsFileAllowed(source)) return new Error("Configuration.TitleImage.FileExtensionNotAllowed", "The only allowed file extension is jpg");

            using (var ms = new MemoryStream(source))
            {

                if (ms.Length / 1000 > 1000)
                {
                    return new Error("Configuration.ImageTitle.FileGreatearThan1MB", "FileGreatearThan1MB Please provide file with less size");
                }

                bytes = await _imageResizer.ResizeImageAsync(source, DefaultTitleImageWidth, DefaultTitleImageHeight, ResizeType.Cover);
            }

            var file =  user.Id.ToString() + "-" + Guid.NewGuid().ToString() + "-main-photo.png";

            var path = await _fileStorage.UploadFile(bytes, file);

            var uid = _userContext.CurrentUserId;

            var fileId = Guid.NewGuid();

            var fileData = new FileDataModel
            {
                Id = fileId,
                UserId = uid,
                Path = path,
                Name = file,
                DateCreated = DateTime.Now,
                Type = MediaTypes.ProfilePhoto
            };

            var userFileId = Guid.NewGuid();
            var userFileData = new UserFileData
            {
                Id = userFileId,
                UserId = uid,
                FileId = fileId,
                DateCreated = DateTime.Now,
                Choosed = false,
            };

            await _db.Files.AddRangeAsync(fileData);
            await _db.UserFiles.AddAsync(userFileData);

            return (fileId, userFileId, path);
        }
    }
}
