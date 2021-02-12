using System;

namespace Shop.Domain.Models
{
    public class Attachment
    {
        public int Id { get; set; }
        public DateTime UploadTime { get; set; }
        public string MimeType { get; set; }
    }
}