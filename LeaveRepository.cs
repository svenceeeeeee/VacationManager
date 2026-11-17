using Microsoft.Data.SqlClient;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Reflection;

namespace VacationManager.Data
{
    public class LeaveRepository
    {
        public DataTable GetAllLeaves()  
        {
            DataTable leaves = new DataTable();
            connection connection1 = new connection();

            using (SqlConnection connection = connection1.GetConnection())
            {
                string query = @"
                    SELECT
                        LeaveRequest.LeaveRequestId,
                        Users.Username,
                        Users.FirstName,
                        Users.LastName,
                        LeaveTypes.LeaveTypeName,
                        LeaveRequest.FromDate,
                        LeaveRequest.ToDate,
                        LeaveRequest.CreationDate,
                        LeaveRequest.HalfDay,
                        LeaveRequest.Status,
                        LeaveRequest.MedicalDocument
                            FROM LeaveRequest
                               INNER JOIN Users
                                ON LeaveRequest.UserId = Users.UserId
                               INNER JOIN LeaveTypes
                                ON LeaveRequest.LeaveTypeId = LeaveTypes.LeaveTypeId
                            ORDER BY LeaveRequest.CreationDate DESC";

                using (SqlCommand command = new SqlCommand(query, connection))
                {
                    using (SqlDataAdapter adapter = new SqlDataAdapter(command))
                    {
                        adapter.Fill(leaves);
                    }
                }
            }

            return leaves;
        }

        public bool UpdateLeaveStatus(int leaveRequestId, string status)  
        {
            connection connection1 = new connection();
            using (SqlConnection connection = connection1.GetConnection())
            {

                string query = @"
            UPDATE LeaveRequest
            SET Status = @Status
            WHERE LeaveRequestId = @LeaveRequestId";

                using (SqlCommand command = new SqlCommand(query, connection))
                {
                    command.Parameters.AddWithValue("@Status", status);
                    command.Parameters.AddWithValue(
                        "@LeaveRequestId", leaveRequestId);

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

        public DataTable GetLeaveTypes()   
        {
            DataTable leaveTypes = new DataTable();
            connection connection1 = new connection();

            using (SqlConnection connection = connection1.GetConnection())
            {
                string query = @"
            SELECT LeaveTypeId, LeaveTypeName
            FROM LeaveTypes
            ORDER BY LeaveTypeId";

                using (SqlCommand command = new SqlCommand(query, connection))
                using (SqlDataAdapter adapter = new SqlDataAdapter(command))
                {
                    adapter.Fill(leaveTypes);
                }
            }

            return leaveTypes;
        }

        public bool AddLeaveRequest(int userId, int leaveTypeId, DateTime fromDate, DateTime toDate, bool halfDay, string medicalDocument)    //добавяне на нова заявка
        {
            connection connection1 = new connection();

            using (SqlConnection connection = connection1.GetConnection())
            {

                string query = @"
            INSERT INTO LeaveRequest
                (FromDate, ToDate, CreationDate, HalfDay,
                 Status, UserId, LeaveTypeId, MedicalDocument)
            VALUES
                (@FromDate, @ToDate, @CreationDate, @HalfDay,
                 @Status, @UserId, @LeaveTypeId, @MedicalDocument)";

                using (SqlCommand command = new SqlCommand(query, connection))
                {
                    command.Parameters.AddWithValue("@FromDate", fromDate);
                    command.Parameters.AddWithValue("@ToDate", toDate);
                    command.Parameters.AddWithValue("@CreationDate", DateTime.Now);
                    command.Parameters.AddWithValue("@HalfDay", halfDay);
                    command.Parameters.AddWithValue("@Status", "Чакаща");
                    command.Parameters.AddWithValue("@UserId", userId);
                    command.Parameters.AddWithValue("@LeaveTypeId", leaveTypeId);


                    if (string.IsNullOrWhiteSpace(medicalDocument))
                    {
                        command.Parameters.AddWithValue(
                            "@MedicalDocument", DBNull.Value);
                    }
                    else
                    {
                        command.Parameters.AddWithValue(
                            "@MedicalDocument", medicalDocument);
                    }

                    connection.Open();

                    int result = command.ExecuteNonQuery();

                    return result > 0;
                }
            }
        }
        public DataTable GetLeavesByUserId(int userId)   
        {
            DataTable leaves = new DataTable();
            connection connection1 = new connection();

            using (SqlConnection connection = connection1.GetConnection())
            {
              string query = @"
            SELECT
                LeaveRequest.LeaveRequestId,
                LeaveTypes.LeaveTypeName,
                LeaveRequest.FromDate,
                LeaveRequest.ToDate,
                LeaveRequest.CreationDate,
                LeaveRequest.HalfDay,
                LeaveRequest.Status,
                LeaveRequest.MedicalDocument
            FROM LeaveRequest
            INNER JOIN LeaveTypes
                ON LeaveRequest.LeaveTypeId = LeaveTypes.LeaveTypeId
            WHERE LeaveRequest.UserId = @UserId
            ORDER BY LeaveRequest.CreationDate DESC";

                using (SqlCommand command = new SqlCommand(query, connection))
                {
                    command.Parameters.AddWithValue("@UserId", userId);

                    using (SqlDataAdapter adapter = new SqlDataAdapter(command))
                    {
                        adapter.Fill(leaves);
                    }
                }
            }

            return leaves;
        }


        public DataTable GetLeavesByTeamId(int teamId)      
        { 
            DataTable leaves = new DataTable();
            connection connection1 = new connection();

            using (SqlConnection connection = connection1.GetConnection())
            {
                string query = @"
            SELECT
                LeaveRequest.LeaveRequestId,
                Users.Username,
                Users.FirstName,
                Users.LastName,
                LeaveTypes.LeaveTypeName,
                LeaveRequest.FromDate,
                LeaveRequest.ToDate,
                LeaveRequest.CreationDate,
                LeaveRequest.HalfDay,
                LeaveRequest.Status
            FROM LeaveRequest
            INNER JOIN Users
                ON LeaveRequest.UserId = Users.UserId
            INNER JOIN LeaveTypes
                ON LeaveRequest.LeaveTypeId = LeaveTypes.LeaveTypeId
            WHERE Users.TeamId = @TeamId
            ORDER BY LeaveRequest.CreationDate DESC";

                using (SqlCommand command = new SqlCommand(query, connection))
                {
                    command.Parameters.AddWithValue("@TeamId", teamId);

                    using (SqlDataAdapter adapter = new SqlDataAdapter(command))
                    {
                        adapter.Fill(leaves);
                    }
                }
            }

            return leaves;
        }
    }
}
