using BlogFest.Web.Infrastructure.FileStorage;

namespace BlogFest.Services.FileStorage
{
    public interface IFileStorageSystem
    {
        Task<string> UploadFile(byte[] bytes, string name);
        Task UploadFileRange(List<FileToUpload> files);
        void RemoveFile(string path);
        Task<byte[]> GetFile(string path);
    }
}
