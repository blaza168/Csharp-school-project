using System.Linq;
using Shop.Application.Producer;
using Shop.Application.Products;
using Shop.Application.Rating;
using Shop.Application.Search.ViewModels;
using Shop.Database.Repositories;

namespace Shop.Application.Search
{
    [Service]
    public class FullTextSearchService
    {
        private readonly ProductRepository _productRepository;
        private readonly ProducerRepository _producerRepository;
        private readonly RatingRepository _ratingRepository;

        public FullTextSearchService(ProductRepository productRepository, ProducerRepository producerRepository, RatingRepository ratingRepository)
        {
            _productRepository = productRepository;
            _producerRepository = producerRepository;
            _ratingRepository = ratingRepository;
        }

        public SearchResultViewModel Do(string text)
        {
            return new SearchResultViewModel
            {
                ProductViewModels = _productRepository.FilterProductsByText(
                    FilterProducts.ModelMapper,
                    text
                ),
                ProducerViewModels = _producerRepository.GetProducers(
                    condition: p => p.Name.Contains(text) || p.Description.Contains(text) || p.Country.Contains(text),
                    selector: ListProducers.ProducerMapper
                ),
                RatingViewModels = _ratingRepository.GetRatings(
                    condition: r => r.Description.Contains(text),
                    selector: ListRatings.RatingMapper)
            };
        }
    }
}