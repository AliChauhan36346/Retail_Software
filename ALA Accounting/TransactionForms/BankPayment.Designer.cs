namespace ALA_Accounting.TransactionForms
{
    partial class BankPayment
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(BankPayment));
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            this.label8 = new System.Windows.Forms.Label();
            this.btn_forward = new Guna.UI2.WinForms.Guna2Button();
            this.txt_bankAccountBalance = new Guna.UI2.WinForms.Guna2TextBox();
            this.txt_bankAccountName = new Guna.UI2.WinForms.Guna2TextBox();
            this.txt_bankAccount = new Guna.UI2.WinForms.Guna2TextBox();
            this.btn_back = new Guna.UI2.WinForms.Guna2Button();
            this.txt_bankPaymentId = new Guna.UI2.WinForms.Guna2TextBox();
            this.guna2PictureBox1 = new Guna.UI2.WinForms.Guna2PictureBox();
            this.btn_newCustomer = new Guna.UI2.WinForms.Guna2Button();
            this.btn_printSetting = new Guna.UI2.WinForms.Guna2Button();
            this.btn_delete = new Guna.UI2.WinForms.Guna2Button();
            this.btn_cancel = new Guna.UI2.WinForms.Guna2Button();
            this.btn_addNew = new Guna.UI2.WinForms.Guna2Button();
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.bankPaymentId = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.date = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.accountId = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.accountName = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.bankAccountId = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.amount = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.chequeNumber = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.chequeDate = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.description = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.guna2GroupBox1 = new Guna.UI2.WinForms.Guna2GroupBox();
            this.lstAccounts = new System.Windows.Forms.ListBox();
            this.txt_amount = new Guna.UI2.WinForms.Guna2TextBox();
            this.label6 = new System.Windows.Forms.Label();
            this.txt_description = new Guna.UI2.WinForms.Guna2TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.txt_accountName = new Guna.UI2.WinForms.Guna2TextBox();
            this.txt_accountBalance = new Guna.UI2.WinForms.Guna2TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.txt_accountId = new Guna.UI2.WinForms.Guna2TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.btn_save = new Guna.UI2.WinForms.Guna2Button();
            this.btn_print = new Guna.UI2.WinForms.Guna2Button();
            this.label7 = new System.Windows.Forms.Label();
            this.label9 = new System.Windows.Forms.Label();
            this.guna2ShadowPanel1 = new Guna.UI2.WinForms.Guna2ShadowPanel();
            this.label1 = new System.Windows.Forms.Label();
            this.txt_chequeNo = new Guna.UI2.WinForms.Guna2TextBox();
            this.txt_chequeDate = new Guna.UI2.WinForms.Guna2TextBox();
            this.label10 = new System.Windows.Forms.Label();
            this.label11 = new System.Windows.Forms.Label();
            this.label12 = new System.Windows.Forms.Label();
            this.lstBankAccount = new System.Windows.Forms.ListBox();
            this.dtm_paymentDate = new System.Windows.Forms.DateTimePicker();
            ((System.ComponentModel.ISupportInitialize)(this.guna2PictureBox1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            this.guna2GroupBox1.SuspendLayout();
            this.guna2ShadowPanel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.BackColor = System.Drawing.SystemColors.ButtonFace;
            this.label8.Font = new System.Drawing.Font("Arial", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label8.ForeColor = System.Drawing.SystemColors.ControlDarkDark;
            this.label8.Location = new System.Drawing.Point(65, 142);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(48, 24);
            this.label8.TabIndex = 75;
            this.label8.Text = "تاریخ";
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
            this.btn_forward.Location = new System.Drawing.Point(281, 96);
            this.btn_forward.Name = "btn_forward";
            this.btn_forward.Size = new System.Drawing.Size(46, 29);
            this.btn_forward.TabIndex = 77;
            this.btn_forward.Click += new System.EventHandler(this.btn_forward_Click);
            // 
            // txt_bankAccountBalance
            // 
            this.txt_bankAccountBalance.BackColor = System.Drawing.Color.Transparent;
            this.txt_bankAccountBalance.BorderRadius = 6;
            this.txt_bankAccountBalance.BorderThickness = 2;
            this.txt_bankAccountBalance.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.txt_bankAccountBalance.DefaultText = "";
            this.txt_bankAccountBalance.DisabledState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(208)))), ((int)(((byte)(208)))), ((int)(((byte)(208)))));
            this.txt_bankAccountBalance.DisabledState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(226)))), ((int)(((byte)(226)))), ((int)(((byte)(226)))));
            this.txt_bankAccountBalance.DisabledState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(138)))), ((int)(((byte)(138)))), ((int)(((byte)(138)))));
            this.txt_bankAccountBalance.DisabledState.PlaceholderForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(138)))), ((int)(((byte)(138)))), ((int)(((byte)(138)))));
            this.txt_bankAccountBalance.FocusedState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(148)))), ((int)(((byte)(255)))));
            this.txt_bankAccountBalance.Font = new System.Drawing.Font("Segoe UI Semibold", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txt_bankAccountBalance.ForeColor = System.Drawing.Color.Red;
            this.txt_bankAccountBalance.HoverState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(148)))), ((int)(((byte)(255)))));
            this.txt_bankAccountBalance.Location = new System.Drawing.Point(327, 138);
            this.txt_bankAccountBalance.Name = "txt_bankAccountBalance";
            this.txt_bankAccountBalance.PasswordChar = '\0';
            this.txt_bankAccountBalance.PlaceholderText = "";
            this.txt_bankAccountBalance.ReadOnly = true;
            this.txt_bankAccountBalance.SelectedText = "";
            this.txt_bankAccountBalance.ShadowDecoration.Color = System.Drawing.Color.Silver;
            this.txt_bankAccountBalance.Size = new System.Drawing.Size(145, 36);
            this.txt_bankAccountBalance.TabIndex = 83;
            // 
            // txt_bankAccountName
            // 
            this.txt_bankAccountName.BackColor = System.Drawing.Color.Transparent;
            this.txt_bankAccountName.BorderRadius = 6;
            this.txt_bankAccountName.BorderThickness = 2;
            this.txt_bankAccountName.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.txt_bankAccountName.DefaultText = "";
            this.txt_bankAccountName.DisabledState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(208)))), ((int)(((byte)(208)))), ((int)(((byte)(208)))));
            this.txt_bankAccountName.DisabledState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(226)))), ((int)(((byte)(226)))), ((int)(((byte)(226)))));
            this.txt_bankAccountName.DisabledState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(138)))), ((int)(((byte)(138)))), ((int)(((byte)(138)))));
            this.txt_bankAccountName.DisabledState.PlaceholderForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(138)))), ((int)(((byte)(138)))), ((int)(((byte)(138)))));
            this.txt_bankAccountName.FocusedState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(148)))), ((int)(((byte)(255)))));
            this.txt_bankAccountName.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.txt_bankAccountName.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.txt_bankAccountName.HoverState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(148)))), ((int)(((byte)(255)))));
            this.txt_bankAccountName.Location = new System.Drawing.Point(220, 182);
            this.txt_bankAccountName.Name = "txt_bankAccountName";
            this.txt_bankAccountName.PasswordChar = '\0';
            this.txt_bankAccountName.PlaceholderText = "";
            this.txt_bankAccountName.ReadOnly = true;
            this.txt_bankAccountName.SelectedText = "";
            this.txt_bankAccountName.ShadowDecoration.Color = System.Drawing.Color.Silver;
            this.txt_bankAccountName.Size = new System.Drawing.Size(252, 34);
            this.txt_bankAccountName.TabIndex = 81;
            // 
            // txt_bankAccount
            // 
            this.txt_bankAccount.BackColor = System.Drawing.Color.Transparent;
            this.txt_bankAccount.BorderRadius = 6;
            this.txt_bankAccount.BorderThickness = 2;
            this.txt_bankAccount.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.txt_bankAccount.DefaultText = "";
            this.txt_bankAccount.DisabledState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(208)))), ((int)(((byte)(208)))), ((int)(((byte)(208)))));
            this.txt_bankAccount.DisabledState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(226)))), ((int)(((byte)(226)))), ((int)(((byte)(226)))));
            this.txt_bankAccount.DisabledState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(138)))), ((int)(((byte)(138)))), ((int)(((byte)(138)))));
            this.txt_bankAccount.DisabledState.PlaceholderForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(138)))), ((int)(((byte)(138)))), ((int)(((byte)(138)))));
            this.txt_bankAccount.FocusedState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(148)))), ((int)(((byte)(255)))));
            this.txt_bankAccount.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.txt_bankAccount.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.txt_bankAccount.HoverState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(148)))), ((int)(((byte)(255)))));
            this.txt_bankAccount.Location = new System.Drawing.Point(117, 182);
            this.txt_bankAccount.Name = "txt_bankAccount";
            this.txt_bankAccount.PasswordChar = '\0';
            this.txt_bankAccount.PlaceholderText = "";
            this.txt_bankAccount.SelectedText = "";
            this.txt_bankAccount.ShadowDecoration.Color = System.Drawing.Color.Silver;
            this.txt_bankAccount.Size = new System.Drawing.Size(101, 34);
            this.txt_bankAccount.TabIndex = 79;
            this.txt_bankAccount.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.txt_bankAccount.TextChanged += new System.EventHandler(this.txt_bankAccount_TextChanged);
            this.txt_bankAccount.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txt_bankAccount_KeyDown);
            this.txt_bankAccount.Leave += new System.EventHandler(this.txt_bankAccount_Leave);
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
            this.btn_back.Location = new System.Drawing.Point(116, 96);
            this.btn_back.Name = "btn_back";
            this.btn_back.Size = new System.Drawing.Size(46, 29);
            this.btn_back.TabIndex = 76;
            this.btn_back.Click += new System.EventHandler(this.btn_back_Click);
            // 
            // txt_bankPaymentId
            // 
            this.txt_bankPaymentId.BackColor = System.Drawing.Color.Transparent;
            this.txt_bankPaymentId.BorderRadius = 6;
            this.txt_bankPaymentId.BorderThickness = 2;
            this.txt_bankPaymentId.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.txt_bankPaymentId.DefaultText = "";
            this.txt_bankPaymentId.DisabledState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(208)))), ((int)(((byte)(208)))), ((int)(((byte)(208)))));
            this.txt_bankPaymentId.DisabledState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(226)))), ((int)(((byte)(226)))), ((int)(((byte)(226)))));
            this.txt_bankPaymentId.DisabledState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(138)))), ((int)(((byte)(138)))), ((int)(((byte)(138)))));
            this.txt_bankPaymentId.DisabledState.PlaceholderForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(138)))), ((int)(((byte)(138)))), ((int)(((byte)(138)))));
            this.txt_bankPaymentId.FillColor = System.Drawing.Color.WhiteSmoke;
            this.txt_bankPaymentId.FocusedState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(148)))), ((int)(((byte)(255)))));
            this.txt_bankPaymentId.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.txt_bankPaymentId.ForeColor = System.Drawing.Color.Blue;
            this.txt_bankPaymentId.HoverState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(148)))), ((int)(((byte)(255)))));
            this.txt_bankPaymentId.Location = new System.Drawing.Point(165, 94);
            this.txt_bankPaymentId.Name = "txt_bankPaymentId";
            this.txt_bankPaymentId.PasswordChar = '\0';
            this.txt_bankPaymentId.PlaceholderText = "";
            this.txt_bankPaymentId.ReadOnly = true;
            this.txt_bankPaymentId.SelectedText = "";
            this.txt_bankPaymentId.ShadowDecoration.Color = System.Drawing.Color.Silver;
            this.txt_bankPaymentId.Size = new System.Drawing.Size(113, 33);
            this.txt_bankPaymentId.TabIndex = 72;
            this.txt_bankPaymentId.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // guna2PictureBox1
            // 
            this.guna2PictureBox1.Image = ((System.Drawing.Image)(resources.GetObject("guna2PictureBox1.Image")));
            this.guna2PictureBox1.ImageRotate = 0F;
            this.guna2PictureBox1.Location = new System.Drawing.Point(16, 10);
            this.guna2PictureBox1.Name = "guna2PictureBox1";
            this.guna2PictureBox1.Size = new System.Drawing.Size(55, 52);
            this.guna2PictureBox1.TabIndex = 9;
            this.guna2PictureBox1.TabStop = false;
            // 
            // btn_newCustomer
            // 
            this.btn_newCustomer.BorderRadius = 4;
            this.btn_newCustomer.DisabledState.BorderColor = System.Drawing.Color.DarkGray;
            this.btn_newCustomer.DisabledState.CustomBorderColor = System.Drawing.Color.DarkGray;
            this.btn_newCustomer.DisabledState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(169)))), ((int)(((byte)(169)))), ((int)(((byte)(169)))));
            this.btn_newCustomer.DisabledState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(141)))), ((int)(((byte)(141)))), ((int)(((byte)(141)))));
            this.btn_newCustomer.FillColor = System.Drawing.Color.PaleTurquoise;
            this.btn_newCustomer.Font = new System.Drawing.Font("Arial", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btn_newCustomer.ForeColor = System.Drawing.Color.Gray;
            this.btn_newCustomer.Image = ((System.Drawing.Image)(resources.GetObject("btn_newCustomer.Image")));
            this.btn_newCustomer.ImageAlign = System.Windows.Forms.HorizontalAlignment.Left;
            this.btn_newCustomer.ImageOffset = new System.Drawing.Point(-3, 0);
            this.btn_newCustomer.ImageSize = new System.Drawing.Size(38, 38);
            this.btn_newCustomer.Location = new System.Drawing.Point(383, 10);
            this.btn_newCustomer.Name = "btn_newCustomer";
            this.btn_newCustomer.Size = new System.Drawing.Size(89, 52);
            this.btn_newCustomer.TabIndex = 8;
            this.btn_newCustomer.Text = "نیا اکاؤنٹ";
            this.btn_newCustomer.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.btn_newCustomer.TextOffset = new System.Drawing.Point(4, 0);
            // 
            // btn_printSetting
            // 
            this.btn_printSetting.BorderRadius = 4;
            this.btn_printSetting.DisabledState.BorderColor = System.Drawing.Color.DarkGray;
            this.btn_printSetting.DisabledState.CustomBorderColor = System.Drawing.Color.DarkGray;
            this.btn_printSetting.DisabledState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(169)))), ((int)(((byte)(169)))), ((int)(((byte)(169)))));
            this.btn_printSetting.DisabledState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(141)))), ((int)(((byte)(141)))), ((int)(((byte)(141)))));
            this.btn_printSetting.FillColor = System.Drawing.Color.DarkKhaki;
            this.btn_printSetting.Font = new System.Drawing.Font("Arial", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btn_printSetting.ForeColor = System.Drawing.Color.White;
            this.btn_printSetting.Image = ((System.Drawing.Image)(resources.GetObject("btn_printSetting.Image")));
            this.btn_printSetting.ImageAlign = System.Windows.Forms.HorizontalAlignment.Left;
            this.btn_printSetting.ImageOffset = new System.Drawing.Point(-3, 0);
            this.btn_printSetting.ImageSize = new System.Drawing.Size(35, 35);
            this.btn_printSetting.Location = new System.Drawing.Point(872, 10);
            this.btn_printSetting.Name = "btn_printSetting";
            this.btn_printSetting.Size = new System.Drawing.Size(89, 52);
            this.btn_printSetting.TabIndex = 7;
            this.btn_printSetting.Text = "پرنٹ سیٹنگ";
            this.btn_printSetting.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.btn_printSetting.TextOffset = new System.Drawing.Point(4, 0);
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
            this.btn_delete.Location = new System.Drawing.Point(767, 10);
            this.btn_delete.Name = "btn_delete";
            this.btn_delete.Size = new System.Drawing.Size(89, 52);
            this.btn_delete.TabIndex = 6;
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
            this.btn_cancel.Location = new System.Drawing.Point(674, 10);
            this.btn_cancel.Name = "btn_cancel";
            this.btn_cancel.Size = new System.Drawing.Size(89, 52);
            this.btn_cancel.TabIndex = 5;
            this.btn_cancel.Text = "کینسل";
            this.btn_cancel.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.btn_cancel.TextOffset = new System.Drawing.Point(4, 0);
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
            this.btn_addNew.Location = new System.Drawing.Point(488, 10);
            this.btn_addNew.Name = "btn_addNew";
            this.btn_addNew.Size = new System.Drawing.Size(89, 52);
            this.btn_addNew.TabIndex = 3;
            this.btn_addNew.Text = "نیا ریکارڈ";
            this.btn_addNew.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.btn_addNew.TextOffset = new System.Drawing.Point(4, 0);
            this.btn_addNew.Click += new System.EventHandler(this.btn_addNew_Click);
            // 
            // dataGridView1
            // 
            this.dataGridView1.AllowUserToAddRows = false;
            this.dataGridView1.AllowUserToDeleteRows = false;
            dataGridViewCellStyle1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.dataGridView1.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle1;
            this.dataGridView1.BackgroundColor = System.Drawing.Color.White;
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle2.BackColor = System.Drawing.SystemColors.ControlLight;
            dataGridViewCellStyle2.Font = new System.Drawing.Font("Calibri", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle2.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle2.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle2.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dataGridView1.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle2;
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.bankPaymentId,
            this.date,
            this.accountId,
            this.accountName,
            this.bankAccountId,
            this.amount,
            this.chequeNumber,
            this.chequeDate,
            this.description});
            this.dataGridView1.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.dataGridView1.Location = new System.Drawing.Point(0, 381);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.ReadOnly = true;
            this.dataGridView1.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dataGridView1.Size = new System.Drawing.Size(1070, 243);
            this.dataGridView1.TabIndex = 82;
            this.dataGridView1.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dataGridView1_CellContentClick);
            this.dataGridView1.CellDoubleClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dataGridView1_CellDoubleClick);
            // 
            // bankPaymentId
            // 
            this.bankPaymentId.FillWeight = 120F;
            this.bankPaymentId.HeaderText = "بینک پیمنٹ آئی ڈی";
            this.bankPaymentId.Name = "bankPaymentId";
            this.bankPaymentId.ReadOnly = true;
            this.bankPaymentId.Width = 130;
            // 
            // date
            // 
            this.date.HeaderText = "تاریخ";
            this.date.Name = "date";
            this.date.ReadOnly = true;
            // 
            // accountId
            // 
            this.accountId.HeaderText = "اکاؤنٹ آئی ڈی";
            this.accountId.Name = "accountId";
            this.accountId.ReadOnly = true;
            // 
            // accountName
            // 
            this.accountName.HeaderText = "اکاؤنٹ نام";
            this.accountName.Name = "accountName";
            this.accountName.ReadOnly = true;
            this.accountName.Width = 260;
            // 
            // bankAccountId
            // 
            this.bankAccountId.FillWeight = 120F;
            this.bankAccountId.HeaderText = "بینک اکاؤنٹ آئی ڈی";
            this.bankAccountId.Name = "bankAccountId";
            this.bankAccountId.ReadOnly = true;
            this.bankAccountId.Width = 120;
            // 
            // amount
            // 
            this.amount.HeaderText = "رقم";
            this.amount.Name = "amount";
            this.amount.ReadOnly = true;
            this.amount.Width = 125;
            // 
            // chequeNumber
            // 
            this.chequeNumber.HeaderText = "چیک نمبر";
            this.chequeNumber.Name = "chequeNumber";
            this.chequeNumber.ReadOnly = true;
            // 
            // chequeDate
            // 
            this.chequeDate.HeaderText = "تاریخ چیک";
            this.chequeDate.Name = "chequeDate";
            this.chequeDate.ReadOnly = true;
            // 
            // description
            // 
            this.description.HeaderText = "تفصیل";
            this.description.Name = "description";
            this.description.ReadOnly = true;
            this.description.Width = 250;
            // 
            // guna2GroupBox1
            // 
            this.guna2GroupBox1.BorderThickness = 2;
            this.guna2GroupBox1.Controls.Add(this.lstAccounts);
            this.guna2GroupBox1.Controls.Add(this.txt_amount);
            this.guna2GroupBox1.Controls.Add(this.label6);
            this.guna2GroupBox1.Controls.Add(this.txt_description);
            this.guna2GroupBox1.Controls.Add(this.label5);
            this.guna2GroupBox1.Controls.Add(this.label4);
            this.guna2GroupBox1.Controls.Add(this.txt_accountName);
            this.guna2GroupBox1.Controls.Add(this.txt_accountBalance);
            this.guna2GroupBox1.Controls.Add(this.label3);
            this.guna2GroupBox1.Controls.Add(this.txt_accountId);
            this.guna2GroupBox1.Controls.Add(this.label2);
            this.guna2GroupBox1.Font = new System.Drawing.Font("Arial", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.guna2GroupBox1.ForeColor = System.Drawing.Color.Gray;
            this.guna2GroupBox1.Location = new System.Drawing.Point(581, 94);
            this.guna2GroupBox1.Name = "guna2GroupBox1";
            this.guna2GroupBox1.ShadowDecoration.BorderRadius = 10;
            this.guna2GroupBox1.ShadowDecoration.Color = System.Drawing.Color.DimGray;
            this.guna2GroupBox1.ShadowDecoration.Enabled = true;
            this.guna2GroupBox1.ShadowDecoration.Shadow = new System.Windows.Forms.Padding(8);
            this.guna2GroupBox1.Size = new System.Drawing.Size(472, 265);
            this.guna2GroupBox1.TabIndex = 78;
            this.guna2GroupBox1.Text = "اکاؤنٹ";
            this.guna2GroupBox1.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // lstAccounts
            // 
            this.lstAccounts.Font = new System.Drawing.Font("Arial", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lstAccounts.FormattingEnabled = true;
            this.lstAccounts.ItemHeight = 17;
            this.lstAccounts.Location = new System.Drawing.Point(14, 75);
            this.lstAccounts.Name = "lstAccounts";
            this.lstAccounts.Size = new System.Drawing.Size(345, 174);
            this.lstAccounts.TabIndex = 89;
            // 
            // txt_amount
            // 
            this.txt_amount.BackColor = System.Drawing.Color.Transparent;
            this.txt_amount.BorderRadius = 6;
            this.txt_amount.BorderThickness = 2;
            this.txt_amount.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.txt_amount.DefaultText = "";
            this.txt_amount.DisabledState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(208)))), ((int)(((byte)(208)))), ((int)(((byte)(208)))));
            this.txt_amount.DisabledState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(226)))), ((int)(((byte)(226)))), ((int)(((byte)(226)))));
            this.txt_amount.DisabledState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(138)))), ((int)(((byte)(138)))), ((int)(((byte)(138)))));
            this.txt_amount.DisabledState.PlaceholderForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(138)))), ((int)(((byte)(138)))), ((int)(((byte)(138)))));
            this.txt_amount.FocusedState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(148)))), ((int)(((byte)(255)))));
            this.txt_amount.Font = new System.Drawing.Font("Segoe UI Semibold", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txt_amount.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.txt_amount.HoverState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(148)))), ((int)(((byte)(255)))));
            this.txt_amount.Location = new System.Drawing.Point(14, 123);
            this.txt_amount.Name = "txt_amount";
            this.txt_amount.PasswordChar = '\0';
            this.txt_amount.PlaceholderText = "amount";
            this.txt_amount.SelectedText = "";
            this.txt_amount.ShadowDecoration.Color = System.Drawing.Color.Silver;
            this.txt_amount.Size = new System.Drawing.Size(345, 31);
            this.txt_amount.TabIndex = 91;
            this.txt_amount.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.BackColor = System.Drawing.SystemColors.ButtonHighlight;
            this.label6.Location = new System.Drawing.Point(371, 167);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(65, 24);
            this.label6.TabIndex = 10;
            this.label6.Text = "وضاحت";
            // 
            // txt_description
            // 
            this.txt_description.BackColor = System.Drawing.Color.Transparent;
            this.txt_description.BorderRadius = 6;
            this.txt_description.BorderThickness = 2;
            this.txt_description.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.txt_description.DefaultText = "";
            this.txt_description.DisabledState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(208)))), ((int)(((byte)(208)))), ((int)(((byte)(208)))));
            this.txt_description.DisabledState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(226)))), ((int)(((byte)(226)))), ((int)(((byte)(226)))));
            this.txt_description.DisabledState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(138)))), ((int)(((byte)(138)))), ((int)(((byte)(138)))));
            this.txt_description.DisabledState.PlaceholderForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(138)))), ((int)(((byte)(138)))), ((int)(((byte)(138)))));
            this.txt_description.FocusedState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(148)))), ((int)(((byte)(255)))));
            this.txt_description.Font = new System.Drawing.Font("Segoe UI Semibold", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txt_description.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.txt_description.HoverState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(148)))), ((int)(((byte)(255)))));
            this.txt_description.Location = new System.Drawing.Point(14, 165);
            this.txt_description.Multiline = true;
            this.txt_description.Name = "txt_description";
            this.txt_description.PasswordChar = '\0';
            this.txt_description.PlaceholderText = "Description";
            this.txt_description.SelectedText = "";
            this.txt_description.ShadowDecoration.Color = System.Drawing.Color.Silver;
            this.txt_description.Size = new System.Drawing.Size(345, 87);
            this.txt_description.TabIndex = 9;
            this.txt_description.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.BackColor = System.Drawing.SystemColors.ButtonHighlight;
            this.label5.ForeColor = System.Drawing.Color.Blue;
            this.label5.Location = new System.Drawing.Point(370, 126);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(33, 24);
            this.label5.TabIndex = 8;
            this.label5.Text = "رقم";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.BackColor = System.Drawing.SystemColors.ButtonHighlight;
            this.label4.Location = new System.Drawing.Point(370, 86);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(29, 24);
            this.label4.TabIndex = 5;
            this.label4.Text = "نام";
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
            this.txt_accountName.Location = new System.Drawing.Point(14, 83);
            this.txt_accountName.Name = "txt_accountName";
            this.txt_accountName.PasswordChar = '\0';
            this.txt_accountName.PlaceholderText = "Account Name";
            this.txt_accountName.SelectedText = "";
            this.txt_accountName.ShadowDecoration.Color = System.Drawing.Color.Silver;
            this.txt_accountName.Size = new System.Drawing.Size(345, 31);
            this.txt_accountName.TabIndex = 4;
            this.txt_accountName.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // txt_accountBalance
            // 
            this.txt_accountBalance.BackColor = System.Drawing.Color.Transparent;
            this.txt_accountBalance.BorderRadius = 6;
            this.txt_accountBalance.BorderThickness = 2;
            this.txt_accountBalance.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.txt_accountBalance.DefaultText = "";
            this.txt_accountBalance.DisabledState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(208)))), ((int)(((byte)(208)))), ((int)(((byte)(208)))));
            this.txt_accountBalance.DisabledState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(226)))), ((int)(((byte)(226)))), ((int)(((byte)(226)))));
            this.txt_accountBalance.DisabledState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(138)))), ((int)(((byte)(138)))), ((int)(((byte)(138)))));
            this.txt_accountBalance.DisabledState.PlaceholderForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(138)))), ((int)(((byte)(138)))), ((int)(((byte)(138)))));
            this.txt_accountBalance.FocusedState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(148)))), ((int)(((byte)(255)))));
            this.txt_accountBalance.Font = new System.Drawing.Font("Segoe UI Semibold", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txt_accountBalance.ForeColor = System.Drawing.Color.Red;
            this.txt_accountBalance.HoverState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(148)))), ((int)(((byte)(255)))));
            this.txt_accountBalance.Location = new System.Drawing.Point(14, 44);
            this.txt_accountBalance.Name = "txt_accountBalance";
            this.txt_accountBalance.PasswordChar = '\0';
            this.txt_accountBalance.PlaceholderText = "";
            this.txt_accountBalance.ReadOnly = true;
            this.txt_accountBalance.SelectedText = "";
            this.txt_accountBalance.ShadowDecoration.Color = System.Drawing.Color.Silver;
            this.txt_accountBalance.Size = new System.Drawing.Size(133, 31);
            this.txt_accountBalance.TabIndex = 3;
            this.txt_accountBalance.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.BackColor = System.Drawing.SystemColors.ButtonHighlight;
            this.label3.Location = new System.Drawing.Point(153, 48);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(52, 24);
            this.label3.TabIndex = 2;
            this.label3.Text = "بیلنس";
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
            this.txt_accountId.Location = new System.Drawing.Point(224, 44);
            this.txt_accountId.Name = "txt_accountId";
            this.txt_accountId.PasswordChar = '\0';
            this.txt_accountId.PlaceholderText = "Account ID";
            this.txt_accountId.SelectedText = "";
            this.txt_accountId.ShadowDecoration.Color = System.Drawing.Color.Silver;
            this.txt_accountId.Size = new System.Drawing.Size(135, 31);
            this.txt_accountId.TabIndex = 1;
            this.txt_accountId.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.txt_accountId.TextChanged += new System.EventHandler(this.txt_accountId_TextChanged);
            this.txt_accountId.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txt_accountId_KeyDown);
            this.txt_accountId.Leave += new System.EventHandler(this.txt_accountId_Leave);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.BackColor = System.Drawing.SystemColors.ButtonHighlight;
            this.label2.Location = new System.Drawing.Point(361, 48);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(66, 24);
            this.label2.TabIndex = 0;
            this.label2.Text = " آئی ڈی";
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
            this.btn_save.Location = new System.Drawing.Point(581, 10);
            this.btn_save.Name = "btn_save";
            this.btn_save.Size = new System.Drawing.Size(89, 52);
            this.btn_save.TabIndex = 2;
            this.btn_save.Text = "سیو";
            this.btn_save.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.btn_save.TextOffset = new System.Drawing.Point(4, 0);
            this.btn_save.Click += new System.EventHandler(this.btn_save_Click);
            // 
            // btn_print
            // 
            this.btn_print.BorderRadius = 4;
            this.btn_print.DisabledState.BorderColor = System.Drawing.Color.DarkGray;
            this.btn_print.DisabledState.CustomBorderColor = System.Drawing.Color.DarkGray;
            this.btn_print.DisabledState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(169)))), ((int)(((byte)(169)))), ((int)(((byte)(169)))));
            this.btn_print.DisabledState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(141)))), ((int)(((byte)(141)))), ((int)(((byte)(141)))));
            this.btn_print.FillColor = System.Drawing.Color.DarkKhaki;
            this.btn_print.Font = new System.Drawing.Font("Arial", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btn_print.ForeColor = System.Drawing.Color.White;
            this.btn_print.Image = ((System.Drawing.Image)(resources.GetObject("btn_print.Image")));
            this.btn_print.ImageAlign = System.Windows.Forms.HorizontalAlignment.Left;
            this.btn_print.ImageOffset = new System.Drawing.Point(-3, 0);
            this.btn_print.ImageSize = new System.Drawing.Size(38, 38);
            this.btn_print.Location = new System.Drawing.Point(964, 10);
            this.btn_print.Name = "btn_print";
            this.btn_print.Size = new System.Drawing.Size(89, 52);
            this.btn_print.TabIndex = 1;
            this.btn_print.Text = "پرنٹ";
            this.btn_print.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.btn_print.TextOffset = new System.Drawing.Point(4, 0);
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.BackColor = System.Drawing.SystemColors.ButtonFace;
            this.label7.Font = new System.Drawing.Font("Arial", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label7.ForeColor = System.Drawing.SystemColors.ControlDarkDark;
            this.label7.Location = new System.Drawing.Point(6, 98);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(107, 24);
            this.label7.TabIndex = 73;
            this.label7.Text = "پیمنٹ آئی ڈی";
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.BackColor = System.Drawing.SystemColors.ButtonFace;
            this.label9.Font = new System.Drawing.Font("Arial", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label9.ForeColor = System.Drawing.SystemColors.ControlDarkDark;
            this.label9.Location = new System.Drawing.Point(15, 187);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(99, 24);
            this.label9.TabIndex = 80;
            this.label9.Text = "بینک اکاؤنٹ";
            // 
            // guna2ShadowPanel1
            // 
            this.guna2ShadowPanel1.BackColor = System.Drawing.Color.Transparent;
            this.guna2ShadowPanel1.Controls.Add(this.guna2PictureBox1);
            this.guna2ShadowPanel1.Controls.Add(this.btn_newCustomer);
            this.guna2ShadowPanel1.Controls.Add(this.btn_printSetting);
            this.guna2ShadowPanel1.Controls.Add(this.btn_delete);
            this.guna2ShadowPanel1.Controls.Add(this.btn_cancel);
            this.guna2ShadowPanel1.Controls.Add(this.btn_addNew);
            this.guna2ShadowPanel1.Controls.Add(this.btn_save);
            this.guna2ShadowPanel1.Controls.Add(this.btn_print);
            this.guna2ShadowPanel1.Controls.Add(this.label1);
            this.guna2ShadowPanel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.guna2ShadowPanel1.FillColor = System.Drawing.Color.White;
            this.guna2ShadowPanel1.Location = new System.Drawing.Point(0, 0);
            this.guna2ShadowPanel1.Name = "guna2ShadowPanel1";
            this.guna2ShadowPanel1.Radius = 5;
            this.guna2ShadowPanel1.ShadowColor = System.Drawing.Color.Black;
            this.guna2ShadowPanel1.Size = new System.Drawing.Size(1070, 73);
            this.guna2ShadowPanel1.TabIndex = 71;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Arial", 24F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.SystemColors.ControlDarkDark;
            this.label1.Location = new System.Drawing.Point(67, 25);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(142, 37);
            this.label1.TabIndex = 0;
            this.label1.Text = "بینک پیمنٹ";
            // 
            // txt_chequeNo
            // 
            this.txt_chequeNo.BackColor = System.Drawing.Color.Transparent;
            this.txt_chequeNo.BorderRadius = 6;
            this.txt_chequeNo.BorderThickness = 2;
            this.txt_chequeNo.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.txt_chequeNo.DefaultText = "";
            this.txt_chequeNo.DisabledState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(208)))), ((int)(((byte)(208)))), ((int)(((byte)(208)))));
            this.txt_chequeNo.DisabledState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(226)))), ((int)(((byte)(226)))), ((int)(((byte)(226)))));
            this.txt_chequeNo.DisabledState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(138)))), ((int)(((byte)(138)))), ((int)(((byte)(138)))));
            this.txt_chequeNo.DisabledState.PlaceholderForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(138)))), ((int)(((byte)(138)))), ((int)(((byte)(138)))));
            this.txt_chequeNo.FocusedState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(148)))), ((int)(((byte)(255)))));
            this.txt_chequeNo.Font = new System.Drawing.Font("Segoe UI Semibold", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txt_chequeNo.ForeColor = System.Drawing.Color.Red;
            this.txt_chequeNo.HoverState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(148)))), ((int)(((byte)(255)))));
            this.txt_chequeNo.Location = new System.Drawing.Point(116, 224);
            this.txt_chequeNo.Name = "txt_chequeNo";
            this.txt_chequeNo.PasswordChar = '\0';
            this.txt_chequeNo.PlaceholderText = "";
            this.txt_chequeNo.ReadOnly = true;
            this.txt_chequeNo.SelectedText = "";
            this.txt_chequeNo.ShadowDecoration.Color = System.Drawing.Color.Silver;
            this.txt_chequeNo.Size = new System.Drawing.Size(141, 36);
            this.txt_chequeNo.TabIndex = 84;
            // 
            // txt_chequeDate
            // 
            this.txt_chequeDate.BackColor = System.Drawing.Color.Transparent;
            this.txt_chequeDate.BorderRadius = 6;
            this.txt_chequeDate.BorderThickness = 2;
            this.txt_chequeDate.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.txt_chequeDate.DefaultText = "";
            this.txt_chequeDate.DisabledState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(208)))), ((int)(((byte)(208)))), ((int)(((byte)(208)))));
            this.txt_chequeDate.DisabledState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(226)))), ((int)(((byte)(226)))), ((int)(((byte)(226)))));
            this.txt_chequeDate.DisabledState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(138)))), ((int)(((byte)(138)))), ((int)(((byte)(138)))));
            this.txt_chequeDate.DisabledState.PlaceholderForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(138)))), ((int)(((byte)(138)))), ((int)(((byte)(138)))));
            this.txt_chequeDate.FocusedState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(148)))), ((int)(((byte)(255)))));
            this.txt_chequeDate.Font = new System.Drawing.Font("Segoe UI Semibold", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txt_chequeDate.ForeColor = System.Drawing.Color.Red;
            this.txt_chequeDate.HoverState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(148)))), ((int)(((byte)(255)))));
            this.txt_chequeDate.Location = new System.Drawing.Point(327, 224);
            this.txt_chequeDate.Name = "txt_chequeDate";
            this.txt_chequeDate.PasswordChar = '\0';
            this.txt_chequeDate.PlaceholderText = "";
            this.txt_chequeDate.ReadOnly = true;
            this.txt_chequeDate.SelectedText = "";
            this.txt_chequeDate.ShadowDecoration.Color = System.Drawing.Color.Silver;
            this.txt_chequeDate.Size = new System.Drawing.Size(145, 36);
            this.txt_chequeDate.TabIndex = 85;
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.BackColor = System.Drawing.SystemColors.ButtonFace;
            this.label10.Font = new System.Drawing.Font("Arial", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label10.ForeColor = System.Drawing.SystemColors.ControlDarkDark;
            this.label10.Location = new System.Drawing.Point(29, 231);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(81, 24);
            this.label10.TabIndex = 86;
            this.label10.Text = "چیک نمبر";
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.BackColor = System.Drawing.SystemColors.ButtonFace;
            this.label11.Font = new System.Drawing.Font("Arial", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label11.ForeColor = System.Drawing.SystemColors.ControlDarkDark;
            this.label11.Location = new System.Drawing.Point(276, 231);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(48, 24);
            this.label11.TabIndex = 87;
            this.label11.Text = "تاریخ";
            // 
            // label12
            // 
            this.label12.AutoSize = true;
            this.label12.BackColor = System.Drawing.SystemColors.Control;
            this.label12.Font = new System.Drawing.Font("Arial", 15.75F, System.Drawing.FontStyle.Bold);
            this.label12.ForeColor = System.Drawing.SystemColors.ControlDarkDark;
            this.label12.Location = new System.Drawing.Point(419, 113);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(52, 24);
            this.label12.TabIndex = 88;
            this.label12.Text = "بیلنس";
            // 
            // lstBankAccount
            // 
            this.lstBankAccount.Font = new System.Drawing.Font("Arial", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lstBankAccount.FormattingEnabled = true;
            this.lstBankAccount.ItemHeight = 17;
            this.lstBankAccount.Location = new System.Drawing.Point(117, 216);
            this.lstBankAccount.Name = "lstBankAccount";
            this.lstBankAccount.Size = new System.Drawing.Size(355, 140);
            this.lstBankAccount.TabIndex = 90;
            // 
            // dtm_paymentDate
            // 
            this.dtm_paymentDate.Font = new System.Drawing.Font("Arial", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dtm_paymentDate.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dtm_paymentDate.Location = new System.Drawing.Point(119, 141);
            this.dtm_paymentDate.Name = "dtm_paymentDate";
            this.dtm_paymentDate.Size = new System.Drawing.Size(172, 32);
            this.dtm_paymentDate.TabIndex = 10;
            this.dtm_paymentDate.Value = new System.DateTime(2025, 3, 26, 2, 24, 47, 0);
            // 
            // BankPayment
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1070, 624);
            this.Controls.Add(this.dtm_paymentDate);
            this.Controls.Add(this.lstBankAccount);
            this.Controls.Add(this.label12);
            this.Controls.Add(this.label11);
            this.Controls.Add(this.label10);
            this.Controls.Add(this.txt_chequeDate);
            this.Controls.Add(this.txt_chequeNo);
            this.Controls.Add(this.label8);
            this.Controls.Add(this.btn_forward);
            this.Controls.Add(this.txt_bankAccountBalance);
            this.Controls.Add(this.txt_bankAccountName);
            this.Controls.Add(this.txt_bankAccount);
            this.Controls.Add(this.btn_back);
            this.Controls.Add(this.txt_bankPaymentId);
            this.Controls.Add(this.dataGridView1);
            this.Controls.Add(this.guna2GroupBox1);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.label9);
            this.Controls.Add(this.guna2ShadowPanel1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "BankPayment";
            this.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.StartPosition = System.Windows.Forms.FormStartPosition.Manual;
            this.Text = "BankPayment";
            this.Load += new System.EventHandler(this.BankPayment_Load);
            ((System.ComponentModel.ISupportInitialize)(this.guna2PictureBox1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            this.guna2GroupBox1.ResumeLayout(false);
            this.guna2GroupBox1.PerformLayout();
            this.guna2ShadowPanel1.ResumeLayout(false);
            this.guna2ShadowPanel1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label8;
        private Guna.UI2.WinForms.Guna2Button btn_forward;
        private Guna.UI2.WinForms.Guna2TextBox txt_bankAccountBalance;
        private Guna.UI2.WinForms.Guna2TextBox txt_bankAccountName;
        private Guna.UI2.WinForms.Guna2TextBox txt_bankAccount;
        private Guna.UI2.WinForms.Guna2Button btn_back;
        private Guna.UI2.WinForms.Guna2TextBox txt_bankPaymentId;
        private Guna.UI2.WinForms.Guna2PictureBox guna2PictureBox1;
        private Guna.UI2.WinForms.Guna2Button btn_newCustomer;
        private Guna.UI2.WinForms.Guna2Button btn_printSetting;
        private Guna.UI2.WinForms.Guna2Button btn_delete;
        private Guna.UI2.WinForms.Guna2Button btn_cancel;
        private Guna.UI2.WinForms.Guna2Button btn_addNew;
        private System.Windows.Forms.DataGridView dataGridView1;
        private Guna.UI2.WinForms.Guna2GroupBox guna2GroupBox1;
        private System.Windows.Forms.Label label6;
        private Guna.UI2.WinForms.Guna2TextBox txt_description;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label4;
        private Guna.UI2.WinForms.Guna2TextBox txt_accountName;
        private Guna.UI2.WinForms.Guna2TextBox txt_accountBalance;
        private System.Windows.Forms.Label label3;
        private Guna.UI2.WinForms.Guna2TextBox txt_accountId;
        private System.Windows.Forms.Label label2;
        private Guna.UI2.WinForms.Guna2Button btn_save;
        private Guna.UI2.WinForms.Guna2Button btn_print;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label9;
        private Guna.UI2.WinForms.Guna2ShadowPanel guna2ShadowPanel1;
        private System.Windows.Forms.Label label1;
        private Guna.UI2.WinForms.Guna2TextBox txt_chequeNo;
        private Guna.UI2.WinForms.Guna2TextBox txt_chequeDate;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.Label label12;
        private System.Windows.Forms.DataGridViewTextBoxColumn bankPaymentId;
        private System.Windows.Forms.DataGridViewTextBoxColumn date;
        private System.Windows.Forms.DataGridViewTextBoxColumn accountId;
        private System.Windows.Forms.DataGridViewTextBoxColumn accountName;
        private System.Windows.Forms.DataGridViewTextBoxColumn bankAccountId;
        private System.Windows.Forms.DataGridViewTextBoxColumn amount;
        private System.Windows.Forms.DataGridViewTextBoxColumn chequeNumber;
        private System.Windows.Forms.DataGridViewTextBoxColumn chequeDate;
        private System.Windows.Forms.DataGridViewTextBoxColumn description;
        private System.Windows.Forms.ListBox lstAccounts;
        private System.Windows.Forms.ListBox lstBankAccount;
        private Guna.UI2.WinForms.Guna2TextBox txt_amount;
        private System.Windows.Forms.DateTimePicker dtm_paymentDate;
    }
}