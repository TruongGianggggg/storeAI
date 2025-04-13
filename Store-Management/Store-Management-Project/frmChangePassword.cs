using BLL;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Store_Management_Project
{
    public partial class frmChangePassword : Form
    {
        AccountStaffBLL tkbll;
        public frmChangePassword()
        {
            InitializeComponent();
            tkbll = new AccountStaffBLL();
        }

        private void checkBox1_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBox1.Checked)
                txtMatKhauCu.PasswordChar = '\0';
            else
                txtMatKhauCu.PasswordChar = '*';
        }

        private void checkBox2_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBox2.Checked)
                txtMatKhauMoi.PasswordChar = '\0';
            else
                txtMatKhauMoi.PasswordChar = '*';
        }

        private void checkBox3_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBox3.Checked)
                txtNhapLai.PasswordChar = '\0';
            else
                txtNhapLai.PasswordChar = '*';
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (txtTenDangNhap.Text.Equals(string.Empty) || txtMatKhauCu.Text.Equals(string.Empty)
                || txtMatKhauMoi.Text.Equals(string.Empty) || txtNhapLai.Text.Equals(string.Empty))
                MessageBox.Show("Điền đầy đủ thông tin!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            else
            {
                if (!txtMatKhauCu.Text.Equals(tkbll.GetMatKhau(txtTenDangNhap.Text)) || !txtTenDangNhap.Text.Equals(tkbll.GetTenDangNhap(txtTenDangNhap.Text)))
                    MessageBox.Show("Mật khẩu cũ hoặc tài khoản chưa chính xác!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                else
                {
                    if (!txtMatKhauMoi.Text.Equals(txtNhapLai.Text))
                        MessageBox.Show("Nhập lại mật khẩu chưa trùng khớp!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    else
                    {
                        tkbll.ChangePassword(txtTenDangNhap.Text, txtMatKhauMoi.Text);
                        MessageBox.Show("Thay đổi mật khẩu thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        this.Dispose();
                    }
                }
            }
        }
    }
}
