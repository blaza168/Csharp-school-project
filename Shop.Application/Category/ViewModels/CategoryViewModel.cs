using Shop.Domain.Models;
using System.Collections.Generic;

namespace Shop.Application.Category.ViewModels
{
    public class CategoryViewModel
    {
        public int Id { get; set; }
        public string Name { get; set; }

        public ICollection<Product> Producers { get; set; }
    }
}
