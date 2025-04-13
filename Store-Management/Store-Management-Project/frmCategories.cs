using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using BLL;
using Guna.UI2.WinForms;
using static System.Net.Mime.MediaTypeNames;

namespace Store_Management_Project
{
    public partial class frmCategories : Form
    {
        CategoriesBLL categoriesBLL;
        List<DanhMucSanPham> lst;
        public frmCategories()
        {
            InitializeComponent();
            categoriesBLL = new CategoriesBLL();
            LoadData();
            InitializeCustomTextBox();
            cboFind.SelectedIndex = 0;
            string duongDanUngDung = AppDomain.CurrentDomain.BaseDirectory;
            string imagePath = Path.Combine(duongDanUngDung, @"Images\DanhMuc\null.jpg");
            pictureBox1.SizeMode = PictureBoxSizeMode.Zoom;
            pictureBox1.ImageLocation = imagePath;

        }
        public void LoadData()
        {
            lst = categoriesBLL.getDanhSachDanhMuc();
            tblCategories.DataSource = lst;
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
            string tenDanhMucMoi = TenDM.Text.Trim();
            string hinhDanhMucMoi = HinhDM.Text.Trim();

            //if (!categoriesBLL.KiemTraDanhMucTonTai(tenDanhMucMoi))
            //{
            //    DialogResult result = MessageBox.Show("Bạn có muốn thêm danh mục sản phẩm này?", "Xác nhận", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

            //    if (result == DialogResult.Yes)
            //    {
            //        categoriesBLL.ThemDanhMuc(tenDanhMucMoi, hinhDanhMucMoi);
            //        LoadData();
            //    }
            //}
            //else
            //{
            //    MessageBox.Show("Danh mục đã tồn tại. Vui lòng chọn tên khác.", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            //}
            DialogResult result = MessageBox.Show("Bạn có muốn thêm danh mục sản phẩm này?", "Xác nhận", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

            if (result == DialogResult.Yes)
            {
                categoriesBLL.ThemDanhMuc(tenDanhMucMoi, hinhDanhMucMoi);
                LoadData();
            }

        }

        private void guna2Button2_Click(object sender, EventArgs e)
        {
            DialogResult result = MessageBox.Show("Bạn có chắc chắn muốn xóa danh mục sản phẩm này?", "Xác nhận xóa", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

            if (result == DialogResult.Yes)
            {
                categoriesBLL.XoaDanhMuc(categoriesBLL.LayIDtuTen(TenDM.Text));
                LoadData();
                pictureBox1.Image = null;
                string duongDanUngDung = AppDomain.CurrentDomain.BaseDirectory;
                string imagePath = Path.Combine(duongDanUngDung, @"Images\DanhMuc\" + HinhDM.Text + @"");
                if (File.Exists(imagePath))
                    File.Delete(imagePath);
            }
            TenDM.Text = string.Empty;
            HinhDM.Text = string.Empty;

        }

        private void guna2Button3_Click(object sender, EventArgs e)
        {
            DialogResult result = MessageBox.Show("Bạn có muốn cập nhật lại danh mục sản phẩm này?", "Xác nhận", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            int i = tblCategories.CurrentRow.Index;
            if (result == DialogResult.Yes)
            {
                DialogResult result1 = MessageBox.Show("Bạn có muốn đổi ảnh khác?", "Thông báo", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                if (result1 == DialogResult.Yes)
                {
                    string duongDanUngDung = AppDomain.CurrentDomain.BaseDirectory;
                    string imagePath = Path.Combine(duongDanUngDung, @"Images\DanhMuc\" + HinhDM.Text + @"");
                    if (File.Exists(imagePath))
                        File.Delete(imagePath);
                    OpenFileDialog openFileDialog = new OpenFileDialog();
                    openFileDialog.Filter = "Image Files (*.png;*.jpg;*.jpeg;*.gif;*.bmp)|*.png;*.jpg;*.jpeg;*.gif;*.bmp|All files (*.*)|*.*";

                    if (openFileDialog.ShowDialog() == DialogResult.OK)
                    {
                        string tenHinh = Path.GetFileName(openFileDialog.FileName);
                        string duongDanThuMucAnh = Path.Combine(duongDanUngDung, @"Images\DanhMuc\");
                        string duongDanHinhMoi = Path.Combine(duongDanThuMucAnh, tenHinh);
                        File.Copy(openFileDialog.FileName, duongDanHinhMoi, true);

                        HinhDM.Text = tenHinh;

                        pictureBox1.SizeMode = PictureBoxSizeMode.Zoom;
                        pictureBox1.ImageLocation = duongDanHinhMoi;

                        categoriesBLL.CapNhatDanhMuc(TenDM.Text, HinhDM.Text, int.Parse(tblCategories.Rows[i].Cells[0].Value.ToString()));
                        LoadData();
                        TenDM.Text = string.Empty;
                        HinhDM.Text = string.Empty;
                    }
                }
                else if (result1 == DialogResult.No)
                {
                    categoriesBLL.CapNhatDanhMuc(TenDM.Text, HinhDM.Text, int.Parse(tblCategories.Rows[i].Cells[0].Value.ToString()));
                    LoadData();
                    TenDM.Text = string.Empty;
                    HinhDM.Text = string.Empty;
                }
            }
        }

        private void guna2Button4_Click(object sender, EventArgs e)
        {
            TenDM.Text = string.Empty;
            HinhDM.Text = string.Empty;
            btnLuu.Enabled = true;
            btnSua.Enabled = false;
            btnXoa.Enabled = false;
            TenDM.Enabled = true;
            HinhDM.Enabled = true;
            guna2Button6.Enabled = true;
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

        private void tblCategories_Click(object sender, EventArgs e)
        {
            DataGridViewRow selectedRow = tblCategories.SelectedRows[0];
            TenDM.Text = selectedRow.Cells[1].Value.ToString();
            HinhDM.Text = selectedRow.Cells[2].Value.ToString();
            btnLuu.Enabled = false;
            btnSua.Enabled = true;
            btnXoa.Enabled = true;
            TenDM.Enabled = true;
            HinhDM.Enabled = true;

            string linksanpham = selectedRow.Cells[2].Value.ToString();
            string duongDanUngDung = AppDomain.CurrentDomain.BaseDirectory;
            string imagePath = Path.Combine(duongDanUngDung, @"Images\DanhMuc\" + linksanpham + @"");
            if (System.IO.File.Exists(imagePath))
            {
                pictureBox1.ImageLocation = imagePath;
                pictureBox1.SizeMode = PictureBoxSizeMode.Zoom;
            }
            else
                MessageBox.Show("Hình ảnh không tồn tại.");
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (!isTxtFindDefault)
            {
                if (cboFind.Text == "Mã Danh Mục")
                    tblCategories.DataSource = categoriesBLL.GetDanhMucList_MaDanhMuc(txtFind.Text.Trim());
                if (cboFind.Text == "Tên Danh Mục")
                    tblCategories.DataSource = categoriesBLL.GetDanhMucList_TenDanhMuc(txtFind.Text.Trim());

            }
            else
            {
                LoadData();
            }
            btnLuu.Enabled = false;
            btnSua.Enabled = false;
            btnXoa.Enabled = false;
            TenDM.Enabled = false;
            HinhDM.Enabled = false;
        }

        private void guna2Button6_Click(object sender, EventArgs e)
        {
            OpenFileDialog openFileDialog = new OpenFileDialog();
            openFileDialog.Filter = "Image Files (*.png;*.jpg;*.jpeg;*.gif;*.bmp)|*.png;*.jpg;*.jpeg;*.gif;*.bmp|All files (*.*)|*.*";

            if (openFileDialog.ShowDialog() == DialogResult.OK)
            {
                string tenHinh = Path.GetFileName(openFileDialog.FileName);
                string duongDanUngDung = AppDomain.CurrentDomain.BaseDirectory;
                string duongDanThuMucAnh = Path.Combine(duongDanUngDung, @"Images\DanhMuc\");
                string duongDanHinhMoi = Path.Combine(duongDanThuMucAnh, tenHinh);
                File.Copy(openFileDialog.FileName, duongDanHinhMoi, true);

                HinhDM.Text = tenHinh;

                pictureBox1.SizeMode = PictureBoxSizeMode.Zoom;
                pictureBox1.ImageLocation = duongDanHinhMoi;
            }
        }
    }
}
