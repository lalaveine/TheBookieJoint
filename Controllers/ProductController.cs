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
        public ViewResult List(string genre, int productPage = 1) => View(new ProductsListViewModel {
                            Products = repository.Products
                            .Where(p => genre == null || p.Genre == genre)
                                .OrderBy(p => p.ProductID)
                                .Skip((productPage - 1) * PageSize)
                                .Take(PageSize),
                            PagingInfo = new PagingInfo {
                                CurrentPage = productPage,
                                ItemsPerPage = PageSize,
                                TotalItems = genre == null ? repository.Products.Count() : repository.Products.Where(p => p.Genre == genre).Count()
                            },
                            CurrentGenre = genre
        });

        public ViewResult Search(string searchString) => View(new ProductsSearchViewModel {
                            Products = repository.Products
                                .Where(p => p.Name.Contains(searchString.Trim(),  StringComparison.OrdinalIgnoreCase))
                                    .OrderBy(p => p.ProductID)
        });
    }
}