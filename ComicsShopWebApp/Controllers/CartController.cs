using ComicsShopWebApp.Models;
using ComicsShopWebApp.ViewModels;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

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

        public async Task<IActionResult> Index()
        {
            var viewModel = new CartViewModel();
            var order = await CartOrderAysnc();
            viewModel.Items = order.ProductItems.ToList();
            viewModel.Total = order.ProductItems.Sum(item => item.Product.Cost * item.Quantity);
            return View(viewModel);
        }

        public async Task<IActionResult> Buy(int id)
        {
            var order = await CartOrderAysnc();

            var productItem = order.ProductItems.Where(pi => pi.Id == id).FirstOrDefault();
            if (productItem != null)
            {
                productItem.Quantity++;
            }
            else
            {
                order.ProductItems.Add(new ProductItem { Product = _db.Products.Find(id), Quantity = 1 });
            }

            _db.SaveChanges();

            return RedirectToAction("Index", "Product");
        }

        private async Task<Order> CartOrderAysnc()
        {
            var user = await _userManager.GetUserAsync(this.User);
            var order = _db.Orders.Where(o => o.Status.StatusName.Equals("CART") && o.UserId == user.Id).FirstOrDefault();
            if (order == null)
            {
                order = new Order() { UserId = user.Id, StatusId = _db.Statuses.Where(s => s.StatusName.Equals("CART")).First().Id, DeliveryAdress = "CART" };
                _db.Orders.Add(order);
                _db.SaveChanges();
            }
            return order;
        }
    }
}
