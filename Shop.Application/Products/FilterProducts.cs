using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using Shop.Application.Products.Requests;
using Shop.Application.Products.ViewModels;
using Shop.Database.Repositories;
using Shop.Domain.Models;

namespace Shop.Application.Products
{
    public class FilterProducts
    {
        private static readonly Expression<Func<Product, ProductViewModel>> ModelMapper = p =>
            new ProductViewModel
            {
                Id = p.Id,
                Price = $"$ {p.Price:N2}",
                Description = p.Description,
                Weight = p.Weight
            };
        
        private readonly ProductRepository _productRepository;
        private readonly RatingRepository _ratingRepository;

        public FilterProducts(ProductRepository productRepository, RatingRepository ratingRepository)
        {
            _productRepository = productRepository;
            _ratingRepository = ratingRepository;
        }

        public IEnumerable<ProductViewModel> Do(FilterProductsRequest request)
        {
            if (request.FilterOption == FilterOption.PRICE)
            {
                return _productRepository.GetProductsByPrice(request.MinPrice.GetValueOrDefault(), request.MaxPrice, ModelMapper);
            }
            if (request.FilterOption == FilterOption.STOCK)
            {
                return _productRepository.GetProductsByQuantity(0, ModelMapper);
            }
            if (request.FilterOption == FilterOption.RATING)
            {
                IEnumerable<int> products =
                    _ratingRepository.GetProductIdsByTotalRating(request.MinRating.GetValueOrDefault(), request.MaxRating.GetValueOrDefault(),
                        r => r.ProductId);

                return _productRepository.GetProducts(p => products.Contains(p.Id), ModelMapper);
            }
            if (request.FilterOption == FilterOption.WEIGHT)
            {
                return _productRepository.GetProducts(p => 
                        p.Weight >= request.MinWeight.GetValueOrDefault() && p.Weight <= request.MaxWeight.GetValueOrDefault()
                    , ModelMapper);
            }
            if (request.FilterOption == FilterOption.CATEGORY)
            {
                return _productRepository.GetProducts(p => p.CategoryId == request.CategoryId.GetValueOrDefault(), ModelMapper);
            }
            if (request.FilterOption == FilterOption.PRODUCER)
            {
                return _productRepository.GetProducts(p => p.ProducerId == request.ProducerId.GetValueOrDefault(),
                    ModelMapper);
            }
            
            return new List<ProductViewModel>();
        }
    }
}