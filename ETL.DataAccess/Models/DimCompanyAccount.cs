using System;

namespace ETL.DataAccess.Models
{
    public partial class DimCompanyAccount
    {
        public int AccountKey { get; set; }
        public int Fikey { get; set; }
        public int OrganizationKey { get; set; }
        public string AccountNumber { get; set; }
        public DateTime? StartDate { get; set; }
        public DateTime? EndDate { get; set; }
        public bool? CurrentFlag { get; set; }
        public int? Etlid { get; set; }

        public virtual DimFinancialInstitution FikeyNavigation { get; set; }
        public virtual DimCompany OrganizationKeyNavigation { get; set; }
    }
}
