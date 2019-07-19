using System;
using System.Collections.Generic;
using System.Linq;
using ReSharperDemo.Models;

namespace ReSharperDemo
{
    class SmartCompletionAndQuickFixes
    {
        //Alt+Enter to get quick fixes
        private void ConvertToLinq()
        {
            var n = Enumerable.Range(1, 20);
            int sum = 0;

            
            //1
            foreach (var num in n)
            {
                sum += num;
            }

            //2
            var numbers = new List<int> { 6, 2, 8, 3 };
            int sumAgg = numbers.Aggregate(func: (result, item) => result + item);

            //3
            int s = 0;
            for (var i = 0; i < numbers.Count; i++)
            {
                var number = numbers[i];
                s += number;
            }

            //4
            IEnumerable<Booking> developers = new List<Booking>();
            int count = 0;
            foreach (var developer in developers)
            {
                if (developer.NumOfPax == 30)
                {
                    count++;
                }
            }

        }//Highlight closing braces

        
        public decimal ConvertStatement(decimal value)
        {
            var airline = Airlines.Delta;

            //Alt+Enter to convert to a Switch statement
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

            //Shows that the call is recursive
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

        //Invoke specify Enum member values. F6 to Move to file
        public enum Airlines
        {
            Mango,
            Kulula,
            Delta,
            Emirates,
            AmericanAirlines,
            Qatar
        }

        
        public Customers[] GetCustomers(Customers[] customers)
        {
            //return customers.Where(c => c.CustomerId == "new");

            //Code analysis for return type and auto import using
            //Remove the null and start typing the above Linq query
            return null;
        }

        public void SuggestType()
        {
            //var a = new XmlTextWriter("dwd", Encoding.UTF7);
            //Start typing the above line, after the comma press Ctrl+Shift+Space to get the Encoding num values

            var formattedDate = DateTime.Now.ToString();
        }

        //Alt+Enter on Person and its properties to create them
        public static void CreateClass()
        {
            //var person = new Person();
            //person.Name = "Hugin";
            //person.Age = 34;

            //var persons = new List<Person> {new Person {Age = 10, Name = "Hugin"}, new Person {Age = 22, Name = "Leo"}};

        }
    }

    //Invoke Alt+Insert - Insert constructor with properties.
    //Demonstrate formatting members
    public class Employee
    {
        public string Name { get; set; }
        public string Department { get; set; }
        public virtual int Age { get; set; }
        public decimal Salary { get; set; }

        //Create methods and properties using mnemonics

    }
}