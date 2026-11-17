namespace Forms
{
    partial class TeamDetailsForm
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
            label1 = new Label();
            lblTeamName = new Label();
            lblTeamLeader = new Label();
            dgvTeamMembers = new DataGridView();
            dgvTeamProjects = new DataGridView();
            btnRefresh = new Button();
            btnBack = new Button();
            btnNext = new Button();
            label2 = new Label();
            label3 = new Label();
            ((System.ComponentModel.ISupportInitialize)dgvTeamMembers).BeginInit();
            ((System.ComponentModel.ISupportInitialize)dgvTeamProjects).BeginInit();
            SuspendLayout();
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new Font("Sitka Text", 16.1999989F, FontStyle.Bold, GraphicsUnit.Point, 204);
            label1.Location = new Point(40, 30);
            label1.Margin = new Padding(4, 0, 4, 0);
            label1.Name = "label1";
            label1.Size = new Size(402, 48);
            label1.TabIndex = 0;
            label1.Text = "Информация за екипа";
            // 
            // lblTeamName
            // 
            lblTeamName.AutoSize = true;
            lblTeamName.Font = new Font("Verdana", 10.2F, FontStyle.Regular, GraphicsUnit.Point, 204);
            lblTeamName.Location = new Point(484, 68);
            lblTeamName.Margin = new Padding(4, 0, 4, 0);
            lblTeamName.Name = "lblTeamName";
            lblTeamName.Size = new Size(177, 25);
            lblTeamName.TabIndex = 1;
            lblTeamName.Text = "(име на екипа)";
            // 
            // lblTeamLeader
            // 
            lblTeamLeader.AutoSize = true;
            lblTeamLeader.Font = new Font("Verdana", 10.2F, FontStyle.Regular, GraphicsUnit.Point, 204);
            lblTeamLeader.Location = new Point(738, 68);
            lblTeamLeader.Margin = new Padding(4, 0, 4, 0);
            lblTeamLeader.Name = "lblTeamLeader";
            lblTeamLeader.Size = new Size(274, 25);
            lblTeamLeader.TabIndex = 2;
            lblTeamLeader.Text = "(ръководител на екипа)";
            // 
            // dgvTeamMembers
            // 
            dgvTeamMembers.BackgroundColor = SystemColors.ScrollBar;
            dgvTeamMembers.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dgvTeamMembers.Location = new Point(42, 111);
            dgvTeamMembers.Margin = new Padding(4, 4, 4, 4);
            dgvTeamMembers.Name = "dgvTeamMembers";
            dgvTeamMembers.RowHeadersWidth = 51;
            dgvTeamMembers.Size = new Size(974, 191);
            dgvTeamMembers.TabIndex = 3;
            dgvTeamMembers.CellContentClick += dgvTeamMembers_CellContentClick;
            // 
            // dgvTeamProjects
            // 
            dgvTeamProjects.BackgroundColor = SystemColors.ScrollBar;
            dgvTeamProjects.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dgvTeamProjects.Location = new Point(42, 325);
            dgvTeamProjects.Margin = new Padding(4, 4, 4, 4);
            dgvTeamProjects.Name = "dgvTeamProjects";
            dgvTeamProjects.RowHeadersWidth = 51;
            dgvTeamProjects.Size = new Size(974, 179);
            dgvTeamProjects.TabIndex = 4;
            // 
            // btnRefresh
            // 
            btnRefresh.BackColor = SystemColors.ActiveCaption;
            btnRefresh.Font = new Font("Sitka Text", 10.8F, FontStyle.Bold);
            btnRefresh.Location = new Point(46, 530);
            btnRefresh.Margin = new Padding(4, 4, 4, 4);
            btnRefresh.Name = "btnRefresh";
            btnRefresh.Size = new Size(148, 48);
            btnRefresh.TabIndex = 5;
            btnRefresh.Text = "Обнови";
            btnRefresh.UseVisualStyleBackColor = false;
            btnRefresh.Click += btnRefresh_Click;
            // 
            // btnBack
            // 
            btnBack.BackColor = SystemColors.InactiveCaption;
            btnBack.Font = new Font("Sitka Text", 10.8F, FontStyle.Bold);
            btnBack.Location = new Point(215, 530);
            btnBack.Margin = new Padding(4, 4, 4, 4);
            btnBack.Name = "btnBack";
            btnBack.Size = new Size(129, 48);
            btnBack.TabIndex = 6;
            btnBack.Text = "Назад";
            btnBack.UseVisualStyleBackColor = false;
            btnBack.Click += btnBack_Click;
            // 
            // btnNext
            // 
            btnNext.BackColor = SystemColors.InactiveCaption;
            btnNext.Font = new Font("Sitka Text", 10.8F, FontStyle.Bold);
            btnNext.Location = new Point(365, 531);
            btnNext.Margin = new Padding(4, 4, 4, 4);
            btnNext.Name = "btnNext";
            btnNext.Size = new Size(136, 45);
            btnNext.TabIndex = 7;
            btnNext.Text = "Напред";
            btnNext.UseVisualStyleBackColor = false;
            btnNext.Click += btnNext_Click;
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Font = new Font("Verdana", 12F, FontStyle.Regular, GraphicsUnit.Point, 204);
            label2.Location = new Point(484, 21);
            label2.Margin = new Padding(4, 0, 4, 0);
            label2.Name = "label2";
            label2.Size = new Size(179, 29);
            label2.TabIndex = 8;
            label2.Text = "Име на екипа";
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Font = new Font("Verdana", 12F, FontStyle.Regular, GraphicsUnit.Point, 204);
            label3.Location = new Point(720, 21);
            label3.Margin = new Padding(4, 0, 4, 0);
            label3.Name = "label3";
            label3.Size = new Size(288, 29);
            label3.TabIndex = 9;
            label3.Text = "Ръководител на екипа";
            // 
            // TeamDetailsForm
            // 
            AutoScaleDimensions = new SizeF(10F, 25F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1081, 621);
            Controls.Add(label3);
            Controls.Add(label2);
            Controls.Add(btnNext);
            Controls.Add(btnBack);
            Controls.Add(btnRefresh);
            Controls.Add(dgvTeamProjects);
            Controls.Add(dgvTeamMembers);
            Controls.Add(lblTeamLeader);
            Controls.Add(lblTeamName);
            Controls.Add(label1);
            Margin = new Padding(4, 4, 4, 4);
            Name = "TeamDetailsForm";
            Text = "TeamDetailsForm";
            ((System.ComponentModel.ISupportInitialize)dgvTeamMembers).EndInit();
            ((System.ComponentModel.ISupportInitialize)dgvTeamProjects).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label label1;
        private Label lblTeamName;
        private Label lblTeamLeader;
        private DataGridView dgvTeamMembers;
        private DataGridView dgvTeamProjects;
        private Button btnRefresh;
        private Button btnBack;
        private Button btnNext;
        private Label label2;
        private Label label3;
    }
}