using BLL;
using DTO;
using Microsoft.Office.Interop.Word;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Windows.Forms;

namespace Store_Management_Project
{
    public partial class frmStatistics : Form
    {
        StatisticsBLL sbll;
        public frmStatistics()
        {
            InitializeComponent();
            sbll = new StatisticsBLL();
            LoadComboxboxNam();
            LoadTableHoaDonOnline();
            LoadTableHoaDonOffline();
        }
        public void LoadComboxboxNam()
        {
            int namhientai = DateTime.Now.Year;
            for (int year = namhientai; year >= 1900; year--)
                cboNam.Items.Add(year);
        }

        private void cboLuaChon_SelectedIndexChanged(object sender, EventArgs e)
        {
            switch (cboLuaChon.SelectedIndex)
            {
                case 0:
                    LoadTableHoaDonOnline();
                    LoadTableHoaDonOffline();
                    dateChonNgay.Enabled = false;
                    cboThang.Enabled = false;
                    cboQuy.Enabled = false;
                    cboNam.Enabled = false;
                    cboThang.SelectedIndex = 0;
                    cboQuy.SelectedIndex = 0;
                    cboNam.SelectedIndex = 0;
                    dateChonNgay.Value = DateTime.Parse(DateTime.Now.ToString("dd/MM/yyyy"));
                    break;
                case 1:
                    dateChonNgay.Enabled = true;
                    cboThang.Enabled = false;
                    cboQuy.Enabled = false;
                    cboNam.Enabled = false;
                    cboThang.SelectedIndex = 0;
                    cboQuy.SelectedIndex = 0;
                    cboNam.SelectedIndex = 0;
                    dateChonNgay.Value = DateTime.Parse(DateTime.Now.ToString("dd/MM/yyyy"));
                    break;
                case 2:
                    dateChonNgay.Enabled = false;
                    cboThang.Enabled = true;
                    cboQuy.Enabled = false;
                    cboNam.Enabled = false;
                    cboThang.SelectedIndex = 0;
                    cboQuy.SelectedIndex = 0;
                    cboNam.SelectedIndex = 0;
                    dateChonNgay.Value = DateTime.Parse(DateTime.Now.ToString("dd/MM/yyyy"));
                    break;
                case 3:
                    dateChonNgay.Enabled = false;
                    cboThang.Enabled = false;
                    cboQuy.Enabled = true;
                    cboNam.Enabled = false;
                    cboThang.SelectedIndex = 0;
                    cboQuy.SelectedIndex = 0;
                    cboNam.SelectedIndex = 0;
                    dateChonNgay.Value = DateTime.Parse(DateTime.Now.ToString("dd/MM/yyyy"));
                    break;
                case 4:
                    dateChonNgay.Enabled = false;
                    cboThang.Enabled = false;
                    cboQuy.Enabled = false;
                    cboNam.Enabled = true;
                    cboThang.SelectedIndex = 0;
                    cboQuy.SelectedIndex = 0;
                    cboNam.SelectedIndex = 0;
                    dateChonNgay.Value = DateTime.Parse(DateTime.Now.ToString("dd/MM/yyyy"));
                    break;
            }
        }

        public void LoadTableHoaDonOnline()
        {
            tblOnline.DataSource = sbll.GetDataHoaDonOnline();
            tblOnline.Columns[0].HeaderText = "Mã Đơn Hàng";
            tblOnline.Columns[1].HeaderText = "Nhân Viên Lập HĐ";
            tblOnline.Columns[2].HeaderText = "Tên Khách Hàng";
            tblOnline.Columns[3].HeaderText = "Ngày Lập";
            tblOnline.Columns[4].HeaderText = "Tổng Tiền";
            tblOnline.Columns[5].HeaderText = "Trạng Thái";

            tblOnline.Columns[3].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            tblOnline.Columns[4].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
            tblOnline.Columns[5].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
        }

        public void LoadTableHoaDonOffline()
        {
            tblOffline.DataSource = sbll.GetDataHoaDonOffline();
            tblOffline.Columns[0].HeaderText = "Mã Đơn Hàng";
            tblOffline.Columns[1].HeaderText = "Nhân Viên Lập HĐ";
            tblOffline.Columns[2].HeaderText = "Ngày Lập";
            tblOffline.Columns[3].HeaderText = "Tổng Tiền";
            tblOffline.Columns[4].HeaderText = "Trạng Thái";

            tblOffline.Columns[2].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            tblOffline.Columns[3].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
            tblOffline.Columns[4].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
        }

        private void label14_Click(object sender, EventArgs e)
        {
            this.Visible = false;
            Program.mainForm = new frmMain();
            Program.mainForm.Show();
        }

        private void dateChonNgay_ValueChanged(object sender, EventArgs e)
        {
            try
            {
                tblOnline.DataSource = sbll.SearchHoaDonOnlineTheoNgay(dateChonNgay.Value);
                tblOffline.DataSource = sbll.SearchHoaDonOfflineTheoNgay(dateChonNgay.Value);
                lblSoLuongOnline.Text = sbll.SoLuongHoaDonOnline(dateChonNgay.Value).ToString() + " đơn";
                lblDoanhThuOnline.Text = sbll.DoanhThuOnline(dateChonNgay.Value).ToString("N0") + " đ";
                lblSoLuongOffline.Text = sbll.SoLuongHoaDonOffline(dateChonNgay.Value).ToString() + " đơn";
                lblDoanhThuOffline.Text = sbll.DoanhThuOffline(dateChonNgay.Value).ToString("N0") + " đ";
            }
            catch (Exception)
            {
                MessageBox.Show("Lỗi hệ thống");
            }
        }

        private void cboThang_SelectedIndexChanged(object sender, EventArgs e)
        {
            switch (cboThang.SelectedIndex)
            {
                case 0:
                    LoadTableHoaDonOnline();
                    LoadTableHoaDonOffline();
                    lblSoLuongOnline.Text = "0 đơn";
                    lblDoanhThuOnline.Text = "0 đ";
                    lblSoLuongOffline.Text = "0 đơn";
                    lblDoanhThuOffline.Text = "0 đ";
                    break;
                case 1:
                    tblOnline.DataSource = sbll.SearchHoaDonOnlineTheoThang(cboThang.SelectedIndex);
                    tblOffline.DataSource = sbll.SearchHoaDonOfflineTheoThang(cboThang.SelectedIndex);
                    lblSoLuongOnline.Text = sbll.SoLuongHoaDonOnlineTheoThang(cboThang.SelectedIndex).ToString() + " đơn";
                    lblDoanhThuOnline.Text = sbll.DoanhThuOnlineTheoThang(cboThang.SelectedIndex).ToString("N0") + " đ";
                    lblSoLuongOffline.Text = sbll.SoLuongHoaDonOfflineTheoThang(cboThang.SelectedIndex).ToString() + " đơn";
                    lblDoanhThuOffline.Text = sbll.DoanhThuOfflineTheoThang(cboThang.SelectedIndex).ToString("N0") + " đ";
                    break;
                case 2:
                    tblOnline.DataSource = sbll.SearchHoaDonOnlineTheoThang(cboThang.SelectedIndex);
                    tblOffline.DataSource = sbll.SearchHoaDonOfflineTheoThang(cboThang.SelectedIndex);
                    lblSoLuongOnline.Text = sbll.SoLuongHoaDonOnlineTheoThang(cboThang.SelectedIndex).ToString() + " đơn";
                    lblDoanhThuOnline.Text = sbll.DoanhThuOnlineTheoThang(cboThang.SelectedIndex).ToString("N0") + " đ";
                    lblSoLuongOffline.Text = sbll.SoLuongHoaDonOfflineTheoThang(cboThang.SelectedIndex).ToString() + " đơn";
                    lblDoanhThuOffline.Text = sbll.DoanhThuOfflineTheoThang(cboThang.SelectedIndex).ToString("N0") + " đ";
                    break;
                case 3:
                    tblOnline.DataSource = sbll.SearchHoaDonOnlineTheoThang(cboThang.SelectedIndex);
                    tblOffline.DataSource = sbll.SearchHoaDonOfflineTheoThang(cboThang.SelectedIndex);
                    lblSoLuongOnline.Text = sbll.SoLuongHoaDonOnlineTheoThang(cboThang.SelectedIndex).ToString() + " đơn";
                    lblDoanhThuOnline.Text = sbll.DoanhThuOnlineTheoThang(cboThang.SelectedIndex).ToString("N0") + " đ";
                    lblSoLuongOffline.Text = sbll.SoLuongHoaDonOfflineTheoThang(cboThang.SelectedIndex).ToString() + " đơn";
                    lblDoanhThuOffline.Text = sbll.DoanhThuOfflineTheoThang(cboThang.SelectedIndex).ToString("N0") + " đ";
                    break;
                case 4:
                    tblOnline.DataSource = sbll.SearchHoaDonOnlineTheoThang(cboThang.SelectedIndex);
                    tblOffline.DataSource = sbll.SearchHoaDonOfflineTheoThang(cboThang.SelectedIndex);
                    lblSoLuongOnline.Text = sbll.SoLuongHoaDonOnlineTheoThang(cboThang.SelectedIndex).ToString() + " đơn";
                    lblDoanhThuOnline.Text = sbll.DoanhThuOnlineTheoThang(cboThang.SelectedIndex).ToString("N0") + " đ";
                    lblSoLuongOffline.Text = sbll.SoLuongHoaDonOfflineTheoThang(cboThang.SelectedIndex).ToString() + " đơn";
                    lblDoanhThuOffline.Text = sbll.DoanhThuOfflineTheoThang(cboThang.SelectedIndex).ToString("N0") + " đ";
                    break;
                case 5:
                    tblOnline.DataSource = sbll.SearchHoaDonOnlineTheoThang(cboThang.SelectedIndex);
                    tblOffline.DataSource = sbll.SearchHoaDonOfflineTheoThang(cboThang.SelectedIndex);
                    lblSoLuongOnline.Text = sbll.SoLuongHoaDonOnlineTheoThang(cboThang.SelectedIndex).ToString() + " đơn";
                    lblDoanhThuOnline.Text = sbll.DoanhThuOnlineTheoThang(cboThang.SelectedIndex).ToString("N0") + " đ";
                    lblSoLuongOffline.Text = sbll.SoLuongHoaDonOfflineTheoThang(cboThang.SelectedIndex).ToString() + " đơn";
                    lblDoanhThuOffline.Text = sbll.DoanhThuOfflineTheoThang(cboThang.SelectedIndex).ToString("N0") + " đ";
                    break;
                case 6:
                    tblOnline.DataSource = sbll.SearchHoaDonOnlineTheoThang(cboThang.SelectedIndex);
                    tblOffline.DataSource = sbll.SearchHoaDonOfflineTheoThang(cboThang.SelectedIndex);
                    lblSoLuongOnline.Text = sbll.SoLuongHoaDonOnlineTheoThang(cboThang.SelectedIndex).ToString() + " đơn";
                    lblDoanhThuOnline.Text = sbll.DoanhThuOnlineTheoThang(cboThang.SelectedIndex).ToString("N0") + " đ";
                    lblSoLuongOffline.Text = sbll.SoLuongHoaDonOfflineTheoThang(cboThang.SelectedIndex).ToString() + " đơn";
                    lblDoanhThuOffline.Text = sbll.DoanhThuOfflineTheoThang(cboThang.SelectedIndex).ToString("N0") + " đ";
                    break;
                case 7:
                    tblOnline.DataSource = sbll.SearchHoaDonOnlineTheoThang(cboThang.SelectedIndex);
                    tblOffline.DataSource = sbll.SearchHoaDonOfflineTheoThang(cboThang.SelectedIndex);
                    lblSoLuongOnline.Text = sbll.SoLuongHoaDonOnlineTheoThang(cboThang.SelectedIndex).ToString() + " đơn";
                    lblDoanhThuOnline.Text = sbll.DoanhThuOnlineTheoThang(cboThang.SelectedIndex).ToString("N0") + " đ";
                    lblSoLuongOffline.Text = sbll.SoLuongHoaDonOfflineTheoThang(cboThang.SelectedIndex).ToString() + " đơn";
                    lblDoanhThuOffline.Text = sbll.DoanhThuOfflineTheoThang(cboThang.SelectedIndex).ToString("N0") + " đ";
                    break;
                case 8:
                    tblOnline.DataSource = sbll.SearchHoaDonOnlineTheoThang(cboThang.SelectedIndex);
                    tblOffline.DataSource = sbll.SearchHoaDonOfflineTheoThang(cboThang.SelectedIndex);
                    lblSoLuongOnline.Text = sbll.SoLuongHoaDonOnlineTheoThang(cboThang.SelectedIndex).ToString() + " đơn";
                    lblDoanhThuOnline.Text = sbll.DoanhThuOnlineTheoThang(cboThang.SelectedIndex).ToString("N0") + " đ";
                    lblSoLuongOffline.Text = sbll.SoLuongHoaDonOfflineTheoThang(cboThang.SelectedIndex).ToString() + " đơn";
                    lblDoanhThuOffline.Text = sbll.DoanhThuOfflineTheoThang(cboThang.SelectedIndex).ToString("N0") + " đ";
                    break;
                case 9:
                    tblOnline.DataSource = sbll.SearchHoaDonOnlineTheoThang(cboThang.SelectedIndex);
                    tblOffline.DataSource = sbll.SearchHoaDonOfflineTheoThang(cboThang.SelectedIndex);
                    lblSoLuongOnline.Text = sbll.SoLuongHoaDonOnlineTheoThang(cboThang.SelectedIndex).ToString() + " đơn";
                    lblDoanhThuOnline.Text = sbll.DoanhThuOnlineTheoThang(cboThang.SelectedIndex).ToString("N0") + " đ";
                    lblSoLuongOffline.Text = sbll.SoLuongHoaDonOfflineTheoThang(cboThang.SelectedIndex).ToString() + " đơn";
                    lblDoanhThuOffline.Text = sbll.DoanhThuOfflineTheoThang(cboThang.SelectedIndex).ToString("N0") + " đ";
                    break;
                case 10:
                    tblOnline.DataSource = sbll.SearchHoaDonOnlineTheoThang(cboThang.SelectedIndex);
                    tblOffline.DataSource = sbll.SearchHoaDonOfflineTheoThang(cboThang.SelectedIndex);
                    lblSoLuongOnline.Text = sbll.SoLuongHoaDonOnlineTheoThang(cboThang.SelectedIndex).ToString() + " đơn";
                    lblDoanhThuOnline.Text = sbll.DoanhThuOnlineTheoThang(cboThang.SelectedIndex).ToString("N0") + " đ";
                    lblSoLuongOffline.Text = sbll.SoLuongHoaDonOfflineTheoThang(cboThang.SelectedIndex).ToString() + " đơn";
                    lblDoanhThuOffline.Text = sbll.DoanhThuOfflineTheoThang(cboThang.SelectedIndex).ToString("N0") + " đ";
                    break;
                case 11:
                    tblOnline.DataSource = sbll.SearchHoaDonOnlineTheoThang(cboThang.SelectedIndex);
                    tblOffline.DataSource = sbll.SearchHoaDonOfflineTheoThang(cboThang.SelectedIndex);
                    lblSoLuongOnline.Text = sbll.SoLuongHoaDonOnlineTheoThang(cboThang.SelectedIndex).ToString() + " đơn";
                    lblDoanhThuOnline.Text = sbll.DoanhThuOnlineTheoThang(cboThang.SelectedIndex).ToString("N0") + " đ";
                    lblSoLuongOffline.Text = sbll.SoLuongHoaDonOfflineTheoThang(cboThang.SelectedIndex).ToString() + " đơn";
                    lblDoanhThuOffline.Text = sbll.DoanhThuOfflineTheoThang(cboThang.SelectedIndex).ToString("N0") + " đ";
                    break;
                case 12:
                    tblOnline.DataSource = sbll.SearchHoaDonOnlineTheoThang(cboThang.SelectedIndex);
                    tblOffline.DataSource = sbll.SearchHoaDonOfflineTheoThang(cboThang.SelectedIndex);
                    lblSoLuongOnline.Text = sbll.SoLuongHoaDonOnlineTheoThang(cboThang.SelectedIndex).ToString() + " đơn";
                    lblDoanhThuOnline.Text = sbll.DoanhThuOnlineTheoThang(cboThang.SelectedIndex).ToString("N0") + " đ";
                    lblSoLuongOffline.Text = sbll.SoLuongHoaDonOfflineTheoThang(cboThang.SelectedIndex).ToString() + " đơn";
                    lblDoanhThuOffline.Text = sbll.DoanhThuOfflineTheoThang(cboThang.SelectedIndex).ToString("N0") + " đ";
                    break;
            }
        }

        private void cboQuy_SelectedIndexChanged(object sender, EventArgs e)
        {
            switch (cboQuy.SelectedIndex)
            {
                case 0:
                    LoadTableHoaDonOnline();
                    LoadTableHoaDonOffline();
                    lblSoLuongOnline.Text = "0 đơn";
                    lblDoanhThuOnline.Text = "0 đ";
                    lblSoLuongOffline.Text = "0 đơn";
                    lblDoanhThuOffline.Text = "0 đ";
                    break;
                case 1:
                    tblOnline.DataSource = sbll.SearchHoaDonOnlineTheoQuy(cboQuy.SelectedIndex);
                    tblOffline.DataSource = sbll.SearchHoaDonOfflineTheoQuy(cboQuy.SelectedIndex);
                    lblSoLuongOnline.Text = sbll.SoLuongHoaDonOnlineTheoQuy(cboQuy.SelectedIndex).ToString() + " đơn";
                    lblDoanhThuOnline.Text = sbll.DoanhThuOnlineTheoQuy(cboQuy.SelectedIndex).ToString("N0") + " đ";
                    lblSoLuongOffline.Text = sbll.SoLuongHoaDonOfflineTheoQuy(cboQuy.SelectedIndex).ToString() + " đơn";
                    lblDoanhThuOffline.Text = sbll.DoanhThuOfflineTheoQuy(cboQuy.SelectedIndex).ToString("N0") + " đ";
                    break;
                case 2:
                    tblOnline.DataSource = sbll.SearchHoaDonOnlineTheoQuy(cboQuy.SelectedIndex);
                    tblOffline.DataSource = sbll.SearchHoaDonOfflineTheoQuy(cboQuy.SelectedIndex);
                    lblSoLuongOnline.Text = sbll.SoLuongHoaDonOnlineTheoQuy(cboQuy.SelectedIndex).ToString() + " đơn";
                    lblDoanhThuOnline.Text = sbll.DoanhThuOnlineTheoQuy(cboQuy.SelectedIndex).ToString("N0") + " đ";
                    lblSoLuongOffline.Text = sbll.SoLuongHoaDonOfflineTheoQuy(cboQuy.SelectedIndex).ToString() + " đơn";
                    lblDoanhThuOffline.Text = sbll.DoanhThuOfflineTheoQuy(cboQuy.SelectedIndex).ToString("N0") + " đ";
                    break;
                case 3:
                    tblOnline.DataSource = sbll.SearchHoaDonOnlineTheoQuy(cboQuy.SelectedIndex);
                    tblOffline.DataSource = sbll.SearchHoaDonOfflineTheoQuy(cboQuy.SelectedIndex);
                    lblSoLuongOnline.Text = sbll.SoLuongHoaDonOnlineTheoQuy(cboQuy.SelectedIndex).ToString() + " đơn";
                    lblDoanhThuOnline.Text = sbll.DoanhThuOnlineTheoQuy(cboQuy.SelectedIndex).ToString("N0") + " đ";
                    lblSoLuongOffline.Text = sbll.SoLuongHoaDonOfflineTheoQuy(cboQuy.SelectedIndex).ToString() + " đơn";
                    lblDoanhThuOffline.Text = sbll.DoanhThuOfflineTheoQuy(cboQuy.SelectedIndex).ToString("N0") + " đ";
                    break;
                case 4:
                    tblOnline.DataSource = sbll.SearchHoaDonOnlineTheoQuy(cboQuy.SelectedIndex);
                    tblOffline.DataSource = sbll.SearchHoaDonOfflineTheoQuy(cboQuy.SelectedIndex);
                    lblSoLuongOnline.Text = sbll.SoLuongHoaDonOnlineTheoQuy(cboQuy.SelectedIndex).ToString() + " đơn";
                    lblDoanhThuOnline.Text = sbll.DoanhThuOnlineTheoQuy(cboQuy.SelectedIndex).ToString("N0") + " đ";
                    lblSoLuongOffline.Text = sbll.SoLuongHoaDonOfflineTheoQuy(cboQuy.SelectedIndex).ToString() + " đơn";
                    lblDoanhThuOffline.Text = sbll.DoanhThuOfflineTheoQuy(cboQuy.SelectedIndex).ToString("N0") + " đ";
                    break;
            }
        }

        private void cboNam_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cboNam.SelectedIndex == 0)
            {
                LoadTableHoaDonOnline();
                LoadTableHoaDonOffline();
                lblSoLuongOnline.Text = "0 đơn";
                lblDoanhThuOnline.Text = "0 đ";
                lblSoLuongOffline.Text = "0 đơn";
                lblDoanhThuOffline.Text = "0 đ";
            }
            else
            {
                tblOnline.DataSource = sbll.SearchHoaDonOnlineTheoNam(int.Parse(cboNam.Text.Trim()));
                tblOffline.DataSource = sbll.SearchHoaDonOfflineTheoNam(int.Parse(cboNam.Text.Trim()));
                lblSoLuongOnline.Text = sbll.SoLuongHoaDonOnlineTheoNam(int.Parse(cboNam.Text.Trim())).ToString() + " đơn";
                lblDoanhThuOnline.Text = sbll.DoanhThuOnlineTheoNam(int.Parse(cboNam.Text.Trim())).ToString("N0") + " đ";
                lblSoLuongOffline.Text = sbll.SoLuongHoaDonOfflineTheoNam(int.Parse(cboNam.Text.Trim())).ToString() + " đơn";
                lblDoanhThuOffline.Text = sbll.DoanhThuOfflineTheoNam(int.Parse(cboNam.Text.Trim())).ToString("N0") + " đ";
            }
        }

        private void btnInHoaDon_Click(object sender, EventArgs e)
        {
            string tennv = sbll.LayHoTenNhanVienTuTaiKhoan(frmLogin.tendn);
            switch (cboLuaChon.SelectedIndex)
            {
                case 0:
                    
                    break;
                case 1:
                    List<HoaDonOnlineDTO> lst1 = sbll.SearchHoaDonOnlineTheoNgay(dateChonNgay.Value);
                    List<HoaDonOfflineDTO> lst2 = sbll.SearchHoaDonOfflineTheoNgay(dateChonNgay.Value);
                    ThemDuLieuVaoFileWord1(tennv, DateTime.Now.ToString("dd/MM/yyyy"), lst1, 
                        lblSoLuongOnline.Text,
                        lblDoanhThuOnline.Text);
                    ThemDuLieuVaoFileWord2(tennv, DateTime.Now.ToString("dd/MM/yyyy"), lst2,
                        lblSoLuongOffline.Text,
                        lblDoanhThuOffline.Text);
                    break;
                case 2:
                    List<HoaDonOnlineDTO> lst3 = sbll.SearchHoaDonOnlineTheoThang(cboThang.SelectedIndex);
                    List<HoaDonOfflineDTO> lst4 = sbll.SearchHoaDonOfflineTheoThang(cboThang.SelectedIndex);
                    ThemDuLieuVaoFileWord1(tennv, DateTime.Now.ToString("dd/MM/yyyy"), lst3,
                        lblSoLuongOnline.Text,
                        lblDoanhThuOnline.Text);
                    ThemDuLieuVaoFileWord2(tennv, DateTime.Now.ToString("dd/MM/yyyy"), lst4,
                        lblSoLuongOffline.Text,
                        lblDoanhThuOffline.Text);
                    break;
                case 3:
                    List<HoaDonOnlineDTO> lst5 = sbll.SearchHoaDonOnlineTheoQuy(cboQuy.SelectedIndex);
                    List<HoaDonOfflineDTO> lst6 = sbll.SearchHoaDonOfflineTheoQuy(cboQuy.SelectedIndex);
                    ThemDuLieuVaoFileWord1(tennv, DateTime.Now.ToString("dd/MM/yyyy"), lst5,
                        lblSoLuongOnline.Text,
                        lblDoanhThuOnline.Text);
                    ThemDuLieuVaoFileWord2(tennv, DateTime.Now.ToString("dd/MM/yyyy"), lst6,
                        lblSoLuongOffline.Text,
                        lblDoanhThuOffline.Text);
                    break;
                case 4:
                    if (cboNam.SelectedIndex != 0)
                    {
                        List<HoaDonOnlineDTO> lst7 = sbll.SearchHoaDonOnlineTheoNam(int.Parse(cboNam.Text));
                        List<HoaDonOfflineDTO> lst8 = sbll.SearchHoaDonOfflineTheoNam(int.Parse(cboNam.Text));
                        ThemDuLieuVaoFileWord1(tennv, DateTime.Now.ToString("dd/MM/yyyy"), lst7,
                            lblSoLuongOnline.Text,
                            lblDoanhThuOnline.Text);
                        ThemDuLieuVaoFileWord2(tennv, DateTime.Now.ToString("dd/MM/yyyy"), lst8,
                            lblSoLuongOffline.Text,
                            lblDoanhThuOffline.Text);
                    }
                    else
                        MessageBox.Show("Chưa chọn năm để thống kê doanh thu");
                    break;
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
        private void ThemDuLieuVaoFileWord2(string tennv, string thoigian,
            List<HoaDonOfflineDTO> lst2, string soluong, string tongtien)
        {
            string duongDanUngDung = AppDomain.CurrentDomain.BaseDirectory;
            string duongDanTepWord = Path.Combine(duongDanUngDung, @"Bill\PrintStatistic.docx");
            if (File.Exists(duongDanTepWord))
            {
                Microsoft.Office.Interop.Word.Application wordApp = new Microsoft.Office.Interop.Word.Application();
                Document doc = wordApp.Documents.Open(duongDanTepWord, ReadOnly: true);
                ThayDoiGiaTriTruong(doc, "TenNhanVien", tennv);
                ThayDoiGiaTriTruong(doc, "NgayLap", thoigian);
                ThayDoiGiaTriTruong(doc, "SoLuongOnline", soluong);
                ThayDoiGiaTriTruong(doc, "DoanhThuOnline", tongtien);

                if (lst2.Any())
                {

                    Range endRange = doc.Range();
                    endRange.Find.Execute("Danh sách các hóa đơn:", Forward: false);
                    Range endOfTenNhanVien = endRange.Duplicate;
                    endOfTenNhanVien.MoveEnd(WdUnits.wdParagraph, 1);
                    int endPosition = endOfTenNhanVien.End;

                    Table table = doc.Tables.Add(doc.Range(endPosition), 1, 5);
                    table.Borders.Enable = 1;
                    table.Cell(1, 1).Range.Text = "Mã Hóa Đơn";
                    table.Cell(1, 2).Range.Text = "Nhân Viên";
                    table.Cell(1, 3).Range.Text = "Ngày Lập";
                    table.Cell(1, 4).Range.Text = "Tổng Tiền";
                    table.Cell(1, 5).Range.Text = "Trạng Thái";
                    table.Cell(1, 2).Range.ParagraphFormat.Alignment = WdParagraphAlignment.wdAlignParagraphRight;
                    table.Cell(1, 3).Range.ParagraphFormat.Alignment = WdParagraphAlignment.wdAlignParagraphRight;
                    table.Range.Font.Size = 12;

                    int rowIndex = 2;
                    foreach (var item in lst2)
                    {
                        table.Rows.Add();
                        table.Cell(rowIndex, 1).Range.Text = item.Mahd;
                        table.Cell(rowIndex, 2).Range.Text = item.Tennv;
                        table.Cell(rowIndex, 3).Range.Text = item.Ngaylap.ToString("dd/MM/yyyy");
                        table.Cell(rowIndex, 4).Range.Text = item.Tongtien.ToString("N0") + "đ";
                        table.Cell(rowIndex, 5).Range.Text = item.Trangthai;
                        rowIndex++;
                    }
                }
                wordApp.Visible = true;
            }
            else
            {
                MessageBox.Show("Tệp Word không tồn tại.");
            }
        }
        private void ThemDuLieuVaoFileWord1(string tennv, string thoigian,
            List<HoaDonOnlineDTO> lst1, string soluong, string tongtien)
        {
            string duongDanUngDung = AppDomain.CurrentDomain.BaseDirectory;
            string duongDanTepWord = Path.Combine(duongDanUngDung, @"Bill\PrintStatistic.docx");
            if (File.Exists(duongDanTepWord))
            {
                Microsoft.Office.Interop.Word.Application wordApp = new Microsoft.Office.Interop.Word.Application();
                Document doc = wordApp.Documents.Open(duongDanTepWord, ReadOnly: true);
                ThayDoiGiaTriTruong(doc, "TenNhanVien", tennv);
                ThayDoiGiaTriTruong(doc, "NgayLap", thoigian);
                ThayDoiGiaTriTruong(doc, "SoLuongOnline", soluong);
                ThayDoiGiaTriTruong(doc, "DoanhThuOnline", tongtien);

                if (lst1.Any())
                {

                    Range endRange = doc.Range();
                    endRange.Find.Execute("Danh sách các hóa đơn:", Forward: false);
                    Range endOfTenNhanVien = endRange.Duplicate;
                    endOfTenNhanVien.MoveEnd(WdUnits.wdParagraph, 1);
                    int endPosition = endOfTenNhanVien.End;

                    Table table = doc.Tables.Add(doc.Range(endPosition), 1, 6);
                    table.Borders.Enable = 1;
                    table.Cell(1, 1).Range.Text = "Mã Hóa Đơn";
                    table.Cell(1, 2).Range.Text = "Nhân Viên";
                    table.Cell(1, 3).Range.Text = "Khách Hàng";
                    table.Cell(1, 4).Range.Text = "Ngày Lập";
                    table.Cell(1, 5).Range.Text = "Tổng Tiền";
                    table.Cell(1, 6).Range.Text = "Trạng Thái";
                    table.Cell(1, 2).Range.ParagraphFormat.Alignment = WdParagraphAlignment.wdAlignParagraphRight;
                    table.Cell(1, 3).Range.ParagraphFormat.Alignment = WdParagraphAlignment.wdAlignParagraphRight;
                    table.Range.Font.Size = 12;

                    int rowIndex = 2;
                    foreach (var item in lst1)
                    {
                        table.Rows.Add();
                        table.Cell(rowIndex, 1).Range.Text = item.Mahd;
                        table.Cell(rowIndex, 2).Range.Text = item.Tennv;
                        table.Cell(rowIndex, 3).Range.Text = item.Tenkh;
                        table.Cell(rowIndex, 4).Range.Text = item.Ngaylap.ToString("dd/MM/yyyy");
                        table.Cell(rowIndex, 5).Range.Text = item.Tongtien.ToString("N0") + "đ";
                        table.Cell(rowIndex, 6).Range.Text = item.Trangthai;
                        rowIndex++;
                    }
                }
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
            string duongDanTepWord = Path.Combine(duongDanUngDung, @"Bill\PrintStatistic.docx");

            if (File.Exists(duongDanTepWord))
            {
                Microsoft.Office.Interop.Word.Application wordApp = new Microsoft.Office.Interop.Word.Application();
                Microsoft.Office.Interop.Word.Document doc = wordApp.Documents.Open(duongDanTepWord, ReadOnly: true);

            }
            else
                MessageBox.Show("Tệp Word không tồn tại.");
        }

        private void tblOnline_Click(object sender, EventArgs e)
        {
            try{}
            catch (Exception)
            {
                MessageBox.Show("Chưa có dữ liệu để chọn");
            }
        }

        private void openAIFormBtn_Click(object sender, EventArgs e)
        {
            AIForm.TryOpen(sbll, this);
        }
    }
}
