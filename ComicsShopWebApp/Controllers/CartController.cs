using Microsoft.AspNetCore.Mvc;

namespace ComicsShopWebApp.Controllers
{
    public class CartController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Buy(int id)
        {
            return RedirectToAction("Index", "Cart");
        }
    }
}
