using System.Collections.Generic;
using Shop.Application.Rating.ViewModels;
using Shop.Database.Repositories;

namespace Shop.Application.Rating
{
    [Service]
    public class ListRatings
    {
        private readonly RatingRepository _ratingRepository;
        
        public ListRatings(RatingRepository ratingRepository)
        {
            _ratingRepository = ratingRepository;
        }

        public IEnumerable<RatingViewModel> Do()
        {
            return _ratingRepository.GetRatings(selector: GetRating.RatingMapper);
        }
    }
}
