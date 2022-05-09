using ClosedXML.Excel;
using ComicsShopWebApp.Data;
using Microsoft.EntityFrameworkCore;

namespace ComicsShopWebApp.Utilities;

public class ExcelCategoriesImporter : ICategoriesImporter
{
    public void ImportCategories(FileStream stream, ComicsShopDBContext context)
    {
        using (XLWorkbook workBook = new XLWorkbook(stream, XLEventTracking.Disabled))
        {
            foreach (IXLWorksheet worksheet in workBook.Worksheets)
            {
                var category = context.Categories.Where(c => c.CategoryName.Equals(worksheet.Name)).FirstOrDefault();
                if (category is null)
                {
                    category = new()
                    {
                        CategoryName = worksheet.Name,
                        CategoryDescription = "Завантажено з Excel файлу"
                    };

                    context.Categories.Add(category);
                }

                foreach (var row in worksheet.RowsUsed().Skip(1))
                {
                    var product = context.Products.Include(p => p.Categories)
                    .Where(p => p.ProductName.Equals(row.Cell(1).GetValue<string>())).FirstOrDefault();
                    if (product is null)
                    {
                        product = new()
                        {
                            ProductName = row.Cell(1).GetValue<string>(),
                            Cost = row.Cell(2).GetValue<decimal>(),
                            NumLeft = row.Cell(3).GetValue<int>()
                        };
                        product.Categories.Add(category);
                        context.Products.Add(product);
                    }
                    else
                    {
                        product.NumLeft = row.Cell(3).GetValue<int>();
                        product.Cost = row.Cell(2).GetValue<decimal>();
                        product.Categories.Add(category);
                        context.Update(product);
                    }
                }
                context.SaveChanges();
            }
        }
    }
}
