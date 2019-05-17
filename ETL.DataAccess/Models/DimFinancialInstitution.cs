using System.Collections.Generic;

namespace ETL.DataAccess.Models
{
    public partial class DimFinancialInstitution
    {
        public DimFinancialInstitution()
        {
            DimCompany = new HashSet<DimCompany>();
            DimCompanyAccount = new HashSet<DimCompanyAccount>();
        }

        public int Fikey { get; set; }
        public string FialternateKey { get; set; }
        public string Name { get; set; }
        public string AccountRange { get; set; }

        public virtual ICollection<DimCompany> DimCompany { get; set; }
        public virtual ICollection<DimCompanyAccount> DimCompanyAccount { get; set; }
    }
}
