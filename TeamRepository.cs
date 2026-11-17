using Microsoft.Data.SqlClient;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VacationManager.Data
{
    public class TeamRepository
    {
        public DataTable GetAllTeams()
        {
            DataTable teams = new DataTable();
            connection connection1 = new connection();

            using (SqlConnection connection =connection1.GetConnection())
            {
                string query = @"
                    SELECT
                        Teams.TeamId,
                        Teams.TeamName,
                        Projects.ProjectName,
                        Teams.TeamLeaderId,
                        Users.FirstName + ' ' + Users.LastName AS TeamLeader
                    FROM Teams
                    LEFT JOIN Projects
                        ON Teams.ProjectId = Projects.ProjectId
                    LEFT JOIN Users
                        ON Teams.TeamLeaderId = Users.UserId
                    ORDER BY Teams.TeamId";

                using (SqlCommand command = new SqlCommand(query, connection))
                {
                    using (SqlDataAdapter adapter = new SqlDataAdapter(command))
                    {
                        adapter.Fill(teams);
                    }
                }
            }

            return teams;
        }

        public DataTable GetTeamMembers(int teamId)
        {
            DataTable members = new DataTable();
            connection connection1 = new connection();

            using (SqlConnection connection = connection1.GetConnection())
            {
                string query = @"
                    SELECT
                        Users.UserId,
                        Users.Username,
                        Users.FirstName,
                        Users.LastName,
                        Roles.RoleName
                    FROM TeamMembers
                    INNER JOIN Users
                        ON TeamMembers.UserId = Users.UserId
                    INNER JOIN Roles
                        ON Users.RoleId = Roles.RoleId
                    WHERE TeamMembers.TeamId = @TeamId
                    ORDER BY Users.FirstName, Users.LastName";

                using (SqlCommand command = new SqlCommand(query, connection))
                {
                    command.Parameters.AddWithValue("@TeamId", teamId);

                    using (SqlDataAdapter adapter = new SqlDataAdapter(command))
                    {
                        adapter.Fill(members);
                    }
                }
            }

            return members;
        }


        public DataTable GetTeamProjects(int teamId)
        {
            DataTable projects = new DataTable();
            connection connection1 = new connection();

            using (SqlConnection connection = connection1.GetConnection())
            {
                string query = @"
            SELECT Projects.ProjectId, Projects.ProjectName,
                   Projects.Description
            FROM ProjectTeams
            INNER JOIN Projects
                ON ProjectTeams.ProjectId = Projects.ProjectId
            WHERE ProjectTeams.TeamId = @TeamId
            ORDER BY Projects.ProjectName";

                using (SqlCommand command = new SqlCommand(query, connection))
                {
                    command.Parameters.AddWithValue("@TeamId", teamId);

                    using (SqlDataAdapter adapter = new SqlDataAdapter(command))
                    {
                        adapter.Fill(projects);
                    }
                }
            }

            return projects;
        }
    }
}
