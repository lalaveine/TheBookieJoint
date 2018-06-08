using System;
using Microsoft.AspNetCore.Mvc;
using System.Linq;
using Microsoft.AspNetCore.Authorization;

using TheBookieJoint.Models;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

namespace TheBookieJoint.Controllers {

    [Authorize]
    public class AdminController : Controller {

        private IProductRepository repository;

        public AdminController(IProductRepository repo) {
            repository = repo;
        }

        public async Task<IActionResult> Index(string sortOrder)
        {
            ViewData["IdSortParm"] = String.IsNullOrEmpty(sortOrder) ? "id_desc" : "";
            ViewData["NameSortParm"] = sortOrder == "name" ? "name_desc" : "name";
            ViewData["PriceSortParm"] = sortOrder == "price" ? "price_desc" : "price";

            var products = from p in repository.Products
                        select p;
            switch (sortOrder)
            {
                case "id_desc":
                    products = products.OrderByDescending(p => p.ProductID);
                    break;
                case "name":
                    products = products.OrderBy(p => p.Name);
                    break;
                case "name_desc":
                    products = products.OrderByDescending(p => p.Name);
                    break;
                case "price":
                    products = products.OrderBy(p => p.Price);
                    break;
                case "price_desc":
                    products = products.OrderByDescending(p => p.Price);
                    break;
                default:
                    products = products.OrderBy(p => p.ProductID);
                    break;
            }
            return View(await products.AsNoTracking().ToListAsync());
        }
        
        public ViewResult Edit(int productId) =>
            View(repository.Products
                .FirstOrDefault(p => p.ProductID == productId));

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

        public ViewResult Create() => View("Edit", new Product());

        [HttpPost]
        public IActionResult Delete(int productId) {
            Product deletedProduct = repository.DeleteProduct(productId);
            if (deletedProduct != null) {
                TempData["message"] = $"{deletedProduct.Name} was deleted";
            }
            return RedirectToAction("Index");
        }

    }
}