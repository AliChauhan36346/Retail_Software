using ALA_Accounting.Addition_Classes;
using ALA_Accounting.transaction_classes;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Drawing.Printing;
using System.IO;
using System.Linq;
using System.Windows.Forms;
using System.Diagnostics;

namespace ALA_Accounting.Addition
{
    public partial class BalanceSheet : Form
    {
        BalanceSheetClass balanceSheetClass;
        int financialYearId;
        BalanceSheetClass.BalanceSheetSummary summary;

        public BalanceSheet(int financialYearId)
        {
            InitializeComponent();
            this.financialYearId = financialYearId;
            balanceSheetClass = new BalanceSheetClass();
        }

        private void BalanceSheet_Load(object sender, EventArgs e)
        {
            LoadBalanceSheet();
        }

        private void LoadBalanceSheet()
        {
            try
            {
                // Get balance sheet data
                var groupedData = balanceSheetClass.GetGroupedBalanceSheetData(financialYearId);
                summary = balanceSheetClass.GetBalanceSheetSummary(financialYearId);
                DataTable financialYearInfo = balanceSheetClass.GetFinancialYearInfo(financialYearId);

                // Clear existing data
                dgv_balanceSheet.Rows.Clear();

                // Set title and date info
                if (financialYearInfo.Rows.Count > 0)
                {
                    string yearName = financialYearInfo.Rows[0]["YearName"].ToString();
                    DateTime endDate = Convert.ToDateTime(financialYearInfo.Rows[0]["EndDate"]);
                    lbl_title.Text = $"BALANCE SHEET - {yearName}";
                    lbl_asOfDate.Text = $"As of {endDate:dd-MMM-yyyy}";
                }

                // Add Assets section
                AddSectionHeader("ASSETS");
                decimal totalAssets = 0;

                if (groupedData.ContainsKey("Current Assets موجودہ اثاثے"))
                {
                    AddSubHeader("Current Assets موجودہ اثاثے");
                    var currentAssetItems = groupedData["Current Assets موجودہ اثاثے"];
                    decimal currentAssetTotal = 0;

                    // Group by MainAccountName
                    var groupedByMain = currentAssetItems.GroupBy(x => x.MainAccountName);
                    foreach (var mainGroup in groupedByMain)
                    {
                        decimal mainAccountTotal = mainGroup.Sum(x => x.Amount);
                        AddSectionTotal("    " + mainGroup.Key, mainAccountTotal);
                        currentAssetTotal += mainAccountTotal;
                    }

                    // Add Inventory separately
                    decimal inventoryValue = GetInventoryValue(financialYearId);
                    if (inventoryValue > 0)
                    {
                        AddSectionTotal("    Inventories انویٹری", inventoryValue);
                        currentAssetTotal += inventoryValue;
                    }

                    AddSectionTotal("  Total Current Assets", currentAssetTotal);
                    totalAssets += currentAssetTotal;
                    dgv_balanceSheet.Rows.Add();
                }

                if (groupedData.ContainsKey("Non Current Liabilities  غیر موجودہ ذمہ داریاں"))
                {
                    AddSubHeader("Fixed Assets ثابت اثاثے");
                    var fixedAssetItems = groupedData["Non Current Liabilities  غیر موجودہ ذمہ داریاں"];
                    decimal fixedAssetTotal = 0;

                    // Group by MainAccountName
                    var groupedByMain = fixedAssetItems.GroupBy(x => x.MainAccountName);
                    foreach (var mainGroup in groupedByMain)
                    {
                        decimal mainAccountTotal = mainGroup.Sum(x => x.Amount);
                        AddSectionTotal("    " + mainGroup.Key, mainAccountTotal);
                        fixedAssetTotal += mainAccountTotal;
                    }

                    AddSectionTotal("  Total Fixed Assets", fixedAssetTotal);
                    totalAssets += fixedAssetTotal;
                    dgv_balanceSheet.Rows.Add();
                }

                AddSectionTotal("TOTAL ASSETS", totalAssets, true);
                dgv_balanceSheet.Rows[dgv_balanceSheet.RowCount - 1].DefaultCellStyle.BackColor = Color.LightGray;
                dgv_balanceSheet.Rows[dgv_balanceSheet.RowCount - 1].DefaultCellStyle.Font = new Font("Arial", 11, FontStyle.Bold);

                dgv_balanceSheet.Rows.Add();

                // Add Liabilities section
                AddSectionHeader("LIABILITIES");
                decimal totalLiabilities = 0;

                if (groupedData.ContainsKey("Current Liabilities  موجودہ ذمہ داریاں"))
                {
                    AddSubHeader("Current Liabilities موجودہ ذمہ داریاں");
                    var currentLiabItems = groupedData["Current Liabilities  موجودہ ذمہ داریاں"];
                    decimal currentLiabTotal = 0;

                    // Group by MainAccountName
                    var groupedByMain = currentLiabItems.GroupBy(x => x.MainAccountName);
                    foreach (var mainGroup in groupedByMain)
                    {
                        decimal mainAccountTotal = mainGroup.Sum(x => x.Amount);
                        AddSectionTotal("    " + mainGroup.Key, mainAccountTotal);
                        currentLiabTotal += mainAccountTotal;
                    }

                    AddSectionTotal("  Total Current Liabilities", currentLiabTotal);
                    totalLiabilities += currentLiabTotal;
                    dgv_balanceSheet.Rows.Add();
                }

                AddSectionTotal("TOTAL LIABILITIES", totalLiabilities, true);
                dgv_balanceSheet.Rows[dgv_balanceSheet.RowCount - 1].DefaultCellStyle.BackColor = Color.LightGray;
                dgv_balanceSheet.Rows[dgv_balanceSheet.RowCount - 1].DefaultCellStyle.Font = new Font("Arial", 11, FontStyle.Bold);

                dgv_balanceSheet.Rows.Add();

                // Add Income section
                if (groupedData.ContainsKey("Income آمدنی"))
                {
                    AddSectionHeader("INCOME");
                    var incomeItems = groupedData["Income آمدنی"];
                    decimal incomeTotal = 0;

                    // Group by MainAccountName
                    var groupedByMain = incomeItems.GroupBy(x => x.MainAccountName);
                    foreach (var mainGroup in groupedByMain)
                    {
                        decimal mainAccountTotal = mainGroup.Sum(x => x.Amount);
                        AddSectionTotal("  " + mainGroup.Key, mainAccountTotal);
                        incomeTotal += mainAccountTotal;
                    }

                    AddSectionTotal("Total Income آمدنی", incomeTotal, true);
                    dgv_balanceSheet.Rows[dgv_balanceSheet.RowCount - 1].DefaultCellStyle.BackColor = Color.LightGray;
                    dgv_balanceSheet.Rows.Add();
                }

                // Add Cost of Sales section
                if (groupedData.ContainsKey("Cost of Sales فروخت کی لاگت"))
                {
                    AddSectionHeader("COST OF SALES");
                    var costItems = groupedData["Cost of Sales فروخت کی لاگت"];
                    decimal costsTotal = 0;

                    // Group by MainAccountName
                    var groupedByMain = costItems.GroupBy(x => x.MainAccountName);
                    foreach (var mainGroup in groupedByMain)
                    {
                        decimal mainAccountTotal = mainGroup.Sum(x => x.Amount);
                        AddSectionTotal("  " + mainGroup.Key, mainAccountTotal);
                        costsTotal += mainAccountTotal;
                    }

                    AddSectionTotal("Total Cost of Sales فروخت کی لاگت", costsTotal, true);
                    dgv_balanceSheet.Rows[dgv_balanceSheet.RowCount - 1].DefaultCellStyle.BackColor = Color.LightGray;
                    dgv_balanceSheet.Rows.Add();
                }

                // Add Expenses section
                AddSectionHeader("EXPENSES");
                decimal expensesTotal = 0;

                if (groupedData.ContainsKey("Financial Expense  مالی اخراجات"))
                {
                    AddSubHeader("Financial Expense مالی اخراجات");
                    var finExpItems = groupedData["Financial Expense  مالی اخراجات"];
                    decimal finExpTotal = 0;

                    var groupedByMain = finExpItems.GroupBy(x => x.MainAccountName);
                    foreach (var mainGroup in groupedByMain)
                    {
                        decimal mainAccountTotal = mainGroup.Sum(x => x.Amount);
                        AddSectionTotal("    " + mainGroup.Key, mainAccountTotal);
                        finExpTotal += mainAccountTotal;
                    }

                    AddSectionTotal("  Total Financial Expense", finExpTotal);
                    expensesTotal += finExpTotal;
                }

                if (groupedData.ContainsKey("Operating Expense  آپریٹنگ اخراجات"))
                {
                    AddSubHeader("Operating Expense آپریٹنگ اخراجات");
                    var opExpItems = groupedData["Operating Expense  آپریٹنگ اخراجات"];
                    decimal opExpTotal = 0;

                    var groupedByMain = opExpItems.GroupBy(x => x.MainAccountName);
                    foreach (var mainGroup in groupedByMain)
                    {
                        decimal mainAccountTotal = mainGroup.Sum(x => x.Amount);
                        AddSectionTotal("    " + mainGroup.Key, mainAccountTotal);
                        opExpTotal += mainAccountTotal;
                    }

                    AddSectionTotal("  Total Operating Expense", opExpTotal);
                    expensesTotal += opExpTotal;
                }

                if (groupedData.ContainsKey("Other Expense  دوسرے اخراجات"))
                {
                    AddSubHeader("Other Expense دوسرے اخراجات");
                    var otherExpItems = groupedData["Other Expense  دوسرے اخراجات"];
                    decimal otherExpTotal = 0;

                    var groupedByMain = otherExpItems.GroupBy(x => x.MainAccountName);
                    foreach (var mainGroup in groupedByMain)
                    {
                        decimal mainAccountTotal = mainGroup.Sum(x => x.Amount);
                        AddSectionTotal("    " + mainGroup.Key, mainAccountTotal);
                        otherExpTotal += mainAccountTotal;
                    }

                    AddSectionTotal("  Total Other Expense", otherExpTotal);
                    expensesTotal += otherExpTotal;
                }

                AddSectionTotal("Total Expenses", expensesTotal, true);
                dgv_balanceSheet.Rows[dgv_balanceSheet.RowCount - 1].DefaultCellStyle.BackColor = Color.LightGray;
                dgv_balanceSheet.Rows.Add();

                // Add summary section
                AddSectionHeader("FINANCIAL SUMMARY");
                AddSummaryRow("Total Assets", totalAssets.ToString("N2"));
                AddSummaryRow("Total Liabilities", totalLiabilities.ToString("N2"));

                if (summary.IsBalanced)
                {
                    AddSummaryRow("Balance Status", "✓ BALANCED", Color.Green);
                }
                else
                {
                    AddSummaryRow("Balance Status", "✗ UNBALANCED", Color.Red);
                }

                // Auto-fit columns
                dgv_balanceSheet.AutoResizeColumns();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error loading balance sheet: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private decimal GetInventoryValue(int financialYearId)
        {
            decimal inventoryValue = 0;
            try
            {
                Connection conn = new Connection();
                conn.openConnection();

                string query = @"
                    -- Get the financial year date range
                    DECLARE @StartDate DATETIME;
                    DECLARE @EndDate DATETIME;
                    
                    SELECT @StartDate = StartDate, @EndDate = EndDate 
                    FROM FinancialYear 
                    WHERE FinancialYearID = @FinancialYearID;

                    -- Calculate inventory value based on date range
                    SELECT COALESCE(SUM(iob.Quantity * iob.Rate), 0) +
                           COALESCE(SUM(CASE WHEN it.TransactionType = 'Purchase' THEN it.Quantity * it.Rate 
                                           ELSE -it.Quantity * it.Rate END), 0) AS InventoryBalance
                    FROM InventoryOpeningBalance iob
                    LEFT JOIN InventoryTransaction it ON iob.ItemID = it.ItemID 
                        AND it.TransactionDate >= @StartDate 
                        AND it.TransactionDate <= @EndDate
                    WHERE iob.FinancialYearID = @FinancialYearID";

                using (SqlCommand cmd = new SqlCommand(query, conn.connection))
                {
                    cmd.Parameters.AddWithValue("@FinancialYearID", financialYearId);
                    object result = cmd.ExecuteScalar();
                    if (result != null && result != DBNull.Value)
                    {
                        inventoryValue = Convert.ToDecimal(result);
                    }
                }

                conn.closeConnection();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error calculating inventory value: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

            return inventoryValue;
        }

        private void AddSectionHeader(string sectionName)
        {
            int rowIndex = dgv_balanceSheet.Rows.Add();
            dgv_balanceSheet.Rows[rowIndex].Cells[0].Value = sectionName;
            dgv_balanceSheet.Rows[rowIndex].DefaultCellStyle.BackColor = Color.Navy;
            dgv_balanceSheet.Rows[rowIndex].DefaultCellStyle.ForeColor = Color.White;
            dgv_balanceSheet.Rows[rowIndex].DefaultCellStyle.Font = new Font("Arial", 11, FontStyle.Bold);
        }

        private void AddSubHeader(string subHeaderName)
        {
            int rowIndex = dgv_balanceSheet.Rows.Add();
            dgv_balanceSheet.Rows[rowIndex].Cells[0].Value = "  " + subHeaderName;
            dgv_balanceSheet.Rows[rowIndex].DefaultCellStyle.BackColor = Color.LightBlue;
            dgv_balanceSheet.Rows[rowIndex].DefaultCellStyle.Font = new Font("Arial", 10, FontStyle.Italic);
        }

        private decimal AddItemsToGrid(List<BalanceSheetClass.BalanceSheetItem> items)
        {
            decimal total = 0;
            foreach (var item in items)
            {
                int rowIndex = dgv_balanceSheet.Rows.Add();
                dgv_balanceSheet.Rows[rowIndex].Cells[0].Value = "    " + item.AccountName;
                dgv_balanceSheet.Rows[rowIndex].Cells[1].Value = item.Amount.ToString("N2");
                dgv_balanceSheet.Rows[rowIndex].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
                total += item.Amount;
            }
            return total;
        }

        private void AddSectionTotal(string label, decimal amount, bool isBold = false)
        {
            int rowIndex = dgv_balanceSheet.Rows.Add();
            dgv_balanceSheet.Rows[rowIndex].Cells[0].Value = label;
            dgv_balanceSheet.Rows[rowIndex].Cells[1].Value = amount.ToString("N2");

            if (isBold)
            {
                dgv_balanceSheet.Rows[rowIndex].DefaultCellStyle.BackColor = Color.LightGray;
                dgv_balanceSheet.Rows[rowIndex].DefaultCellStyle.Font = new Font("Arial", 10, FontStyle.Bold);
            }
            else
            {
                dgv_balanceSheet.Rows[rowIndex].DefaultCellStyle.Font = new Font("Arial", 10, FontStyle.Underline);
            }
        }

        private void AddSummaryRow(string label, string value, Color? foreColor = null)
        {
            int rowIndex = dgv_balanceSheet.Rows.Add();
            dgv_balanceSheet.Rows[rowIndex].Cells[0].Value = label;
            dgv_balanceSheet.Rows[rowIndex].Cells[1].Value = value;

            if (foreColor.HasValue)
            {
                dgv_balanceSheet.Rows[rowIndex].DefaultCellStyle.ForeColor = foreColor.Value;
                dgv_balanceSheet.Rows[rowIndex].DefaultCellStyle.Font = new Font("Arial", 10, FontStyle.Bold);
            }
        }

        private void btn_exportPDF_Click(object sender, EventArgs e)
        {
            try
            {
                SaveFileDialog saveDialog = new SaveFileDialog
                {
                    Filter = "Text Files (*.txt)|*.txt|CSV Files (*.csv)|*.csv",
                    FileName = $"BalanceSheet_{DateTime.Now:yyyyMMdd_HHmmss}.txt"
                };

                if (saveDialog.ShowDialog() == DialogResult.OK)
                {
                    ExportToText(saveDialog.FileName);
                    MessageBox.Show("Balance Sheet exported successfully!", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    Process.Start(saveDialog.FileName);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error exporting: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btn_exportExcel_Click(object sender, EventArgs e)
        {
            try
            {
                SaveFileDialog saveDialog = new SaveFileDialog
                {
                    Filter = "Excel Files (*.xlsx)|*.xlsx",
                    FileName = $"BalanceSheet_{DateTime.Now:yyyyMMdd_HHmmss}.xlsx"
                };

                if (saveDialog.ShowDialog() == DialogResult.OK)
                {
                    ExportToExcel(saveDialog.FileName);
                    MessageBox.Show("Balance Sheet exported to Excel successfully!", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    Process.Start(saveDialog.FileName);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error exporting to Excel: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void ExportToPDF(string filePath)
        {
            // Using simple text export
            try
            {
                using (StreamWriter writer = new StreamWriter(filePath))
                {
                    writer.WriteLine(lbl_title.Text);
                    writer.WriteLine(lbl_asOfDate.Text);
                    writer.WriteLine(new string('=', 80));
                    writer.WriteLine();

                    foreach (DataGridViewRow row in dgv_balanceSheet.Rows)
                    {
                        string label = row.Cells[0].Value?.ToString() ?? "";
                        string amount = row.Cells[1].Value?.ToString() ?? "";
                        writer.WriteLine($"{label,-60} {amount,20}");
                    }
                }
            }
            catch (Exception ex)
            {
                throw new Exception("Error exporting: " + ex.Message);
            }
        }

        private void ExportToText(string filePath)
        {
            try
            {
                using (StreamWriter writer = new StreamWriter(filePath))
                {
                    writer.WriteLine(lbl_title.Text);
                    writer.WriteLine(lbl_asOfDate.Text);
                    writer.WriteLine(new string('=', 80));
                    writer.WriteLine();

                    foreach (DataGridViewRow row in dgv_balanceSheet.Rows)
                    {
                        string label = row.Cells[0].Value?.ToString() ?? "";
                        string amount = row.Cells[1].Value?.ToString() ?? "";
                        writer.WriteLine($"{label,-60} {amount,20}");
                    }
                }
            }
            catch (Exception ex)
            {
                throw new Exception("Error exporting: " + ex.Message);
            }
        }

        private void ExportToExcel(string filePath)
        {
            try
            {
                using (StreamWriter writer = new StreamWriter(filePath))
                {
                    // Write header
                    writer.WriteLine(lbl_title.Text);
                    writer.WriteLine(lbl_asOfDate.Text);
                    writer.WriteLine();

                    // Write column headers
                    writer.WriteLine($"{"Description",-60}\t{"Amount",20}");
                    writer.WriteLine(new string('=', 80));

                    // Write data
                    foreach (DataGridViewRow row in dgv_balanceSheet.Rows)
                    {
                        string label = row.Cells[0].Value?.ToString() ?? "";
                        string amount = row.Cells[1].Value?.ToString() ?? "";
                        writer.WriteLine($"{label,-60}\t{amount,20}");
                    }
                }
            }
            catch (Exception ex)
            {
                throw new Exception("Error generating Excel: " + ex.Message);
            }
        }

        private void btn_print_Click(object sender, EventArgs e)
        {
            try
            {
                PrintPreviewDialog printPreviewDialog = new PrintPreviewDialog();
                PrintDocument printDocument = new PrintDocument();
                printDocument.PrintPage += PrintDocument_PrintPage;
                printPreviewDialog.Document = printDocument;
                printPreviewDialog.ShowDialog();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error printing balance sheet: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void PrintDocument_PrintPage(object sender, System.Drawing.Printing.PrintPageEventArgs e)
        {
            int lineHeight = 20;
            int yPosition = 50;
            Font titleFont = new Font("Arial", 14, FontStyle.Bold);
            Font regularFont = new Font("Arial", 10);

            e.Graphics.DrawString(lbl_title.Text, titleFont, Brushes.Black, 50, yPosition);
            yPosition += lineHeight + 10;
            e.Graphics.DrawString(lbl_asOfDate.Text, regularFont, Brushes.Black, 50, yPosition);
            yPosition += lineHeight + 10;

            foreach (DataGridViewRow row in dgv_balanceSheet.Rows)
            {
                string label = row.Cells[0].Value?.ToString() ?? "";
                string amount = row.Cells[1].Value?.ToString() ?? "";

                e.Graphics.DrawString(label, regularFont, Brushes.Black, 50, yPosition);
                e.Graphics.DrawString(amount, regularFont, Brushes.Black, 400, yPosition);

                yPosition += lineHeight;

                if (yPosition > e.MarginBounds.Bottom)
                {
                    e.HasMorePages = true;
                    return;
                }
            }

            e.HasMorePages = false;
        }
    }
}
