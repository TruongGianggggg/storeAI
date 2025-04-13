using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.UI.WebControls;
using System.Windows.Forms;
using BLL;
using DTO;
using static System.Net.Mime.MediaTypeNames;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace Store_Management_Project
{
    public partial class frmCustomer : Form
    {
        CustomerBLL customerBLL;
        List<CustomerDTO> khachHangList;
        public frmCustomer()
        {
            InitializeComponent();
            

            customerBLL = new CustomerBLL();
            LoadDataKhachHang();
            InitializeCustomTextBox();
            cboFind.SelectedIndex = 0;
        }
        public void LoadDataKhachHang()
        {
            khachHangList = customerBLL.getDanhSachKhachHang();
            tblCustomer.DataSource = khachHangList;
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




        private void tblCustomer_Click(object sender, EventArgs e)
        {
            DataGridViewRow selectedRow = tblCustomer.SelectedRows[0];
            txtMaKH.Text = selectedRow.Cells[0].Value.ToString();
            txtHtdKH.Text = selectedRow.Cells[1].Value.ToString();
            txtTenKH.Text = selectedRow.Cells[2].Value.ToString();
            txtEmail.Text = selectedRow.Cells[3].Value.ToString();
            txtSDT.Text = selectedRow.Cells[4].Value.ToString();
            txtDiaChi.Text = selectedRow.Cells[5].Value.ToString();

            txtHtdKH.Enabled = true;
            txtTenKH.Enabled = true;
            txtEmail.Enabled = true;
            txtSDT.Enabled = true;
            txtDiaChi.Enabled = true;

            btnLuu.Enabled = false;
            btnSua.Enabled = true;
            btnXoa.Enabled = true;
        }


        private void guna2Button2_Click(object sender, EventArgs e)
        {
            int i = tblCustomer.CurrentRow.Index;

            DialogResult result = MessageBox.Show("Bạn có chắc chắn muốn xóa thiết bị này?", "Xác nhận xóa", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

            if (result == DialogResult.Yes)
            {
                customerBLL.XoaKhachHang(customerBLL.LayIDtuEmail(txtSDT.Text));
                LoadDataKhachHang();
            }
            txtHtdKH.Text = string.Empty;
            txtTenKH.Text = string.Empty;
            txtEmail.Text = string.Empty;
            txtSDT.Text = string.Empty;
            txtDiaChi.Text = string.Empty;
        }

        private void guna2Button1_Click(object sender, EventArgs e)
        {
            DialogResult result = MessageBox.Show("Bạn có muốn thêm khách hàng này?", "Xác nhận", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

            if (customerBLL.KiemTraEmail(txtEmail.Text))
            {
                MessageBox.Show("Email đã tồn tại. Vui lòng nhập một email khác.");
            }
            else
            {
                if (result == DialogResult.Yes)
                {
                    customerBLL.ThemKhachHang(txtHtdKH.Text.Trim(), txtTenKH.Text.Trim(), txtEmail.Text.Trim(), txtSDT.Text.Trim(), txtDiaChi.Text.Trim());
                    LoadDataKhachHang();
                }
            }

        }

        private void guna2Button4_Click(object sender, EventArgs e)
        {
            txtHtdKH.Text = string.Empty;
            txtTenKH.Text = string.Empty;
            txtEmail.Text = string.Empty;
            txtSDT.Text = string.Empty;
            txtDiaChi.Text = string.Empty;

            txtHtdKH.Enabled = true;
            txtTenKH.Enabled = true;
            txtEmail.Enabled = true;
            txtSDT.Enabled = true;
            txtDiaChi.Enabled = true;

            btnLuu.Enabled = true;
            btnSua.Enabled = false;
            btnXoa.Enabled = false;
        }

        private void guna2Button3_Click(object sender, EventArgs e)
        {
            DialogResult result = MessageBox.Show("Bạn có muốn cập nhật lại khách hàng này?", "Xác nhận", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            int i = tblCustomer.CurrentRow.Index;
            if (result == DialogResult.Yes)
            {
                customerBLL.CapNhatKhachHang(txtHtdKH.Text, txtTenKH.Text, txtEmail.Text, txtSDT.Text, txtDiaChi.Text, int.Parse(tblCustomer.Rows[i].Cells[0].Value.ToString()));
                LoadDataKhachHang();
            }
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

        private void button1_Click(object sender, EventArgs e)
        {
            if (!isTxtFindDefault)
            {
                if (cboFind.Text == "Mã Khách Hàng")
                    tblCustomer.DataSource = customerBLL.GetKhachHangList_MaKhachHang(txtFind.Text.Trim());
                if (cboFind.Text == "Số Điện Thoại")
                    tblCustomer.DataSource = customerBLL.GetKhachHangList_SoDienThoai(txtFind.Text.Trim());
                if (cboFind.Text == "Email")
                    tblCustomer.DataSource = customerBLL.GetKhachHangList_Email(txtFind.Text.Trim());
            }
            else
            {
                LoadDataKhachHang();
            }


        }

    }
}
