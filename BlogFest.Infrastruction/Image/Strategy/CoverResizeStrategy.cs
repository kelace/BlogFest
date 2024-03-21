
using System.Drawing.Drawing2D;
using System.Drawing;


namespace BlogFest.Infrastruction.ImageResizer.Strategy
{
	public class CoverResizeStrategy : IResizeStrategy
	{
		public async Task<byte[]> ResizeImage(byte[] source, int widthDestination, int heightDestination)
		{
			byte[] result = new byte[0];
			using (var ms = new MemoryStream(source))
			using (var output = new MemoryStream())
			using (var image = Bitmap.FromStream(ms))
			{

				using (var _img = new Bitmap(widthDestination, heightDestination))
				using (var g = Graphics.FromImage(_img))
				{

					var cx = (float)widthDestination / (float)heightDestination;

					var csh = cx > 1 ? image.Width / cx : image.Height;
					var csw = cx < 1 ? image.Height / cx : image.Width;
					var lastx = cx < 1 ? (image.Width - csw) / 2 : 0;
					var lasty = cx > 1 ? (image.Height - csh) / 2 : 0;

					if (cx == 1)
					{
						var min = Math.Min(image.Width, image.Height);
						csh = min;
						csw = min;
						lastx = (image.Width - min) / 2;
						lasty = (image.Height - min) / 2;
					}

					g.InterpolationMode = InterpolationMode.HighQualityBicubic;
					var sourceRect = new RectangleF(lastx, lasty, csw, csh);

					g.DrawImage(
						image,
						new RectangleF(0, 0, widthDestination, heightDestination),
						//0,
						//0,
						sourceRect,
						GraphicsUnit.Pixel
					);

					_img.Save(output, System.Drawing.Imaging.ImageFormat.Jpeg);
					result = output.ToArray();
				}
			}

			return result;
		}
	}
}
