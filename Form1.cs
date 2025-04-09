using System;
using System.IO;
using System.Text.RegularExpressions;
using System.Windows.Forms;

namespace StudentRecordApp
{
    public partial class StudentInfoForm : Form
    {
        public StudentInfoForm()
        {
            InitializeComponent();
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            // Validate all fields before saving
            if (ValidateAllFields())
            {
                // Format the data
                string studentData = $"{txtIDNumber.Text},{txtFirstName.Text},{txtLastName.Text},{txtMiddleName.Text},{txtCourse.Text},{txtYearLevel.Text},{txtBirthday.Text}";

                try
                {
                    // Append data to the file
                    using (StreamWriter writer = new StreamWriter("student_record.txt", true))
                    {
                        writer.WriteLine(studentData);
                    }

                    MessageBox.Show("Student information saved successfully!", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    ClearAllFields();
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"Error saving data: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private bool ValidateAllFields()
        {
            // Validate ID Number (numbers only)
            if (string.IsNullOrWhiteSpace(txtIDNumber.Text) || !Regex.IsMatch(txtIDNumber.Text, @"^\d+$"))
            {
                MessageBox.Show("ID Number must contain only numbers.", "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtIDNumber.Focus();
                return false;
            }

            // Validate First Name (no special characters)
            if (string.IsNullOrWhiteSpace(txtFirstName.Text) || !Regex.IsMatch(txtFirstName.Text, @"^[a-zA-Z\s]+$"))
            {
                MessageBox.Show("First Name must not contain special characters.", "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtFirstName.Focus();
                return false;
            }

            // Validate Last Name (no special characters)
            if (string.IsNullOrWhiteSpace(txtLastName.Text) || !Regex.IsMatch(txtLastName.Text, @"^[a-zA-Z\s]+$"))
            {
                MessageBox.Show("Last Name must not contain special characters.", "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtLastName.Focus();
                return false;
            }

            // Validate Middle Name (no special characters) - optional
            if (!string.IsNullOrWhiteSpace(txtMiddleName.Text) && !Regex.IsMatch(txtMiddleName.Text, @"^[a-zA-Z\s]+$"))
            {
                MessageBox.Show("Middle Name must not contain special characters.", "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtMiddleName.Focus();
                return false;
            }

            // Validate Course (no special characters)
            if (string.IsNullOrWhiteSpace(txtCourse.Text) || !Regex.IsMatch(txtCourse.Text, @"^[a-zA-Z\s]+$"))
            {
                MessageBox.Show("Course must not contain special characters.", "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtCourse.Focus();
                return false;
            }

            // Validate Year Level (numbers only)
            if (string.IsNullOrWhiteSpace(txtYearLevel.Text) || !Regex.IsMatch(txtYearLevel.Text, @"^\d+$"))
            {
                MessageBox.Show("Year Level must contain only numbers.", "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtYearLevel.Focus();
                return false;
            }

            // Validate Birthday format (Year/Month/Day)
            if (string.IsNullOrWhiteSpace(txtBirthday.Text) || !Regex.IsMatch(txtBirthday.Text, @"^\d{2}/\d{1,2}/\d{1,2}$"))
            {
                MessageBox.Show("Birthday must be in the format Month/Day/Year (MM/DD/YY).", "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtBirthday.Focus();
                return false;
            }

            return true;
        }

        private void ClearAllFields()
        {
            txtIDNumber.Clear();
            txtFirstName.Clear();
            txtLastName.Clear();
            txtMiddleName.Clear();
            txtCourse.Clear();
            txtYearLevel.Clear();
            txtBirthday.Clear();
            txtIDNumber.Focus();
        }

        private void btnClear_Click(object sender, EventArgs e)
        {
            ClearAllFields();
        }

        private void label9_Click(object sender, EventArgs e)
        {

        }
    }
}
