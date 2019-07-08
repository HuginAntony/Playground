using System;

namespace ReSharperDemo
{
    class Program
    {
        //Intialize field in constructor. Rename to private naming convention
        private string filename;

        //Move to file. Intialize values.
        public enum Developer
        {
            Junior,
            Intermediate,
            Senior
        }

        static void Main(string[] args)
        {
            
        }

        void ConvertToLinq()
        {
            //var n = Enumerable.Range(1, 20);
            //int sum = 0;

            //foreach (var num in n)
            //{
            //    sum += num;
            //}
        }

        public string FizzBuzz(int i)
        {
            //Extract to variable. Ctrl+Alt+V
            if (i % 3 == 0)
                return "Fizz";

            if (i % 5 == 0)
                return "Buzz";

            if (i % 3 == 0 && i % 5 == 0)
                return "FizzBuzz";

            return null;
        }
    }
}
