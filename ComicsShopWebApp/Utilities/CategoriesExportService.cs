using ComicsShopWebApp.Models;
using Microsoft.AspNetCore.Mvc;

namespace ComicsShopWebApp.Utilities
{
    public class CategoriesExportService
    {
        private readonly ICategoriesExporter _exporter;

        public CategoriesExportService(ICategoriesExporter exporter)
        {
            _exporter = exporter;
        }

        public FileContentResult Export(IEnumerable<Category> categories, string fileName)
        {
            return _exporter.exportCategories(categories, fileName);
        }
    }
}