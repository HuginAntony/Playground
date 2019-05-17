using System.Collections.Generic;

namespace ETL.DataAccess.Models
{
    public partial class DimDataVendor
    {
        public DimDataVendor()
        {
            FactCitcollection = new HashSet<FactCitcollection>();
            FactProductInventory = new HashSet<FactProductInventory>();
            FactSales = new HashSet<FactSales>();
        }

        public int VendorKey { get; set; }
        public string VendorName { get; set; }
        public string VendorId { get; set; }
        public int Etlid { get; set; }

        public virtual ICollection<FactCitcollection> FactCitcollection { get; set; }
        public virtual ICollection<FactProductInventory> FactProductInventory { get; set; }
        public virtual ICollection<FactSales> FactSales { get; set; }
    }
}
