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
using System.IO;
using System.Diagnostics;

namespace Forms
{
    public partial class LeaveApprovalsForm : Form
    {
        private LeaveService leaveService = new LeaveService();
        private DataTable leavesTable;
        private string roleName;
        private int teamId;
        private int userId;

        public LeaveApprovalsForm(string roleName, int teamId, int userId)
        {
            InitializeComponent();

            this.roleName = roleName;
            this.teamId = teamId;
            this.userId = userId;

            cmbStatusFilter.Items.Clear();
            cmbStatusFilter.Items.Add("Всички");
            cmbStatusFilter.Items.Add("Чакаща");
            cmbStatusFilter.Items.Add("Одобрена");
            cmbStatusFilter.Items.Add("Отказана");

            cmbStatusFilter.SelectedIndex = 0;

            LoadLeaves();
        }

        private void LoadLeaves()
        {
            if (roleName == "CEO")
            {
                leavesTable = leaveService.GetAllLeaves();
            }
            else if (roleName == "Team Lead")
            {
                if (teamId <= 0)
                {
                    MessageBox.Show("Нямаш назначен екип.");
                    leavesTable = new DataTable();
                }
                else
                {
                    leavesTable = leaveService.GetLeavesByTeamId(teamId);
                }
            }
            else
            {
                leavesTable = new DataTable();
            }

            FilterLeaves();
        }

        private void FilterLeaves()
        {
            if (leavesTable == null)
            {
                return;
            }

            DataTable filteredTable = leavesTable.Clone();

            string selectedStatus = cmbStatusFilter.Text;

            foreach (DataRow row in leavesTable.Rows)
            {
                if (selectedStatus == "Всички" ||
                    row["Status"].ToString() == selectedStatus)
                {
                    filteredTable.ImportRow(row);
                }
            }

            dgvLeaves.DataSource = filteredTable;

            if (dgvLeaves.Columns.Contains("MedicalDocument"))
            {
                dgvLeaves.Columns["MedicalDocument"].Visible = false;
            }

            if (dgvLeaves.Columns.Contains("LeaveRequestId"))
            {
                dgvLeaves.Columns["LeaveRequestId"].Visible = false;
            }

            lblMessage.Text = "Брой заявки: " +
                filteredTable.Rows.Count;
        }

        private void ChangeStatus(string status)
        {
            if (dgvLeaves.CurrentRow == null)
            {
                MessageBox.Show("Избери заявка от таблицата.");
                return;
            }

            if (!dgvLeaves.Columns.Contains("LeaveRequestId") ||
                dgvLeaves.CurrentRow.Cells["LeaveRequestId"].Value == null ||
                dgvLeaves.CurrentRow.Cells["LeaveRequestId"].Value == DBNull.Value)
            {
                MessageBox.Show("Не може да се определи избраната заявка.");
                return;
            }

            int leaveRequestId = Convert.ToInt32(dgvLeaves.CurrentRow.Cells["LeaveRequestId"].Value);

            string currentStatus = dgvLeaves.CurrentRow.Cells["Status"].Value.ToString();


            if (currentStatus == "Отказана")
            {
                MessageBox.Show(
                    "Тази заявка вече е отказана.");
                return;
            }

            DialogResult answer = MessageBox.Show(
                "Сигурен ли си, че искаш да промениш статуса на заявката на „"
                + status + "“?",
                "Потвърждение",
                MessageBoxButtons.YesNo,
                MessageBoxIcon.Question);

            if (answer == DialogResult.No)
            {
                return;
            }

            bool updated = leaveService.UpdateLeaveStatus(leaveRequestId, status);

            if (updated)
            {
                lblMessage.Text = "Статусът е променен на „" + status + "“.";

                LoadLeaves();
            }
            else
            {
                lblMessage.Text = "Статусът не беше променен.";
            }
        }

        private void btnApprove_Click(object sender, EventArgs e)
        {
            ChangeStatus("Одобрена");
        }

        private void cmbStatusFilter_SelectedIndexChanged(object sender, EventArgs e)
        {
            FilterLeaves();
        }

        private void btnRefresh_Click(object sender, EventArgs e)
        {
            LoadLeaves();
            lblMessage.Text = "Данните са обновени.";
        }

        private void btnReject_Click(object sender, EventArgs e)
        {
            ChangeStatus("Отказана");
        }

        private void btnOpenMedicalDocument_Click(object sender, EventArgs e)
        {
            if (dgvLeaves.CurrentRow == null)
            {
                MessageBox.Show("Избери заявка от таблицата.");
                return;
            }

            if (!dgvLeaves.Columns.Contains("MedicalDocument"))
            {
                MessageBox.Show(
                    "Не е намерена информация за медицинския документ.");
                return;
            }

            object documentValue =
                dgvLeaves.CurrentRow.Cells["MedicalDocument"].Value;

            if (documentValue == null ||
                documentValue == DBNull.Value ||
                string.IsNullOrWhiteSpace(documentValue.ToString()))
            {
                MessageBox.Show(
                    "За тази заявка няма прикачен медицински документ.");
                return;
            }

            string relativePath = documentValue.ToString();

            string fullPath = Path.Combine(
                Application.StartupPath, relativePath);

            if (!File.Exists(fullPath))
            {
                MessageBox.Show(
                    "Файлът не е намерен. Възможно е да е преместен или изтрит.");
                return;
            }

            try
            {
                Process.Start(new ProcessStartInfo
                {
                    FileName = fullPath,
                    UseShellExecute = true
                });
            }
            catch (Exception ex)
            {
                MessageBox.Show(
                    "Документът не може да бъде отворен.\n" + ex.Message);
            }
        }
    }
}
