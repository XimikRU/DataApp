using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.Entity;

namespace edX.DataApp.Lab.MVC.Models
{
    public class ContosoContext : DbContext
    {
        public ContosoContext()
            : base(@"Data Source=(localdb)\MSSQLLOCALDB;Initial Catalog=ContosoDB;")
        { }

        public DbSet<Partner> Partners { get; set; }
    }
}