using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore.Storage;
using Microsoft.EntityFrameworkCore.Infrastructure;
using System.Linq;

namespace edX.DataApp.Lab.CoreConsole
{
    public class ContosoContext : DbContext
    {
        public virtual DbSet<Customer> Customers { get; set; }

        public virtual DbSet<Product> Products { get; set; }

        public virtual DbSet<Partner> Partners { get; set; }

        public virtual DbSet<ProductCategory> ProductCategories { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            string connectionString = @"Data Source=(localdb)\MSSQLLOCALDB;Initial Catalog=ContosoDB;Integrated Security=True";
            optionsBuilder.UseSqlServer(connectionString);
        }

        public static async Task RunAsync()
        {
            using (ContosoContext context = new ContosoContext())
            {
                var creator = context.GetService<IDatabaseCreator>() as RelationalDatabaseCreator;
                await creator.ExistsAsync();
                System.Console.WriteLine("Connection Successful");
            } 
        }

        public void RunCustomerLogic()
        {
            using (ContosoContext context = new ContosoContext())
            {
                foreach (Customer customer in context.Customers)
                {
                    System.Console.WriteLine($"[{customer.CustomerId}] {customer.FirstName}");
                }


                IEnumerable<Customer> customersFiltered =
                    context.Customers.Where(customer => customer.FirstName == "Bob");

                foreach(Customer customer in customersFiltered)
                {
                    System.Console.WriteLine($"{customer.LastName}\t");
                }
               
            }
        }
    }
}
