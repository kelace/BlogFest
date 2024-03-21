using BlogFest.Application.Abstract;
using BlogFest.Application.Services.Media.Results;
using BlogFest.Domain.Base;
using BlogFest.Infrastruction.Files;
using BlogFest.Infrastruction.ImageResizer;
using BlogFest.Infrastruction.ImageResizer.Strategy;
using BlogFest.Infrastruction.Persistance.DataModels;
using BlogFest.Infrastructure.Persistance;
using BlogFest.Infrastructure.Persistance.DataModels;
using BlogFest.Services.FileStorage;
using Microsoft.EntityFrameworkCore;

namespace BlogFest.Infrastruction
{
    public class PostImageLoader : IPostImageLoader
    {
        const int DefaultTitleImageWidth = 780;
        const int DefaultTitleImageHeight = 438;
        private readonly IFileStorageSystem _fyleSystem;
        private readonly ApplicationDbContext _db;
        private readonly IUserContext _userContext;
		private readonly IImageResizer _imageResizer; 
		private readonly IFileExtensionChecker _fileChecker; 

        public PostImageLoader(IFileStorageSystem fyleSystem, ApplicationDbContext db, IUserContext userContext, IImageResizer imageResizer, IFileExtensionChecker fileChecker)
        {
            _fyleSystem = fyleSystem;
            _db = db;
            _userContext = userContext;
			_imageResizer = imageResizer;
            _fileChecker = fileChecker;
        }

        public async Task<Result<SuccesUploadResult, Error>> LoadTitleImage(byte[] photo, Guid postId)
        {

            var id = Guid.NewGuid();

            if (!_fileChecker.IsFileAllowed(photo)) return new Error("Post.TitleImage.FileExtensionNotAllowed", "The only allowed file extension is jpg");

			var bytes = await _imageResizer.ResizeImageAsync(photo, DefaultTitleImageWidth, DefaultTitleImageHeight, ResizeType.Cover);
			var result = await _fyleSystem.UploadFile(bytes, "image-title-" + id.ToString() + ".jpg");
			var postFileId = Guid.NewGuid();

			var file = new FileDataModel
			{
				Id = id,
				Path = result,
				Name = "image-title-" + id.ToString(),
				UserId = _userContext.CurrentUserId
			};

			var postFile = new PostFileData
			{
				Id = postFileId,
				FileId = id,
				Active = false,
				PostId = postId,
			};

			_db.Files.Add(file);
			_db.PostFiles.Add(postFile);


            return new SuccesUploadResult
            {
                ImagePath = result,
                ImageId = id
            };
        }

        public async Task<Result<bool, Error>> RemoveTitleImage(Guid id)
        {
            var contentResult = await (from pf in _db.PostFiles
                         join f in _db.Files on pf.FileId equals f.Id 
                         where pf.Id == id
                         select new {path = f.Path, fileId = f.Id, photoFileId = pf.Id} ).FirstOrDefaultAsync();

            _fyleSystem.RemoveFile(contentResult.path);

            var file = new FileDataModel
            {
                Id = contentResult.fileId,

            };

            var postFile = new PostFileData
            {
                Id = contentResult.photoFileId,

            };

            _db.PostFiles.Remove(postFile);
            _db.Files.Remove(file);

            return true;

        }
    }
}
