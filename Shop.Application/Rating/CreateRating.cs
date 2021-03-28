using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using Shop.Application.Rating.Requests;
using Shop.Database.Repositories;

namespace Shop.Application.Rating
{
    [Service]
    public class CreateRating
    {
        private readonly RatingRepository _ratingRepository;
        
        public CreateRating(RatingRepository ratingRepository)
        {
            _ratingRepository = ratingRepository;
        }

        public Task<int> Do(CreateRatingRequest request)
        {
            return _ratingRepository.CreateRating(new Domain.Models.Rating
            {
                NumericRating = request.NumericRating,
                Description = request.Description,
                ProductId = request.ProductId,
            });
        }
    }
}
