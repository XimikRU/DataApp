using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Storage;
using System;
using System.Threading.Tasks;

namespace edX.DataApp.Lab.CoreConsole
{
    class Program
    {
        static void Main(string[] args)
        {
            using (ContosoContext context = new ContosoContext())
            {
                
                // new ContosoContext().RunCustomerLogic();
                // ContosoContext.RunAsync().Wait();
                // new ProductQuery().RunLogic(context);
                // new ModifyingDatabaseData().RunChangeLogic(context);
                // new ModifyingDatabaseData().RunAddLogic(context);
                // new DatabaseTransactions().RunLogic(context);
                // RunAsync();
                new Lab().RunLogic(context);
            }
            System.Console.WriteLine("Application has completed execution. Press any key to exit.");
            System.Console.ReadKey();
        }

        static async Task RunAsync()
        {
            using (ContosoContext context = new ContosoContext())
            {
                var creator = context.GetService<IDatabaseCreator>() as RelationalDatabaseCreator;
                await creator.ExistsAsync();
                Console.WriteLine("Connection Successful");
                await new ProductAndCategoryQuery().RunLogic(context);
            }
        }
    }
}