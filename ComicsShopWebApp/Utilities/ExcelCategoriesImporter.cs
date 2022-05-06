using ClosedXML.Excel;
using ComicsShopWebApp.Models;

namespace ComicsShopWebApp.Utilities;

public class ExcelCategoriesImporter : ICategoriesImporter
{
    public void ImportCategories(FileStream stream, ComicsShopDBContext context)
    {
        using (XLWorkbook workBook = new XLWorkbook(stream, XLEventTracking.Disabled))
        {
            foreach (IXLWorksheet worksheet in workBook.Worksheets)
            {
                var category = context.Categories.Where(c => c.CategoryName.Equals(worksheet.Name)).SingleOrDefault();
            }
        }
        throw new NotImplementedException();
    }
}
