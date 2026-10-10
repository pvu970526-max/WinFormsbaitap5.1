using System;
using System.Windows.Forms;

namespace WinFormsApp10
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
            // sensible defaults
            rbMale.Checked = true;
            dtpBirth.Value = DateTime.Today.AddYears(-18);
        }

        private void btnRegister_Click(object sender, EventArgs e)
        {
            epCheck.Clear();
            bool valid = true;

            if (string.IsNullOrWhiteSpace(txtUsername.Text))
            {
                epCheck.SetError(txtUsername, "Vui lòng nhập tên đăng nhập.");
                valid = false;
            }

            if (string.IsNullOrWhiteSpace(txtPassword.Text))
            {
                epCheck.SetError(txtPassword, "Vui lòng nhập mật khẩu.");
                valid = false;
            }

            if (!string.Equals(txtPassword.Text, txtConfirm.Text, StringComparison.Ordinal))
            {
                epCheck.SetError(txtConfirm, "Mật khẩu không khớp.");
                valid = false;
            }

            // age calculation
            var today = DateTime.Today;
            int age = today.Year - dtpBirth.Value.Year;
            if (dtpBirth.Value.Date > today.AddYears(-age)) age--;
            if (age < 18)
            {
                epCheck.SetError(dtpBirth, "Bạn phải ít nhất 18 tuổi.");
                valid = false;
            }

            if (!chkAgree.Checked)
            {
                epCheck.SetError(chkAgree, "Bạn phải đồng ý với điều khoản.");
                valid = false;
            }

            if (valid)
            {
                MessageBox.Show("Đăng ký thành công.", "Thành công", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        private void btnReset_Click(object sender, EventArgs e)
        {
            txtUsername.Text = string.Empty;
            txtPassword.Text = string.Empty;
            txtConfirm.Text = string.Empty;
            dtpBirth.Value = DateTime.Today.AddYears(-18);
            rbMale.Checked = true;
            chkAgree.Checked = false;
            epCheck.Clear();
        }
    }
}
