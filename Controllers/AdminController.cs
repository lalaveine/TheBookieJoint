using System;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Authorization;
using Microsoft.EntityFrameworkCore;

using TheBookieJoint.Models;

namespace TheBookieJoint.Controllers {

    [Authorize]
    public class AdminController : Controller {

        private IProductRepository repository;
        IHostingEnvironment appEnvironment;

        public AdminController(IProductRepository repo, IHostingEnvironment appEnv) {
            repository = repo;
            appEnvironment = appEnv;
        }

        public async Task<IActionResult> Index(string sortOrder, string searchString)
        {
            ViewData["IdSortParm"] = String.IsNullOrEmpty(sortOrder) ? "id_desc" : "";
            ViewData["NameSortParm"] = sortOrder == "name" ? "name_desc" : "name";
            ViewData["AuthorSortParm"] = sortOrder == "author" ? "author_desc" : "author";
            ViewData["LanguageSortParm"] = sortOrder == "language" ? "language_desc" : "language";
            ViewData["GenreSortParm"] = sortOrder == "genre" ? "genre_desc" : "genre";
            ViewData["PublisherSortParm"] = sortOrder == "publisher" ? "publisher_desc" : "publisher";
            ViewData["PriceSortParm"] = sortOrder == "price" ? "price_desc" : "price";

            ViewData["CurrentFilter"] = searchString;

            var products = repository.Products;

            if (!String.IsNullOrEmpty(searchString))
            {
                products = products.Where(p => p.ProductID.ToString().Contains(searchString.Trim() , StringComparison.OrdinalIgnoreCase)
                                            || p.Name.Contains(searchString.Trim() , StringComparison.OrdinalIgnoreCase)
                                            || p.Author.Contains(searchString.Trim() , StringComparison.OrdinalIgnoreCase)
                                            || p.Language.Contains(searchString.Trim() , StringComparison.OrdinalIgnoreCase)
                                            || p.Genre.Contains(searchString.Trim() , StringComparison.OrdinalIgnoreCase)
                                            || p.Publisher.Contains(searchString.Trim() , StringComparison.OrdinalIgnoreCase)
                                            || p.Price.ToString().Contains(searchString.Trim() , StringComparison.OrdinalIgnoreCase));
            }

            ViewData["IdSort"] = "false";
            ViewData["IdDescSort"] = "false";
            ViewData["NameSort"] = "false";
            ViewData["NameDescSort"] = "false";
            ViewData["AuthorSort"] = "false";
            ViewData["AuthorDescSort"] = "false";
            ViewData["LanguageSort"] = "false";
            ViewData["LanguageDescSort"] = "false";
            ViewData["GenreSort"] = "false";
            ViewData["GenreDescSort"] = "false";
            ViewData["PublisherSort"] = "false";
            ViewData["PublisherDescSort"] = "false";
            ViewData["PriceSort"] = "false";
            ViewData["PriceDescSort"] = "false";

            switch (sortOrder)
            {
                case "id_desc":
                    products = products.OrderByDescending(p => p.ProductID);
                    ViewData["IdDescSort"] = "true";
                    break;
                case "name":
                    products = products.OrderBy(p => p.Name);
                    ViewData["NameSort"] = "true";
                    break;
                case "name_desc":
                    products = products.OrderByDescending(p => p.Name);
                    ViewData["NameDescSort"] = "true";
                    break;
                case "author":
                    products = products.OrderBy(p => p.Author);
                    ViewData["AuthorSort"] = "true";
                    break;
                case "author_desc":
                    products = products.OrderByDescending(p => p.Author);
                    ViewData["AuthorDescSort"] = "true";
                    break;
                case "language":
                    products = products.OrderBy(p => p.Language);
                    ViewData["LanguageSort"] = "true";
                    break;
                case "language_desc":
                    products = products.OrderByDescending(p => p.Language);
                    ViewData["LanguageDescSort"] = "true";
                    break;
                case "genre":
                    products = products.OrderBy(p => p.Genre);
                    ViewData["GenreSort"] = "true";
                    break;
                case "genre_desc":
                    products = products.OrderByDescending(p => p.Genre);
                    ViewData["GenreDescSort"] = "true";
                    break;
                case "publisher":
                    products = products.OrderBy(p => p.Publisher);
                    ViewData["PublisherSort"] = "true";
                    break;
                case "publisher_desc":
                    products = products.OrderByDescending(p => p.Publisher);
                    ViewData["PublisherDescSort"] = "true";
                    break;
                case "price":
                    products = products.OrderBy(p => p.Price);
                    ViewData["PriceSort"] = "true";
                    break;
                case "price_desc":
                    products = products.OrderByDescending(p => p.Price);
                    ViewData["PriceDescSort"] = "true";
                    break;
                default:
                    products = products.OrderBy(p => p.ProductID);
                    ViewData["IdSort"] = "true";
                    break;
            }
            return View(await products.AsNoTracking().ToListAsync());
        }
        
        public ViewResult Edit(int productId) => View(repository.Products.FirstOrDefault(p => p.ProductID == productId));

        [HttpPost]
        public async Task<IActionResult> Edit(Product product) {
            // string path = "/images/books/default.png";
            // if (files.Count != 0)
            // {
            //     var img = files[0];
            //     path = "/images/books/" + img.FileName;

            //     using (var fileStream = new FileStream(appEnvironment.WebRootPath + path, FileMode.Create))
            //     {
            //         await img.CopyToAsync(fileStream);
            //     }
            // }
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