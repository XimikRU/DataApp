using edX.DataApp.Web.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace edX.DataApp.Web
{
    public interface IContosoContext : IDisposable
    {
        DbSet<Partner> Partners { get; }
        int SaveChanges();  
    }
}
