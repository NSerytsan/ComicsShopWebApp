using ComicsShopWebApp.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using ComicsShopWebApp.Utilities;
using Microsoft.EntityFrameworkCore;

namespace ComicsShopWebApp.Controllers
{
    [Authorize(Roles = "Admin")]
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

        public IActionResult Create()
        {
            return View();
        }

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

        public IActionResult Edit(int id)
        {
            var category = _db.Categories.Find(id);

            if (category == null)
            {
                return NotFound();
            }
            return View(category);
        }

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

        public IActionResult Import(IFormFile file)
        {
            return RedirectToAction("Index");
        }

        public IActionResult Export()
        {
            var exporter = new CategoriesExportService(new ExcelCategoriesExporter());
            return exporter.Export(_db.Categories.Include(c => c.Products), $"comics_shop_{DateTime.UtcNow.ToShortDateString()}");
        }
    }
}