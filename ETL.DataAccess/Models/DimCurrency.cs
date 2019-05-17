using System.Collections.Generic;

namespace ETL.DataAccess.Models
{
    public partial class DimCurrency
    {
        public DimCurrency()
        {
            FactCitcollection = new HashSet<FactCitcollection>();
            FactSales = new HashSet<FactSales>();
        }

        public int CurrencyKey { get; set; }
        public string CurrencyAlternateKey { get; set; }
        public string CurrencyName { get; set; }

        public virtual ICollection<FactCitcollection> FactCitcollection { get; set; }
        public virtual ICollection<FactSales> FactSales { get; set; }
    }
}
