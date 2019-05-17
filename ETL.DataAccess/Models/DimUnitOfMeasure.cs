using System.Collections.Generic;

namespace ETL.DataAccess.Models
{
    public partial class DimUnitOfMeasure
    {
        public DimUnitOfMeasure()
        {
            InverseConversionKeyNavigation = new HashSet<DimUnitOfMeasure>();
        }

        public int Uomkey { get; set; }
        public string Uomdescription { get; set; }
        public double? ConversionFactor { get; set; }
        public int? ConversionKey { get; set; }

        public virtual DimUnitOfMeasure ConversionKeyNavigation { get; set; }
        public virtual ICollection<DimUnitOfMeasure> InverseConversionKeyNavigation { get; set; }
    }
}
