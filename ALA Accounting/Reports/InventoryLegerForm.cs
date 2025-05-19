using ALA_Accounting.Addition;
using ALA_Accounting.Reports_Classes;
using ALA_Accounting.transaction_classes;
using ALA_Accounting.TransactionForms;
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
    public partial class InventoryLegerForm : Form
    {
        InventoryLegerClass inventoryLegerClass = new InventoryLegerClass();
        CommonFunctions CommonFunctions = new CommonFunctions();

        int FinancialYearID;

        public InventoryLegerForm(int financialYearId)
        {
            InitializeComponent();
            FinancialYearID = financialYearId;
        }

        private void btn_search_Click(object sender, EventArgs e)
        {
            string itemCode = txt_ItemCode.Text.Trim();
            DateTime? startDate = chk_date.Checked ? dtmStart.Value.Date : (DateTime?)null;
            DateTime? endDate = chk_date.Checked ? dtmEnd.Value.Date : (DateTime?)null;

            DataTable ledgerData = inventoryLegerClass.LoadData(FinancialYearID, itemCode, startDate, endDate);
            dataGridView2.AutoGenerateColumns = false;
            dataGridView2.DataSource = ledgerData;
            CalculateTotalsFromDataGridView();
        }

        private void CalculateTotalsFromDataGridView()
        {
            decimal totalQuantityIn = 0;
            decimal totalQuantityOut = 0;
            decimal runningBalance=0;

            string balance="0";
            // Loop through DataGridView rows
            foreach (DataGridViewRow row in dataGridView2.Rows)
            {
                if (row.Cells["QuantityIn"].Value != DBNull.Value)
                    totalQuantityIn += Convert.ToDecimal(row.Cells["QuantityIn"].Value);

                if (row.Cells["QuantityOut"].Value != DBNull.Value)
                    totalQuantityOut += Convert.ToDecimal(row.Cells["QuantityOut"].Value);

                // Last row contains final balance

                // Last row contains final balance
                if (row.Cells["BalanceQty"].Value != null && row.Cells["BalanceQty"].Value != DBNull.Value)
                {
                    balance = row.Cells["BalanceQty"].Value.ToString();
                }

            }

            runningBalance=Convert.ToDecimal(balance);

            // Display totals in textboxes
            txt_totalIn.Text = totalQuantityIn.ToString("N2");
            txt_totalOut.Text = totalQuantityOut.ToString("N2");
            txt_balance.Text = runningBalance.ToString("N2");
        }



        private void InventoryLegerForm_Load(object sender, EventArgs e)
        {
            lstAccounts.Visible = false;

            // date time to today
            dtmEnd.Value = DateTime.Now;
            dtmStart.Value = DateTime.Now;

        }

        







        private void guna2ShadowPanel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void txt_ItemCode_TextChanged(object sender, EventArgs e)
        {
            if (txt_ItemCode.Text == "")
            {
                lstAccounts.Visible = false;
                return;
            }

            CommonFunctions.ShowAccountSuggestions(txt_ItemCode, lstAccounts, "inventory");
        }

        private void txt_ItemCode_KeyDown(object sender, KeyEventArgs e)
        {
            CommonFunctions.HandleAccountSuggestionKeyDown(txt_ItemCode, txt_ItemName, lstAccounts, e, btn_search);
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
                        childForm = new Sales(FinancialYearID, sourceId);
                    }
                    else if (transactionPrefix == "PV") // Purchase
                    {
                        childForm = new purchase(FinancialYearID, sourceId);
                    }
                    else if (transactionPrefix == "OB") // Opening Balance
                    {
                        childForm = new InventoryOpeningBalances(FinancialYearID, sourceId);
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
