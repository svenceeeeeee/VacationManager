using System;
using System.Data;
using System.Windows.Forms;
using VacationManager.Logic;

namespace Forms
{
    public partial class LoginForm : Form
    {
        private AuthService authService = new AuthService();

        public LoginForm()
        {
            InitializeComponent();
            authService.ResetPassword("ceo", "ceo123");
            authService.ResetPassword("lead", "lead123");
            authService.ResetPassword("lead2", "lead123");
            authService.ResetPassword("dev", "dev123");
            authService.ResetPassword("dev2", "dev123");
            authService.ResetPassword("dev3", "dev123");
            authService.ResetPassword("guest", "guest123");
            authService.ResetPassword("guest2", "guest123");
        }


        

        private void btnLogin_Click(object sender, EventArgs e)
        {
            string username = txtUsername.Text.Trim();
            string password = txtPassword.Text;

            if (string.IsNullOrWhiteSpace(username))
            {
                lblError.Text = "Въведи потребителско име.";
                txtUsername.Focus();
                return;
            }

            if (string.IsNullOrWhiteSpace(password))
            {
                lblError.Text = "Въведи парола.";
                txtPassword.Focus();
                return;
            }

            try
            {
                DataTable user = authService.Login(username, password);

                if (user != null && user.Rows.Count > 0)
                {
                    lblError.Text = "";
                    string roleName = user.Rows[0]["RoleName"].ToString();
                    string firstName = user.Rows[0]["FirstName"].ToString();

                    MessageBox.Show( "Успешен вход!");

                    if (roleName == "CEO")
                    {
                        UsersForm usersForm = new UsersForm();
                        usersForm.Show();
                        this.Hide();
                    }
                    else if (roleName == "Team Lead")
                    {
                        int teamId = 0;
                        int userId = Convert.ToInt32(user.Rows[0]["UserId"]);

                        if (user.Rows[0]["TeamId"] != DBNull.Value)
                        {
                            teamId = Convert.ToInt32(user.Rows[0]["TeamId"]);
                        }

                        if (teamId > 0)
                        {
                            LeaveApprovalsForm leaveForm = new LeaveApprovalsForm(roleName, teamId, userId);
                            leaveForm.Show();
                            this.Hide();
                        }
                        else
                        {
                            MessageBox.Show(
                                "Нямаш назначен екип. Свържи се с администратора.",
                                "Ограничен достъп",
                                MessageBoxButtons.OK,
                                MessageBoxIcon.Warning);
                        }
                    }
                    else if (roleName == "Developer")
                    {
                        int userId = Convert.ToInt32(user.Rows[0]["UserId"]);
                        LeaveRequestForm requestForm = new LeaveRequestForm(userId);
                        requestForm.Show();
                        this.Hide();
                    }
                    else if (roleName == "Unassigned")
                    {
                        MessageBox.Show(
                            "Нямаш назначена роля. Свържи се с администратора.",
                            "Ограничен достъп",
                            MessageBoxButtons.OK,
                            MessageBoxIcon.Warning);
                    }
                }
                else
                {
                    lblError.Text = "Невалидно потребителско име или парола.";

                    string debugInfo = authService.CheckLoginProblem(username, password);
                    MessageBox.Show("Диагностика на грешката:\n\n" + debugInfo, "Инфо за проблема", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Грешка при връзка с базата данни:\n" + ex.Message, "Грешка", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}