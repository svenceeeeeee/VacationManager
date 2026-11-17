using System;
using System.Data;
using System.Windows.Forms;
using VacationManager.Logic;

namespace Forms
{
    public partial class UsersForm : Form
    {
        private UserService userService = new UserService();
        private DataTable usersTable;

        private int currentPage = 1;
        private int pageSize = 10;

        public UsersForm()
        {
            InitializeComponent();

            dgvUsers.AutoGenerateColumns = true;
            cmbFilterRole.Items.Clear();
            cmbFilterRole.Items.Add("Всички");
            cmbFilterRole.Items.Add("CEO");
            cmbFilterRole.Items.Add("Team Lead");
            cmbFilterRole.Items.Add("Developer");
            cmbFilterRole.Items.Add("Unassigned");
            cmbFilterRole.SelectedIndex = 0;
            LoadAllUsers();
        }

        private void LoadAllUsers()
        {
            usersTable = userService.GetAllUsers();
            currentPage = 1;
            DisplayCurrentPage();
        }

        private void SearchUsers()
        {
            string username = txtSearchUsername.Text.Trim();
            string firstName = txtSearchFirstName.Text.Trim();
            string lastName = txtSearchLastName.Text.Trim();
            string roleName = cmbFilterRole.Text;

            usersTable = userService.SearchUsers(username, firstName, lastName, roleName);
            currentPage = 1;
            DisplayCurrentPage();
        }

        private void DisplayCurrentPage()
        {
            if (usersTable == null || usersTable.Rows.Count == 0)
            {
                dgvUsers.DataSource = null;
                return;
            }

            if (pageSize <= 0) pageSize = 10;

            DataTable pageTable = usersTable.Clone();
            int startIndex = (currentPage - 1) * pageSize;
            int endIndex = startIndex + pageSize;

            if (endIndex > usersTable.Rows.Count)
            {
                endIndex = usersTable.Rows.Count;
            }

            for (int i = startIndex; i < endIndex; i++)
            {
                pageTable.ImportRow(usersTable.Rows[i]);
            }

            dgvUsers.DataSource = pageTable;

            int totalPages = (int)Math.Ceiling((double)usersTable.Rows.Count / pageSize);
            if (totalPages == 0) totalPages = 1;

           
        }


        private void btnSearch_Click(object sender, EventArgs e)
        {
            SearchUsers();
        }

        private void btnClear_Click(object sender, EventArgs e)
        {
            txtSearchUsername.Text = "";
            txtSearchFirstName.Text = "";
            txtSearchLastName.Text = "";
            cmbFilterRole.SelectedIndex = 0;
            LoadAllUsers();
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            AddUserForm addUserForm = new AddUserForm();
            if (addUserForm.ShowDialog() == DialogResult.OK)
            {
                LoadAllUsers();
            }
        }

        private void btnEdit_Click(object sender, EventArgs e)
        {
            if (dgvUsers.CurrentRow == null)
            {
                MessageBox.Show("Моля, изберете потребител за редактиране.");
                return;
            }

            int userId = Convert.ToInt32(dgvUsers.CurrentRow.Cells["Id"].Value);
            string username = dgvUsers.CurrentRow.Cells["Username"].Value.ToString();
            string firstName = dgvUsers.CurrentRow.Cells["FirstName"].Value.ToString();
            string lastName = dgvUsers.CurrentRow.Cells["LastName"].Value.ToString();
            int roleId = 1;
            int teamId = 0;

            AddUserForm editUserForm = new AddUserForm(userId, username, firstName, lastName, roleId, teamId);
            if (editUserForm.ShowDialog() == DialogResult.OK)
            {
                LoadAllUsers();
            }
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            if (dgvUsers.CurrentRow == null)
            {
                MessageBox.Show("Моля, изберете потребител за изтриване.");
                return;
            }

            int userId = Convert.ToInt32(dgvUsers.CurrentRow.Cells["Id"].Value);

            DialogResult confirm = MessageBox.Show("Сигурни ли сте, че искате да изтриете този потребител?", "Потвърждение", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

            if (confirm == DialogResult.Yes)
            {
                bool deleted = userService.DeleteUser(userId);
                if (deleted)
                {
                    MessageBox.Show("Потребителят е изтрит успешно.");
                    LoadAllUsers();
                }
                else
                {
                    MessageBox.Show("Грешка при изтриване на потребителя.");
                }
            }
        }


        private void dgvUsers_CellContentClick(object sender, DataGridViewCellEventArgs e) { }
        private void txtSearchLastName_TextChanged(object sender, EventArgs e) { }
        private void cmbFilterRole_SelectedIndexChanged(object sender, EventArgs e) { }
       
        private void btnLeaveApprovals_Click(object sender, EventArgs e) { }
    }
}