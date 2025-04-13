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
    public partial class frmAccountStaff : Form
    {
        AccountStaffBLL asbll;
        public frmAccountStaff()
        {
            InitializeComponent();
            asbll = new AccountStaffBLL();
            LoadTable();
            LoadCboNhanVien();
        }

        public void LoadTable()
        {
            tblAccStaff.DataSource = asbll.LoadData();
            tblAccStaff.Columns[0].HeaderText = "Tên Nhân Viên";
            tblAccStaff.Columns[1].HeaderText = "Tài Khoản";
            tblAccStaff.Columns[2].HeaderText = "Mật Khẩu";
            tblAccStaff.Columns[3].HeaderText = "Hoạt Động";
            tblAccStaff.Columns[4].HeaderText = "Quyền";
        }

        public void LoadCboNhanVien()
        {
            cboTenNhanVien.DataSource = asbll.LoadListNhanVien();
        }

        private void tblAccStaff_Click(object sender, EventArgs e)
        {
            int i = tblAccStaff.CurrentRow.Index;
            cboTenNhanVien.Text = tblAccStaff.Rows[i].Cells[0].Value.ToString();
            txtTaiKhoanNhanVien.Text = tblAccStaff.Rows[i].Cells[1].Value.ToString();
            int hoatdong = int.Parse(tblAccStaff.Rows[i].Cells[3].Value.ToString());
            switch (hoatdong)
            {
                case 0:
                    cboHoatDong.SelectedIndex = 1;
                    break;
                case 1:
                    cboHoatDong.SelectedIndex = 0;
                    break;
            }
            cboQuyen.Text = tblAccStaff.Rows[i].Cells[4].Value.ToString();
        }

        private void btnXoa_Click(object sender, EventArgs e)
        {
            DialogResult result = MessageBox.Show("Bạn có chắc chắn muốn xóa?", "Xác nhận", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (result == DialogResult.Yes)
            {
                asbll.XoaTaiKhoan(asbll.LayMaNhanVien(cboTenNhanVien.Text), txtTaiKhoanNhanVien.Text);
                LoadTable();
                txtTaiKhoanNhanVien.Text = string.Empty;
            }
        }

        private void btnThem_Click(object sender, EventArgs e)
        {
            string pass = "123";
            if (!(txtTaiKhoanNhanVien.Text == string.Empty))
            {
                switch (cboHoatDong.SelectedIndex)
                {
                    case 0:
                        asbll.ThemTaiKhoan(asbll.LayMaNhanVien(cboTenNhanVien.Text), txtTaiKhoanNhanVien.Text,
                                            pass, "1", cboQuyen.Text);
                        LoadTable();
                        txtTaiKhoanNhanVien.Text = string.Empty;
                        cboTenNhanVien.SelectedIndex = 0;
                        cboHoatDong.SelectedIndex = 0;
                        cboQuyen.SelectedIndex = 0;
                        break;
                    case 1:
                        asbll.ThemTaiKhoan(asbll.LayMaNhanVien(cboTenNhanVien.Text), txtTaiKhoanNhanVien.Text,
                                            pass, "0", cboQuyen.Text);
                        LoadTable();
                        txtTaiKhoanNhanVien.Text = string.Empty;
                        cboTenNhanVien.SelectedIndex = 0;
                        cboHoatDong.SelectedIndex = 0;
                        cboQuyen.SelectedIndex = 0;
                        break;
                }
            }
            else
                MessageBox.Show("Chưa nhập đủ dữ liệu");
        }

        private void btnSua_Click(object sender, EventArgs e)
        {
            DialogResult result = MessageBox.Show("Bạn có chắc chắn muốn cập nhật?", "Xác nhận", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (result == DialogResult.Yes)
            {
                switch (cboHoatDong.SelectedIndex)
                {
                    case 0:
                        asbll.CapNhatTaiKhoan(asbll.LayMaNhanVien(cboTenNhanVien.Text), txtTaiKhoanNhanVien.Text,
                                            "1", cboQuyen.Text);
                        LoadTable();
                        txtTaiKhoanNhanVien.Text = string.Empty;
                        cboTenNhanVien.SelectedIndex = 0;
                        cboHoatDong.SelectedIndex = 0;
                        cboQuyen.SelectedIndex = 0;
                        break;
                    case 1:
                        asbll.CapNhatTaiKhoan(asbll.LayMaNhanVien(cboTenNhanVien.Text), txtTaiKhoanNhanVien.Text,
                                            "0", cboQuyen.Text);
                        LoadTable();
                        txtTaiKhoanNhanVien.Text = string.Empty;
                        cboTenNhanVien.SelectedIndex = 0;
                        cboHoatDong.SelectedIndex = 0;
                        cboQuyen.SelectedIndex = 0;
                        break;
                }
            }
        }

        private void btnNhapLai_Click(object sender, EventArgs e)
        {
            if (!(txtTaiKhoanNhanVien.Text == string.Empty))
            {
                DialogResult result = MessageBox.Show("Bạn có chắc chắn muốn reset password cho tài khoản: " + txtTaiKhoanNhanVien.Text + " ?", "Xác nhận", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                if (result == DialogResult.Yes)
                {
                    asbll.ResetPassword(asbll.LayMaNhanVien(cboTenNhanVien.Text), txtTaiKhoanNhanVien.Text);
                    MessageBox.Show("Reset thành công!");
                    LoadTable();
                }
            }
            else
                MessageBox.Show("Hãy chọn 1 tài khoản để thực hiện", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
        }

        private void btnThoat_Click(object sender, EventArgs e)
        {
            this.Visible = false;
            Program.mainForm = new frmMain();
            Program.mainForm.Show();
        }

        private void tblAccStaff_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void label3_Click(object sender, EventArgs e)
        {

        }

        private void cboQuyen_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void cboHoatDong_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void txtTaiKhoanNhanVien_TextChanged(object sender, EventArgs e)
        {

        }

        private void cboTenNhanVien_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void label5_Click(object sender, EventArgs e)
        {

        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void label4_Click(object sender, EventArgs e)
        {

        }
    }
}
