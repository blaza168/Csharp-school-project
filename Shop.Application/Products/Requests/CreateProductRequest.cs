using Microsoft.AspNetCore.Http;
using Shop.Application.Files.Requests;

namespace Shop.Application.Products.Requests
{
    public class CreateProductRequest
    {
        public string Name { get; set; }
        public string Description { get; set; }
        public decimal Price { get; set; }
        public decimal Weight { get; set; }
        public int Qty { get; set; }
        
        public int ProducerId { get; set; }
        public int CategoryId { get; set; }
        public int FileId { get; set; }
    }
}