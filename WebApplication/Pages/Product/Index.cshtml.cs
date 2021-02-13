using System.Collections;
using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Shop.Application.Products;
using Shop.Application.Products.ViewModels;
using WebApplication.Commands.Products;

namespace WebApplication.Pages.Product
{
    public class Index : PageModel
    {
        [BindProperty]
        public FilterProductsCommand Command { get; set; }
        public IEnumerable<ProductViewModel> products { get; set; }
        
        public void OnGet([FromServices] GetProducts getProducts)
        {
            products = getProducts.Do();
        }
    }
}