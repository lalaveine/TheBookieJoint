using System;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Authorization;
using Microsoft.EntityFrameworkCore;

using TheBookieJoint.Models;
using TheBookieJoint.Models.ViewModels;
using Microsoft.AspNetCore.Http;

namespace TheBookieJoint.Controllers {

    [Authorize]
    public class AdminController : Controller {

        private IProductRepository repository;
        IHostingEnvironment appEnvironment;

        public int PageSize = 10;

        public AdminController(IProductRepository repo, IHostingEnvironment appEnv) {
            repository = repo;
            appEnvironment = appEnv;
        }
      
        public IActionResult Index(string sortOrder, string searchString, int productPage = 1)
        {
            ViewData["IdSortParm"] = String.IsNullOrEmpty(sortOrder) ? "id_desc" : "";
            ViewData["NameSortParm"] = sortOrder == "name" ? "name_desc" : "name";
            ViewData["AuthorSortParm"] = sortOrder == "author" ? "author_desc" : "author";
            ViewData["LanguageSortParm"] = sortOrder == "language" ? "language_desc" : "language";
            ViewData["GenreSortParm"] = sortOrder == "genre" ? "genre_desc" : "genre";
            ViewData["PublisherSortParm"] = sortOrder == "publisher" ? "publisher_desc" : "publisher";
            ViewData["PriceSortParm"] = sortOrder == "price" ? "price_desc" : "price";

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
                case "author":
                    products = products.OrderBy(p => p.Author);
                    break;
                case "author_desc":
                    products = products.OrderByDescending(p => p.Author);
                    break;
                case "language":
                    products = products.OrderBy(p => p.Language);
                    break;
                case "language_desc":
                    products = products.OrderByDescending(p => p.Language);
                    break;
                case "genre":
                    products = products.OrderBy(p => p.Genre);
                    break;
                case "genre_desc":
                    products = products.OrderByDescending(p => p.Genre);
                    break;
                case "publisher":
                    products = products.OrderBy(p => p.Publisher);
                    break;
                case "publisher_desc":
                    products = products.OrderByDescending(p => p.Publisher);
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

            return View(new AdminIndexViewModel {
                            Products = products.Skip((productPage - 1) * PageSize).Take(PageSize),
                            PagingInfo = new PagingInfo {
                                CurrentPage = productPage,
                                ItemsPerPage = PageSize,
                                TotalItems = products.Count()
                            },
                            CurrentSortOrder = sortOrder,
                            SearchString = searchString
            });
        }
        
        public ViewResult Edit(int productId) => View(repository.Products.FirstOrDefault(p => p.ProductID == productId));

        [HttpPost]
        public async Task<IActionResult> Edit(Product product, IFormFile cover) {
            if (ModelState.IsValid) {
                if (cover != null)
                {
                    // Поменять задание имени на имя-автора-название-id
                    product.CoverImgPath = String.Format("/images/covers/{0}-{1}-{2}{3}", product.Author, product.Name, product.ProductID, Path.GetExtension(cover.FileName)).Replace(" ", "-").ToLower();

                    using (var fileStream = new FileStream(appEnvironment.WebRootPath + product.CoverImgPath, FileMode.Create))
                    {
                        await cover.CopyToAsync(fileStream);
                    }
                }
                if (product.CoverImgPath == null) {
                    product.CoverImgPath = "";
                }
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