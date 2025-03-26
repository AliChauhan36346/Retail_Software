namespace ALA_Accounting.Addition
{
    partial class ImportInventoryOpeningBalances
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(ImportInventoryOpeningBalances));
            this.label1 = new System.Windows.Forms.Label();
            this.btn_import = new Guna.UI2.WinForms.Guna2Button();
            this.combo_financialYear = new System.Windows.Forms.ComboBox();
            this.label2 = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.BackColor = System.Drawing.SystemColors.Control;
            this.label1.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.label1.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.label1.Font = new System.Drawing.Font("Arial", 15.75F, System.Drawing.FontStyle.Bold);
            this.label1.ForeColor = System.Drawing.Color.IndianRed;
            this.label1.Location = new System.Drawing.Point(12, 45);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(420, 74);
            this.label1.TabIndex = 8;
            this.label1.Text = "نوٹ: یہ پچھلے منتخب سال سے اکاؤنٹ کے تمام بیلنس \r\nدرآمد کرے گا، قطع نظر اس کے کہ " +
    "ان کے اوپننگ بیلنس\r\n پہلے ہی داخل ہو چکے ہیں یا نہیں";
            this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // btn_import
            // 
            this.btn_import.BorderColor = System.Drawing.Color.RoyalBlue;
            this.btn_import.BorderRadius = 4;
            this.btn_import.BorderThickness = 2;
            this.btn_import.DisabledState.BorderColor = System.Drawing.Color.DarkGray;
            this.btn_import.DisabledState.CustomBorderColor = System.Drawing.Color.DarkGray;
            this.btn_import.DisabledState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(169)))), ((int)(((byte)(169)))), ((int)(((byte)(169)))));
            this.btn_import.DisabledState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(141)))), ((int)(((byte)(141)))), ((int)(((byte)(141)))));
            this.btn_import.FillColor = System.Drawing.Color.DodgerBlue;
            this.btn_import.Font = new System.Drawing.Font("Arial", 20.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btn_import.ForeColor = System.Drawing.Color.White;
            this.btn_import.Image = ((System.Drawing.Image)(resources.GetObject("btn_import.Image")));
            this.btn_import.ImageAlign = System.Windows.Forms.HorizontalAlignment.Left;
            this.btn_import.ImageOffset = new System.Drawing.Point(-3, 0);
            this.btn_import.ImageSize = new System.Drawing.Size(38, 38);
            this.btn_import.Location = new System.Drawing.Point(200, 221);
            this.btn_import.Name = "btn_import";
            this.btn_import.Size = new System.Drawing.Size(214, 52);
            this.btn_import.TabIndex = 7;
            this.btn_import.Text = "بیلنس درآمد کریں";
            this.btn_import.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.btn_import.TextOffset = new System.Drawing.Point(4, 0);
            this.btn_import.Click += new System.EventHandler(this.btn_import_Click);
            // 
            // combo_financialYear
            // 
            this.combo_financialYear.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.combo_financialYear.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.combo_financialYear.FormattingEnabled = true;
            this.combo_financialYear.Location = new System.Drawing.Point(26, 171);
            this.combo_financialYear.Name = "combo_financialYear";
            this.combo_financialYear.Size = new System.Drawing.Size(388, 28);
            this.combo_financialYear.TabIndex = 6;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.BackColor = System.Drawing.SystemColors.ButtonHighlight;
            this.label2.Font = new System.Drawing.Font("Arial", 15.75F, System.Drawing.FontStyle.Bold);
            this.label2.Location = new System.Drawing.Point(22, 144);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(392, 24);
            this.label2.TabIndex = 5;
            this.label2.Text = "بیلنس درآمد کرنے کے لیے مالی سال کا انتخاب کریں۔";
            // 
            // ImportInventoryOpeningBalances
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(444, 319);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.btn_import);
            this.Controls.Add(this.combo_financialYear);
            this.Controls.Add(this.label2);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.Name = "ImportInventoryOpeningBalances";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "ImportInventoryOpeningBalances";
            this.Load += new System.EventHandler(this.ImportInventoryOpeningBalances_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private Guna.UI2.WinForms.Guna2Button btn_import;
        private System.Windows.Forms.ComboBox combo_financialYear;
        private System.Windows.Forms.Label label2;
    }
}