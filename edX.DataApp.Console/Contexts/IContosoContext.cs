using edX.DataApp.Console.Contexts;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace edX.DataApp.Console
{
    public interface IContosoContext : IDisposable
    {
        DbSet<Partner> Partners { get; }
        int SaveChanges();
    }
}
