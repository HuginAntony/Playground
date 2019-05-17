using System;
using System.Collections.Generic;

namespace ETL.DataAccess.Models
{
    public partial class DimPromotion
    {
        public DimPromotion()
        {
            FactSales = new HashSet<FactSales>();
        }

        public int PromotionKey { get; set; }
        public int? PromotionAlternateKey { get; set; }
        public string EnglishPromotionName { get; set; }
        public double? DiscountPct { get; set; }
        public string EnglishPromotionType { get; set; }
        public string EnglishPromotionCategory { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime? EndDate { get; set; }
        public int? MinQty { get; set; }
        public int? MaxQty { get; set; }

        public virtual ICollection<FactSales> FactSales { get; set; }
    }
}
