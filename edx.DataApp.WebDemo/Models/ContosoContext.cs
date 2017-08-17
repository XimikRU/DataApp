namespace edx.DataApp.WebDemo.Models
{
    using System;
    using System.Data.Entity;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Linq;

    public partial class ContosoContext : DbContext
    {
        public ContosoContext()
            : base("name=ContosoContext1")
        {
            this.Configuration.ProxyCreationEnabled = false;
        }

        public virtual DbSet<ProductCategories> ProductCategories { get; set; }
        public virtual DbSet<Products> Products { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<ProductCategories>()
                .HasMany(e => e.Products)
                .WithRequired(e => e.ProductCategories)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<Products>()
                .Property(e => e.StandardCost)
                .HasPrecision(19, 4);

            modelBuilder.Entity<Products>()
                .Property(e => e.ListPrice)
                .HasPrecision(19, 4);
        }
    }
}
