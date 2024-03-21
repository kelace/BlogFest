using BlogFest.Infrastruction.ImageResizer.Strategy;

namespace BlogFest.Infrastruction.ImageResizer
{
    public interface IImageResizer
    {
        Task<byte[]> ResizeImageAsync(byte[] image, int width, int height);
        byte[] ResizeImage(byte[] image, int width, int height);
        Task<byte[]> ResizeImageAsync(byte[] image, int width, int height, ResizeType type);

    }
}
