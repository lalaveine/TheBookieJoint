using Microsoft.AspNetCore.Mvc;
using TheBookieJoint.Models;
namespace TheBookieJoint.Controllers {
    public class ProductController : Controller {
        private IProductRepository repository;
        public ProductController(IProductRepository repo) {
            repository = repo;
        }
        public ViewResult List() => View(repository.Products);
    }
}