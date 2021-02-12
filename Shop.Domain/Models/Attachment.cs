using System;

namespace Shop.Domain.Models
{
    public class Attachment
    {
        public int Id { get; set; }
        public DateTime UploadTime { get; set; }
        public string MimeType { get; set; }
        
        // This stupid EF requires reference navigation on both sides ...
        public virtual Product Product { get; set; }
        public virtual Producer Producer { get; set; }
    }
}