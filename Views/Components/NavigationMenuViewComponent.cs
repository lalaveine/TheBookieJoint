using Microsoft.AspNetCore.Mvc;
using System.Linq;

using TheBookieJoint.Models;

namespace TheBookieJoint.Components {
    public class NavigationMenuViewComponent : ViewComponent {
        private IProductRepository repository;

        public NavigationMenuViewComponent(IProductRepository repo) {
            repository = repo;
        }
        public IViewComponentResult Invoke() {
            ViewBag.SelectedGenre = RouteData?.Values["genre"];
            return View(repository.Products
                    .Select(p => p.Genre)
                    .Distinct()
                    .OrderBy(p => p));
        }
    }
}

