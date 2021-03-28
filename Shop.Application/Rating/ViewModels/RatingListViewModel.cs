namespace Shop.Application.Rating.ViewModels
{
    public class RatingListViewModel
    {
        public int Id { get; set; }
        public decimal NumericRating { get; set; }
        public string Description { get; set; }

        public int ProductId { get; set; }
    }
}
