using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using VacationManager.Logic;

namespace Forms
{
    public partial class TeamDetailsForm : Form
    {
        private TeamService teamService = new TeamService();
        private DataTable teamsTable;
        private int currentIndex = 0;
        public TeamDetailsForm()
        {
            InitializeComponent();
            LoadTeams();
        }

        private void LoadTeams()
        {
            teamsTable = teamService.GetAllTeams();

            if (teamsTable.Rows.Count == 0)
            {
                lblTeamName.Text = "Няма екипи";
                lblTeamLeader.Text = "Няма ръководител";
                dgvTeamMembers.DataSource = null;
                dgvTeamProjects.DataSource = null;
                btnBack.Enabled = false;
                btnNext.Enabled = false;

                MessageBox.Show("Няма въведени екипи.");
                return;
            }

            currentIndex = 0;
            DisplayCurrentTeam();
        }

        private void DisplayCurrentTeam()
        {
            if (teamsTable == null || teamsTable.Rows.Count == 0)
            {
                return;
            }

            DataRow team = teamsTable.Rows[currentIndex];
            int teamId = Convert.ToInt32(team["TeamId"]);
            lblTeamName.Text = team["TeamName"].ToString();
            if (team["TeamLeader"] == DBNull.Value)
            {
                lblTeamLeader.Text = "Няма зададен ръководител";
            }
            else
            {
                lblTeamLeader.Text = team["TeamLeader"].ToString();
            }

            dgvTeamMembers.DataSource = teamService.GetTeamMembers(teamId);
            dgvTeamProjects.DataSource = teamService.GetTeamProjects(teamId);
            btnBack.Enabled = currentIndex > 0;
            btnNext.Enabled = currentIndex < teamsTable.Rows.Count - 1;
        }

        private void btnRefresh_Click(object sender, EventArgs e)
        {
            int previousTeamId = -1;

            if (teamsTable != null && teamsTable.Rows.Count > 0)
            {
                previousTeamId = Convert.ToInt32(teamsTable.Rows[currentIndex]["TeamId"]);
            }

            teamsTable = teamService.GetAllTeams();

            if (teamsTable.Rows.Count == 0)
            {
                dgvTeamMembers.DataSource = null;
                dgvTeamProjects.DataSource = null;
                lblTeamName.Text = "Няма екипи";
                lblTeamLeader.Text = "Няма ръководител";
                btnBack.Enabled = false;
                btnNext.Enabled = false;
                return;
            }

            currentIndex = 0;

            for (int i = 0; i < teamsTable.Rows.Count; i++)
            {
                if (Convert.ToInt32(teamsTable.Rows[i]["TeamId"]) == previousTeamId)
                {
                    currentIndex = i;
                    break;
                }
            }

            DisplayCurrentTeam();
        }

        private void btnNext_Click(object sender, EventArgs e)
        {
            if (currentIndex < teamsTable.Rows.Count - 1)
            {
                currentIndex++;
                DisplayCurrentTeam();
            }
        }

        private void btnBack_Click(object sender, EventArgs e)
        {
            if (currentIndex > 0)
            {
                currentIndex--;
                DisplayCurrentTeam();
            }
        }

        private void dgvTeamMembers_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }
    }
}
