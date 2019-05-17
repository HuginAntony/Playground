using System;
using System.Configuration;
using ETL.DataAccess.ModelConfigurations;
using ETL.DataAccess.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;

namespace ETL.DataAccess
{
    public class JadeDWContext : DbContext
    {
        public JadeDWContext()
        {
        }

        public JadeDWContext(DbContextOptions<JadeDWContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Classification> Classification { get; set; }
        public virtual DbSet<DimClient> DimClient { get; set; }
        public virtual DbSet<DimCompany> DimCompany { get; set; }
        public virtual DbSet<DimCompanyAccount> DimCompanyAccount { get; set; }
        public virtual DbSet<DimCurrency> DimCurrency { get; set; }
        public virtual DbSet<DimDataVendor> DimDataVendor { get; set; }
        public virtual DbSet<DimDate> DimDate { get; set; }
        public virtual DbSet<DimEmployee> DimEmployee { get; set; }
        public virtual DbSet<DimFinancialInstitution> DimFinancialInstitution { get; set; }
        public virtual DbSet<DimLocation> DimLocation { get; set; }
        public virtual DbSet<DimProduct> DimProduct { get; set; }
        public virtual DbSet<DimProductCategory> DimProductCategory { get; set; }
        public virtual DbSet<DimProductSubcategory> DimProductSubcategory { get; set; }
        public virtual DbSet<DimPromotion> DimPromotion { get; set; }
        public virtual DbSet<DimTime> DimTime { get; set; }
        public virtual DbSet<DimUnitOfMeasure> DimUnitOfMeasure { get; set; }
        public virtual DbSet<FactCitcollection> FactCitcollection { get; set; }
        public virtual DbSet<FactFitransaction> FactFitransaction { get; set; }
        public virtual DbSet<FactProductInventory> FactProductInventory { get; set; }
        public virtual DbSet<FactSales> FactSales { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                optionsBuilder.UseSqlServer("Server=localhost;Database=JadeDW;Trusted_Connection=True;Integrated Security=SSPI;");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.HasAnnotation("ProductVersion", "2.2.4-servicing-10062");

            modelBuilder.ApplyConfiguration(new ClassificationConfiguration());
            modelBuilder.ApplyConfiguration(new DimClientConfiguration());
            modelBuilder.ApplyConfiguration(new DimCompanyConfiguration());
            modelBuilder.ApplyConfiguration(new DimCompanyAccountConfiguration());
            modelBuilder.ApplyConfiguration(new DimCurrencyConfiguration());
            modelBuilder.ApplyConfiguration(new DimDataVendorConfiguration());
            modelBuilder.ApplyConfiguration(new DimDateConfiguration());
            modelBuilder.ApplyConfiguration(new DimEmployeeConfiguration());
            modelBuilder.ApplyConfiguration(new DimFinancialInstitutionConfiguration());
            modelBuilder.ApplyConfiguration(new DimLocationConfiguration());
            modelBuilder.ApplyConfiguration(new DimProductConfiguration());
            modelBuilder.ApplyConfiguration(new DimProductCategoryConfiguration());
            modelBuilder.ApplyConfiguration(new DimProductSubcategoryConfiguration());
            modelBuilder.ApplyConfiguration(new DimPromotionConfiguration());
            modelBuilder.ApplyConfiguration(new DimTimeConfiguration());
            modelBuilder.ApplyConfiguration(new DimUnitOfMeasureConfiguration());
            modelBuilder.ApplyConfiguration(new FactCitcollectionConfiguration());
            modelBuilder.ApplyConfiguration(new FactFitransactionConfiguration());
            modelBuilder.ApplyConfiguration(new FactProductInventoryConfiguration());
            modelBuilder.ApplyConfiguration(new FactSalesConfiguration());
        }
    }
}
