using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using Shop.Application.Products.Requests;

namespace WebApplication.Commands.Products
{
    public class FilterProductsCommand : IValidatableObject
    {
        [Required]
        public FilterOption FilterOption { get; set; }
        
        // price
        public decimal? MaxPrice { get; set; }
        public decimal? MinPrice { get; set; }
        
        // weight
        public decimal? MaxWeight { get; set; }
        public decimal? MinWeight { get; set; }
        
        // category
        public int? CategoryId { get; set; }
        
        // producer
        public int? ProducerId { get; set; }

        // Rating
        public decimal? MaxRating { get; set; }
        public decimal? MinRating { get; set; }
        
        public IEnumerable<ValidationResult> Validate(ValidationContext validationContext)
        {
            // Price
            if (this.FilterOption == FilterOption.PRICE && MinPrice == null)
            {
                yield return new ValidationResult("MinPrice not specified");
            }
            
            // category
            if (this.FilterOption == FilterOption.CATEGORY && CategoryId == null)
            {
                yield return new ValidationResult("CategoryId not specified");
            }
            
            // Weight
            if (this.FilterOption == FilterOption.WEIGHT && MinWeight == null)
            {
                yield return new ValidationResult("MinWeight not specified");
            }

            // Producer
            if (this.FilterOption == FilterOption.PRODUCER && ProducerId == null)
            {
                yield return new ValidationResult("Producer not specified");
            }
            
            // Rating
            if (this.FilterOption == FilterOption.RATING && (MinRating == null || MaxRating == null))
            {
                yield return new ValidationResult("Rating range not specified");
            }
        }
    }
}