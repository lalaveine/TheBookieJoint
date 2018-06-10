using System;
using System.Linq;
using Microsoft.AspNetCore.Mvc;

using TheBookieJoint.Models;
using TheBookieJoint.Models.ViewModels;

namespace TheBookieJoint.Controllers {
    public class ProductController : Controller {
        private IProductRepository repository;
        public int PageSize = 5;

        public ProductController(IProductRepository repo) {
            repository = repo;
        }
        public ViewResult List(string genre, string searchString, int productPage = 1) {
            ViewData["CurrentFilter"] = searchString;

            var products = repository.Products.Where(p => genre == null || p.Genre == genre);
                                    

            if (!String.IsNullOrEmpty(searchString)) {
                products = products.Where(p => p.Name.Contains(searchString.Trim() , StringComparison.OrdinalIgnoreCase)
                                            || p.Author.Contains(searchString.Trim() , StringComparison.OrdinalIgnoreCase));
            }

            return View(new ProductsListViewModel {
                            Products = products.OrderBy(p => p.ProductID)
                                            .Skip((productPage - 1) * PageSize)
                                            .Take(PageSize),
                            PagingInfo = new PagingInfo {
                                CurrentPage = productPage,
                                ItemsPerPage = PageSize,
                                TotalItems = products.Count()
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