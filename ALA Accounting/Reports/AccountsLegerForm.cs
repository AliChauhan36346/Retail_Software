using ALA_Accounting.Addition;
using ALA_Accounting.Reports_Classes;
using ALA_Accounting.transaction_classes;
using ALA_Accounting.TransactionForms;
using ALA_Accounting.UsersForm;
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
    public partial class AccountsLegerForm : Form
    {
        int financialYearId;
        CommonFunctions commonFunctions = new CommonFunctions();
        AccountsLegerClass legerClass = new AccountsLegerClass();

        public AccountsLegerForm(int financialYearId)
        {
            this.financialYearId = financialYearId;
            InitializeComponent();

        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void guna2ShadowPanel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void btn_search_Click(object sender, EventArgs e)
        {
            // Validate account ID input
            if (!int.TryParse(txt_accountId.Text, out int accountId))
            {
                MessageBox.Show("Please enter a valid Account ID", "Invalid Input", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            // Load the full ledger data
            DataTable ledgerTable = legerClass.GetAccountLedger(accountId, financialYearId);

            // Check if date filter is applied
            if (chk_date.Checked)
            {
                DateTime startDate = dtmStart.Value.Date;
                DateTime endDate= dtmEnd.Value.Date;

                // Calculate Balance Brought Forward
                decimal balanceBroughtForward = 0;
                foreach (DataRow row in ledgerTable.Rows)
                {
                    DateTime rowDate = Convert.ToDateTime(row["Date"]);

                    if (rowDate < startDate) // Sum all previous transactions before the selected date
                    {
                        decimal debit = Convert.ToDecimal(row["Debit"]);
                        decimal credit = Convert.ToDecimal(row["Credit"]);
                        balanceBroughtForward += debit - credit;
                    }
                }

                // Remove older records and keep only those after the selected date
                DataRow[] rowsToKeep = ledgerTable.Select($"Date >= '{startDate:yyyy-MM-dd}' AND Date <= '{endDate:yyyy-MM-dd}'");
                DataTable filteredTable = ledgerTable.Clone(); // Clone structure
                foreach (DataRow row in rowsToKeep)
                    filteredTable.ImportRow(row);

                // Insert Balance Brought Forward row at the top
                DataRow bbfRow = filteredTable.NewRow();
                bbfRow["Date"] = startDate;
                bbfRow["TransactionID"] = "BBF"; // Balance Brought Forward
                bbfRow["Description"] = "Balance Brought Forward";
                bbfRow["Debit"] = DBNull.Value;
                bbfRow["Credit"] = DBNull.Value;
                bbfRow["Balance"] = balanceBroughtForward;
                bbfRow["Status"] = balanceBroughtForward >= 0 ? "Debit" : "Credit";

                filteredTable.Rows.InsertAt(bbfRow, 0); // Add BBF row at the top

                // Update the BindingSource
                AccountLegerBS.DataSource = filteredTable;
            }
            else
            {
                // If no date filter, show full ledger
                AccountLegerBS.DataSource = ledgerTable;
            }

            dataGridView2.DataSource = AccountLegerBS;
            CalculateTotalsFromGridView();
        }

        private void CalculateTotalsFromGridView()
        {
            decimal totalDebit = 0, totalCredit = 0, finalBalance = 0;
            string status = "Debit"; // Default status

            foreach (DataGridViewRow row in dataGridView2.Rows)
            {
                if (!row.IsNewRow) // Ensure it's not an empty new row
                {
                    totalDebit += row.Cells["Debit"].Value != DBNull.Value ? Convert.ToDecimal(row.Cells["Debit"].Value) : 0;
                    totalCredit += row.Cells["Credit"].Value != DBNull.Value ? Convert.ToDecimal(row.Cells["Credit"].Value) : 0;
                    finalBalance = row.Cells["Balance"].Value != DBNull.Value ? Convert.ToDecimal(row.Cells["Balance"].Value) : 0; // Last row's balance
                    status = row.Cells["Status"].Value != DBNull.Value ? row.Cells["Status"].Value.ToString() : "Debit"; // Last row's balance
                }
            }

            // Display results in textboxes
            txt_debit.Text = totalDebit.ToString("N2");  // Format as 2 decimal places
            txt_credit.Text = totalCredit.ToString("N2");
            txt_balance.Text = Math.Abs(finalBalance).ToString("N2") + " " + status;

            // Change color based on status
            txt_balance.ForeColor = status == "Debit" ? Color.Red : Color.Green;
        }


        private void txt_accountId_KeyDown(object sender, KeyEventArgs e)
        {
            commonFunctions.HandleAccountSuggestionKeyDown(txt_accountId, txt_accountName, lstAccounts, e, txt_accountName);
        }

        private void txt_accountId_TextChanged(object sender, EventArgs e)
        {
                if (txt_accountId.Text == "")
                {
                    lstAccounts.Visible = false;
                    return;
                }

                commonFunctions.ShowAccountSuggestions(txt_accountId, lstAccounts, "allAccount");
        }

        private void AccountsLegerForm_Load(object sender, EventArgs e)
        {
            lstAccounts.Visible = false;

            // set date today
            dtmStart.Value = dtmEnd.Value = DateTime.Now;
        }

        private void dataGridView2_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            if (!dataGridView2.Rows[e.RowIndex].IsNewRow && e.RowIndex >= 0) // Ensure a row is selected
            {
                DataGridViewRow selectedRow = dataGridView2.Rows[e.RowIndex];
                string transactionId = selectedRow.Cells["TransactionID"].Value?.ToString(); // Get Transaction ID

                if (!string.IsNullOrEmpty(transactionId))
                {
                    // Extract the prefix to determine the transaction type (first 2-3 characters)
                    string transactionPrefix = new string(transactionId.TakeWhile(char.IsLetter).ToArray());
                    int sourceId = int.Parse(new string(transactionId.SkipWhile(char.IsLetter).ToArray()));

                    Form childForm = null; // Declare form variable

                    // Open the respective form as an MDI child
                    if (transactionPrefix == "SV") // Sales
                    {
                        childForm = new Sales(financialYearId, sourceId);
                    }
                    else if (transactionPrefix == "PV") // Purchase
                    {
                        childForm = new purchase(financialYearId, sourceId);
                    }
                    else if (transactionPrefix == "CPV") // Cash Payment
                    {
                        childForm = new CashPayment(financialYearId, sourceId);
                    }
                    else if (transactionPrefix == "CRV") // Cash Receipt
                    {
                        childForm = new CashReceipt(financialYearId, sourceId);
                    }
                    else if (transactionPrefix == "BPV") // Bank Payment
                    {
                        childForm = new BankPayment(financialYearId, sourceId);
                    }
                    else if (transactionPrefix == "BRV") // Bank Receipt
                    {
                        return; // Do nothing for Bank Receipt
                    }
                    else if (transactionPrefix == "OB") // Opening Balance
                    {
                        childForm = new AccountsOpeningBalances(financialYearId, sourceId);
                    }
                    else
                    {
                        MessageBox.Show("Unknown transaction type.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }

                    // If a form was created, open it in the parent as an MDI child
                    if (childForm != null)
                    {
                        childForm.MdiParent = this.MdiParent; // Set MDI parent
                        //childForm.WindowState = FormWindowState.Maximized; // Optional: Open maximized
                        childForm.Show();
                    }
                }
            }
        }

    }
}
