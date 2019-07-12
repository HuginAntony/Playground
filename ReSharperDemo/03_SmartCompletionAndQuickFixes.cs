using System;
using System.Linq;
using ReSharperDemo.Models;

namespace ReSharperDemo
{
    class SmartCompletionAndQuickFixes
    {
        private void ConvertToLinq()
        {
            var n = Enumerable.Range(1, 20);
            int sum = 0;

            foreach (var num in n)
            {
                sum += num;
            }
        }//Highlight closing braces

        public decimal ConvertStatement(decimal value)
        {
            switch (value)
            {
                case 50:
                    return 0.50M;
                case 20:
                    return 0.20M;
                case 10:
                    return 0.10M;
                case 5:
                    return 0.05M;
                default:
                    return 0;
            }
        }

        public static void MarkAsInjectedLanguage()
        {
            var css = @".text{
                                color: #434;
                                margin: 0;
                              }";
        }

        //Move to file. Intialize values.
        public enum Developer
        {
            Junior,
            Intermediate,
            Senior
        }

        //Code analysis for return type and auto import usings
        public Customers[] GetCustomers(Customers[] customers)
        {
            //return customers.Where(c => c.CustomerId == "new");
            return null;
        }

        public void SuggestType()
        {
            //var a = new XmlTextWriter("dwd", Encoding.UTF7);
            var formattedDate = DateTime.Now.ToString();
        }

        public static void CreateClass()
        {
            //var person = new Person();
            //person.Name = "Hugin";
            //person.Age = 34;

            //var persons = new List<Person> {new Person {Age = 10, Name = "Hugin"}, new Person {Age = 22, Name = "Leo"}};

        }
    }
}