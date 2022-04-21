using ComicsShopWebApp.Models;
using Microsoft.AspNetCore.Mvc;

namespace ComicsShopWebApp.Controllers
{
    public class UserSupportController : Controller
    {
        private readonly ComicsShopDBContext _db;

        public UserSupportController(ComicsShopDBContext db)
        {
            _db = db;
        }
        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Create() 
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create(UserSupport model)
        {
            if (ModelState.IsValid)
            {
                _db.UserSupports.Add(model);
                _db.SaveChanges();
                return RedirectToAction("Index", "Home");
            }
            return View(model);
        }
    }
}
