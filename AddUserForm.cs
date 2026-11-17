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
    public partial class AddUserForm : Form
    { 
        public AddUserForm()
        {
            InitializeComponent();

            LoadRoles();
            LoadTeams();
        }

        public AddUserForm(int userId, string username, string firstName, string lastName, int roleId, int teamId)
        {
            InitializeComponent();

            this.userId = userId;
            editMode = true;

            LoadRoles();
            LoadTeams();

            txtUsername.Text = username;
            txtFirstName.Text = firstName;
            txtLastName.Text = lastName;

            cmbRole.SelectedValue = roleId;


            if (teamId > 0)
            {
                cmbTeam.SelectedValue = teamId;
            }
            else
            {
                cmbTeam.SelectedIndex = 0;
            }
            txtPassword.Text = "";

            this.Text = "Редактиране на потребител";
        }

        private UserService userService = new UserService();
        private int userId = 0;
        private bool editMode = false;

        private void btnSave_Click(object sender, EventArgs e)
        {
            string username = txtUsername.Text.Trim();
            string password = txtPassword.Text;
            string firstName = txtFirstName.Text.Trim();
            string lastName = txtLastName.Text.Trim();
            if (string.IsNullOrWhiteSpace(username))
            {
                MessageBox.Show("Въведи потребителско име.");
                txtUsername.Focus();
                return;
            }

            if (!editMode && string.IsNullOrWhiteSpace(password))
            {
                MessageBox.Show("Въведи парола.");
                txtPassword.Focus();
                return;
            }

            if (string.IsNullOrWhiteSpace(firstName))
            {
                MessageBox.Show("Въведи собствено име.");
                txtFirstName.Focus();
                return;
            }

            if (string.IsNullOrWhiteSpace(lastName))
            {
                MessageBox.Show("Въведи фамилия.");
                txtLastName.Focus();
                return;
            }

            if (cmbRole.SelectedValue == null)
            {
                MessageBox.Show("Избери роля.");
                cmbRole.Focus();
                return;
            }

            if (editMode && userId <= 0)
            {
                MessageBox.Show("Невалиден потребител за редактиране.");
                return;
            }

            int roleId;

            if (!int.TryParse(cmbRole.SelectedValue.ToString(), out roleId) || roleId <= 0)
            {
                MessageBox.Show("Избраната роля е невалидна.");
                return;
            }

            int teamId = 0;
            if (cmbTeam.SelectedValue != null &&
                cmbTeam.SelectedValue != DBNull.Value)
            {
                teamId = Convert.ToInt32(cmbTeam.SelectedValue);
            }

            bool result;

            if (editMode)
            {
                result = userService.UpdateUser(userId, username, password, firstName, lastName, roleId, teamId);               
            }
            else
            {
                result = userService.AddUser(username, password, firstName, lastName, roleId, teamId);
            }

            if (result)
            {
                if (editMode)
                {
                    MessageBox.Show("Потребителят е редактиран успешно.");
                }
                else
                {
                    MessageBox.Show("Потребителят е добавен успешно.");
                }
                this.DialogResult = DialogResult.OK;
                this.Close();
            }
            else
            {
                MessageBox.Show("Записът не беше успешен. Провери въведените данни и дали потребителското име вече е заето.");
            }
        }

        private void LoadRoles()
        {
            cmbRole.DataSource = userService.GetRoles();
            cmbRole.DisplayMember = "RoleName";
            cmbRole.ValueMember = "RoleId";
        }
        private void LoadTeams()
        {
            DataTable teams = userService.GetTeams();
            DataRow newRow = teams.NewRow();
            newRow["TeamId"] = DBNull.Value;
            newRow["TeamName"] = "Без екип";
            teams.Rows.InsertAt(newRow, 0);
            cmbTeam.DataSource = teams;
            cmbTeam.DisplayMember = "TeamName";
            cmbTeam.ValueMember = "TeamId";
        }
    }
}
