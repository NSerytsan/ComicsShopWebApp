using ComicsShopWebApp.Models;
using Microsoft.AspNetCore.Authorization;
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
            var categories = _db.Categories;
            return View(categories);
        }

        [Authorize]
        public IActionResult Create()
        {
            return View();
        }

        [Authorize]
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create(Category category)
        {
            if (ModelState.IsValid)
            {
                _db.Categories.Add(category);
                _db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(category);
        }

        [Authorize]
        public IActionResult Edit(int id)
        {
            var category = _db.Categories.Find(id);

            if (category == null)
            {
                return NotFound();
            }
            return View(category);
        }

        [Authorize]
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Edit(Category category)
        {
            if (ModelState.IsValid)
            {
                _db.Categories.Update(category);
                _db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(category);
        }

        [Authorize]
        public IActionResult Delete(int id)
        {
            var category = _db.Categories.Find(id);

            if (category == null)
            {
                return NotFound();
            }
            
            _db.Entry(category).Collection(p => p.Products).Load();
            return View(category);
        }

        [Authorize]
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public IActionResult DeletePost(int id)
        {
            var category = _db.Categories.Find(id);
            if (category == null)
            {
                return NotFound();
            }

            _db.Categories.Remove(category);
            _db.SaveChanges();
            return RedirectToAction("Index");
        }
    }
}
