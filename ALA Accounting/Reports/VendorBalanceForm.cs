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
    public partial class VendorBalanceForm : Form
    {
        private int financialYearId;
        private VendorBalanceClass reportClass;

        public VendorBalanceForm(int financialYearId)
        {
            InitializeComponent();
            this.financialYearId = financialYearId;
            reportClass = new VendorBalanceClass();
        }

        private void VendorBalanceForm_Load(object sender, EventArgs e)
        {
            LoadFilters();
            LoadReport();
        }

        private void LoadFilters()
        {
            try
            {
                // Set date range to financial year
                dtpStartDate.Value = new DateTime(DateTime.Now.Year, 1, 1);
                dtpEndDate.Value = DateTime.Now;
                
                // Update labels with date format
                UpdateDateLabels();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error loading filters: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void UpdateDateLabels()
        {
            // Format: 23/2/2020
            string startDateLabel = dtpStartDate.Value.ToString("d/M/yyyy");
            string endDateLabel = dtpEndDate.Value.ToString("d/M/yyyy");
            // You can display these in labels if needed
        }

        private void LoadReport()
        {
            try
            {
                DateTime startDate = dtpStartDate.Value;
                DateTime endDate = dtpEndDate.Value;

                DataTable reportData = reportClass.LoadData(financialYearId, startDate, endDate);
                
                // Add totals row
                DataRow totalRow = reportData.NewRow();
                totalRow["Vendor Name"] = "TOTAL";
                totalRow["Opening Balance"] = reportData.AsEnumerable().Sum(r => Convert.ToDecimal(r["Opening Balance"]));
                totalRow["Debit"] = reportData.AsEnumerable().Sum(r => Convert.ToDecimal(r["Debit"]));
                totalRow["Credit"] = reportData.AsEnumerable().Sum(r => Convert.ToDecimal(r["Credit"]));
                totalRow["Closing Balance"] = reportData.AsEnumerable().Sum(r => Convert.ToDecimal(r["Closing Balance"]));
                reportData.Rows.Add(totalRow);

                dgvVendorBalance.DataSource = reportData;

                // Load summary
                DataTable summaryData = reportClass.GetSummary(financialYearId, startDate, endDate);
                if (summaryData.Rows.Count > 0)
                {
                    DataRow summaryRow = summaryData.Rows[0];
                    lblTotalVendors.Text = "Total Vendors: " + Convert.ToInt32(summaryRow["TotalVendors"]).ToString();
                    lblTotalClosingBalance.Text = "Total Closing Balance: " + Convert.ToDecimal(summaryRow["TotalClosingBalance"]).ToString("N2");
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
                foreach (DataGridViewColumn col in dgvVendorBalance.Columns)
                {
                    col.AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;

                    // Format numeric columns with currency and 2 decimals
                    if (col.HeaderText.Contains("Balance") || col.HeaderText.Contains("Debit") || col.HeaderText.Contains("Credit"))
                    {
                        col.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
                        col.DefaultCellStyle.Format = "N2";
                    }

                    // Header styling
                    col.HeaderCell.Style.BackColor = Color.Navy;
                    col.HeaderCell.Style.ForeColor = Color.White;
                    col.HeaderCell.Style.Font = new Font("Arial", 10, FontStyle.Bold);
                }

                // Make TOTAL row bold and highlighted
                if (dgvVendorBalance.Rows.Count > 0)
                {
                    DataGridViewRow totalRow = dgvVendorBalance.Rows[dgvVendorBalance.Rows.Count - 1];
                    totalRow.DefaultCellStyle.BackColor = Color.LightGray;
                    totalRow.DefaultCellStyle.Font = new Font("Arial", 10, FontStyle.Bold);
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
                saveFileDialog.FileName = "VendorBalance_" + DateTime.Now.ToString("yyyy-MM-dd");

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
                StringBuilder sb = new StringBuilder();

                // Headers
                foreach (DataGridViewColumn col in dgvVendorBalance.Columns)
                {
                    sb.Append(col.HeaderText + "\t");
                }
                sb.AppendLine();

                // Data rows
                foreach (DataGridViewRow row in dgvVendorBalance.Rows)
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
            e.Graphics.DrawString("Vendor Balance Report", new Font("Arial", 14, FontStyle.Bold), Brushes.Black, 20, 20);
            e.Graphics.DrawString("Date: " + DateTime.Now.ToString("dd-MMM-yyyy"), new Font("Arial", 10), Brushes.Black, 20, 50);
        }
    }
}
