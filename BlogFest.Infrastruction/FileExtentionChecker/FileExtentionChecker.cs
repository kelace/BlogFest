using BlogFest.Infrastruction.FileExtentionChecker;

namespace BlogFest.Infrastruction.Files
{
    public class FileExtensionChecker : IFileExtensionChecker
    {
        public bool IsFileAllowed(byte[] file)
        {
            if(file == null && file.Length == 0) return false;

            using(var ms = new MemoryStream(file))
            using(var br = new BinaryReader(ms)) 
            {
                byte[] data = br.ReadBytes(0x10); 
                string data_as_hex = BitConverter.ToString(data);

                data_as_hex = data_as_hex.Substring(0, 8);

                if (data_as_hex == MagicFileTypeConstants.Jpg) return true;
                return false;
            }
        }
    }
}
