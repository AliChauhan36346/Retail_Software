namespace ALA_Accounting.Addition
{
    partial class BalanceSheet
    {
        private System.ComponentModel.IContainer components = null;

        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        private void InitializeComponent()
        {
            this.panel1 = new System.Windows.Forms.Panel();
            this.lbl_asOfDate = new System.Windows.Forms.Label();
            this.lbl_title = new System.Windows.Forms.Label();
            this.dgv_balanceSheet = new System.Windows.Forms.DataGridView();
            this.panel2 = new System.Windows.Forms.Panel();
            this.btn_print = new System.Windows.Forms.Button();
            this.btn_exportExcel = new System.Windows.Forms.Button();
            this.btn_exportPDF = new System.Windows.Forms.Button();
            this.colAccountName = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colAmount = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgv_balanceSheet)).BeginInit();
            this.panel2.SuspendLayout();
            this.SuspendLayout();
            
            // panel1
            this.panel1.BackColor = System.Drawing.Color.DodgerBlue;
            this.panel1.Controls.Add(this.lbl_asOfDate);
            this.panel1.Controls.Add(this.lbl_title);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(900, 80);
            this.panel1.TabIndex = 0;
            
            // lbl_asOfDate
            this.lbl_asOfDate.AutoSize = true;
            this.lbl_asOfDate.Font = new System.Drawing.Font("Arial", 10F);
            this.lbl_asOfDate.ForeColor = System.Drawing.Color.White;
            this.lbl_asOfDate.Location = new System.Drawing.Point(20, 50);
            this.lbl_asOfDate.Name = "lbl_asOfDate";
            this.lbl_asOfDate.Size = new System.Drawing.Size(79, 16);
            this.lbl_asOfDate.TabIndex = 1;
            this.lbl_asOfDate.Text = "As of Date";
            
            // lbl_title
            this.lbl_title.AutoSize = true;
            this.lbl_title.Font = new System.Drawing.Font("Arial", 16F, System.Drawing.FontStyle.Bold);
            this.lbl_title.ForeColor = System.Drawing.Color.White;
            this.lbl_title.Location = new System.Drawing.Point(20, 15);
            this.lbl_title.Name = "lbl_title";
            this.lbl_title.Size = new System.Drawing.Size(181, 25);
            this.lbl_title.TabIndex = 0;
            this.lbl_title.Text = "BALANCE SHEET";
            
            // dgv_balanceSheet
            this.dgv_balanceSheet.AllowUserToAddRows = false;
            this.dgv_balanceSheet.AllowUserToDeleteRows = false;
            this.dgv_balanceSheet.BackgroundColor = System.Drawing.Color.White;
            this.dgv_balanceSheet.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgv_balanceSheet.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.colAccountName,
            this.colAmount});
            this.dgv_balanceSheet.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgv_balanceSheet.Location = new System.Drawing.Point(0, 80);
            this.dgv_balanceSheet.Name = "dgv_balanceSheet";
            this.dgv_balanceSheet.ReadOnly = true;
            this.dgv_balanceSheet.RowHeadersVisible = false;
            this.dgv_balanceSheet.Size = new System.Drawing.Size(900, 420);
            this.dgv_balanceSheet.TabIndex = 1;
            
            // panel2
            this.panel2.BackColor = System.Drawing.Color.WhiteSmoke;
            this.panel2.Controls.Add(this.btn_print);
            this.panel2.Controls.Add(this.btn_exportExcel);
            this.panel2.Controls.Add(this.btn_exportPDF);
            this.panel2.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.panel2.Location = new System.Drawing.Point(0, 500);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(900, 50);
            this.panel2.TabIndex = 2;
            
            // btn_print
            this.btn_print.BackColor = System.Drawing.Color.LimeGreen;
            this.btn_print.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btn_print.Font = new System.Drawing.Font("Arial", 10F, System.Drawing.FontStyle.Bold);
            this.btn_print.ForeColor = System.Drawing.Color.White;
            this.btn_print.Location = new System.Drawing.Point(590, 10);
            this.btn_print.Name = "btn_print";
            this.btn_print.Size = new System.Drawing.Size(90, 30);
            this.btn_print.TabIndex = 2;
            this.btn_print.Text = "??? Print";
            this.btn_print.UseVisualStyleBackColor = false;
            this.btn_print.Click += new System.EventHandler(this.btn_print_Click);
            
            // btn_exportExcel
            this.btn_exportExcel.BackColor = System.Drawing.Color.Green;
            this.btn_exportExcel.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btn_exportExcel.Font = new System.Drawing.Font("Arial", 10F, System.Drawing.FontStyle.Bold);
            this.btn_exportExcel.ForeColor = System.Drawing.Color.White;
            this.btn_exportExcel.Location = new System.Drawing.Point(710, 10);
            this.btn_exportExcel.Name = "btn_exportExcel";
            this.btn_exportExcel.Size = new System.Drawing.Size(90, 30);
            this.btn_exportExcel.TabIndex = 1;
            this.btn_exportExcel.Text = "?? Excel";
            this.btn_exportExcel.UseVisualStyleBackColor = false;
            this.btn_exportExcel.Click += new System.EventHandler(this.btn_exportExcel_Click);
            
            // btn_exportPDF
            this.btn_exportPDF.BackColor = System.Drawing.Color.SteelBlue;
            this.btn_exportPDF.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btn_exportPDF.Font = new System.Drawing.Font("Arial", 10F, System.Drawing.FontStyle.Bold);
            this.btn_exportPDF.ForeColor = System.Drawing.Color.White;
            this.btn_exportPDF.Location = new System.Drawing.Point(810, 10);
            this.btn_exportPDF.Name = "btn_exportPDF";
            this.btn_exportPDF.Size = new System.Drawing.Size(80, 30);
            this.btn_exportPDF.TabIndex = 0;
            this.btn_exportPDF.Text = "?? Text";
            this.btn_exportPDF.UseVisualStyleBackColor = false;
            this.btn_exportPDF.Click += new System.EventHandler(this.btn_exportPDF_Click);
            
            // colAccountName
            this.colAccountName.DataPropertyName = "AccountName";
            this.colAccountName.HeaderText = "Description";
            this.colAccountName.Name = "colAccountName";
            this.colAccountName.ReadOnly = true;
            this.colAccountName.Width = 600;
            
            // colAmount
            this.colAmount.DataPropertyName = "Amount";
            this.colAmount.HeaderText = "Amount";
            this.colAmount.Name = "colAmount";
            this.colAmount.ReadOnly = true;
            this.colAmount.Width = 200;
            
            // BalanceSheet
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(900, 550);
            this.Controls.Add(this.dgv_balanceSheet);
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.panel1);
            this.Name = "BalanceSheet";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Balance Sheet";
            this.Load += new System.EventHandler(this.BalanceSheet_Load);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgv_balanceSheet)).EndInit();
            this.panel2.ResumeLayout(false);
            this.ResumeLayout(false);
        }

        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Label lbl_asOfDate;
        private System.Windows.Forms.Label lbl_title;
        private System.Windows.Forms.DataGridView dgv_balanceSheet;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Button btn_print;
        private System.Windows.Forms.Button btn_exportExcel;
        private System.Windows.Forms.Button btn_exportPDF;
        private System.Windows.Forms.DataGridViewTextBoxColumn colAccountName;
        private System.Windows.Forms.DataGridViewTextBoxColumn colAmount;
    }
}
