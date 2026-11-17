using Microsoft.Data.SqlClient;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VacationManager.Data
{
    public class UserRepository
    {
        public DataTable GetUserForLogin(string username, string password)
        {
            DataTable user = new DataTable();

            connection connection1 = new connection();

            using (SqlConnection connection = connection1.GetConnection())
            {
                string query = @"
                    SELECT Users.Id,
                           Users.Username,
                           Users.FirstName,
                           Users.LastName,
                           Users.RoleId,
                           Users.TeamId,
                           Roles.Name
                    FROM Users
                    INNER JOIN Roles ON Users.Id = Roles.Id
                    WHERE Users.Username = @Username
                    AND Users.PasswordHash = @PasswordHash";

                using (SqlCommand command = new SqlCommand(query, connection))
                {
                    command.Parameters.AddWithValue("@Username", username);
                    command.Parameters.AddWithValue("@PasswordHash", password);

                    using (SqlDataAdapter adapter = new SqlDataAdapter(command))
                    {
                        adapter.Fill(user);
                    }
                }
            }

            return user;
        }

        public DataTable GetAllUsers()
        {
            DataTable users = new DataTable();

            connection connection1 = new connection();

            using (SqlConnection connection = connection1.GetConnection())
            {
                string query = @"
            SELECT Users.Id,
                   Users.Username,
                   Users.FirstName,
                   Users.LastName,
                   Roles.Name,
                   Users.TeamId
            FROM Users
            INNER JOIN Roles ON Users.Id = Roles.Id
            ORDER BY Users.Id";

                using (SqlCommand command = new SqlCommand(query, connection))
                {
                    using (SqlDataAdapter adapter = new SqlDataAdapter(command))
                    {
                        adapter.Fill(users);
                    }
                }
            }

            return users;
        }
        public DataTable SearchUsers(string username, string firstName, string lastName, string roleName)
        {
            DataTable users = new DataTable();

            connection connection1 = new connection();

            using (SqlConnection connection = connection1.GetConnection())
            {
                string query = @"
            SELECT Users.Id,
                   Users.Username,
                   Users.FirstName,
                   Users.LastName,
                   Roles.Name,
                   Users.TeamId
            FROM Users
            INNER JOIN Roles ON Users.Id = Roles.Id
            WHERE (@Username = '' OR Users.Username LIKE '%' + @Username + '%')
              AND (@FirstName = '' OR Users.FirstName LIKE '%' + @FirstName + '%')
              AND (@LastName = '' OR Users.LastName LIKE '%' + @LastName + '%')
              AND (@Name = '' OR Roles.Name = @Name)
            ORDER BY Users.Id";

                using (SqlCommand command = new SqlCommand(query, connection))
                {
                    command.Parameters.AddWithValue("@Username", username);
                    command.Parameters.AddWithValue("@FirstName", firstName);
                    command.Parameters.AddWithValue("@LastName", lastName);
                    command.Parameters.AddWithValue("@Name", roleName);

                    using (SqlDataAdapter adapter = new SqlDataAdapter(command))
                    {
                        adapter.Fill(users);
                    }
                }
            }

            return users;
        }

        public DataTable GetRoles()
        {
            DataTable roles = new DataTable();

            connection connection1 = new connection();

            using (SqlConnection connection = connection1.GetConnection())
            {
                string query = "SELECT Id, Name FROM Roles ORDER BY Name";

                using (SqlDataAdapter adapter = new SqlDataAdapter(query, connection))
                {
                    adapter.Fill(roles);
                }
            }

            return roles;
        }

        public DataTable GetTeams()
        {
            DataTable teams = new DataTable();

            connection connection1 = new connection();

            using (SqlConnection connection = connection1.GetConnection())
            {
                string query = "SELECT Id, Name FROM Teams ORDER BY Name";

                using (SqlDataAdapter adapter = new SqlDataAdapter(query, connection))
                {
                    adapter.Fill(teams);
                }
            }

            return teams;
        }


        public bool UsernameExists(string username, int userId = 0)
        {
            connection connection1 = new connection();

            using (SqlConnection connection = connection1.GetConnection())
            {
                string query = @"
                    SELECT COUNT(*)
                    FROM Users
                    WHERE Username = @Username
                    AND Id <> @Id";

                using (SqlCommand command = new SqlCommand(query, connection))
                {
                    command.Parameters.AddWithValue("@Username", username);
                    command.Parameters.AddWithValue("@Id", userId);

                    connection.Open();

                    int count = Convert.ToInt32(command.ExecuteScalar());

                    return count > 0;
                }
            }
        }


        public bool AddUser(string username, string password, string firstName, string lastName, int roleId, int teamId)
        {
            connection connection1 = new connection();

            using (SqlConnection connection = connection1.GetConnection())
            {
                string query = @"
            INSERT INTO Users
                (Username, PasswordHash, FirstName, LastName, RoleId, TeamId)
            VALUES
                (@Username, @Password, @FirstName, @LastName, @RoleId, @TeamId)";

                using (SqlCommand command = new SqlCommand(query, connection))
                {
                    command.Parameters.AddWithValue("@Username", username);
                    command.Parameters.AddWithValue("@PasswordHash", password);
                    command.Parameters.AddWithValue("@FirstName", firstName);
                    command.Parameters.AddWithValue("@LastName", lastName);
                    command.Parameters.AddWithValue("@RoleId", roleId);

                    if (teamId > 0)
                    {
                        command.Parameters.AddWithValue("@TeamId", teamId);
                    }
                    else
                    {
                        command.Parameters.AddWithValue("@TeamId", DBNull.Value);
                    }

                    connection.Open();

                    int result = command.ExecuteNonQuery();

                    if (result > 0)
                    {
                        return true;
                    }
                    else
                    {
                        return false;
                    }
                }
            }
        }

        public bool UpdateUser(int userId, string username, string password, string firstName, string lastName, int roleId, int teamId)
        {
            connection connection1 = new connection();

            using (SqlConnection connection = connection1.GetConnection())
            {
                string query = @"
            UPDATE Users
            SET Username = @Username,
                Password = CASE
                    WHEN @PasswordHash = '' THEN PasswordHash
                    ELSE @PasswordHash
                    END,
                FirstName = @FirstName,
                LastName = @LastName,
                RoleId = @RoleId,
                TeamId = @TeamId
            WHERE Id = @Id";

                using (SqlCommand command = new SqlCommand(query, connection))
                {
                    command.Parameters.AddWithValue("@Id", userId);
                    command.Parameters.AddWithValue("@Username", username);
                    command.Parameters.AddWithValue("@PasswordHash", password);
                    command.Parameters.AddWithValue("@FirstName", firstName);
                    command.Parameters.AddWithValue("@LastName", lastName);
                    command.Parameters.AddWithValue("@RoleId", roleId);

                    if (teamId > 0)
                    {
                        command.Parameters.AddWithValue("@TeamId", teamId);
                    }
                    else
                    {
                        command.Parameters.AddWithValue("@TeamId", DBNull.Value);
                    }

                    connection.Open();

                    int result = command.ExecuteNonQuery();

                    if (result > 0)
                    {
                        return true;
                    }
                    else
                    {
                        return false;
                    }
                }
            }
        }
        public bool DeleteUser(int userId)
        {
            connection connection1 = new connection();

            using (SqlConnection connection = connection1.GetConnection())
            {
                string query = @"
            DELETE FROM Users
            WHERE Id = @Id";

                using (SqlCommand command = new SqlCommand(query, connection))
                {
                    command.Parameters.AddWithValue("@Id", userId);

                    connection.Open();

                    int result = command.ExecuteNonQuery();

                    if (result > 0)
                    {
                        return true;
                    }
                    else
                    {
                        return false;
                    }
                }
            }
        }

    }
}
