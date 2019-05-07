using System;

namespace CouchBaseCaching
{
    public class ThisCustomer
    {
        public int CustomerId { get; set; }
        public string CustomerName { get; set; }
        public decimal Amount { get; set; }
        public int? InvoiceId { get; set; }
        public DateTime InvoiceDate { get; set; }
    }
}