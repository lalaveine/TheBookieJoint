using System.Linq;
using Microsoft.AspNetCore.Mvc;

using TheBookieJoint.Models;
using TheBookieJoint.Models.ViewModels;

namespace TheBookieJoint.Controllers {
    public class CartController : Controller {
        private IProductRepository repository;
        private Cart cart;
        public CartController(IProductRepository repo, Cart cartService) {
            repository = repo;
            cart = cartService;
        }
        public ViewResult Index(string returnUrl) {
            return View(new CartIndexViewModel {
                Cart = cart,
                ReturnUrl = returnUrl
            });
        }

        public RedirectToActionResult AddToCart(int productId, string returnUrl) {
            Product product = repository.Products.FirstOrDefault(p => p.ProductID == productId);
            if (product != null) {
                if (cart.Lines.Where(l => l.Product.ProductID == product.ProductID).Count() == product.NumberOfCopies){
                    TempData["message"] = $"Эта книга не может быть добавлена в корзину.";
                } else {
                    cart.AddItem(product, 1);
                }                
            }
            return RedirectToAction("Index", new { returnUrl });
        }
        public RedirectToActionResult RemoveFromCart(int productId, string returnUrl) {
            Product product = repository.Products.FirstOrDefault(p => p.ProductID == productId);
            if (product != null) {
                cart.RemoveLine(product);
            }
            return RedirectToAction("Index", new { returnUrl });
        }
    }
}
