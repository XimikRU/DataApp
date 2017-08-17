using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using System.Data;
using System.Data.Entity;
using edX.DataApp.Console.Contexts;
using System.Data.Entity.ModelConfiguration;

namespace edX.DataApp.Console
{
    class Program
    {
        static void Main(string[] args)
        {
            
            // Second main action
            /*
            using (ContosoContext context = new ContosoContext())
            {
                context.PrintPartnerName();
            }
            */

            // First main action
            /* RunAsync().Wait(); */

            // Third Main Action
            /*
            using (ContosoCodeModel context = new ContosoCodeModel())
            {
                //List<Partner> partners = Task.Run(async () => await context.OpenedPartners(context)).Result;
                // or without await
                List <Partner> partners = context.OpenedPartners(context).Result;
                foreach (Partner partner in partners)
                {
                    System.Console.WriteLine($"[{partner.PartnerId}] {partner.Name} {partner.IsOpen}");
                }
            }
            */

            // Fourth main action
            /*
            using (ContosoCodeModel context = new ContosoCodeModel())
            {
                List<string> names = new RawSQL().AnnualPartners(context);
                foreach (string name in names)
                    System.Console.WriteLine(name);

                int result1 = context.Database.SqlQuery<int>("SELECT COUNT(*) FROM Partners").SingleOrDefault();
                System.Console.WriteLine($"Count:\t{result1}");

                string result = context.Database.SqlQuery<string>("SELECT @@VERSION").SingleOrDefault();
                System.Console.WriteLine(result);
            }
            */

            //Fifth main action
            using (ContosoCodeModel context = new ContosoCodeModel())
            {
                LocalData temp = new LocalData();
                temp.RunLogic(context);
                context.Partners.Add(new Partner { Name = "EXAMPLE" });
                temp.RunLogic(context);
                context.Partners.Load();
                temp.RunLogic(context);
            }

            System.Console.WriteLine("Application has completed execution. Press any key to exit.");
            System.Console.ReadKey();
        }


        /* ------------------  Main logic Task ------------ */
        static async Task RunAsync()
        {
            string connectionString = @"Data Source=(localdb)\MSSQLLocalDB;Initial Catalog=ContosoDB;Integrated Security=True;Connect Timeout=30;Encrypt=False;TrustServerCertificate=True;ApplicationIntent=ReadWrite;MultiSubnetFailover=False";
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                await connection.OpenAsync();
                System.Console.WriteLine("Connection Successful");

                //await new Lab1().RunLogic(connection);
                //await new LINQToDataSet().RunLogic(connection);
                //await new GenericQuery().Output(await new GenericQuery().RunLogic(connection));
                //await new BasicQuery().RunLogic(connection);
                //await new BasicQuery().RunDataReader(connection);
                //await new DataAdapter().RunLogic(connection);  
                //await new DataReader().RunLogic(connection);
                //await new LINQ().RunLogic(connection);

            }
        }


        static async Task Repeating(SqlConnection connection)
        {
            string q = "SELECT CustomerId, FirstName, LastName FROM Customers";
            using (SqlDataAdapter adapter = new SqlDataAdapter(q, connection))
            {
                DataSet set = new DataSet();
                adapter.Fill(set, "CustTable");
                DataTable table = set.Tables["Customers"];
                foreach(DataRow row in table.Rows)
                {
                    foreach(DataColumn col in table.Columns)
                    {
                        System.Console.WriteLine($"{row[col]}\t");
                    }
                }
            }
        }

    }
}
