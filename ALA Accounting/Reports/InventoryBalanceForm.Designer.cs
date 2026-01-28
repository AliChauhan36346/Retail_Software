namespace ALA_Accounting.Reports
{
    partial class InventoryBalanceForm
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
            this.pnlFilters = new System.Windows.Forms.Panel();
            this.pnlTop = new System.Windows.Forms.Panel();
            this.lblTitle = new System.Windows.Forms.Label();
            this.dgvInventoryBalance = new System.Windows.Forms.DataGridView();
            this.pnlBottom = new System.Windows.Forms.Panel();
            this.btnExportExcel = new System.Windows.Forms.Button();
            this.btnPrint = new System.Windows.Forms.Button();
            this.lblTotalClosingQty = new System.Windows.Forms.Label();
            this.lblTotalClosingValue = new System.Windows.Forms.Label();
            this.btnApplyFilters = new System.Windows.Forms.Button();
            this.btnClearFilters = new System.Windows.Forms.Button();
            this.cmbCategory = new System.Windows.Forms.ComboBox();
            this.cmbSubCategory = new System.Windows.Forms.ComboBox();
            this.cmbBrand = new System.Windows.Forms.ComboBox();
            this.dtpStartDate = new System.Windows.Forms.DateTimePicker();
            this.dtpEndDate = new System.Windows.Forms.DateTimePicker();
            this.lblCategory = new System.Windows.Forms.Label();
            this.lblSubCategory = new System.Windows.Forms.Label();
            this.lblBrand = new System.Windows.Forms.Label();
            this.lblStartDate = new System.Windows.Forms.Label();
            this.lblEndDate = new System.Windows.Forms.Label();
            this.pnlFilters.SuspendLayout();
            this.pnlTop.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvInventoryBalance)).BeginInit();
            this.pnlBottom.SuspendLayout();
            this.SuspendLayout();

            // pnlTop
            this.pnlTop.BackColor = System.Drawing.Color.DodgerBlue;
            this.pnlTop.Controls.Add(this.lblTitle);
            this.pnlTop.Dock = System.Windows.Forms.DockStyle.Top;
            this.pnlTop.Location = new System.Drawing.Point(0, 0);
            this.pnlTop.Name = "pnlTop";
            this.pnlTop.Size = new System.Drawing.Size(1200, 50);
            this.pnlTop.TabIndex = 0;

            // lblTitle
            this.lblTitle.AutoSize = true;
            this.lblTitle.Font = new System.Drawing.Font("Arial", 14F, System.Drawing.FontStyle.Bold);
            this.lblTitle.ForeColor = System.Drawing.Color.White;
            this.lblTitle.Location = new System.Drawing.Point(20, 12);
            this.lblTitle.Name = "lblTitle";
            this.lblTitle.Size = new System.Drawing.Size(190, 22);
            this.lblTitle.TabIndex = 0;
            this.lblTitle.Text = "Inventory Balance Report";

            // pnlFilters
            this.pnlFilters.BackColor = System.Drawing.Color.WhiteSmoke;
            this.pnlFilters.Controls.Add(this.lblCategory);
            this.pnlFilters.Controls.Add(this.cmbCategory);
            this.pnlFilters.Controls.Add(this.lblSubCategory);
            this.pnlFilters.Controls.Add(this.cmbSubCategory);
            this.pnlFilters.Controls.Add(this.lblBrand);
            this.pnlFilters.Controls.Add(this.cmbBrand);
            this.pnlFilters.Controls.Add(this.lblStartDate);
            this.pnlFilters.Controls.Add(this.dtpStartDate);
            this.pnlFilters.Controls.Add(this.lblEndDate);
            this.pnlFilters.Controls.Add(this.dtpEndDate);
            this.pnlFilters.Controls.Add(this.btnApplyFilters);
            this.pnlFilters.Controls.Add(this.btnClearFilters);
            this.pnlFilters.Dock = System.Windows.Forms.DockStyle.Top;
            this.pnlFilters.Location = new System.Drawing.Point(0, 50);
            this.pnlFilters.Name = "pnlFilters";
            this.pnlFilters.Size = new System.Drawing.Size(1200, 120);
            this.pnlFilters.TabIndex = 1;

            // lblCategory
            this.lblCategory.AutoSize = true;
            this.lblCategory.Location = new System.Drawing.Point(20, 15);
            this.lblCategory.Name = "lblCategory";
            this.lblCategory.Size = new System.Drawing.Size(52, 13);
            this.lblCategory.TabIndex = 0;
            this.lblCategory.Text = "Category:";

            // cmbCategory
            this.cmbCategory.FormattingEnabled = true;
            this.cmbCategory.Location = new System.Drawing.Point(80, 12);
            this.cmbCategory.Name = "cmbCategory";
            this.cmbCategory.Size = new System.Drawing.Size(150, 21);
            this.cmbCategory.TabIndex = 1;
            this.cmbCategory.SelectedIndexChanged += new System.EventHandler(this.cmbCategory_SelectedIndexChanged);

            // lblSubCategory
            this.lblSubCategory.AutoSize = true;
            this.lblSubCategory.Location = new System.Drawing.Point(280, 15);
            this.lblSubCategory.Name = "lblSubCategory";
            this.lblSubCategory.Size = new System.Drawing.Size(75, 13);
            this.lblSubCategory.TabIndex = 2;
            this.lblSubCategory.Text = "Sub Category:";

            // cmbSubCategory
            this.cmbSubCategory.FormattingEnabled = true;
            this.cmbSubCategory.Location = new System.Drawing.Point(360, 12);
            this.cmbSubCategory.Name = "cmbSubCategory";
            this.cmbSubCategory.Size = new System.Drawing.Size(150, 21);
            this.cmbSubCategory.TabIndex = 3;

            // lblBrand
            this.lblBrand.AutoSize = true;
            this.lblBrand.Location = new System.Drawing.Point(540, 15);
            this.lblBrand.Name = "lblBrand";
            this.lblBrand.Size = new System.Drawing.Size(38, 13);
            this.lblBrand.TabIndex = 4;
            this.lblBrand.Text = "Brand:";

            // cmbBrand
            this.cmbBrand.FormattingEnabled = true;
            this.cmbBrand.Location = new System.Drawing.Point(580, 12);
            this.cmbBrand.Name = "cmbBrand";
            this.cmbBrand.Size = new System.Drawing.Size(150, 21);
            this.cmbBrand.TabIndex = 5;

            // lblStartDate
            this.lblStartDate.AutoSize = true;
            this.lblStartDate.Location = new System.Drawing.Point(20, 45);
            this.lblStartDate.Name = "lblStartDate";
            this.lblStartDate.Size = new System.Drawing.Size(58, 13);
            this.lblStartDate.TabIndex = 6;
            this.lblStartDate.Text = "Start Date:";

            // dtpStartDate
            this.dtpStartDate.Location = new System.Drawing.Point(80, 42);
            this.dtpStartDate.Name = "dtpStartDate";
            this.dtpStartDate.Size = new System.Drawing.Size(150, 20);
            this.dtpStartDate.TabIndex = 7;

            // lblEndDate
            this.lblEndDate.AutoSize = true;
            this.lblEndDate.Location = new System.Drawing.Point(280, 45);
            this.lblEndDate.Name = "lblEndDate";
            this.lblEndDate.Size = new System.Drawing.Size(54, 13);
            this.lblEndDate.TabIndex = 8;
            this.lblEndDate.Text = "End Date:";

            // dtpEndDate
            this.dtpEndDate.Location = new System.Drawing.Point(360, 42);
            this.dtpEndDate.Name = "dtpEndDate";
            this.dtpEndDate.Size = new System.Drawing.Size(150, 20);
            this.dtpEndDate.TabIndex = 9;

            // btnApplyFilters
            this.btnApplyFilters.BackColor = System.Drawing.Color.LimeGreen;
            this.btnApplyFilters.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnApplyFilters.Font = new System.Drawing.Font("Arial", 9F, System.Drawing.FontStyle.Bold);
            this.btnApplyFilters.ForeColor = System.Drawing.Color.White;
            this.btnApplyFilters.Location = new System.Drawing.Point(570, 40);
            this.btnApplyFilters.Name = "btnApplyFilters";
            this.btnApplyFilters.Size = new System.Drawing.Size(80, 25);
            this.btnApplyFilters.TabIndex = 10;
            this.btnApplyFilters.Text = "Apply";
            this.btnApplyFilters.UseVisualStyleBackColor = false;
            this.btnApplyFilters.Click += new System.EventHandler(this.btnApplyFilters_Click);

            // btnClearFilters
            this.btnClearFilters.BackColor = System.Drawing.Color.Orange;
            this.btnClearFilters.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnClearFilters.Font = new System.Drawing.Font("Arial", 9F, System.Drawing.FontStyle.Bold);
            this.btnClearFilters.ForeColor = System.Drawing.Color.White;
            this.btnClearFilters.Location = new System.Drawing.Point(660, 40);
            this.btnClearFilters.Name = "btnClearFilters";
            this.btnClearFilters.Size = new System.Drawing.Size(80, 25);
            this.btnClearFilters.TabIndex = 11;
            this.btnClearFilters.Text = "Clear";
            this.btnClearFilters.UseVisualStyleBackColor = false;
            this.btnClearFilters.Click += new System.EventHandler(this.btnClearFilters_Click);

            // dgvInventoryBalance
            this.dgvInventoryBalance.AllowUserToAddRows = false;
            this.dgvInventoryBalance.AllowUserToDeleteRows = false;
            this.dgvInventoryBalance.BackgroundColor = System.Drawing.Color.White;
            this.dgvInventoryBalance.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgvInventoryBalance.Location = new System.Drawing.Point(0, 170);
            this.dgvInventoryBalance.Name = "dgvInventoryBalance";
            this.dgvInventoryBalance.ReadOnly = true;
            this.dgvInventoryBalance.RowHeadersVisible = false;
            this.dgvInventoryBalance.Size = new System.Drawing.Size(1200, 330);
            this.dgvInventoryBalance.TabIndex = 2;

            // pnlBottom
            this.pnlBottom.BackColor = System.Drawing.Color.WhiteSmoke;
            this.pnlBottom.Controls.Add(this.lblTotalClosingQty);
            this.pnlBottom.Controls.Add(this.lblTotalClosingValue);
            this.pnlBottom.Controls.Add(this.btnExportExcel);
            this.pnlBottom.Controls.Add(this.btnPrint);
            this.pnlBottom.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.pnlBottom.Location = new System.Drawing.Point(0, 500);
            this.pnlBottom.Name = "pnlBottom";
            this.pnlBottom.Size = new System.Drawing.Size(1200, 50);
            this.pnlBottom.TabIndex = 3;

            // lblTotalClosingQty
            this.lblTotalClosingQty.AutoSize = true;
            this.lblTotalClosingQty.Font = new System.Drawing.Font("Arial", 10F, System.Drawing.FontStyle.Bold);
            this.lblTotalClosingQty.Location = new System.Drawing.Point(20, 15);
            this.lblTotalClosingQty.Name = "lblTotalClosingQty";
            this.lblTotalClosingQty.Size = new System.Drawing.Size(140, 16);
            this.lblTotalClosingQty.TabIndex = 0;
            this.lblTotalClosingQty.Text = "Total Closing Qty: 0";

            // lblTotalClosingValue
            this.lblTotalClosingValue.AutoSize = true;
            this.lblTotalClosingValue.Font = new System.Drawing.Font("Arial", 10F, System.Drawing.FontStyle.Bold);
            this.lblTotalClosingValue.Location = new System.Drawing.Point(250, 15);
            this.lblTotalClosingValue.Name = "lblTotalClosingValue";
            this.lblTotalClosingValue.Size = new System.Drawing.Size(160, 16);
            this.lblTotalClosingValue.TabIndex = 1;
            this.lblTotalClosingValue.Text = "Total Closing Value: 0";

            // btnExportExcel
            this.btnExportExcel.BackColor = System.Drawing.Color.Green;
            this.btnExportExcel.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnExportExcel.Font = new System.Drawing.Font("Arial", 9F, System.Drawing.FontStyle.Bold);
            this.btnExportExcel.ForeColor = System.Drawing.Color.White;
            this.btnExportExcel.Location = new System.Drawing.Point(1000, 12);
            this.btnExportExcel.Name = "btnExportExcel";
            this.btnExportExcel.Size = new System.Drawing.Size(90, 25);
            this.btnExportExcel.TabIndex = 2;
            this.btnExportExcel.Text = "Export Excel";
            this.btnExportExcel.UseVisualStyleBackColor = false;
            this.btnExportExcel.Click += new System.EventHandler(this.btnExportExcel_Click);

            // btnPrint
            this.btnPrint.BackColor = System.Drawing.Color.LimeGreen;
            this.btnPrint.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnPrint.Font = new System.Drawing.Font("Arial", 9F, System.Drawing.FontStyle.Bold);
            this.btnPrint.ForeColor = System.Drawing.Color.White;
            this.btnPrint.Location = new System.Drawing.Point(1100, 12);
            this.btnPrint.Name = "btnPrint";
            this.btnPrint.Size = new System.Drawing.Size(90, 25);
            this.btnPrint.TabIndex = 3;
            this.btnPrint.Text = "Print";
            this.btnPrint.UseVisualStyleBackColor = false;
            this.btnPrint.Click += new System.EventHandler(this.btnPrint_Click);

            // InventoryBalanceForm
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1200, 550);
            this.Controls.Add(this.dgvInventoryBalance);
            this.Controls.Add(this.pnlBottom);
            this.Controls.Add(this.pnlFilters);
            this.Controls.Add(this.pnlTop);
            this.Name = "InventoryBalanceForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Inventory Balance Report";
            this.Load += new System.EventHandler(this.InventoryBalanceForm_Load);
            this.pnlTop.ResumeLayout(false);
            this.pnlTop.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvInventoryBalance)).EndInit();
            this.pnlFilters.ResumeLayout(false);
            this.pnlFilters.PerformLayout();
            this.pnlBottom.ResumeLayout(false);
            this.pnlBottom.PerformLayout();
            this.ResumeLayout(false);
        }

        private System.Windows.Forms.Panel pnlTop;
        private System.Windows.Forms.Label lblTitle;
        private System.Windows.Forms.Panel pnlFilters;
        private System.Windows.Forms.DataGridView dgvInventoryBalance;
        private System.Windows.Forms.Panel pnlBottom;
        private System.Windows.Forms.Button btnExportExcel;
        private System.Windows.Forms.Button btnPrint;
        private System.Windows.Forms.Label lblTotalClosingQty;
        private System.Windows.Forms.Label lblTotalClosingValue;
        private System.Windows.Forms.Button btnApplyFilters;
        private System.Windows.Forms.Button btnClearFilters;
        private System.Windows.Forms.ComboBox cmbCategory;
        private System.Windows.Forms.ComboBox cmbSubCategory;
        private System.Windows.Forms.ComboBox cmbBrand;
        private System.Windows.Forms.DateTimePicker dtpStartDate;
        private System.Windows.Forms.DateTimePicker dtpEndDate;
        private System.Windows.Forms.Label lblCategory;
        private System.Windows.Forms.Label lblSubCategory;
        private System.Windows.Forms.Label lblBrand;
        private System.Windows.Forms.Label lblStartDate;
        private System.Windows.Forms.Label lblEndDate;
    }
}
