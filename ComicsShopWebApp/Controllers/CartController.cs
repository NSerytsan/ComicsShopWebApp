using ComicsShopWebApp.Models;
using ComicsShopWebApp.ViewModels;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Authorization;
using ComicsShopWebApp.Data;

namespace ComicsShopWebApp.Controllers
{
    public class CartController : Controller
    {
        private readonly ComicsShopDBContext _db;
        private readonly UserManager<User> _userManager;

        public CartController(ComicsShopDBContext db, UserManager<User> userManager)
        {
            _db = db;
            _userManager = userManager;
        }

        [Authorize]
        public async Task<IActionResult> Index()
        {
            var order = await CartOrderAsync();
            var viewModel = new CartViewModel
            {
                Items = order.ProductItems.ToList(),
                Total = order.ProductItems.Sum(item => item.Product.Cost * item.Quantity)
            };
            return View(viewModel);
        }

        [Authorize]
        public async Task<IActionResult> Buy(int id)
        {
            var order = await CartOrderAsync();

            var productItem = order.ProductItems.FirstOrDefault(pi => pi.Product.Id == id);
            if (productItem != null)
            {
                if (productItem.Product.NumLeft > productItem.Quantity)
                {
                    productItem.Quantity++;
                }
            }
            else
            {
                var product = _db.Products.Find(id);
                if (product == null) return NotFound();
                if (product.NumLeft > 0)
                {
                    order.ProductItems.Add(new ProductItem { Product = product, Quantity = 1 });
                }
            }

            _db.SaveChanges();

            return RedirectToAction("Index", "Product");
        }

        [Authorize]
        public async Task<IActionResult> Delete(int id)
        {
            var order = await CartOrderAsync();

            var productItem = order.ProductItems.Where(pi => pi.Product.Id == id).FirstOrDefault();
            if (productItem != null)
            {
                order.ProductItems.Remove(productItem);
                _db.SaveChanges();
            }

            return RedirectToAction("Index", "Cart");
        }

        private async Task<Order> CartOrderAsync()
        {
            var user = await _userManager.GetUserAsync(this.User);
            var order = _db.Orders.Where(o => o.Status.StatusName.Equals("CART") && o.UserId == user.Id).FirstOrDefault();
            if (order == null)
            {
                order = new Order() { UserId = user.Id, StatusId = _db.Statuses.Where(s => s.StatusName.Equals("CART")).First().Id, DeliveryAddress = string.Empty };
                _db.Orders.Add(order);
                _db.SaveChanges();
            }
            return order;
        }
    }
}
