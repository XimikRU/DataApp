namespace edX.DataApp.Console
{
    using System;
    using System.Data.Entity;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Linq;
    using System.Collections.Generic;
    using System.Threading.Tasks;
    using System.Data.Entity.SqlServer;
    using System.Collections.ObjectModel;
    using edX.DataApp.Console.Contexts;

    [DbConfigurationType(typeof(ContosoContextConfiguration))]
    public partial class ContosoCodeModel : DbContext, IContosoContext
    {
        public ContosoCodeModel()
            : base("name=ContosoCodeModel")
        {
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

        /// <summary>
        /// Returns List of Opened Partners; 
        /// </summary>
        /// <param name="context"></param>
        /// <returns></returns>
        public async Task<List<Partner>> OpenedPartners(ContosoCodeModel context)
        {
            List<Partner> matchingPartners =
                 await context.Partners.Where(partner => partner.IsOpen).ToListAsync();
            return matchingPartners;
        }

        /// <summary>
        /// Retry pattern (conspect)
        /// </summary>
        public class ContosoContextConfiguration : DbConfiguration
        {
            public ContosoContextConfiguration()
            {
                SetExecutionStrategy("System.Data.SqlClient", () => new SqlAzureExecutionStrategy());
            }
        }
    }
}
