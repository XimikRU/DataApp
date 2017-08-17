using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

// Unit 3.4 //

namespace edX.DataApp.Console
{   
    /*
     * 
     * 
    // Default = my //
    class DefaultContext : DbContext
    {
        public virtual DbSet<Product> Products { get; set; }

        // Constructor
        public DefaultContext() 
            : base("name = DefaultConnectionString")
        {
            //Database.SetInitializer<DefaultContext>(new DefaultInitializer());
        }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            // base.OnModelCreating(modelBuilder); ????
            // modelBuilder.Entity<ContosoCodeModel>().HasKey(t => t.Partners); // ????
            
        }
    }
    *
    *
    */
}
