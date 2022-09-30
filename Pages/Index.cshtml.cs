using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using SqlApp.Models;
using SqlApp.Services;

namespace SqlApp.Pages
{
    public class IndexModel : PageModel
    {
        public List<Product> products;
        public void OnGet()
        {
            products = new List<Product>();
            ProductServices productServices = new ProductServices();
            products = productServices.GetProducts();

        }
    }
}