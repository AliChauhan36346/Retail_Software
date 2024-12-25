namespace ALA_Accounting.Addition
{
    partial class FinancialYear
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FinancialYear));
            this.guna2ShadowPanel1 = new Guna.UI2.WinForms.Guna2ShadowPanel();
            this.label1 = new System.Windows.Forms.Label();
            this.btn_cancel = new Guna.UI2.WinForms.Guna2Button();
            this.btn_addNew = new Guna.UI2.WinForms.Guna2Button();
            this.btn_save = new Guna.UI2.WinForms.Guna2Button();
            this.label2 = new System.Windows.Forms.Label();
            this.txt_YearName = new Guna.UI2.WinForms.Guna2TextBox();
            this.lstFinancialYears = new System.Windows.Forms.ListBox();
            this.dtm_endDate = new Guna.UI2.WinForms.Guna2DateTimePicker();
            this.dtm_startDate = new Guna.UI2.WinForms.Guna2DateTimePicker();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.guna2ShadowPanel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // guna2ShadowPanel1
            // 
            this.guna2ShadowPanel1.BackColor = System.Drawing.Color.Transparent;
            this.guna2ShadowPanel1.Controls.Add(this.label1);
            this.guna2ShadowPanel1.FillColor = System.Drawing.Color.White;
            this.guna2ShadowPanel1.Location = new System.Drawing.Point(13, 11);
            this.guna2ShadowPanel1.Margin = new System.Windows.Forms.Padding(4);
            this.guna2ShadowPanel1.Name = "guna2ShadowPanel1";
            this.guna2ShadowPanel1.Radius = 5;
            this.guna2ShadowPanel1.ShadowColor = System.Drawing.Color.Gray;
            this.guna2ShadowPanel1.ShadowShift = 6;
            this.guna2ShadowPanel1.Size = new System.Drawing.Size(262, 58);
            this.guna2ShadowPanel1.TabIndex = 112;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Arial", 24F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.SystemColors.ControlDarkDark;
            this.label1.Location = new System.Drawing.Point(73, 10);
            this.label1.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(114, 37);
            this.label1.TabIndex = 2;
            this.label1.Text = "مالی سال";
            // 
            // btn_cancel
            // 
            this.btn_cancel.BorderRadius = 4;
            this.btn_cancel.DisabledState.BorderColor = System.Drawing.Color.DarkGray;
            this.btn_cancel.DisabledState.CustomBorderColor = System.Drawing.Color.DarkGray;
            this.btn_cancel.DisabledState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(169)))), ((int)(((byte)(169)))), ((int)(((byte)(169)))));
            this.btn_cancel.DisabledState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(141)))), ((int)(((byte)(141)))), ((int)(((byte)(141)))));
            this.btn_cancel.FillColor = System.Drawing.Color.Thistle;
            this.btn_cancel.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btn_cancel.ForeColor = System.Drawing.Color.DimGray;
            this.btn_cancel.Image = ((System.Drawing.Image)(resources.GetObject("btn_cancel.Image")));
            this.btn_cancel.ImageAlign = System.Windows.Forms.HorizontalAlignment.Left;
            this.btn_cancel.ImageOffset = new System.Drawing.Point(-3, 0);
            this.btn_cancel.ImageSize = new System.Drawing.Size(38, 38);
            this.btn_cancel.Location = new System.Drawing.Point(537, 20);
            this.btn_cancel.Name = "btn_cancel";
            this.btn_cancel.Size = new System.Drawing.Size(80, 49);
            this.btn_cancel.TabIndex = 118;
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
            this.btn_addNew.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btn_addNew.ForeColor = System.Drawing.Color.White;
            this.btn_addNew.Image = ((System.Drawing.Image)(resources.GetObject("btn_addNew.Image")));
            this.btn_addNew.ImageAlign = System.Windows.Forms.HorizontalAlignment.Left;
            this.btn_addNew.ImageOffset = new System.Drawing.Point(-3, 0);
            this.btn_addNew.ImageSize = new System.Drawing.Size(32, 32);
            this.btn_addNew.Location = new System.Drawing.Point(367, 19);
            this.btn_addNew.Name = "btn_addNew";
            this.btn_addNew.Size = new System.Drawing.Size(80, 49);
            this.btn_addNew.TabIndex = 117;
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
            this.btn_save.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btn_save.ForeColor = System.Drawing.Color.White;
            this.btn_save.Image = ((System.Drawing.Image)(resources.GetObject("btn_save.Image")));
            this.btn_save.ImageAlign = System.Windows.Forms.HorizontalAlignment.Left;
            this.btn_save.ImageOffset = new System.Drawing.Point(-3, 0);
            this.btn_save.ImageSize = new System.Drawing.Size(38, 38);
            this.btn_save.Location = new System.Drawing.Point(452, 19);
            this.btn_save.Name = "btn_save";
            this.btn_save.Size = new System.Drawing.Size(80, 49);
            this.btn_save.TabIndex = 116;
            this.btn_save.Text = "سیو";
            this.btn_save.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.btn_save.TextOffset = new System.Drawing.Point(4, 0);
            this.btn_save.Click += new System.EventHandler(this.btn_save_Click);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.BackColor = System.Drawing.SystemColors.ButtonFace;
            this.label2.Font = new System.Drawing.Font("Arial", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.ForeColor = System.Drawing.SystemColors.ControlDarkDark;
            this.label2.Location = new System.Drawing.Point(444, 233);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(118, 24);
            this.label2.TabIndex = 115;
            this.label2.Text = "مالی سال کا نام";
            // 
            // txt_YearName
            // 
            this.txt_YearName.BackColor = System.Drawing.Color.Transparent;
            this.txt_YearName.BorderRadius = 6;
            this.txt_YearName.BorderThickness = 2;
            this.txt_YearName.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.txt_YearName.DefaultText = "";
            this.txt_YearName.DisabledState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(208)))), ((int)(((byte)(208)))), ((int)(((byte)(208)))));
            this.txt_YearName.DisabledState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(226)))), ((int)(((byte)(226)))), ((int)(((byte)(226)))));
            this.txt_YearName.DisabledState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(138)))), ((int)(((byte)(138)))), ((int)(((byte)(138)))));
            this.txt_YearName.DisabledState.PlaceholderForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(138)))), ((int)(((byte)(138)))), ((int)(((byte)(138)))));
            this.txt_YearName.FocusedState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(148)))), ((int)(((byte)(255)))));
            this.txt_YearName.Font = new System.Drawing.Font("Segoe UI Semibold", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txt_YearName.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.txt_YearName.HoverState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(148)))), ((int)(((byte)(255)))));
            this.txt_YearName.Location = new System.Drawing.Point(294, 226);
            this.txt_YearName.Name = "txt_YearName";
            this.txt_YearName.PasswordChar = '\0';
            this.txt_YearName.PlaceholderText = "";
            this.txt_YearName.SelectedText = "";
            this.txt_YearName.ShadowDecoration.Color = System.Drawing.Color.Silver;
            this.txt_YearName.Size = new System.Drawing.Size(144, 34);
            this.txt_YearName.TabIndex = 114;
            this.txt_YearName.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // lstFinancialYears
            // 
            this.lstFinancialYears.FormattingEnabled = true;
            this.lstFinancialYears.Location = new System.Drawing.Point(12, 77);
            this.lstFinancialYears.Name = "lstFinancialYears";
            this.lstFinancialYears.Size = new System.Drawing.Size(263, 212);
            this.lstFinancialYears.TabIndex = 113;
            this.lstFinancialYears.SelectedIndexChanged += new System.EventHandler(this.lstFinancialYears_SelectedIndexChanged);
            // 
            // dtm_endDate
            // 
            this.dtm_endDate.BorderRadius = 8;
            this.dtm_endDate.Checked = true;
            this.dtm_endDate.FillColor = System.Drawing.Color.RoyalBlue;
            this.dtm_endDate.Font = new System.Drawing.Font("Segoe UI", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dtm_endDate.ForeColor = System.Drawing.Color.White;
            this.dtm_endDate.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dtm_endDate.Location = new System.Drawing.Point(294, 163);
            this.dtm_endDate.MaxDate = new System.DateTime(9998, 12, 31, 0, 0, 0, 0);
            this.dtm_endDate.MinDate = new System.DateTime(1753, 1, 1, 0, 0, 0, 0);
            this.dtm_endDate.Name = "dtm_endDate";
            this.dtm_endDate.Size = new System.Drawing.Size(144, 36);
            this.dtm_endDate.TabIndex = 120;
            this.dtm_endDate.Value = new System.DateTime(2024, 8, 26, 17, 20, 4, 398);
            this.dtm_endDate.ValueChanged += new System.EventHandler(this.dtm_endDate_ValueChanged);
            // 
            // dtm_startDate
            // 
            this.dtm_startDate.BorderRadius = 8;
            this.dtm_startDate.Checked = true;
            this.dtm_startDate.FillColor = System.Drawing.Color.RoyalBlue;
            this.dtm_startDate.Font = new System.Drawing.Font("Segoe UI", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dtm_startDate.ForeColor = System.Drawing.Color.White;
            this.dtm_startDate.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dtm_startDate.Location = new System.Drawing.Point(294, 109);
            this.dtm_startDate.MaxDate = new System.DateTime(9998, 12, 31, 0, 0, 0, 0);
            this.dtm_startDate.MinDate = new System.DateTime(1753, 1, 1, 0, 0, 0, 0);
            this.dtm_startDate.Name = "dtm_startDate";
            this.dtm_startDate.Size = new System.Drawing.Size(144, 36);
            this.dtm_startDate.TabIndex = 121;
            this.dtm_startDate.Value = new System.DateTime(2024, 8, 26, 17, 20, 4, 398);
            this.dtm_startDate.ValueChanged += new System.EventHandler(this.dtm_startDate_ValueChanged);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.BackColor = System.Drawing.SystemColors.ButtonFace;
            this.label3.Font = new System.Drawing.Font("Arial", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.ForeColor = System.Drawing.SystemColors.ControlDarkDark;
            this.label3.Location = new System.Drawing.Point(444, 116);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(101, 24);
            this.label3.TabIndex = 122;
            this.label3.Text = "ابتدائی تاریخ";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.BackColor = System.Drawing.SystemColors.ButtonFace;
            this.label4.Font = new System.Drawing.Font("Arial", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.ForeColor = System.Drawing.SystemColors.ControlDarkDark;
            this.label4.Location = new System.Drawing.Point(444, 171);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(108, 24);
            this.label4.TabIndex = 123;
            this.label4.Text = "اختتامی تاریخ";
            // 
            // FinancialYear
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(685, 300);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.dtm_startDate);
            this.Controls.Add(this.dtm_endDate);
            this.Controls.Add(this.guna2ShadowPanel1);
            this.Controls.Add(this.btn_cancel);
            this.Controls.Add(this.btn_addNew);
            this.Controls.Add(this.btn_save);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.txt_YearName);
            this.Controls.Add(this.lstFinancialYears);
            this.Name = "FinancialYear";
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "FinancialYear";
            this.Load += new System.EventHandler(this.FinancialYear_Load);
            this.guna2ShadowPanel1.ResumeLayout(false);
            this.guna2ShadowPanel1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private Guna.UI2.WinForms.Guna2ShadowPanel guna2ShadowPanel1;
        private System.Windows.Forms.Label label1;
        private Guna.UI2.WinForms.Guna2Button btn_cancel;
        private Guna.UI2.WinForms.Guna2Button btn_addNew;
        private Guna.UI2.WinForms.Guna2Button btn_save;
        private System.Windows.Forms.Label label2;
        private Guna.UI2.WinForms.Guna2TextBox txt_YearName;
        private System.Windows.Forms.ListBox lstFinancialYears;
        private Guna.UI2.WinForms.Guna2DateTimePicker dtm_endDate;
        private Guna.UI2.WinForms.Guna2DateTimePicker dtm_startDate;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
    }
}