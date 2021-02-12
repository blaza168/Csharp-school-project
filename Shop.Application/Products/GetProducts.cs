using System.Collections.Generic;
using System.Linq;
using Shop.Database;

namespace Shop.Application.Products
{
    public class GetProducts
    {
        private readonly ApplicationDbContext _context;

        public GetProducts(ApplicationDbContext context)
        {
            _context = context;
        }

        public IEnumerable<ProductViewModel> Do() =>_context.Products.ToList().Select(x => new ProductViewModel
            {
                Name = x.Name,
                Description = x.Description,
                Price = $"$ {x.Price:N2}",
                Weight = x.Weight,
                Qty = x.Qty,
            });
    }
    
    public class ProductViewModel
    {
        public string Name { get; set; }
        public string Description { get; set; }
        public string Price { get; set; }
        public decimal Weight { get; set; }
        public int Qty { get; set; }
    }
}