using System.Collections.Generic;
using System.Linq;

namespace ReSharperDemo
{
    class Program
    {
        //Intialize field in constructor. Rename to private naming convention
        private string filename;

        static void Main(string[] args)
        {
            //Quick fix to make method public
            DataTips.DisplayProducts();
        }
    }
}