using ComicsShopWebApp.Models;

namespace ComicsShopWebApp.Utilities
{
    public class CategoriesImportService
    {
        private readonly ICategoriesImporter _importer;

        public CategoriesImportService(ICategoriesImporter importer)
        {
            _importer = importer;
        }

        public void Export(FileStream stream, ComicsShopDBContext context)
        {
            _importer.ImportCategories(stream, context);
        }
    }
}