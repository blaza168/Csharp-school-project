using System;
using System.Linq.Expressions;
using Shop.Application.Products.ViewModels;
using Shop.Database.Repositories;
using Shop.Domain.Models;

namespace Shop.Application.Products
{
    [Service]
    public class GetProduct
    {
        public static readonly Expression<Func<Product, ProductViewModel>> ProductMapper = x => new ProductViewModel
        {
            Id = x.Id,
            Name = x.Name,
            Description = x.Description,
            Price = $"$ {x.Price:N2}",
            Weight = x.Weight,
            Qty = x.Qty,
        };
        
        private readonly ProductRepository _productRepository;

        public GetProduct(ProductRepository productRepository)
        {
            _productRepository = productRepository;
        }

        public ProductViewModel Do(int id)
        {
            return _productRepository.GetProductById(id, ProductMapper);
        }
    }
}