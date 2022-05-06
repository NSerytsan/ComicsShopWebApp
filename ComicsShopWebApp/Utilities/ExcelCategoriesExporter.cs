using ClosedXML.Excel;
using ComicsShopWebApp.Models;
using Microsoft.AspNetCore.Mvc;

namespace ComicsShopWebApp.Utilities;

public class ExcelCategoriesExporter : ICategoriesExporter
{
    public FileContentResult ExportCategories(IEnumerable<Category> categories, string fileName)
    {
        using (XLWorkbook workbook = new XLWorkbook(XLEventTracking.Disabled))
        {
            foreach (var category in categories)
            {
                var worksheet = workbook.Worksheets.Add(category.CategoryName);
                worksheet.Cell("A1").Value = "Назва продукту";
                worksheet.Cell("B1").Value = "Вартість";
                worksheet.Cell("C1").Value = "Залишилося";
                worksheet.Row(1).Style.Font.Bold = true;

                var products = category.Products.ToList();
                for (int i = 0; i < products.Count; i++)
                {
                    worksheet.Cell(i + 2, 1).Value = products[i].ProductName;
                    worksheet.Cell(i + 2, 2).Value = products[i].Cost;
                    worksheet.Cell(i + 2, 3).Value = products[i].NumLeft;
                }
            }

            using (var stream = new MemoryStream())
            {
                workbook.SaveAs(stream);
                stream.Flush();

                return new FileContentResult(stream.ToArray(), "application/vnd.openxmlformats-officedocument.spreadsheetml.sheet")
                {
                    FileDownloadName = $"{fileName}.xlsx"
                };
            }
        }
    }
}
