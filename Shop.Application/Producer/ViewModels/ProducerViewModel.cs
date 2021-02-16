using System.Collections.Generic;
using Shop.Application.Products.ViewModels;

namespace Shop.Application.Producer.ViewModels
{
    public class ProducerViewModel
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public string Country { get; set; }
        
        public int FileId { get; set; }

        public ICollection<ProductViewModel> Products { get; set; }
    }
}