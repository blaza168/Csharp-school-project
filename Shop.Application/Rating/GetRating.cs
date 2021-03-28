using System;
using System.Linq;
using System.Linq.Expressions;
using Shop.Application.Rating.ViewModels;
using Shop.Application.Products.ViewModels;
using Shop.Database.Repositories;

namespace Shop.Application.Rating
{
    [Service]
    public class GetRating
    {
        public static readonly Expression<Func<Domain.Models.Rating, RatingViewModel>> RatingMapper = p =>
            new RatingViewModel
            {
                Id = p.Id,
                NumericRating = p.NumericRating,
                Description = p.Description,
                ProductId = p.ProductId,
                Product = p.Product,
            };

        private readonly RatingRepository _ratingRepository;
        
        public GetRating(RatingRepository ratingRepository)
        {
            _ratingRepository = ratingRepository;
        }

        public RatingViewModel Do(int ratingId)
        {
            return _ratingRepository.GetRatingById(ratingId, RatingMapper);
        }
    }
}
