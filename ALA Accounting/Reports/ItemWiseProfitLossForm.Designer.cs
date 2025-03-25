namespace ALA_Accounting.Reports
{
    partial class ItemWiseProfitLossForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(ItemWiseProfitLossForm));
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle9 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle10 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle15 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle16 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle11 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle12 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle13 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle14 = new System.Windows.Forms.DataGridViewCellStyle();
            this.guna2ShadowPanel2 = new Guna.UI2.WinForms.Guna2ShadowPanel();
            this.label1 = new System.Windows.Forms.Label();
            this.chk_date = new System.Windows.Forms.CheckBox();
            this.guna2ShadowPanel1 = new Guna.UI2.WinForms.Guna2ShadowPanel();
            this.rdo_allInventory = new System.Windows.Forms.RadioButton();
            this.rdo_catagory = new System.Windows.Forms.RadioButton();
            this.cmbo_catagory = new System.Windows.Forms.ComboBox();
            this.chk_subCatagory = new System.Windows.Forms.CheckBox();
            this.cmbo_subCatagory = new System.Windows.Forms.ComboBox();
            this.chk_brandName = new System.Windows.Forms.CheckBox();
            this.cmbo_brandName = new System.Windows.Forms.ComboBox();
            this.btn_search = new Guna.UI2.WinForms.Guna2Button();
            this.to = new System.Windows.Forms.Label();
            this.dtmEnd = new System.Windows.Forms.DateTimePicker();
            this.dtmStart = new System.Windows.Forms.DateTimePicker();
            this.dataGridView2 = new System.Windows.Forms.DataGridView();
            this.ItemCode = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ItemName = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Quantity = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Unit = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.UnitCost = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.TotalCost = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.SalesValue = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ProfitLoss = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.txt_totalProfitLoss = new Guna.UI2.WinForms.Guna2TextBox();
            this.guna2GradientPanel1 = new Guna.UI2.WinForms.Guna2GradientPanel();
            this.txt_totalSalesValue = new Guna.UI2.WinForms.Guna2TextBox();
            this.txt_totalCost = new Guna.UI2.WinForms.Guna2TextBox();
            this.guna2ShadowPanel2.SuspendLayout();
            this.guna2ShadowPanel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView2)).BeginInit();
            this.guna2GradientPanel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // guna2ShadowPanel2
            // 
            this.guna2ShadowPanel2.BackColor = System.Drawing.Color.Transparent;
            this.guna2ShadowPanel2.Controls.Add(this.label1);
            this.guna2ShadowPanel2.FillColor = System.Drawing.Color.White;
            this.guna2ShadowPanel2.Location = new System.Drawing.Point(12, 12);
            this.guna2ShadowPanel2.Name = "guna2ShadowPanel2";
            this.guna2ShadowPanel2.Radius = 2;
            this.guna2ShadowPanel2.ShadowColor = System.Drawing.Color.Chartreuse;
            this.guna2ShadowPanel2.ShadowDepth = 95;
            this.guna2ShadowPanel2.ShadowShift = 8;
            this.guna2ShadowPanel2.Size = new System.Drawing.Size(215, 59);
            this.guna2ShadowPanel2.TabIndex = 60;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Arial", 20.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.Color.ForestGreen;
            this.label1.Location = new System.Drawing.Point(7, 14);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(201, 32);
            this.label1.TabIndex = 1;
            this.label1.Text = "آئٹم وار منافع نقصان";
            // 
            // chk_date
            // 
            this.chk_date.AutoSize = true;
            this.chk_date.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.chk_date.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.chk_date.Location = new System.Drawing.Point(291, 136);
            this.chk_date.Name = "chk_date";
            this.chk_date.Size = new System.Drawing.Size(56, 23);
            this.chk_date.TabIndex = 58;
            this.chk_date.Text = "تاریخ";
            this.chk_date.UseVisualStyleBackColor = true;
            this.chk_date.CheckedChanged += new System.EventHandler(this.chk_date_CheckedChanged);
            // 
            // guna2ShadowPanel1
            // 
            this.guna2ShadowPanel1.BackColor = System.Drawing.Color.Transparent;
            this.guna2ShadowPanel1.Controls.Add(this.rdo_allInventory);
            this.guna2ShadowPanel1.Controls.Add(this.rdo_catagory);
            this.guna2ShadowPanel1.Controls.Add(this.cmbo_catagory);
            this.guna2ShadowPanel1.Controls.Add(this.chk_subCatagory);
            this.guna2ShadowPanel1.Controls.Add(this.cmbo_subCatagory);
            this.guna2ShadowPanel1.Controls.Add(this.guna2ShadowPanel2);
            this.guna2ShadowPanel1.Controls.Add(this.chk_date);
            this.guna2ShadowPanel1.Controls.Add(this.chk_brandName);
            this.guna2ShadowPanel1.Controls.Add(this.cmbo_brandName);
            this.guna2ShadowPanel1.Controls.Add(this.btn_search);
            this.guna2ShadowPanel1.Controls.Add(this.to);
            this.guna2ShadowPanel1.Controls.Add(this.dtmEnd);
            this.guna2ShadowPanel1.Controls.Add(this.dtmStart);
            this.guna2ShadowPanel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.guna2ShadowPanel1.FillColor = System.Drawing.Color.White;
            this.guna2ShadowPanel1.Location = new System.Drawing.Point(0, 0);
            this.guna2ShadowPanel1.Name = "guna2ShadowPanel1";
            this.guna2ShadowPanel1.ShadowColor = System.Drawing.Color.Black;
            this.guna2ShadowPanel1.Size = new System.Drawing.Size(1080, 172);
            this.guna2ShadowPanel1.TabIndex = 109;
            // 
            // rdo_allInventory
            // 
            this.rdo_allInventory.AutoSize = true;
            this.rdo_allInventory.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Bold);
            this.rdo_allInventory.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.rdo_allInventory.Location = new System.Drawing.Point(291, 12);
            this.rdo_allInventory.Name = "rdo_allInventory";
            this.rdo_allInventory.Size = new System.Drawing.Size(96, 23);
            this.rdo_allInventory.TabIndex = 65;
            this.rdo_allInventory.TabStop = true;
            this.rdo_allInventory.Text = "تمام انوینٹری";
            this.rdo_allInventory.UseVisualStyleBackColor = true;
            this.rdo_allInventory.CheckedChanged += new System.EventHandler(this.rdo_allInventory_CheckedChanged);
            // 
            // rdo_catagory
            // 
            this.rdo_catagory.AutoSize = true;
            this.rdo_catagory.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Bold);
            this.rdo_catagory.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.rdo_catagory.Location = new System.Drawing.Point(256, 40);
            this.rdo_catagory.Name = "rdo_catagory";
            this.rdo_catagory.Size = new System.Drawing.Size(138, 23);
            this.rdo_catagory.TabIndex = 64;
            this.rdo_catagory.TabStop = true;
            this.rdo_catagory.Text = "کیٹیگری منتخب کریں";
            this.rdo_catagory.UseVisualStyleBackColor = true;
            this.rdo_catagory.CheckedChanged += new System.EventHandler(this.rdo_catagory_CheckedChanged);
            // 
            // cmbo_catagory
            // 
            this.cmbo_catagory.BackColor = System.Drawing.Color.Lime;
            this.cmbo_catagory.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbo_catagory.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Bold);
            this.cmbo_catagory.FormattingEnabled = true;
            this.cmbo_catagory.Location = new System.Drawing.Point(400, 39);
            this.cmbo_catagory.Name = "cmbo_catagory";
            this.cmbo_catagory.Size = new System.Drawing.Size(379, 27);
            this.cmbo_catagory.TabIndex = 63;
            this.cmbo_catagory.SelectedIndexChanged += new System.EventHandler(this.cmbo_catagory_SelectedIndexChanged);
            // 
            // chk_subCatagory
            // 
            this.chk_subCatagory.AutoSize = true;
            this.chk_subCatagory.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.chk_subCatagory.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.chk_subCatagory.Location = new System.Drawing.Point(291, 74);
            this.chk_subCatagory.Name = "chk_subCatagory";
            this.chk_subCatagory.Size = new System.Drawing.Size(94, 23);
            this.chk_subCatagory.TabIndex = 62;
            this.chk_subCatagory.Text = "ذیلی کیٹگری";
            this.chk_subCatagory.UseVisualStyleBackColor = true;
            this.chk_subCatagory.CheckedChanged += new System.EventHandler(this.chk_subCatagory_CheckedChanged);
            // 
            // cmbo_subCatagory
            // 
            this.cmbo_subCatagory.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbo_subCatagory.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Bold);
            this.cmbo_subCatagory.FormattingEnabled = true;
            this.cmbo_subCatagory.Location = new System.Drawing.Point(400, 72);
            this.cmbo_subCatagory.Name = "cmbo_subCatagory";
            this.cmbo_subCatagory.Size = new System.Drawing.Size(379, 27);
            this.cmbo_subCatagory.TabIndex = 61;
            // 
            // chk_brandName
            // 
            this.chk_brandName.AutoSize = true;
            this.chk_brandName.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.chk_brandName.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.chk_brandName.Location = new System.Drawing.Point(291, 107);
            this.chk_brandName.Name = "chk_brandName";
            this.chk_brandName.Size = new System.Drawing.Size(84, 23);
            this.chk_brandName.TabIndex = 55;
            this.chk_brandName.Text = "برانڈ کا نام";
            this.chk_brandName.UseVisualStyleBackColor = true;
            this.chk_brandName.CheckedChanged += new System.EventHandler(this.chk_brandName_CheckedChanged);
            // 
            // cmbo_brandName
            // 
            this.cmbo_brandName.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbo_brandName.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Bold);
            this.cmbo_brandName.FormattingEnabled = true;
            this.cmbo_brandName.Location = new System.Drawing.Point(401, 105);
            this.cmbo_brandName.Name = "cmbo_brandName";
            this.cmbo_brandName.Size = new System.Drawing.Size(379, 27);
            this.cmbo_brandName.TabIndex = 53;
            // 
            // btn_search
            // 
            this.btn_search.BorderColor = System.Drawing.Color.GreenYellow;
            this.btn_search.BorderRadius = 4;
            this.btn_search.BorderThickness = 2;
            this.btn_search.DisabledState.BorderColor = System.Drawing.Color.DarkGray;
            this.btn_search.DisabledState.CustomBorderColor = System.Drawing.Color.DarkGray;
            this.btn_search.DisabledState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(169)))), ((int)(((byte)(169)))), ((int)(((byte)(169)))));
            this.btn_search.DisabledState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(141)))), ((int)(((byte)(141)))), ((int)(((byte)(141)))));
            this.btn_search.FillColor = System.Drawing.Color.LawnGreen;
            this.btn_search.Font = new System.Drawing.Font("Segoe UI Semibold", 12F, System.Drawing.FontStyle.Bold);
            this.btn_search.ForeColor = System.Drawing.Color.White;
            this.btn_search.Image = ((System.Drawing.Image)(resources.GetObject("btn_search.Image")));
            this.btn_search.ImageOffset = new System.Drawing.Point(12, -10);
            this.btn_search.ImageSize = new System.Drawing.Size(38, 38);
            this.btn_search.Location = new System.Drawing.Point(797, 39);
            this.btn_search.Name = "btn_search";
            this.btn_search.Size = new System.Drawing.Size(86, 58);
            this.btn_search.TabIndex = 52;
            this.btn_search.Text = "Search";
            this.btn_search.TextOffset = new System.Drawing.Point(-10, 15);
            this.btn_search.Click += new System.EventHandler(this.btn_search_Click);
            // 
            // to
            // 
            this.to.AutoSize = true;
            this.to.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.to.Location = new System.Drawing.Point(509, 141);
            this.to.Name = "to";
            this.to.Size = new System.Drawing.Size(24, 16);
            this.to.TabIndex = 51;
            this.to.Text = "To";
            // 
            // dtmEnd
            // 
            this.dtmEnd.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dtmEnd.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dtmEnd.Location = new System.Drawing.Point(539, 138);
            this.dtmEnd.Name = "dtmEnd";
            this.dtmEnd.Size = new System.Drawing.Size(102, 22);
            this.dtmEnd.TabIndex = 17;
            this.dtmEnd.Value = new System.DateTime(2025, 3, 21, 0, 0, 0, 0);
            // 
            // dtmStart
            // 
            this.dtmStart.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dtmStart.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dtmStart.Location = new System.Drawing.Point(401, 138);
            this.dtmStart.Name = "dtmStart";
            this.dtmStart.Size = new System.Drawing.Size(102, 22);
            this.dtmStart.TabIndex = 16;
            this.dtmStart.Value = new System.DateTime(2025, 3, 21, 0, 0, 0, 0);
            // 
            // dataGridView2
            // 
            dataGridViewCellStyle9.BackColor = System.Drawing.Color.LightGreen;
            dataGridViewCellStyle9.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle9.ForeColor = System.Drawing.Color.Black;
            dataGridViewCellStyle9.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle9.SelectionForeColor = System.Drawing.Color.White;
            this.dataGridView2.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle9;
            this.dataGridView2.BackgroundColor = System.Drawing.Color.White;
            this.dataGridView2.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.dataGridView2.CellBorderStyle = System.Windows.Forms.DataGridViewCellBorderStyle.SingleVertical;
            this.dataGridView2.ColumnHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.Single;
            dataGridViewCellStyle10.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle10.BackColor = System.Drawing.SystemColors.ControlLight;
            dataGridViewCellStyle10.Font = new System.Drawing.Font("Arial", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle10.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle10.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle10.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle10.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dataGridView2.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle10;
            this.dataGridView2.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView2.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.ItemCode,
            this.ItemName,
            this.Quantity,
            this.Unit,
            this.UnitCost,
            this.TotalCost,
            this.SalesValue,
            this.ProfitLoss});
            dataGridViewCellStyle15.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle15.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle15.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle15.ForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle15.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle15.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle15.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.dataGridView2.DefaultCellStyle = dataGridViewCellStyle15;
            this.dataGridView2.Location = new System.Drawing.Point(0, 191);
            this.dataGridView2.MultiSelect = false;
            this.dataGridView2.Name = "dataGridView2";
            this.dataGridView2.ReadOnly = true;
            dataGridViewCellStyle16.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle16.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle16.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle16.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle16.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle16.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle16.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dataGridView2.RowHeadersDefaultCellStyle = dataGridViewCellStyle16;
            this.dataGridView2.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dataGridView2.Size = new System.Drawing.Size(1080, 383);
            this.dataGridView2.TabIndex = 110;
            // 
            // ItemCode
            // 
            this.ItemCode.DataPropertyName = "Item Code";
            this.ItemCode.HeaderText = "آئٹم کوڈ";
            this.ItemCode.Name = "ItemCode";
            this.ItemCode.ReadOnly = true;
            this.ItemCode.Width = 90;
            // 
            // ItemName
            // 
            this.ItemName.DataPropertyName = "Item Name";
            this.ItemName.HeaderText = "آئٹم کا نام";
            this.ItemName.Name = "ItemName";
            this.ItemName.ReadOnly = true;
            this.ItemName.Width = 285;
            // 
            // Quantity
            // 
            this.Quantity.DataPropertyName = "Quantity";
            this.Quantity.HeaderText = "مقدار";
            this.Quantity.Name = "Quantity";
            this.Quantity.ReadOnly = true;
            // 
            // Unit
            // 
            this.Unit.DataPropertyName = "Unit";
            this.Unit.HeaderText = "یونٹ";
            this.Unit.Name = "Unit";
            this.Unit.ReadOnly = true;
            this.Unit.Width = 80;
            // 
            // UnitCost
            // 
            this.UnitCost.DataPropertyName = "UnitCost";
            dataGridViewCellStyle11.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight;
            dataGridViewCellStyle11.Format = "N2";
            dataGridViewCellStyle11.NullValue = null;
            this.UnitCost.DefaultCellStyle = dataGridViewCellStyle11;
            this.UnitCost.HeaderText = "یونٹ لاگت";
            this.UnitCost.Name = "UnitCost";
            this.UnitCost.ReadOnly = true;
            this.UnitCost.Width = 115;
            // 
            // TotalCost
            // 
            this.TotalCost.DataPropertyName = "Total Cost";
            dataGridViewCellStyle12.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight;
            dataGridViewCellStyle12.Format = "N2";
            dataGridViewCellStyle12.NullValue = null;
            this.TotalCost.DefaultCellStyle = dataGridViewCellStyle12;
            this.TotalCost.HeaderText = "کل لاگت";
            this.TotalCost.Name = "TotalCost";
            this.TotalCost.ReadOnly = true;
            this.TotalCost.Width = 115;
            // 
            // SalesValue
            // 
            this.SalesValue.DataPropertyName = "Sales Value";
            dataGridViewCellStyle13.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight;
            dataGridViewCellStyle13.Format = "N2";
            dataGridViewCellStyle13.NullValue = null;
            this.SalesValue.DefaultCellStyle = dataGridViewCellStyle13;
            this.SalesValue.HeaderText = "فروخت قیمت";
            this.SalesValue.Name = "SalesValue";
            this.SalesValue.ReadOnly = true;
            this.SalesValue.Width = 115;
            // 
            // ProfitLoss
            // 
            this.ProfitLoss.DataPropertyName = "Profit / (Loss)";
            dataGridViewCellStyle14.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight;
            dataGridViewCellStyle14.Format = "N2";
            dataGridViewCellStyle14.NullValue = null;
            this.ProfitLoss.DefaultCellStyle = dataGridViewCellStyle14;
            this.ProfitLoss.HeaderText = "نفع/نقصان";
            this.ProfitLoss.Name = "ProfitLoss";
            this.ProfitLoss.ReadOnly = true;
            this.ProfitLoss.Width = 115;
            // 
            // txt_totalProfitLoss
            // 
            this.txt_totalProfitLoss.BackColor = System.Drawing.Color.Transparent;
            this.txt_totalProfitLoss.BorderColor = System.Drawing.Color.Gray;
            this.txt_totalProfitLoss.BorderRadius = 6;
            this.txt_totalProfitLoss.BorderThickness = 2;
            this.txt_totalProfitLoss.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.txt_totalProfitLoss.DefaultText = "";
            this.txt_totalProfitLoss.DisabledState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(208)))), ((int)(((byte)(208)))), ((int)(((byte)(208)))));
            this.txt_totalProfitLoss.DisabledState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(226)))), ((int)(((byte)(226)))), ((int)(((byte)(226)))));
            this.txt_totalProfitLoss.DisabledState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(138)))), ((int)(((byte)(138)))), ((int)(((byte)(138)))));
            this.txt_totalProfitLoss.DisabledState.PlaceholderForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(138)))), ((int)(((byte)(138)))), ((int)(((byte)(138)))));
            this.txt_totalProfitLoss.FillColor = System.Drawing.Color.WhiteSmoke;
            this.txt_totalProfitLoss.FocusedState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(148)))), ((int)(((byte)(255)))));
            this.txt_totalProfitLoss.Font = new System.Drawing.Font("Arial Narrow", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txt_totalProfitLoss.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.txt_totalProfitLoss.HoverState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(148)))), ((int)(((byte)(255)))));
            this.txt_totalProfitLoss.Location = new System.Drawing.Point(943, 4);
            this.txt_totalProfitLoss.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.txt_totalProfitLoss.Name = "txt_totalProfitLoss";
            this.txt_totalProfitLoss.PasswordChar = '\0';
            this.txt_totalProfitLoss.PlaceholderText = "";
            this.txt_totalProfitLoss.ReadOnly = true;
            this.txt_totalProfitLoss.SelectedText = "";
            this.txt_totalProfitLoss.ShadowDecoration.Color = System.Drawing.Color.Silver;
            this.txt_totalProfitLoss.Size = new System.Drawing.Size(115, 31);
            this.txt_totalProfitLoss.TabIndex = 9;
            this.txt_totalProfitLoss.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // guna2GradientPanel1
            // 
            this.guna2GradientPanel1.Controls.Add(this.txt_totalSalesValue);
            this.guna2GradientPanel1.Controls.Add(this.txt_totalCost);
            this.guna2GradientPanel1.Controls.Add(this.txt_totalProfitLoss);
            this.guna2GradientPanel1.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.guna2GradientPanel1.FillColor = System.Drawing.Color.White;
            this.guna2GradientPanel1.FillColor2 = System.Drawing.Color.LightGray;
            this.guna2GradientPanel1.GradientMode = System.Drawing.Drawing2D.LinearGradientMode.Vertical;
            this.guna2GradientPanel1.Location = new System.Drawing.Point(0, 577);
            this.guna2GradientPanel1.Name = "guna2GradientPanel1";
            this.guna2GradientPanel1.Size = new System.Drawing.Size(1080, 40);
            this.guna2GradientPanel1.TabIndex = 111;
            // 
            // txt_totalSalesValue
            // 
            this.txt_totalSalesValue.BackColor = System.Drawing.Color.Transparent;
            this.txt_totalSalesValue.BorderColor = System.Drawing.Color.Gray;
            this.txt_totalSalesValue.BorderRadius = 6;
            this.txt_totalSalesValue.BorderThickness = 2;
            this.txt_totalSalesValue.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.txt_totalSalesValue.DefaultText = "";
            this.txt_totalSalesValue.DisabledState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(208)))), ((int)(((byte)(208)))), ((int)(((byte)(208)))));
            this.txt_totalSalesValue.DisabledState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(226)))), ((int)(((byte)(226)))), ((int)(((byte)(226)))));
            this.txt_totalSalesValue.DisabledState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(138)))), ((int)(((byte)(138)))), ((int)(((byte)(138)))));
            this.txt_totalSalesValue.DisabledState.PlaceholderForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(138)))), ((int)(((byte)(138)))), ((int)(((byte)(138)))));
            this.txt_totalSalesValue.FillColor = System.Drawing.Color.WhiteSmoke;
            this.txt_totalSalesValue.FocusedState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(148)))), ((int)(((byte)(255)))));
            this.txt_totalSalesValue.Font = new System.Drawing.Font("Arial Narrow", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txt_totalSalesValue.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.txt_totalSalesValue.HoverState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(148)))), ((int)(((byte)(255)))));
            this.txt_totalSalesValue.Location = new System.Drawing.Point(827, 5);
            this.txt_totalSalesValue.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.txt_totalSalesValue.Name = "txt_totalSalesValue";
            this.txt_totalSalesValue.PasswordChar = '\0';
            this.txt_totalSalesValue.PlaceholderText = "";
            this.txt_totalSalesValue.ReadOnly = true;
            this.txt_totalSalesValue.SelectedText = "";
            this.txt_totalSalesValue.ShadowDecoration.Color = System.Drawing.Color.Silver;
            this.txt_totalSalesValue.Size = new System.Drawing.Size(113, 31);
            this.txt_totalSalesValue.TabIndex = 11;
            this.txt_totalSalesValue.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // txt_totalCost
            // 
            this.txt_totalCost.BackColor = System.Drawing.Color.Transparent;
            this.txt_totalCost.BorderColor = System.Drawing.Color.Gray;
            this.txt_totalCost.BorderRadius = 6;
            this.txt_totalCost.BorderThickness = 2;
            this.txt_totalCost.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.txt_totalCost.DefaultText = "";
            this.txt_totalCost.DisabledState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(208)))), ((int)(((byte)(208)))), ((int)(((byte)(208)))));
            this.txt_totalCost.DisabledState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(226)))), ((int)(((byte)(226)))), ((int)(((byte)(226)))));
            this.txt_totalCost.DisabledState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(138)))), ((int)(((byte)(138)))), ((int)(((byte)(138)))));
            this.txt_totalCost.DisabledState.PlaceholderForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(138)))), ((int)(((byte)(138)))), ((int)(((byte)(138)))));
            this.txt_totalCost.FillColor = System.Drawing.Color.WhiteSmoke;
            this.txt_totalCost.FocusedState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(148)))), ((int)(((byte)(255)))));
            this.txt_totalCost.Font = new System.Drawing.Font("Arial Narrow", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txt_totalCost.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.txt_totalCost.HoverState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(148)))), ((int)(((byte)(255)))));
            this.txt_totalCost.Location = new System.Drawing.Point(711, 5);
            this.txt_totalCost.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.txt_totalCost.Name = "txt_totalCost";
            this.txt_totalCost.PasswordChar = '\0';
            this.txt_totalCost.PlaceholderText = "";
            this.txt_totalCost.ReadOnly = true;
            this.txt_totalCost.SelectedText = "";
            this.txt_totalCost.ShadowDecoration.Color = System.Drawing.Color.Silver;
            this.txt_totalCost.Size = new System.Drawing.Size(113, 31);
            this.txt_totalCost.TabIndex = 10;
            this.txt_totalCost.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // ItemWiseProfitLossForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1080, 617);
            this.Controls.Add(this.guna2ShadowPanel1);
            this.Controls.Add(this.dataGridView2);
            this.Controls.Add(this.guna2GradientPanel1);
            this.Name = "ItemWiseProfitLossForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.Manual;
            this.Text = "ItemWiseProfitLossForm";
            this.Load += new System.EventHandler(this.ItemWiseProfitLossForm_Load);
            this.guna2ShadowPanel2.ResumeLayout(false);
            this.guna2ShadowPanel2.PerformLayout();
            this.guna2ShadowPanel1.ResumeLayout(false);
            this.guna2ShadowPanel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView2)).EndInit();
            this.guna2GradientPanel1.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion
        private Guna.UI2.WinForms.Guna2ShadowPanel guna2ShadowPanel2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.CheckBox chk_date;
        private Guna.UI2.WinForms.Guna2ShadowPanel guna2ShadowPanel1;
        private System.Windows.Forms.CheckBox chk_brandName;
        private System.Windows.Forms.ComboBox cmbo_brandName;
        private Guna.UI2.WinForms.Guna2Button btn_search;
        private System.Windows.Forms.Label to;
        private System.Windows.Forms.DateTimePicker dtmEnd;
        private System.Windows.Forms.DateTimePicker dtmStart;
        private System.Windows.Forms.DataGridView dataGridView2;
        private Guna.UI2.WinForms.Guna2TextBox txt_totalProfitLoss;
        private Guna.UI2.WinForms.Guna2GradientPanel guna2GradientPanel1;
        private Guna.UI2.WinForms.Guna2TextBox txt_totalCost;
        private System.Windows.Forms.RadioButton rdo_allInventory;
        private System.Windows.Forms.RadioButton rdo_catagory;
        private System.Windows.Forms.ComboBox cmbo_catagory;
        private System.Windows.Forms.CheckBox chk_subCatagory;
        private System.Windows.Forms.ComboBox cmbo_subCatagory;
        private System.Windows.Forms.DataGridViewTextBoxColumn ItemCode;
        private System.Windows.Forms.DataGridViewTextBoxColumn ItemName;
        private System.Windows.Forms.DataGridViewTextBoxColumn Quantity;
        private System.Windows.Forms.DataGridViewTextBoxColumn Unit;
        private System.Windows.Forms.DataGridViewTextBoxColumn UnitCost;
        private System.Windows.Forms.DataGridViewTextBoxColumn TotalCost;
        private System.Windows.Forms.DataGridViewTextBoxColumn SalesValue;
        private System.Windows.Forms.DataGridViewTextBoxColumn ProfitLoss;
        private Guna.UI2.WinForms.Guna2TextBox txt_totalSalesValue;
    }
}