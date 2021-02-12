using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.Extensions.Logging;
using Shop.Application.Products;
using Shop.Application.Products.Create;
using Shop.Database;

namespace WebApplication.Pages
{
    public class IndexModel : PageModel
    {
        private readonly ILogger<IndexModel> _logger;
        private readonly ApplicationDbContext _context;

        [BindProperty]
        public CreateProductViewModel Product { get; set; }
        
        public IEnumerable<ProductViewModel> Products { get; set; }

        public IndexModel(ILogger<IndexModel> logger, ApplicationDbContext context)
        {
            _logger = logger;
            _context = context;
        }

        public void OnGet()
        {
            this.Products = new GetProducts(_context).Do();
        }

        public async Task<IActionResult> OnPost()
        {
            await new Shop.Application.Products.Create.CreateProduct(_context).Do(new CreateProductViewModel {
                Name = Product.Name, 
                Description = Product.Description, 
                Price = Product.Price, 
                Weight = Product.Weight, 
                Qty = Product.Qty,
                
            });
            
            return RedirectToPage("Index");
        }
    }
}