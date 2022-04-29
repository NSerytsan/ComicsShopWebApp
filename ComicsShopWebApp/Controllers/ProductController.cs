using ComicsShopWebApp.Models;
using ComicsShopWebApp.ViewModels;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;

namespace ComicsShopWebApp.Controllers
{
    public class ProductController : Controller
    {
        private readonly ComicsShopDBContext _db;

        public ProductController(ComicsShopDBContext db)
        {
            _db = db;
        }
        public IActionResult Index()
        {
            IEnumerable<Product> ProductsList = _db.Products;
            return View(ProductsList);
        }

        [Authorize]
        [HttpGet]
        public IActionResult Create()
        {
            var listItem = _db.Categories.Select(c => new SelectListItem()
            {
                Text = c.CategoryName,
                Value = c.Id.ToString()
            }).ToList();

            var viewModel = new ProductViewModel()
            {
                Categories = listItem
            };

            return View(viewModel);
        }

        [Authorize]
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create(ProductViewModel viewModel)
        {
            if (ModelState.IsValid)
            {
                var product = new Product()
                {
                    ProductName = viewModel.ProductName,
                    Cost = viewModel.Cost,
                    NumLeft = viewModel.NumLeft
                };

                var categoryIds = viewModel.Categories.Where(x => x.Selected).Select(y => y.Value);
                foreach (var catId in categoryIds)
                {
                    var category = _db.Categories.Find(int.Parse(catId));
                    if (category != null)
                    {
                        product.Categories.Add(category);
                    }
                }

                _db.Products.Add(product);
                _db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(viewModel);
        }

        [Authorize]
        public IActionResult Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }
            var product = _db.Products.Find(id);

            if (product == null)
            {
                return NotFound();
            }

            var categoryIds = product.Categories.Select(c => c.Id).ToList();
            var listItem = _db.Categories.Select(c => new SelectListItem()
            {
                Text = c.CategoryName,
                Value = c.Id.ToString(),
                Selected = categoryIds.Contains(c.Id)
            }).ToList();


            var viewModel = new ProductViewModel()
            {
                Id = product.Id,
                ProductName = product.ProductName,
                Cost = product.Cost,
                NumLeft = product.NumLeft,
                Categories = listItem
            };

            return View(viewModel);
        }

        [Authorize]
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Edit(ProductViewModel viewModel)
        {
            if (ModelState.IsValid)
            {
                var product = _db.Products.Find(viewModel.Id);
                if (product != null)
                {
                    product.NumLeft = viewModel.NumLeft;
                    product.ProductName = viewModel.ProductName;
                    product.Cost = viewModel.Cost;

                    var categoryIds = viewModel.Categories.Where(x => x.Selected).Select(y => y.Value);

                    product.Categories.Clear();

                    foreach (var catId in categoryIds)
                    {
                        var category = _db.Categories.FirstOrDefault(c => c.Id == int.Parse(catId));
                        if (category != null)
                        {
                            product.Categories.Add(category);
                        }
                    }

                    _db.Products.Update(product);

                    _db.SaveChanges();
                    return RedirectToAction("Index");
                }
            }

            return View(viewModel);
        }

        [Authorize]
        public IActionResult Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }
            var ProductFromDb = _db.Products.Find(id);

            if (ProductFromDb == null)
            {
                return NotFound();
            }
            return View(ProductFromDb);
        }

        [Authorize]
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public IActionResult DeletePost(int? id)
        {
            var obj = _db.Products.Find(id);
            if (obj == null)
            {
                return NotFound();
            }

            _db.Products.Remove(obj);
            _db.SaveChanges();
            return RedirectToAction("Index");
        }
    }
}
