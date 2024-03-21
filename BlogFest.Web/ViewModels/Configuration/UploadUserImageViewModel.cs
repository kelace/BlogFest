using System.ComponentModel.DataAnnotations;

namespace BlogFest.Web.ViewModels.Configuration
{
    public class UploadUserImageViewModel
    {
        public IFormFile FormFile { get; set; }

        public async Task<byte[]> FileToArray()
        {
            var result = new byte[0];
            using(var ms = new MemoryStream())
            {
                await FormFile.CopyToAsync(ms);
                result = ms.ToArray();
            }

            return result;
        }
    }
}
