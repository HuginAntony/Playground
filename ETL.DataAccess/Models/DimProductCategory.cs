using System.Collections.Generic;

namespace ETL.DataAccess.Models
{
    public partial class DimProductCategory
    {
        public DimProductCategory()
        {
            DimProductSubcategory = new HashSet<DimProductSubcategory>();
        }

        public int ProductCategoryKey { get; set; }
        public string ProductCategoryAlternateKey { get; set; }
        public string ProductCategoryName { get; set; }

        public virtual ICollection<DimProductSubcategory> DimProductSubcategory { get; set; }
    }
}
