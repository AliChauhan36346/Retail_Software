namespace ALA_Accounting.Reports
{
    partial class PurchaseSummaryReport
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
            this.components = new System.ComponentModel.Container();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle3 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle4 = new System.Windows.Forms.DataGridViewCellStyle();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(PurchaseSummaryReport));
            this.purchaseSummaryBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.guna2ShadowPanel2 = new Guna.UI2.WinForms.Guna2ShadowPanel();
            this.label1 = new System.Windows.Forms.Label();
            this.chk_date = new System.Windows.Forms.CheckBox();
            this.chk_employee = new System.Windows.Forms.CheckBox();
            this.dataGridView2 = new System.Windows.Forms.DataGridView();
            this.PurchaseInvoiceID = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.InvoiceDate = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.AccountName = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.employeeReference = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.GrossTotal = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.AdditionalDiscount = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.CarriageAndFreight = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.NetTotal = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.chk_customer = new System.Windows.Forms.CheckBox();
            this.chk_vendorType = new System.Windows.Forms.CheckBox();
            this.cmbo_employee = new System.Windows.Forms.ComboBox();
            this.cmbo_vendorType = new System.Windows.Forms.ComboBox();
            this.txt_totalNet = new Guna.UI2.WinForms.Guna2TextBox();
            this.guna2GradientPanel1 = new Guna.UI2.WinForms.Guna2GradientPanel();
            this.txt_totalGross = new Guna.UI2.WinForms.Guna2TextBox();
            this.to = new System.Windows.Forms.Label();
            this.dtmEnd = new System.Windows.Forms.DateTimePicker();
            this.dtmStart = new System.Windows.Forms.DateTimePicker();
            this.txt_accountName = new Guna.UI2.WinForms.Guna2TextBox();
            this.txt_accountId = new Guna.UI2.WinForms.Guna2TextBox();
            this.guna2ShadowPanel1 = new Guna.UI2.WinForms.Guna2ShadowPanel();
            this.btn_search = new Guna.UI2.WinForms.Guna2Button();
            ((System.ComponentModel.ISupportInitialize)(this.purchaseSummaryBindingSource)).BeginInit();
            this.guna2ShadowPanel2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView2)).BeginInit();
            this.guna2GradientPanel1.SuspendLayout();
            this.guna2ShadowPanel1.SuspendLayout();
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
            this.guna2ShadowPanel2.ShadowColor = System.Drawing.Color.Red;
            this.guna2ShadowPanel2.ShadowDepth = 95;
            this.guna2ShadowPanel2.ShadowShift = 8;
            this.guna2ShadowPanel2.Size = new System.Drawing.Size(161, 55);
            this.guna2ShadowPanel2.TabIndex = 60;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Arial", 24F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.Color.Green;
            this.label1.Location = new System.Drawing.Point(9, 10);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(149, 37);
            this.label1.TabIndex = 1;
            this.label1.Text = "خرید رپورٹ";
            // 
            // chk_date
            // 
            this.chk_date.AutoSize = true;
            this.chk_date.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.chk_date.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.chk_date.Location = new System.Drawing.Point(230, 116);
            this.chk_date.Name = "chk_date";
            this.chk_date.Size = new System.Drawing.Size(56, 23);
            this.chk_date.TabIndex = 58;
            this.chk_date.Text = "تاریخ";
            this.chk_date.UseVisualStyleBackColor = true;
            this.chk_date.CheckedChanged += new System.EventHandler(this.chk_date_CheckedChanged);
            // 
            // chk_employee
            // 
            this.chk_employee.AutoSize = true;
            this.chk_employee.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.chk_employee.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.chk_employee.Location = new System.Drawing.Point(230, 91);
            this.chk_employee.Name = "chk_employee";
            this.chk_employee.Size = new System.Drawing.Size(57, 23);
            this.chk_employee.TabIndex = 57;
            this.chk_employee.Text = "ملازم";
            this.chk_employee.UseVisualStyleBackColor = true;
            this.chk_employee.CheckedChanged += new System.EventHandler(this.chk_employee_CheckedChanged);
            // 
            // dataGridView2
            // 
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle1.BackColor = System.Drawing.Color.LightCoral;
            dataGridViewCellStyle1.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle1.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle1.SelectionForeColor = System.Drawing.Color.White;
            this.dataGridView2.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle1;
            this.dataGridView2.BackgroundColor = System.Drawing.Color.White;
            this.dataGridView2.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.dataGridView2.CellBorderStyle = System.Windows.Forms.DataGridViewCellBorderStyle.SingleVertical;
            this.dataGridView2.ColumnHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.Single;
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle2.BackColor = System.Drawing.SystemColors.ControlLight;
            dataGridViewCellStyle2.Font = new System.Drawing.Font("Arial", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle2.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle2.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle2.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dataGridView2.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle2;
            this.dataGridView2.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView2.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.PurchaseInvoiceID,
            this.InvoiceDate,
            this.AccountName,
            this.employeeReference,
            this.GrossTotal,
            this.AdditionalDiscount,
            this.CarriageAndFreight,
            this.NetTotal});
            dataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle3.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle3.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle3.ForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle3.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle3.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle3.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.dataGridView2.DefaultCellStyle = dataGridViewCellStyle3;
            this.dataGridView2.Location = new System.Drawing.Point(0, 161);
            this.dataGridView2.MultiSelect = false;
            this.dataGridView2.Name = "dataGridView2";
            this.dataGridView2.ReadOnly = true;
            dataGridViewCellStyle4.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle4.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle4.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle4.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle4.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle4.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle4.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dataGridView2.RowHeadersDefaultCellStyle = dataGridViewCellStyle4;
            this.dataGridView2.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dataGridView2.Size = new System.Drawing.Size(1080, 413);
            this.dataGridView2.TabIndex = 110;
            this.dataGridView2.CellDoubleClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dataGridView2_CellDoubleClick);
            // 
            // PurchaseInvoiceID
            // 
            this.PurchaseInvoiceID.DataPropertyName = "PurchaseInvoiceID";
            this.PurchaseInvoiceID.HeaderText = "انوائس نمبر";
            this.PurchaseInvoiceID.Name = "PurchaseInvoiceID";
            this.PurchaseInvoiceID.ReadOnly = true;
            this.PurchaseInvoiceID.Width = 108;
            // 
            // InvoiceDate
            // 
            this.InvoiceDate.DataPropertyName = "InvoiceDate";
            this.InvoiceDate.HeaderText = "تاریخ";
            this.InvoiceDate.Name = "InvoiceDate";
            this.InvoiceDate.ReadOnly = true;
            this.InvoiceDate.Width = 90;
            // 
            // AccountName
            // 
            this.AccountName.DataPropertyName = "AccountName";
            this.AccountName.HeaderText = "فروش کا نام";
            this.AccountName.Name = "AccountName";
            this.AccountName.ReadOnly = true;
            this.AccountName.Width = 261;
            // 
            // employeeReference
            // 
            this.employeeReference.DataPropertyName = "employeeReference";
            this.employeeReference.HeaderText = "ملازم";
            this.employeeReference.Name = "employeeReference";
            this.employeeReference.ReadOnly = true;
            this.employeeReference.Width = 135;
            // 
            // GrossTotal
            // 
            this.GrossTotal.DataPropertyName = "GrossTotal";
            this.GrossTotal.HeaderText = "گروس ٹوٹل";
            this.GrossTotal.Name = "GrossTotal";
            this.GrossTotal.ReadOnly = true;
            this.GrossTotal.Width = 110;
            // 
            // AdditionalDiscount
            // 
            this.AdditionalDiscount.DataPropertyName = "AdditionalDiscount";
            this.AdditionalDiscount.HeaderText = "رعایت";
            this.AdditionalDiscount.Name = "AdditionalDiscount";
            this.AdditionalDiscount.ReadOnly = true;
            // 
            // CarriageAndFreight
            // 
            this.CarriageAndFreight.DataPropertyName = "CarriageAndFreight";
            this.CarriageAndFreight.HeaderText = "کرایہ";
            this.CarriageAndFreight.Name = "CarriageAndFreight";
            this.CarriageAndFreight.ReadOnly = true;
            this.CarriageAndFreight.Width = 105;
            // 
            // NetTotal
            // 
            this.NetTotal.DataPropertyName = "NetTotal";
            this.NetTotal.HeaderText = "نیٹ ٹوٹل";
            this.NetTotal.Name = "NetTotal";
            this.NetTotal.ReadOnly = true;
            this.NetTotal.Width = 110;
            // 
            // chk_customer
            // 
            this.chk_customer.AutoSize = true;
            this.chk_customer.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.chk_customer.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.chk_customer.Location = new System.Drawing.Point(230, 62);
            this.chk_customer.Name = "chk_customer";
            this.chk_customer.Size = new System.Drawing.Size(62, 23);
            this.chk_customer.TabIndex = 56;
            this.chk_customer.Text = "سپلائر";
            this.chk_customer.UseVisualStyleBackColor = true;
            this.chk_customer.CheckedChanged += new System.EventHandler(this.chk_customer_CheckedChanged);
            // 
            // chk_vendorType
            // 
            this.chk_vendorType.AutoSize = true;
            this.chk_vendorType.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.chk_vendorType.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.chk_vendorType.Location = new System.Drawing.Point(230, 28);
            this.chk_vendorType.Name = "chk_vendorType";
            this.chk_vendorType.Size = new System.Drawing.Size(106, 23);
            this.chk_vendorType.TabIndex = 55;
            this.chk_vendorType.Text = "سپلائر کی قسم";
            this.chk_vendorType.UseVisualStyleBackColor = true;
            this.chk_vendorType.CheckedChanged += new System.EventHandler(this.chk_customerType_CheckedChanged);
            // 
            // cmbo_employee
            // 
            this.cmbo_employee.FormattingEnabled = true;
            this.cmbo_employee.Location = new System.Drawing.Point(339, 90);
            this.cmbo_employee.Name = "cmbo_employee";
            this.cmbo_employee.Size = new System.Drawing.Size(390, 21);
            this.cmbo_employee.TabIndex = 54;
            // 
            // cmbo_vendorType
            // 
            this.cmbo_vendorType.FormattingEnabled = true;
            this.cmbo_vendorType.Location = new System.Drawing.Point(339, 26);
            this.cmbo_vendorType.Name = "cmbo_vendorType";
            this.cmbo_vendorType.Size = new System.Drawing.Size(390, 21);
            this.cmbo_vendorType.TabIndex = 53;
            // 
            // txt_totalNet
            // 
            this.txt_totalNet.BackColor = System.Drawing.Color.Transparent;
            this.txt_totalNet.BorderColor = System.Drawing.Color.Gray;
            this.txt_totalNet.BorderRadius = 6;
            this.txt_totalNet.BorderThickness = 2;
            this.txt_totalNet.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.txt_totalNet.DefaultText = "";
            this.txt_totalNet.DisabledState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(208)))), ((int)(((byte)(208)))), ((int)(((byte)(208)))));
            this.txt_totalNet.DisabledState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(226)))), ((int)(((byte)(226)))), ((int)(((byte)(226)))));
            this.txt_totalNet.DisabledState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(138)))), ((int)(((byte)(138)))), ((int)(((byte)(138)))));
            this.txt_totalNet.DisabledState.PlaceholderForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(138)))), ((int)(((byte)(138)))), ((int)(((byte)(138)))));
            this.txt_totalNet.FillColor = System.Drawing.Color.WhiteSmoke;
            this.txt_totalNet.FocusedState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(148)))), ((int)(((byte)(255)))));
            this.txt_totalNet.Font = new System.Drawing.Font("Arial Narrow", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txt_totalNet.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.txt_totalNet.HoverState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(148)))), ((int)(((byte)(255)))));
            this.txt_totalNet.Location = new System.Drawing.Point(949, 4);
            this.txt_totalNet.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.txt_totalNet.Name = "txt_totalNet";
            this.txt_totalNet.PasswordChar = '\0';
            this.txt_totalNet.PlaceholderText = "";
            this.txt_totalNet.ReadOnly = true;
            this.txt_totalNet.SelectedText = "";
            this.txt_totalNet.ShadowDecoration.Color = System.Drawing.Color.Silver;
            this.txt_totalNet.Size = new System.Drawing.Size(115, 31);
            this.txt_totalNet.TabIndex = 9;
            this.txt_totalNet.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // guna2GradientPanel1
            // 
            this.guna2GradientPanel1.Controls.Add(this.txt_totalGross);
            this.guna2GradientPanel1.Controls.Add(this.txt_totalNet);
            this.guna2GradientPanel1.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.guna2GradientPanel1.FillColor = System.Drawing.Color.White;
            this.guna2GradientPanel1.FillColor2 = System.Drawing.Color.Gainsboro;
            this.guna2GradientPanel1.GradientMode = System.Drawing.Drawing2D.LinearGradientMode.Vertical;
            this.guna2GradientPanel1.Location = new System.Drawing.Point(0, 577);
            this.guna2GradientPanel1.Name = "guna2GradientPanel1";
            this.guna2GradientPanel1.Size = new System.Drawing.Size(1080, 40);
            this.guna2GradientPanel1.TabIndex = 111;
            // 
            // txt_totalGross
            // 
            this.txt_totalGross.BackColor = System.Drawing.Color.Transparent;
            this.txt_totalGross.BorderColor = System.Drawing.Color.Gray;
            this.txt_totalGross.BorderRadius = 6;
            this.txt_totalGross.BorderThickness = 2;
            this.txt_totalGross.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.txt_totalGross.DefaultText = "";
            this.txt_totalGross.DisabledState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(208)))), ((int)(((byte)(208)))), ((int)(((byte)(208)))));
            this.txt_totalGross.DisabledState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(226)))), ((int)(((byte)(226)))), ((int)(((byte)(226)))));
            this.txt_totalGross.DisabledState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(138)))), ((int)(((byte)(138)))), ((int)(((byte)(138)))));
            this.txt_totalGross.DisabledState.PlaceholderForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(138)))), ((int)(((byte)(138)))), ((int)(((byte)(138)))));
            this.txt_totalGross.FillColor = System.Drawing.Color.WhiteSmoke;
            this.txt_totalGross.FocusedState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(148)))), ((int)(((byte)(255)))));
            this.txt_totalGross.Font = new System.Drawing.Font("Arial Narrow", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txt_totalGross.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.txt_totalGross.HoverState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(148)))), ((int)(((byte)(255)))));
            this.txt_totalGross.Location = new System.Drawing.Point(636, 5);
            this.txt_totalGross.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.txt_totalGross.Name = "txt_totalGross";
            this.txt_totalGross.PasswordChar = '\0';
            this.txt_totalGross.PlaceholderText = "";
            this.txt_totalGross.ReadOnly = true;
            this.txt_totalGross.SelectedText = "";
            this.txt_totalGross.ShadowDecoration.Color = System.Drawing.Color.Silver;
            this.txt_totalGross.Size = new System.Drawing.Size(113, 31);
            this.txt_totalGross.TabIndex = 10;
            this.txt_totalGross.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // to
            // 
            this.to.AutoSize = true;
            this.to.Location = new System.Drawing.Point(473, 121);
            this.to.Name = "to";
            this.to.Size = new System.Drawing.Size(20, 13);
            this.to.TabIndex = 51;
            this.to.Text = "To";
            // 
            // dtmEnd
            // 
            this.dtmEnd.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dtmEnd.Location = new System.Drawing.Point(523, 117);
            this.dtmEnd.Name = "dtmEnd";
            this.dtmEnd.Size = new System.Drawing.Size(102, 20);
            this.dtmEnd.TabIndex = 17;
            this.dtmEnd.Value = new System.DateTime(2025, 3, 15, 15, 2, 50, 0);
            // 
            // dtmStart
            // 
            this.dtmStart.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dtmStart.Location = new System.Drawing.Point(340, 117);
            this.dtmStart.Name = "dtmStart";
            this.dtmStart.Size = new System.Drawing.Size(102, 20);
            this.dtmStart.TabIndex = 16;
            this.dtmStart.Value = new System.DateTime(2025, 3, 15, 15, 2, 50, 0);
            // 
            // txt_accountName
            // 
            this.txt_accountName.BackColor = System.Drawing.Color.Transparent;
            this.txt_accountName.BorderRadius = 6;
            this.txt_accountName.BorderThickness = 2;
            this.txt_accountName.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.txt_accountName.DefaultText = "";
            this.txt_accountName.DisabledState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(208)))), ((int)(((byte)(208)))), ((int)(((byte)(208)))));
            this.txt_accountName.DisabledState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(226)))), ((int)(((byte)(226)))), ((int)(((byte)(226)))));
            this.txt_accountName.DisabledState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(138)))), ((int)(((byte)(138)))), ((int)(((byte)(138)))));
            this.txt_accountName.DisabledState.PlaceholderForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(138)))), ((int)(((byte)(138)))), ((int)(((byte)(138)))));
            this.txt_accountName.FocusedState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(148)))), ((int)(((byte)(255)))));
            this.txt_accountName.Font = new System.Drawing.Font("Segoe UI Semibold", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txt_accountName.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.txt_accountName.HoverState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(148)))), ((int)(((byte)(255)))));
            this.txt_accountName.Location = new System.Drawing.Point(442, 53);
            this.txt_accountName.Name = "txt_accountName";
            this.txt_accountName.PasswordChar = '\0';
            this.txt_accountName.PlaceholderText = "Vendor Name";
            this.txt_accountName.SelectedText = "";
            this.txt_accountName.ShadowDecoration.Color = System.Drawing.Color.Silver;
            this.txt_accountName.Size = new System.Drawing.Size(287, 31);
            this.txt_accountName.TabIndex = 13;
            this.txt_accountName.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // txt_accountId
            // 
            this.txt_accountId.BackColor = System.Drawing.Color.Transparent;
            this.txt_accountId.BorderRadius = 6;
            this.txt_accountId.BorderThickness = 2;
            this.txt_accountId.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.txt_accountId.DefaultText = "";
            this.txt_accountId.DisabledState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(208)))), ((int)(((byte)(208)))), ((int)(((byte)(208)))));
            this.txt_accountId.DisabledState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(226)))), ((int)(((byte)(226)))), ((int)(((byte)(226)))));
            this.txt_accountId.DisabledState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(138)))), ((int)(((byte)(138)))), ((int)(((byte)(138)))));
            this.txt_accountId.DisabledState.PlaceholderForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(138)))), ((int)(((byte)(138)))), ((int)(((byte)(138)))));
            this.txt_accountId.FocusedState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(148)))), ((int)(((byte)(255)))));
            this.txt_accountId.Font = new System.Drawing.Font("Segoe UI Semibold", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txt_accountId.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.txt_accountId.HoverState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(148)))), ((int)(((byte)(255)))));
            this.txt_accountId.Location = new System.Drawing.Point(339, 53);
            this.txt_accountId.Name = "txt_accountId";
            this.txt_accountId.PasswordChar = '\0';
            this.txt_accountId.PlaceholderText = "Vendor ID";
            this.txt_accountId.SelectedText = "";
            this.txt_accountId.ShadowDecoration.Color = System.Drawing.Color.Silver;
            this.txt_accountId.Size = new System.Drawing.Size(100, 31);
            this.txt_accountId.TabIndex = 12;
            this.txt_accountId.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // guna2ShadowPanel1
            // 
            this.guna2ShadowPanel1.BackColor = System.Drawing.Color.Transparent;
            this.guna2ShadowPanel1.Controls.Add(this.guna2ShadowPanel2);
            this.guna2ShadowPanel1.Controls.Add(this.chk_date);
            this.guna2ShadowPanel1.Controls.Add(this.chk_employee);
            this.guna2ShadowPanel1.Controls.Add(this.chk_customer);
            this.guna2ShadowPanel1.Controls.Add(this.chk_vendorType);
            this.guna2ShadowPanel1.Controls.Add(this.cmbo_employee);
            this.guna2ShadowPanel1.Controls.Add(this.cmbo_vendorType);
            this.guna2ShadowPanel1.Controls.Add(this.btn_search);
            this.guna2ShadowPanel1.Controls.Add(this.to);
            this.guna2ShadowPanel1.Controls.Add(this.dtmEnd);
            this.guna2ShadowPanel1.Controls.Add(this.dtmStart);
            this.guna2ShadowPanel1.Controls.Add(this.txt_accountName);
            this.guna2ShadowPanel1.Controls.Add(this.txt_accountId);
            this.guna2ShadowPanel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.guna2ShadowPanel1.FillColor = System.Drawing.Color.White;
            this.guna2ShadowPanel1.Location = new System.Drawing.Point(0, 0);
            this.guna2ShadowPanel1.Name = "guna2ShadowPanel1";
            this.guna2ShadowPanel1.ShadowColor = System.Drawing.Color.Black;
            this.guna2ShadowPanel1.Size = new System.Drawing.Size(1080, 155);
            this.guna2ShadowPanel1.TabIndex = 109;
            // 
            // btn_search
            // 
            this.btn_search.BorderColor = System.Drawing.Color.LavenderBlush;
            this.btn_search.BorderRadius = 4;
            this.btn_search.BorderThickness = 2;
            this.btn_search.DisabledState.BorderColor = System.Drawing.Color.DarkGray;
            this.btn_search.DisabledState.CustomBorderColor = System.Drawing.Color.DarkGray;
            this.btn_search.DisabledState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(169)))), ((int)(((byte)(169)))), ((int)(((byte)(169)))));
            this.btn_search.DisabledState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(141)))), ((int)(((byte)(141)))), ((int)(((byte)(141)))));
            this.btn_search.FillColor = System.Drawing.Color.IndianRed;
            this.btn_search.Font = new System.Drawing.Font("Segoe UI Semibold", 12F, System.Drawing.FontStyle.Bold);
            this.btn_search.ForeColor = System.Drawing.Color.White;
            this.btn_search.Image = ((System.Drawing.Image)(resources.GetObject("btn_search.Image")));
            this.btn_search.ImageOffset = new System.Drawing.Point(12, -10);
            this.btn_search.ImageSize = new System.Drawing.Size(38, 38);
            this.btn_search.Location = new System.Drawing.Point(735, 26);
            this.btn_search.Name = "btn_search";
            this.btn_search.Size = new System.Drawing.Size(86, 58);
            this.btn_search.TabIndex = 52;
            this.btn_search.Text = "Search";
            this.btn_search.TextOffset = new System.Drawing.Point(-10, 15);
            this.btn_search.Click += new System.EventHandler(this.btn_search_Click);
            // 
            // PurchaseSummaryReport
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1080, 617);
            this.Controls.Add(this.dataGridView2);
            this.Controls.Add(this.guna2GradientPanel1);
            this.Controls.Add(this.guna2ShadowPanel1);
            this.Name = "PurchaseSummaryReport";
            this.StartPosition = System.Windows.Forms.FormStartPosition.Manual;
            this.Text = "PurchaseSummaryReport";
            this.Load += new System.EventHandler(this.PurchaseSummaryReport_Load);
            ((System.ComponentModel.ISupportInitialize)(this.purchaseSummaryBindingSource)).EndInit();
            this.guna2ShadowPanel2.ResumeLayout(false);
            this.guna2ShadowPanel2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView2)).EndInit();
            this.guna2GradientPanel1.ResumeLayout(false);
            this.guna2ShadowPanel1.ResumeLayout(false);
            this.guna2ShadowPanel1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.BindingSource purchaseSummaryBindingSource;
        private Guna.UI2.WinForms.Guna2ShadowPanel guna2ShadowPanel2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.CheckBox chk_date;
        private System.Windows.Forms.CheckBox chk_employee;
        private System.Windows.Forms.DataGridView dataGridView2;
        private System.Windows.Forms.CheckBox chk_customer;
        private System.Windows.Forms.CheckBox chk_vendorType;
        private System.Windows.Forms.ComboBox cmbo_employee;
        private System.Windows.Forms.ComboBox cmbo_vendorType;
        private Guna.UI2.WinForms.Guna2TextBox txt_totalNet;
        private Guna.UI2.WinForms.Guna2GradientPanel guna2GradientPanel1;
        private Guna.UI2.WinForms.Guna2TextBox txt_totalGross;
        private System.Windows.Forms.Label to;
        private System.Windows.Forms.DateTimePicker dtmEnd;
        private System.Windows.Forms.DateTimePicker dtmStart;
        private Guna.UI2.WinForms.Guna2TextBox txt_accountName;
        private Guna.UI2.WinForms.Guna2TextBox txt_accountId;
        private Guna.UI2.WinForms.Guna2ShadowPanel guna2ShadowPanel1;
        private Guna.UI2.WinForms.Guna2Button btn_search;
        private System.Windows.Forms.DataGridViewTextBoxColumn PurchaseInvoiceID;
        private System.Windows.Forms.DataGridViewTextBoxColumn InvoiceDate;
        private System.Windows.Forms.DataGridViewTextBoxColumn AccountName;
        private System.Windows.Forms.DataGridViewTextBoxColumn employeeReference;
        private System.Windows.Forms.DataGridViewTextBoxColumn GrossTotal;
        private System.Windows.Forms.DataGridViewTextBoxColumn AdditionalDiscount;
        private System.Windows.Forms.DataGridViewTextBoxColumn CarriageAndFreight;
        private System.Windows.Forms.DataGridViewTextBoxColumn NetTotal;
    }
}