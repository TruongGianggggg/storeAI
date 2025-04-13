using BLL;
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
    public partial class frmOrderOnline : Form
    {
        OrderOnlineBLL orderOnlineBLL;
        public frmOrderOnline()
        {
            InitializeComponent();
            orderOnlineBLL = new OrderOnlineBLL();
            LoadTable();
            //LoadTableDetail("");
        }
        public void LoadTable()
        {
            tbl.DataSource = orderOnlineBLL.GetData();
            tbl.Columns[0].HeaderText = "Mã Đơn Hàng";
            tbl.Columns[1].HeaderText = "Mã Khách Hàng";
            tbl.Columns[2].HeaderText = "Tên Khách Hàng";
            tbl.Columns[3].HeaderText = "Ngày Đặt Hàng";
            tbl.Columns[4].HeaderText = "Tổng Tiền";
            tbl.Columns[5].HeaderText = "Trạng Thái";

            tbl.Columns[3].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            tbl.Columns[4].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
            tbl.Columns[5].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
        }
        public void LoadTableDetail(string str)
        {
            tblDetail.DataSource = orderOnlineBLL.GetDataDetail(str);
            tblDetail.Columns[0].HeaderText = "Mã Chi Tiết Đơn Hàng";
            tblDetail.Columns[1].HeaderText = "Mã Đơn Hàng";
            tblDetail.Columns[2].HeaderText = "Mã Sản Phẩm";
            tblDetail.Columns[3].HeaderText = "Tên Sản Phẩm";
            tblDetail.Columns[4].HeaderText = "Giá Sản Phẩm";
            tblDetail.Columns[5].HeaderText = "Số Lượng";

            tblDetail.Columns[1].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            tblDetail.Columns[2].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            tblDetail.Columns[4].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
            tblDetail.Columns[5].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
        }

        private void tbl_Click(object sender, EventArgs e)
        {
            if (tbl != null && tbl.Rows.Count > 0)
            {
                int i = tbl.CurrentRow.Index;
                LoadTableDetail(tbl.Rows[i].Cells[0].Value.ToString());
                lblMaDonHang.Text = tbl.Rows[i].Cells[0].Value.ToString();
                switch (tbl.Rows[i].Cells[5].Value.ToString())
                {
                    case "Đang Chờ Xử Lý":
                        btnXacNhan.Enabled = true;
                        btnLayHang.Enabled = false;
                        btnGiaoHang.Enabled = false;
                        btnHoanTat.Enabled = false;
                        btnInHoaDon.Enabled = false;
                        break;
                    case "Đã Xác Nhận Đơn Hàng":
                        btnXacNhan.Enabled = false;
                        btnLayHang.Enabled = true;
                        btnGiaoHang.Enabled = false;
                        btnHoanTat.Enabled = false;
                        btnInHoaDon.Enabled = false;
                        break;
                    case "Đang Lấy Hàng":
                        btnXacNhan.Enabled = false;
                        btnLayHang.Enabled = false;
                        btnGiaoHang.Enabled = true;
                        btnHoanTat.Enabled = false;
                        btnInHoaDon.Enabled = true;
                        break;
                    case "Đang Giao Hàng":
                        btnXacNhan.Enabled = false;
                        btnLayHang.Enabled = false;
                        btnGiaoHang.Enabled = false;
                        btnHoanTat.Enabled = true;
                        btnInHoaDon.Enabled = true;
                        break;
                    case "Giao Hàng Thành Công":
                        btnXacNhan.Enabled = false;
                        btnLayHang.Enabled = false;
                        btnGiaoHang.Enabled = false;
                        btnHoanTat.Enabled = false;
                        break;
                }
            }
            else
                MessageBox.Show("Chưa có dữ liệu để chọn");
        }

        private void btnXacNhan_Click(object sender, EventArgs e)
        {
            try
            {
                if (!(lblMaDonHang.Text == string.Empty))
                {
                    DialogResult result = MessageBox.Show("Thay đổi trạng thái đơn hàng có mã hóa đơn '" + lblMaDonHang.Text + "': 'ĐÃ XÁC NHẬN ĐƠN HÀNG' ?", "Xác nhận", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                    if (result == DialogResult.Yes)
                    {
                        orderOnlineBLL.CapNhatDaXacNhan(int.Parse(lblMaDonHang.Text.Trim()), frmLogin.manhanvien);
                        LoadTable();
                        btnXacNhan.Enabled = false;
                        btnLayHang.Enabled = false;
                        btnGiaoHang.Enabled = false;
                        btnHoanTat.Enabled = false;
                    }
                }
                else
                    MessageBox.Show("Chưa chọn đơn đặt hàng nào!");
            }
            catch (Exception)
            {
                MessageBox.Show("Lỗi hệ thống!");
            }
        }

        private void btnLayHang_Click(object sender, EventArgs e)
        {
            try
            {
                if (!(lblMaDonHang.Text == string.Empty))
                {
                    DialogResult result = MessageBox.Show("Thay đổi trạng thái đơn hàng có mã hóa đơn '" + lblMaDonHang.Text + "': 'ĐANG LẤY HÀNG' ?", "Xác nhận", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                    if (result == DialogResult.Yes)
                    {
                        orderOnlineBLL.CapNhatChoLayHang(int.Parse(lblMaDonHang.Text.Trim()));
                        LoadTable();
                        btnXacNhan.Enabled = false;
                        btnLayHang.Enabled = false;
                        btnGiaoHang.Enabled = false;
                        btnHoanTat.Enabled = false;
                    }
                }
                else
                    MessageBox.Show("Chưa chọn đơn đặt hàng nào!");
            }
            catch (Exception)
            {
                MessageBox.Show("Lỗi hệ thống!");
            }
        }

        private void btnGiaoHang_Click(object sender, EventArgs e)
        {
            try
            {
                if (!(lblMaDonHang.Text == string.Empty))
                {
                    DialogResult result = MessageBox.Show("Thay đổi trạng thái đơn hàng có mã hóa đơn '" + lblMaDonHang.Text + "': 'ĐANG GIAO HÀNG' ?", "Xác nhận", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                    if (result == DialogResult.Yes)
                    {
                        orderOnlineBLL.CapNhatChoGiaoHang(int.Parse(lblMaDonHang.Text.Trim()));
                        LoadTable();
                        btnXacNhan.Enabled = false;
                        btnLayHang.Enabled = false;
                        btnGiaoHang.Enabled = false;
                        btnHoanTat.Enabled = false;
                    }
                }
                else
                    MessageBox.Show("Chưa chọn đơn đặt hàng nào!");
            }
            catch (Exception)
            {
                MessageBox.Show("Lỗi hệ thống!");
            }
        }

        private void btnHoanTat_Click(object sender, EventArgs e)
        {
            try
            {
                if (!(lblMaDonHang.Text == string.Empty))
                {
                    DialogResult result = MessageBox.Show("Thay đổi trạng thái đơn hàng có mã hóa đơn '" + lblMaDonHang.Text + "': 'GIAO HÀNG THÀNH CÔNG' ?", "Xác nhận", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                    if (result == DialogResult.Yes)
                    {
                        orderOnlineBLL.CapNhatHoanTat(int.Parse(lblMaDonHang.Text.Trim()));
                        LoadTable();
                        ThemHoaDonChoDonHang();
                        btnXacNhan.Enabled = false;
                        btnLayHang.Enabled = false;
                        btnGiaoHang.Enabled = false;
                        btnHoanTat.Enabled = false;
                    }
                }
                else
                    MessageBox.Show("Chưa chọn đơn đặt hàng nào!");
            }
            catch (Exception)
            {
                MessageBox.Show("Lỗi hệ thống!");
            }
        }

        public void ThemHoaDonChoDonHang()
        {
            try
            {
                orderOnlineBLL.ThemHoaDon(int.Parse(lblMaDonHang.Text),
                    frmLogin.manhanvien,
                    orderOnlineBLL.LayMaKhachHang(int.Parse(lblMaDonHang.Text)),
                    DateTime.Parse(DateTime.Now.ToString("dd/MM/yyyy")),
                    "Đã Thanh Toán",
                    double.Parse(orderOnlineBLL.LayTongTien(int.Parse(lblMaDonHang.Text)).ToString()));

                string mahoadon = orderOnlineBLL.LayMaHoaDon(int.Parse(lblMaDonHang.Text));

                foreach (var item in orderOnlineBLL.ListCTDonHangToAddCTHoaDon(int.Parse(lblMaDonHang.Text)))
                {
                    orderOnlineBLL.ThemChiTietHoaDon(mahoadon, (int)item.MaSanPham, item.SoLuong);
                }
            }
            catch (Exception)
            {
                MessageBox.Show("Lỗi hệ thống!");
            }
        }

        private void cboLoc_SelectedIndexChanged(object sender, EventArgs e)
        {
            switch (cboLoc.SelectedIndex)
            {
                case 0:
                    LoadTable();
                    break;
                case 1:
                    tbl.DataSource = orderOnlineBLL.LocDangChoXuLy();
                    break;
                case 2:
                    tbl.DataSource = orderOnlineBLL.LocDaXacNhanDonHang();
                    break;
                case 3:
                    tbl.DataSource = orderOnlineBLL.LocDangLayHang();
                    break;
                case 4:
                    tbl.DataSource = orderOnlineBLL.LocDangGiaoHang();
                    break;
                case 5:
                    tbl.DataSource = orderOnlineBLL.LocGiaoHangThanhCong();
                    break;
            }
        }

        private void dateChon_ValueChanged(object sender, EventArgs e)
        {
            switch (cboLoc.SelectedIndex)
            {
                case 0:
                    tbl.DataSource = orderOnlineBLL.GetDataTheoNgay(dateChon.Value);
                    break;
                case 1:
                    tbl.DataSource = orderOnlineBLL.LocDangChoXuLyTheoNgay(dateChon.Value);
                    break;
                case 2:
                    tbl.DataSource = orderOnlineBLL.LocDaXacNhanDonHangTheoNgay(dateChon.Value);
                    break;
                case 3:
                    tbl.DataSource = orderOnlineBLL.LocDangLayHangTheoNgay(dateChon.Value);
                    break;
                case 4:
                    tbl.DataSource = orderOnlineBLL.LocDangGiaoHangTheoNgay(dateChon.Value);
                    break;
                case 5:
                    tbl.DataSource = orderOnlineBLL.LocGiaoHangThanhCongTheoNgay(dateChon.Value);
                    break;
            }
        }

        private void label14_Click(object sender, EventArgs e)
        {
            this.Visible = false;
            Program.mainForm = new frmMain();
            Program.mainForm.Show();
        }
        private void MoTepWordTuDuongDanTuongDoi()
        {
            string duongDanUngDung = AppDomain.CurrentDomain.BaseDirectory;
            string duongDanTepWord = Path.Combine(duongDanUngDung, @"Bill\PrintOrderOnline.docx");

            if (File.Exists(duongDanTepWord))
            {
                Microsoft.Office.Interop.Word.Application wordApp = new Microsoft.Office.Interop.Word.Application();
                Microsoft.Office.Interop.Word.Document doc = wordApp.Documents.Open(duongDanTepWord, ReadOnly: true);

            }
            else
                MessageBox.Show("Tệp Word không tồn tại.");
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

        private void ThemDuLieuVaoFileWord(string madonhang, string tenkh, string sdt, string diachi,
            string ngaydat, string tongtien)
        {
            string duongDanUngDung = AppDomain.CurrentDomain.BaseDirectory;
            string duongDanTepWord = Path.Combine(duongDanUngDung, @"Bill\PrintOrderOnline.docx");
            if (File.Exists(duongDanTepWord))
            {
                Microsoft.Office.Interop.Word.Application wordApp = new Microsoft.Office.Interop.Word.Application();
                Document doc = wordApp.Documents.Open(duongDanTepWord, ReadOnly: true);
                ThayDoiGiaTriTruong(doc, "MaHoaDon", madonhang);
                ThayDoiGiaTriTruong(doc, "TenKhachHang", tenkh);
                ThayDoiGiaTriTruong(doc, "SdtKhachHang", sdt);
                ThayDoiGiaTriTruong(doc, "DiaChiKhachHang", diachi);
                ThayDoiGiaTriTruong(doc, "NgayLap", ngaydat);
                ThayDoiGiaTriTruong(doc, "TongTienDonDatHang", tongtien);

                var detailorder = orderOnlineBLL.PrintDetailOrder(int.Parse(lblMaDonHang.Text));
                if (detailorder.Any())
                {

                    Range endRange = doc.Range();
                    endRange.Find.Execute("THÔNG TIN CHI TIẾT ĐƠN HÀNG:", Forward: false);
                    Range endOfTenNhanVien = endRange.Duplicate;
                    endOfTenNhanVien.MoveEnd(WdUnits.wdParagraph, 1);
                    int endPosition = endOfTenNhanVien.End;

                    Table table = doc.Tables.Add(doc.Range(endPosition), 1, 4);
                    table.Borders.Enable = 1;
                    table.Cell(1, 1).Range.Text = "Mã Sản Phẩm";
                    table.Cell(1, 2).Range.Text = "Tên Sản Phẩm";
                    table.Cell(1, 3).Range.Text = "Giá";
                    table.Cell(1, 3).Range.ParagraphFormat.Alignment = WdParagraphAlignment.wdAlignParagraphRight;
                    table.Cell(1, 4).Range.Text = "Số Lượng";
                    table.Cell(1, 4).Range.ParagraphFormat.Alignment = WdParagraphAlignment.wdAlignParagraphCenter;
                    table.Range.Font.Size = 13;

                    int rowIndex = 2;
                    foreach (var item in detailorder)
                    {
                        table.Rows.Add();
                        table.Cell(rowIndex, 1).Range.Text = item.Masp.ToString();
                        table.Cell(rowIndex, 2).Range.Text = item.Tensp;
                        table.Cell(rowIndex, 3).Range.Text = item.Gia.ToString("N0") + "đ";
                        table.Cell(rowIndex, 4).Range.Text = item.Soluong.ToString();
                        rowIndex++;
                    }
                }

                //doc.Paragraphs.Add();
                //Paragraph text1 = doc.Paragraphs.Add();
                //text1.Range.Text = "Tổng tiền hóa đơn: " + tongtien;
                //text1.Format.Alignment = Microsoft.Office.Interop.Word.WdParagraphAlignment.wdAlignParagraphRight;
                //text1.Range.Font.Bold = 0;
                //text1.Range.Font.Size = 13;
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

        private void btnInHoaDon_Click(object sender, EventArgs e)
        {
            string tenkh = orderOnlineBLL.LayTenKhachHang(int.Parse(lblMaDonHang.Text));
            string sdt = orderOnlineBLL.LaySdt(int.Parse(lblMaDonHang.Text));
            string diachi = orderOnlineBLL.LayDiaChi(int.Parse(lblMaDonHang.Text));
            string ngaydat = orderOnlineBLL.LayNgayDat(int.Parse(lblMaDonHang.Text)).ToString("dd/MM/yyyy");
            string tongtien = orderOnlineBLL.LayTongTien(int.Parse(lblMaDonHang.Text)).ToString("N0") + " đ";
            ThemDuLieuVaoFileWord(lblMaDonHang.Text, tenkh, sdt, diachi, ngaydat, tongtien);
            MoTepWordTuDuongDanTuongDoi();
        }
    }
}
