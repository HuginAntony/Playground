using ReSharperDemo.Models;

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

        private static NorthwindContext _db;

        static void Main(string[] args)
        {
            //Quick fix to make method static
            //FizzBuzzUnreachableCode(5);

            //var persons = new List<Person> {new Person {Age = 10, Name = "Hugin"}, new Person {Age = 22, Name = "Leo"}};

            _db = new NorthwindContext();
            DisplayProducts();
        }

        public void SmartCompletion()
        {
            //var a = new XmlTextWriter("dwd", Encoding.UTF7);
        }

        public static void CreateClass()
        {
            //var person = new Person();
            //person.Name = "Hugin";
            //person.Age = 34;

        }

        private static void DisplayProducts()
        {
            //Demo DataTips
            //var products = _db.Products.ToList();
            
            //foreach (var product in products)
            //{
            //    Console.WriteLine(product.ProductName);
            //}
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


        //Code analysis for return type and auto import usings
        public static Customer[] GetCustomers(Customer[] customer)
        {
            //return customer.Where(c => c.CustomerId == "new");
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