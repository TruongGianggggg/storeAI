namespace Store_Management_Project
{
    partial class frmStatistics
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle3 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle4 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle5 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle6 = new System.Windows.Forms.DataGridViewCellStyle();
            this.label8 = new System.Windows.Forms.Label();
            this.tblOnline = new Guna.UI2.WinForms.Guna2DataGridView();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.tblOffline = new Guna.UI2.WinForms.Guna2DataGridView();
            this.panel1 = new System.Windows.Forms.Panel();
            this.panel2 = new System.Windows.Forms.Panel();
            this.lblDoanhThuOffline = new System.Windows.Forms.Label();
            this.lblDoanhThuOnline = new System.Windows.Forms.Label();
            this.lblSoLuongOffline = new System.Windows.Forms.Label();
            this.lblSoLuongOnline = new System.Windows.Forms.Label();
            this.label12 = new System.Windows.Forms.Label();
            this.label11 = new System.Windows.Forms.Label();
            this.label10 = new System.Windows.Forms.Label();
            this.label9 = new System.Windows.Forms.Label();
            this.btnInHoaDon = new Guna.UI2.WinForms.Guna2Button();
            this.cboNam = new Guna.UI2.WinForms.Guna2ComboBox();
            this.label7 = new System.Windows.Forms.Label();
            this.cboQuy = new Guna.UI2.WinForms.Guna2ComboBox();
            this.label6 = new System.Windows.Forms.Label();
            this.cboThang = new Guna.UI2.WinForms.Guna2ComboBox();
            this.label5 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.dateChonNgay = new System.Windows.Forms.DateTimePicker();
            this.cboLuaChon = new Guna.UI2.WinForms.Guna2ComboBox();
            this.label3 = new System.Windows.Forms.Label();
            this.guna2Button1 = new Guna.UI2.WinForms.Guna2Button();
            this.label14 = new System.Windows.Forms.Label();
            this.openAIFormBtn = new Guna.UI2.WinForms.Guna2CircleButton();
            ((System.ComponentModel.ISupportInitialize)(this.tblOnline)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.tblOffline)).BeginInit();
            this.panel1.SuspendLayout();
            this.panel2.SuspendLayout();
            this.SuspendLayout();
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Font = new System.Drawing.Font("Segoe UI", 30F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label8.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.label8.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.label8.Location = new System.Drawing.Point(22, 24);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(428, 54);
            this.label8.TabIndex = 59;
            this.label8.Text = "THỐNG KÊ HÓA ĐƠN";
            // 
            // tblOnline
            // 
            dataGridViewCellStyle1.BackColor = System.Drawing.Color.White;
            this.tblOnline.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle1;
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle2.BackColor = System.Drawing.Color.White;
            dataGridViewCellStyle2.Font = new System.Drawing.Font("Segoe UI", 10.5F);
            dataGridViewCellStyle2.ForeColor = System.Drawing.Color.Black;
            dataGridViewCellStyle2.SelectionBackColor = System.Drawing.Color.White;
            dataGridViewCellStyle2.SelectionForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.tblOnline.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle2;
            this.tblOnline.ColumnHeadersHeight = 40;
            this.tblOnline.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.EnableResizing;
            dataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle3.BackColor = System.Drawing.Color.White;
            dataGridViewCellStyle3.Font = new System.Drawing.Font("Segoe UI", 10.5F);
            dataGridViewCellStyle3.ForeColor = System.Drawing.Color.Black;
            dataGridViewCellStyle3.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(239)))), ((int)(((byte)(241)))), ((int)(((byte)(243)))));
            dataGridViewCellStyle3.SelectionForeColor = System.Drawing.Color.Black;
            dataGridViewCellStyle3.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.tblOnline.DefaultCellStyle = dataGridViewCellStyle3;
            this.tblOnline.GridColor = System.Drawing.Color.FromArgb(((int)(((byte)(239)))), ((int)(((byte)(241)))), ((int)(((byte)(243)))));
            this.tblOnline.Location = new System.Drawing.Point(31, 159);
            this.tblOnline.Name = "tblOnline";
            this.tblOnline.ReadOnly = true;
            this.tblOnline.RowHeadersVisible = false;
            this.tblOnline.RowTemplate.Height = 30;
            this.tblOnline.Size = new System.Drawing.Size(1242, 411);
            this.tblOnline.TabIndex = 60;
            this.tblOnline.Theme = Guna.UI2.WinForms.Enums.DataGridViewPresetThemes.WhiteGrid;
            this.tblOnline.ThemeStyle.AlternatingRowsStyle.BackColor = System.Drawing.Color.White;
            this.tblOnline.ThemeStyle.AlternatingRowsStyle.Font = null;
            this.tblOnline.ThemeStyle.AlternatingRowsStyle.ForeColor = System.Drawing.Color.Empty;
            this.tblOnline.ThemeStyle.AlternatingRowsStyle.SelectionBackColor = System.Drawing.Color.Empty;
            this.tblOnline.ThemeStyle.AlternatingRowsStyle.SelectionForeColor = System.Drawing.Color.Empty;
            this.tblOnline.ThemeStyle.BackColor = System.Drawing.Color.White;
            this.tblOnline.ThemeStyle.GridColor = System.Drawing.Color.FromArgb(((int)(((byte)(239)))), ((int)(((byte)(241)))), ((int)(((byte)(243)))));
            this.tblOnline.ThemeStyle.HeaderStyle.BackColor = System.Drawing.Color.White;
            this.tblOnline.ThemeStyle.HeaderStyle.BorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.None;
            this.tblOnline.ThemeStyle.HeaderStyle.Font = new System.Drawing.Font("Segoe UI", 10.5F);
            this.tblOnline.ThemeStyle.HeaderStyle.ForeColor = System.Drawing.Color.Black;
            this.tblOnline.ThemeStyle.HeaderStyle.HeaightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.EnableResizing;
            this.tblOnline.ThemeStyle.HeaderStyle.Height = 40;
            this.tblOnline.ThemeStyle.ReadOnly = true;
            this.tblOnline.ThemeStyle.RowsStyle.BackColor = System.Drawing.Color.White;
            this.tblOnline.ThemeStyle.RowsStyle.BorderStyle = System.Windows.Forms.DataGridViewCellBorderStyle.SingleHorizontal;
            this.tblOnline.ThemeStyle.RowsStyle.Font = new System.Drawing.Font("Segoe UI", 10.5F);
            this.tblOnline.ThemeStyle.RowsStyle.ForeColor = System.Drawing.Color.Black;
            this.tblOnline.ThemeStyle.RowsStyle.Height = 30;
            this.tblOnline.ThemeStyle.RowsStyle.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(239)))), ((int)(((byte)(241)))), ((int)(((byte)(243)))));
            this.tblOnline.ThemeStyle.RowsStyle.SelectionForeColor = System.Drawing.Color.Black;
            this.tblOnline.Click += new System.EventHandler(this.tblOnline_Click);
            // 
            // label1
            // 
            this.label1.BackColor = System.Drawing.Color.Red;
            this.label1.Font = new System.Drawing.Font("Segoe UI", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            this.label1.Location = new System.Drawing.Point(28, 115);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(1245, 41);
            this.label1.TabIndex = 61;
            this.label1.Text = "Danh Sách Hóa Đơn Bán Trên Website";
            this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // label2
            // 
            this.label2.BackColor = System.Drawing.Color.Red;
            this.label2.Font = new System.Drawing.Font("Segoe UI", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            this.label2.Location = new System.Drawing.Point(28, 571);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(1245, 41);
            this.label2.TabIndex = 63;
            this.label2.Text = "Danh Sách Hóa Đơn Bán Tại Cửa Hàng";
            this.label2.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // tblOffline
            // 
            dataGridViewCellStyle4.BackColor = System.Drawing.Color.White;
            this.tblOffline.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle4;
            dataGridViewCellStyle5.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle5.BackColor = System.Drawing.Color.White;
            dataGridViewCellStyle5.Font = new System.Drawing.Font("Segoe UI", 10.5F);
            dataGridViewCellStyle5.ForeColor = System.Drawing.Color.Black;
            dataGridViewCellStyle5.SelectionBackColor = System.Drawing.Color.White;
            dataGridViewCellStyle5.SelectionForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle5.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.tblOffline.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle5;
            this.tblOffline.ColumnHeadersHeight = 40;
            this.tblOffline.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.EnableResizing;
            dataGridViewCellStyle6.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle6.BackColor = System.Drawing.Color.White;
            dataGridViewCellStyle6.Font = new System.Drawing.Font("Segoe UI", 10.5F);
            dataGridViewCellStyle6.ForeColor = System.Drawing.Color.Black;
            dataGridViewCellStyle6.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(239)))), ((int)(((byte)(241)))), ((int)(((byte)(243)))));
            dataGridViewCellStyle6.SelectionForeColor = System.Drawing.Color.Black;
            dataGridViewCellStyle6.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.tblOffline.DefaultCellStyle = dataGridViewCellStyle6;
            this.tblOffline.GridColor = System.Drawing.Color.FromArgb(((int)(((byte)(239)))), ((int)(((byte)(241)))), ((int)(((byte)(243)))));
            this.tblOffline.Location = new System.Drawing.Point(31, 615);
            this.tblOffline.Name = "tblOffline";
            this.tblOffline.ReadOnly = true;
            this.tblOffline.RowHeadersVisible = false;
            this.tblOffline.RowTemplate.Height = 30;
            this.tblOffline.Size = new System.Drawing.Size(1242, 404);
            this.tblOffline.TabIndex = 62;
            this.tblOffline.Theme = Guna.UI2.WinForms.Enums.DataGridViewPresetThemes.WhiteGrid;
            this.tblOffline.ThemeStyle.AlternatingRowsStyle.BackColor = System.Drawing.Color.White;
            this.tblOffline.ThemeStyle.AlternatingRowsStyle.Font = null;
            this.tblOffline.ThemeStyle.AlternatingRowsStyle.ForeColor = System.Drawing.Color.Empty;
            this.tblOffline.ThemeStyle.AlternatingRowsStyle.SelectionBackColor = System.Drawing.Color.Empty;
            this.tblOffline.ThemeStyle.AlternatingRowsStyle.SelectionForeColor = System.Drawing.Color.Empty;
            this.tblOffline.ThemeStyle.BackColor = System.Drawing.Color.White;
            this.tblOffline.ThemeStyle.GridColor = System.Drawing.Color.FromArgb(((int)(((byte)(239)))), ((int)(((byte)(241)))), ((int)(((byte)(243)))));
            this.tblOffline.ThemeStyle.HeaderStyle.BackColor = System.Drawing.Color.White;
            this.tblOffline.ThemeStyle.HeaderStyle.BorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.None;
            this.tblOffline.ThemeStyle.HeaderStyle.Font = new System.Drawing.Font("Segoe UI", 10.5F);
            this.tblOffline.ThemeStyle.HeaderStyle.ForeColor = System.Drawing.Color.Black;
            this.tblOffline.ThemeStyle.HeaderStyle.HeaightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.EnableResizing;
            this.tblOffline.ThemeStyle.HeaderStyle.Height = 40;
            this.tblOffline.ThemeStyle.ReadOnly = true;
            this.tblOffline.ThemeStyle.RowsStyle.BackColor = System.Drawing.Color.White;
            this.tblOffline.ThemeStyle.RowsStyle.BorderStyle = System.Windows.Forms.DataGridViewCellBorderStyle.SingleHorizontal;
            this.tblOffline.ThemeStyle.RowsStyle.Font = new System.Drawing.Font("Segoe UI", 10.5F);
            this.tblOffline.ThemeStyle.RowsStyle.ForeColor = System.Drawing.Color.Black;
            this.tblOffline.ThemeStyle.RowsStyle.Height = 30;
            this.tblOffline.ThemeStyle.RowsStyle.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(239)))), ((int)(((byte)(241)))), ((int)(((byte)(243)))));
            this.tblOffline.ThemeStyle.RowsStyle.SelectionForeColor = System.Drawing.Color.Black;
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.SystemColors.ControlLightLight;
            this.panel1.Controls.Add(this.panel2);
            this.panel1.Controls.Add(this.btnInHoaDon);
            this.panel1.Controls.Add(this.cboNam);
            this.panel1.Controls.Add(this.label7);
            this.panel1.Controls.Add(this.cboQuy);
            this.panel1.Controls.Add(this.label6);
            this.panel1.Controls.Add(this.cboThang);
            this.panel1.Controls.Add(this.label5);
            this.panel1.Controls.Add(this.label4);
            this.panel1.Controls.Add(this.dateChonNgay);
            this.panel1.Controls.Add(this.cboLuaChon);
            this.panel1.Controls.Add(this.label3);
            this.panel1.Controls.Add(this.guna2Button1);
            this.panel1.Location = new System.Drawing.Point(1273, 115);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(617, 904);
            this.panel1.TabIndex = 64;
            // 
            // panel2
            // 
            this.panel2.BackColor = System.Drawing.Color.Transparent;
            this.panel2.Controls.Add(this.openAIFormBtn);
            this.panel2.Controls.Add(this.lblDoanhThuOffline);
            this.panel2.Controls.Add(this.lblDoanhThuOnline);
            this.panel2.Controls.Add(this.lblSoLuongOffline);
            this.panel2.Controls.Add(this.lblSoLuongOnline);
            this.panel2.Controls.Add(this.label12);
            this.panel2.Controls.Add(this.label11);
            this.panel2.Controls.Add(this.label10);
            this.panel2.Controls.Add(this.label9);
            this.panel2.Location = new System.Drawing.Point(21, 545);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(574, 340);
            this.panel2.TabIndex = 12;
            // 
            // lblDoanhThuOffline
            // 
            this.lblDoanhThuOffline.AutoSize = true;
            this.lblDoanhThuOffline.Font = new System.Drawing.Font("Segoe UI Semibold", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblDoanhThuOffline.ForeColor = System.Drawing.Color.Red;
            this.lblDoanhThuOffline.Location = new System.Drawing.Point(320, 191);
            this.lblDoanhThuOffline.Name = "lblDoanhThuOffline";
            this.lblDoanhThuOffline.Size = new System.Drawing.Size(17, 25);
            this.lblDoanhThuOffline.TabIndex = 20;
            this.lblDoanhThuOffline.Text = " ";
            // 
            // lblDoanhThuOnline
            // 
            this.lblDoanhThuOnline.AutoSize = true;
            this.lblDoanhThuOnline.Font = new System.Drawing.Font("Segoe UI Semibold", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblDoanhThuOnline.ForeColor = System.Drawing.Color.Red;
            this.lblDoanhThuOnline.Location = new System.Drawing.Point(320, 138);
            this.lblDoanhThuOnline.Name = "lblDoanhThuOnline";
            this.lblDoanhThuOnline.Size = new System.Drawing.Size(17, 25);
            this.lblDoanhThuOnline.TabIndex = 19;
            this.lblDoanhThuOnline.Text = " ";
            // 
            // lblSoLuongOffline
            // 
            this.lblSoLuongOffline.AutoSize = true;
            this.lblSoLuongOffline.Font = new System.Drawing.Font("Segoe UI Semibold", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblSoLuongOffline.ForeColor = System.Drawing.Color.Red;
            this.lblSoLuongOffline.Location = new System.Drawing.Point(355, 72);
            this.lblSoLuongOffline.Name = "lblSoLuongOffline";
            this.lblSoLuongOffline.Size = new System.Drawing.Size(17, 25);
            this.lblSoLuongOffline.TabIndex = 18;
            this.lblSoLuongOffline.Text = " ";
            // 
            // lblSoLuongOnline
            // 
            this.lblSoLuongOnline.AutoSize = true;
            this.lblSoLuongOnline.Font = new System.Drawing.Font("Segoe UI Semibold", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblSoLuongOnline.ForeColor = System.Drawing.Color.Red;
            this.lblSoLuongOnline.Location = new System.Drawing.Point(355, 19);
            this.lblSoLuongOnline.Name = "lblSoLuongOnline";
            this.lblSoLuongOnline.Size = new System.Drawing.Size(17, 25);
            this.lblSoLuongOnline.TabIndex = 17;
            this.lblSoLuongOnline.Text = " ";
            // 
            // label12
            // 
            this.label12.Font = new System.Drawing.Font("Segoe UI Semibold", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label12.ForeColor = System.Drawing.SystemColors.ControlText;
            this.label12.Location = new System.Drawing.Point(25, 183);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(312, 40);
            this.label12.TabIndex = 16;
            this.label12.Text = "Doanh thu thống kê bán offline:";
            this.label12.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // label11
            // 
            this.label11.Font = new System.Drawing.Font("Segoe UI Semibold", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label11.ForeColor = System.Drawing.SystemColors.ControlText;
            this.label11.Location = new System.Drawing.Point(25, 130);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(312, 40);
            this.label11.TabIndex = 15;
            this.label11.Text = "Doanh thu thống kê bán online:";
            this.label11.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // label10
            // 
            this.label10.Font = new System.Drawing.Font("Segoe UI Semibold", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label10.ForeColor = System.Drawing.SystemColors.ControlText;
            this.label10.Location = new System.Drawing.Point(25, 72);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(324, 40);
            this.label10.TabIndex = 14;
            this.label10.Text = "Tổng số lượng hóa đơn bán offline:";
            this.label10.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // label9
            // 
            this.label9.Font = new System.Drawing.Font("Segoe UI Semibold", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label9.ForeColor = System.Drawing.SystemColors.ControlText;
            this.label9.Location = new System.Drawing.Point(25, 19);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(324, 40);
            this.label9.TabIndex = 13;
            this.label9.Text = "Tổng số lượng hóa đơn bán online:";
            this.label9.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // btnInHoaDon
            // 
            this.btnInHoaDon.BorderRadius = 35;
            this.btnInHoaDon.DisabledState.BorderColor = System.Drawing.Color.DarkGray;
            this.btnInHoaDon.DisabledState.CustomBorderColor = System.Drawing.Color.DarkGray;
            this.btnInHoaDon.DisabledState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(169)))), ((int)(((byte)(169)))), ((int)(((byte)(169)))));
            this.btnInHoaDon.DisabledState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(141)))), ((int)(((byte)(141)))), ((int)(((byte)(141)))));
            this.btnInHoaDon.FillColor = System.Drawing.Color.Red;
            this.btnInHoaDon.Font = new System.Drawing.Font("Segoe UI", 18F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnInHoaDon.ForeColor = System.Drawing.Color.White;
            this.btnInHoaDon.Location = new System.Drawing.Point(51, 456);
            this.btnInHoaDon.Name = "btnInHoaDon";
            this.btnInHoaDon.PressedColor = System.Drawing.Color.White;
            this.btnInHoaDon.Size = new System.Drawing.Size(529, 73);
            this.btnInHoaDon.TabIndex = 11;
            this.btnInHoaDon.Text = "IN THỐNG KÊ";
            this.btnInHoaDon.Click += new System.EventHandler(this.btnInHoaDon_Click);
            // 
            // cboNam
            // 
            this.cboNam.BackColor = System.Drawing.Color.Transparent;
            this.cboNam.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawFixed;
            this.cboNam.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboNam.Enabled = false;
            this.cboNam.FocusedColor = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(148)))), ((int)(((byte)(255)))));
            this.cboNam.FocusedState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(148)))), ((int)(((byte)(255)))));
            this.cboNam.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cboNam.ForeColor = System.Drawing.Color.Black;
            this.cboNam.ItemHeight = 30;
            this.cboNam.Items.AddRange(new object[] {
            "Chọn năm thống kê"});
            this.cboNam.Location = new System.Drawing.Point(253, 394);
            this.cboNam.Name = "cboNam";
            this.cboNam.Size = new System.Drawing.Size(325, 36);
            this.cboNam.StartIndex = 0;
            this.cboNam.TabIndex = 10;
            this.cboNam.SelectedIndexChanged += new System.EventHandler(this.cboNam_SelectedIndexChanged);
            // 
            // label7
            // 
            this.label7.Font = new System.Drawing.Font("Segoe UI", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label7.Location = new System.Drawing.Point(44, 390);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(203, 40);
            this.label7.TabIndex = 9;
            this.label7.Text = "Chọn năm thống kê:";
            this.label7.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // cboQuy
            // 
            this.cboQuy.BackColor = System.Drawing.Color.Transparent;
            this.cboQuy.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawFixed;
            this.cboQuy.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboQuy.Enabled = false;
            this.cboQuy.FocusedColor = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(148)))), ((int)(((byte)(255)))));
            this.cboQuy.FocusedState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(148)))), ((int)(((byte)(255)))));
            this.cboQuy.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cboQuy.ForeColor = System.Drawing.Color.Black;
            this.cboQuy.ItemHeight = 30;
            this.cboQuy.Items.AddRange(new object[] {
            "Chọn quý thống kê",
            "Quý 1",
            "Quý 2",
            "Quý 3",
            "Quý 4"});
            this.cboQuy.Location = new System.Drawing.Point(253, 332);
            this.cboQuy.Name = "cboQuy";
            this.cboQuy.Size = new System.Drawing.Size(325, 36);
            this.cboQuy.StartIndex = 0;
            this.cboQuy.TabIndex = 8;
            this.cboQuy.SelectedIndexChanged += new System.EventHandler(this.cboQuy_SelectedIndexChanged);
            // 
            // label6
            // 
            this.label6.Font = new System.Drawing.Font("Segoe UI", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label6.Location = new System.Drawing.Point(44, 328);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(203, 40);
            this.label6.TabIndex = 7;
            this.label6.Text = "Chọn quý thống kê:";
            this.label6.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // cboThang
            // 
            this.cboThang.BackColor = System.Drawing.Color.Transparent;
            this.cboThang.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawFixed;
            this.cboThang.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboThang.Enabled = false;
            this.cboThang.FocusedColor = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(148)))), ((int)(((byte)(255)))));
            this.cboThang.FocusedState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(148)))), ((int)(((byte)(255)))));
            this.cboThang.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cboThang.ForeColor = System.Drawing.Color.Black;
            this.cboThang.ItemHeight = 30;
            this.cboThang.Items.AddRange(new object[] {
            "Chọn tháng thống kê",
            "Tháng 1",
            "Tháng 2",
            "Tháng 3",
            "Tháng 4",
            "Tháng 5",
            "Tháng 6",
            "Tháng 7",
            "Tháng 8",
            "Tháng 9",
            "Tháng 10",
            "Tháng 11",
            "Tháng 12"});
            this.cboThang.Location = new System.Drawing.Point(253, 271);
            this.cboThang.Name = "cboThang";
            this.cboThang.Size = new System.Drawing.Size(325, 36);
            this.cboThang.StartIndex = 0;
            this.cboThang.TabIndex = 6;
            this.cboThang.SelectedIndexChanged += new System.EventHandler(this.cboThang_SelectedIndexChanged);
            // 
            // label5
            // 
            this.label5.Font = new System.Drawing.Font("Segoe UI", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.Location = new System.Drawing.Point(44, 267);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(203, 40);
            this.label5.TabIndex = 5;
            this.label5.Text = "Chọn tháng thống kê:";
            this.label5.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // label4
            // 
            this.label4.Font = new System.Drawing.Font("Segoe UI", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.Location = new System.Drawing.Point(44, 207);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(203, 40);
            this.label4.TabIndex = 4;
            this.label4.Text = "Chọn ngày thống kê:";
            this.label4.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // dateChonNgay
            // 
            this.dateChonNgay.CalendarFont = new System.Drawing.Font("Segoe UI", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dateChonNgay.CalendarForeColor = System.Drawing.Color.Black;
            this.dateChonNgay.CustomFormat = "dd/MM/yyyy";
            this.dateChonNgay.Enabled = false;
            this.dateChonNgay.Font = new System.Drawing.Font("Segoe UI", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dateChonNgay.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dateChonNgay.Location = new System.Drawing.Point(253, 209);
            this.dateChonNgay.Name = "dateChonNgay";
            this.dateChonNgay.Size = new System.Drawing.Size(325, 33);
            this.dateChonNgay.TabIndex = 3;
            this.dateChonNgay.ValueChanged += new System.EventHandler(this.dateChonNgay_ValueChanged);
            // 
            // cboLuaChon
            // 
            this.cboLuaChon.BackColor = System.Drawing.Color.Transparent;
            this.cboLuaChon.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawFixed;
            this.cboLuaChon.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboLuaChon.FocusedColor = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(148)))), ((int)(((byte)(255)))));
            this.cboLuaChon.FocusedState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(148)))), ((int)(((byte)(255)))));
            this.cboLuaChon.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cboLuaChon.ForeColor = System.Drawing.Color.Black;
            this.cboLuaChon.ItemHeight = 30;
            this.cboLuaChon.Items.AddRange(new object[] {
            "Tất Cả",
            "Theo Ngày",
            "Tháng Tháng",
            "Theo Quý",
            "Theo Năm"});
            this.cboLuaChon.Location = new System.Drawing.Point(253, 154);
            this.cboLuaChon.Name = "cboLuaChon";
            this.cboLuaChon.Size = new System.Drawing.Size(325, 36);
            this.cboLuaChon.StartIndex = 0;
            this.cboLuaChon.TabIndex = 2;
            this.cboLuaChon.SelectedIndexChanged += new System.EventHandler(this.cboLuaChon_SelectedIndexChanged);
            // 
            // label3
            // 
            this.label3.Font = new System.Drawing.Font("Segoe UI", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(46, 150);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(201, 40);
            this.label3.TabIndex = 1;
            this.label3.Text = "Chọn loại thống kê:";
            this.label3.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // guna2Button1
            // 
            this.guna2Button1.BorderRadius = 35;
            this.guna2Button1.DisabledState.BorderColor = System.Drawing.Color.DarkGray;
            this.guna2Button1.DisabledState.CustomBorderColor = System.Drawing.Color.DarkGray;
            this.guna2Button1.DisabledState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(169)))), ((int)(((byte)(169)))), ((int)(((byte)(169)))));
            this.guna2Button1.DisabledState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(141)))), ((int)(((byte)(141)))), ((int)(((byte)(141)))));
            this.guna2Button1.FillColor = System.Drawing.Color.Red;
            this.guna2Button1.Font = new System.Drawing.Font("Segoe UI", 18F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.guna2Button1.ForeColor = System.Drawing.Color.White;
            this.guna2Button1.Location = new System.Drawing.Point(49, 34);
            this.guna2Button1.Name = "guna2Button1";
            this.guna2Button1.PressedColor = System.Drawing.Color.White;
            this.guna2Button1.Size = new System.Drawing.Size(529, 73);
            this.guna2Button1.TabIndex = 0;
            this.guna2Button1.Text = "THỐNG KÊ DOANH THU";
            // 
            // label14
            // 
            this.label14.AutoSize = true;
            this.label14.Font = new System.Drawing.Font("Microsoft Sans Serif", 30F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label14.Location = new System.Drawing.Point(1860, 9);
            this.label14.Name = "label14";
            this.label14.Size = new System.Drawing.Size(41, 46);
            this.label14.TabIndex = 113;
            this.label14.Text = "x";
            this.label14.Click += new System.EventHandler(this.label14_Click);
            // 
            // openAIFormBtn
            // 
            this.openAIFormBtn.DisabledState.BorderColor = System.Drawing.Color.DarkGray;
            this.openAIFormBtn.DisabledState.CustomBorderColor = System.Drawing.Color.DarkGray;
            this.openAIFormBtn.DisabledState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(169)))), ((int)(((byte)(169)))), ((int)(((byte)(169)))));
            this.openAIFormBtn.DisabledState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(141)))), ((int)(((byte)(141)))), ((int)(((byte)(141)))));
            this.openAIFormBtn.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.openAIFormBtn.ForeColor = System.Drawing.Color.White;
            this.openAIFormBtn.Location = new System.Drawing.Point(471, 237);
            this.openAIFormBtn.Name = "openAIFormBtn";
            this.openAIFormBtn.ShadowDecoration.Mode = Guna.UI2.WinForms.Enums.ShadowMode.Circle;
            this.openAIFormBtn.Size = new System.Drawing.Size(100, 100);
            this.openAIFormBtn.TabIndex = 21;
            this.openAIFormBtn.Text = "CCCCCCCCCCc";
            this.openAIFormBtn.Click += new System.EventHandler(this.openAIFormBtn_Click);
            // 
            // frmStatistics
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1940, 1100);
            this.Controls.Add(this.label14);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.tblOffline);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.tblOnline);
            this.Controls.Add(this.label8);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "frmStatistics";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "frmStatistics";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            ((System.ComponentModel.ISupportInitialize)(this.tblOnline)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.tblOffline)).EndInit();
            this.panel1.ResumeLayout(false);
            this.panel2.ResumeLayout(false);
            this.panel2.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label8;
        private Guna.UI2.WinForms.Guna2DataGridView tblOnline;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private Guna.UI2.WinForms.Guna2DataGridView tblOffline;
        private System.Windows.Forms.Panel panel1;
        private Guna.UI2.WinForms.Guna2Button guna2Button1;
        private System.Windows.Forms.Label label3;
        private Guna.UI2.WinForms.Guna2ComboBox cboLuaChon;
        private System.Windows.Forms.DateTimePicker dateChonNgay;
        private System.Windows.Forms.Label label4;
        private Guna.UI2.WinForms.Guna2ComboBox cboThang;
        private System.Windows.Forms.Label label5;
        private Guna.UI2.WinForms.Guna2ComboBox cboQuy;
        private System.Windows.Forms.Label label6;
        private Guna.UI2.WinForms.Guna2ComboBox cboNam;
        private System.Windows.Forms.Label label7;
        private Guna.UI2.WinForms.Guna2Button btnInHoaDon;
        private System.Windows.Forms.Label label14;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Label label12;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.Label lblDoanhThuOffline;
        private System.Windows.Forms.Label lblDoanhThuOnline;
        private System.Windows.Forms.Label lblSoLuongOffline;
        private System.Windows.Forms.Label lblSoLuongOnline;
        private Guna.UI2.WinForms.Guna2CircleButton openAIFormBtn;
    }
}