namespace ETL.DataAccess.Models
{
    public partial class DimProductSubcategory
    {
        public int ProductSubcategoryKey { get; set; }
        public string ProductSubcategoryAlternateKey { get; set; }
        public string ProductSubcategoryName { get; set; }
        public int? ProductCategoryKey { get; set; }

        public virtual DimProductCategory ProductCategoryKeyNavigation { get; set; }
    }
}
