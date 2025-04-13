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

    public partial class frmImportFinsh : Form
    {
        ImportBLL importBLL;

        public frmImportFinsh()
        {
            InitializeComponent();
            importBLL = new ImportBLL();
            LoadTableNhapKho();

        }

        public void LoadTableNhapKho()
        {
            tblNhapKho.DataSource = importBLL.GetDataNhapKhoHoanThanh();
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

        private void tblNhapKho_Click(object sender, EventArgs e)
        {
            int i = tblNhapKho.CurrentRow.Index;
            lblMaNhapKho.Text = tblNhapKho.Rows[i].Cells[0].Value.ToString();
            lblTenNhanVien.Text = tblNhapKho.Rows[i].Cells[1].Value.ToString();
            lblNgayLap.Text = tblNhapKho.Rows[i].Cells[2].Value.ToString();
            LoadTableChiTietNhapKho(int.Parse(tblNhapKho.Rows[i].Cells[0].Value.ToString()));

        }

        private void label14_Click(object sender, EventArgs e)
        {
            this.Visible = false;
            Program.mainForm = new frmMain();
            Program.mainForm.Show();


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

        private void tblChiTietNhapKho_Click(object sender, EventArgs e)
        {
            if (tblChiTietNhapKho != null && tblChiTietNhapKho.Rows.Count > 0)
            {
                int i = tblChiTietNhapKho.CurrentRow.Index;
                lblMaCTHD.Text = tblChiTietNhapKho.Rows[i].Cells[0].Value.ToString();
                txtTenSPDaChon.Text = tblChiTietNhapKho.Rows[i].Cells[2].Value.ToString();
                txtSoLuongDaChon.Text = tblChiTietNhapKho.Rows[i].Cells[3].Value.ToString();


            }
            else
                MessageBox.Show("Chưa có dữ liệu", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
        }
    }
}
