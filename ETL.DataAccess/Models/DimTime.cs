using System.Collections.Generic;

namespace ETL.DataAccess.Models
{
    public partial class DimTime
    {
        public DimTime()
        {
            FactCitcollection = new HashSet<FactCitcollection>();
            FactFitransaction = new HashSet<FactFitransaction>();
            FactProductInventory = new HashSet<FactProductInventory>();
            FactSales = new HashSet<FactSales>();
        }

        public int TimeKey { get; set; }
        public string Time { get; set; }
        public string Hour { get; set; }
        public string MilitaryHour { get; set; }
        public string Minute { get; set; }
        public string Second { get; set; }
        public string AmPm { get; set; }
        public string StandardTime { get; set; }

        public virtual ICollection<FactCitcollection> FactCitcollection { get; set; }
        public virtual ICollection<FactFitransaction> FactFitransaction { get; set; }
        public virtual ICollection<FactProductInventory> FactProductInventory { get; set; }
        public virtual ICollection<FactSales> FactSales { get; set; }
    }
}
