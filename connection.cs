using Microsoft.Data.SqlClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VacationManager.Data
{
    public class connection
    {
        public static string connectionString = @"Data Source=svence;Database=VacationManager;Trusted_Connection=True;TrustServerCertificate=True;";

        public SqlConnection GetConnection()
        {
            return new SqlConnection(connectionString);
        }

        public bool TestConnection()
        {
            using (SqlConnection connection = GetConnection())
            {
                connection.Open();

                return connection.State == System.Data.ConnectionState.Open;
            }
        }
    }
}
