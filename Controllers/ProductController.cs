using Microsoft.AspNetCore.Mvc;
using System.Linq;

using TheBookieJoint.Models.ViewModels;

using TheBookieJoint.Models;
using System;

namespace TheBookieJoint.Controllers {
    public class ProductController : Controller {
        private IProductRepository repository;
        public int PageSize = 6;

        public ProductController(IProductRepository repo) {
            repository = repo;
        }
        public ViewResult List(string genre, string searchString, int productPage = 1) {
            ViewData["CurrentFilter"] = searchString;

            var products = repository.Products.Where(p => genre == null || p.Genre == genre)
                                    .OrderBy(p => p.ProductID)
                                    .Skip((productPage - 1) * PageSize)
                                    .Take(PageSize);

            if (!String.IsNullOrEmpty(searchString)) {
                products = repository.Products.Where(p => p.Name.Contains(searchString.Trim() , StringComparison.OrdinalIgnoreCase)
                                            || p.Author.Contains(searchString.Trim() , StringComparison.OrdinalIgnoreCase));
            }

            return View(new ProductsListViewModel {
                            Products = products,
                            PagingInfo = new PagingInfo {
                                CurrentPage = productPage,
                                ItemsPerPage = PageSize,
                                TotalItems = genre == null ? repository.Products.Count() : repository.Products.Where(p => p.Genre == genre).Count()
                            },
                            CurrentGenre = genre
            });
        } 

        [HttpPost]
        public IActionResult Edit(Product product) {
            if (ModelState.IsValid) {
                repository.SaveProduct(product);
                TempData["message"] = $"{product.Name} has been saved";
                return RedirectToAction("Index");
            } else {
                // there is something wrong with the data values
                return View(product);
            }
        }

        public ViewResult Details(int productId) => View(repository.Products
                .FirstOrDefault(p => p.ProductID == productId));

    }
}