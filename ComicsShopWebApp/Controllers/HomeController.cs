using ComicsShopWebApp.Models;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;

namespace ComicsShopWebApp.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly ComicsShopDBContext _db;

        public HomeController(ILogger<HomeController> logger, ComicsShopDBContext db)
        {
            _logger = logger;
            _db = db;
        }

        public IActionResult Index()
        {
            IEnumerable<Product> ProductsList = _db.Products ;
            return View(ProductsList);
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}