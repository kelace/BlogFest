namespace BlogFest.Infrastruction.ImageResizer.Strategy
{
	public interface IResizeStrategy
	{
		Task<byte[]> ResizeImage(byte[] source, int widthDestination, int heightDestination);
	}

	public enum ResizeType
	{
		Default,
		Cover,
	}
}
