using System.ComponentModel.DataAnnotations;

namespace WebApplication.Commands.Products
{
    public class CreateProductCommand
    {
        [Required]
        public string Name { get; set; }
        [Required]
        public string Description { get; set; }
        [Required]
        public decimal Price { get; set; }
        [Required]
        public decimal Weight { get; set; }
        [Required]
        public int Qty { get; set; }
        
        [Required]
        public int ProducerId { get; set; }
        [Required]
        public int CategoryId { get; set; }
    }
}