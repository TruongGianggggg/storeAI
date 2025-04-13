using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using BLL;

namespace Store_Management_Project
{
    public partial class frmBrand : Form
    {
        BrandBLL brandBLL;
        List<ThuongHieu> lst;
        public frmBrand()
        {
            InitializeComponent();
            brandBLL = new BrandBLL();

            LoadData();
            InitializeCustomTextBox();

            cboFind.SelectedIndex = 0;
        }
        public void LoadData()
        {
            lst = brandBLL.getDanhSachThuongHieu();
            tblThuongHieu.DataSource = lst;
        }

        private bool isTxtFindDefault = true;

        private void InitializeCustomTextBox()
        {
            txtFind.Text = "Tìm kiếm tại đây ... ";
            txtFind.ForeColor = System.Drawing.Color.Gray;

            txtFind.GotFocus += TextBox1_GotFocus;
            txtFind.LostFocus += TextBox1_LostFocus;
        }


        private void TextBox1_GotFocus(object sender, EventArgs e)
        {
            if (isTxtFindDefault)
            {
                txtFind.Text = "";
                txtFind.ForeColor = System.Drawing.Color.Black;
                isTxtFindDefault = false;
            }
        }

        private void TextBox1_LostFocus(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtFind.Text))
            {
                txtFind.Text = "Tìm kiếm tại đây ... ";
                txtFind.ForeColor = System.Drawing.Color.Gray;
                isTxtFindDefault = true;
            }
        }


        private void guna2Button1_Click(object sender, EventArgs e)
        {
            DialogResult result = MessageBox.Show("Bạn có muốn thêm thương hiệu sản phẩm này?", "Xác nhận", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

            if (result == DialogResult.Yes)
            {
                brandBLL.ThemThuongHieu(TenTH.Text.Trim());
                LoadData();
            }
        }

        private void guna2Button2_Click(object sender, EventArgs e)
        {
            int i = tblThuongHieu.CurrentRow.Index;

            DialogResult result = MessageBox.Show("Bạn có chắc chắn muốn xóa thương hiệu sản phẩm này?", "Xác nhận xóa", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

            if (result == DialogResult.Yes)
            {
                brandBLL.XoaThuongHieu(brandBLL.LayIDtuTen(TenTH.Text));
                LoadData();
            }
            TenTH.Text = string.Empty;

        }

        private void guna2Button3_Click(object sender, EventArgs e)
        {
            DialogResult result = MessageBox.Show("Bạn có muốn cập nhật lại thương hiệu sản phẩm này?", "Xác nhận", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            int i = tblThuongHieu.CurrentRow.Index;
            if (result == DialogResult.Yes)
            {
                brandBLL.CapNhatThuongHieu(TenTH.Text, int.Parse(tblThuongHieu.Rows[i].Cells[0].Value.ToString()));
                LoadData();
            }
        }

        private void guna2Button4_Click(object sender, EventArgs e)
        {
            TenTH.Text = string.Empty;
            btnLuu.Enabled = true;
            btnSua.Enabled = false;
            btnXoa.Enabled = false;

            TenTH.Enabled = true;
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

        private void tblThuongHieu_Click(object sender, EventArgs e)
        {
            DataGridViewRow selectedRow = tblThuongHieu.SelectedRows[0];
            TenTH.Text = selectedRow.Cells[1].Value.ToString();
            btnLuu.Enabled = false;
            btnSua.Enabled = true;
            btnXoa.Enabled = true;
            TenTH.Enabled = true;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (!isTxtFindDefault)
            {
                if (cboFind.Text == "Mã Thương Hiệu")
                    tblThuongHieu.DataSource = brandBLL.GetThuongHieuList_MaThuongHieu(txtFind.Text.Trim());
                if (cboFind.Text == "Tên Thương Hiệu")
                    tblThuongHieu.DataSource = brandBLL.GetThuongHieuList_TenThuongHieu(txtFind.Text.Trim());
            }
            else
            {
                LoadData();
            }

            btnLuu.Enabled = false;
            btnSua.Enabled = false;
            btnXoa.Enabled = false;

            TenTH.Enabled = false;
        }
    }
}
