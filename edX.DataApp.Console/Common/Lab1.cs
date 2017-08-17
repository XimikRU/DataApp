using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using System.Data;

namespace edX.DataApp.Console
{
    public class Lab1
    {
        public async Task RunLogic(SqlConnection connection)
        {
            SqlCommand command = connection.CreateCommand();
            command.CommandType = CommandType.Text;
            command.CommandText = "SELECT COUNT(CustomerId) AS CustomerCount, SalesPerson AS Contributor FROM Customers GROUP BY SalesPerson ORDER BY CustomerCount DESC";
            SqlDataReader reader = await command.ExecuteReaderAsync();
            while (await reader.ReadAsync())
            {
                System.Console.WriteLine($"{await reader.GetFieldValueAsync<string>(1),25}\t{await reader.GetFieldValueAsync<int>(0):000} Customers");
            }
        }
    }
}
