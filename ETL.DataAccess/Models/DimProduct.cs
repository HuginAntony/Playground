using System;
using System.Collections.Generic;

namespace ETL.DataAccess.Models
{
    public partial class DimProduct
    {
        public DimProduct()
        {
            FactProductInventory = new HashSet<FactProductInventory>();
            FactSales = new HashSet<FactSales>();
        }

        public int ProductKey { get; set; }
        public string ProductAlternateKey { get; set; }
        public string ItemName { get; set; }
        public string ItemType { get; set; }
        public string ItemGroupDescription { get; set; }
        public string ItemGroupCategory { get; set; }
        public string Description { get; set; }
        public string UnitofMeasure { get; set; }
        public bool? IsSaleable { get; set; }
        public bool? IsInventoryTrackingRequired { get; set; }
        public bool? IsBatchTrackingRequired { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
        public bool CurrentFlag { get; set; }
        public int Etlid { get; set; }

        public virtual ICollection<FactProductInventory> FactProductInventory { get; set; }
        public virtual ICollection<FactSales> FactSales { get; set; }
    }
}
