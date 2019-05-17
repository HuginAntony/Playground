using System;

namespace ETL.DataAccess.Models
{
    public partial class FactFitransaction
    {
        public int TransactionId { get; set; }
        public int DateKey { get; set; }
        public int TimeKey { get; set; }
        public int CompanyKey { get; set; }
        public string AccountNumber { get; set; }
        public string TransactionType { get; set; }
        public decimal TransactionAmount { get; set; }
        public decimal AccountBalance { get; set; }
        public string TransactionDescription { get; set; }
        public DateTime? InsertDateTime { get; set; }
        public int? Etlid { get; set; }

        public virtual DimCompany CompanyKeyNavigation { get; set; }
        public virtual DimDate DateKeyNavigation { get; set; }
        public virtual DimTime TimeKeyNavigation { get; set; }
    }
}
