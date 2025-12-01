using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using StoreApp.Data.Abstract;
using StoreApp.Web.Models;

namespace StoreApp.Web.Pages
{
    public class CartModel : PageModel
    {
        private IStoreRepsository _repository;
        public CartModel(IStoreRepsository repsository, Cart cartService)
        {
            _repository = repsository;
            Cart = cartService;
        }

        public Cart? Cart { get; set; }
        public void OnGet()
        {
        }

        public IActionResult OnPost(int Id)
        {
            var product = _repository.Products.FirstOrDefault(i => i.Id == Id);

            if(product != null)
            {
                Cart?.AddItem(product, 1);
            }

            return RedirectToPage("/Cart");
        }

        public IActionResult OnPostRemove(int Id)
        {
            Cart?.RemoveItem(Cart.Items.First(p => p.Product.Id == Id).Product);
            return RedirectToPage("/Cart");
        }
    }
}
