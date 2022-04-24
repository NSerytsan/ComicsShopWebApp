using ComicsShopWebApp.Models;
using ComicsShopWebApp.ViewModels;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

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
		public async Task<IActionResult> IndexAsync()
		{
			var user = await _userManager.GetUserAsync(this.User);

			IEnumerable<UserSupport> MesssagesList = _db.UserSupports.Where(b => b.UserId == user.Id);
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
	}
}
