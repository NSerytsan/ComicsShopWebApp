using ComicsShopWebApp.Models;
using ComicsShopWebApp.ViewModels;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;

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
                    var productCat = new ProductCategory()
                    {
                        CategoryId = int.Parse(catId),
                        ProductId = viewModel.Id
                    };
                    product.ProductCategories.Add(productCat);
                }

                _db.Products.Add(product);
                _db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(viewModel);
        }

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

            var categoryIds = _db.ProductCategories.Where(p => p.ProductId == product.Id).Select(c => c.CategoryId).ToList();
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

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Edit(ProductViewModel viewModel)
        {
            if (ModelState.IsValid)
            {
                var product = _db.Products.Find(viewModel.Id);
                product.NumLeft = viewModel.NumLeft;
                product.ProductName = viewModel.ProductName;
                product.Cost = viewModel.Cost;

                var categoryIds = viewModel.Categories.Where(x => x.Selected).Select(y => y.Value);

                _db.ProductCategories.RemoveRange(_db.ProductCategories.Where(pc => pc.ProductId == product.Id));

                foreach (var catId in categoryIds)
                {
                    var productCat = new ProductCategory()
                    {
                        CategoryId = int.Parse(catId),
                        ProductId = product.Id
                    };
                    product.ProductCategories.Add(productCat);
                }

                _db.Products.Update(product);

                _db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(viewModel);
        }

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
