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
    public partial class frmVoucher : Form
    {
        VoucherBLL vbll;
        public frmVoucher()
        {
            InitializeComponent();
            vbll = new VoucherBLL();
            LoadTable();
        }

        public void LoadTable()
        {
            tblVoucher.DataSource = vbll.GetVoucherList();
        }

        private void tblVoucher_Click(object sender, EventArgs e)
        {
            int i = tblVoucher.CurrentRow.Index;
            txtMavoucher.Text = tblVoucher.Rows[i].Cells[0].Value.ToString();
            txtCode.Text = tblVoucher.Rows[i].Cells[1].Value.ToString();
            cboGiamgia.Text = tblVoucher.Rows[i].Cells[2].Value.ToString();
            dateChonNgay.Value = DateTime.Parse(tblVoucher.Rows[i].Cells[3].Value.ToString());
            btnThem.Enabled = false;
            btnXoa.Enabled = true;
            btnSua.Enabled = true;
        }

        private void btnThem_Click(object sender, EventArgs e)
        {
            try
            {
                vbll.ThemVoucher(txtCode.Text, int.Parse(cboGiamgia.Text), DateTime.Parse(dateChonNgay.Value.ToString("dd/MM/yyyy")));
                LoadTable();
                txtCode.Text = string.Empty;
                cboGiamgia.SelectedIndex = 0;
                dateChonNgay.Value = DateTime.Now;
            }
            catch (Exception)
            {
                MessageBox.Show("Lỗi hệ thống");
            }
        }

        private void btnXoa_Click(object sender, EventArgs e)
        {
            try
            {
                vbll.XoaVoucher(int.Parse(txtMavoucher.Text));
                LoadTable();
                txtCode.Text = string.Empty;
                cboGiamgia.SelectedIndex = 0;
                dateChonNgay.Value = DateTime.Now;
            }
            catch (Exception)
            {
                MessageBox.Show("Voucher đã được sử dụng, không thể xóa");
            }
        }

        private void btnSua_Click(object sender, EventArgs e)
        {
            try
            {
                vbll.SuaVoucher(int.Parse(txtMavoucher.Text), txtCode.Text, int.Parse(cboGiamgia.Text), DateTime.Parse(dateChonNgay.Value.ToString("dd/MM/yyyy")));
                LoadTable();
                txtCode.Text = string.Empty;
                cboGiamgia.SelectedIndex = 0;
                dateChonNgay.Value = DateTime.Now;
            }
            catch (Exception)
            {
                MessageBox.Show("Lỗi hệ thống");
            }
        }

        private void btnThoat_Click(object sender, EventArgs e)
        {
            this.Visible = false;
            Program.mainForm = new frmMain();
            Program.mainForm.Show();
        }

        private void btnNhapLai_Click(object sender, EventArgs e)
        {
            txtMavoucher.Text = string.Empty;
            txtCode.Text = string.Empty;
            cboGiamgia.SelectedIndex = 0;
            dateChonNgay.Value = DateTime.Now;
            btnXoa.Enabled = false;
            btnSua.Enabled = false;
            btnThem.Enabled = true;
        }
    }
}
