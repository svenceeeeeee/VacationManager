namespace Forms
{
    partial class UsersForm
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
            dgvUsers = new DataGridView();
            txtSearchFirstName = new TextBox();
            txtSearchLastName = new TextBox();
            label2 = new Label();
            label3 = new Label();
            cmbFilterRole = new ComboBox();
            label4 = new Label();
            btnAdd = new Button();
            btnEdit = new Button();
            btnDelete = new Button();
            label5 = new Label();
            btnRefresh = new Button();
            btnSearch = new Button();
            btnClear = new Button();
            label1 = new Label();
            txtSearchUsername = new TextBox();
            btnLeaveApprovals = new Button();
            ((System.ComponentModel.ISupportInitialize)dgvUsers).BeginInit();
            SuspendLayout();
            // 
            // dgvUsers
            // 
            dgvUsers.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dgvUsers.Location = new Point(48, 64);
            dgvUsers.Margin = new Padding(4);
            dgvUsers.Name = "dgvUsers";
            dgvUsers.RowHeadersWidth = 51;
            dgvUsers.Size = new Size(678, 291);
            dgvUsers.TabIndex = 0;
            dgvUsers.CellContentClick += dgvUsers_CellContentClick;
            // 
            // txtSearchFirstName
            // 
            txtSearchFirstName.Location = new Point(820, 173);
            txtSearchFirstName.Margin = new Padding(4);
            txtSearchFirstName.Name = "txtSearchFirstName";
            txtSearchFirstName.Size = new Size(268, 31);
            txtSearchFirstName.TabIndex = 3;
            // 
            // txtSearchLastName
            // 
            txtSearchLastName.Location = new Point(804, 253);
            txtSearchLastName.Margin = new Padding(4);
            txtSearchLastName.Name = "txtSearchLastName";
            txtSearchLastName.Size = new Size(308, 31);
            txtSearchLastName.TabIndex = 4;
            txtSearchLastName.TextChanged += txtSearchLastName_TextChanged;
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Font = new Font("Sitka Small", 10.8F);
            label2.Location = new Point(856, 137);
            label2.Margin = new Padding(4, 0, 4, 0);
            label2.Name = "label2";
            label2.Size = new Size(195, 32);
            label2.TabIndex = 5;
            label2.Text = "Търсене по име";
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Font = new Font("Sitka Small", 10.8F);
            label3.Location = new Point(832, 217);
            label3.Margin = new Padding(4, 0, 4, 0);
            label3.Name = "label3";
            label3.Size = new Size(256, 32);
            label3.TabIndex = 6;
            label3.Text = "Търсене по фамилия";
            // 
            // cmbFilterRole
            // 
            cmbFilterRole.FormattingEnabled = true;
            cmbFilterRole.Location = new Point(844, 337);
            cmbFilterRole.Margin = new Padding(4);
            cmbFilterRole.Name = "cmbFilterRole";
            cmbFilterRole.Size = new Size(232, 33);
            cmbFilterRole.TabIndex = 7;
            cmbFilterRole.SelectedIndexChanged += cmbFilterRole_SelectedIndexChanged;
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Font = new Font("Sitka Small", 10.8F);
            label4.Location = new Point(868, 301);
            label4.Margin = new Padding(4, 0, 4, 0);
            label4.Name = "label4";
            label4.Size = new Size(199, 32);
            label4.TabIndex = 8;
            label4.Text = "Филтър по роля";
            // 
            // btnAdd
            // 
            btnAdd.Font = new Font("Tahoma", 10.8F);
            btnAdd.Location = new Point(48, 405);
            btnAdd.Margin = new Padding(4);
            btnAdd.Name = "btnAdd";
            btnAdd.Size = new Size(181, 49);
            btnAdd.TabIndex = 9;
            btnAdd.Text = "Добавяне";
            btnAdd.UseVisualStyleBackColor = true;
            btnAdd.Click += btnAdd_Click;
            // 
            // btnEdit
            // 
            btnEdit.Font = new Font("Tahoma", 10.8F);
            btnEdit.Location = new Point(449, 405);
            btnEdit.Margin = new Padding(4);
            btnEdit.Name = "btnEdit";
            btnEdit.Size = new Size(175, 49);
            btnEdit.TabIndex = 10;
            btnEdit.Text = "Редактиране";
            btnEdit.UseVisualStyleBackColor = true;
            btnEdit.Click += btnEdit_Click;
            // 
            // btnDelete
            // 
            btnDelete.Font = new Font("Tahoma", 10.8F);
            btnDelete.Location = new Point(241, 405);
            btnDelete.Margin = new Padding(4);
            btnDelete.Name = "btnDelete";
            btnDelete.Size = new Size(182, 49);
            btnDelete.TabIndex = 11;
            btnDelete.Text = "Изтриване";
            btnDelete.UseVisualStyleBackColor = true;
            btnDelete.Click += btnDelete_Click;
            // 
            // label5
            // 
            label5.AutoSize = true;
            label5.Font = new Font("Times New Roman", 16F, FontStyle.Regular, GraphicsUnit.Point, 204);
            label5.Location = new Point(255, 24);
            label5.Margin = new Padding(4, 0, 4, 0);
            label5.Name = "label5";
            label5.Size = new Size(192, 36);
            label5.TabIndex = 15;
            label5.Text = "Потребители";
            // 
            // btnRefresh
            // 
            btnRefresh.Font = new Font("Tahoma", 10.8F);
            btnRefresh.Location = new Point(55, 546);
            btnRefresh.Margin = new Padding(4);
            btnRefresh.Name = "btnRefresh";
            btnRefresh.Size = new Size(135, 41);
            btnRefresh.TabIndex = 16;
            btnRefresh.Text = "Обнови";
            btnRefresh.UseVisualStyleBackColor = true;
            // 
            // btnSearch
            // 
            btnSearch.Font = new Font("Tahoma", 10.8F);
            btnSearch.Location = new Point(867, 391);
            btnSearch.Margin = new Padding(4);
            btnSearch.Name = "btnSearch";
            btnSearch.Size = new Size(184, 76);
            btnSearch.TabIndex = 17;
            btnSearch.Text = "Търсене / Филтриране";
            btnSearch.UseVisualStyleBackColor = true;
            btnSearch.Click += btnSearch_Click;
            // 
            // btnClear
            // 
            btnClear.Font = new Font("Tahoma", 10.8F);
            btnClear.Location = new Point(55, 496);
            btnClear.Margin = new Padding(4);
            btnClear.Name = "btnClear";
            btnClear.Size = new Size(174, 42);
            btnClear.TabIndex = 18;
            btnClear.Text = "Изчисти";
            btnClear.UseVisualStyleBackColor = true;
            btnClear.Click += btnClear_Click;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new Font("Sitka Small", 10.8F);
            label1.Location = new Point(776, 54);
            label1.Margin = new Padding(4, 0, 4, 0);
            label1.Name = "label1";
            label1.Size = new Size(374, 32);
            label1.TabIndex = 2;
            label1.Text = "Търсене по потребителско име";
            // 
            // txtSearchUsername
            // 
            txtSearchUsername.Location = new Point(776, 90);
            txtSearchUsername.Margin = new Padding(4);
            txtSearchUsername.Name = "txtSearchUsername";
            txtSearchUsername.Size = new Size(374, 31);
            txtSearchUsername.TabIndex = 1;
            // 
            // btnLeaveApprovals
            // 
            btnLeaveApprovals.Font = new Font("Times New Roman", 12F, FontStyle.Regular, GraphicsUnit.Point, 204);
            btnLeaveApprovals.Location = new Point(55, 595);
            btnLeaveApprovals.Margin = new Padding(4);
            btnLeaveApprovals.Name = "btnLeaveApprovals";
            btnLeaveApprovals.Size = new Size(222, 46);
            btnLeaveApprovals.TabIndex = 20;
            btnLeaveApprovals.Text = "Заявки за отпуск";
            btnLeaveApprovals.UseVisualStyleBackColor = true;
            btnLeaveApprovals.Click += btnLeaveApprovals_Click;
            // 
            // UsersForm
            // 
            AutoScaleDimensions = new SizeF(10F, 25F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1224, 750);
            Controls.Add(btnLeaveApprovals);
            Controls.Add(btnClear);
            Controls.Add(btnSearch);
            Controls.Add(btnRefresh);
            Controls.Add(label5);
            Controls.Add(btnDelete);
            Controls.Add(btnEdit);
            Controls.Add(btnAdd);
            Controls.Add(label4);
            Controls.Add(cmbFilterRole);
            Controls.Add(label3);
            Controls.Add(label2);
            Controls.Add(txtSearchLastName);
            Controls.Add(txtSearchFirstName);
            Controls.Add(label1);
            Controls.Add(txtSearchUsername);
            Controls.Add(dgvUsers);
            Margin = new Padding(4);
            Name = "UsersForm";
            Text = "UsersForm";
            ((System.ComponentModel.ISupportInitialize)dgvUsers).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private DataGridView dgvUsers;
        private TextBox txtSearchFirstName;
        private TextBox txtSearchLastName;
        private Label label2;
        private Label label3;
        private ComboBox cmbFilterRole;
        private Label label4;
        private Button btnAdd;
        private Button btnEdit;
        private Button btnDelete;
        private Label label5;
        private Button btnRefresh;
        private Button btnSearch;
        private Button btnClear;
        private Label label1;
        private TextBox txtSearchUsername;
        private Button btnTeams;
        private Button btnLeaveApprovals;
    }
}