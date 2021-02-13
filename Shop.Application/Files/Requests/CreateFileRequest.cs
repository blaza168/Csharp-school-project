using System;
using Shop.Application.Products;

namespace Shop.Application.Files.Requests
{
    public class CreateFileRequest
    {
        public string Filename { get; set; }
        public DateTime UploadTime { get; set; }
        public string MimeType { get; set; }
    }
}