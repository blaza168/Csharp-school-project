using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Shop.Application.Products;

namespace WebApplication.Pages.Product
{
    public class Create : PageModel
    {
        public void OnGet()
        {
            
        }

        public void OnPost([FromServices] CreateProduct createProduct)
        {
            
        }
    }
}