using ComicsShopWebApp.Models;
using Microsoft.AspNetCore.Mvc;

namespace ComicsShopWebApp.Controllers
{
    public class CategoryController : Controller
    {
        private readonly ComicsShopDBContext _db;

        public CategoryController(ComicsShopDBContext db)
        {
            _db = db;
        }

        public IActionResult Index()
        {
            IEnumerable<Category> CategoryList = _db.Categories;
            return View(CategoryList);
        }
    }
}
