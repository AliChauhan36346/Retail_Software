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
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(ItemWiseProfitLossForm));
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle3 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle4 = new System.Windows.Forms.DataGridViewCellStyle();
            this.ItemProfitLossBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.guna2ShadowPanel2 = new Guna.UI2.WinForms.Guna2ShadowPanel();
            this.label1 = new System.Windows.Forms.Label();
            this.chk_date = new System.Windows.Forms.CheckBox();
            this.chk_employee = new System.Windows.Forms.CheckBox();
            this.cmbo_employee = new System.Windows.Forms.ComboBox();
            this.guna2ShadowPanel1 = new Guna.UI2.WinForms.Guna2ShadowPanel();
            this.btn_search = new Guna.UI2.WinForms.Guna2Button();
            this.to = new System.Windows.Forms.Label();
            this.dtmEnd = new System.Windows.Forms.DateTimePicker();
            this.dtmStart = new System.Windows.Forms.DateTimePicker();
            this.dataGridView2 = new System.Windows.Forms.DataGridView();
            this.txt_totalNet = new Guna.UI2.WinForms.Guna2TextBox();
            this.guna2GradientPanel1 = new Guna.UI2.WinForms.Guna2GradientPanel();
            this.txt_totalGross = new Guna.UI2.WinForms.Guna2TextBox();
            this.cmbo_customerType = new System.Windows.Forms.ComboBox();
            this.chk_customerType = new System.Windows.Forms.CheckBox();
            this.checkBox1 = new System.Windows.Forms.CheckBox();
            this.comboBox1 = new System.Windows.Forms.ComboBox();
            this.comboBox2 = new System.Windows.Forms.ComboBox();
            this.radioButton1 = new System.Windows.Forms.RadioButton();
            this.radioButton2 = new System.Windows.Forms.RadioButton();
            this.SalesInvoiceID = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.InvoiceDate = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.AccountName = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.employeeReference = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.GrossTotal = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.AdditionalDiscount = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.CarriageAndFreight = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.NetTotal = new System.Windows.Forms.DataGridViewTextBoxColumn();
            ((System.ComponentModel.ISupportInitialize)(this.ItemProfitLossBindingSource)).BeginInit();
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
            this.chk_date.Location = new System.Drawing.Point(271, 153);
            this.chk_date.Name = "chk_date";
            this.chk_date.Size = new System.Drawing.Size(56, 23);
            this.chk_date.TabIndex = 58;
            this.chk_date.Text = "تاریخ";
            this.chk_date.UseVisualStyleBackColor = true;
            // 
            // chk_employee
            // 
            this.chk_employee.AutoSize = true;
            this.chk_employee.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.chk_employee.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.chk_employee.Location = new System.Drawing.Point(271, 128);
            this.chk_employee.Name = "chk_employee";
            this.chk_employee.Size = new System.Drawing.Size(57, 23);
            this.chk_employee.TabIndex = 57;
            this.chk_employee.Text = "ملازم";
            this.chk_employee.UseVisualStyleBackColor = true;
            // 
            // cmbo_employee
            // 
            this.cmbo_employee.FormattingEnabled = true;
            this.cmbo_employee.Location = new System.Drawing.Point(380, 127);
            this.cmbo_employee.Name = "cmbo_employee";
            this.cmbo_employee.Size = new System.Drawing.Size(390, 21);
            this.cmbo_employee.TabIndex = 54;
            // 
            // guna2ShadowPanel1
            // 
            this.guna2ShadowPanel1.BackColor = System.Drawing.Color.Transparent;
            this.guna2ShadowPanel1.Controls.Add(this.radioButton2);
            this.guna2ShadowPanel1.Controls.Add(this.radioButton1);
            this.guna2ShadowPanel1.Controls.Add(this.comboBox2);
            this.guna2ShadowPanel1.Controls.Add(this.checkBox1);
            this.guna2ShadowPanel1.Controls.Add(this.comboBox1);
            this.guna2ShadowPanel1.Controls.Add(this.guna2ShadowPanel2);
            this.guna2ShadowPanel1.Controls.Add(this.chk_date);
            this.guna2ShadowPanel1.Controls.Add(this.chk_employee);
            this.guna2ShadowPanel1.Controls.Add(this.chk_customerType);
            this.guna2ShadowPanel1.Controls.Add(this.cmbo_employee);
            this.guna2ShadowPanel1.Controls.Add(this.cmbo_customerType);
            this.guna2ShadowPanel1.Controls.Add(this.btn_search);
            this.guna2ShadowPanel1.Controls.Add(this.to);
            this.guna2ShadowPanel1.Controls.Add(this.dtmEnd);
            this.guna2ShadowPanel1.Controls.Add(this.dtmStart);
            this.guna2ShadowPanel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.guna2ShadowPanel1.FillColor = System.Drawing.Color.White;
            this.guna2ShadowPanel1.Location = new System.Drawing.Point(0, 0);
            this.guna2ShadowPanel1.Name = "guna2ShadowPanel1";
            this.guna2ShadowPanel1.ShadowColor = System.Drawing.Color.Black;
            this.guna2ShadowPanel1.Size = new System.Drawing.Size(1080, 185);
            this.guna2ShadowPanel1.TabIndex = 109;
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
            this.btn_search.Location = new System.Drawing.Point(776, 48);
            this.btn_search.Name = "btn_search";
            this.btn_search.Size = new System.Drawing.Size(86, 58);
            this.btn_search.TabIndex = 52;
            this.btn_search.Text = "Search";
            this.btn_search.TextOffset = new System.Drawing.Point(-10, 15);
            // 
            // to
            // 
            this.to.AutoSize = true;
            this.to.Location = new System.Drawing.Point(514, 158);
            this.to.Name = "to";
            this.to.Size = new System.Drawing.Size(20, 13);
            this.to.TabIndex = 51;
            this.to.Text = "To";
            // 
            // dtmEnd
            // 
            this.dtmEnd.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dtmEnd.Location = new System.Drawing.Point(564, 154);
            this.dtmEnd.Name = "dtmEnd";
            this.dtmEnd.Size = new System.Drawing.Size(102, 20);
            this.dtmEnd.TabIndex = 17;
            this.dtmEnd.Value = new System.DateTime(2025, 3, 15, 15, 2, 50, 0);
            // 
            // dtmStart
            // 
            this.dtmStart.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dtmStart.Location = new System.Drawing.Point(381, 154);
            this.dtmStart.Name = "dtmStart";
            this.dtmStart.Size = new System.Drawing.Size(102, 20);
            this.dtmStart.TabIndex = 16;
            this.dtmStart.Value = new System.DateTime(2025, 3, 15, 15, 2, 50, 0);
            // 
            // dataGridView2
            // 
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle1.BackColor = System.Drawing.Color.LightBlue;
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
            this.SalesInvoiceID,
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
            this.dataGridView2.Location = new System.Drawing.Point(0, 191);
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
            this.dataGridView2.Size = new System.Drawing.Size(1080, 383);
            this.dataGridView2.TabIndex = 110;
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
            this.guna2GradientPanel1.FillColor2 = System.Drawing.Color.LightGray;
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
            // cmbo_customerType
            // 
            this.cmbo_customerType.FormattingEnabled = true;
            this.cmbo_customerType.Location = new System.Drawing.Point(380, 100);
            this.cmbo_customerType.Name = "cmbo_customerType";
            this.cmbo_customerType.Size = new System.Drawing.Size(390, 21);
            this.cmbo_customerType.TabIndex = 53;
            // 
            // chk_customerType
            // 
            this.chk_customerType.AutoSize = true;
            this.chk_customerType.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.chk_customerType.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.chk_customerType.Location = new System.Drawing.Point(271, 102);
            this.chk_customerType.Name = "chk_customerType";
            this.chk_customerType.Size = new System.Drawing.Size(84, 23);
            this.chk_customerType.TabIndex = 55;
            this.chk_customerType.Text = "برانڈ کا نام";
            this.chk_customerType.UseVisualStyleBackColor = true;
            // 
            // checkBox1
            // 
            this.checkBox1.AutoSize = true;
            this.checkBox1.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.checkBox1.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.checkBox1.Location = new System.Drawing.Point(271, 77);
            this.checkBox1.Name = "checkBox1";
            this.checkBox1.Size = new System.Drawing.Size(84, 23);
            this.checkBox1.TabIndex = 62;
            this.checkBox1.Text = "برانڈ کا نام";
            this.checkBox1.UseVisualStyleBackColor = true;
            // 
            // comboBox1
            // 
            this.comboBox1.FormattingEnabled = true;
            this.comboBox1.Location = new System.Drawing.Point(380, 75);
            this.comboBox1.Name = "comboBox1";
            this.comboBox1.Size = new System.Drawing.Size(390, 21);
            this.comboBox1.TabIndex = 61;
            // 
            // comboBox2
            // 
            this.comboBox2.FormattingEnabled = true;
            this.comboBox2.Location = new System.Drawing.Point(380, 48);
            this.comboBox2.Name = "comboBox2";
            this.comboBox2.Size = new System.Drawing.Size(390, 21);
            this.comboBox2.TabIndex = 63;
            // 
            // radioButton1
            // 
            this.radioButton1.AutoSize = true;
            this.radioButton1.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Bold);
            this.radioButton1.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.radioButton1.Location = new System.Drawing.Point(233, 48);
            this.radioButton1.Name = "radioButton1";
            this.radioButton1.Size = new System.Drawing.Size(138, 23);
            this.radioButton1.TabIndex = 64;
            this.radioButton1.TabStop = true;
            this.radioButton1.Text = "کیٹیگری منتخب کریں";
            this.radioButton1.UseVisualStyleBackColor = true;
            // 
            // radioButton2
            // 
            this.radioButton2.AutoSize = true;
            this.radioButton2.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Bold);
            this.radioButton2.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.radioButton2.Location = new System.Drawing.Point(271, 22);
            this.radioButton2.Name = "radioButton2";
            this.radioButton2.Size = new System.Drawing.Size(96, 23);
            this.radioButton2.TabIndex = 65;
            this.radioButton2.TabStop = true;
            this.radioButton2.Text = "تمام انوینٹری";
            this.radioButton2.UseVisualStyleBackColor = true;
            // 
            // SalesInvoiceID
            // 
            this.SalesInvoiceID.DataPropertyName = "SalesInvoiceID";
            this.SalesInvoiceID.HeaderText = "آئٹم کوڈ";
            this.SalesInvoiceID.Name = "SalesInvoiceID";
            this.SalesInvoiceID.ReadOnly = true;
            this.SalesInvoiceID.Width = 90;
            // 
            // InvoiceDate
            // 
            this.InvoiceDate.DataPropertyName = "InvoiceDate";
            this.InvoiceDate.HeaderText = "آئٹم کا نام";
            this.InvoiceDate.Name = "InvoiceDate";
            this.InvoiceDate.ReadOnly = true;
            this.InvoiceDate.Width = 285;
            // 
            // AccountName
            // 
            this.AccountName.DataPropertyName = "AccountName";
            this.AccountName.HeaderText = "مقدار";
            this.AccountName.Name = "AccountName";
            this.AccountName.ReadOnly = true;
            // 
            // employeeReference
            // 
            this.employeeReference.DataPropertyName = "employeeReference";
            this.employeeReference.HeaderText = "یونٹ";
            this.employeeReference.Name = "employeeReference";
            this.employeeReference.ReadOnly = true;
            this.employeeReference.Width = 80;
            // 
            // GrossTotal
            // 
            this.GrossTotal.DataPropertyName = "GrossTotal";
            this.GrossTotal.HeaderText = "یونٹ لاگت";
            this.GrossTotal.Name = "GrossTotal";
            this.GrossTotal.ReadOnly = true;
            this.GrossTotal.Width = 115;
            // 
            // AdditionalDiscount
            // 
            this.AdditionalDiscount.DataPropertyName = "AdditionalDiscount";
            this.AdditionalDiscount.HeaderText = "کل لاگت";
            this.AdditionalDiscount.Name = "AdditionalDiscount";
            this.AdditionalDiscount.ReadOnly = true;
            this.AdditionalDiscount.Width = 115;
            // 
            // CarriageAndFreight
            // 
            this.CarriageAndFreight.DataPropertyName = "CarriageAndFreight";
            this.CarriageAndFreight.HeaderText = "فروخت قیمت";
            this.CarriageAndFreight.Name = "CarriageAndFreight";
            this.CarriageAndFreight.ReadOnly = true;
            this.CarriageAndFreight.Width = 115;
            // 
            // NetTotal
            // 
            this.NetTotal.DataPropertyName = "NetTotal";
            this.NetTotal.HeaderText = "نفع/نقصان";
            this.NetTotal.Name = "NetTotal";
            this.NetTotal.ReadOnly = true;
            this.NetTotal.Width = 115;
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
            this.Text = "ItemWiseProfitLossForm";
            ((System.ComponentModel.ISupportInitialize)(this.ItemProfitLossBindingSource)).EndInit();
            this.guna2ShadowPanel2.ResumeLayout(false);
            this.guna2ShadowPanel2.PerformLayout();
            this.guna2ShadowPanel1.ResumeLayout(false);
            this.guna2ShadowPanel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView2)).EndInit();
            this.guna2GradientPanel1.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.BindingSource ItemProfitLossBindingSource;
        private Guna.UI2.WinForms.Guna2ShadowPanel guna2ShadowPanel2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.CheckBox chk_date;
        private System.Windows.Forms.CheckBox chk_employee;
        private System.Windows.Forms.ComboBox cmbo_employee;
        private Guna.UI2.WinForms.Guna2ShadowPanel guna2ShadowPanel1;
        private System.Windows.Forms.CheckBox chk_customerType;
        private System.Windows.Forms.ComboBox cmbo_customerType;
        private Guna.UI2.WinForms.Guna2Button btn_search;
        private System.Windows.Forms.Label to;
        private System.Windows.Forms.DateTimePicker dtmEnd;
        private System.Windows.Forms.DateTimePicker dtmStart;
        private System.Windows.Forms.DataGridView dataGridView2;
        private Guna.UI2.WinForms.Guna2TextBox txt_totalNet;
        private Guna.UI2.WinForms.Guna2GradientPanel guna2GradientPanel1;
        private Guna.UI2.WinForms.Guna2TextBox txt_totalGross;
        private System.Windows.Forms.RadioButton radioButton2;
        private System.Windows.Forms.RadioButton radioButton1;
        private System.Windows.Forms.ComboBox comboBox2;
        private System.Windows.Forms.CheckBox checkBox1;
        private System.Windows.Forms.ComboBox comboBox1;
        private System.Windows.Forms.DataGridViewTextBoxColumn SalesInvoiceID;
        private System.Windows.Forms.DataGridViewTextBoxColumn InvoiceDate;
        private System.Windows.Forms.DataGridViewTextBoxColumn AccountName;
        private System.Windows.Forms.DataGridViewTextBoxColumn employeeReference;
        private System.Windows.Forms.DataGridViewTextBoxColumn GrossTotal;
        private System.Windows.Forms.DataGridViewTextBoxColumn AdditionalDiscount;
        private System.Windows.Forms.DataGridViewTextBoxColumn CarriageAndFreight;
        private System.Windows.Forms.DataGridViewTextBoxColumn NetTotal;
    }
}