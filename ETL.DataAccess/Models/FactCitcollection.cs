using System;

namespace ETL.DataAccess.Models
{
    public partial class FactCitcollection
    {
        public int CollectionId { get; set; }
        public int CollectionDateKey { get; set; }
        public int CollectionTimeKey { get; set; }
        public int CompanyKey { get; set; }
        public int LocationKey { get; set; }
        public int DataVendorKey { get; set; }
        public int CurrencyKey { get; set; }
        public DateTime CollectionDateTime { get; set; }
        public bool? IsTampered { get; set; }
        public bool? IsCorrected { get; set; }
        public string CorrectionReason { get; set; }
        public string SealNumber { get; set; }
        public string CanisterSerialNumber { get; set; }
        public int? TotalNumberofNotes { get; set; }
        public decimal? CitcollectionTotalActualAmount { get; set; }
        public decimal? CitcollectionTotalAmount { get; set; }
        public decimal? CitcollectionTotalSurplusShortage { get; set; }
        public string CitoperatorName { get; set; }
        public int? Delivered { get; set; }
        public int? CollectedInCycle { get; set; }
        public int? Denom1cCount { get; set; }
        public int? Denom5cCount { get; set; }
        public int? Denom10cCount { get; set; }
        public int? Denom25cCount { get; set; }
        public int? Denom50cCount { get; set; }
        public int? Denom1Count { get; set; }
        public int? Denom2Count { get; set; }
        public int? Denom5Count { get; set; }
        public int? Denom10Count { get; set; }
        public int? Denom20Count { get; set; }
        public int? Denom50Count { get; set; }
        public int? Denom100Count { get; set; }
        public int? Denom1cTotal { get; set; }
        public int? Denom5cTotal { get; set; }
        public int? Denom10cTotal { get; set; }
        public int? Denom25cTotal { get; set; }
        public int? Denom50cTotal { get; set; }
        public int? Denom1Total { get; set; }
        public int? Denom2Total { get; set; }
        public int? Denom5Total { get; set; }
        public int? Denom10Total { get; set; }
        public int? Denom20Total { get; set; }
        public int? Denom50Total { get; set; }
        public int? Denom100Total { get; set; }
        public decimal? Total { get; set; }
        public DateTime? InsertDateTime { get; set; }
        public int? Etlid { get; set; }

        public virtual DimDate CollectionDateKeyNavigation { get; set; }
        public virtual DimTime CollectionTimeKeyNavigation { get; set; }
        public virtual DimCompany CompanyKeyNavigation { get; set; }
        public virtual DimCurrency CurrencyKeyNavigation { get; set; }
        public virtual DimDataVendor DataVendorKeyNavigation { get; set; }
        public virtual DimLocation LocationKeyNavigation { get; set; }
    }
}
