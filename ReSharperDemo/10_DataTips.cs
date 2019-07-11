using ReSharperDemo.Models;

namespace ReSharperDemo
{
    class DataTips
    {
        private static void DisplayProducts()
        {
            NorthwindContext _db = new NorthwindContext();

            //Demo DataTips
            //var products = _db.Products.ToList();

            //foreach (var product in products)
            //{
            //    Console.WriteLine(product.ProductName);
            //}
        }
    }
}