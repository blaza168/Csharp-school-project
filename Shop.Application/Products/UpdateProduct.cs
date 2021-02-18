using System.Threading.Tasks;
using Shop.Application.Products.Requests;
using Shop.Application.Util;
using Shop.Database.Repositories;
using Shop.Domain.Models;

namespace Shop.Application.Products
{
    [Service]
    public class UpdateProduct
    {
        private readonly ProductRepository _productRepository;

        public UpdateProduct(ProductRepository productRepository)
        {
            _productRepository = productRepository;
        }

        public Task<int> Do(UpdateProductRequest request)
        {
            Product product = CopyUtil.CopyAttributes<UpdateProductRequest, Product>(request);
            
            return _productRepository.UpdateProductPartial(product);
        }
    }
}