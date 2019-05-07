using System;
using System.Collections.Generic;
using System.Data;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CouchBaseCaching;
using OfficeOpenXml;
using WWI;

namespace ExcelIntegration
{
    class Program
    {
        static void Main(string[] args)
        {
            ReadFromExcel();
            //CreateExcelFile();
        }

        private static void CreateExcelFile()
        {
            WWIModel wwi = new WWIModel();
            var ct = wwi.CustomerTransactions.Select(c => new ThisCustomer
            {
                CustomerId = c.CustomerID,
                CustomerName = wwi.Customers.FirstOrDefault(cus => cus.CustomerID == c.CustomerID).CustomerName,
                Amount = c.TransactionAmount,
                InvoiceId = c.InvoiceID,
                InvoiceDate = c.TransactionDate
            }).ToList();

            using (ExcelPackage package = new ExcelPackage(new FileInfo("MyExcelFile.xlsx")))
            {
                ExcelWorksheet worksheet = package.Workbook.Worksheets.Add("Hugin");

                worksheet.Cells["A1"].LoadFromCollection(ct, true, OfficeOpenXml.Table.TableStyles.Medium2);
                worksheet.Column(5).Style.Numberformat.Format = "dd/MM/yyyy HH:mm:ss";
                worksheet.Cells.AutoFitColumns();

                package.Save();
            }
        }

        public static void ReadFromExcel()
        {
            //create a list to hold all the values
            List<string> excelData = new List<string>();

            //read the Excel file as byte array
            byte[] bin = File.ReadAllBytes("F:\\ReadExcel.xlsx");

            //create a new Excel package in a memorystream
            using (MemoryStream stream = new MemoryStream(bin))
            using (ExcelPackage excelPackage = new ExcelPackage(stream))
            {
                //loop all worksheets
                foreach (ExcelWorksheet worksheet in excelPackage.Workbook.Worksheets)
                {
                    //loop all rows
                    for (int i = worksheet.Dimension.Start.Row; i <= worksheet.Dimension.End.Row; i++)
                    {
                        //loop all columns in a row
                        for (int j = worksheet.Dimension.Start.Column; j <= worksheet.Dimension.End.Column; j++)
                        {
                            //add the cell data to the List
                            if (worksheet.Cells[i, j].Value != null)
                            {
                                excelData.Add(worksheet.Cells[i, j].Value.ToString());
                            }
                        }
                    }
                }

                ExcelWorksheet workSheet = excelPackage.Workbook.Worksheets.First();
                int totalRows = workSheet.Dimension.Rows;

                for (int i = 2; i <= totalRows; i++)
                {
                    var a = workSheet.Cells[i, 1].Value.ToString();
                    var b = DateTime.FromOADate(double.Parse(workSheet.Cells[i, 2].Value.ToString()));
                    var c = workSheet.Cells[i, 4].Value.ToString();
                }
            }
        }
    }
}
