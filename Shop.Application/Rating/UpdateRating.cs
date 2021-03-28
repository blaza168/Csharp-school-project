using Shop.Application.Rating.Requests;
using Shop.Application.Util;
using Shop.Database.Repositories;
using System.Threading.Tasks;

namespace Shop.Application.Rating
{
    [Service]
    public class UpdateRating
    {
        private readonly RatingRepository _ratingRepository;

        public UpdateRating(RatingRepository ratingRepository)
        {
            _ratingRepository = ratingRepository;
        }

        public Task<int> Do(UpdateRatingRequest request)
        {
            Domain.Models.Rating rating = CopyUtil.CopyAttributes<UpdateRatingRequest, Domain.Models.Rating>(request);

            return _ratingRepository.UpdateRatingPartial(rating);
        }
    }
}
