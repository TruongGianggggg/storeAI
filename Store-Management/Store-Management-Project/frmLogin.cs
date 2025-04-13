using BLL;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Store_Management_Project
{
    public partial class frmLogin : Form
    {
        LoginBLL lbll;
        public static string quyen = "", tendn = "";
        public static int manhanvien = 0;
        public frmLogin()
        {
            InitializeComponent();
            lbll = new LoginBLL();
            SetRoundedForm();
            SetRoundedPanel();
            
        }
        private void SetRoundedForm()
        {
            int radius = 30;
            GraphicsPath path = new GraphicsPath();
            path.AddArc(0, 0, radius * 2, radius * 2, 180, 90);
            path.AddLine(radius, 0, this.Width - radius, 0);
            path.AddArc(this.Width - radius * 2, 0, radius * 2, radius * 2, 270, 90);
            path.AddLine(this.Width, radius, this.Width, this.Height - radius);
            path.AddArc(this.Width - radius * 2, this.Height - radius * 2, radius * 2, radius * 2, 0, 90);
            path.AddLine(this.Width - radius, this.Height, radius, this.Height);
            path.AddArc(0, this.Height - radius * 2, radius * 2, radius * 2, 90, 90);
            path.AddLine(0, this.Height - radius, 0, radius);
            this.Region = new Region(path);
        }

        private void SetRoundedPanel()
        {
            int radius = 30;
            GraphicsPath path = new GraphicsPath();
            path.AddArc(0, 0, radius * 2, radius * 2, 180, 90);
            path.AddLine(radius, 0, panel1.Width - radius, 0);
            path.AddArc(panel1.Width - radius * 2, 0, radius * 2, radius * 2, 270, 90);
            path.AddLine(panel1.Width, radius, this.Width, this.Height - radius);
            path.AddArc(panel1.Width - radius * 2, panel1.Height - radius * 2, radius * 2, radius * 2, 0, 90);
            path.AddLine(panel1.Width - radius, panel1.Height, radius, panel1.Height);
            path.AddArc(0, panel1.Height - radius * 2, radius * 2, radius * 2, 90, 90);
            path.AddLine(0, panel1.Height - radius, 0, radius);
            panel1.Region = new Region(path);
        }
        private void guna2Button1_Click(object sender, EventArgs e)
        {
            Login();
        }
        public void Login()
        {
            string username = lbll.LayTenDangNhap(txtTenDangNhap.Text.Trim());
            string password = lbll.LayMatKhau(txtTenDangNhap.Text.Trim());

            if (txtTenDangNhap.Text.Equals(string.Empty))
                MessageBox.Show("Chưa nhập tên đăng nhập!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
            else
            {
                if (txtMatKhau.Text.Equals(string.Empty))
                    MessageBox.Show("Chưa nhập mật khẩu!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                else
                {
                    if (!(username.Equals(txtTenDangNhap.Text.Trim()) && password.Equals(txtMatKhau.Text.Trim())))
                    {
                        MessageBox.Show("Tên tài khoản hoặc mật khẩu không chính xác!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                    else
                    {
                        if (lbll.LayHoatDong(txtTenDangNhap.Text.Trim()) != 0)
                        {
                            //tendangnhap = txtUsername.Text.Trim();
                            //tentaikhoan = tk.GetTenTaiKhoan(txtUsername.Text.Trim());
                            manhanvien = lbll.LayMaNhanVien(txtTenDangNhap.Text);
                            tendn = txtTenDangNhap.Text;
                            quyen = lbll.LayQuyen(txtTenDangNhap.Text.Trim());
                            txtTenDangNhap.Text = ""; txtMatKhau.Text = "";
                            MessageBox.Show("Thành công", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            Program.mainForm = new frmMain();
                            Program.mainForm.Show();
                            this.Visible = false;
                        }    
                        else
                            MessageBox.Show("Tài khoản đã bị khóa!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
            }
        }

        private void txtTenDangNhap_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
                Login();
        }

        private void txtMatKhau_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
                Login();
        }

        private void checkBox1_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBox1.Checked)
                txtMatKhau.PasswordChar = '\0';
            else
                txtMatKhau.PasswordChar = '*';
        }

        private void guna2Button2_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }
    }
}
