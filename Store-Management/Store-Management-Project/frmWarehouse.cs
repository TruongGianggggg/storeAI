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
    public partial class frmWarehouse : Form
    {
        WarehouseBLL wbll;
        public frmWarehouse()
        {
            InitializeComponent();
            wbll = new WarehouseBLL();
            LoadDataTableWareHouse();
        }

        public void LoadDataTableWareHouse()
        {
            tblWarehouse.DataSource = wbll.GetListWarehouse();
            tblWarehouse.Columns[0].HeaderText = "Mã Sản Phẩm";
            tblWarehouse.Columns[1].HeaderText = "Tên Sản Phẩm";
            tblWarehouse.Columns[2].HeaderText = "Số Lượng";
            tblWarehouse.Columns[2].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
        }

        private void label2_Click(object sender, EventArgs e)
        {
            this.Visible = false;
            Program.mainForm = new frmMain();
            Program.mainForm.Show();
        }
    }
}
