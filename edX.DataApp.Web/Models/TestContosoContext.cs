using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace edX.DataApp.Web.Models
{
    class TestContosoContext : IContosoContext
    {
        public TestContosoContext()
        {
            this.Partners = new TestDbSet<Partner>();
        }

        public DbSet<Partner> Partners { get; set; }

        public int SaveChanges()
        {
            return 0;
        }

        public void Dispose()
        { }
    }
}
