using System;
using System.Data;
using Microsoft.Data.SqlClient;

namespace VacationManager.Logic
{
    public class UserService
    {
        private string connectionString = @"Data Source=svence;Database=VacationManager;Trusted_Connection=True;TrustServerCertificate=True;";

        public DataTable GetAllUsers()
        {
            string query = @"
                SELECT 
                    u.Id, 
                    u.Username, 
                    u.FirstName, 
                    u.LastName, 
                    r.Name AS RoleName, 
                    t.Name AS TeamName
                FROM Users u
                INNER JOIN Roles r ON u.RoleId = r.Id
                LEFT JOIN Teams t ON u.TeamId = t.Id
                ORDER BY u.Id ASC";

            DataTable dt = new DataTable();
            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                using (SqlCommand cmd = new SqlCommand(query, conn))
                {
                    SqlDataAdapter adapter = new SqlDataAdapter(cmd);
                    adapter.Fill(dt);
                }
            }
            return dt;
        }

        public DataTable GetRoles()
        {
            string query = "SELECT Id AS RoleId, Name AS RoleName FROM Roles";
            DataTable dt = new DataTable();
            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                using (SqlCommand cmd = new SqlCommand(query, conn))
                {
                    SqlDataAdapter adapter = new SqlDataAdapter(cmd);
                    adapter.Fill(dt);
                }
            }
            return dt;
        }

        public DataTable GetTeams()
        {
            string query = "SELECT Id AS TeamId, Name AS TeamName FROM Teams";
            DataTable dt = new DataTable();
            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                using (SqlCommand cmd = new SqlCommand(query, conn))
                {
                    SqlDataAdapter adapter = new SqlDataAdapter(cmd);
                    adapter.Fill(dt);
                }
            }
            return dt;
        }

        public DataTable SearchUsers(string username, string firstName, string lastName, string roleName)
        {
            string query = @"
                SELECT 
                    u.Id, 
                    u.Username, 
                    u.FirstName, 
                    u.LastName, 
                    r.Name AS RoleName, 
                    t.Name AS TeamName
                FROM Users u
                INNER JOIN Roles r ON u.RoleId = r.Id
                LEFT JOIN Teams t ON u.TeamId = t.Id
                WHERE 1 = 1";

            if (!string.IsNullOrWhiteSpace(username)) query += " AND u.Username LIKE @Username";
            if (!string.IsNullOrWhiteSpace(firstName)) query += " AND u.FirstName LIKE @FirstName";
            if (!string.IsNullOrWhiteSpace(lastName)) query += " AND u.LastName LIKE @LastName";
            if (!string.IsNullOrWhiteSpace(roleName) && roleName != "Всички") query += " AND r.Name = @RoleName";

            query += " ORDER BY u.Id ASC";

            DataTable dt = new DataTable();
            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                using (SqlCommand cmd = new SqlCommand(query, conn))
                {
                    if (!string.IsNullOrWhiteSpace(username)) cmd.Parameters.AddWithValue("@Username", "%" + username + "%");
                    if (!string.IsNullOrWhiteSpace(firstName)) cmd.Parameters.AddWithValue("@FirstName", "%" + firstName + "%");
                    if (!string.IsNullOrWhiteSpace(lastName)) cmd.Parameters.AddWithValue("@LastName", "%" + lastName + "%");
                    if (!string.IsNullOrWhiteSpace(roleName) && roleName != "Всички") cmd.Parameters.AddWithValue("@RoleName", roleName);

                    SqlDataAdapter adapter = new SqlDataAdapter(cmd);
                    adapter.Fill(dt);
                }
            }
            return dt;
        }

        public bool AddUser(string username, string password, string firstName, string lastName, int roleId, int teamId)
        {
            string query = @"
        INSERT INTO Users (Username, PasswordHash, FirstName, LastName, RoleId, TeamId)
        VALUES (@Username, @Password, @FirstName, @LastName, @RoleId, @TeamId)";

            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                using (SqlCommand cmd = new SqlCommand(query, conn))
                {
                    cmd.Parameters.Add("@Username", SqlDbType.NVarChar).Value = username;
                    cmd.Parameters.Add("@Password", SqlDbType.NVarChar).Value = password;
                    cmd.Parameters.Add("@FirstName", SqlDbType.NVarChar).Value = firstName;
                    cmd.Parameters.Add("@LastName", SqlDbType.NVarChar).Value = lastName;
                    cmd.Parameters.Add("@RoleId", SqlDbType.Int).Value = roleId;
                    cmd.Parameters.Add("@TeamId", SqlDbType.Int).Value = teamId > 0 ? (object)teamId : DBNull.Value;

                    conn.Open();
                    return cmd.ExecuteNonQuery() > 0;
                }
            }
        }

        public bool UpdateUser(int userId, string username, string password, string firstName, string lastName, int roleId, int teamId)
        {
            string query = @"
                UPDATE Users 
                SET Username = @Username, 
                    FirstName = @FirstName, 
                    LastName = @LastName, 
                    RoleId = @RoleId, 
                    TeamId = @TeamId";

            if (!string.IsNullOrWhiteSpace(password))
            {
                query += ", PasswordHash = @Password";
            }

            query += " WHERE Id = @Id";

            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                using (SqlCommand cmd = new SqlCommand(query, conn))
                {
                    cmd.Parameters.AddWithValue("@Id", userId);
                    cmd.Parameters.AddWithValue("@Username", username);
                    cmd.Parameters.AddWithValue("@FirstName", firstName);
                    cmd.Parameters.AddWithValue("@LastName", lastName);
                    cmd.Parameters.AddWithValue("@RoleId", roleId);
                    cmd.Parameters.AddWithValue("@TeamId", teamId > 0 ? (object)teamId : DBNull.Value);

                    if (!string.IsNullOrWhiteSpace(password))
                    {
                        cmd.Parameters.AddWithValue("@Password", password);
                    }

                    conn.Open();
                    return cmd.ExecuteNonQuery() > 0;
                }
            }
        }

        public bool DeleteUser(int userId)
        {
            string query = @"
                DELETE FROM Vacations WHERE RequesterId = @Id;
                DELETE FROM Users WHERE Id = @Id;";

            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                using (SqlCommand cmd = new SqlCommand(query, conn))
                {
                    cmd.Parameters.AddWithValue("@Id", userId);
                    conn.Open();
                    return cmd.ExecuteNonQuery() > 0;
                }
            }
        }
    }
}