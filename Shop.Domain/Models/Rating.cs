using System.IO.Compression;

namespace Shop.Domain.Models
{
    public class Rating
    {
        public int Id { get; set; }
        public decimal NumericRating { get; set; }
        public string Description { get; set; }
        
        public int ProductId { get; set; }
        public Product Product { get; set; }
    }
}