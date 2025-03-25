namespace ALA_Accounting.Addition
{
    partial class AccountsOpeningBalances
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle9 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle10 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle11 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle12 = new System.Windows.Forms.DataGridViewCellStyle();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(AccountsOpeningBalances));
            this.dataGridView2 = new System.Windows.Forms.DataGridView();
            this.AccountsOpeningBalanceID = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.AccountID = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.AccountName = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Debit = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Credit = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.label8 = new System.Windows.Forms.Label();
            this.btn_back = new Guna.UI2.WinForms.Guna2Button();
            this.btn_forward = new Guna.UI2.WinForms.Guna2Button();
            this.txt_openingId = new Guna.UI2.WinForms.Guna2TextBox();
            this.label7 = new System.Windows.Forms.Label();
            this.txt_credit = new Guna.UI2.WinForms.Guna2TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.txt_AccountName = new Guna.UI2.WinForms.Guna2TextBox();
            this.txt_accountId = new Guna.UI2.WinForms.Guna2TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.btn_delete = new Guna.UI2.WinForms.Guna2Button();
            this.btn_cancel = new Guna.UI2.WinForms.Guna2Button();
            this.btn_addNew = new Guna.UI2.WinForms.Guna2Button();
            this.btn_save = new Guna.UI2.WinForms.Guna2Button();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.label1 = new System.Windows.Forms.Label();
            this.guna2GroupBox1 = new Guna.UI2.WinForms.Guna2GroupBox();
            this.txt_debit = new Guna.UI2.WinForms.Guna2TextBox();
            this.guna2ShadowPanel1 = new Guna.UI2.WinForms.Guna2ShadowPanel();
            this.lst_Accounts = new System.Windows.Forms.ListBox();
            this.btn_importBalances = new Guna.UI2.WinForms.Guna2Button();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.guna2GroupBox1.SuspendLayout();
            this.guna2ShadowPanel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // dataGridView2
            // 
            dataGridViewCellStyle9.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle9.BackColor = System.Drawing.Color.MintCream;
            dataGridViewCellStyle9.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle9.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            dataGridViewCellStyle9.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle9.SelectionForeColor = System.Drawing.Color.White;
            this.dataGridView2.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle9;
            this.dataGridView2.BackgroundColor = System.Drawing.Color.White;
            dataGridViewCellStyle10.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle10.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle10.Font = new System.Drawing.Font("Arial", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle10.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle10.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle10.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle10.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dataGridView2.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle10;
            this.dataGridView2.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView2.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.AccountsOpeningBalanceID,
            this.AccountID,
            this.AccountName,
            this.Debit,
            this.Credit});
            dataGridViewCellStyle11.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle11.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle11.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle11.ForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle11.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle11.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle11.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.dataGridView2.DefaultCellStyle = dataGridViewCellStyle11;
            this.dataGridView2.Location = new System.Drawing.Point(12, 293);
            this.dataGridView2.MultiSelect = false;
            this.dataGridView2.Name = "dataGridView2";
            this.dataGridView2.ReadOnly = true;
            dataGridViewCellStyle12.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle12.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle12.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle12.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle12.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle12.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle12.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dataGridView2.RowHeadersDefaultCellStyle = dataGridViewCellStyle12;
            this.dataGridView2.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dataGridView2.Size = new System.Drawing.Size(1058, 330);
            this.dataGridView2.TabIndex = 101;
            this.dataGridView2.CellDoubleClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dataGridView2_CellDoubleClick);
            // 
            // AccountsOpeningBalanceID
            // 
            this.AccountsOpeningBalanceID.HeaderText = "اوپننگ آئی ڈی";
            this.AccountsOpeningBalanceID.Name = "AccountsOpeningBalanceID";
            this.AccountsOpeningBalanceID.ReadOnly = true;
            this.AccountsOpeningBalanceID.Width = 130;
            // 
            // AccountID
            // 
            this.AccountID.HeaderText = "اکاؤنٹ آئی ڈی";
            this.AccountID.Name = "AccountID";
            this.AccountID.ReadOnly = true;
            this.AccountID.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.AccountID.Width = 130;
            // 
            // AccountName
            // 
            this.AccountName.HeaderText = "آئٹم نام";
            this.AccountName.Name = "AccountName";
            this.AccountName.ReadOnly = true;
            this.AccountName.Width = 400;
            // 
            // Debit
            // 
            this.Debit.HeaderText = "بنام";
            this.Debit.Name = "Debit";
            this.Debit.ReadOnly = true;
            this.Debit.Width = 170;
            // 
            // Credit
            // 
            this.Credit.HeaderText = "جمع";
            this.Credit.Name = "Credit";
            this.Credit.ReadOnly = true;
            this.Credit.Width = 170;
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.BackColor = System.Drawing.SystemColors.ButtonHighlight;
            this.label8.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(128)))), ((int)(((byte)(128)))));
            this.label8.Location = new System.Drawing.Point(412, 52);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(116, 24);
            this.label8.TabIndex = 54;
            this.label8.Text = "اوپننگ آئی ڈی";
            // 
            // btn_back
            // 
            this.btn_back.DisabledState.BorderColor = System.Drawing.Color.DarkGray;
            this.btn_back.DisabledState.CustomBorderColor = System.Drawing.Color.DarkGray;
            this.btn_back.DisabledState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(169)))), ((int)(((byte)(169)))), ((int)(((byte)(169)))));
            this.btn_back.DisabledState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(141)))), ((int)(((byte)(141)))), ((int)(((byte)(141)))));
            this.btn_back.FillColor = System.Drawing.SystemColors.Control;
            this.btn_back.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.btn_back.ForeColor = System.Drawing.Color.White;
            this.btn_back.Image = ((System.Drawing.Image)(resources.GetObject("btn_back.Image")));
            this.btn_back.ImageSize = new System.Drawing.Size(30, 30);
            this.btn_back.Location = new System.Drawing.Point(203, 47);
            this.btn_back.Name = "btn_back";
            this.btn_back.Size = new System.Drawing.Size(46, 29);
            this.btn_back.TabIndex = 52;
            // 
            // btn_forward
            // 
            this.btn_forward.DisabledState.BorderColor = System.Drawing.Color.DarkGray;
            this.btn_forward.DisabledState.CustomBorderColor = System.Drawing.Color.DarkGray;
            this.btn_forward.DisabledState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(169)))), ((int)(((byte)(169)))), ((int)(((byte)(169)))));
            this.btn_forward.DisabledState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(141)))), ((int)(((byte)(141)))), ((int)(((byte)(141)))));
            this.btn_forward.FillColor = System.Drawing.SystemColors.Control;
            this.btn_forward.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.btn_forward.ForeColor = System.Drawing.Color.White;
            this.btn_forward.Image = ((System.Drawing.Image)(resources.GetObject("btn_forward.Image")));
            this.btn_forward.ImageSize = new System.Drawing.Size(30, 30);
            this.btn_forward.Location = new System.Drawing.Point(360, 47);
            this.btn_forward.Name = "btn_forward";
            this.btn_forward.Size = new System.Drawing.Size(46, 29);
            this.btn_forward.TabIndex = 53;
            // 
            // txt_openingId
            // 
            this.txt_openingId.BackColor = System.Drawing.Color.Transparent;
            this.txt_openingId.BorderRadius = 6;
            this.txt_openingId.BorderThickness = 2;
            this.txt_openingId.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.txt_openingId.DefaultText = "";
            this.txt_openingId.DisabledState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(208)))), ((int)(((byte)(208)))), ((int)(((byte)(208)))));
            this.txt_openingId.DisabledState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(226)))), ((int)(((byte)(226)))), ((int)(((byte)(226)))));
            this.txt_openingId.DisabledState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(138)))), ((int)(((byte)(138)))), ((int)(((byte)(138)))));
            this.txt_openingId.DisabledState.PlaceholderForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(138)))), ((int)(((byte)(138)))), ((int)(((byte)(138)))));
            this.txt_openingId.FillColor = System.Drawing.Color.WhiteSmoke;
            this.txt_openingId.FocusedState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(148)))), ((int)(((byte)(255)))));
            this.txt_openingId.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txt_openingId.ForeColor = System.Drawing.Color.Blue;
            this.txt_openingId.HoverState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(148)))), ((int)(((byte)(255)))));
            this.txt_openingId.Location = new System.Drawing.Point(254, 45);
            this.txt_openingId.Multiline = true;
            this.txt_openingId.Name = "txt_openingId";
            this.txt_openingId.PasswordChar = '\0';
            this.txt_openingId.PlaceholderText = "";
            this.txt_openingId.SelectedText = "";
            this.txt_openingId.ShadowDecoration.Color = System.Drawing.Color.Silver;
            this.txt_openingId.Size = new System.Drawing.Size(102, 32);
            this.txt_openingId.TabIndex = 16;
            this.txt_openingId.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.BackColor = System.Drawing.SystemColors.ButtonHighlight;
            this.label7.ForeColor = System.Drawing.Color.Green;
            this.label7.Location = new System.Drawing.Point(177, 135);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(40, 24);
            this.label7.TabIndex = 14;
            this.label7.Text = "جمع";
            // 
            // txt_credit
            // 
            this.txt_credit.BackColor = System.Drawing.Color.Transparent;
            this.txt_credit.BorderColor = System.Drawing.Color.Green;
            this.txt_credit.BorderRadius = 6;
            this.txt_credit.BorderThickness = 2;
            this.txt_credit.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.txt_credit.DefaultText = "";
            this.txt_credit.DisabledState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(208)))), ((int)(((byte)(208)))), ((int)(((byte)(208)))));
            this.txt_credit.DisabledState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(226)))), ((int)(((byte)(226)))), ((int)(((byte)(226)))));
            this.txt_credit.DisabledState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(138)))), ((int)(((byte)(138)))), ((int)(((byte)(138)))));
            this.txt_credit.DisabledState.PlaceholderForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(138)))), ((int)(((byte)(138)))), ((int)(((byte)(138)))));
            this.txt_credit.FocusedState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(148)))), ((int)(((byte)(255)))));
            this.txt_credit.Font = new System.Drawing.Font("Segoe UI Semibold", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txt_credit.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(192)))), ((int)(((byte)(0)))));
            this.txt_credit.HoverState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(148)))), ((int)(((byte)(255)))));
            this.txt_credit.Location = new System.Drawing.Point(9, 123);
            this.txt_credit.Name = "txt_credit";
            this.txt_credit.PasswordChar = '\0';
            this.txt_credit.PlaceholderText = "";
            this.txt_credit.SelectedText = "";
            this.txt_credit.ShadowDecoration.Color = System.Drawing.Color.Silver;
            this.txt_credit.Size = new System.Drawing.Size(163, 45);
            this.txt_credit.TabIndex = 3;
            this.txt_credit.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.txt_credit.TextChanged += new System.EventHandler(this.txt_credit_TextChanged);
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.BackColor = System.Drawing.SystemColors.ButtonHighlight;
            this.label5.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.label5.Location = new System.Drawing.Point(412, 133);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(35, 24);
            this.label5.TabIndex = 8;
            this.label5.Text = "بنام";
            // 
            // txt_AccountName
            // 
            this.txt_AccountName.BackColor = System.Drawing.Color.Transparent;
            this.txt_AccountName.BorderRadius = 6;
            this.txt_AccountName.BorderThickness = 2;
            this.txt_AccountName.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.txt_AccountName.DefaultText = "";
            this.txt_AccountName.DisabledState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(208)))), ((int)(((byte)(208)))), ((int)(((byte)(208)))));
            this.txt_AccountName.DisabledState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(226)))), ((int)(((byte)(226)))), ((int)(((byte)(226)))));
            this.txt_AccountName.DisabledState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(138)))), ((int)(((byte)(138)))), ((int)(((byte)(138)))));
            this.txt_AccountName.DisabledState.PlaceholderForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(138)))), ((int)(((byte)(138)))), ((int)(((byte)(138)))));
            this.txt_AccountName.FocusedState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(148)))), ((int)(((byte)(255)))));
            this.txt_AccountName.Font = new System.Drawing.Font("Segoe UI Semibold", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txt_AccountName.HoverState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(148)))), ((int)(((byte)(255)))));
            this.txt_AccountName.Location = new System.Drawing.Point(9, 83);
            this.txt_AccountName.Name = "txt_AccountName";
            this.txt_AccountName.PasswordChar = '\0';
            this.txt_AccountName.PlaceholderText = "";
            this.txt_AccountName.SelectedText = "";
            this.txt_AccountName.ShadowDecoration.Color = System.Drawing.Color.Silver;
            this.txt_AccountName.Size = new System.Drawing.Size(289, 31);
            this.txt_AccountName.TabIndex = 1;
            this.txt_AccountName.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
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
            this.txt_accountId.HoverState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(148)))), ((int)(((byte)(255)))));
            this.txt_accountId.Location = new System.Drawing.Point(304, 83);
            this.txt_accountId.Name = "txt_accountId";
            this.txt_accountId.PasswordChar = '\0';
            this.txt_accountId.PlaceholderText = "";
            this.txt_accountId.SelectedText = "";
            this.txt_accountId.ShadowDecoration.Color = System.Drawing.Color.Silver;
            this.txt_accountId.Size = new System.Drawing.Size(102, 31);
            this.txt_accountId.TabIndex = 0;
            this.txt_accountId.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.txt_accountId.TextChanged += new System.EventHandler(this.txt_accountId_TextChanged);
            this.txt_accountId.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txt_accountId_KeyDown);
            this.txt_accountId.Leave += new System.EventHandler(this.txt_accountId_Leave);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.BackColor = System.Drawing.SystemColors.ButtonHighlight;
            this.label2.Location = new System.Drawing.Point(412, 86);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(113, 24);
            this.label2.TabIndex = 0;
            this.label2.Text = "اکاؤنٹ آئی ڈی";
            // 
            // btn_delete
            // 
            this.btn_delete.BorderRadius = 4;
            this.btn_delete.DisabledState.BorderColor = System.Drawing.Color.DarkGray;
            this.btn_delete.DisabledState.CustomBorderColor = System.Drawing.Color.DarkGray;
            this.btn_delete.DisabledState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(169)))), ((int)(((byte)(169)))), ((int)(((byte)(169)))));
            this.btn_delete.DisabledState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(141)))), ((int)(((byte)(141)))), ((int)(((byte)(141)))));
            this.btn_delete.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(192)))), ((int)(((byte)(192)))));
            this.btn_delete.Font = new System.Drawing.Font("Arial", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btn_delete.ForeColor = System.Drawing.Color.Gray;
            this.btn_delete.Image = ((System.Drawing.Image)(resources.GetObject("btn_delete.Image")));
            this.btn_delete.ImageAlign = System.Windows.Forms.HorizontalAlignment.Left;
            this.btn_delete.ImageOffset = new System.Drawing.Point(-3, 0);
            this.btn_delete.ImageSize = new System.Drawing.Size(38, 38);
            this.btn_delete.Location = new System.Drawing.Point(962, 10);
            this.btn_delete.Name = "btn_delete";
            this.btn_delete.Size = new System.Drawing.Size(89, 52);
            this.btn_delete.TabIndex = 1;
            this.btn_delete.Text = "ڈیلیٹ";
            this.btn_delete.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.btn_delete.TextOffset = new System.Drawing.Point(4, 0);
            this.btn_delete.Click += new System.EventHandler(this.btn_delete_Click);
            // 
            // btn_cancel
            // 
            this.btn_cancel.BorderRadius = 4;
            this.btn_cancel.DisabledState.BorderColor = System.Drawing.Color.DarkGray;
            this.btn_cancel.DisabledState.CustomBorderColor = System.Drawing.Color.DarkGray;
            this.btn_cancel.DisabledState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(169)))), ((int)(((byte)(169)))), ((int)(((byte)(169)))));
            this.btn_cancel.DisabledState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(141)))), ((int)(((byte)(141)))), ((int)(((byte)(141)))));
            this.btn_cancel.FillColor = System.Drawing.Color.Thistle;
            this.btn_cancel.Font = new System.Drawing.Font("Arial", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btn_cancel.ForeColor = System.Drawing.Color.DimGray;
            this.btn_cancel.Image = ((System.Drawing.Image)(resources.GetObject("btn_cancel.Image")));
            this.btn_cancel.ImageAlign = System.Windows.Forms.HorizontalAlignment.Left;
            this.btn_cancel.ImageOffset = new System.Drawing.Point(-3, 0);
            this.btn_cancel.ImageSize = new System.Drawing.Size(38, 38);
            this.btn_cancel.Location = new System.Drawing.Point(869, 10);
            this.btn_cancel.Name = "btn_cancel";
            this.btn_cancel.Size = new System.Drawing.Size(89, 52);
            this.btn_cancel.TabIndex = 2;
            this.btn_cancel.Text = "کینسل";
            this.btn_cancel.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.btn_cancel.TextOffset = new System.Drawing.Point(4, 0);
            this.btn_cancel.Click += new System.EventHandler(this.btn_cancel_Click);
            // 
            // btn_addNew
            // 
            this.btn_addNew.BorderRadius = 4;
            this.btn_addNew.DisabledState.BorderColor = System.Drawing.Color.DarkGray;
            this.btn_addNew.DisabledState.CustomBorderColor = System.Drawing.Color.DarkGray;
            this.btn_addNew.DisabledState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(169)))), ((int)(((byte)(169)))), ((int)(((byte)(169)))));
            this.btn_addNew.DisabledState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(141)))), ((int)(((byte)(141)))), ((int)(((byte)(141)))));
            this.btn_addNew.FillColor = System.Drawing.Color.DarkSeaGreen;
            this.btn_addNew.Font = new System.Drawing.Font("Arial", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btn_addNew.ForeColor = System.Drawing.Color.White;
            this.btn_addNew.Image = ((System.Drawing.Image)(resources.GetObject("btn_addNew.Image")));
            this.btn_addNew.ImageAlign = System.Windows.Forms.HorizontalAlignment.Left;
            this.btn_addNew.ImageOffset = new System.Drawing.Point(-3, 0);
            this.btn_addNew.ImageSize = new System.Drawing.Size(28, 28);
            this.btn_addNew.Location = new System.Drawing.Point(683, 10);
            this.btn_addNew.Name = "btn_addNew";
            this.btn_addNew.Size = new System.Drawing.Size(89, 52);
            this.btn_addNew.TabIndex = 3;
            this.btn_addNew.Text = "نیا ریکارڈ";
            this.btn_addNew.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.btn_addNew.TextOffset = new System.Drawing.Point(4, 0);
            this.btn_addNew.Click += new System.EventHandler(this.btn_addNew_Click);
            // 
            // btn_save
            // 
            this.btn_save.BorderRadius = 4;
            this.btn_save.DisabledState.BorderColor = System.Drawing.Color.DarkGray;
            this.btn_save.DisabledState.CustomBorderColor = System.Drawing.Color.DarkGray;
            this.btn_save.DisabledState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(169)))), ((int)(((byte)(169)))), ((int)(((byte)(169)))));
            this.btn_save.DisabledState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(141)))), ((int)(((byte)(141)))), ((int)(((byte)(141)))));
            this.btn_save.FillColor = System.Drawing.Color.Green;
            this.btn_save.Font = new System.Drawing.Font("Arial", 20.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btn_save.ForeColor = System.Drawing.Color.White;
            this.btn_save.Image = ((System.Drawing.Image)(resources.GetObject("btn_save.Image")));
            this.btn_save.ImageAlign = System.Windows.Forms.HorizontalAlignment.Left;
            this.btn_save.ImageOffset = new System.Drawing.Point(-3, 0);
            this.btn_save.ImageSize = new System.Drawing.Size(38, 38);
            this.btn_save.Location = new System.Drawing.Point(776, 10);
            this.btn_save.Name = "btn_save";
            this.btn_save.Size = new System.Drawing.Size(89, 52);
            this.btn_save.TabIndex = 0;
            this.btn_save.Text = "سیو";
            this.btn_save.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.btn_save.TextOffset = new System.Drawing.Point(4, 0);
            this.btn_save.Click += new System.EventHandler(this.btn_save_Click);
            // 
            // pictureBox1
            // 
            this.pictureBox1.Image = ((System.Drawing.Image)(resources.GetObject("pictureBox1.Image")));
            this.pictureBox1.Location = new System.Drawing.Point(12, 10);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(68, 46);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pictureBox1.TabIndex = 2;
            this.pictureBox1.TabStop = false;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Arial", 24F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.SystemColors.ControlDarkDark;
            this.label1.Location = new System.Drawing.Point(81, 17);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(246, 37);
            this.label1.TabIndex = 1;
            this.label1.Text = "اکاؤنٹ اوپننگ بیلنس";
            // 
            // guna2GroupBox1
            // 
            this.guna2GroupBox1.BorderThickness = 2;
            this.guna2GroupBox1.Controls.Add(this.txt_debit);
            this.guna2GroupBox1.Controls.Add(this.label8);
            this.guna2GroupBox1.Controls.Add(this.btn_back);
            this.guna2GroupBox1.Controls.Add(this.btn_forward);
            this.guna2GroupBox1.Controls.Add(this.txt_openingId);
            this.guna2GroupBox1.Controls.Add(this.label7);
            this.guna2GroupBox1.Controls.Add(this.txt_credit);
            this.guna2GroupBox1.Controls.Add(this.label5);
            this.guna2GroupBox1.Controls.Add(this.txt_AccountName);
            this.guna2GroupBox1.Controls.Add(this.txt_accountId);
            this.guna2GroupBox1.Controls.Add(this.label2);
            this.guna2GroupBox1.Font = new System.Drawing.Font("Arial", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.guna2GroupBox1.ForeColor = System.Drawing.Color.Gray;
            this.guna2GroupBox1.Location = new System.Drawing.Point(514, 90);
            this.guna2GroupBox1.Name = "guna2GroupBox1";
            this.guna2GroupBox1.ShadowDecoration.BorderRadius = 10;
            this.guna2GroupBox1.ShadowDecoration.Color = System.Drawing.Color.DimGray;
            this.guna2GroupBox1.ShadowDecoration.Enabled = true;
            this.guna2GroupBox1.ShadowDecoration.Shadow = new System.Windows.Forms.Padding(8);
            this.guna2GroupBox1.Size = new System.Drawing.Size(537, 177);
            this.guna2GroupBox1.TabIndex = 100;
            this.guna2GroupBox1.Text = " اوپننگ بیلنس ڈیٹیل";
            this.guna2GroupBox1.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // txt_debit
            // 
            this.txt_debit.BackColor = System.Drawing.Color.Transparent;
            this.txt_debit.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.txt_debit.BorderRadius = 6;
            this.txt_debit.BorderThickness = 2;
            this.txt_debit.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.txt_debit.DefaultText = "";
            this.txt_debit.DisabledState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(208)))), ((int)(((byte)(208)))), ((int)(((byte)(208)))));
            this.txt_debit.DisabledState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(226)))), ((int)(((byte)(226)))), ((int)(((byte)(226)))));
            this.txt_debit.DisabledState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(138)))), ((int)(((byte)(138)))), ((int)(((byte)(138)))));
            this.txt_debit.DisabledState.PlaceholderForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(138)))), ((int)(((byte)(138)))), ((int)(((byte)(138)))));
            this.txt_debit.FocusedState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(148)))), ((int)(((byte)(255)))));
            this.txt_debit.Font = new System.Drawing.Font("Segoe UI Semibold", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txt_debit.ForeColor = System.Drawing.Color.Red;
            this.txt_debit.HoverState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(148)))), ((int)(((byte)(255)))));
            this.txt_debit.Location = new System.Drawing.Point(243, 123);
            this.txt_debit.Name = "txt_debit";
            this.txt_debit.PasswordChar = '\0';
            this.txt_debit.PlaceholderText = "";
            this.txt_debit.SelectedText = "";
            this.txt_debit.ShadowDecoration.Color = System.Drawing.Color.Silver;
            this.txt_debit.Size = new System.Drawing.Size(163, 45);
            this.txt_debit.TabIndex = 2;
            this.txt_debit.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.txt_debit.TextChanged += new System.EventHandler(this.txt_debit_TextChanged_1);
            // 
            // guna2ShadowPanel1
            // 
            this.guna2ShadowPanel1.BackColor = System.Drawing.Color.Transparent;
            this.guna2ShadowPanel1.Controls.Add(this.btn_importBalances);
            this.guna2ShadowPanel1.Controls.Add(this.btn_delete);
            this.guna2ShadowPanel1.Controls.Add(this.btn_cancel);
            this.guna2ShadowPanel1.Controls.Add(this.btn_addNew);
            this.guna2ShadowPanel1.Controls.Add(this.btn_save);
            this.guna2ShadowPanel1.Controls.Add(this.pictureBox1);
            this.guna2ShadowPanel1.Controls.Add(this.label1);
            this.guna2ShadowPanel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.guna2ShadowPanel1.FillColor = System.Drawing.Color.White;
            this.guna2ShadowPanel1.Location = new System.Drawing.Point(0, 0);
            this.guna2ShadowPanel1.Name = "guna2ShadowPanel1";
            this.guna2ShadowPanel1.ShadowColor = System.Drawing.Color.Black;
            this.guna2ShadowPanel1.Size = new System.Drawing.Size(1070, 73);
            this.guna2ShadowPanel1.TabIndex = 99;
            // 
            // lst_Accounts
            // 
            this.lst_Accounts.Font = new System.Drawing.Font("Arial", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lst_Accounts.FormattingEnabled = true;
            this.lst_Accounts.ItemHeight = 17;
            this.lst_Accounts.Location = new System.Drawing.Point(523, 204);
            this.lst_Accounts.Name = "lst_Accounts";
            this.lst_Accounts.Size = new System.Drawing.Size(397, 191);
            this.lst_Accounts.TabIndex = 102;
            // 
            // btn_importBalances
            // 
            this.btn_importBalances.BorderRadius = 4;
            this.btn_importBalances.DisabledState.BorderColor = System.Drawing.Color.DarkGray;
            this.btn_importBalances.DisabledState.CustomBorderColor = System.Drawing.Color.DarkGray;
            this.btn_importBalances.DisabledState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(169)))), ((int)(((byte)(169)))), ((int)(((byte)(169)))));
            this.btn_importBalances.DisabledState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(141)))), ((int)(((byte)(141)))), ((int)(((byte)(141)))));
            this.btn_importBalances.FillColor = System.Drawing.Color.DodgerBlue;
            this.btn_importBalances.Font = new System.Drawing.Font("Arial", 14.25F);
            this.btn_importBalances.ForeColor = System.Drawing.Color.White;
            this.btn_importBalances.Image = ((System.Drawing.Image)(resources.GetObject("btn_importBalances.Image")));
            this.btn_importBalances.ImageAlign = System.Windows.Forms.HorizontalAlignment.Left;
            this.btn_importBalances.ImageOffset = new System.Drawing.Point(-3, 0);
            this.btn_importBalances.ImageSize = new System.Drawing.Size(35, 35);
            this.btn_importBalances.Location = new System.Drawing.Point(540, 10);
            this.btn_importBalances.Name = "btn_importBalances";
            this.btn_importBalances.Size = new System.Drawing.Size(137, 52);
            this.btn_importBalances.TabIndex = 4;
            this.btn_importBalances.Text = "اکاؤنٹ بیلنس درآمد کریں۔";
            this.btn_importBalances.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.btn_importBalances.TextOffset = new System.Drawing.Point(4, 0);
            this.btn_importBalances.Click += new System.EventHandler(this.btn_importBalances_Click);
            // 
            // AccountsOpeningBalances
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1070, 624);
            this.Controls.Add(this.lst_Accounts);
            this.Controls.Add(this.dataGridView2);
            this.Controls.Add(this.guna2GroupBox1);
            this.Controls.Add(this.guna2ShadowPanel1);
            this.Name = "AccountsOpeningBalances";
            this.StartPosition = System.Windows.Forms.FormStartPosition.Manual;
            this.Text = "AccountsOpeningBalances";
            this.Load += new System.EventHandler(this.AccountsOpeningBalances_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.guna2GroupBox1.ResumeLayout(false);
            this.guna2GroupBox1.PerformLayout();
            this.guna2ShadowPanel1.ResumeLayout(false);
            this.guna2ShadowPanel1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.DataGridView dataGridView2;
        private System.Windows.Forms.Label label8;
        private Guna.UI2.WinForms.Guna2Button btn_back;
        private Guna.UI2.WinForms.Guna2Button btn_forward;
        private Guna.UI2.WinForms.Guna2TextBox txt_openingId;
        private System.Windows.Forms.Label label7;
        private Guna.UI2.WinForms.Guna2TextBox txt_credit;
        private System.Windows.Forms.Label label5;
        private Guna.UI2.WinForms.Guna2TextBox txt_AccountName;
        private Guna.UI2.WinForms.Guna2TextBox txt_accountId;
        private System.Windows.Forms.Label label2;
        private Guna.UI2.WinForms.Guna2Button btn_delete;
        private Guna.UI2.WinForms.Guna2Button btn_cancel;
        private Guna.UI2.WinForms.Guna2Button btn_addNew;
        private Guna.UI2.WinForms.Guna2Button btn_save;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.Label label1;
        private Guna.UI2.WinForms.Guna2GroupBox guna2GroupBox1;
        private Guna.UI2.WinForms.Guna2ShadowPanel guna2ShadowPanel1;
        private System.Windows.Forms.DataGridViewTextBoxColumn AccountsOpeningBalanceID;
        private System.Windows.Forms.DataGridViewTextBoxColumn AccountID;
        private System.Windows.Forms.DataGridViewTextBoxColumn AccountName;
        private System.Windows.Forms.DataGridViewTextBoxColumn Debit;
        private System.Windows.Forms.DataGridViewTextBoxColumn Credit;
        private Guna.UI2.WinForms.Guna2TextBox txt_debit;
        private System.Windows.Forms.ListBox lst_Accounts;
        private Guna.UI2.WinForms.Guna2Button btn_importBalances;
    }
}