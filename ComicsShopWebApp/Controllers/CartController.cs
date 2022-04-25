using ComicsShopWebApp.Helpers;
using ComicsShopWebApp.Models;
using Microsoft.AspNetCore.Mvc;

namespace ComicsShopWebApp.Controllers
{
    public class CartController : Controller
    {
        private readonly ComicsShopDBContext _db;

        public CartController(ComicsShopDBContext db)
        {
            _db = db;
        }

        public IActionResult Index()
        {
            var cart = SessionHelper.GetObjectFromJson<List<ProductItem>>(HttpContext.Session, "cart");
            if (cart != null)
            {
                ViewBag.cart = cart;
                ViewBag.total = cart.Sum(item => item.Product.Cost * item.Quantity);
            }

            return View();
        }

        public IActionResult Buy(int id)
        {
            var cart = SessionHelper.GetObjectFromJson<List<ProductItem>>(HttpContext.Session, "cart");
            if (cart == null)
            {
                cart = new List<ProductItem>();
                cart.Add(new ProductItem { Product = _db.Products.Find(id), Quantity = 1 });
                SessionHelper.SetObjectAsJson(HttpContext.Session, "cart", cart);
            }
            else
            {
                int idx = -1;
                for (int i = 0; i < cart.Count; i++)
                {
                    if (cart[i].Product.Id == id)
                    {
                        idx = i;
                        break;
                    }
                }

                if (idx != -1)
                {
                    cart[idx].Quantity++;
                }
                else
                {
                    cart.Add(new ProductItem { Product = _db.Products.Find(id), Quantity = 1 });
                }
                SessionHelper.SetObjectAsJson(HttpContext.Session, "cart", cart);
            }

            return RedirectToAction("Index", "Product");
        }
    }
}
