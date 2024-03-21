using System.ComponentModel.DataAnnotations;

namespace BlogFest.Web.ViewModels.Thread
{
    public class UploadImageTitleViewModel
    {
        [Required] 
        public IFormFile ImageTitle { get; set; }
        [Required]
        public Guid PostId { get; set; }

        public async Task<byte[]> GetImageTitleBytesAsync()
        {
            using (var stream = new MemoryStream())
            {
                await ImageTitle.CopyToAsync(stream);
                return stream.ToArray();
            }
        }
    }
}
