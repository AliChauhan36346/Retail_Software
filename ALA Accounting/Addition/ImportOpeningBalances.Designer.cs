namespace ALA_Accounting.Addition
{
    partial class ImportOpeningBalances
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(ImportOpeningBalances));
            this.label2 = new System.Windows.Forms.Label();
            this.combo_financialYear = new System.Windows.Forms.ComboBox();
            this.btn_import = new Guna.UI2.WinForms.Guna2Button();
            this.label1 = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.BackColor = System.Drawing.SystemColors.ButtonHighlight;
            this.label2.Font = new System.Drawing.Font("Arial", 15.75F, System.Drawing.FontStyle.Bold);
            this.label2.Location = new System.Drawing.Point(22, 124);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(392, 24);
            this.label2.TabIndex = 1;
            this.label2.Text = "بیلنس درآمد کرنے کے لیے مالی سال کا انتخاب کریں۔";
            // 
            // combo_financialYear
            // 
            this.combo_financialYear.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.combo_financialYear.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.combo_financialYear.FormattingEnabled = true;
            this.combo_financialYear.Location = new System.Drawing.Point(26, 151);
            this.combo_financialYear.Name = "combo_financialYear";
            this.combo_financialYear.Size = new System.Drawing.Size(388, 28);
            this.combo_financialYear.TabIndex = 2;
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
            this.btn_import.Location = new System.Drawing.Point(200, 201);
            this.btn_import.Name = "btn_import";
            this.btn_import.Size = new System.Drawing.Size(214, 52);
            this.btn_import.TabIndex = 3;
            this.btn_import.Text = "بیلنس درآمد کریں";
            this.btn_import.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.btn_import.TextOffset = new System.Drawing.Point(4, 0);
            this.btn_import.Click += new System.EventHandler(this.btn_import_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.BackColor = System.Drawing.SystemColors.Control;
            this.label1.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.label1.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.label1.Font = new System.Drawing.Font("Arial", 15.75F, System.Drawing.FontStyle.Bold);
            this.label1.ForeColor = System.Drawing.Color.IndianRed;
            this.label1.Location = new System.Drawing.Point(12, 25);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(420, 74);
            this.label1.TabIndex = 4;
            this.label1.Text = "نوٹ: یہ پچھلے منتخب سال سے اکاؤنٹ کے تمام بیلنس \r\nدرآمد کرے گا، قطع نظر اس کے کہ " +
    "ان کے اوپننگ بیلنس\r\n پہلے ہی داخل ہو چکے ہیں یا نہیں";
            this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // ImportOpeningBalances
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(444, 319);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.btn_import);
            this.Controls.Add(this.combo_financialYear);
            this.Controls.Add(this.label2);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.Name = "ImportOpeningBalances";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "ImportOpeningBalances";
            this.Load += new System.EventHandler(this.ImportOpeningBalances_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.ComboBox combo_financialYear;
        private Guna.UI2.WinForms.Guna2Button btn_import;
        private System.Windows.Forms.Label label1;
    }
}