using System;
using System.Collections.Generic;

namespace ReSharperDemo.Models
{
    public partial class CustomerCustomerDemo
    {
        public string CustomerId { get; set; }
        public string CustomerTypeId { get; set; }

        public virtual Customers Customers { get; set; }
        public virtual CustomerDemographics CustomerType { get; set; }
    }
}
