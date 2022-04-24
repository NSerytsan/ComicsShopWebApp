using Microsoft.AspNetCore.Mvc;

namespace ComicsShopWebApp.Controllers
{
    public class OrderController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
