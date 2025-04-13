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
    public partial class frmBillManagement : Form
    {
        BillManagementBLL bmbll;
        public frmBillManagement()
        {
            InitializeComponent();
            bmbll = new BillManagementBLL();
            LoadTableHoaDonOffline();
            LoadTableChiTietHoaDonOffline("");

            LoadTableHoaDonOnline();
            LoadTableChiTietHoaDonOnline("");
        }

        private void label7_Click(object sender, EventArgs e)
        {
            this.Visible = false;
            Program.mainForm = new frmMain();
            Program.mainForm.Show();  
        }

        public void LoadTableHoaDonOffline()
        {
            tblHoaDonOffline.DataSource = bmbll.LoadHoaDonOffline();
            tblHoaDonOffline.Columns[0].HeaderText = "Mã Hóa Đơn";
            tblHoaDonOffline.Columns[1].HeaderText = "Tên Nhân Viên";
            tblHoaDonOffline.Columns[2].HeaderText = "Ngày Lập";
            tblHoaDonOffline.Columns[3].HeaderText = "Trạng Thái";
            tblHoaDonOffline.Columns[4].HeaderText = "Tổng Tiền";
        }

        public void LoadTableChiTietHoaDonOffline(string mahd)
        {
            tblChiTietHoaDonOffline.DataSource = bmbll.LoadChiTietHoaDonOffline(mahd);
            tblChiTietHoaDonOffline.Columns[0].HeaderText = "STT";
            tblChiTietHoaDonOffline.Columns[1].HeaderText = "Mã Hóa Đơn";
            tblChiTietHoaDonOffline.Columns[2].HeaderText = "Tên Sản Phẩm";
            tblChiTietHoaDonOffline.Columns[3].HeaderText = "Số Lượng";
        }

        private void tblHoaDonOffline_Click(object sender, EventArgs e)
        {
            try
            {
                int i = tblHoaDonOffline.CurrentRow.Index;
                LoadTableChiTietHoaDonOffline(tblHoaDonOffline.Rows[i].Cells[0].Value.ToString());
            }
            catch (Exception)
            {
                MessageBox.Show("Lỗi hệ thống");
            }
        }

        public void LoadTableHoaDonOnline()
        {
            tblHoaDonOnline.DataSource = bmbll.LayDanhSachHoaDonOnline();
            tblHoaDonOnline.Columns[0].HeaderText = "Mã Hóa Đơn";
            tblHoaDonOnline.Columns[1].HeaderText = "Tên Nhân Viên";
            tblHoaDonOnline.Columns[2].HeaderText = "Tên Khách Hàng";
            tblHoaDonOnline.Columns[3].HeaderText = "Ngày Lập";
            tblHoaDonOnline.Columns[4].HeaderText = "Trạng Thái";
            tblHoaDonOnline.Columns[5].HeaderText = "Tổng Tiền";
        }

        public void LoadTableChiTietHoaDonOnline(string mahd)
        {
            tblChiTietHoaDonOnline.DataSource = bmbll.LayDanhSachCTHDOnline(mahd);
            tblChiTietHoaDonOnline.Columns[0].HeaderText = "STT";
            tblChiTietHoaDonOnline.Columns[1].HeaderText = "Mã Hóa Đơn";
            tblChiTietHoaDonOnline.Columns[2].HeaderText = "Tên Sản Phẩm";
            tblChiTietHoaDonOnline.Columns[3].HeaderText = "Số Lượng";
        }

        private void tblHoaDonOnline_Click(object sender, EventArgs e)
        {
            int i = tblHoaDonOnline.CurrentRow.Index;
            LoadTableChiTietHoaDonOnline(tblHoaDonOnline.Rows[i].Cells[0].Value.ToString());
        }
    }
}
