namespace Smev3Client
{
    public class Attachment
    {
        public string Name { get; set; }
        public string MimeType { get; set; }
        public byte[] Data { get; set; }
        public byte[] SignatureData { get; set; }
    }
}
