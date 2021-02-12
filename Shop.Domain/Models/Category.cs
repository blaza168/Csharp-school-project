using System.Collections;
using System.Collections.Generic;

namespace Shop.Domain.Models
{
    public class Category
    {
        public int Id { get; set; }
        public string Name { get; set; }
        
        public ICollection<Product> Producets { get; set; }
    }
}