namespace Forms
{
    partial class AddUserForm
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            lblTitle = new Label();
            lblUsername = new Label();
            txtUsername = new TextBox();
            lblPassword = new Label();
            txtPassword = new TextBox();
            lblFirstName = new Label();
            txtFirstName = new TextBox();
            lblLastName = new Label();
            txtLastName = new TextBox();
            lblRole = new Label();
            cmbRole = new ComboBox();
            lblTeam = new Label();
            cmbTeam = new ComboBox();
            btnSave = new Button();
            btnCancel = new Button();
            SuspendLayout();
            // 
            // lblTitle
            // 
            lblTitle.AutoSize = true;
            lblTitle.Font = new Font("Times New Roman", 16F, FontStyle.Regular, GraphicsUnit.Point, 204);
            lblTitle.Location = new Point(251, 9);
            lblTitle.Margin = new Padding(4, 0, 4, 0);
            lblTitle.Name = "lblTitle";
            lblTitle.Size = new Size(345, 36);
            lblTitle.TabIndex = 0;
            lblTitle.Text = "Добавяне на потребител";
            // 
            // lblUsername
            // 
            lblUsername.AutoSize = true;
            lblUsername.Font = new Font("Times New Roman", 11F, FontStyle.Regular, GraphicsUnit.Point, 0);
            lblUsername.Location = new Point(297, 56);
            lblUsername.Margin = new Padding(4, 0, 4, 0);
            lblUsername.Name = "lblUsername";
            lblUsername.Size = new Size(196, 25);
            lblUsername.TabIndex = 1;
            lblUsername.Text = "Потребителско име";
            // 
            // txtUsername
            // 
            txtUsername.Font = new Font("Verdana", 10.8F);
            txtUsername.Location = new Point(261, 85);
            txtUsername.Margin = new Padding(4, 4, 4, 4);
            txtUsername.Name = "txtUsername";
            txtUsername.Size = new Size(282, 34);
            txtUsername.TabIndex = 2;
            // 
            // lblPassword
            // 
            lblPassword.AutoSize = true;
            lblPassword.Font = new Font("Times New Roman", 11F, FontStyle.Regular, GraphicsUnit.Point, 0);
            lblPassword.Location = new Point(346, 133);
            lblPassword.Margin = new Padding(4, 0, 4, 0);
            lblPassword.Name = "lblPassword";
            lblPassword.Size = new Size(80, 25);
            lblPassword.TabIndex = 3;
            lblPassword.Text = "Парола";
            // 
            // txtPassword
            // 
            txtPassword.Font = new Font("Verdana", 10.8F);
            txtPassword.Location = new Point(261, 162);
            txtPassword.Margin = new Padding(4, 4, 4, 4);
            txtPassword.Name = "txtPassword";
            txtPassword.Size = new Size(282, 34);
            txtPassword.TabIndex = 4;
            // 
            // lblFirstName
            // 
            lblFirstName.AutoSize = true;
            lblFirstName.Font = new Font("Times New Roman", 11F, FontStyle.Regular, GraphicsUnit.Point, 0);
            lblFirstName.Location = new Point(363, 205);
            lblFirstName.Margin = new Padding(4, 0, 4, 0);
            lblFirstName.Name = "lblFirstName";
            lblFirstName.Size = new Size(51, 25);
            lblFirstName.TabIndex = 5;
            lblFirstName.Text = "Име";
            // 
            // txtFirstName
            // 
            txtFirstName.Font = new Font("Verdana", 10.8F);
            txtFirstName.Location = new Point(261, 234);
            txtFirstName.Margin = new Padding(4, 4, 4, 4);
            txtFirstName.Name = "txtFirstName";
            txtFirstName.Size = new Size(282, 34);
            txtFirstName.TabIndex = 6;
            // 
            // lblLastName
            // 
            lblLastName.AutoSize = true;
            lblLastName.Font = new Font("Times New Roman", 11F, FontStyle.Regular, GraphicsUnit.Point, 0);
            lblLastName.Location = new Point(346, 272);
            lblLastName.Margin = new Padding(4, 0, 4, 0);
            lblLastName.Name = "lblLastName";
            lblLastName.Size = new Size(98, 25);
            lblLastName.TabIndex = 7;
            lblLastName.Text = "Фамилия";
            // 
            // txtLastName
            // 
            txtLastName.Font = new Font("Verdana", 10.8F);
            txtLastName.Location = new Point(261, 301);
            txtLastName.Margin = new Padding(4, 4, 4, 4);
            txtLastName.Name = "txtLastName";
            txtLastName.Size = new Size(282, 34);
            txtLastName.TabIndex = 8;
            // 
            // lblRole
            // 
            lblRole.AutoSize = true;
            lblRole.Font = new Font("Times New Roman", 11F, FontStyle.Regular, GraphicsUnit.Point, 0);
            lblRole.Location = new Point(363, 339);
            lblRole.Margin = new Padding(4, 0, 4, 0);
            lblRole.Name = "lblRole";
            lblRole.Size = new Size(55, 25);
            lblRole.TabIndex = 9;
            lblRole.Text = "Роля";
            // 
            // cmbRole
            // 
            cmbRole.Font = new Font("Verdana", 10.8F);
            cmbRole.FormattingEnabled = true;
            cmbRole.Location = new Point(285, 368);
            cmbRole.Margin = new Padding(4, 4, 4, 4);
            cmbRole.Name = "cmbRole";
            cmbRole.Size = new Size(225, 34);
            cmbRole.TabIndex = 10;
            // 
            // lblTeam
            // 
            lblTeam.AutoSize = true;
            lblTeam.Font = new Font("Times New Roman", 11F, FontStyle.Regular, GraphicsUnit.Point, 0);
            lblTeam.Location = new Point(363, 406);
            lblTeam.Margin = new Padding(4, 0, 4, 0);
            lblTeam.Name = "lblTeam";
            lblTeam.Size = new Size(60, 25);
            lblTeam.TabIndex = 11;
            lblTeam.Text = "Екип";
            // 
            // cmbTeam
            // 
            cmbTeam.Font = new Font("Verdana", 10.8F);
            cmbTeam.FormattingEnabled = true;
            cmbTeam.Location = new Point(285, 435);
            cmbTeam.Margin = new Padding(4, 4, 4, 4);
            cmbTeam.Name = "cmbTeam";
            cmbTeam.Size = new Size(225, 34);
            cmbTeam.TabIndex = 12;
            // 
            // btnSave
            // 
            btnSave.BackColor = SystemColors.InactiveBorder;
            btnSave.Font = new Font("Times New Roman", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
            btnSave.Location = new Point(176, 495);
            btnSave.Margin = new Padding(4, 4, 4, 4);
            btnSave.Name = "btnSave";
            btnSave.Size = new Size(198, 60);
            btnSave.TabIndex = 13;
            btnSave.Text = "Запази";
            btnSave.UseVisualStyleBackColor = false;
            btnSave.Click += btnSave_Click;
            // 
            // btnCancel
            // 
            btnCancel.BackColor = SystemColors.InactiveBorder;
            btnCancel.Font = new Font("Times New Roman", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
            btnCancel.Location = new Point(405, 495);
            btnCancel.Margin = new Padding(4, 4, 4, 4);
            btnCancel.Name = "btnCancel";
            btnCancel.Size = new Size(200, 60);
            btnCancel.TabIndex = 14;
            btnCancel.Text = "Отказ";
            btnCancel.UseVisualStyleBackColor = false;
            // 
            // AddUserForm
            // 
            AutoScaleDimensions = new SizeF(10F, 25F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(806, 562);
            Controls.Add(btnCancel);
            Controls.Add(btnSave);
            Controls.Add(cmbTeam);
            Controls.Add(lblTeam);
            Controls.Add(cmbRole);
            Controls.Add(lblRole);
            Controls.Add(txtLastName);
            Controls.Add(lblLastName);
            Controls.Add(txtFirstName);
            Controls.Add(lblFirstName);
            Controls.Add(txtPassword);
            Controls.Add(lblPassword);
            Controls.Add(txtUsername);
            Controls.Add(lblUsername);
            Controls.Add(lblTitle);
            Margin = new Padding(4, 4, 4, 4);
            Name = "AddUserForm";
            Text = "AddUserForm";
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label lblTitle;
        private Label lblUsername;
        private TextBox txtUsername;
        private Label lblPassword;
        private TextBox txtPassword;
        private Label lblFirstName;
        private TextBox txtFirstName;
        private Label lblLastName;
        private TextBox txtLastName;
        private Label lblRole;
        private ComboBox cmbRole;
        private Label lblTeam;
        private ComboBox cmbTeam;
        private Button btnSave;
        private Button btnCancel;
    }
}