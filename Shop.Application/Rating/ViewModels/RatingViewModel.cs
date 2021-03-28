using Shop.Domain.Models;

namespace Shop.Application.Rating.ViewModels
{
    public class RatingViewModel
    {
        public int Id { get; set; }
        public decimal NumericRating { get; set; }
        public string Description { get; set; }

        public int ProductId { get; set; }
        public Product Product { get; set; }
    }
}
