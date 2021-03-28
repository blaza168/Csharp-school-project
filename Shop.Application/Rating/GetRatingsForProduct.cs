using Shop.Application.Rating.ViewModels;
using Shop.Database.Repositories;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;

namespace Shop.Application.Rating
{
    [Service]
    public class GetRatingsForProduct
    {
        public static readonly Expression<Func<Domain.Models.Rating, RatingsForProductViewModel>> RatingMapper = p =>
            new RatingsForProductViewModel
            {
                Id = p.Id,
                NumericRating = p.NumericRating,
                Description = p.Description,
            };

        private readonly RatingRepository _ratingRepository;

        public GetRatingsForProduct(RatingRepository ratingRepository)
        {
            _ratingRepository = ratingRepository;
        }

        public IEnumerable<RatingsForProductViewModel> Do(int productId)
        {
            return _ratingRepository.GetRatingsForProduct(productId, RatingMapper);
        }
    }
}
