namespace edX.DataApp.WebAPI.Models
{
    using System;
    using System.Data.Entity;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Linq;

    public partial class ContosoContext : DbContext
    {
        // 
        // [4.1.2] Alternatively, you can configure the initializer
        // in the static constructor of your context class: (2 variant)
        public ContosoContext()
            : base("name=ContosoContext1")
        {
            base.Configuration.ProxyCreationEnabled = false;
            //Database.SetInitializer<ContosoContext>(new DropCreateDatabaseIfModelChanges<ContosoContext>());
        }

        public virtual DbSet<C__MigrationHistory> C__MigrationHistory { get; set; }
        public virtual DbSet<Customer> Customers { get; set; }
        public virtual DbSet<Partner> Partners { get; set; }
        public virtual DbSet<ProductCategory> ProductCategories { get; set; }
        public virtual DbSet<Product> Products { get; set; }
        public virtual DbSet<ProductsDetailedView> ProductsDetailedViews { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Partner>()
                .Property(e => e.AnnualRevenue)
                .HasPrecision(19, 4);

            modelBuilder.Entity<ProductCategory>()
                .HasMany(e => e.Products)
                .WithRequired(e => e.ProductCategory)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<Product>()
                .Property(e => e.StandardCost)
                .HasPrecision(19, 4);

            modelBuilder.Entity<Product>()
                .Property(e => e.ListPrice)
                .HasPrecision(19, 4);

            modelBuilder.Entity<ProductsDetailedView>()
                .Property(e => e.Cost)
                .HasPrecision(19, 4);

            modelBuilder.Entity<ProductsDetailedView>()
                .Property(e => e.Price)
                .HasPrecision(19, 4);

            modelBuilder.Entity<ProductsDetailedView>()
                .Property(e => e.Profit)
                .HasPrecision(19, 4);
        }

        public System.Data.Entity.DbSet<edX.DataApp.WebAPI.Models.Item> Items { get; set; }
    }
}
