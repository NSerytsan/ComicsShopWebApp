using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Authorization;
using ComicsShopWebApp.ViewModels;
using ComicsShopWebApp.Models;

namespace ComicsShopWebApp.Controllers
{
    public class OrderController : Controller
    {
        private readonly ComicsShopDBContext _db;
        private readonly UserManager<User> _userManager;
        public OrderController(ComicsShopDBContext db, UserManager<User> userManager)
        {
            _db = db;
            _userManager = userManager;
        }

        public IActionResult Index()
        {
            return View();
        }

        [Authorize]
        [HttpGet]
        public async Task<IActionResult> Create()
        {
            var user = await _userManager.GetUserAsync(this.User);
            var order = _db.Orders.Where(o => o.Status.StatusName.Equals("CART") && o.UserId == user.Id).FirstOrDefault();
            
            if (order == null) return NotFound();
            
            var viewModel = new OrderViewModel()
            {
                Items = order.ProductItems.ToList(),
                Total = order.ProductItems.Sum(item => item.Product.Cost * item.Quantity),
                DeliveryAddress = user.DefaultDeliveryAddress ?? string.Empty
            };

            return View(viewModel);
        }

        [Authorize]
        [HttpPost]
        public async Task<IActionResult> Create(OrderViewModel viewModel)
        {
            if (ModelState.IsValid)
            {
                var user = await _userManager.GetUserAsync(this.User);
                var order = _db.Orders.Where(o => o.Status.StatusName.Equals("CART") && o.UserId == user.Id).FirstOrDefault();
                if (order == null) return NotFound();

                order.DeliveryAddress = viewModel.DeliveryAddress;
                order.StatusId = _db.Statuses.Where(s => s.StatusName.Equals("Новий")).First().Id;
                order.OrderDate = DateTime.Now;
                order.Cost = order.ProductItems.Sum(item => item.Product.Cost * item.Quantity);

                _db.Update(order);
                _db.SaveChanges();

                return RedirectToAction("Index", "Product");
            }
 
            return await Create();
        }
    }
}