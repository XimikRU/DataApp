using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.SqlClient;

namespace edX.DataApp.Console
{
    class BasicQuery
    {
        public async Task RunLogic(SqlConnection connection)
        {
            SqlCommand command = connection.CreateCommand();
            command.CommandType = CommandType.Text;
            command.CommandText = "SELECT TOP(25) CustomerID, FirstName, LastName FROM Customers";
            SqlDataReader reader = await command.ExecuteReaderAsync();
            while(await reader.ReadAsync())
            {
                int id = reader.GetInt32(0);
                string fn = reader.GetString(1);
                string ln = reader.GetString(2);
                System.Console.WriteLine($"[{id:000}]\t{ln}, {fn}");
            }
        }

        public async Task RunDataReader(SqlConnection connection)
        {
            SqlCommand com = connection.CreateCommand();
            com.CommandType = CommandType.Text;
            com.CommandText = "SELECT FirstName, LastName FROM Customers";
            SqlDataReader reader = com.ExecuteReader();
            while (reader.Read())
            {
                string fn = reader.GetString(0);
                string ln = reader.GetString(1);
                System.Console.WriteLine($"{fn} {ln}");
            }
        }


    }
}
