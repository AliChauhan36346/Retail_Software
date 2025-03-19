using ALA_Accounting.Reports_Classes;
using ALA_Accounting.transaction_classes;
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
            try
            {
                // Validate Account ID
                if (!int.TryParse(txt_accountId.Text, out int accountId))
                {
                    MessageBox.Show("Please enter a valid Account ID.", "Invalid Input", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                // Get Start and End Dates (if provided)
                DateTime? startDate = chk_date.Checked ? dtmStart.Value : (DateTime?)null;
                DateTime? endDate = chk_date.Checked ? dtmEnd.Value : (DateTime?)null;

                // Fetch Ledger Data
                AccountsLegerClass ledger = new AccountsLegerClass();
                DataTable ledgerData = ledger.GetLedger(accountId, financialYearId, startDate, endDate);

                // Clear existing rows in DataGridView
                dataGridView2.Rows.Clear();

                // Variables to calculate totals
                decimal totalDebit = 0;
                decimal totalCredit = 0;
                decimal finalBalance = 0;

                string balanceStatus = "";

                // Populate DataGridView
                foreach (DataRow row in ledgerData.Rows)
                {
                    // Add data to DataGridView
                    dataGridView2.Rows.Add(
                        row["Date"],
                        row["TransactionID"],
                        row["description"],
                        row["Debit"],
                        row["Credit"],
                        row["balance"],
                        row["status"]
                    );

                    // Calculate totals
                    totalDebit += Convert.ToDecimal(row["Debit"]);
                    totalCredit += Convert.ToDecimal(row["Credit"]);
                    finalBalance = Convert.ToDecimal(row["Balance"]);
                    balanceStatus = Convert.ToString(row["status"]);
                }

                // Display totals in TextBoxes
                txt_debit.Text = totalDebit.ToString("N2");
                txt_credit.Text = totalCredit.ToString("N2");

                txt_balance.Text = finalBalance.ToString("N2") + " " + balanceStatus;

                // Set color of balance TextBox
                if (balanceStatus == "debit")
                {
                    txt_balance.ForeColor = Color.Red;
                }
                else
                {
                    txt_balance.ForeColor = Color.Green;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("An error occurred while fetching the ledger: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
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
        }
    }
}
