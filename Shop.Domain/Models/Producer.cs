using System.Collections;
using System.Collections.Generic;

namespace Shop.Domain.Models
{
    public class Producer
    {
        public int Id { get; set; }
        public string Description { get; set; }
        public string Country { get; set; }

        // attachment logo
        public int AttachmentId { get; set; }
        public Attachment Attachment { get; set; }
        
        public ICollection<Product> Products { get; set; }
    }
}