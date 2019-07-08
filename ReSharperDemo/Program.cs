using System;
using System.Collections.Generic;

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
            //FizzBuzzUnreachableCode(5);

            //var persons = new List<Person> {new Person {Age = 10, Name = "Hugin"}, new Person {Age = 22, Name = "Leo"}};

            //DisplayPersonList(persons);
        }

        public static void CreateClass()
        {
            var person = new Person();
            person.Name = "Hugin";
            person.Age = 34;

        }

        private static void DisplayPersonList(List<Person> persons)
        {
            //Demo DataTips
            foreach (var person in persons)
            {
                var a = person.Name + "dwd";
            }
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

      

        public static void MarkAsInjectedLanguage()
        {
            var css = @".text{
                                color: #434;
                                margin: 0;
                              }";
        }
    }
}