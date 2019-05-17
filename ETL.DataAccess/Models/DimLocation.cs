using System;
using System.Collections.Generic;

namespace ETL.DataAccess.Models
{
    public partial class DimLocation
    {
        public DimLocation()
        {
            FactCitcollection = new HashSet<FactCitcollection>();
            FactProductInventory = new HashSet<FactProductInventory>();
            FactSales = new HashSet<FactSales>();
        }

        public int LocationKey { get; set; }
        public string LocationId { get; set; }
        public string LocationCountry { get; set; }
        public string LocationState { get; set; }
        public string LocationCity { get; set; }
        public int? LocationZip { get; set; }
        public string LocationAddressLine1 { get; set; }
        public string LocationAddressLine2 { get; set; }
        public string LocationDescription { get; set; }
        public decimal? LocationGpslatitude { get; set; }
        public decimal? LocationGpslongtitude { get; set; }
        public DateTime? StartDate { get; set; }
        public DateTime? EndDate { get; set; }
        public int? Etlid { get; set; }
        public bool? IsCurrent { get; set; }

        public virtual ICollection<FactCitcollection> FactCitcollection { get; set; }
        public virtual ICollection<FactProductInventory> FactProductInventory { get; set; }
        public virtual ICollection<FactSales> FactSales { get; set; }
    }
}
