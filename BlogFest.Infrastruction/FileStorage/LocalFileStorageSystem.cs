using Microsoft.EntityFrameworkCore;
using BlogFest.Infrastruction;
using BlogFest.Infrastructure.Persistance;
using BlogFest.Infrastructure.Persistance.DataModels;
using BlogFest.Web.Infrastructure.FileStorage;
using System.Xml.Linq;
using BlogFest.Application.Abstract;

namespace BlogFest.Services.FileStorage
{
    public class LocalFileStorageSystem : IFileStorageSystem
    {
        const string ContentPath = "Content\\Images\\";
        const string ContextContentPath = "Images\\";

        private readonly IWebHostEnvironmentAccessor _environment;
        private readonly IUserContext _userContext;
        private readonly ApplicationDbContext _context;
        public LocalFileStorageSystem(IWebHostEnvironmentAccessor environment, IUserContext userContext, ApplicationDbContext context)
        {
            _environment = environment;
            _userContext = userContext;
            _context = context;
        }
        public Task<byte[]> GetFile(Guid Id)
        {
            throw new NotImplementedException();
        }

        public async Task<byte[]> GetFile(string path)
        {
            var result = new byte[0];

            var absolutePath = Path.Combine(_environment.ContentRootPath, path);

            if (System.IO.File.Exists(path))
            {
                using (var stream = System.IO.File.Open(absolutePath, FileMode.Open))
                {
                    var file = new byte[stream.Length];
                    await stream.ReadAsync(file);
                    result = file.ToArray();
                }
            }

            return result;
        }

        public  void RemoveFile(string path)
        {
            var absolutePath = Path.Combine(_environment.ContentRootPath, path);
            if (System.IO.File.Exists(absolutePath))
            {
                File.Delete(absolutePath);
            }
        }

        public async Task<string> UploadFile(byte[] bytes, string name)
        {
            var dirPath = Path.Combine(_environment.ContentRootPath, ContentPath);
            var path = Path.Combine(_environment.ContentRootPath, ContentPath, name );
            var relativePath = Path.Combine(ContextContentPath, name);

            if (!System.IO.File.Exists(path))
            {
                using (var stream = System.IO.File.Create(path))
                {
                    await stream.WriteAsync(bytes);
                }
            }

            return relativePath;
        }

        public Task UploadFileRange(List<FileToUpload> files)
        {
            throw new NotImplementedException();
        }
    }
}
