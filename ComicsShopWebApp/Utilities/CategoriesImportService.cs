using ComicsShopWebApp.Data;

namespace ComicsShopWebApp.Utilities
{
    public class CategoriesImportService
    {
        private readonly ICategoriesImporter _importer;

        public CategoriesImportService(ICategoriesImporter importer)
        {
            _importer = importer;
        }

        public void Import(FileStream stream, ComicsShopDBContext context)
        {
            _importer.ImportCategories(stream, context);
        }
    }
}