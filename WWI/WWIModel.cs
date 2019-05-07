namespace WWI
{
    using System;
    using System.Data.Entity;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Linq;

    public partial class WWIModel : DbContext
    {
        public WWIModel()
            : base("name=WWIModel")
        {
        }

        public virtual DbSet<Customer> Customers { get; set; }
        public virtual DbSet<CustomerTransaction> CustomerTransactions { get; set; }
        public virtual DbSet<Order> Orders { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Customer>()
                .Property(e => e.StandardDiscountPercentage)
                .HasPrecision(18, 3);

            modelBuilder.Entity<Customer>()
                .HasMany(e => e.Customers1)
                .WithRequired(e => e.Customer1)
                .HasForeignKey(e => e.BillToCustomerID);

            modelBuilder.Entity<Customer>()
                .HasMany(e => e.CustomerTransactions)
                .WithRequired(e => e.Customer)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<Customer>()
                .HasMany(e => e.Orders)
                .WithRequired(e => e.Customer)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<Order>()
                .HasMany(e => e.Orders1)
                .WithOptional(e => e.Order1)
                .HasForeignKey(e => e.BackorderOrderID);
        }
    }
}
