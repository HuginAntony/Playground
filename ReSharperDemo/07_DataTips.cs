using System;
using System.Linq;
using ReSharperDemo.Models;

namespace ReSharperDemo
{
    class DataTips
    {
        private static void DisplayProducts()
        {
            NorthwindContext _db = new NorthwindContext();

            var products = _db.Products.ToList();

            //Demo DataTips. Insert a breakpoint and set datatips on 2 properties of the oroducts variable above. 
            foreach (var product in products)
            {
                Console.WriteLine(product.ProductName);
            }
        }
    }
}