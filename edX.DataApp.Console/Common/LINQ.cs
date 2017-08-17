using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.SqlClient;
using edX.DataApp.Console.Contexts;

namespace edX.DataApp.Console
{
    class LINQ
    {
        public async Task RunLogic(SqlConnection connection)
        {
            string query = "SELECT CustomerId, FirstName, LastName FROM Customers";
            SqlCommand command = new SqlCommand(query, connection);
            List<Customer> customers = new List<Customer>();

            using (SqlDataReader reader = await command.ExecuteReaderAsync())
            {
                while (reader.Read())
                {
                    customers.Add(
                        new Customer
                        {
                            CustomerID = await reader.GetFieldValueAsync<int>(0),
                            //FirstName = await reader.GetFieldValueAsync<string>(1),
                            //LastName = await reader.GetFieldValueAsync<string>(2)
                        }
                    );
                }
                foreach(Customer customer in customers)
                {
                    System.Console.WriteLine($"[{customer.CustomerID}] "); //{customer.LastName} {customer.FirstName}
                }
            }
        }

    }
}
