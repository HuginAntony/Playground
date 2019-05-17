using System;
using System.Collections.Generic;

namespace ETL.DataAccess.Models
{
    public partial class DimCompany
    {
        public DimCompany()
        {
            DimCompanyAccount = new HashSet<DimCompanyAccount>();
            FactCitcollection = new HashSet<FactCitcollection>();
            FactFitransaction = new HashSet<FactFitransaction>();
            FactProductInventory = new HashSet<FactProductInventory>();
            FactSales = new HashSet<FactSales>();
            InverseParentCompanyKeyNavigation = new HashSet<DimCompany>();
        }

        public int CompanyKey { get; set; }
        public int? ParentCompanyKey { get; set; }
        public int? Fikey { get; set; }
        public string AlternateKey { get; set; }
        public double? ParentPercentageOfOwnership { get; set; }
        public string Name { get; set; }
        public string CompanyDba { get; set; }
        public string Description { get; set; }
        public string Category { get; set; }
        public string StreetAddress1 { get; set; }
        public string StreetAddress2 { get; set; }
        public string City { get; set; }
        public string State { get; set; }
        public int? Zip { get; set; }
        public string Country { get; set; }
        public int? Fein { get; set; }
        public string Phone { get; set; }
        public string SettlementAccount { get; set; }
        public decimal? DepositRequirement { get; set; }
        public int? CitcollectionCycle { get; set; }
        public decimal? ProjectedAnnualSales { get; set; }
        public decimal? ProjectedWeeklySales { get; set; }
        public decimal? ProjectedDailySales { get; set; }
        public DateTime? DateApproved { get; set; }
        public decimal? CityTaxRate { get; set; }
        public decimal? StateTaxRate { get; set; }
        public bool IsParent { get; set; }
        public bool? IsTaxImpoundCity { get; set; }
        public bool? IsTaxImpoundState { get; set; }
        public string StateGl { get; set; }
        public string CityGl { get; set; }
        public bool? NameVerified { get; set; }
        public bool? AddressVerified { get; set; }
        public bool? PhoneVerified { get; set; }
        public bool? Feinverified { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
        public bool CurrentFlag { get; set; }
        public int Etlid { get; set; }

        public virtual DimFinancialInstitution FikeyNavigation { get; set; }
        public virtual DimCompany ParentCompanyKeyNavigation { get; set; }
        public virtual ICollection<DimCompanyAccount> DimCompanyAccount { get; set; }
        public virtual ICollection<FactCitcollection> FactCitcollection { get; set; }
        public virtual ICollection<FactFitransaction> FactFitransaction { get; set; }
        public virtual ICollection<FactProductInventory> FactProductInventory { get; set; }
        public virtual ICollection<FactSales> FactSales { get; set; }
        public virtual ICollection<DimCompany> InverseParentCompanyKeyNavigation { get; set; }
    }
}
