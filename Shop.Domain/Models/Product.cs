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
        
        
        // public decimal Rating { get; set; }
        // producer
        // category
        // attachment
    }
}