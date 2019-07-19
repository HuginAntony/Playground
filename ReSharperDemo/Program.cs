using System;

namespace ReSharperDemo
{
    class Program
    {
        //Intialize field in constructor. Rename to private naming convention
        private string filename;

        static void Main(string[] args)
        {
            //DateTime.Today comment
            var today = DateTime.Today.ToString("yyyy MMMM dd");

            //Quick fix to make method public
            DataTips.DisplayProducts();

            //StackTraceExplorer.GetNumber();
        }
    }
}