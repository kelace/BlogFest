namespace BlogFest.Web.Infrastructure.FileStorage
{
    public class FileToUpload
    {
        public byte[] Body { get; set; }
        public string Name { get; set; }
        public string Path { get; set; }
    }
}
