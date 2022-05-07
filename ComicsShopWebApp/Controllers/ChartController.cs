using ComicsShopWebApp.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace ComicsShopWebApp.Controllers;

[Authorize(Roles = "Admin")]
[Route("api/[controller]")]
[ApiController]
public class ChartController : ControllerBase
{
    private readonly ComicsShopDBContext _db;

    public ChartController(ComicsShopDBContext db)
    {
        _db = db;
    }

    [HttpGet("Categories")]
    public JsonResult Categories()
    {
        List<object> categoriesProducts = new();
        categoriesProducts.Add(new[] { "Категорія", "Кількість товарів" });
        var categories = _db.Categories.Include(c => c.Products);
        foreach (var category in categories)
        {
            categoriesProducts.Add(new object[] { category.CategoryName, category.Products.Count });
        }

        return new JsonResult(categoriesProducts);
    }

    [HttpGet("Products")]
    public JsonResult Products()
    {
        List<object> chartProducts = new();
        chartProducts.Add(new[] { "Товар", "Кількість" });
        var products = _db.Products;
        foreach (var product in products)
        {
            chartProducts.Add(new object[] { product.ProductName, product.NumLeft });
        }

        return new JsonResult(chartProducts);
    }
}
