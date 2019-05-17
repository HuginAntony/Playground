using System;

namespace ETL.DataAccess.Models
{
    public partial class FactProductInventory
    {
        public int InventoryKey { get; set; }
        public int ProductKey { get; set; }
        public int DateKey { get; set; }
        public int TimeKey { get; set; }
        public int VendorKey { get; set; }
        public int LocationKey { get; set; }
        public int CompanyKey { get; set; }
        public string LotNumber { get; set; }
        public string BatchNumber { get; set; }
        public DateTime MovementDate { get; set; }
        public DateTime? ManufacturingDate { get; set; }
        public int IsExpired { get; set; }
        public DateTime? ExpiryDate { get; set; }
        public decimal? UnitCost { get; set; }
        public decimal? UnitPrice { get; set; }
        public int? OpenQty { get; set; }
        public int? HoldQty { get; set; }
        public int? BreakageQty { get; set; }
        public int? IntransitQty { get; set; }
        public int? AllocatedQty { get; set; }
        public int? AddQty { get; set; }
        public int? BeginningQty { get; set; }
        public int? SalesQty { get; set; }
        public int? EndingQty { get; set; }
        public DateTime? InsertDateTime { get; set; }
        public int Etlid { get; set; }

        public virtual DimCompany CompanyKeyNavigation { get; set; }
        public virtual DimDate DateKeyNavigation { get; set; }
        public virtual DimLocation LocationKeyNavigation { get; set; }
        public virtual DimProduct ProductKeyNavigation { get; set; }
        public virtual DimTime TimeKeyNavigation { get; set; }
        public virtual DimDataVendor VendorKeyNavigation { get; set; }
    }
}
