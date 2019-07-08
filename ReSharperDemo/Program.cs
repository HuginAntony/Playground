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
            //Quick fix to make method static
            //FizzBuzz(5);
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

        public string FizzBuzzUnreachableCode(int i)
        {
            //Extract to variable. Ctrl+Alt+V. Then move unreachable code up

            if (i % 3 == 0)
                return "Fizz";

            if (i % 5 == 0)
                return "Buzz";

            if (i % 3 == 0 && i % 5 == 0)
                return "FizzBuzz";

            return null;
        }

        public static void CreateClass()
        {
            //var person = new Person();
            //person.Name = "Hugin";
            //person.Age = 3;
            
        }
    }
}