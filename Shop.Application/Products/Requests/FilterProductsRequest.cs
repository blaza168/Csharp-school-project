namespace Shop.Application.Products.Requests
{
    public class FilterProductsRequest
    {
        public FilterOption FilterOption { get; set; }
        public decimal? MaxPrice { get; set; }
        public decimal? MinPrice { get; set; }
        public decimal? MaxWeight { get; set; }
        public decimal? MinWeight { get; set; }
        public int? CategoryId { get; set; }
        public int? ProducerId { get; set; }
        public decimal? MaxRating { get; set; }
        public decimal? MinRating { get; set; }
    }
}