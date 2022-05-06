using ComicsShopWebApp.Models;

namespace ComicsShopWebApp.Utilities;

public interface ICategoriesImporter
{
    void ImportCategories(FileStream stream, ComicsShopDBContext context);
}
