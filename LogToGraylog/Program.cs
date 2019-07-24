using System;
using System.IO;
using System.Linq;
using CouchBaseCaching;
using log4net;
using log4net.Config;
using WWI;

namespace LogToGraylog
{
    class Program
    {
        private static ILog _log = LogManager.GetLogger(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType);
        static void Main(string[] args)
        {
            XmlConfigurator.Configure();
            LogCustomerInfo();
            Console.ReadLine();
        }

        public static void LogCustomerInfo()
        {
            WWIModel wwi = new WWIModel();
            var ct = wwi.CustomerTransactions.ToList();

            foreach (var customer in ct)
            {
                var c = new ThisCustomer
                {
                    CustomerId = customer.CustomerID,
                    CustomerName = wwi.Customers.Single(cus => cus.CustomerID == customer.CustomerID).CustomerName,
                    Amount = customer.TransactionAmount,
                    InvoiceId = customer.InvoiceID,
                    InvoiceDate = customer.TransactionDate
                };

                _log.Warn(new { message = "Found transaction invoice for customer", customerId = c.CustomerId, customer = Newtonsoft.Json.JsonConvert.SerializeObject(c) });
                try
                {
                    var file = File.Open(c.CustomerName, FileMode.Open);
                }
                catch (Exception e)
                {
                    _log.Error(new { message = "Failed to open file " + c.CustomerName, exception = e });
                }

            }

        }
    }
}
