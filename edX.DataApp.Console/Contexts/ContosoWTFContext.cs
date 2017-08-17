namespace edX.DataApp.Console
{
    using System;
    using System.Data.Entity;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Linq;

    /*
     public partial class ContosoContext : DbContext
     {

         public ContosoContext()
             : base(@"Data Source=(localdb)\MSSQLLOCALDB;Initial Catalog=ContosoDB;Integrated Security=True")
         {
         }

         public virtual DbSet<Partner> Partners { get; set; }

         // Hand-added
         public virtual DbSet<ProductsDetailedView> ProductsDetailedViews { get; set; }

         protected override void OnModelCreating(DbModelBuilder modelBuilder)
         {
             modelBuilder.Entity<Partner>()
                 .Property(e => e.AnnualRevenue)
                 .HasPrecision(19, 4);

             // Hand-added
             modelBuilder.Entity<ProductsDetailedView>()
             .ToTable("ProductsDetailedView");

            // modelBuilder.Entity<Partner>().MapToStoredProcedures(sp =>
             //{
              //   sp.Insert(proc => proc.HasName("AddPartner"));
              //   sp.Update(proc => proc.HasName("UpdatePartner"));
             //    sp.Delete(proc => proc.HasName("DeletePartner"));
            // });

         }

         public void PrintPartnerName()
         {
             foreach (Partner partner in Partners)
             {
                 Console.WriteLine(partner.Name);
             }
         }

     }
     */
}
