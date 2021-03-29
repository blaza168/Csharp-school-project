using System.Collections.Generic;
using Shop.Application.Producer.ViewModels;
using Shop.Application.Products.ViewModels;
using Shop.Application.Rating.ViewModels;

namespace Shop.Application.Search.ViewModels
{
    public class SearchResultViewModel
    {
        public IEnumerable<ProductViewModel> ProductViewModels { get; set; }
        public IEnumerable<ProducerViewModel> ProducerViewModels { get; set; }
        public IEnumerable<RatingListViewModel> RatingViewModels { get; set; }
    }
}