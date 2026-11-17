namespace Forms
{
    partial class LeaveRequestForm
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
            cmbLeaveType = new ComboBox();
            label2 = new Label();
            dtpStartDate = new DateTimePicker();
            dtpEndDate = new DateTimePicker();
            label3 = new Label();
            label4 = new Label();
            btnSubmit = new Button();
            btnClear = new Button();
            lblMessage = new Label();
            label7 = new Label();
            dgvMyLeaves = new DataGridView();
            button1 = new Button();
            btnAttachMedicalDocument = new Button();
            lblMedicalDocument = new Label();
            openFileDialog1 = new OpenFileDialog();
            ((System.ComponentModel.ISupportInitialize)dgvMyLeaves).BeginInit();
            SuspendLayout();
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new Font("Times New Roman", 16F, FontStyle.Regular, GraphicsUnit.Point, 204);
            label1.Location = new Point(171, 9);
            label1.Margin = new Padding(4, 0, 4, 0);
            label1.Name = "label1";
            label1.Size = new Size(313, 36);
            label1.TabIndex = 0;
            label1.Text = "Нова заявка за отпуск";
            // 
            // cmbLeaveType
            // 
            cmbLeaveType.Font = new Font("Sitka Text", 10.1999989F, FontStyle.Regular, GraphicsUnit.Point, 204);
            cmbLeaveType.FormattingEnabled = true;
            cmbLeaveType.Location = new Point(171, 86);
            cmbLeaveType.Margin = new Padding(4);
            cmbLeaveType.Name = "cmbLeaveType";
            cmbLeaveType.Size = new Size(265, 37);
            cmbLeaveType.TabIndex = 1;
            cmbLeaveType.SelectedIndexChanged += cmbLeaveType_SelectedIndexChanged;
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Font = new Font("Times New Roman", 11F, FontStyle.Regular, GraphicsUnit.Point, 0);
            label2.Location = new Point(237, 57);
            label2.Margin = new Padding(4, 0, 4, 0);
            label2.Name = "label2";
            label2.Size = new Size(120, 25);
            label2.TabIndex = 2;
            label2.Text = "Вид отпуск";
            label2.Click += label2_Click;
            // 
            // dtpStartDate
            // 
            dtpStartDate.CalendarFont = new Font("Sitka Text", 10.1999989F, FontStyle.Regular, GraphicsUnit.Point, 204);
            dtpStartDate.Location = new Point(130, 167);
            dtpStartDate.Margin = new Padding(4);
            dtpStartDate.Name = "dtpStartDate";
            dtpStartDate.Size = new Size(320, 31);
            dtpStartDate.TabIndex = 3;
            // 
            // dtpEndDate
            // 
            dtpEndDate.CalendarFont = new Font("Sitka Text", 10.1999989F, FontStyle.Regular, GraphicsUnit.Point, 204);
            dtpEndDate.Location = new Point(130, 240);
            dtpEndDate.Margin = new Padding(4);
            dtpEndDate.Name = "dtpEndDate";
            dtpEndDate.Size = new Size(320, 31);
            dtpEndDate.TabIndex = 4;
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Font = new Font("Times New Roman", 11F, FontStyle.Regular, GraphicsUnit.Point, 0);
            label3.Location = new Point(237, 138);
            label3.Margin = new Padding(4, 0, 4, 0);
            label3.Name = "label3";
            label3.Size = new Size(136, 25);
            label3.TabIndex = 5;
            label3.Text = "Начална дата";
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Font = new Font("Times New Roman", 11F, FontStyle.Regular, GraphicsUnit.Point, 0);
            label4.Location = new Point(237, 211);
            label4.Margin = new Padding(4, 0, 4, 0);
            label4.Name = "label4";
            label4.Size = new Size(128, 25);
            label4.TabIndex = 6;
            label4.Text = "Крайна дата";
            // 
            // btnSubmit
            // 
            btnSubmit.BackColor = SystemColors.ControlLight;
            btnSubmit.Font = new Font("Verdana", 10.8F);
            btnSubmit.Location = new Point(139, 400);
            btnSubmit.Margin = new Padding(4);
            btnSubmit.Name = "btnSubmit";
            btnSubmit.Size = new Size(332, 70);
            btnSubmit.TabIndex = 9;
            btnSubmit.Text = "Подай заявка";
            btnSubmit.UseVisualStyleBackColor = false;
            btnSubmit.Click += btnSubmit_Click;
            // 
            // btnClear
            // 
            btnClear.BackColor = SystemColors.ControlLight;
            btnClear.Font = new Font("Verdana", 10.8F);
            btnClear.Location = new Point(807, 463);
            btnClear.Margin = new Padding(4);
            btnClear.Name = "btnClear";
            btnClear.Size = new Size(149, 52);
            btnClear.TabIndex = 10;
            btnClear.Text = "Изчисти";
            btnClear.UseVisualStyleBackColor = false;
            btnClear.Click += btnClear_Click;
            // 
            // lblMessage
            // 
            lblMessage.AutoSize = true;
            lblMessage.Font = new Font("Verdana", 10.8F, FontStyle.Regular, GraphicsUnit.Point, 204);
            lblMessage.Location = new Point(13, 493);
            lblMessage.Margin = new Padding(4, 0, 4, 0);
            lblMessage.Name = "lblMessage";
            lblMessage.Size = new Size(283, 26);
            lblMessage.TabIndex = 11;
            lblMessage.Text = "Резултат от подаването";
            // 
            // label7
            // 
            label7.AutoSize = true;
            label7.Font = new Font("Times New Roman", 16F, FontStyle.Regular, GraphicsUnit.Point, 204);
            label7.Location = new Point(919, 35);
            label7.Margin = new Padding(4, 0, 4, 0);
            label7.Name = "label7";
            label7.Size = new Size(201, 36);
            label7.TabIndex = 13;
            label7.Text = "Моите заявки";
            // 
            // dgvMyLeaves
            // 
            dgvMyLeaves.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dgvMyLeaves.Location = new Point(653, 75);
            dgvMyLeaves.Margin = new Padding(4);
            dgvMyLeaves.Name = "dgvMyLeaves";
            dgvMyLeaves.RowHeadersWidth = 51;
            dgvMyLeaves.Size = new Size(778, 246);
            dgvMyLeaves.TabIndex = 14;
            // 
            // button1
            // 
            button1.BackColor = SystemColors.ControlLight;
            button1.Font = new Font("Verdana", 10.8F);
            button1.Location = new Point(971, 463);
            button1.Margin = new Padding(4);
            button1.Name = "button1";
            button1.Size = new Size(149, 52);
            button1.TabIndex = 15;
            button1.Text = "Обнови";
            button1.UseVisualStyleBackColor = false;
            button1.Click += button1_Click;
            // 
            // btnAttachMedicalDocument
            // 
            btnAttachMedicalDocument.BackColor = SystemColors.ControlLight;
            btnAttachMedicalDocument.Font = new Font("Times New Roman", 11F, FontStyle.Regular, GraphicsUnit.Point, 0);
            btnAttachMedicalDocument.Location = new Point(160, 289);
            btnAttachMedicalDocument.Margin = new Padding(4);
            btnAttachMedicalDocument.Name = "btnAttachMedicalDocument";
            btnAttachMedicalDocument.Size = new Size(290, 69);
            btnAttachMedicalDocument.TabIndex = 16;
            btnAttachMedicalDocument.Text = "Прикачи болничен документ";
            btnAttachMedicalDocument.UseVisualStyleBackColor = false;
            btnAttachMedicalDocument.Click += btnAttachMedicalDocument_Click;
            // 
            // lblMedicalDocument
            // 
            lblMedicalDocument.AutoSize = true;
            lblMedicalDocument.Font = new Font("Verdana", 10.8F, FontStyle.Regular, GraphicsUnit.Point, 204);
            lblMedicalDocument.Location = new Point(189, 362);
            lblMedicalDocument.Margin = new Padding(4, 0, 4, 0);
            lblMedicalDocument.Name = "lblMedicalDocument";
            lblMedicalDocument.Size = new Size(227, 26);
            lblMedicalDocument.TabIndex = 18;
            lblMedicalDocument.Text = "Няма избран файл";
            // 
            // openFileDialog1
            // 
            openFileDialog1.FileName = "openFileDialog1";
            // 
            // LeaveRequestForm
            // 
            AutoScaleDimensions = new SizeF(10F, 25F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1456, 528);
            Controls.Add(lblMedicalDocument);
            Controls.Add(btnAttachMedicalDocument);
            Controls.Add(button1);
            Controls.Add(dgvMyLeaves);
            Controls.Add(label7);
            Controls.Add(lblMessage);
            Controls.Add(btnClear);
            Controls.Add(btnSubmit);
            Controls.Add(label4);
            Controls.Add(label3);
            Controls.Add(dtpEndDate);
            Controls.Add(dtpStartDate);
            Controls.Add(label2);
            Controls.Add(cmbLeaveType);
            Controls.Add(label1);
            Margin = new Padding(4);
            Name = "LeaveRequestForm";
            Text = "LeaveRequestForm";
            ((System.ComponentModel.ISupportInitialize)dgvMyLeaves).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label label1;
        private ComboBox cmbLeaveType;
        private Label label2;
        private DateTimePicker dtpStartDate;
        private DateTimePicker dtpEndDate;
        private Label label3;
        private Label label4;
        private Button btnSubmit;
        private Button btnClear;
        private Label lblMessage;
        private Label label7;
        private DataGridView dgvMyLeaves;
        private Button button1;
        private Button btnAttachMedicalDocument;
        private Label lblMedicalDocument;
        private OpenFileDialog openFileDialog1;
    }
}