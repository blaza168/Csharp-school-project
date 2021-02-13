using System;

namespace Shop.Application.Files.Responses
{
    public class CreateFileResponse
    {
        public int Id { get; set; }
        public string Filename { get; set; }
        public DateTime UploadTime { get; set; }
        public string MimeType { get; set; }
        
        // filename on disk
        public string DiskFilename { get; set; }
    }
}