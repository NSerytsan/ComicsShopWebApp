using ComicsShopWebApp.Data;
using ComicsShopWebApp.Models;
using ComicsShopWebApp.ViewModels;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

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

        [Authorize]
        [HttpGet]
        public async Task<IActionResult> Index()
        {
            var user = await _userManager.GetUserAsync(this.User);

            var MesssagesList = _db.UserSupports.Include(us => us.User).Where(b => b.UserId == user.Id);
            return View(MesssagesList);
        }

        [HttpGet]
        [Authorize]
        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        [Authorize]
        public async Task<IActionResult> Create(UserSupportViewModel model)
        {
            if (ModelState.IsValid)
            {
                var user = await _userManager.GetUserAsync(this.User);
                var userSupport = new UserSupport
                {
                    UserId = user.Id,
                    User = user,
                    TextMessage = model.TextMessage
                };

                _db.UserSupports.Add(userSupport);
                _db.SaveChanges();
                return RedirectToAction("Index", "Home");
            }
            return View(model);
        }

        [Authorize(Roles = "Admin")]
        public IActionResult ShowAll()
        {
            var MesssagesList = _db.UserSupports.Include(us => us.User);
            return View(MesssagesList);
        }
    }
}
