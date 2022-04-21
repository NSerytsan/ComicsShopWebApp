using ComicsShopWebApp.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;

namespace ComicsShopWebApp.Controllers
{
    public class UserSupportController : Controller
    {
        private readonly ComicsShopDBContext _db;
        private readonly UserManager<User> _userManager;

        public UserSupportController(ComicsShopDBContext db, UserManager<User> userManager)
        {
            _db = db;
            _userManager = userManager;
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
        public async Task<IActionResult> Create(UserSupport model)
        {
            var userId = this.User.FindFirstValue(ClaimTypes.NameIdentifier);
            model.UserId = userId;
            model.User = await _userManager.GetUserAsync(this.User);
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
