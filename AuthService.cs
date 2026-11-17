using System;
using System.Data;
using System.Data.SqlClient;
using System.Security.Cryptography;
using System.Text;
using Microsoft.Data.SqlClient;

namespace VacationManager.Logic
{
    public class AuthService
    {
        private string connectionString = @"Data Source=svence;Database=VacationManager;Trusted_Connection=True;TrustServerCertificate=True;";

        public DataTable Login(string username, string password)
        {
            string hashedPassword = GetSha256Hash(password);

            string query = @"
                SELECT 
                    u.Id AS UserId, 
                    u.Username, 
                    u.FirstName, 
                    u.LastName, 
                    r.Name AS RoleName, 
                    u.TeamId 
                FROM Users u
                INNER JOIN Roles r ON u.RoleId = r.Id
                WHERE LOWER(u.Username) = LOWER(@Username) AND u.PasswordHash = @PasswordHash";

            DataTable dt = new DataTable();

            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                using (SqlCommand cmd = new SqlCommand(query, conn))
                {
                    cmd.Parameters.AddWithValue("@Username", username.Trim());
                    cmd.Parameters.AddWithValue("@PasswordHash", hashedPassword);

                    SqlDataAdapter adapter = new SqlDataAdapter(cmd);
                    adapter.Fill(dt);
                }
            }

            return dt;
        }

        public string CheckLoginProblem(string username, string password)
        {
            string hashedPassword = GetSha256Hash(password);

            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                conn.Open();

                string checkUserQuery = "SELECT COUNT(*) FROM Users WHERE LOWER(Username) = LOWER(@Username)";
                using (SqlCommand cmd = new SqlCommand(checkUserQuery, conn))
                {
                    cmd.Parameters.AddWithValue("@Username", username.Trim());
                    int count = (int)cmd.ExecuteScalar();
                    if (count == 0)
                    {
                        return $"В базата данни няма потребител с име '{username}'.";
                    }
                }

                string checkHashQuery = "SELECT PasswordHash FROM Users WHERE LOWER(Username) = LOWER(@Username)";
                using (SqlCommand cmd = new SqlCommand(checkHashQuery, conn))
                {
                    cmd.Parameters.AddWithValue("@Username", username.Trim());
                    string dbHash = cmd.ExecuteScalar()?.ToString();

                    return $"Потребителят е намерен!\nХеш в базата: {dbHash}\nГенериран хеш в C#: {hashedPassword}\nСъвпадат ли: {(dbHash == hashedPassword ? "ДА" : "НЕ")}";
                }
            }
        }

        public string GetSha256Hash(string rawData)
        {
            using (SHA256 sha256 = SHA256.Create())
            {
                byte[] bytes = sha256.ComputeHash(Encoding.UTF8.GetBytes(rawData));
                StringBuilder builder = new StringBuilder();
                for (int i = 0; i < bytes.Length; i++)
                {
                    builder.Append(bytes[i].ToString("x2"));
                }
                return builder.ToString();
            }
        }

        public bool ResetPassword(string username, string newPassword)
        {
            string newHash = GetSha256Hash(newPassword);

            string query = "UPDATE Users SET PasswordHash = @PasswordHash WHERE Username = @Username";

            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                using (SqlCommand cmd = new SqlCommand(query, conn))
                {
                    cmd.Parameters.AddWithValue("@PasswordHash", newHash);
                    cmd.Parameters.AddWithValue("@Username", username);

                    conn.Open();
                    int rows = cmd.ExecuteNonQuery();
                    return rows > 0;
                }
            }
        }
    }
}