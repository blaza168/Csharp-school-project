using System.Threading.Tasks;
using Shop.Database.Repositories;

namespace Shop.Application.Products
{
    [Service]
    public class DeleteProduct
    {
        private readonly ProductRepository _productRepository;

        public DeleteProduct(ProductRepository productRepository)
        {
            _productRepository = productRepository;
        }

        public Task<int> Do(int productId)
        {
            return _productRepository.DeleteProduct(productId);
        }
    }
}