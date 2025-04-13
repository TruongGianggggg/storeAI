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

    public partial class frmImport : Form
    {
        ImportBLL importBLL;
        DeatailImportDTO deatailImportDTO;
        ProductBLL pbll;

        public frmImport()
        {

            InitializeComponent();
            importBLL = new ImportBLL();
            pbll = new ProductBLL();
            deatailImportDTO = new DeatailImportDTO();
            LoadTableNhapKho();
            LoadDataSanPham();
            comboBox1.SelectedIndex = 0;
        }

        public void LoadTableNhapKho()
        {
            tblNhapKho.DataSource = importBLL.GetDataNhapKho();
            tblNhapKho.Columns[0].HeaderText = "Mã Nhập Kho";
            tblNhapKho.Columns[1].HeaderText = "Mã Nhân Viên";
            tblNhapKho.Columns[2].HeaderText = "Ngày Lập";
            tblNhapKho.Columns[3].HeaderText = "Trạng Thái";

        }

        public void LoadTableChiTietNhapKho(int mank)
        {
            tblChiTietNhapKho.DataSource = importBLL.GetDataChiTietNhapKho(mank);
            tblChiTietNhapKho.Columns[0].HeaderText = "Mã CTNK";
            tblChiTietNhapKho.Columns[1].HeaderText = "Mã NK";
            tblChiTietNhapKho.Columns[2].HeaderText = "Tên Sản Phẩm";
            tblChiTietNhapKho.Columns[3].HeaderText = "Số Lượng";

            tblChiTietNhapKho.Columns[0].Width = 50;
            tblChiTietNhapKho.Columns[1].Width = 50;
            tblChiTietNhapKho.Columns[3].Width = 50;
        }

        public void LoadDataSanPham()
        {
            tblProduct.DataSource = pbll.getDanhSachSanPham();
            tblProduct.Columns[0].HeaderText = "Tên SP";
            tblProduct.Columns[1].HeaderText = "Giới tính";
            tblProduct.Columns[2].HeaderText = "Xuất xứ";
            tblProduct.Columns[3].HeaderText = "Mô tả";
            tblProduct.Columns[4].HeaderText = "Giá gốc";
            tblProduct.Columns[5].HeaderText = "Giá giảm";
            tblProduct.Columns[6].HeaderText = "Danh mục";
            tblProduct.Columns[7].HeaderText = "Thương hiệu";

            tblProduct.Columns[0].Width = 200;
            tblProduct.Columns[4].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
            tblProduct.Columns[5].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
            tblProduct.Columns[6].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
        }


        public void LoadComboboxTheoDieuKien(int i)
        {
            if (i == 2)
            {
                comboBox2.DataSource = importBLL.GetDanhSachTenThuongHieu();
            }
            if (i == 3)
            {
                comboBox2.DataSource = importBLL.GetDanhSachTenDanhMuc();
            }
            if (i == 4)
            {
                comboBox2.DataSource = importBLL.GetDistinctXuatXuList();
            }
            if (i == 5)
            {
                comboBox2.DataSource = importBLL.GetDanhSachGioiTinhSanPham();
            }
        }

        public void TimKiemTenSanPham()
        {
            string searchText = txtTimKiem.Text.Trim();

            if (string.IsNullOrEmpty(searchText))
            {
                LoadDataSanPham();
            }
            else
            {
                tblProduct.DataSource = pbll.getDanhSachSanPham(searchText);
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
                tblProduct.Columns[6].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
            }
        }


        ///////////////       

        private void button1_Click_1(object sender, EventArgs e)
        {
            importBLL.ThemNhapKho(2, DateTime.Now);
            LoadTableNhapKho();
            button1.Enabled = false;
            button2.Enabled = true;
        }

        private void button2_Click_1(object sender, EventArgs e)
        {
            if (tblChiTietNhapKho.Rows.Count > 0)
            {
                MessageBox.Show("Bảng chi tiết phiếu kho còn sản phẩm vui lòng xóa!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else
            {
                if (lblMaNhapKho.Text == string.Empty)
                {
                    MessageBox.Show("Bạn chưa chọn phiếu để xóa nào!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                else
                {
                    DialogResult result = MessageBox.Show("Bạn có chắc chắn muốn xóa phiếu nhập kho này?", "Xác nhận xóa", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                    if (result == DialogResult.Yes)
                    {
                        importBLL.XoaNhapKho(lblMaNhapKho.Text);
                        LoadTableNhapKho();
                    }
                    lblMaNhapKho.Text = string.Empty;
                    lblTenNhanVien.Text = string.Empty;
                    lblNgayLap.Text = string.Empty;

                    button1.Enabled = true;
                    button2.Enabled = false;
                }
            }
        }

        private void guna2Button1_Click_1(object sender, EventArgs e)
        {
            if (tblNhapKho.Rows.Count > 0)
            {
                int maNhapKho = int.Parse(tblNhapKho.Rows[0].Cells[0].Value.ToString());
                importBLL.CapNhatTrangThaiNhapKho(maNhapKho, "Hoàn thành");

                List<ChiTietNhapKho> lst = importBLL.GetDataChiTietNhapKho1(maNhapKho);
                foreach (var item in lst)
                {
                    if (importBLL.KiemTraSanPhamCoTrongKho((int)item.MaSanPham) == true)
                    {
                        importBLL.UpdateSoLuongSanPham((int)item.MaSanPham,
                        importBLL.LaySoLuongSanPhamTrongKho((int)item.MaSanPham) + item.SoLuongNhapKho);
                    }
                    else if (importBLL.KiemTraSanPhamCoTrongKho((int)item.MaSanPham) == false)
                    {
                        importBLL.ThemSanPhamMoiVaoKhoHang((int)item.MaSanPham, (int)item.SoLuongNhapKho);
                    }
                }


                tblNhapKho.DataSource = null;
                tblChiTietNhapKho.DataSource = null;

                LoadTableNhapKho();

                button1.Visible = true;
                button2.Visible = false;
                lblMaNhapKho.Text = string.Empty;
                lblTenNhanVien.Text = string.Empty;
                lblNgayLap.Text = string.Empty;
            }
            else
            {
                MessageBox.Show("Không có dữ liệu để hoàn thành.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        private void btnLuu_Click_1(object sender, EventArgs e)
        {
            if (!lblMaNhapKho.Text.Equals(string.Empty))
            {
                if (lblMaSanPham.Text.Equals("0"))
                    MessageBox.Show("Bạn chưa chọn sản phẩm nào!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                else
                {
                    if (txtSoLuong.Text.Equals(string.Empty))
                        MessageBox.Show("Bạn chưa nhập số lượng!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    else
                    {
                        importBLL.ThemChiTietNhapKho(int.Parse(lblMaNhapKho.Text), int.Parse(lblMaSanPham.Text), int.Parse(txtSoLuong.Text));
                        LoadTableChiTietNhapKho(int.Parse(lblMaNhapKho.Text));
                        txtSoLuong.Text = string.Empty;
                        txtSoLuong.Focus();
                    }
                }
            }
            else
                MessageBox.Show("Bạn chưa chọn hóa đơn nào!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);

        }

        private void btnXoa_Click_1(object sender, EventArgs e)
        {
            DialogResult result = MessageBox.Show("Bạn có chắc chắn muốn xóa sản phẩm này ra khỏi kho không ?", "Xác nhận xóa", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (result == DialogResult.Yes)
            {
                importBLL.XoaChiTietNhapKho(lblMaCTHD.Text);
                LoadTableChiTietNhapKho(int.Parse(lblMaNhapKho.Text));
            }
        }

        private void btnSua_Click(object sender, EventArgs e)
        {
            if (!string.IsNullOrEmpty(lblMaCTHD.Text))
            {
                // Kiểm tra xem người dùng đã nhập số lượng mới chưa
                if (!string.IsNullOrEmpty(txtSoLuongDaChon.Text))
                {
                    try
                    {
                        // Chuyển đổi số lượng mới từ chuỗi sang kiểu int
                        int soLuongMoi = int.Parse(txtSoLuongDaChon.Text);

                        // Gọi phương thức cập nhật số lượng trong BLL
                        importBLL.SuaSoLuongChiTietNhapKho(int.Parse(lblMaCTHD.Text), soLuongMoi);

                        // Cập nhật lại bảng chi tiết nhập kho
                        LoadTableChiTietNhapKho(int.Parse(lblMaNhapKho.Text));

                        // Hiển thị thông báo thành công
                        MessageBox.Show("Cập nhật số lượng thành công.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                    catch (FormatException)
                    {
                        MessageBox.Show("Vui lòng nhập số lượng là một số nguyên dương.", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show($"Lỗi: {ex.Message}", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
                else
                {
                    MessageBox.Show("Vui lòng nhập số lượng mới.", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            else
            {
                MessageBox.Show("Chưa chọn chi tiết nhập kho để cập nhật.", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void tblNhapKho_Click(object sender, EventArgs e)
        {
            if (tblNhapKho != null && tblNhapKho.Rows.Count > 0)
            {
                int i = tblNhapKho.CurrentRow.Index;
                lblMaNhapKho.Text = tblNhapKho.Rows[i].Cells[0].Value.ToString();
                lblTenNhanVien.Text = tblNhapKho.Rows[i].Cells[1].Value.ToString();
                lblNgayLap.Text = tblNhapKho.Rows[i].Cells[2].Value.ToString();
                LoadTableChiTietNhapKho(int.Parse(tblNhapKho.Rows[i].Cells[0].Value.ToString()));
                button2.Enabled = true;
            }
            else
                MessageBox.Show("Chưa có dữ liệu để chọn");
        }

        private void tblProduct_Click(object sender, EventArgs e)
        {
            int i = tblProduct.CurrentRow.Index;
            lblMaSanPham.Text = pbll.GetIdSanPham(tblProduct.Rows[i].Cells[0].Value.ToString()).ToString();
            btnLuu.Enabled = true;
            btnXoa.Enabled = false;
            btnSua.Enabled = false;
            txtSoLuong.Focus();
        }

        private void comboBox2_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (comboBox1.SelectedIndex == 2)
                tblProduct.DataSource = pbll.TimKiemSanPhamTheoThuongHieu(comboBox2.Text.Trim());
            if (comboBox1.SelectedIndex == 3)
                tblProduct.DataSource = pbll.TimKiemSanPhamTheoDanhMuc(comboBox2.Text.Trim());
            if (comboBox1.SelectedIndex == 4)
                tblProduct.DataSource = pbll.TimKiemSanPhamTheoXuatXu(comboBox2.Text.Trim());
            if (comboBox1.SelectedIndex == 5)
                tblProduct.DataSource = pbll.TimKiemSanPhamTheoGioiTinh(comboBox2.Text.Trim());
        }

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
                LoadDataSanPham();
            }
            if (comboBox1.SelectedIndex == 2)
            {
                txtTimKiem.Visible = false;
                comboBox2.Visible = true;
                LoadComboboxTheoDieuKien(2);
                tblProduct.DataSource = pbll.TimKiemSanPhamTheoThuongHieu(comboBox2.Text.Trim());
            }
            if (comboBox1.SelectedIndex == 3)
            {
                txtTimKiem.Visible = false;
                comboBox2.Visible = true;
                LoadComboboxTheoDieuKien(3);
                tblProduct.DataSource = pbll.TimKiemSanPhamTheoDanhMuc(comboBox2.Text.Trim());
            }
            if (comboBox1.SelectedIndex == 4)
            {
                txtTimKiem.Visible = false;
                comboBox2.Visible = true;
                LoadComboboxTheoDieuKien(4);
                tblProduct.DataSource = pbll.TimKiemSanPhamTheoXuatXu(comboBox2.Text.Trim());
            }
            if (comboBox1.SelectedIndex == 5)
            {
                txtTimKiem.Visible = false;
                comboBox2.Visible = true;
                LoadComboboxTheoDieuKien(5);
                tblProduct.DataSource = pbll.TimKiemSanPhamTheoGioiTinh(comboBox2.Text.Trim());
            }
        }

        private void txtTimKiem_TextChanged_1(object sender, EventArgs e)
        {
            TimKiemTenSanPham();
        }

        private void tblChiTietNhapKho_Click(object sender, EventArgs e)
        {
            if (tblChiTietNhapKho != null && tblChiTietNhapKho.Rows.Count > 0)
            {
                panel1.Visible = true;
                int i = tblChiTietNhapKho.CurrentRow.Index;
                lblMaCTHD.Text = tblChiTietNhapKho.Rows[i].Cells[0].Value.ToString();
                txtTenSPDaChon.Text = tblChiTietNhapKho.Rows[i].Cells[2].Value.ToString();
                txtSoLuongDaChon.Text = tblChiTietNhapKho.Rows[i].Cells[3].Value.ToString();

                panel3.Visible = true;
                btnXoa.Enabled = true;
                btnSua.Enabled = true;
                btnLuu.Enabled = false;
            }
            else
                MessageBox.Show("Chưa có dữ liệu", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
        }

        private void label14_Click(object sender, EventArgs e)
        {
            if (tblNhapKho.Rows.Count < 0 || tblChiTietNhapKho.Rows.Count < 0)
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
                    importBLL.XoaChiTietNhapKho(lblMaNhapKho.Text);
                    importBLL.XoaNhapKho(lblMaNhapKho.Text);
                    this.Visible = false;
                    Program.mainForm = new frmMain();
                    Program.mainForm.Show();
                }
            }


        }

        private void guna2Button2_Click(object sender, EventArgs e)
        {
            this.Visible = false;
            Program.importfinishForm = new frmImportFinsh();
            Program.importfinishForm.Show();
        }

        private void guna2Button3_Click(object sender, EventArgs e)
        {
            ThemDuLieuVaoFileWord(lblMaNhapKho.Text, "Phạm Lê Tuấn Anh",
                DateTime.Now.ToString("dd/MM/yyyy HH:MM:ss"), txtSoLuongDaChon.Text);
            MoTepWordTuDuongDanTuongDoi();
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


                var lstDatHang = importBLL.InBill(mahd);
                if (lstDatHang.Any())
                {

                    Range endRange = doc.Range();
                    endRange.Find.Execute("Thông tin chi tiết hóa đơn:", Forward: false);
                    Range endOfTenNhanVien = endRange.Duplicate;
                    endOfTenNhanVien.MoveEnd(WdUnits.wdParagraph, 1);
                    int endPosition = endOfTenNhanVien.End;

                    Table table = doc.Tables.Add(doc.Range(endPosition), 1, 2);
                    table.Borders.Enable = 1;
                    table.Cell(1, 1).Range.Text = "Tên Sản Phẩm";
                    table.Cell(1, 2).Range.Text = "Số Lượng";
                    table.Cell(1, 2).Range.ParagraphFormat.Alignment = WdParagraphAlignment.wdAlignParagraphRight;
                    table.Range.Font.Size = 13;

                    int rowIndex = 2;
                    foreach (var item in lstDatHang)
                    {
                        table.Rows.Add();
                        table.Cell(rowIndex, 1).Range.Text = item.tensp;
                        table.Cell(rowIndex, 2).Range.Text = item.soluong.ToString();
                        rowIndex++;
                    }
                }

                doc.Paragraphs.Add();
                Paragraph text1 = doc.Paragraphs.Add();
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

        private void guna2Button2_Click_1(object sender, EventArgs e)
        {
            this.Visible = false;
            Program.importfinishForm = new frmImportFinsh();
            Program.importfinishForm.Show();
        }
    }
}
