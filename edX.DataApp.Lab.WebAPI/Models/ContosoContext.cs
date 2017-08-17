using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.Entity;

namespace edX.DataApp.Lab.WebAPI.Models
{
    public class ContosoContext : DbContext
    {
        public ContosoContext()
            : base(@"Data Source=(localdb)\MSSQLLOCALDB;Initial Catalog=ContosoDB;")
        {
            this.Configuration.ProxyCreationEnabled = false;
        }

        public DbSet<Product> Products { get; set; }
        public DbSet<ProductCategory> ProductCategories { get; set; }
    }
}