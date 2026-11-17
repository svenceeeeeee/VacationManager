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
    public partial class LeaveRequestForm : Form
    {
        private LeaveService leaveService = new LeaveService();
        private int userId;
        private string medicalDocumentPath = "";
        public LeaveRequestForm(int userId)
        {
            InitializeComponent();

            this.userId = userId;

            LoadLeaveTypes();
            UpdateMedicalDocumentControls();
            LoadMyLeaves();
        }

        private void LoadLeaveTypes()
        {
            DataTable leaveTypes = leaveService.GetLeaveTypes();

            cmbLeaveType.DataSource = leaveTypes;
            cmbLeaveType.DisplayMember = "LeaveTypeName";
            cmbLeaveType.ValueMember = "LeaveTypeId";
            cmbLeaveType.SelectedIndex = -1;
        }

        private void btnSubmit_Click(object sender, EventArgs e)
        {
            if (cmbLeaveType.SelectedIndex == -1)
            {
                lblMessage.Text = "Избери вид отпуск.";
                return;
            }

            bool isSickLeave = cmbLeaveType.Text.Trim() == "Sick" || cmbLeaveType.Text.Trim() == "Болничен";

            if (isSickLeave && string.IsNullOrWhiteSpace(medicalDocumentPath))
            {
                lblMessage.Text = "За болничен отпуск трябва да прикачиш документ.";
                return;
            }

            DateTime fromDate = dtpStartDate.Value.Date;
            DateTime toDate = dtpEndDate.Value.Date;

            if (fromDate < DateTime.Today)
            {
                lblMessage.Text = "Началната дата не може да бъде в миналото.";
                return;
            }

            if (fromDate > toDate)
            {
                lblMessage.Text = "Началната дата не може да е след крайната.";
                return;
            }

            string leaveType = cmbLeaveType.SelectedValue?.ToString() ?? cmbLeaveType.Text;
            bool halfDay = false;
            string savedMedicalDocument = "";

            try
            {
                if (isSickLeave)
                {
                    savedMedicalDocument = SaveMedicalDocument(medicalDocumentPath);
                }


                bool added = leaveService.AddLeaveRequest(userId, leaveType, fromDate, toDate, halfDay, savedMedicalDocument);

                if (added)
                {
                    lblMessage.Text = "Заявката е подадена успешно и чака одобрение.";

                    cmbLeaveType.SelectedIndex = -1;
                    medicalDocumentPath = "";
                    lblMedicalDocument.Text = "Няма избран файл";

                    LoadMyLeaves();
                }
                else
                {
                    lblMessage.Text = "Заявката не беше записана.";
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(
                    "Възникна грешка при записването на заявката:\n" + ex.Message,
                    "Грешка",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error);
            }
        }

        private void btnClear_Click(object sender, EventArgs e)
        {
            cmbLeaveType.SelectedIndex = -1;
            dtpStartDate.Value = DateTime.Today;
            dtpEndDate.Value = DateTime.Today;
            medicalDocumentPath = "";
            lblMedicalDocument.Text = "Няма избран файл";
            lblMessage.Text = "";
        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void LoadMyLeaves()
        {
            DataTable leaves = leaveService.GetLeavesByUserId(userId);
            dgvMyLeaves.DataSource = leaves;
            if (dgvMyLeaves.Columns.Contains("LeaveRequestId"))
            {
                dgvMyLeaves.Columns["LeaveRequestId"].Visible = false;
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            LoadMyLeaves();
        }

        private void btnAttachMedicalDocument_Click(object sender, EventArgs e)
        {
            if (cmbLeaveType.SelectedIndex == -1)
            {
                lblMessage.Text = "Първо избери вид отпуск.";
                return;
            }

            if (cmbLeaveType.Text.Trim() != "Sick")
            {
                lblMessage.Text = "Документ се прикачва само за болничен отпуск.";
                return;
            }

            openFileDialog1.Title = "Избери болничен документ";
            openFileDialog1.Filter = "Документи (*.pdf;*.jpg;*.jpeg;*.png)|*.pdf;*.jpg;*.jpeg;*.png";

            if (openFileDialog1.ShowDialog() == DialogResult.OK)
            {
                medicalDocumentPath = openFileDialog1.FileName;
                lblMedicalDocument.Text = System.IO.Path.GetFileName(medicalDocumentPath);
                lblMessage.Text = "Документът е избран.";
            }
        }


        private void UpdateMedicalDocumentControls()
        {
            bool isSickLeave = cmbLeaveType.Text.Trim() == "Sick";

            btnAttachMedicalDocument.Visible = isSickLeave;
            lblMedicalDocument.Visible = isSickLeave;

            if (!isSickLeave)
            {
                medicalDocumentPath = "";
                lblMedicalDocument.Text = "Няма избран файл";
            }
        }

        private void cmbLeaveType_SelectedIndexChanged(object sender, EventArgs e)
        {
            UpdateMedicalDocumentControls();
        }

        private string SaveMedicalDocument(string selectedFilePath)
        {
            if (string.IsNullOrWhiteSpace(selectedFilePath))
            {
                return "";
            }

            if (!File.Exists(selectedFilePath))
            {
                throw new FileNotFoundException("Избраният документ не беше намерен.");
            }

            string extension = Path.GetExtension(selectedFilePath).ToLower();

            if (extension != ".pdf" && extension != ".jpg" && extension != ".jpeg" && extension != ".png")
            {
                throw new Exception( "Разрешени са само PDF, JPG, JPEG и PNG файлове.");
            }

            string folderPath = Path.Combine(Application.StartupPath, "MedicalDocuments");

            Directory.CreateDirectory(folderPath);

            string fileName = Guid.NewGuid().ToString() + extension;
            string destinationPath = Path.Combine(folderPath, fileName);
            File.Copy(selectedFilePath, destinationPath, false);
            return Path.Combine("MedicalDocuments", fileName);
        }
    }
}
