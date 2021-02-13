using System.Collections.Generic;
using System.Linq;
using Shop.Application.Products.ViewModels;
using Shop.Database;
using Shop.Database.Repositories;

namespace Shop.Application.Products
{
    public class GetProducts
    {
        private readonly ProductRepository _productRepository;

        public GetProducts(ProductRepository productRepository)
        {
            _productRepository = productRepository;
        }

        public IEnumerable<ProductViewModel> Do()
        {
            return _productRepository.GetProducts(x => new ProductViewModel {
                Id = x.Id,
                Name = x.Name,
                Description = x.Description,
                Price = $"$ {x.Price:N2}",
                Weight = x.Weight,
                Qty = x.Qty,
            });
        }
    }
}