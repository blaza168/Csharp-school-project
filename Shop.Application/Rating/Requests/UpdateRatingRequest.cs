namespace Shop.Application.Rating.Requests
{
    public class UpdateRatingRequest
    {
        public int Id { get; set; }
        public decimal NumericRating { get; set; }
        public string Description { get; set; }

        public int ProductId { get; set; }
    }
}
