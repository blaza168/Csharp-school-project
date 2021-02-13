using System.Collections;
using System.Collections.Generic;
using System.Data;

namespace Shop.Domain.Models
{
    public class Product
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public decimal Price { get; set; }
        public decimal Weight { get; set; }
        public int Qty { get; set; }
        
        // producer
        public int ProducerId { get; set; }
        public Producer Producer { get; set; }
        
        // category
        public int CategoryId { get; set; }
        public Category Category { get; set; }
        
        // attachment
        public int? FileId { get; set; }
        public virtual File File { get; set; }
        
        public ICollection<Rating> Ratings { get; set; }
    }
}