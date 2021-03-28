using Shop.Domain.Models;

namespace Shop.Application.Rating.Requests
{
    public class CreateRatingRequest
    {
        public decimal NumericRating { get; set; }
        public string Description { get; set; }

        public int ProductId { get; set; }
    }
}
