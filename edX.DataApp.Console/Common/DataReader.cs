using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.SqlClient;

namespace edX.DataApp.Console
{
    class DataReader
    {
        public async Task RunLogic(SqlConnection connection)
        {
            string query = "SELECT CustomerId, FirstName, LastName FROM Customers";
            SqlCommand command = new SqlCommand(query, connection);

            using (SqlDataReader reader = command.ExecuteReader())
            {
                while (reader.Read())
                {
                    int idOrdinalValue = reader.GetOrdinal("CustomerId");
                    int fnOrdinalValue = reader.GetOrdinal("FirstName");
                    int lnOrdinalValue = reader.GetOrdinal("LastName");

                    int id = reader.GetFieldValue<int>(idOrdinalValue);
                    string firstName = reader.GetFieldValue<string>(fnOrdinalValue);
                    string lastName = reader.GetFieldValue<string>(lnOrdinalValue);

                    System.Console.WriteLine($"{id}\t{lastName}, {firstName}");
                }
            }
        }
    }
}
