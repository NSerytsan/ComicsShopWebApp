using Microsoft.AspNetCore.Mvc;

namespace ComicsShopWebApp.Controllers
{
    public class AccountController : Controller
    {
        [HttpGet]
        public IActionResult Register()
        {
            return View();
        }
    }
}
