using ComicsShopWebApp.Models;
using Microsoft.AspNetCore.Mvc;

namespace ComicsShopWebApp.Utilities
{
    public interface ICategoriesExporter
    {
        FileContentResult exportCategories(IEnumerable<Category> categories, string fileName);
    }
}