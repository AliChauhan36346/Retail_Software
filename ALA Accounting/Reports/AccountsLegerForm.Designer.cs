namespace ALA_Accounting.Reports
{
    partial class AccountsLegerForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(AccountsLegerForm));
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle3 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle4 = new System.Windows.Forms.DataGridViewCellStyle();
            this.guna2ShadowPanel1 = new Guna.UI2.WinForms.Guna2ShadowPanel();
            this.btn_search = new Guna.UI2.WinForms.Guna2Button();
            this.to = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.dtmEnd = new System.Windows.Forms.DateTimePicker();
            this.dtmStart = new System.Windows.Forms.DateTimePicker();
            this.chk_date = new Guna.UI2.WinForms.Guna2CustomCheckBox();
            this.txt_accountName = new Guna.UI2.WinForms.Guna2TextBox();
            this.txt_accountId = new Guna.UI2.WinForms.Guna2TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.guna2PictureBox1 = new Guna.UI2.WinForms.Guna2PictureBox();
            this.label1 = new System.Windows.Forms.Label();
            this.dataGridView2 = new System.Windows.Forms.DataGridView();
            this.date = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.TransactionID = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.description = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Debit = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Credit = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.balance = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.status = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.guna2GradientPanel1 = new Guna.UI2.WinForms.Guna2GradientPanel();
            this.txt_debit = new Guna.UI2.WinForms.Guna2TextBox();
            this.txt_credit = new Guna.UI2.WinForms.Guna2TextBox();
            this.txt_balance = new Guna.UI2.WinForms.Guna2TextBox();
            this.lstAccounts = new System.Windows.Forms.ListBox();
            this.guna2ShadowPanel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.guna2PictureBox1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView2)).BeginInit();
            this.guna2GradientPanel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // guna2ShadowPanel1
            // 
            this.guna2ShadowPanel1.BackColor = System.Drawing.Color.Transparent;
            this.guna2ShadowPanel1.Controls.Add(this.btn_search);
            this.guna2ShadowPanel1.Controls.Add(this.to);
            this.guna2ShadowPanel1.Controls.Add(this.label8);
            this.guna2ShadowPanel1.Controls.Add(this.dtmEnd);
            this.guna2ShadowPanel1.Controls.Add(this.dtmStart);
            this.guna2ShadowPanel1.Controls.Add(this.chk_date);
            this.guna2ShadowPanel1.Controls.Add(this.txt_accountName);
            this.guna2ShadowPanel1.Controls.Add(this.txt_accountId);
            this.guna2ShadowPanel1.Controls.Add(this.label2);
            this.guna2ShadowPanel1.Controls.Add(this.guna2PictureBox1);
            this.guna2ShadowPanel1.Controls.Add(this.label1);
            this.guna2ShadowPanel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.guna2ShadowPanel1.FillColor = System.Drawing.Color.White;
            this.guna2ShadowPanel1.Location = new System.Drawing.Point(0, 0);
            this.guna2ShadowPanel1.Name = "guna2ShadowPanel1";
            this.guna2ShadowPanel1.ShadowColor = System.Drawing.Color.Black;
            this.guna2ShadowPanel1.Size = new System.Drawing.Size(1080, 122);
            this.guna2ShadowPanel1.TabIndex = 0;
            this.guna2ShadowPanel1.Paint += new System.Windows.Forms.PaintEventHandler(this.guna2ShadowPanel1_Paint);
            // 
            // btn_search
            // 
            this.btn_search.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(64)))), ((int)(((byte)(0)))));
            this.btn_search.BorderRadius = 4;
            this.btn_search.BorderThickness = 2;
            this.btn_search.DisabledState.BorderColor = System.Drawing.Color.DarkGray;
            this.btn_search.DisabledState.CustomBorderColor = System.Drawing.Color.DarkGray;
            this.btn_search.DisabledState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(169)))), ((int)(((byte)(169)))), ((int)(((byte)(169)))));
            this.btn_search.DisabledState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(141)))), ((int)(((byte)(141)))), ((int)(((byte)(141)))));
            this.btn_search.FillColor = System.Drawing.Color.Ivory;
            this.btn_search.Font = new System.Drawing.Font("Segoe UI Semibold", 12F, System.Drawing.FontStyle.Bold);
            this.btn_search.ForeColor = System.Drawing.Color.DimGray;
            this.btn_search.Image = ((System.Drawing.Image)(resources.GetObject("btn_search.Image")));
            this.btn_search.ImageOffset = new System.Drawing.Point(12, -10);
            this.btn_search.ImageSize = new System.Drawing.Size(38, 38);
            this.btn_search.Location = new System.Drawing.Point(773, 44);
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
            this.to.Location = new System.Drawing.Point(602, 91);
            this.to.Name = "to";
            this.to.Size = new System.Drawing.Size(20, 13);
            this.to.TabIndex = 51;
            this.to.Text = "To";
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.BackColor = System.Drawing.SystemColors.ButtonHighlight;
            this.label8.Font = new System.Drawing.Font("Arial", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label8.ForeColor = System.Drawing.SystemColors.ControlDarkDark;
            this.label8.Location = new System.Drawing.Point(369, 85);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(48, 24);
            this.label8.TabIndex = 50;
            this.label8.Text = "تاریخ";
            // 
            // dtmEnd
            // 
            this.dtmEnd.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dtmEnd.Location = new System.Drawing.Point(649, 87);
            this.dtmEnd.Name = "dtmEnd";
            this.dtmEnd.Size = new System.Drawing.Size(102, 20);
            this.dtmEnd.TabIndex = 17;
            this.dtmEnd.Value = new System.DateTime(2025, 3, 15, 15, 2, 50, 0);
            // 
            // dtmStart
            // 
            this.dtmStart.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dtmStart.Location = new System.Drawing.Point(469, 87);
            this.dtmStart.Name = "dtmStart";
            this.dtmStart.Size = new System.Drawing.Size(102, 20);
            this.dtmStart.TabIndex = 16;
            this.dtmStart.Value = new System.DateTime(2025, 3, 15, 15, 2, 50, 0);
            // 
            // chk_date
            // 
            this.chk_date.CheckedState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(148)))), ((int)(((byte)(255)))));
            this.chk_date.CheckedState.BorderRadius = 2;
            this.chk_date.CheckedState.BorderThickness = 0;
            this.chk_date.CheckedState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(148)))), ((int)(((byte)(255)))));
            this.chk_date.CheckMarkColor = System.Drawing.Color.IndianRed;
            this.chk_date.Location = new System.Drawing.Point(436, 87);
            this.chk_date.Name = "chk_date";
            this.chk_date.Size = new System.Drawing.Size(20, 20);
            this.chk_date.TabIndex = 15;
            this.chk_date.Text = "chkDate";
            this.chk_date.UncheckedState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(125)))), ((int)(((byte)(137)))), ((int)(((byte)(149)))));
            this.chk_date.UncheckedState.BorderRadius = 2;
            this.chk_date.UncheckedState.BorderThickness = 0;
            this.chk_date.UncheckedState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(125)))), ((int)(((byte)(137)))), ((int)(((byte)(149)))));
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
            this.txt_accountName.Location = new System.Drawing.Point(436, 44);
            this.txt_accountName.Name = "txt_accountName";
            this.txt_accountName.PasswordChar = '\0';
            this.txt_accountName.PlaceholderText = "AccountName";
            this.txt_accountName.SelectedText = "";
            this.txt_accountName.ShadowDecoration.Color = System.Drawing.Color.Silver;
            this.txt_accountName.Size = new System.Drawing.Size(331, 31);
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
            this.txt_accountId.Location = new System.Drawing.Point(322, 44);
            this.txt_accountId.Name = "txt_accountId";
            this.txt_accountId.PasswordChar = '\0';
            this.txt_accountId.PlaceholderText = "Account Id";
            this.txt_accountId.SelectedText = "";
            this.txt_accountId.ShadowDecoration.Color = System.Drawing.Color.Silver;
            this.txt_accountId.Size = new System.Drawing.Size(108, 31);
            this.txt_accountId.TabIndex = 12;
            this.txt_accountId.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.txt_accountId.TextChanged += new System.EventHandler(this.txt_accountId_TextChanged);
            this.txt_accountId.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txt_accountId_KeyDown);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.BackColor = System.Drawing.SystemColors.ButtonHighlight;
            this.label2.Font = new System.Drawing.Font("Arial", 15.75F, System.Drawing.FontStyle.Bold);
            this.label2.Location = new System.Drawing.Point(253, 51);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(63, 24);
            this.label2.TabIndex = 11;
            this.label2.Text = " اکاؤنٹ";
            this.label2.Click += new System.EventHandler(this.label2_Click);
            // 
            // guna2PictureBox1
            // 
            this.guna2PictureBox1.Image = ((System.Drawing.Image)(resources.GetObject("guna2PictureBox1.Image")));
            this.guna2PictureBox1.ImageRotate = 0F;
            this.guna2PictureBox1.Location = new System.Drawing.Point(12, 11);
            this.guna2PictureBox1.Name = "guna2PictureBox1";
            this.guna2PictureBox1.Size = new System.Drawing.Size(55, 52);
            this.guna2PictureBox1.TabIndex = 10;
            this.guna2PictureBox1.TabStop = false;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Arial", 24F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.SystemColors.ControlDarkDark;
            this.label1.Location = new System.Drawing.Point(58, 26);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(174, 37);
            this.label1.TabIndex = 1;
            this.label1.Text = "اکاؤنٹس کھا تا";
            // 
            // dataGridView2
            // 
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle1.BackColor = System.Drawing.Color.MintCream;
            dataGridViewCellStyle1.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle1.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle1.SelectionForeColor = System.Drawing.Color.White;
            this.dataGridView2.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle1;
            this.dataGridView2.BackgroundColor = System.Drawing.Color.White;
            this.dataGridView2.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.dataGridView2.CellBorderStyle = System.Windows.Forms.DataGridViewCellBorderStyle.SingleVertical;
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle2.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle2.Font = new System.Drawing.Font("Arial", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle2.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle2.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle2.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dataGridView2.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle2;
            this.dataGridView2.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView2.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.date,
            this.TransactionID,
            this.description,
            this.Debit,
            this.Credit,
            this.balance,
            this.status});
            dataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle3.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle3.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle3.ForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle3.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle3.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle3.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.dataGridView2.DefaultCellStyle = dataGridViewCellStyle3;
            this.dataGridView2.Location = new System.Drawing.Point(0, 128);
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
            this.dataGridView2.Size = new System.Drawing.Size(1080, 443);
            this.dataGridView2.TabIndex = 103;
            // 
            // date
            // 
            this.date.HeaderText = "تاریخ";
            this.date.Name = "date";
            this.date.ReadOnly = true;
            // 
            // TransactionID
            // 
            this.TransactionID.HeaderText = "ٹرانزیکشن آئی ڈی";
            this.TransactionID.Name = "TransactionID";
            this.TransactionID.ReadOnly = true;
            this.TransactionID.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            // 
            // description
            // 
            this.description.HeaderText = "تفصیل";
            this.description.Name = "description";
            this.description.ReadOnly = true;
            this.description.Width = 380;
            // 
            // Debit
            // 
            this.Debit.HeaderText = "ڈیبٹ / بنام";
            this.Debit.Name = "Debit";
            this.Debit.ReadOnly = true;
            this.Debit.Width = 120;
            // 
            // Credit
            // 
            this.Credit.HeaderText = "کریڈٹ / جمع";
            this.Credit.Name = "Credit";
            this.Credit.ReadOnly = true;
            this.Credit.Width = 120;
            // 
            // balance
            // 
            this.balance.HeaderText = "بیلنس";
            this.balance.Name = "balance";
            this.balance.ReadOnly = true;
            this.balance.Width = 120;
            // 
            // status
            // 
            this.status.HeaderText = "اسٹیٹس";
            this.status.Name = "status";
            this.status.ReadOnly = true;
            this.status.Width = 80;
            // 
            // guna2GradientPanel1
            // 
            this.guna2GradientPanel1.Controls.Add(this.txt_debit);
            this.guna2GradientPanel1.Controls.Add(this.txt_credit);
            this.guna2GradientPanel1.Controls.Add(this.txt_balance);
            this.guna2GradientPanel1.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.guna2GradientPanel1.FillColor = System.Drawing.Color.White;
            this.guna2GradientPanel1.FillColor2 = System.Drawing.Color.LightGray;
            this.guna2GradientPanel1.GradientMode = System.Drawing.Drawing2D.LinearGradientMode.Vertical;
            this.guna2GradientPanel1.Location = new System.Drawing.Point(0, 572);
            this.guna2GradientPanel1.Name = "guna2GradientPanel1";
            this.guna2GradientPanel1.Size = new System.Drawing.Size(1080, 45);
            this.guna2GradientPanel1.TabIndex = 105;
            // 
            // txt_debit
            // 
            this.txt_debit.BackColor = System.Drawing.Color.Transparent;
            this.txt_debit.BorderColor = System.Drawing.Color.Gray;
            this.txt_debit.BorderRadius = 6;
            this.txt_debit.BorderThickness = 2;
            this.txt_debit.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.txt_debit.DefaultText = "";
            this.txt_debit.DisabledState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(208)))), ((int)(((byte)(208)))), ((int)(((byte)(208)))));
            this.txt_debit.DisabledState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(226)))), ((int)(((byte)(226)))), ((int)(((byte)(226)))));
            this.txt_debit.DisabledState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(138)))), ((int)(((byte)(138)))), ((int)(((byte)(138)))));
            this.txt_debit.DisabledState.PlaceholderForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(138)))), ((int)(((byte)(138)))), ((int)(((byte)(138)))));
            this.txt_debit.FillColor = System.Drawing.Color.WhiteSmoke;
            this.txt_debit.FocusedState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(148)))), ((int)(((byte)(255)))));
            this.txt_debit.Font = new System.Drawing.Font("Arial Narrow", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txt_debit.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.txt_debit.HoverState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(148)))), ((int)(((byte)(255)))));
            this.txt_debit.Location = new System.Drawing.Point(625, 7);
            this.txt_debit.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.txt_debit.Name = "txt_debit";
            this.txt_debit.PasswordChar = '\0';
            this.txt_debit.PlaceholderText = "";
            this.txt_debit.ReadOnly = true;
            this.txt_debit.SelectedText = "";
            this.txt_debit.ShadowDecoration.Color = System.Drawing.Color.Silver;
            this.txt_debit.Size = new System.Drawing.Size(113, 31);
            this.txt_debit.TabIndex = 10;
            this.txt_debit.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // txt_credit
            // 
            this.txt_credit.BackColor = System.Drawing.Color.Transparent;
            this.txt_credit.BorderColor = System.Drawing.Color.Gray;
            this.txt_credit.BorderRadius = 6;
            this.txt_credit.BorderThickness = 2;
            this.txt_credit.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.txt_credit.DefaultText = "";
            this.txt_credit.DisabledState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(208)))), ((int)(((byte)(208)))), ((int)(((byte)(208)))));
            this.txt_credit.DisabledState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(226)))), ((int)(((byte)(226)))), ((int)(((byte)(226)))));
            this.txt_credit.DisabledState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(138)))), ((int)(((byte)(138)))), ((int)(((byte)(138)))));
            this.txt_credit.DisabledState.PlaceholderForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(138)))), ((int)(((byte)(138)))), ((int)(((byte)(138)))));
            this.txt_credit.FillColor = System.Drawing.Color.WhiteSmoke;
            this.txt_credit.FocusedState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(148)))), ((int)(((byte)(255)))));
            this.txt_credit.Font = new System.Drawing.Font("Arial Narrow", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txt_credit.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.txt_credit.HoverState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(148)))), ((int)(((byte)(255)))));
            this.txt_credit.Location = new System.Drawing.Point(744, 7);
            this.txt_credit.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.txt_credit.Name = "txt_credit";
            this.txt_credit.PasswordChar = '\0';
            this.txt_credit.PlaceholderText = "";
            this.txt_credit.ReadOnly = true;
            this.txt_credit.SelectedText = "";
            this.txt_credit.ShadowDecoration.Color = System.Drawing.Color.Silver;
            this.txt_credit.Size = new System.Drawing.Size(115, 31);
            this.txt_credit.TabIndex = 9;
            this.txt_credit.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // txt_balance
            // 
            this.txt_balance.BackColor = System.Drawing.Color.Transparent;
            this.txt_balance.BorderColor = System.Drawing.Color.Gray;
            this.txt_balance.BorderRadius = 6;
            this.txt_balance.BorderThickness = 2;
            this.txt_balance.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.txt_balance.DefaultText = "";
            this.txt_balance.DisabledState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(208)))), ((int)(((byte)(208)))), ((int)(((byte)(208)))));
            this.txt_balance.DisabledState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(226)))), ((int)(((byte)(226)))), ((int)(((byte)(226)))));
            this.txt_balance.DisabledState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(138)))), ((int)(((byte)(138)))), ((int)(((byte)(138)))));
            this.txt_balance.DisabledState.PlaceholderForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(138)))), ((int)(((byte)(138)))), ((int)(((byte)(138)))));
            this.txt_balance.FillColor = System.Drawing.Color.WhiteSmoke;
            this.txt_balance.FocusedState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(148)))), ((int)(((byte)(255)))));
            this.txt_balance.Font = new System.Drawing.Font("Arial Narrow", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txt_balance.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.txt_balance.HoverState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(148)))), ((int)(((byte)(255)))));
            this.txt_balance.Location = new System.Drawing.Point(867, 7);
            this.txt_balance.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.txt_balance.Name = "txt_balance";
            this.txt_balance.PasswordChar = '\0';
            this.txt_balance.PlaceholderText = "";
            this.txt_balance.ReadOnly = true;
            this.txt_balance.SelectedText = "";
            this.txt_balance.ShadowDecoration.Color = System.Drawing.Color.Silver;
            this.txt_balance.Size = new System.Drawing.Size(191, 31);
            this.txt_balance.TabIndex = 8;
            this.txt_balance.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // lstAccounts
            // 
            this.lstAccounts.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lstAccounts.FormattingEnabled = true;
            this.lstAccounts.ItemHeight = 18;
            this.lstAccounts.Location = new System.Drawing.Point(322, 76);
            this.lstAccounts.Name = "lstAccounts";
            this.lstAccounts.Size = new System.Drawing.Size(445, 274);
            this.lstAccounts.TabIndex = 104;
            // 
            // AccountsLegerForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(1080, 617);
            this.Controls.Add(this.lstAccounts);
            this.Controls.Add(this.guna2GradientPanel1);
            this.Controls.Add(this.dataGridView2);
            this.Controls.Add(this.guna2ShadowPanel1);
            this.MaximizeBox = false;
            this.Name = "AccountsLegerForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.Manual;
            this.Text = "AccountsLegerForm";
            this.Load += new System.EventHandler(this.AccountsLegerForm_Load);
            this.guna2ShadowPanel1.ResumeLayout(false);
            this.guna2ShadowPanel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.guna2PictureBox1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView2)).EndInit();
            this.guna2GradientPanel1.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private Guna.UI2.WinForms.Guna2ShadowPanel guna2ShadowPanel1;
        private System.Windows.Forms.Label label1;
        private Guna.UI2.WinForms.Guna2PictureBox guna2PictureBox1;
        private Guna.UI2.WinForms.Guna2TextBox txt_accountId;
        private System.Windows.Forms.Label label2;
        private Guna.UI2.WinForms.Guna2TextBox txt_accountName;
        private Guna.UI2.WinForms.Guna2CustomCheckBox chk_date;
        private System.Windows.Forms.DateTimePicker dtmStart;
        private System.Windows.Forms.DateTimePicker dtmEnd;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Label to;
        private Guna.UI2.WinForms.Guna2Button btn_search;
        private System.Windows.Forms.DataGridView dataGridView2;
        private System.Windows.Forms.DataGridViewTextBoxColumn date;
        private System.Windows.Forms.DataGridViewTextBoxColumn TransactionID;
        private System.Windows.Forms.DataGridViewTextBoxColumn description;
        private System.Windows.Forms.DataGridViewTextBoxColumn Debit;
        private System.Windows.Forms.DataGridViewTextBoxColumn Credit;
        private System.Windows.Forms.DataGridViewTextBoxColumn balance;
        private System.Windows.Forms.DataGridViewTextBoxColumn status;
        private Guna.UI2.WinForms.Guna2GradientPanel guna2GradientPanel1;
        private Guna.UI2.WinForms.Guna2TextBox txt_debit;
        private Guna.UI2.WinForms.Guna2TextBox txt_credit;
        private Guna.UI2.WinForms.Guna2TextBox txt_balance;
        private System.Windows.Forms.ListBox lstAccounts;
    }
}