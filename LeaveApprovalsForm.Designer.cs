namespace Forms
{
    partial class LeaveApprovalsForm
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
            cmbStatusFilter = new ComboBox();
            label2 = new Label();
            dgvLeaves = new DataGridView();
            btnApprove = new Button();
            btnReject = new Button();
            btnRefresh = new Button();
            lblMessage = new Label();
            btnOpenMedicalDocument = new Button();
            ((System.ComponentModel.ISupportInitialize)dgvLeaves).BeginInit();
            SuspendLayout();
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new Font("Times New Roman", 16F, FontStyle.Regular, GraphicsUnit.Point, 204);
            label1.Location = new Point(386, 9);
            label1.Margin = new Padding(4, 0, 4, 0);
            label1.Name = "label1";
            label1.Size = new Size(243, 36);
            label1.TabIndex = 0;
            label1.Text = "Заявки за отпуск";
            // 
            // cmbStatusFilter
            // 
            cmbStatusFilter.Font = new Font("Sitka Text", 10.1999989F, FontStyle.Regular, GraphicsUnit.Point, 0);
            cmbStatusFilter.FormattingEnabled = true;
            cmbStatusFilter.Location = new Point(360, 90);
            cmbStatusFilter.Margin = new Padding(4);
            cmbStatusFilter.Name = "cmbStatusFilter";
            cmbStatusFilter.Size = new Size(285, 37);
            cmbStatusFilter.TabIndex = 1;
            cmbStatusFilter.SelectedIndexChanged += cmbStatusFilter_SelectedIndexChanged;
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Font = new Font("Times New Roman", 10F, FontStyle.Regular, GraphicsUnit.Point, 204);
            label2.Location = new Point(424, 64);
            label2.Margin = new Padding(4, 0, 4, 0);
            label2.Name = "label2";
            label2.Size = new Size(160, 22);
            label2.TabIndex = 2;
            label2.Text = "Филтър по статус";
            // 
            // dgvLeaves
            // 
            dgvLeaves.BackgroundColor = SystemColors.ScrollBar;
            dgvLeaves.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dgvLeaves.Location = new Point(90, 180);
            dgvLeaves.Margin = new Padding(4);
            dgvLeaves.Name = "dgvLeaves";
            dgvLeaves.RowHeadersWidth = 51;
            dgvLeaves.Size = new Size(892, 218);
            dgvLeaves.TabIndex = 3;
            // 
            // btnApprove
            // 
            btnApprove.BackColor = SystemColors.ControlLight;
            btnApprove.Font = new Font("Times New Roman", 11F, FontStyle.Regular, GraphicsUnit.Point, 0);
            btnApprove.Location = new Point(327, 406);
            btnApprove.Margin = new Padding(4);
            btnApprove.Name = "btnApprove";
            btnApprove.Size = new Size(132, 44);
            btnApprove.TabIndex = 4;
            btnApprove.Text = "Одобри";
            btnApprove.UseVisualStyleBackColor = false;
            btnApprove.Click += btnApprove_Click;
            // 
            // btnReject
            // 
            btnReject.BackColor = SystemColors.ControlLight;
            btnReject.Font = new Font("Times New Roman", 11F, FontStyle.Regular, GraphicsUnit.Point, 0);
            btnReject.Location = new Point(467, 406);
            btnReject.Margin = new Padding(4);
            btnReject.Name = "btnReject";
            btnReject.Size = new Size(149, 44);
            btnReject.TabIndex = 5;
            btnReject.Text = "Отхвърли";
            btnReject.UseVisualStyleBackColor = false;
            btnReject.Click += btnReject_Click;
            // 
            // btnRefresh
            // 
            btnRefresh.BackColor = SystemColors.ControlLight;
            btnRefresh.Font = new Font("Times New Roman", 11F, FontStyle.Regular, GraphicsUnit.Point, 0);
            btnRefresh.Location = new Point(624, 406);
            btnRefresh.Margin = new Padding(4);
            btnRefresh.Name = "btnRefresh";
            btnRefresh.Size = new Size(135, 44);
            btnRefresh.TabIndex = 6;
            btnRefresh.Text = "Обнови";
            btnRefresh.UseVisualStyleBackColor = false;
            btnRefresh.Click += btnRefresh_Click;
            // 
            // lblMessage
            // 
            lblMessage.AutoSize = true;
            lblMessage.Font = new Font("Times New Roman", 11F, FontStyle.Regular, GraphicsUnit.Point, 204);
            lblMessage.Location = new Point(723, 515);
            lblMessage.Margin = new Padding(4, 0, 4, 0);
            lblMessage.Name = "lblMessage";
            lblMessage.Size = new Size(242, 25);
            lblMessage.TabIndex = 7;
            lblMessage.Text = "Съобщение за резултата";
            // 
            // btnOpenMedicalDocument
            // 
            btnOpenMedicalDocument.BackColor = SystemColors.ControlLight;
            btnOpenMedicalDocument.Font = new Font("Times New Roman", 11F, FontStyle.Regular, GraphicsUnit.Point, 0);
            btnOpenMedicalDocument.Location = new Point(351, 493);
            btnOpenMedicalDocument.Margin = new Padding(4);
            btnOpenMedicalDocument.Name = "btnOpenMedicalDocument";
            btnOpenMedicalDocument.Size = new Size(340, 68);
            btnOpenMedicalDocument.TabIndex = 8;
            btnOpenMedicalDocument.Text = "Отвори медицински документ";
            btnOpenMedicalDocument.UseVisualStyleBackColor = false;
            btnOpenMedicalDocument.Click += btnOpenMedicalDocument_Click;
            // 
            // LeaveApprovalsForm
            // 
            AutoScaleDimensions = new SizeF(10F, 25F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1072, 601);
            Controls.Add(btnOpenMedicalDocument);
            Controls.Add(lblMessage);
            Controls.Add(btnRefresh);
            Controls.Add(btnReject);
            Controls.Add(btnApprove);
            Controls.Add(dgvLeaves);
            Controls.Add(label2);
            Controls.Add(cmbStatusFilter);
            Controls.Add(label1);
            Margin = new Padding(4);
            Name = "LeaveApprovalsForm";
            Text = "LeaveApprovalsForm";
            ((System.ComponentModel.ISupportInitialize)dgvLeaves).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label label1;
        private ComboBox cmbStatusFilter;
        private Label label2;
        private DataGridView dgvLeaves;
        private Button btnApprove;
        private Button btnReject;
        private Button btnRefresh;
        private Label lblMessage;
        private Button btnOpenMedicalDocument;
    }
}