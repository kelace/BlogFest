using BlogFest.Domain.Base;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlogFest.Infrastruction.ImageResizer.Strategy
{
	public class DefaultResizeStrategy : IResizeStrategy
	{
		public async Task<byte[]> ResizeImage(byte[] source, int widthDestination, int heightDestination)
		{
			byte[] result = new byte[0];
			using (var mst = new MemoryStream(source))
			using (var output = new MemoryStream())
			{
				//await st.CopyToAsync(mst);

				var img = System.Drawing.Image.FromStream(mst);

				var resizedImg = Procces(img, new Size(widthDestination, heightDestination));

				resizedImg.Save(output, System.Drawing.Imaging.ImageFormat.Jpeg);

				result = output.ToArray();
			}

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
			nPercentW = ((float)size.Width / (float)sourceWidth);
			nPercentH = ((float)size.Height / (float)sourceHeight);
			nPercent = Math.Min(nPercentW, nPercentH);
			// New Width and Height
			int destWidth = (int)(sourceWidth * nPercent);
			int destHeight = (int)(sourceHeight * nPercent);
			Bitmap b = new Bitmap(destWidth, destHeight);
			Graphics g = Graphics.FromImage((System.Drawing.Image)b);
			g.InterpolationMode = InterpolationMode.HighQualityBicubic;
			// Draw image with new width and height
			g.DrawImage(imgToResize, 0, 0, destWidth, destHeight);
			g.Dispose();
			return (System.Drawing.Image)b;
		}
	}
}
