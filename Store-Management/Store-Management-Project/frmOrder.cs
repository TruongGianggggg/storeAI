using AllControls;
using BLL;
using DTO;
using Microsoft.Office.Interop.Word;
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

namespace Store_Management_Project
{
    public partial class frmOrder : Form
    {
        ProductItem productItem;
        ProductBLL pbll;
        OrderBLL obll;
        public frmOrder()
        {
            InitializeComponent();
            pbll = new ProductBLL();
            obll = new OrderBLL();
            obll = new OrderBLL();
            comboBox1.SelectedIndex = 0;
            LoadTableHoaDon();
            if (obll.GetMaHoaDonDauTienChuaThanhToan() == string.Empty)
                lblMaHoaDon.Text = "";
            else
            {
                lblMaHoaDon.Text = obll.GetMaHoaDonDauTienChuaThanhToan();
                LoadTableChiTietHoaDon(lblMaHoaDon.Text);
            }
        }

        public void LoadTableHoaDon()
        {
            tblHoaDon.DataSource = obll.GetDataHoaDonChuaThanhToan();
            tblHoaDon.Columns[0].HeaderText = "Mã Hóa Đơn";
            tblHoaDon.Columns[1].HeaderText = "Tên Nhân Viên";
            tblHoaDon.Columns[2].HeaderText = "Ngày Lập";
            tblHoaDon.Columns[3].HeaderText = "Trạng Thái";
            tblHoaDon.Columns[4].HeaderText = "Tổng Tiền";
        }

        public void LoadTableChiTietHoaDon(string mahd)
        {
            tblChiTietHoaDon.DataSource = obll.GetDataChiTietHoaDon(mahd);
            tblChiTietHoaDon.Columns[0].HeaderText = "Mã CTHĐ";
            tblChiTietHoaDon.Columns[1].HeaderText = "Mã HĐ";
            tblChiTietHoaDon.Columns[2].HeaderText = "Tên Sản Phẩm";
            tblChiTietHoaDon.Columns[3].HeaderText = "Số Lượng";

            tblChiTietHoaDon.Columns[0].Width = 80;
            tblChiTietHoaDon.Columns[1].Width = 80;
            tblChiTietHoaDon.Columns[3].Width = 80;
        }

        //==============================================================================================
        public void LoadDataSanPham()
        {
            flowLayoutPanel1.Controls.Clear();
            List<ImageProductDTO> lstProduct = pbll.getHinhAnhSanPham();
            foreach (ImageProductDTO item in lstProduct)
            {
                productItem = new ProductItem(item.imglink, item.masp, item.tensp);
                flowLayoutPanel1.Controls.Add(productItem);
                Button btnChon = productItem.Controls.Find("btnChon", true).FirstOrDefault() as Button;
                if (btnChon != null)
                    btnChon.Click += (sender, e) =>
                    {
                        if (!pbll.KiemTraTonKho(int.Parse(item.masp.Trim())))
                            MessageBox.Show("Sản phẩm không có sẵn trong kho. Không thể chọn!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        else
                        {
                            lblMaSP.Text = item.masp;
                            lblTenSP.Text = item.tensp;
                            lblGioiTinh.Text = pbll.getGioiTinhSP(lblMaSP.Text);
                            lblXuatXu.Text = pbll.getXuatXuSP(lblMaSP.Text);
                            lblThuongHieu.Text = pbll.getThuongHieuSP(lblMaSP.Text);
                            lblDanhMuc.Text = pbll.getDanhMucSP(lblMaSP.Text);
                            lblGiaGiam.Text = pbll.getGiaGiamSP(lblMaSP.Text).ToString("N0") + "đ";
                            lblGiaGoc.Text = pbll.getGiaGocSP(lblMaSP.Text).ToString("N0") + "đ";
                            lblSoLuongSPTrongKho.Text = pbll.GetSoLuongCoTrongKho(lblMaSP.Text).ToString();
                        }
                    };
            }
        }
        public void LoadDataSanPhamTimKiem(string tensp)
        {
            flowLayoutPanel1.Controls.Clear();
            List<ImageProductDTO> lstProduct = pbll.getHinhAnhSanPham_TimKiem(tensp);
            foreach (ImageProductDTO item in lstProduct)
            {
                productItem = new ProductItem(item.imglink, item.masp, item.tensp);
                flowLayoutPanel1.Controls.Add(productItem);
                Button btnChon = productItem.Controls.Find("btnChon", true).FirstOrDefault() as Button;
                if (btnChon != null)
                    btnChon.Click += (sender, e) =>
                    {
                        if (!pbll.KiemTraTonKho(int.Parse(item.masp.Trim())))
                            MessageBox.Show("Sản phẩm không có sẵn trong kho. Không thể chọn!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        else
                        {
                            lblMaSP.Text = item.masp;
                            lblTenSP.Text = item.tensp;
                            lblGioiTinh.Text = pbll.getGioiTinhSP(lblMaSP.Text);
                            lblXuatXu.Text = pbll.getXuatXuSP(lblMaSP.Text);
                            lblThuongHieu.Text = pbll.getThuongHieuSP(lblMaSP.Text);
                            lblDanhMuc.Text = pbll.getDanhMucSP(lblMaSP.Text);
                            lblGiaGiam.Text = pbll.getGiaGiamSP(lblMaSP.Text).ToString("N0") + "đ";
                            lblGiaGoc.Text = pbll.getGiaGocSP(lblMaSP.Text).ToString("N0") + "đ";
                            lblSoLuongSPTrongKho.Text = pbll.GetSoLuongCoTrongKho(lblMaSP.Text).ToString();
                        }
                    };
            }
        }
        public void LoadDataSanPhamTheoThuongHieu(string str)
        {
            flowLayoutPanel1.Controls.Clear();
            List<ImageProductDTO> lstProduct = pbll.getHinhAnhSanPham_ThuongHieu(str);
            foreach (ImageProductDTO item in lstProduct)
            {
                productItem = new ProductItem(item.imglink, item.masp, item.tensp);
                flowLayoutPanel1.Controls.Add(productItem);
                Button btnChon = productItem.Controls.Find("btnChon", true).FirstOrDefault() as Button;
                if (btnChon != null)
                    btnChon.Click += (sender, e) =>
                    {
                        if (!pbll.KiemTraTonKho(int.Parse(item.masp.Trim())))
                            MessageBox.Show("Sản phẩm không có sẵn trong kho. Không thể chọn!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        else
                        {
                            lblMaSP.Text = item.masp;
                            lblTenSP.Text = item.tensp;
                            lblGioiTinh.Text = pbll.getGioiTinhSP(lblMaSP.Text);
                            lblXuatXu.Text = pbll.getXuatXuSP(lblMaSP.Text);
                            lblThuongHieu.Text = pbll.getThuongHieuSP(lblMaSP.Text);
                            lblDanhMuc.Text = pbll.getDanhMucSP(lblMaSP.Text);
                            lblGiaGiam.Text = pbll.getGiaGiamSP(lblMaSP.Text).ToString("N0") + "đ";
                            lblGiaGoc.Text = pbll.getGiaGocSP(lblMaSP.Text).ToString("N0") + "đ";
                            lblSoLuongSPTrongKho.Text = pbll.GetSoLuongCoTrongKho(lblMaSP.Text).ToString();
                        }
                    };
            }
        }
        public void LoadDataSanPhamTheoDanhMuc(string str)
        {
            flowLayoutPanel1.Controls.Clear();
            List<ImageProductDTO> lstProduct = pbll.getHinhAnhSanPham_DanhMuc(str);
            foreach (ImageProductDTO item in lstProduct)
            {
                productItem = new ProductItem(item.imglink, item.masp, item.tensp);
                flowLayoutPanel1.Controls.Add(productItem);
                Button btnChon = productItem.Controls.Find("btnChon", true).FirstOrDefault() as Button;
                if (btnChon != null)
                    btnChon.Click += (sender, e) =>
                    {
                        if (!pbll.KiemTraTonKho(int.Parse(item.masp.Trim())))
                            MessageBox.Show("Sản phẩm không có sẵn trong kho. Không thể chọn!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        else
                        {
                            lblMaSP.Text = item.masp;
                            lblTenSP.Text = item.tensp;
                            lblGioiTinh.Text = pbll.getGioiTinhSP(lblMaSP.Text);
                            lblXuatXu.Text = pbll.getXuatXuSP(lblMaSP.Text);
                            lblThuongHieu.Text = pbll.getThuongHieuSP(lblMaSP.Text);
                            lblDanhMuc.Text = pbll.getDanhMucSP(lblMaSP.Text);
                            lblGiaGiam.Text = pbll.getGiaGiamSP(lblMaSP.Text).ToString("N0") + "đ";
                            lblGiaGoc.Text = pbll.getGiaGocSP(lblMaSP.Text).ToString("N0") + "đ";
                            lblSoLuongSPTrongKho.Text = pbll.GetSoLuongCoTrongKho(lblMaSP.Text).ToString();
                        }
                    };
            }
        }
        public void LoadDataSanPhamTheoXuatXu(string str)
        {
            flowLayoutPanel1.Controls.Clear();
            List<ImageProductDTO> lstProduct = pbll.getHinhAnhSanPham_XuatXu(str);
            foreach (ImageProductDTO item in lstProduct)
            {
                productItem = new ProductItem(item.imglink, item.masp, item.tensp);
                flowLayoutPanel1.Controls.Add(productItem);
                Button btnChon = productItem.Controls.Find("btnChon", true).FirstOrDefault() as Button;
                if (btnChon != null)
                    btnChon.Click += (sender, e) =>
                    {
                        if (!pbll.KiemTraTonKho(int.Parse(item.masp.Trim())))
                            MessageBox.Show("Sản phẩm không có sẵn trong kho. Không thể chọn!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        else
                        {
                            lblMaSP.Text = item.masp;
                            lblTenSP.Text = item.tensp;
                            lblGioiTinh.Text = pbll.getGioiTinhSP(lblMaSP.Text);
                            lblXuatXu.Text = pbll.getXuatXuSP(lblMaSP.Text);
                            lblThuongHieu.Text = pbll.getThuongHieuSP(lblMaSP.Text);
                            lblDanhMuc.Text = pbll.getDanhMucSP(lblMaSP.Text);
                            lblGiaGiam.Text = pbll.getGiaGiamSP(lblMaSP.Text).ToString("N0") + "đ";
                            lblGiaGoc.Text = pbll.getGiaGocSP(lblMaSP.Text).ToString("N0") + "đ";
                            lblSoLuongSPTrongKho.Text = pbll.GetSoLuongCoTrongKho(lblMaSP.Text).ToString();
                        }
                    };
            }
        }
        public void LoadDataSanPhamTheoGioiTinh(string str)
        {
            flowLayoutPanel1.Controls.Clear();
            List<ImageProductDTO> lstProduct = pbll.getHinhAnhSanPham_GioiTinh(str);
            foreach (ImageProductDTO item in lstProduct)
            {
                productItem = new ProductItem(item.imglink, item.masp, item.tensp);
                flowLayoutPanel1.Controls.Add(productItem);
                Button btnChon = productItem.Controls.Find("btnChon", true).FirstOrDefault() as Button;
                if (btnChon != null)
                    btnChon.Click += (sender, e) =>
                    {
                        if (!pbll.KiemTraTonKho(int.Parse(item.masp.Trim())))
                            MessageBox.Show("Sản phẩm không có sẵn trong kho. Không thể chọn!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        else
                        {
                            lblMaSP.Text = item.masp;
                            lblTenSP.Text = item.tensp;
                            lblGioiTinh.Text = pbll.getGioiTinhSP(lblMaSP.Text);
                            lblXuatXu.Text = pbll.getXuatXuSP(lblMaSP.Text);
                            lblThuongHieu.Text = pbll.getThuongHieuSP(lblMaSP.Text);
                            lblDanhMuc.Text = pbll.getDanhMucSP(lblMaSP.Text);
                            lblGiaGiam.Text = pbll.getGiaGiamSP(lblMaSP.Text).ToString("N0") + "đ";
                            lblGiaGoc.Text = pbll.getGiaGocSP(lblMaSP.Text).ToString("N0") + "đ";
                            lblSoLuongSPTrongKho.Text = pbll.GetSoLuongCoTrongKho(lblMaSP.Text).ToString();
                        }
                    };
            }
        }


        //==============================================================================================


        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (comboBox1.SelectedIndex == 0)
            {
                txtTimKiem.Visible = true;
                comboBox2.Visible = false;
                LoadDataSanPham();
            }
            if (comboBox1.SelectedIndex == 1)
            {
                txtTimKiem.Visible = true;
                comboBox2.Visible = false;
            }
            if (comboBox1.SelectedIndex == 2)
            {
                txtTimKiem.Visible = false;
                comboBox2.Visible = true;
                LoadComboboxTheoDieuKien(2);
            }
            if (comboBox1.SelectedIndex == 3)
            {
                txtTimKiem.Visible = false;
                comboBox2.Visible = true;
                LoadComboboxTheoDieuKien(3);
            }
            if (comboBox1.SelectedIndex == 4)
            {
                txtTimKiem.Visible = false;
                comboBox2.Visible = true;
                LoadComboboxTheoDieuKien(4);
            }
            if (comboBox1.SelectedIndex == 5)
            {
                txtTimKiem.Visible = false;
                comboBox2.Visible = true;
                LoadComboboxTheoDieuKien(5);
            }
        }

        public void LoadComboboxTheoDieuKien(int i)
        {
            if (i == 2)
                comboBox2.DataSource = obll.GetDanhSachTenThuongHieu();
            if (i == 3)
                comboBox2.DataSource = obll.GetDanhSachTenDanhMuc();
            if (i == 4)
                comboBox2.DataSource = obll.GetDistinctXuatXuList();
            if (i == 5)
                comboBox2.DataSource = obll.GetDanhSachGioiTinhSanPham();
        }

        private void comboBox2_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (comboBox1.SelectedIndex == 2)
                LoadDataSanPhamTheoThuongHieu(comboBox2.Text);
            if (comboBox1.SelectedIndex == 3)
                LoadDataSanPhamTheoDanhMuc(comboBox2.Text);
            if (comboBox1.SelectedIndex == 4)
                LoadDataSanPhamTheoXuatXu(comboBox2.Text);
            if (comboBox1.SelectedIndex == 5)
                LoadDataSanPhamTheoGioiTinh(comboBox2.Text);
        }

        private void txtTimKiem_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)Keys.Enter)
            {
                LoadDataSanPhamTimKiem(txtTimKiem.Text);
            }
        }

        private void btnTaoPhieu_Click(object sender, EventArgs e)
        {
            obll.ThemHoaDon(frmLogin.manhanvien, DateTime.Now);
            LoadTableHoaDon();
            lblMaHoaDon.Text = obll.GetMaHoaDonDauTienChuaThanhToan();
            btnXoaPhieu.Visible = true;
            btnTaoPhieu.Visible = false;
            panel2.Enabled = true;
            flowLayoutPanel1.Enabled = true;
            btnThem.Enabled = true;
            btnXoa.Enabled = true;
            btnSua.Enabled = true;
            btnThanhToan.Enabled = true;
        }

        private void btnThem_Click(object sender, EventArgs e)
        {
            if (lblMaSP.Text == "...")
                MessageBox.Show("Chưa chọn sản phẩm!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            else
            {
                if (txtNhapSoLuong.Text == string.Empty)
                    MessageBox.Show("Chưa nhập số lượng cho sản phẩm!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                else
                {
                    if (!lblMaSP.Text.Equals(string.Empty) && !txtNhapSoLuong.Text.Equals(string.Empty))
                    {
                        if (int.Parse(txtNhapSoLuong.Text) <= obll.GetSoLuongSanPhamTrongKho(lblMaSP.Text))
                        {
                            //obll.SoLuongTrongKhoHang(lblTenSP.Text)
                            if (int.Parse(txtNhapSoLuong.Text) <= int.Parse(lblSoLuongSPTrongKho.Text))
                            {
                                obll.ThemChiTietHoaDon(lblMaHoaDon.Text, int.Parse(lblMaSP.Text), int.Parse(txtNhapSoLuong.Text));
                                //pbll.CapNhatSoLuongSanPhamTrongKho(lblMaSP.Text, int.Parse(txtNhapSoLuong.Text));
                                LoadTableChiTietHoaDon(lblMaHoaDon.Text);

                                obll.CapNhatSanPhamTrongKhoHang(lblMaSP.Text, int.Parse(lblSoLuongSPTrongKho.Text.Trim()) - int.Parse(txtNhapSoLuong.Text.Trim()));
                                lblSoLuongSPTrongKho.Text = obll.GetSoLuongSanPhamTrongKho(lblMaSP.Text).ToString();

                                txtNhapSoLuong.Text = string.Empty;
                            }
                            else
                                MessageBox.Show("Không đủ số lượng trong kho để đặt thêm cho mặt hàng này", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        }
                        else
                            MessageBox.Show("Không đủ số lượng trong kho để đặt", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    }
                }
            }
        }

        private void btnXoa_Click(object sender, EventArgs e)
        {
            DialogResult result = MessageBox.Show("Bạn có chắc chắn muốn xóa này?", "Xác nhận", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

            if (result == DialogResult.Yes)
            {
                if (soluong != 0)
                {
                    obll.XoaChiTietHoaDonOffline(int.Parse(lblMaCTHD.Text));
                    LoadTableChiTietHoaDon(lblMaHoaDon.Text);
                    lblMaCTHD.Text = string.Empty;

                    obll.CapNhatSanPhamTrongKhoHang(lblMaSP.Text, (
                        soluong
                        + int.Parse(lblSoLuongSPTrongKho.Text)));

                    lblSoLuongSPTrongKho.Text = obll.GetSoLuongSanPhamTrongKho(lblMaSP.Text).ToString();
                    soluong = 0;
                }
                else
                    MessageBox.Show("Chưa chọn sản phẩm để xóa", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        int soluong;
        private void tblChiTietHoaDon_Click(object sender, EventArgs e)
        {
            if (tblChiTietHoaDon != null && tblChiTietHoaDon.Rows.Count > 0)
            {
                int i = tblChiTietHoaDon.CurrentRow.Index;
                label9.Visible = true;
                lblMaCTHD.Visible = true;
                lblMaCTHD.Text = tblChiTietHoaDon.Rows[i].Cells[0].Value.ToString();
                lblTenSP.Text = tblChiTietHoaDon.Rows[i].Cells[2].Value.ToString();
                soluong = int.Parse(tblChiTietHoaDon.Rows[i].Cells[3].Value.ToString());
                lblMaSP.Text = obll.GetIdSanPhamByTen(lblTenSP.Text);
                lblSoLuongSPTrongKho.Text = pbll.GetSoLuongCoTrongKho(lblMaSP.Text).ToString();
            }
            else
                MessageBox.Show("Chưa có dữ liệu để chọn");
        }

        private void btnSua_Click(object sender, EventArgs e)
        {
            if (!lblMaCTHD.Text.Equals(string.Empty))
            {
                if (!txtNhapSoLuong.Text.Equals(string.Empty))
                {
                    if (int.Parse(txtNhapSoLuong.Text) <= obll.GetSoLuongSanPhamTrongKho(lblMaSP.Text))
                    {
                        DialogResult result = MessageBox.Show("Bạn có chắc chắn muốn cập nhật mới?", "Xác nhận", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                        if (result == DialogResult.Yes)
                        {
                            int i = tblChiTietHoaDon.CurrentRow.Index;
                            int soluongdangco = int.Parse(tblChiTietHoaDon.Rows[i].Cells[3].Value.ToString());
                            int soluongmoi = int.Parse(txtNhapSoLuong.Text);
                            if (soluongmoi == soluongdangco)
                            {
                                obll.SuaSoLuongChiTietHoaDonOffline(int.Parse(lblMaCTHD.Text), int.Parse(txtNhapSoLuong.Text));
                                LoadTableChiTietHoaDon(lblMaHoaDon.Text);
                                txtNhapSoLuong.Text = string.Empty;
                                lblMaCTHD.Text = string.Empty;
                                lblSoLuongSPTrongKho.Text = obll.GetSoLuongSanPhamTrongKho(lblMaSP.Text).ToString();
                            }
                            else if (soluongmoi > soluongdangco)
                            {
                                obll.SuaSoLuongChiTietHoaDonOffline(int.Parse(lblMaCTHD.Text), int.Parse(txtNhapSoLuong.Text));
                                LoadTableChiTietHoaDon(lblMaHoaDon.Text);
                                txtNhapSoLuong.Text = string.Empty;
                                lblMaCTHD.Text = string.Empty;
                                int soluongtanglen = soluongmoi - soluongdangco;
                                int soluongdecapnhat = int.Parse(lblSoLuongSPTrongKho.Text) - soluongtanglen;
                                obll.CapNhatSanPhamTrongKhoHang(lblMaSP.Text, soluongdecapnhat);
                                lblSoLuongSPTrongKho.Text = obll.GetSoLuongSanPhamTrongKho(lblMaSP.Text).ToString();
                            }
                            else if (soluongmoi < soluongdangco)
                            {
                                obll.SuaSoLuongChiTietHoaDonOffline(int.Parse(lblMaCTHD.Text), int.Parse(txtNhapSoLuong.Text));
                                LoadTableChiTietHoaDon(lblMaHoaDon.Text);
                                txtNhapSoLuong.Text = string.Empty;
                                lblMaCTHD.Text = string.Empty;
                                int soluonggiamdi = soluongdangco - soluongmoi;
                                int soluongdecapnhat = int.Parse(lblSoLuongSPTrongKho.Text) + soluonggiamdi;
                                obll.CapNhatSanPhamTrongKhoHang(lblMaSP.Text, soluongdecapnhat);
                                lblSoLuongSPTrongKho.Text = obll.GetSoLuongSanPhamTrongKho(lblMaSP.Text).ToString();
                            }
                        }
                    }
                    else
                        MessageBox.Show("Không đủ số lượng trong kho để đặt", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
                else
                    MessageBox.Show("Số lượng đang trống", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            else
                MessageBox.Show("Bạn chưa chọn sản phẩm cần sửa", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
        }

        private void btnThanhToan_Click(object sender, EventArgs e)
        {
            btnThem.Enabled = false;
            btnXoa.Enabled = false;
            btnSua.Enabled = false;
            obll.TinhTongTien(lblMaHoaDon.Text);
            lblTongTienHoaDon.Text = obll.GetTongTienHoaDon(lblMaHoaDon.Text).ToString("N0") + "đ";
            btnXuatHoaDon.Enabled = true;
            btnHoanTat.Enabled = true;
            lblMaCTHD.Text = string.Empty;
            txtNhapSoLuong.Text = string.Empty;
        }

        private void btnXuatHoaDon_Click(object sender, EventArgs e)
        {
            ThemDuLieuVaoFileWord(lblMaHoaDon.Text, "Phạm Lê Tuấn Anh",
                DateTime.Now.ToString("dd/MM/yyyy HH:MM:ss"), lblTongTienHoaDon.Text);
            MoTepWordTuDuongDanTuongDoi();
        }

        private void ThayDoiGiaTriTruong(Microsoft.Office.Interop.Word.Document doc, string tenTruong, string giaTriMoi)
        {
            foreach (Microsoft.Office.Interop.Word.Field field in doc.Fields)
            {
                if (field.Code.Text.Contains(tenTruong))
                {
                    field.Select();
                    Microsoft.Office.Interop.Word.Selection selection = doc.Application.Selection;
                    selection.Range.InsertAfter(giaTriMoi);
                    selection.TypeBackspace();
                    break;
                }
            }
        }

        private void ThemDuLieuVaoFileWord(string mahd, string tennv, string thoigian, string tongtien)
        {
            string duongDanUngDung = AppDomain.CurrentDomain.BaseDirectory;
            string duongDanTepWord = Path.Combine(duongDanUngDung, @"Bill\PrintBill.docx");
            if (File.Exists(duongDanTepWord))
            {
                Microsoft.Office.Interop.Word.Application wordApp = new Microsoft.Office.Interop.Word.Application();
                Document doc = wordApp.Documents.Open(duongDanTepWord, ReadOnly: true);
                ThayDoiGiaTriTruong(doc, "MaHoaDon", mahd);
                ThayDoiGiaTriTruong(doc, "TenNhanVien", tennv);
                ThayDoiGiaTriTruong(doc, "NgayLap", thoigian);


                var lstDatHang = obll.InBill(mahd);
                if (lstDatHang.Any())
                {

                    Range endRange = doc.Range();
                    endRange.Find.Execute("Thông tin chi tiết hóa đơn:", Forward: false);
                    Range endOfTenNhanVien = endRange.Duplicate;
                    endOfTenNhanVien.MoveEnd(WdUnits.wdParagraph, 1);
                    int endPosition = endOfTenNhanVien.End;

                    Table table = doc.Tables.Add(doc.Range(endPosition), 1, 3);
                    table.Borders.Enable = 1;
                    table.Cell(1, 1).Range.Text = "Tên Sản Phẩm";
                    table.Cell(1, 2).Range.Text = "Giá";
                    table.Cell(1, 2).Range.ParagraphFormat.Alignment = WdParagraphAlignment.wdAlignParagraphRight;
                    table.Cell(1, 3).Range.Text = "Số Lượng";
                    table.Cell(1, 3).Range.ParagraphFormat.Alignment = WdParagraphAlignment.wdAlignParagraphRight;
                    table.Range.Font.Size = 13;

                    int rowIndex = 2;
                    foreach (var item in lstDatHang)
                    {
                        table.Rows.Add();
                        table.Cell(rowIndex, 1).Range.Text = item.tensp;
                        table.Cell(rowIndex, 2).Range.Text = item.giasp.ToString("N0") + "đ";
                        table.Cell(rowIndex, 3).Range.Text = item.soluong.ToString();
                        rowIndex++;
                    }
                }

                doc.Paragraphs.Add();
                Paragraph text1 = doc.Paragraphs.Add();
                text1.Range.Text = "Tổng tiền hóa đơn: " + tongtien;
                text1.Format.Alignment = Microsoft.Office.Interop.Word.WdParagraphAlignment.wdAlignParagraphRight;
                text1.Range.Font.Bold = 0;
                text1.Range.Font.Size = 13;
                //Paragraph text2 = doc.Paragraphs.Add();
                //text2.Range.Text = "Tổng hóa đơn có trong " + thoigian + " là: " + tonghoadon + "\n";
                //text2.Format.Alignment = Microsoft.Office.Interop.Word.WdParagraphAlignment.wdAlignParagraphLeft;
                //text2.Range.Font.Bold = 0;
                //text2.Range.Font.Size = 13;
                //Paragraph text3 = doc.Paragraphs.Add();
                //text3.Range.Text = "Tổng doanh thu trong " + thoigian + " là: " + doanhthu + "\n";
                //text3.Format.Alignment = Microsoft.Office.Interop.Word.WdParagraphAlignment.wdAlignParagraphLeft;
                //text3.Range.Font.Bold = 0;
                //text3.Range.Font.Size = 13;
                //Paragraph text4 = doc.Paragraphs.Add();
                //text4.Range.Text = "Danh sách các phòng được đặt nhiều hơn 1 lần là:\n";
                //text4.Format.Alignment = Microsoft.Office.Interop.Word.WdParagraphAlignment.wdAlignParagraphLeft;
                //text4.Range.Font.Bold = 0;
                //text4.Range.Font.Size = 13;



                wordApp.Visible = true;
            }
            else
            {
                MessageBox.Show("Tệp Word không tồn tại.");
            }
        }

        private void MoTepWordTuDuongDanTuongDoi()
        {
            string duongDanUngDung = AppDomain.CurrentDomain.BaseDirectory;
            string duongDanTepWord = Path.Combine(duongDanUngDung, @"Bill\PrintBill.docx");

            if (File.Exists(duongDanTepWord))
            {
                Microsoft.Office.Interop.Word.Application wordApp = new Microsoft.Office.Interop.Word.Application();
                Microsoft.Office.Interop.Word.Document doc = wordApp.Documents.Open(duongDanTepWord, ReadOnly: true);

            }
            else
                MessageBox.Show("Tệp Word không tồn tại.");
        }

        private void btnHoanTat_Click(object sender, EventArgs e)
        {
            DialogResult result = MessageBox.Show("Bạn có chắc chắn muốn hoàn tất thanh toán?", "Xác nhận", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

            if (result == DialogResult.Yes)
            {
                string str1 = lblTongTienHoaDon.Text.Trim().Replace(",", "");
                string str2 = str1.Replace("đ", "");
                obll.CapNhatTrangThaiDonHang(lblMaHoaDon.Text.Trim(), double.Parse(str2));
                LoadTableHoaDon();
                LoadTableChiTietHoaDon("");
                btnTaoPhieu.Visible = true;
                btnXoaPhieu.Visible = false;
                panel2.Enabled = false;
                flowLayoutPanel1.Enabled = false;
                lblTongTienHoaDon.Text = string.Empty;
                lblMaHoaDon.Text = string.Empty;
                btnThanhToan.Enabled = false;
                btnXuatHoaDon.Enabled = false;
                btnHoanTat.Enabled = false;
            }
        }

        private void btnXoaPhieu_Click(object sender, EventArgs e)
        {
            if (obll.KiemTraBangCTHD(lblMaHoaDon.Text) == false)
            {
                obll.XoaHoaDon(lblMaHoaDon.Text);
                LoadTableHoaDon();
                btnXoaPhieu.Visible = false;
                btnTaoPhieu.Visible = true;
                panel2.Enabled = false;
                flowLayoutPanel1.Enabled = false;
                btnThem.Enabled = false;
                btnXoa.Enabled = false;
                btnSua.Enabled = false;
                btnThanhToan.Enabled = false;
            }
            else
            {
                obll.XoaCTHoaDon(lblMaHoaDon.Text);
                obll.XoaHoaDon(lblMaHoaDon.Text);
                LoadTableHoaDon();
                LoadTableChiTietHoaDon(lblMaHoaDon.Text);
                lblMaHoaDon.Text = string.Empty;
                btnXoaPhieu.Visible = false;
                btnTaoPhieu.Visible = true;
                panel2.Enabled = false;
                flowLayoutPanel1.Enabled = false;
                btnThem.Enabled = false;
                btnXoa.Enabled = false;
                btnSua.Enabled = false;
                btnThanhToan.Enabled = false;
            }
        }

        private void label16_Click(object sender, EventArgs e)
        {
            if (tblHoaDon.Rows.Count < 0 || tblChiTietHoaDon.Rows.Count < 0)
            {
                this.Visible = false;
                Program.mainForm = new frmMain();
                Program.mainForm.Show();
            }
            else
            {
                DialogResult result = MessageBox.Show("Bạn có chắc chắn muốn thoát, toàn bộ thông tin sẽ bị xóa?", "Xác nhận", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

                if (result == DialogResult.Yes)
                {
                    obll.XoaCTHoaDon(lblMaHoaDon.Text);
                    obll.XoaHoaDon(lblMaHoaDon.Text);
                    this.Visible = false;
                    Program.mainForm = new frmMain();
                    Program.mainForm.Show();
                }
            }
        }

    }
}
