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
            var airline = Airlines.Delta;

            if (value == 50)
                return 0.50M;
            else if (value == 20)
                return 0.20M;
            else if (value == 10)
                return 0.10M;
            else if (value == 5)
                return 0.05M;
            else
                return 0;
        }

        public void Recursive(int n)
        {
            if (n > 20)
            {
                return;
            }

            Recursive(n+1);
        }
        public static void MarkAsInjectedLanguage()
        {
            //Bug: this is a hack

            var css = @".text{
                                color: #434;
                                margin: 0;
                              }";
        }

        //Move to file. Intialize values.
        public enum Airlines
        {
            Mango,
            Kulula,
            Delta,
            Emirates,
            AmericanAirlines,
            Qatar
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