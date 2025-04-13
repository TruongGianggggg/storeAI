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
using DTO;
using Guna.UI2.WinForms;

namespace Store_Management_Project
{
    public partial class frmProduct : Form
    {
        ProductBLL productBLL;
        List<ProductDTO> lstProduct;
        public static string tensp;
        public frmProduct()
        {
            InitializeComponent();
            productBLL = new ProductBLL();
            LoadTableProduct();
            LoadCboDanhMuc();
            LoadCboThuongHieu();
            LoadCboGioiTinh();
            LoadTableHinhAnhSanPham(0);
            cboFind.SelectedIndex = 0;
            label17.Text = "Tổng số lượng sản phẩm đang có là: " + productBLL.DemSoLuongSanPham().ToString() + " sp";
        }
        public void LoadTableProduct()
        {
            lstProduct = productBLL.getDanhSachSanPhamDescending();
            tblProduct.DataSource = lstProduct;
            tblProduct.Columns[0].HeaderText = "Tên SP";
            tblProduct.Columns[1].HeaderText = "Giới tính";
            tblProduct.Columns[2].HeaderText = "Xuất xứ";
            tblProduct.Columns[3].HeaderText = "Mô tả";
            tblProduct.Columns[4].HeaderText = "Giá gốc";
            tblProduct.Columns[5].HeaderText = "Giá giảm";
            tblProduct.Columns[6].HeaderText = "Danh mục";
            tblProduct.Columns[7].HeaderText = "Thương hiệu";

            tblProduct.Columns[4].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
            tblProduct.Columns[5].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
            tblProduct.Columns[6].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            tblProduct.Columns[7].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            tblProduct.Columns[0].Width = 500;
            tblProduct.Columns[4].Width = 90;
            tblProduct.Columns[5].Width = 90;
        }

        public void LoadTableHinhAnhSanPham(int masp)
        {
            tblHinhAnhSanPham.DataSource = productBLL.getHinhAnhSanPham(masp);
            tblHinhAnhSanPham.Columns[0].HeaderText = "Link Hình Ảnh SP";
            tblHinhAnhSanPham.Columns[1].HeaderText = "Mã Sản Phẩm";
            tblHinhAnhSanPham.Columns[2].HeaderText = "Tên Sản Phẩm";
            tblHinhAnhSanPham.Columns[0].Width = 150;
            tblHinhAnhSanPham.Columns[1].Width = 50;
            tblHinhAnhSanPham.Columns[2].Width = 200;
        }

        public void LoadCboDanhMuc() { cboDanhMuc.DataSource = productBLL.LayDanhSachDanhMuc(); }

        public void LoadCboThuongHieu() { cboThuongHieu.DataSource = productBLL.LayDanhSachThuongHieu(); }

        public void LoadCboGioiTinh() { cboGioiTinh.DataSource = productBLL.LayDanhSachGioiTinh(); }


        private void guna2Button5_Click(object sender, EventArgs e)
        {
            this.Visible = false;
            Program.mainForm = new frmMain();
            Program.mainForm.Show();
        }

        private void tblProduct_Click(object sender, EventArgs e)
        {
            int i = tblProduct.CurrentRow.Index;
            txtTenSanPham.Text = tblProduct.Rows[i].Cells[0].Value.ToString();
            cboGioiTinh.Text = tblProduct.Rows[i].Cells[1].Value.ToString();
            txtXuatXu.Text = tblProduct.Rows[i].Cells[2].Value.ToString();
            txtMoTa.Text = tblProduct.Rows[i].Cells[3].Value.ToString();
            txtGiaGoc.Text = tblProduct.Rows[i].Cells[4].Value.ToString();
            txtGiaGiam.Text = tblProduct.Rows[i].Cells[5].Value.ToString();
            cboDanhMuc.Text = tblProduct.Rows[i].Cells[6].Value.ToString();
            cboThuongHieu.Text = tblProduct.Rows[i].Cells[7].Value.ToString();

            btnThem.Enabled = false;
            btnXoa.Enabled = true;
            btnSua.Enabled = true;

            pictureBox1.Image = null;
            LoadTableHinhAnhSanPham(productBLL.LayMaSanPham(tblProduct.Rows[i].Cells[0].Value.ToString()));
            btnThemHinhSP.Enabled = true;
            label14.Text = string.Empty;

            if (!productBLL.KiemTraTonKho(productBLL.LayMaSanPham(tblProduct.Rows[i].Cells[0].Value.ToString())))
                panel6.Visible = true;
            else
                panel6.Visible = false;
        }

        private void btnThem_Click(object sender, EventArgs e)
        {
            if (txtTenSanPham.Text.Equals(string.Empty) || txtXuatXu.Text.Equals(string.Empty) || txtMoTa.Text.Equals(string.Empty) ||
                txtGiaGoc.Text.Equals(string.Empty) || txtGiaGiam.Text.Equals(string.Empty))
            {
                MessageBox.Show("Nhập đủ thông tin cần nhập", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            else
            {
                DialogResult result = MessageBox.Show("Bạn có chắc chắn muốn thêm sản phẩm mới?", "Xác nhận", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                if (result == DialogResult.Yes)
                {
                    productBLL.ThemSanPhamMoi(txtTenSanPham.Text, cboGioiTinh.Text, txtXuatXu.Text, txtMoTa.Text, double.Parse(txtGiaGoc.Text), double.Parse(txtGiaGiam.Text),
                        productBLL.LayMaDanhMuc(cboDanhMuc.Text), productBLL.LayMaThuongHieu(cboThuongHieu.Text.Trim()));
                    MessageBox.Show("Thêm thành công");
                    LoadTableProduct();
                    label17.Text = "Tổng số lượng sản phẩm đang có là: " + productBLL.DemSoLuongSanPham().ToString() + " sp";
                }
            }
        }

        private void btnXoa_Click(object sender, EventArgs e)
        {
            try
            {
                if (txtTenSanPham.Text.Equals(string.Empty))
                    MessageBox.Show("Chưa chọn sản phẩm cần xóa");
                else
                {
                    DialogResult result = MessageBox.Show("Bạn có chắc chắn muốn xóa?", "Xác nhận", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                    if (result == DialogResult.Yes)
                    {
                        List<string> lstURLImage = productBLL.LayDanhSachLinkAnhTheoMaSP(productBLL.LayMaSanPham(txtTenSanPham.Text.Trim()));
                        string duongDanUngDung = AppDomain.CurrentDomain.BaseDirectory;
                        string duongDanThuMucAnh = Path.Combine(duongDanUngDung, @"Images\Toys\");
                        string[] danhSachDuongDan = Directory.GetFiles(duongDanThuMucAnh);

                        List<string> danhSachTenTep = new List<string>();

                        foreach (string duongDan in danhSachDuongDan)
                        {
                            string tenTep = Path.GetFileName(duongDan);
                            danhSachTenTep.Add(tenTep);
                        }

                        foreach (string tenTep in danhSachTenTep)
                        {
                            foreach (string item in lstURLImage)
                            {
                                if (tenTep.Trim().Equals(item.Trim()))
                                {
                                    string strtodelete = Path.Combine(duongDanUngDung, @"Images\Toys\" + tenTep + @"");
                                    File.Delete(strtodelete);
                                }
                            }
                        }

                        productBLL.XoaTatCaHinhAnhCuaSanPham(productBLL.LayMaSanPham(txtTenSanPham.Text.Trim()));
                        productBLL.XoaSanPham(txtTenSanPham.Text.Trim());
                        MessageBox.Show("Xóa thành công");
                        LoadTableProduct();
                        LoadTableHinhAnhSanPham(productBLL.LayMaSanPham(txtTenSanPham.Text.Trim()));
                        label14.Text = string.Empty;
                        pictureBox1.Image = null;
                        foreach (Guna2TextBox item in panel2.Controls.OfType<Guna2TextBox>())
                            item.Text = string.Empty;
                        txtMoTa.Text = string.Empty;
                        label17.Text = "Tổng số lượng sản phẩm đang có là: " + productBLL.DemSoLuongSanPham().ToString() + " sp";
                    }
                }
            }
            catch (Exception)
            {
                MessageBox.Show("Sản phẩm này đã được bán, không thể xóa", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            
        }

        private void btnSua_Click(object sender, EventArgs e)
        {
            if (txtTenSanPham.Text.Equals(string.Empty))
                MessageBox.Show("Chưa chọn sản phẩm cần sửa");
            else
            {
                DialogResult result = MessageBox.Show("Bạn có chắc chắn muốn sửa?", "Xác nhận", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                if (result == DialogResult.Yes)
                {
                    productBLL.CapNhatSanPham(txtTenSanPham.Text, cboGioiTinh.Text, txtXuatXu.Text, txtMoTa.Text, double.Parse(txtGiaGoc.Text), double.Parse(txtGiaGiam.Text),
                        productBLL.LayMaDanhMuc(cboDanhMuc.Text), productBLL.LayMaThuongHieu(cboThuongHieu.Text.Trim()));
                    MessageBox.Show("Sửa thành công");
                    LoadTableProduct();
                }
            }
        }

        private void txtGiaGoc_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar) &&
                e.KeyChar != (char)Keys.Left && e.KeyChar != (char)Keys.Right && e.KeyChar != (char)Keys.Delete)
            {
                e.Handled = true;
            }
        }

        private void txtGiaGiam_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar) &&
                e.KeyChar != (char)Keys.Left && e.KeyChar != (char)Keys.Right && e.KeyChar != (char)Keys.Delete)
            {
                e.Handled = true;
            }
        }

        private void btnNhapLai_Click(object sender, EventArgs e)
        {
            LoadTableProduct();
            btnThem.Enabled = true;
            btnXoa.Enabled = false;
            btnSua.Enabled = false;
            foreach (Guna2TextBox item in panel2.Controls.OfType<Guna2TextBox>())
                item.Text = string.Empty;
            txtMoTa.Text = string.Empty;
            pictureBox1.Image = null;
            LoadTableHinhAnhSanPham(0);
            btnThemHinhSP.Enabled = true;
            btnXoaHinhSP.Enabled = false;
            btnThemHinhSP.Enabled = false;
        }

        private void tblHinhAnhSanPham_Click(object sender, EventArgs e)
        {
            string linksanpham = tblHinhAnhSanPham.Rows[tblHinhAnhSanPham.CurrentRow.Index].Cells[0].Value.ToString();
            string duongDanUngDung = AppDomain.CurrentDomain.BaseDirectory;
            string imagePath = Path.Combine(duongDanUngDung, @"Images\Toys\" + linksanpham + @"");

            if (System.IO.File.Exists(imagePath))
            {
                pictureBox1.ImageLocation = imagePath;
                pictureBox1.SizeMode = PictureBoxSizeMode.Zoom;

                btnThemHinhSP.Enabled = false;
                btnXoaHinhSP.Enabled = true;
            }
            else
                MessageBox.Show("Hình ảnh không tồn tại.");
            label14.Text = linksanpham;

        }

        private void btnThemHinhSP_Click(object sender, EventArgs e)
        {
            OpenFileDialog openFileDialog = new OpenFileDialog();
            openFileDialog.Filter = "Image Files (*.png;*.jpg;*.jpeg;*.gif;*.bmp)|*.png;*.jpg;*.jpeg;*.gif;*.bmp|All files (*.*)|*.*";

            if (openFileDialog.ShowDialog() == DialogResult.OK)
            {
                string tenHinh = Path.GetFileName(openFileDialog.FileName);
                string duongDanUngDung = AppDomain.CurrentDomain.BaseDirectory;
                string duongDanThuMucAnh = Path.Combine(duongDanUngDung, @"Images\Toys\");
                string duongDanHinhMoi = Path.Combine(duongDanThuMucAnh, tenHinh);
                File.Copy(openFileDialog.FileName, duongDanHinhMoi, true);

                productBLL.ThemHinhAnhChoSanPham(productBLL.LayMaSanPham(txtTenSanPham.Text.Trim()),
                    tenHinh);
                LoadTableHinhAnhSanPham(productBLL.LayMaSanPham(txtTenSanPham.Text.Trim()));

                pictureBox1.SizeMode = PictureBoxSizeMode.Zoom;
                pictureBox1.ImageLocation = duongDanHinhMoi;
            }
        }

        private void btnXoaHinhSP_Click(object sender, EventArgs e)
        {
            DialogResult result = MessageBox.Show("Bạn có chắc chắn muốn xóa hình này?", "Xác nhận", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (result == DialogResult.Yes)
            {
                if (!(label14.Text == string.Empty))
                {
                    productBLL.XoaHinhAnhChoSanPham(label14.Text);
                    LoadTableHinhAnhSanPham(productBLL.LayMaSanPham(txtTenSanPham.Text.Trim()));
                    pictureBox1.Image = null;

                    string duongDanUngDung = AppDomain.CurrentDomain.BaseDirectory;
                    string imagePath = Path.Combine(duongDanUngDung, @"Images\Toys\" + label14.Text + @"");

                    if (File.Exists(imagePath))
                    {
                        File.Delete(imagePath);
                        label14.Text = string.Empty;
                    }

                    btnXoaHinhSP.Enabled = false;
                    btnThemHinhSP.Enabled = true;
                }
                else
                    MessageBox.Show("Chưa chọn hình để xóa");
            }
        }

        private void txtFind_TextChanged(object sender, EventArgs e)
        {
            switch (cboFind.SelectedIndex)
            {
                case 0:
                    tblProduct.DataSource = productBLL.TimKiemSanPhamTheoTenSP(txtFind.Text.Trim());
                    break;
                case 1:
                    tblProduct.DataSource = productBLL.TimKiemSanPhamXuatXu(txtFind.Text.Trim());
                    break;
                case 2:
                    tblProduct.DataSource = productBLL.TimKiemSanPhamGioiTinh(txtFind.Text.Trim());
                    break;
                case 3:
                    tblProduct.DataSource = productBLL.TimKiemSanPhamDanhMuc(txtFind.Text.Trim());
                    break;
                case 4:
                    tblProduct.DataSource = productBLL.TimKiemSanPhamThuongHieu(txtFind.Text.Trim());
                    break;
                default:
                    break;
            }
        }

        private void guna2Button1_Click(object sender, EventArgs e)
        {
            tensp = txtTenSanPham.Text.Trim();
            this.Visible = false;
            Program.importForm = new frmImport();
            Program.importForm.Show();
        }
    }
}
