using System;
using System.Data;
using Microsoft.Data.SqlClient;

namespace VacationManager.Logic
{
    public class LeaveService
    {
        private string connectionString = @"Data Source=svence;Database=VacationManager;Trusted_Connection=True;TrustServerCertificate=True;";

        public DataTable GetLeaveTypes()
        {
            DataTable dt = new DataTable();
            dt.Columns.Add("LeaveTypeId", typeof(string));
            dt.Columns.Add("LeaveTypeName", typeof(string));

            dt.Rows.Add("Платен", "Платен");
            dt.Rows.Add("Неплатен", "Неплатен");
            dt.Rows.Add("Болничен", "Болничен");

            return dt;
        }

        public bool AddLeaveRequest(int userId, string leaveType, DateTime fromDate, DateTime toDate, bool halfDay, string medicalDocumentPath)
        {
            string query = @"
                INSERT INTO Vacations (RequesterId, LeaveType, DateFrom, DateTo, HalfDay, AttachmentPath, Status, CreationDate)
                VALUES (@UserId, @LeaveType, @FromDate, @ToDate, @HalfDay, @AttachmentPath, N'Неодобрена', GETDATE())";

            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                using (SqlCommand cmd = new SqlCommand(query, conn))
                {
                    cmd.Parameters.Add("@UserId", SqlDbType.Int).Value = userId;
                    cmd.Parameters.Add("@LeaveType", SqlDbType.NVarChar).Value = leaveType;
                    cmd.Parameters.Add("@FromDate", SqlDbType.Date).Value = fromDate;
                    cmd.Parameters.Add("@ToDate", SqlDbType.Date).Value = toDate;
                    cmd.Parameters.Add("@HalfDay", SqlDbType.Bit).Value = halfDay;
                    cmd.Parameters.Add("@AttachmentPath", SqlDbType.NVarChar).Value = (object)medicalDocumentPath ?? DBNull.Value;

                    conn.Open();
                    return cmd.ExecuteNonQuery() > 0;
                }
            }
        }

        public bool AddLeaveRequest(int userId, int leaveTypeId, DateTime fromDate, DateTime toDate, bool halfDay, string medicalDocumentPath)
        {
            string leaveTypeStr = "Платен";
            if (leaveTypeId == 2) leaveTypeStr = "Неплатен";
            else if (leaveTypeId == 3) leaveTypeStr = "Болничен";

            return AddLeaveRequest(userId, leaveTypeStr, fromDate, toDate, halfDay, medicalDocumentPath);
        }

        public DataTable GetLeavesByUserId(int userId)
        {
            string query = @"
                SELECT 
                    v.Id AS LeaveRequestId,
                    v.LeaveType AS [Вид отпуск],
                    v.DateFrom AS [Начална дата],
                    v.DateTo AS [Крайна дата],
                    v.Status AS [Статус],
                    v.CreationDate AS [Дата на заявяване]
                FROM Vacations v
                WHERE v.RequesterId = @UserId
                ORDER BY v.CreationDate DESC";

            DataTable dt = new DataTable();
            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                using (SqlCommand cmd = new SqlCommand(query, conn))
                {
                    cmd.Parameters.Add("@UserId", SqlDbType.Int).Value = userId;
                    SqlDataAdapter adapter = new SqlDataAdapter(cmd);
                    adapter.Fill(dt);
                }
            }
            return dt;
        }

        public DataTable GetAllLeaves(string searchText = "")
        {
            string query = @"
                SELECT 
                    v.Id AS LeaveRequestId, 
                    u.FirstName + ' ' + u.LastName AS [Служител], 
                    v.DateFrom AS [Начална дата], 
                    v.DateTo AS [Крайна дата], 
                    v.CreationDate AS [Дата на заявяване],
                    v.LeaveType AS [Тип],
                    v.Status AS [Status], 
                    v.HalfDay AS [Половин ден],
                    v.AttachmentPath AS MedicalDocument
                FROM Vacations v
                INNER JOIN Users u ON v.RequesterId = u.Id
                WHERE 1 = 1";

            if (!string.IsNullOrWhiteSpace(searchText))
            {
                query += " AND (u.FirstName LIKE @Search OR u.LastName LIKE @Search OR u.Username LIKE @Search)";
            }

            query += " ORDER BY v.CreationDate DESC";

            DataTable dt = new DataTable();
            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                using (SqlCommand cmd = new SqlCommand(query, conn))
                {
                    if (!string.IsNullOrWhiteSpace(searchText))
                        cmd.Parameters.Add("@Search", SqlDbType.NVarChar).Value = "%" + searchText + "%";

                    SqlDataAdapter adapter = new SqlDataAdapter(cmd);
                    adapter.Fill(dt);
                }
            }
            return dt;
        }

        public DataTable GetLeavesByTeamId(int teamId, string searchText = "")
        {
            string query = @"
                SELECT 
                    v.Id AS LeaveRequestId, 
                    u.FirstName + ' ' + u.LastName AS [Служител], 
                    v.DateFrom AS [Начална дата], 
                    v.DateTo AS [Крайна дата], 
                    v.CreationDate AS [Дата на заявяване],
                    v.LeaveType AS [Тип],
                    v.Status AS [Status], 
                    v.HalfDay AS [Половин ден],
                    v.AttachmentPath AS MedicalDocument
                FROM Vacations v
                INNER JOIN Users u ON v.RequesterId = u.Id
                WHERE u.TeamId = @TeamId";

            if (!string.IsNullOrWhiteSpace(searchText))
            {
                query += " AND (u.FirstName LIKE @Search OR u.LastName LIKE @Search OR u.Username LIKE @Search)";
            }

            query += " ORDER BY v.CreationDate DESC";

            DataTable dt = new DataTable();
            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                using (SqlCommand cmd = new SqlCommand(query, conn))
                {
                    cmd.Parameters.Add("@TeamId", SqlDbType.Int).Value = teamId;
                    if (!string.IsNullOrWhiteSpace(searchText))
                        cmd.Parameters.Add("@Search", SqlDbType.NVarChar).Value = "%" + searchText + "%";

                    SqlDataAdapter adapter = new SqlDataAdapter(cmd);
                    adapter.Fill(dt);
                }
            }
            return dt;
        }

        public bool UpdateLeaveStatus(int leaveRequestId, string newStatus)
        {
            string query = "UPDATE Vacations SET Status = @Status WHERE Id = @Id";

            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                using (SqlCommand cmd = new SqlCommand(query, conn))
                {
                    cmd.Parameters.Add("@Status", SqlDbType.NVarChar).Value = newStatus;
                    cmd.Parameters.Add("@Id", SqlDbType.Int).Value = leaveRequestId;

                    conn.Open();
                    return cmd.ExecuteNonQuery() > 0;
                }
            }
        }
    }
}