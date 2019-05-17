using System;

namespace ETL.DataAccess.Models
{
    public partial class FactSales
    {
        public int SalesId { get; set; }
        public int ProductKey { get; set; }
        public int OrderDateKey { get; set; }
        public int OrderTimeKey { get; set; }
        public int CompanyKey { get; set; }
        public int? SalesEmployeeKey { get; set; }
        public int? PromotionKey { get; set; }
        public int CurrencyKey { get; set; }
        public int LocationKey { get; set; }
        public int VendorKey { get; set; }
        public string SaleOrderNumber { get; set; }
        public decimal UnitPrice { get; set; }
        public decimal UnitCost { get; set; }
        public short SaleQuantity { get; set; }
        public decimal SalePrice { get; set; }
        public double SaleDiscountAmount { get; set; }
        public double SaleDiscountPercentage { get; set; }
        public decimal NetAmount { get; set; }
        public decimal? ExpectedDeposit { get; set; }
        public decimal SalesAmount { get; set; }
        public decimal? CityTax { get; set; }
        public decimal? ExpectedCityTax { get; set; }
        public decimal? CountyTax { get; set; }
        public decimal? StateTax { get; set; }
        public decimal? ExpectedStateTax { get; set; }
        public decimal? Freight { get; set; }
        public DateTime? OrderDate { get; set; }
        public DateTime? DueDate { get; set; }
        public DateTime? ShipDate { get; set; }
        public int? FidepositId { get; set; }
        public int? CitdepositId { get; set; }
        public int? StateTaxDepositId { get; set; }
        public int? CityTaxDepositId { get; set; }
        public string Posid { get; set; }
        public string PosuserId { get; set; }
        public DateTime? InsertDateTime { get; set; }
        public int Etlid { get; set; }

        public virtual DimCompany CompanyKeyNavigation { get; set; }
        public virtual DimCurrency CurrencyKeyNavigation { get; set; }
        public virtual DimLocation LocationKeyNavigation { get; set; }
        public virtual DimDate OrderDateKeyNavigation { get; set; }
        public virtual DimTime OrderTimeKeyNavigation { get; set; }
        public virtual DimProduct ProductKeyNavigation { get; set; }
        public virtual DimPromotion PromotionKeyNavigation { get; set; }
        public virtual DimEmployee SalesEmployeeKeyNavigation { get; set; }
        public virtual DimDataVendor VendorKeyNavigation { get; set; }
    }
}
