using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using System.Data;

namespace edX.DataApp.Console
{
    public class LINQToDataSet
    {
        public async Task RunLogic(SqlConnection connection)
        {
            string query = "SELECT * FROM Customers";
            using (SqlDataAdapter adapter = new SqlDataAdapter(query, connection))
            {
                DataSet set = new DataSet();
                adapter.Fill(set, "Customers");
                var linqQuery = from customer in set.Tables["Customers"].AsEnumerable()
                                where customer.Field<int>("CustomerId") == 5
                                select customer;
                string firstName = linqQuery.SingleOrDefault().Field<string>("FirstName");
                System.Console.WriteLine(firstName);
            }
        }
    }
}
