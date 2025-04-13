using Guna.UI2.WinForms.Suite;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Reflection.Emit;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Store_Management_Project
{
    public partial class frmMain : Form
    {
        public frmMain()
        {
            InitializeComponent();
            if (frmLogin.quyen.Equals("Admin"))
            {
                lblUsername.Text = frmLogin.tendn;
                lblRole.Text = frmLogin.quyen;
            }
            else
            {
                lblUsername.Text = frmLogin.tendn;
                lblRole.Text = frmLogin.quyen;
                btnTaiKhoan.Visible = false;
                btnThongKe.Visible = false;
                btnNhanVien.Visible = false;
                btnNhapKho.Visible = false;
                btnSamPham.Visible = false;
                btnDanhMuc.Visible = false;
                btnThuongHieu.Visible = false;
                
                btnVoucher.Visible = true;
                btnThuongHieu.Visible = false;
                button1.Visible = true;
            }
        }

        private void label1_Click(object sender, EventArgs e)
        {
            this.Visible = false;
            frmProduct frm = new frmProduct();
            frm.Show();
        }

        private void label2_Click(object sender, EventArgs e)
        {
            this.Visible = false;
            Program.customerForm = new frmCustomer();
            Program.customerForm.Show();
        }

        private void quảnLýDanhMụcToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Visible = false;
            Program.categoriesForm = new frmCategories();
            Program.categoriesForm.Show();
        }

        private void quảnLýThươngHiệuToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Visible = false;
            Program.brandForm = new frmBrand();
            Program.brandForm.Show();
        }

        private void label8_Click(object sender, EventArgs e)
        {
            this.Visible = false;
            Program.staffForm = new frmStaff();
            Program.staffForm.Show();
        }

        private void label3_Click(object sender, EventArgs e)
        {
            this.Visible = false;
            Program.orderForm = new frmOrder();
            Program.orderForm.Show();
        }

        private void label6_Click(object sender, EventArgs e)
        {
            this.Visible = false;
            Program.importForm = new frmImport();
            Program.importForm.Show();
        }

        private void khoHàngTổngToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Visible = false;
            Program.warehouseForm = new frmWarehouse();
            Program.warehouseForm.Show();
        }

        private void nhậpHàngToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            this.Visible = false;
            Program.importForm = new frmImport();
            Program.importForm.Show();
        }

        private void label9_Click(object sender, EventArgs e)
        {
            this.Visible = false;
            Program.loginForm = new frmLogin();
            Program.loginForm.Show();
        }

        private void tạoĐơnHàngToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Program.orderForm = new frmOrder();
            Program.orderForm.Show();
            this.Visible = false;
        }

        private void thoátToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Visible = false;
            Program.loginForm = new frmLogin();
            Program.loginForm.Show();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.Visible = false;
            Program.staffForm = new frmStaff();
            Program.staffForm.Show();
        }

        private void quảnLýThôngTinKháchHàngToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Visible = false;
            Program.customerForm = new frmCustomer();
            Program.customerForm.Show();
        }

        private void btnDanhMuc_Click(object sender, EventArgs e)
        {
            this.Visible = false;
            Program.categoriesForm = new frmCategories();
            Program.categoriesForm.Show();
        }

        private void btnThuongHieu_Click(object sender, EventArgs e)
        {
            this.Visible = false;
            Program.brandForm = new frmBrand();
            Program.brandForm.Show();
        }

        private void btnSamPham_Click(object sender, EventArgs e)
        {
            this.Visible = false;
            Program.productForm = new frmProduct();
            Program.productForm.Show();
        }

        private void btnNhapKho_Click(object sender, EventArgs e)
        {
            this.Visible=false;
            Program.importForm = new frmImport();
            Program.importForm.Show();
        }

        private void btnTaiKhoan_Click(object sender, EventArgs e)
        {
            this.Visible = false;
            Program.accountStaffForm = new frmAccountStaff();
            Program.accountStaffForm.Show();
        }

        private void button1_Click_1(object sender, EventArgs e)
        {
            this.Visible = false;
            Program.billManagementForm = new frmBillManagement();
            Program.billManagementForm.Show();
        }

        private void quảnLýTàiKhoảnKháchHàngToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Visible = false;
            Program.accountCustomerForm = new frmAccountCustomer();
            Program.accountCustomerForm.Show();
        }

        private void đơnHàngĐangChờToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Visible = false;
            Program.orderOnlineForm = new frmOrderOnline();
            Program.orderOnlineForm.Show();
        }

        private void btnThongKe_Click(object sender, EventArgs e)
        {
            this.Visible = false;
            Program.statisticsForm = new frmStatistics();
            Program.statisticsForm.Show();
        }

        private void btnPhieuNhap_Click(object sender, EventArgs e)
        {
            this.Visible = false;
            Program.importfinishForm = new frmImportFinsh();
            Program.importfinishForm.Show();
        }

        private void btnVoucher_Click(object sender, EventArgs e)
        {
            this.Visible = false;
            Program.voucherForm = new frmVoucher();
            Program.voucherForm.Show();
        }

        private void đồiMậtKhẩuToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Program.changePasswordForm = new frmChangePassword();
            Program.changePasswordForm.ShowDialog();
        }
    }
}
