using System.Threading.Tasks;
using Shop.Application.Products.Requests;
using Shop.Application.Products.ViewModels;
using Shop.Database;
using Shop.Database.Repositories;
using Shop.Domain.Models;

namespace Shop.Application.Products
{
    [Service]
    public class CreateProduct
    {
        private readonly ProductRepository _productRepository;

        public CreateProduct(ProductRepository productRepository)
        {
            _productRepository = productRepository;
        }

        public async Task<int> Do(CreateProductRequest request)
        {
            return await _productRepository.CreateProduct(new Product
            {
                Name = request.Name,
                Description = request.Description,
                Price = request.Price,
                Weight = request.Weight,
                Qty = request.Qty,
                ProducerId = request.ProducerId,
                CategoryId = request.CategoryId,
                //FileId = request.FileId,          //TODO: temporary workaround to prevent SQL from complaining about foreign key when we have no files
            });
        }
    }
}