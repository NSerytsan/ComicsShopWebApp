using Microsoft.AspNetCore.Mvc;

namespace ComicsShopWebApp.Controllers
{
	public class ProductListController : Controller
	{
		public IActionResult Index()
		{
			return View();
		}
	}
}
