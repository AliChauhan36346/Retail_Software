// INTEGRATION EXAMPLE
// Add this to your main form or menu form where you manage financial year operations

// Example 1: Add to a Menu Click Event
// ====================================

/*
private void toolStripMenuItem_ViewBalanceSheet_Click(object sender, EventArgs e)
{
    if (currentFinancialYearId <= 0)
    {
        MessageBox.Show("Please select a financial year first.", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
        return;
    }

    try
    {
        BalanceSheet balanceSheetForm = new BalanceSheet(currentFinancialYearId);
        balanceSheetForm.ShowDialog(this);
    }
    catch (Exception ex)
    {
        MessageBox.Show("Error opening balance sheet: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
    }
}
*/

// Example 2: Add to a Button Click Event
// ========================================

/*
private void btn_balanceSheet_Click(object sender, EventArgs e)
{
    if (financialYearId <= 0)
    {
        MessageBox.Show("No financial year selected.", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
        return;
    }

    BalanceSheet balanceSheet = new BalanceSheet(financialYearId);
    balanceSheet.ShowDialog();
}
*/

// Example 3: Keyboard Shortcut
// =============================

/*
// Add to Form_Load or Form_KeyDown event
protected override bool ProcessCmdKey(ref Message msg, Keys keyData)
{
    if (keyData == (Keys.Control | Keys.B)) // Ctrl+B for Balance Sheet
    {
        if (currentFinancialYearId > 0)
        {
            new BalanceSheet(currentFinancialYearId).ShowDialog();
            return true;
        }
    }
    return base.ProcessCmdKey(ref msg, keyData);
}
*/

// Example 4: From Financial Year Form After Selection
// ====================================================

/*
In your FinancialYear.cs or similar form:

private void combo_financialYear_SelectedIndexChanged(object sender, EventArgs e)
{
    if (combo_financialYear.SelectedItem is ListBoxItem selectedYear)
    {
        int yearId = int.Parse(selectedYear.ItemID);
        
        // Enable balance sheet button
        btn_viewBalanceSheet.Enabled = true;
        btn_viewBalanceSheet.Tag = yearId;
    }
}

private void btn_viewBalanceSheet_Click(object sender, EventArgs e)
{
    if (btn_viewBalanceSheet.Tag is int yearId && yearId > 0)
    {
        BalanceSheet balanceSheet = new BalanceSheet(yearId);
        balanceSheet.ShowDialog();
    }
}
*/

// Example 5: Display in Main Dashboard
// =====================================

/*
// In your main form
private int selectedFinancialYearId = 0;

public void LoadDashboard(int financialYearId)
{
    selectedFinancialYearId = financialYearId;
    
    // Other dashboard loading code...
    
    // Enable financial reports
    btn_profitLoss.Enabled = true;
    btn_balanceSheet.Enabled = true;
    btn_trialBalance.Enabled = true;
}

private void btn_balanceSheet_Click(object sender, EventArgs e)
{
    if (selectedFinancialYearId > 0)
    {
        BalanceSheet form = new BalanceSheet(selectedFinancialYearId);
        form.MdiParent = this; // If using MDI
        form.Show();
    }
}
*/

// REQUIRED USING STATEMENTS
// ==========================

/*
Add these to any form that will call the Balance Sheet:

using ALA_Accounting.Addition;
using ALA_Accounting.Addition_Classes;
*/

// MENU STRUCTURE RECOMMENDATION
// ==============================

/*
File Menu
??? New...
??? Open...
??? Exit

Edit Menu
??? Accounts
??? Transactions
??? Settings

Financial Reports
??? Trial Balance
??? Income Statement (P&L)
??? Balance Sheet          ? YOUR NEW REPORT
??? Cash Flow Statement
??? Financial Ratios

Tools Menu
??? Import Data
??? Export Data
??? Utilities

Help Menu
??? About
??? Documentation
*/

// DATABASE VERIFICATION QUERY
// ============================

/*
Run this SQL to verify your system is ready for Balance Sheet:

-- Check MainAccounts have FinancialStatementComponent
SELECT MainAccountID, MainAccountName, FinancialStatementComponent 
FROM MainAccounts 
WHERE FinancialStatementComponent IS NULL;

-- Check SubAccounts are linked correctly
SELECT sa.SubAccountTypeId, sa.SubAccountTypeName, ma.MainAccountName 
FROM SubAccounts sa
LEFT JOIN MainAccounts ma ON sa.MainAccountID = ma.MainAccountID
WHERE ma.MainAccountID IS NULL;

-- Check you have accounts with classifications
SELECT DISTINCT FinancialStatementComponent, COUNT(*) as Count
FROM MainAccounts
GROUP BY FinancialStatementComponent;

-- Expected output:
-- Assets, Liabilities, Capital (or similar)
*/

// TESTING CHECKLIST
// =================

/*
Before deploying, test:

? Open BalanceSheet form with valid financial year
? Verify all sections display (Assets, Liabilities, Equity)
? Check totals are calculated correctly
? Verify Current Ratio is displayed
? Test Print functionality
? Export to Excel - verify file created
? Export to Text - verify file created
? Close and reopen to ensure data loads each time
? Test with different financial years
? Check error handling with no data
? Verify balance sheet balances correctly
*/

// PERFORMANCE OPTIMIZATION (Optional)
// ====================================

/*
If performance is slow with large datasets, consider:

1. Add indexes to frequently queried columns:
   CREATE INDEX IX_Transactions_YearID ON Transactions(FinancialYearID);
   CREATE INDEX IX_AccountsOB_YearID ON AccountsOpeningBalance(FinancialYearID);

2. Cache data temporarily:
   private static Dictionary<int, DataTable> balanceSheetCache = new Dictionary<int, DataTable>();

3. Use async operations for large queries:
   public async Task<DataTable> GetBalanceSheetDataAsync(int financialYearID)
   {
       return await Task.Run(() => GetBalanceSheetData(financialYearID));
   }
*/

// CUSTOM BRANDING EXAMPLE
// =======================

/*
To customize appearance, modify BalanceSheet.Designer.cs:

// Change header color
this.panel1.BackColor = System.Drawing.Color.DarkBlue; // Your company color

// Change button colors
this.btn_exportExcel.BackColor = System.Drawing.Color.Green;

// Add company logo
// Add a PictureBox to panel1 with your logo

// Change font
this.dgv_balanceSheet.DefaultCellStyle.Font = new Font("Calibri", 11);
*/

// REGULATORY/ACCOUNTING COMPLIANCE
// =================================

/*
Your balance sheet should comply with:

- Generally Accepted Accounting Principles (GAAP)
- International Financial Reporting Standards (IFRS)
- Local accounting standards (Pakistan: IAS/IFRS equivalent)

The current implementation covers:
? Proper account classification
? Asset-Liability-Equity structure
? Current/Fixed asset separation
? Balance verification
? Ratio calculations

Future enhancements could include:
- Footnotes and disclosures
- Comparative analysis (YoY)
- Budget vs Actual
- Segment reporting
*/
