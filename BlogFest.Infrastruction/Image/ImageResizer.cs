using BlogFest.Infrastruction.ImageResizer.Strategy;
using System.Drawing;
using System.Drawing.Drawing2D;

namespace BlogFest.Infrastruction.ImageResizer
{
    public class ImageResizer : IImageResizer
    {
        private readonly Dictionary<ResizeType, IResizeStrategy> _strategies;

        public ImageResizer(Dictionary<ResizeType, IResizeStrategy> strategies)
        {
            _strategies = strategies;
        }
        public byte[] ResizeImage(byte[] image, int width, int height)
        {
            throw new NotImplementedException();
        }

        public async Task<byte[]> ResizeImageAsync(byte[] image, int width, int height, ResizeType type)
        {
            var resizer = _strategies[type];

            if (resizer == null) throw new NullReferenceException(nameof(resizer));

            return await resizer.ResizeImage(image, width, height);   
        }

        public async Task<byte[]> ResizeImageAsync(byte[] image, int width, int height)
        {

            byte[] result = new byte[width * height];
            if (image.Length == 0) return new byte[0];
            await Task.Run(() =>
            {
                using (var mst = new MemoryStream(image))
                using (var output = new MemoryStream())
                {
                    //await st.CopyToAsync(mst);

           

                    var img = System.Drawing.Image.FromStream(mst);

                    var resizedImg = Procces(img, new Size(width, height));

                    resizedImg.Save(output, System.Drawing.Imaging.ImageFormat.Jpeg);

                    result = output.ToArray();
                }
            });

            return result;
        }

        private Image Procces(Image imgToResize, Size size)
        {
            // Get the image current width
            int sourceWidth = imgToResize.Width;
            // Get the image current height
            int sourceHeight = imgToResize.Height;
            float nPercent = 0;
            float nPercentW = 0;
            float nPercentH = 0;
            // Calculate width and height with new desired size
            nPercentW = size.Width / (float)sourceWidth;
            nPercentH = size.Height / (float)sourceHeight;
            nPercent = Math.Min(nPercentW, nPercentH);
            // New Width and Height
            int destWidth = (int)(sourceWidth * nPercent);
            int destHeight = (int)(sourceHeight * nPercent);
            Bitmap b = new Bitmap(destWidth, destHeight);
            Graphics g = Graphics.FromImage(b);
            g.InterpolationMode = InterpolationMode.HighQualityBicubic;
            // Draw image with new width and height
            g.DrawImage(imgToResize, 0, 0, destWidth, destHeight);
            g.Dispose();
            return (System.Drawing.Image)b;
        }
    }
}
