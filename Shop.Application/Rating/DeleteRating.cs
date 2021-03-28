using Shop.Database.Repositories;
using System.Threading.Tasks;

namespace Shop.Application.Rating
{
    [Service]
    public class DeleteRating
    {
        private readonly RatingRepository _ratingRepository;

        public DeleteRating(RatingRepository ratingRepository)
        {
            _ratingRepository = ratingRepository;
        }

        public Task<int> Do(int ratingId)
        {
            return _ratingRepository.DeleteRating(ratingId);
        }
    }
}
