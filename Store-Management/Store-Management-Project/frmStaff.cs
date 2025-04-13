using BLL;
using DTO;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Store_Management_Project
{
    public partial class frmStaff : Form
    {
        StaffBLL staffBLL;
        List<StaffDTO> nhanvienList;
        public frmStaff()
        {
            InitializeComponent();
            staffBLL = new StaffBLL();
            LoadDataNhanVien();
        }

        public void LoadDataNhanVien()
        {
            nhanvienList = staffBLL.getDanhSachNhanVien();
            tblStaff.DataSource = nhanvienList;
            tblStaff.Columns[0].HeaderText = "STT";
            tblStaff.Columns[1].HeaderText = "Tên Nhân Viên";
            tblStaff.Columns[2].HeaderText = "Email";
            tblStaff.Columns[3].HeaderText = "Ngày Sinh";
            tblStaff.Columns[4].HeaderText = "SĐT";
            tblStaff.Columns[5].HeaderText = "CCCD";
            tblStaff.Columns[6].HeaderText = "Dịa Chỉ";
        }

        private void tblStaff_Click(object sender, EventArgs e)
        {
            DataGridViewRow selectedRow = tblStaff.SelectedRows[0];
            txtMaNV.Text = selectedRow.Cells[0].Value.ToString();
            txtTenNV.Text = selectedRow.Cells[1].Value.ToString();
            txtEmail.Text = selectedRow.Cells[2].Value.ToString();
            dateNgaySinh.Value = DateTime.Parse(selectedRow.Cells[3].Value.ToString());
            txtSDT.Text = selectedRow.Cells[4].Value.ToString();
            txtCCCD.Text = selectedRow.Cells[5].Value.ToString();
            txtDiaChi.Text = selectedRow.Cells[6].Value.ToString();

            btnLuu.Enabled = false;
            btnSua.Enabled = true;
            btnXoa.Enabled = true;
            txtTenNV.Enabled = true;
            txtEmail.Enabled = true;
            txtSDT.Enabled = true;
            txtDiaChi.Enabled = true;
            txtCCCD.Enabled = true;
        }

        public bool KiemTraNhapEmail(string email)
        {
            string pattern = @"^[a-zA-Z0-9._%+-]+@[a-zA-Z0-9.-]+\.[a-zA-Z]{2,}$";
            Regex regex = new Regex(pattern);
            return regex.IsMatch(email);
        }

        static bool KiemTraNhapNgaySinh(string str)
        {
            if (DateTime.TryParseExact(str, "dd/MM/yyyy", null, System.Globalization.DateTimeStyles.None, out DateTime ngaysinh))
            {
                int tuoi = TinhSoTuoi(ngaysinh);
                return tuoi > 18;
            }
            return false;
        }

        static int TinhSoTuoi(DateTime ngaysinh)
        {
            DateTime hientai = DateTime.Now;
            int tuoi = hientai.Year - ngaysinh.Year;
            if (ngaysinh > hientai.AddYears(-tuoi))
            {
                tuoi--;
            }
            return tuoi;
        }

        private void btnLuu_Click(object sender, EventArgs e)
        {
            DialogResult result = MessageBox.Show("Bạn có muốn thêm nhân viên này?", "Xác nhận", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (staffBLL.KiemTraEmail(txtEmail.Text))
                MessageBox.Show("Email đã tồn tại. Vui lòng nhập một email khác.");
            else
            {
                if (txtSDT.Text.Length != 10)
                {
                    MessageBox.Show("SĐT chưa hợp lệ");
                    txtSDT.Focus();
                    return;
                }
                else
                {
                    if (txtCCCD.Text.Length != 12)
                    {
                        MessageBox.Show("CCCD chưa hợp lệ");
                        txtCCCD.Focus();
                        return;
                    }
                    else
                    {
                        if (!KiemTraNhapEmail(txtEmail.Text))
                        {
                            MessageBox.Show("Email chưa hợp lệ");
                            txtEmail.Focus();
                            return;
                        }
                        else
                        {
                            if (!KiemTraNhapNgaySinh(dateNgaySinh.Text))
                            {
                                MessageBox.Show("Tuổi phải trên 18");
                                return;
                            }
                            else
                            {
                                if (result == DialogResult.Yes)
                                {
                                    staffBLL.ThemNhanVien(txtTenNV.Text.Trim(), txtEmail.Text.Trim(), txtSDT.Text.Trim(), txtDiaChi.Text.Trim(), dateNgaySinh.Value, txtCCCD.Text.Trim());
                                    LoadDataNhanVien();
                                }
                            }
                        }
                    }
                }
            }
        }

        private void guna2Button4_Click(object sender, EventArgs e)
        {
            dateNgaySinh.Value = DateTime.Parse(DateTime.Now.ToString("dd/MM/yyyy"));
            txtMaNV.Text = string.Empty;
            txtTenNV.Text = string.Empty;
            txtEmail.Text = string.Empty;
            txtSDT.Text = string.Empty;
            txtDiaChi.Text = string.Empty;
            txtCCCD.Text = string.Empty;
            txtTenNV.Enabled = true;
            txtEmail.Enabled = true;
            txtSDT.Enabled = true;
            txtDiaChi.Enabled = true;
            txtCCCD.Enabled = true;
            btnLuu.Enabled = true;
            btnSua.Enabled = false;
            btnXoa.Enabled = false;
            txtTenNV.Focus();
        }

        private void btnXoa_Click(object sender, EventArgs e)
        {
            int i = tblStaff.CurrentRow.Index;

            DialogResult result = MessageBox.Show("Bạn có chắc chắn muốn xóa khách hàng này?", "Xác nhận xóa", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

            if (result == DialogResult.Yes)
            {
                staffBLL.XoaNhanVien(int.Parse(txtMaNV.Text));
                LoadDataNhanVien();
            }
            txtTenNV.Text = string.Empty;
            txtEmail.Text = string.Empty;
            txtSDT.Text = string.Empty;
            txtDiaChi.Text = string.Empty;
            txtMaNV.Text = string.Empty;
            btnLuu.Enabled = false;
            btnSua.Enabled = true;
            btnXoa.Enabled = true;
        }

        private void btnSua_Click(object sender, EventArgs e)
        {
            DialogResult result = MessageBox.Show("Bạn có muốn cập nhật lại nhân viên này?", "Xác nhận", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (txtSDT.Text.Length != 10)
            {
                MessageBox.Show("SĐT chưa hợp lệ");
                txtSDT.Focus();
                return;
            }
            else
            {
                if (txtCCCD.Text.Length != 12)
                {
                    MessageBox.Show("CCCD chưa hợp lệ");
                    txtCCCD.Focus();
                    return;
                }
                else
                {
                    if (!KiemTraNhapEmail(txtEmail.Text))
                    {
                        MessageBox.Show("Email chưa hợp lệ");
                        txtEmail.Focus();
                        return;
                    }
                    else
                    {
                        if (!KiemTraNhapNgaySinh(dateNgaySinh.Text))
                        {
                            MessageBox.Show("Tuổi phải trên 18");
                            return;
                        }
                        else
                        {
                            if (result == DialogResult.Yes)
                            {
                                staffBLL.CapNhatNhanVien(txtTenNV.Text, txtEmail.Text, dateNgaySinh.Value, txtSDT.Text, txtCCCD.Text, txtDiaChi.Text, int.Parse(txtMaNV.Text));
                                LoadDataNhanVien();
                            }
                        }
                    }
                }
            }
        }

        private void guna2Button5_Click(object sender, EventArgs e)
        {
            DialogResult result = MessageBox.Show("Bạn có muốn thoát?", "Xác nhận", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

            if (result == DialogResult.Yes)
            {
                this.Visible = false;
                Program.mainForm = new frmMain();
                Program.mainForm.Show();
            }
        }

        private void txtSDT_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == 8 || e.KeyChar == 46)
                return;
            if (txtSDT.Text.Length >= 10)
                e.Handled = true;
        }


        private void txtCCCD_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar) &&
                e.KeyChar != (char)Keys.Left && e.KeyChar != (char)Keys.Right && e.KeyChar != (char)Keys.Delete)
                e.Handled = true;
            if (e.KeyChar == 8 || e.KeyChar == 46)
                return;
            if (txtCCCD.Text.Length >= 12)
                e.Handled = true;
        }

        private void txtFind_TextChanged(object sender, EventArgs e)
        {
            switch (cboFind.SelectedIndex)
            {
                case 0:
                    tblStaff.DataSource = staffBLL.TimKiemNhanVienTheoTen(txtFind.Text.Trim());
                    break;
                case 1:
                    tblStaff.DataSource = staffBLL.TimKiemNhanVienTheoSDT(txtFind.Text.Trim());
                    break;
                case 2:
                    tblStaff.DataSource = staffBLL.TimKiemNhanVienTheoCCCD(txtFind.Text.Trim());
                    break;
            }
        }
    }
}
