using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using Shop.Application.Rating.ViewModels;
using Shop.Database.Repositories;

namespace Shop.Application.Rating
{
    [Service]
    public class ListRatings
    {
        public static readonly Expression<Func<Domain.Models.Rating, RatingListViewModel>> RatingMapper = p =>
            new RatingListViewModel
            {
                Id = p.Id,
                NumericRating = p.NumericRating,
                Description = p.Description,
                ProductId = p.ProductId,
            };

        private readonly RatingRepository _ratingRepository;
        
        public ListRatings(RatingRepository ratingRepository)
        {
            _ratingRepository = ratingRepository;
        }

        public IEnumerable<RatingListViewModel> Do()
        {
            return _ratingRepository.GetRatings(selector: RatingMapper);
        }
    }
}
