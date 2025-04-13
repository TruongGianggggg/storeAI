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
    public partial class frmAccountCustomer : Form
    {
        AccountCustomerBLL acbll;
        public frmAccountCustomer()
        {
            InitializeComponent();
            acbll = new AccountCustomerBLL();
            LoadTable();
            LoadCboKhachHang();
        }

        private void btnThoat_Click(object sender, EventArgs e)
        {
            this.Visible = false;
            Program.mainForm = new frmMain();
            Program.mainForm.Show();
        }

        public void LoadTable()
        {
            tblAccCustomer.DataSource = acbll.LoadData();
            tblAccCustomer.Columns[0].HeaderText = "Mã Tài Khoản";
            tblAccCustomer.Columns[1].HeaderText = "Tài Khoản";
            tblAccCustomer.Columns[2].HeaderText = "Mật Khẩu";
            tblAccCustomer.Columns[3].HeaderText = "Mã Khách Hàng";
            tblAccCustomer.Columns[4].HeaderText = "Tên Khách Hàng";
            tblAccCustomer.Columns[5].HeaderText = "Email";
            tblAccCustomer.Columns[6].HeaderText = "SĐT";
            tblAccCustomer.Columns[7].HeaderText = "Hoạt Động";
        }

        public void LoadCboKhachHang() { cboKhachHang.DataSource = acbll.LoadKhachHang(); }

        private void tblAccCustomer_Click(object sender, EventArgs e)
        {
            cboKhachHang.Enabled = false;
            int i = tblAccCustomer.CurrentRow.Index;
            cboKhachHang.Text = tblAccCustomer.Rows[i].Cells[4].Value.ToString();
            txtTaiKhoanKhachHang.Text = tblAccCustomer.Rows[i].Cells[1].Value.ToString();
            txtEmail.Text = tblAccCustomer.Rows[i].Cells[5].Value.ToString();
            txtSDT.Text = tblAccCustomer.Rows[i].Cells[6].Value.ToString();
            cboHoatDong.Text = tblAccCustomer.Rows[i].Cells[7].Value.ToString();
        }

        private void btnThem_Click(object sender, EventArgs e)
        {
            try
            {
                cboKhachHang.Enabled = true;
                DialogResult result = MessageBox.Show("Bạn có chắc chắn muốn thêm?", "Xác nhận", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                if (result == DialogResult.Yes)
                {
                    if (!acbll.KiemTraTonTaiTaiKhoan(txtEmail.Text))
                    {
                        acbll.ThemTaiKhoanKhachHang(txtTaiKhoanKhachHang.Text,
                                                    acbll.LayIdKhachHang(cboKhachHang.Text),
                                                    cboHoatDong.Text);
                        LoadTable();
                        cboKhachHang.Text = string.Empty;
                        cboHoatDong.SelectedIndex = 0;
                        txtEmail.Text = string.Empty;
                        txtSDT.Text = string.Empty;
                        txtTaiKhoanKhachHang.Text = string.Empty;
                        cboKhachHang.Enabled = false;
                    }
                    else
                        MessageBox.Show("Khách hàng đã tồn tại tài khoản, hãy kiểm tra lại!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            catch (Exception)
            {
                MessageBox.Show("Lỗi!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void cboKhachHang_SelectedIndexChanged(object sender, EventArgs e)
        {
            txtEmail.Text = acbll.LayEmail(cboKhachHang.Text.Trim());
            txtSDT.Text = acbll.LaySDT(cboKhachHang.Text.Trim());
        }

        private void btnXoa_Click(object sender, EventArgs e)
        {
            DialogResult result = MessageBox.Show("Bạn có chắc chắn muốn xóa?", "Xác nhận", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (result == DialogResult.Yes)
            {
                acbll.XoaTaiKhoanKhachHang(txtEmail.Text);
                LoadTable();
                cboKhachHang.Text = string.Empty;
                cboHoatDong.SelectedIndex = 0;
                txtEmail.Text = string.Empty;
                txtSDT.Text = string.Empty;
                txtTaiKhoanKhachHang.Text = string.Empty;
                cboKhachHang.Enabled = false;
            }
        }

        private void btnSua_Click(object sender, EventArgs e)
        {
            DialogResult result = MessageBox.Show("Bạn có chắc chắn muốn sửa?", "Xác nhận", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (result == DialogResult.Yes)
            {
                acbll.CapNhatTaiKhoanKhachHang(txtEmail.Text, txtTaiKhoanKhachHang.Text.Trim(), cboHoatDong.Text);
                LoadTable();
                cboKhachHang.Text = string.Empty;
                cboHoatDong.SelectedIndex = 0;
                txtEmail.Text = string.Empty;
                txtSDT.Text = string.Empty;
                txtTaiKhoanKhachHang.Text = string.Empty;
                cboKhachHang.Enabled = false;
            }
        }

        private void btnNhapLai_Click(object sender, EventArgs e)
        {
            DialogResult result = MessageBox.Show("Bạn có chắc chắn muốn reset password?", "Xác nhận", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (result == DialogResult.Yes)
            {
                acbll.ResetPassword(txtEmail.Text);
                LoadTable();
                cboKhachHang.Text = string.Empty;
                cboHoatDong.SelectedIndex = 0;
                txtEmail.Text = string.Empty;
                txtSDT.Text = string.Empty;
                txtTaiKhoanKhachHang.Text = string.Empty;
                cboKhachHang.Enabled = false;
            }
        }
    }
}
