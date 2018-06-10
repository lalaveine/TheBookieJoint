using System;
using System.Linq;

using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Authorization;

using TheBookieJoint.Models;
using TheBookieJoint.Models.ViewModels;

namespace TheBookieJoint.Controllers {

    public class OrderController : Controller {
        private IOrderRepository repository;

        private Cart cart;

        public int PageSize = 5;

        public OrderController(IOrderRepository repoService, Cart cartService) {
            repository = repoService;
            cart = cartService;
        }

        [Authorize]
        public IActionResult List(string sortOrder, string searchString, int productPage = 1) {
            ViewData["IdSortParm"] = String.IsNullOrEmpty(sortOrder) ? "id_desc" : "";
            ViewData["ShippedSortParm"] = sortOrder == "shipped" ? "shipped_desc" : "shipped";
            ViewData["NameSortParm"] = sortOrder == "name" ? "name_desc" : "name";
            ViewData["PostalCodeSortParm"] = sortOrder == "postalCode" ? "postalCode_desc" : "postalCode";

            var orders = repository.Orders;

            if (!String.IsNullOrEmpty(searchString))
            {
                orders = orders.Where(o => o.PostalCode.ToString().Contains(searchString.Trim() , StringComparison.OrdinalIgnoreCase)
                                            || o.Name.Contains(searchString.Trim() , StringComparison.OrdinalIgnoreCase));
            }

            switch (sortOrder)
            {
                case "id_desc":
                    orders = orders.OrderByDescending(o => o.OrderID);
                    break;
                case "shipped":
                    orders = orders.OrderBy(p => p.Name);
                    break;
                case "shipped_desc":
                    orders = orders.OrderByDescending(o => o.Name);
                    break;
                case "name":
                    orders = orders.OrderBy(p => p.Name);
                    break;
                case "name_desc":
                    orders = orders.OrderByDescending(o => o.Name);
                    break;
                case "postalCode":
                    orders = orders.OrderBy(o => o.PostalCode);
                    break;
                case "postalCode_desc":
                    orders = orders.OrderByDescending(o => o.PostalCode);
                    break;
                default:
                    orders = orders.OrderBy(o => o.OrderID);
                    break;
            }

            return View(new OrderListViewModel {
                            Orders = orders.Skip((productPage - 1) * PageSize).Take(PageSize),
                            PagingInfo = new PagingInfo {
                                CurrentPage = productPage,
                                ItemsPerPage = PageSize,
                                TotalItems = orders.Count()
                            },
                            CurrentSortOrder = sortOrder,
                            SearchString = searchString
            });
        }
        
        [HttpPost]
        [Authorize]
        public IActionResult MarkShipped(int orderID) {
            Order order = repository.Orders.FirstOrDefault(o => o.OrderID == orderID);
            if (order != null) {
                order.Shipped = true;
                repository.SaveOrder(order);
            }
            return RedirectToAction(nameof(List));
        }

        public ViewResult Checkout() => View(new Order());

        [HttpPost]
        public IActionResult Checkout(Order order) {
            if (cart.Lines.Count() == 0) {
                ModelState.AddModelError("", "Извините, ваша корзина пуста!");
            }
            if (ModelState.IsValid) {
                order.Lines = cart.Lines.ToArray();
                repository.SaveOrder(order);
                return RedirectToAction(nameof(Completed));
            } else {
                return View(order);
            }
        }

        public ViewResult Completed() {
            cart.Clear();
            return View();
        }
    }
}

