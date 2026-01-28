using ALA_Accounting.Reports_Classes;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ALA_Accounting.Reports
{
    public partial class InventoryBalanceForm : Form
    {
        private int financialYearId;
        private InventoryBalanceClass reportClass;

        public InventoryBalanceForm(int financialYearId)
        {
            InitializeComponent();
            this.financialYearId = financialYearId;
            reportClass = new InventoryBalanceClass();
        }

        private void InventoryBalanceForm_Load(object sender, EventArgs e)
        {
            LoadFilters();
            LoadReport();
        }

        private void LoadFilters()
        {
            try
            {
                // Load Categories
                DataTable categories = reportClass.LoadCategories();
                cmbCategory.DataSource = categories;
                cmbCategory.DisplayMember = "CategoryName";
                cmbCategory.ValueMember = "InventoryCategoryID";
                cmbCategory.SelectedIndex = -1;

                // Load Brands
                DataTable brands = reportClass.LoadBrands();
                cmbBrand.DataSource = brands;
                cmbBrand.DisplayMember = "BrandName";
                cmbBrand.ValueMember = "BrandName";
                cmbBrand.SelectedIndex = -1;

                // Set date range to financial year
                dtpStartDate.Value = new DateTime(DateTime.Now.Year, 1, 1);
                dtpEndDate.Value = DateTime.Now;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error loading filters: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void cmbCategory_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cmbCategory.SelectedValue != null && int.TryParse(cmbCategory.SelectedValue.ToString(), out int categoryID))
            {
                DataTable subCategories = reportClass.LoadSubCategories(categoryID);
                cmbSubCategory.DataSource = subCategories;
                cmbSubCategory.DisplayMember = "SubCategoryName";
                cmbSubCategory.ValueMember = "SubCategoryID";
                cmbSubCategory.SelectedIndex = -1;
            }
            else
            {
                cmbSubCategory.DataSource = null;
            }
        }

        private void LoadReport()
        {
            try
            {
                int? categoryID = cmbCategory.SelectedValue != null ? (int?)Convert.ToInt32(cmbCategory.SelectedValue) : null;
                int? subCategoryID = cmbSubCategory.SelectedValue != null ? (int?)Convert.ToInt32(cmbSubCategory.SelectedValue) : null;
                string brand = cmbBrand.SelectedValue != null ? cmbBrand.SelectedValue.ToString() : null;
                DateTime startDate = dtpStartDate.Value;
                DateTime endDate = dtpEndDate.Value;

                DataTable reportData = reportClass.LoadData(financialYearId, categoryID, subCategoryID, brand, startDate, endDate);
                dgvInventoryBalance.DataSource = reportData;

                // Load summary
                DataTable summaryData = reportClass.GetSummary(financialYearId, categoryID, subCategoryID, brand, startDate, endDate);
                if (summaryData.Rows.Count > 0)
                {
                    DataRow summaryRow = summaryData.Rows[0];
                    lblTotalClosingQty.Text = "Total Closing Balance: " + Convert.ToDecimal(summaryRow["TotalClosingBalance"]).ToString("N2");
                    lblTotalClosingValue.Text = "Total Value: " + Convert.ToDecimal(summaryRow["TotalValue"]).ToString("N2");
                }

                // Format columns
                FormatColumns();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error loading report: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void FormatColumns()
        {
            try
            {
                // Hide Item Code column if needed, adjust column widths
                foreach (DataGridViewColumn col in dgvInventoryBalance.Columns)
                {
                    col.AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;

                    // Format numeric columns
                    if (col.Name.Contains("Qty") || col.Name.Contains("Rate") || col.Name.Contains("Cost") || col.Name.Contains("Value"))
                    {
                        col.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
                        col.DefaultCellStyle.Format = "N2";
                    }

                    // Header styling
                    col.HeaderCell.Style.BackColor = Color.Navy;
                    col.HeaderCell.Style.ForeColor = Color.White;
                    col.HeaderCell.Style.Font = new Font("Arial", 10, FontStyle.Bold);
                }
            }
            catch { }
        }

        private void btnApplyFilters_Click(object sender, EventArgs e)
        {
            LoadReport();
        }

        private void btnClearFilters_Click(object sender, EventArgs e)
        {
            cmbCategory.SelectedIndex = -1;
            cmbSubCategory.DataSource = null;
            cmbBrand.SelectedIndex = -1;
            dtpStartDate.Value = new DateTime(DateTime.Now.Year, 1, 1);
            dtpEndDate.Value = DateTime.Now;
            LoadReport();
        }

        private void btnExportExcel_Click(object sender, EventArgs e)
        {
            try
            {
                SaveFileDialog saveFileDialog = new SaveFileDialog();
                saveFileDialog.Filter = "Excel Files (*.xlsx)|*.xlsx";
                saveFileDialog.FileName = "InventoryBalance_" + DateTime.Now.ToString("yyyy-MM-dd");

                if (saveFileDialog.ShowDialog() == DialogResult.OK)
                {
                    ExportToExcel(saveFileDialog.FileName);
                    MessageBox.Show("Report exported successfully!", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error exporting to Excel: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void ExportToExcel(string filePath)
        {
            try
            {
                // Simple Excel export using tab-separated values
                StringBuilder sb = new StringBuilder();

                // Headers
                foreach (DataGridViewColumn col in dgvInventoryBalance.Columns)
                {
                    sb.Append(col.HeaderText + "\t");
                }
                sb.AppendLine();

                // Data rows
                foreach (DataGridViewRow row in dgvInventoryBalance.Rows)
                {
                    foreach (DataGridViewCell cell in row.Cells)
                    {
                        sb.Append((cell.Value ?? "").ToString() + "\t");
                    }
                    sb.AppendLine();
                }

                System.IO.File.WriteAllText(filePath, sb.ToString());
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error: " + ex.Message);
            }
        }

        private void btnPrint_Click(object sender, EventArgs e)
        {
            try
            {
                PrintPreviewDialog printDialog = new PrintPreviewDialog();
                System.Drawing.Printing.PrintDocument printDoc = new System.Drawing.Printing.PrintDocument();
                printDoc.PrintPage += PrintDoc_PrintPage;
                printDialog.Document = printDoc;
                printDialog.ShowDialog();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error printing: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void PrintDoc_PrintPage(object sender, System.Drawing.Printing.PrintPageEventArgs e)
        {
            // Basic print implementation
            e.Graphics.DrawString("Inventory Balance Report", new Font("Arial", 14, FontStyle.Bold), Brushes.Black, 20, 20);
            e.Graphics.DrawString("Date: " + DateTime.Now.ToString("dd-MMM-yyyy"), new Font("Arial", 10), Brushes.Black, 20, 50);
        }
    }
}
