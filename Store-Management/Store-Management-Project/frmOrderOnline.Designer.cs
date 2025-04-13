namespace Store_Management_Project
{
    partial class frmOrderOnline
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmOrderOnline));
            this.tbl = new Guna.UI2.WinForms.Guna2DataGridView();
            this.label16 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.tblDetail = new Guna.UI2.WinForms.Guna2DataGridView();
            this.label2 = new System.Windows.Forms.Label();
            this.btnXacNhan = new Guna.UI2.WinForms.Guna2Button();
            this.btnLayHang = new Guna.UI2.WinForms.Guna2Button();
            this.btnHoanTat = new Guna.UI2.WinForms.Guna2Button();
            this.btnGiaoHang = new Guna.UI2.WinForms.Guna2Button();
            this.lblMaDonHang = new System.Windows.Forms.Label();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.pictureBox2 = new System.Windows.Forms.PictureBox();
            this.pictureBox3 = new System.Windows.Forms.PictureBox();
            this.label3 = new System.Windows.Forms.Label();
            this.cboLoc = new Guna.UI2.WinForms.Guna2ComboBox();
            this.dateChon = new Guna.UI2.WinForms.Guna2DateTimePicker();
            this.label8 = new System.Windows.Forms.Label();
            this.label14 = new System.Windows.Forms.Label();
            this.pictureBox4 = new System.Windows.Forms.PictureBox();
            this.btnInHoaDon = new Guna.UI2.WinForms.Guna2Button();
            ((System.ComponentModel.ISupportInitialize)(this.tbl)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.tblDetail)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox3)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox4)).BeginInit();
            this.SuspendLayout();
            // 
            // tbl
            // 
            dataGridViewCellStyle1.BackColor = System.Drawing.Color.White;
            this.tbl.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle1;
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle2.BackColor = System.Drawing.Color.White;
            dataGridViewCellStyle2.Font = new System.Drawing.Font("Segoe UI", 10.5F);
            dataGridViewCellStyle2.ForeColor = System.Drawing.Color.Black;
            dataGridViewCellStyle2.SelectionBackColor = System.Drawing.Color.White;
            dataGridViewCellStyle2.SelectionForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.tbl.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle2;
            this.tbl.ColumnHeadersHeight = 40;
            this.tbl.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.EnableResizing;
            dataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle3.BackColor = System.Drawing.Color.White;
            dataGridViewCellStyle3.Font = new System.Drawing.Font("Segoe UI", 10.5F);
            dataGridViewCellStyle3.ForeColor = System.Drawing.Color.Black;
            dataGridViewCellStyle3.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(239)))), ((int)(((byte)(241)))), ((int)(((byte)(243)))));
            dataGridViewCellStyle3.SelectionForeColor = System.Drawing.Color.Black;
            dataGridViewCellStyle3.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.tbl.DefaultCellStyle = dataGridViewCellStyle3;
            this.tbl.GridColor = System.Drawing.Color.FromArgb(((int)(((byte)(239)))), ((int)(((byte)(241)))), ((int)(((byte)(243)))));
            this.tbl.Location = new System.Drawing.Point(61, 243);
            this.tbl.Name = "tbl";
            this.tbl.ReadOnly = true;
            this.tbl.RowHeadersVisible = false;
            this.tbl.RowTemplate.Height = 30;
            this.tbl.Size = new System.Drawing.Size(1306, 403);
            this.tbl.TabIndex = 22;
            this.tbl.Theme = Guna.UI2.WinForms.Enums.DataGridViewPresetThemes.WhiteGrid;
            this.tbl.ThemeStyle.AlternatingRowsStyle.BackColor = System.Drawing.Color.White;
            this.tbl.ThemeStyle.AlternatingRowsStyle.Font = null;
            this.tbl.ThemeStyle.AlternatingRowsStyle.ForeColor = System.Drawing.Color.Empty;
            this.tbl.ThemeStyle.AlternatingRowsStyle.SelectionBackColor = System.Drawing.Color.Empty;
            this.tbl.ThemeStyle.AlternatingRowsStyle.SelectionForeColor = System.Drawing.Color.Empty;
            this.tbl.ThemeStyle.BackColor = System.Drawing.Color.White;
            this.tbl.ThemeStyle.GridColor = System.Drawing.Color.FromArgb(((int)(((byte)(239)))), ((int)(((byte)(241)))), ((int)(((byte)(243)))));
            this.tbl.ThemeStyle.HeaderStyle.BackColor = System.Drawing.Color.White;
            this.tbl.ThemeStyle.HeaderStyle.BorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.None;
            this.tbl.ThemeStyle.HeaderStyle.Font = new System.Drawing.Font("Segoe UI", 10.5F);
            this.tbl.ThemeStyle.HeaderStyle.ForeColor = System.Drawing.Color.Black;
            this.tbl.ThemeStyle.HeaderStyle.HeaightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.EnableResizing;
            this.tbl.ThemeStyle.HeaderStyle.Height = 40;
            this.tbl.ThemeStyle.ReadOnly = true;
            this.tbl.ThemeStyle.RowsStyle.BackColor = System.Drawing.Color.White;
            this.tbl.ThemeStyle.RowsStyle.BorderStyle = System.Windows.Forms.DataGridViewCellBorderStyle.SingleHorizontal;
            this.tbl.ThemeStyle.RowsStyle.Font = new System.Drawing.Font("Segoe UI", 10.5F);
            this.tbl.ThemeStyle.RowsStyle.ForeColor = System.Drawing.Color.Black;
            this.tbl.ThemeStyle.RowsStyle.Height = 30;
            this.tbl.ThemeStyle.RowsStyle.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(239)))), ((int)(((byte)(241)))), ((int)(((byte)(243)))));
            this.tbl.ThemeStyle.RowsStyle.SelectionForeColor = System.Drawing.Color.Black;
            this.tbl.Click += new System.EventHandler(this.tbl_Click);
            // 
            // label16
            // 
            this.label16.BackColor = System.Drawing.Color.Red;
            this.label16.Font = new System.Drawing.Font("Segoe UI", 20.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label16.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            this.label16.Location = new System.Drawing.Point(61, 206);
            this.label16.Name = "label16";
            this.label16.Size = new System.Drawing.Size(1306, 37);
            this.label16.TabIndex = 42;
            this.label16.Text = "QUẢN LÝ ĐƠN ĐẶT HÀNG";
            // 
            // label1
            // 
            this.label1.BackColor = System.Drawing.Color.Red;
            this.label1.Font = new System.Drawing.Font("Segoe UI", 20.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            this.label1.Location = new System.Drawing.Point(61, 648);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(1306, 40);
            this.label1.TabIndex = 44;
            this.label1.Text = "CHI TIẾT ĐƠN ĐẶT HÀNG:";
            // 
            // tblDetail
            // 
            dataGridViewCellStyle4.BackColor = System.Drawing.Color.White;
            this.tblDetail.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle4;
            dataGridViewCellStyle5.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle5.BackColor = System.Drawing.Color.White;
            dataGridViewCellStyle5.Font = new System.Drawing.Font("Segoe UI", 10.5F);
            dataGridViewCellStyle5.ForeColor = System.Drawing.Color.Black;
            dataGridViewCellStyle5.SelectionBackColor = System.Drawing.Color.White;
            dataGridViewCellStyle5.SelectionForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle5.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.tblDetail.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle5;
            this.tblDetail.ColumnHeadersHeight = 40;
            this.tblDetail.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.EnableResizing;
            dataGridViewCellStyle6.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle6.BackColor = System.Drawing.Color.White;
            dataGridViewCellStyle6.Font = new System.Drawing.Font("Segoe UI", 10.5F);
            dataGridViewCellStyle6.ForeColor = System.Drawing.Color.Black;
            dataGridViewCellStyle6.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(239)))), ((int)(((byte)(241)))), ((int)(((byte)(243)))));
            dataGridViewCellStyle6.SelectionForeColor = System.Drawing.Color.Black;
            dataGridViewCellStyle6.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.tblDetail.DefaultCellStyle = dataGridViewCellStyle6;
            this.tblDetail.GridColor = System.Drawing.Color.FromArgb(((int)(((byte)(239)))), ((int)(((byte)(241)))), ((int)(((byte)(243)))));
            this.tblDetail.Location = new System.Drawing.Point(61, 688);
            this.tblDetail.Name = "tblDetail";
            this.tblDetail.ReadOnly = true;
            this.tblDetail.RowHeadersVisible = false;
            this.tblDetail.RowTemplate.Height = 30;
            this.tblDetail.Size = new System.Drawing.Size(1306, 330);
            this.tblDetail.TabIndex = 43;
            this.tblDetail.Theme = Guna.UI2.WinForms.Enums.DataGridViewPresetThemes.WhiteGrid;
            this.tblDetail.ThemeStyle.AlternatingRowsStyle.BackColor = System.Drawing.Color.White;
            this.tblDetail.ThemeStyle.AlternatingRowsStyle.Font = null;
            this.tblDetail.ThemeStyle.AlternatingRowsStyle.ForeColor = System.Drawing.Color.Empty;
            this.tblDetail.ThemeStyle.AlternatingRowsStyle.SelectionBackColor = System.Drawing.Color.Empty;
            this.tblDetail.ThemeStyle.AlternatingRowsStyle.SelectionForeColor = System.Drawing.Color.Empty;
            this.tblDetail.ThemeStyle.BackColor = System.Drawing.Color.White;
            this.tblDetail.ThemeStyle.GridColor = System.Drawing.Color.FromArgb(((int)(((byte)(239)))), ((int)(((byte)(241)))), ((int)(((byte)(243)))));
            this.tblDetail.ThemeStyle.HeaderStyle.BackColor = System.Drawing.Color.White;
            this.tblDetail.ThemeStyle.HeaderStyle.BorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.None;
            this.tblDetail.ThemeStyle.HeaderStyle.Font = new System.Drawing.Font("Segoe UI", 10.5F);
            this.tblDetail.ThemeStyle.HeaderStyle.ForeColor = System.Drawing.Color.Black;
            this.tblDetail.ThemeStyle.HeaderStyle.HeaightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.EnableResizing;
            this.tblDetail.ThemeStyle.HeaderStyle.Height = 40;
            this.tblDetail.ThemeStyle.ReadOnly = true;
            this.tblDetail.ThemeStyle.RowsStyle.BackColor = System.Drawing.Color.White;
            this.tblDetail.ThemeStyle.RowsStyle.BorderStyle = System.Windows.Forms.DataGridViewCellBorderStyle.SingleHorizontal;
            this.tblDetail.ThemeStyle.RowsStyle.Font = new System.Drawing.Font("Segoe UI", 10.5F);
            this.tblDetail.ThemeStyle.RowsStyle.ForeColor = System.Drawing.Color.Black;
            this.tblDetail.ThemeStyle.RowsStyle.Height = 30;
            this.tblDetail.ThemeStyle.RowsStyle.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(239)))), ((int)(((byte)(241)))), ((int)(((byte)(243)))));
            this.tblDetail.ThemeStyle.RowsStyle.SelectionForeColor = System.Drawing.Color.Black;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.BackColor = System.Drawing.Color.Transparent;
            this.label2.Font = new System.Drawing.Font("Segoe UI", 20.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.label2.Location = new System.Drawing.Point(1414, 202);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(468, 37);
            this.label2.TabIndex = 45;
            this.label2.Text = "TRẠNG THÁI ĐƠN HÀNG HIỆN TẠI:";
            // 
            // btnXacNhan
            // 
            this.btnXacNhan.BorderRadius = 30;
            this.btnXacNhan.DisabledState.BorderColor = System.Drawing.Color.DarkGray;
            this.btnXacNhan.DisabledState.CustomBorderColor = System.Drawing.Color.DarkGray;
            this.btnXacNhan.DisabledState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(169)))), ((int)(((byte)(169)))), ((int)(((byte)(169)))));
            this.btnXacNhan.DisabledState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(141)))), ((int)(((byte)(141)))), ((int)(((byte)(141)))));
            this.btnXacNhan.Enabled = false;
            this.btnXacNhan.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(192)))), ((int)(((byte)(0)))));
            this.btnXacNhan.Font = new System.Drawing.Font("Segoe UI", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnXacNhan.ForeColor = System.Drawing.Color.White;
            this.btnXacNhan.Location = new System.Drawing.Point(1421, 268);
            this.btnXacNhan.Name = "btnXacNhan";
            this.btnXacNhan.Size = new System.Drawing.Size(440, 66);
            this.btnXacNhan.TabIndex = 46;
            this.btnXacNhan.Text = "XÁC NHẬN ĐƠN HÀNG";
            this.btnXacNhan.Click += new System.EventHandler(this.btnXacNhan_Click);
            // 
            // btnLayHang
            // 
            this.btnLayHang.BorderRadius = 30;
            this.btnLayHang.DisabledState.BorderColor = System.Drawing.Color.DarkGray;
            this.btnLayHang.DisabledState.CustomBorderColor = System.Drawing.Color.DarkGray;
            this.btnLayHang.DisabledState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(169)))), ((int)(((byte)(169)))), ((int)(((byte)(169)))));
            this.btnLayHang.DisabledState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(141)))), ((int)(((byte)(141)))), ((int)(((byte)(141)))));
            this.btnLayHang.Enabled = false;
            this.btnLayHang.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(192)))), ((int)(((byte)(0)))));
            this.btnLayHang.Font = new System.Drawing.Font("Segoe UI", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnLayHang.ForeColor = System.Drawing.Color.White;
            this.btnLayHang.Location = new System.Drawing.Point(1421, 422);
            this.btnLayHang.Name = "btnLayHang";
            this.btnLayHang.Size = new System.Drawing.Size(440, 66);
            this.btnLayHang.TabIndex = 47;
            this.btnLayHang.Text = "LẤY HÀNG";
            this.btnLayHang.Click += new System.EventHandler(this.btnLayHang_Click);
            // 
            // btnHoanTat
            // 
            this.btnHoanTat.BorderRadius = 30;
            this.btnHoanTat.DisabledState.BorderColor = System.Drawing.Color.DarkGray;
            this.btnHoanTat.DisabledState.CustomBorderColor = System.Drawing.Color.DarkGray;
            this.btnHoanTat.DisabledState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(169)))), ((int)(((byte)(169)))), ((int)(((byte)(169)))));
            this.btnHoanTat.DisabledState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(141)))), ((int)(((byte)(141)))), ((int)(((byte)(141)))));
            this.btnHoanTat.Enabled = false;
            this.btnHoanTat.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(192)))));
            this.btnHoanTat.Font = new System.Drawing.Font("Segoe UI", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnHoanTat.ForeColor = System.Drawing.Color.White;
            this.btnHoanTat.Location = new System.Drawing.Point(1421, 889);
            this.btnHoanTat.Name = "btnHoanTat";
            this.btnHoanTat.Size = new System.Drawing.Size(440, 66);
            this.btnHoanTat.TabIndex = 49;
            this.btnHoanTat.Text = "ĐÃ GIAO";
            this.btnHoanTat.Click += new System.EventHandler(this.btnHoanTat_Click);
            // 
            // btnGiaoHang
            // 
            this.btnGiaoHang.BorderRadius = 30;
            this.btnGiaoHang.DisabledState.BorderColor = System.Drawing.Color.DarkGray;
            this.btnGiaoHang.DisabledState.CustomBorderColor = System.Drawing.Color.DarkGray;
            this.btnGiaoHang.DisabledState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(169)))), ((int)(((byte)(169)))), ((int)(((byte)(169)))));
            this.btnGiaoHang.DisabledState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(141)))), ((int)(((byte)(141)))), ((int)(((byte)(141)))));
            this.btnGiaoHang.Enabled = false;
            this.btnGiaoHang.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(192)))), ((int)(((byte)(192)))));
            this.btnGiaoHang.Font = new System.Drawing.Font("Segoe UI", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnGiaoHang.ForeColor = System.Drawing.Color.White;
            this.btnGiaoHang.Location = new System.Drawing.Point(1421, 580);
            this.btnGiaoHang.Name = "btnGiaoHang";
            this.btnGiaoHang.Size = new System.Drawing.Size(440, 66);
            this.btnGiaoHang.TabIndex = 48;
            this.btnGiaoHang.Text = "GIAO HÀNG";
            this.btnGiaoHang.Click += new System.EventHandler(this.btnGiaoHang_Click);
            // 
            // lblMaDonHang
            // 
            this.lblMaDonHang.AutoSize = true;
            this.lblMaDonHang.BackColor = System.Drawing.Color.Red;
            this.lblMaDonHang.Font = new System.Drawing.Font("Segoe UI", 20.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblMaDonHang.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            this.lblMaDonHang.Location = new System.Drawing.Point(396, 648);
            this.lblMaDonHang.Name = "lblMaDonHang";
            this.lblMaDonHang.Size = new System.Drawing.Size(0, 37);
            this.lblMaDonHang.TabIndex = 51;
            // 
            // pictureBox1
            // 
            this.pictureBox1.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.pictureBox1.Image = ((System.Drawing.Image)(resources.GetObject("pictureBox1.Image")));
            this.pictureBox1.Location = new System.Drawing.Point(1421, 340);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(440, 66);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.CenterImage;
            this.pictureBox1.TabIndex = 52;
            this.pictureBox1.TabStop = false;
            // 
            // pictureBox2
            // 
            this.pictureBox2.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.pictureBox2.Image = ((System.Drawing.Image)(resources.GetObject("pictureBox2.Image")));
            this.pictureBox2.Location = new System.Drawing.Point(1421, 494);
            this.pictureBox2.Name = "pictureBox2";
            this.pictureBox2.Size = new System.Drawing.Size(440, 66);
            this.pictureBox2.SizeMode = System.Windows.Forms.PictureBoxSizeMode.CenterImage;
            this.pictureBox2.TabIndex = 53;
            this.pictureBox2.TabStop = false;
            // 
            // pictureBox3
            // 
            this.pictureBox3.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.pictureBox3.Image = ((System.Drawing.Image)(resources.GetObject("pictureBox3.Image")));
            this.pictureBox3.Location = new System.Drawing.Point(1421, 652);
            this.pictureBox3.Name = "pictureBox3";
            this.pictureBox3.Size = new System.Drawing.Size(440, 66);
            this.pictureBox3.SizeMode = System.Windows.Forms.PictureBoxSizeMode.CenterImage;
            this.pictureBox3.TabIndex = 54;
            this.pictureBox3.TabStop = false;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.BackColor = System.Drawing.Color.Transparent;
            this.label3.Font = new System.Drawing.Font("Segoe UI", 20.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.label3.Location = new System.Drawing.Point(54, 146);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(453, 37);
            this.label3.TabIndex = 55;
            this.label3.Text = "LỌC DANH SÁCH ĐƠN ĐẶT HÀNG";
            // 
            // cboLoc
            // 
            this.cboLoc.BackColor = System.Drawing.Color.Transparent;
            this.cboLoc.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawFixed;
            this.cboLoc.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboLoc.FocusedColor = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(148)))), ((int)(((byte)(255)))));
            this.cboLoc.FocusedState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(148)))), ((int)(((byte)(255)))));
            this.cboLoc.Font = new System.Drawing.Font("Segoe UI", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cboLoc.ForeColor = System.Drawing.Color.Black;
            this.cboLoc.ItemHeight = 30;
            this.cboLoc.Items.AddRange(new object[] {
            "Tất Cả",
            "Đang Chờ Xử Lý",
            "Đã Xác Nhận Đơn Hàng",
            "Đang Lấy Hàng",
            "Đang Giao Hàng",
            "Giao Hàng Thành Công"});
            this.cboLoc.Location = new System.Drawing.Point(513, 146);
            this.cboLoc.Name = "cboLoc";
            this.cboLoc.Size = new System.Drawing.Size(369, 36);
            this.cboLoc.StartIndex = 0;
            this.cboLoc.TabIndex = 56;
            this.cboLoc.SelectedIndexChanged += new System.EventHandler(this.cboLoc_SelectedIndexChanged);
            // 
            // dateChon
            // 
            this.dateChon.Checked = true;
            this.dateChon.CustomFormat = "dd/MM/yyyy";
            this.dateChon.FillColor = System.Drawing.Color.White;
            this.dateChon.Font = new System.Drawing.Font("Segoe UI", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dateChon.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dateChon.Location = new System.Drawing.Point(900, 146);
            this.dateChon.MaxDate = new System.DateTime(9998, 12, 31, 0, 0, 0, 0);
            this.dateChon.MinDate = new System.DateTime(1753, 1, 1, 0, 0, 0, 0);
            this.dateChon.Name = "dateChon";
            this.dateChon.Size = new System.Drawing.Size(246, 36);
            this.dateChon.TabIndex = 57;
            this.dateChon.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.dateChon.Value = new System.DateTime(2023, 12, 18, 2, 21, 21, 859);
            this.dateChon.ValueChanged += new System.EventHandler(this.dateChon_ValueChanged);
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Font = new System.Drawing.Font("Segoe UI", 30F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label8.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.label8.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.label8.Location = new System.Drawing.Point(59, 57);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(763, 54);
            this.label8.TabIndex = 58;
            this.label8.Text = "QUẢN LÝ ĐƠN ĐẶT HÀNG TỪ WEBSITE";
            // 
            // label14
            // 
            this.label14.AutoSize = true;
            this.label14.Font = new System.Drawing.Font("Microsoft Sans Serif", 30F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label14.Location = new System.Drawing.Point(1863, 19);
            this.label14.Name = "label14";
            this.label14.Size = new System.Drawing.Size(41, 46);
            this.label14.TabIndex = 112;
            this.label14.Text = "x";
            this.label14.Click += new System.EventHandler(this.label14_Click);
            // 
            // pictureBox4
            // 
            this.pictureBox4.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.pictureBox4.Image = ((System.Drawing.Image)(resources.GetObject("pictureBox4.Image")));
            this.pictureBox4.Location = new System.Drawing.Point(1421, 806);
            this.pictureBox4.Name = "pictureBox4";
            this.pictureBox4.Size = new System.Drawing.Size(440, 66);
            this.pictureBox4.SizeMode = System.Windows.Forms.PictureBoxSizeMode.CenterImage;
            this.pictureBox4.TabIndex = 114;
            this.pictureBox4.TabStop = false;
            // 
            // btnInHoaDon
            // 
            this.btnInHoaDon.BorderRadius = 30;
            this.btnInHoaDon.DisabledState.BorderColor = System.Drawing.Color.DarkGray;
            this.btnInHoaDon.DisabledState.CustomBorderColor = System.Drawing.Color.DarkGray;
            this.btnInHoaDon.DisabledState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(169)))), ((int)(((byte)(169)))), ((int)(((byte)(169)))));
            this.btnInHoaDon.DisabledState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(141)))), ((int)(((byte)(141)))), ((int)(((byte)(141)))));
            this.btnInHoaDon.Enabled = false;
            this.btnInHoaDon.FillColor = System.Drawing.Color.Crimson;
            this.btnInHoaDon.Font = new System.Drawing.Font("Segoe UI", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnInHoaDon.ForeColor = System.Drawing.Color.White;
            this.btnInHoaDon.Location = new System.Drawing.Point(1421, 734);
            this.btnInHoaDon.Name = "btnInHoaDon";
            this.btnInHoaDon.Size = new System.Drawing.Size(440, 66);
            this.btnInHoaDon.TabIndex = 113;
            this.btnInHoaDon.Text = "IN HÓA ĐƠN";
            this.btnInHoaDon.Click += new System.EventHandler(this.btnInHoaDon_Click);
            // 
            // frmOrderOnline
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1924, 1061);
            this.Controls.Add(this.pictureBox4);
            this.Controls.Add(this.btnInHoaDon);
            this.Controls.Add(this.label14);
            this.Controls.Add(this.label8);
            this.Controls.Add(this.dateChon);
            this.Controls.Add(this.cboLoc);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.pictureBox3);
            this.Controls.Add(this.pictureBox2);
            this.Controls.Add(this.pictureBox1);
            this.Controls.Add(this.lblMaDonHang);
            this.Controls.Add(this.btnHoanTat);
            this.Controls.Add(this.btnGiaoHang);
            this.Controls.Add(this.btnLayHang);
            this.Controls.Add(this.btnXacNhan);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.tblDetail);
            this.Controls.Add(this.label16);
            this.Controls.Add(this.tbl);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "frmOrderOnline";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "frmOrderOnline";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            ((System.ComponentModel.ISupportInitialize)(this.tbl)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.tblDetail)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox3)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox4)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private Guna.UI2.WinForms.Guna2DataGridView tbl;
        private System.Windows.Forms.Label label16;
        private System.Windows.Forms.Label label1;
        private Guna.UI2.WinForms.Guna2DataGridView tblDetail;
        private System.Windows.Forms.Label label2;
        private Guna.UI2.WinForms.Guna2Button btnXacNhan;
        private Guna.UI2.WinForms.Guna2Button btnLayHang;
        private Guna.UI2.WinForms.Guna2Button btnHoanTat;
        private Guna.UI2.WinForms.Guna2Button btnGiaoHang;
        private System.Windows.Forms.Label lblMaDonHang;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.PictureBox pictureBox2;
        private System.Windows.Forms.PictureBox pictureBox3;
        private System.Windows.Forms.Label label3;
        private Guna.UI2.WinForms.Guna2ComboBox cboLoc;
        private Guna.UI2.WinForms.Guna2DateTimePicker dateChon;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Label label14;
        private System.Windows.Forms.PictureBox pictureBox4;
        private Guna.UI2.WinForms.Guna2Button btnInHoaDon;
    }
}