using ALA_Accounting.Addition;
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
using Guna.UI2.WinForms;
using System.Web.UI.WebControls;
using ALA_Accounting.Addition_Classes;
using System.Data.Common;
using System.Data.SqlClient;
using System.Data.Odbc;


namespace ALA_Accounting.TransactionForms
{


    public partial class Sales : Form
    {
        FinancialYear financialYear=new FinancialYear();

        CommonFunctions functions = new CommonFunctions();

        InventoryItems inventoryItems=new InventoryItems();

        int financialYearId;
        int salesInvoiceId=-1;


        SalesInvoice salesInvoice= new SalesInvoice();



        public Sales(int financialYearId, int salesInvoiceId)
        {
            InitializeComponent();

            this.financialYearId = financialYearId;
            this.salesInvoiceId = salesInvoiceId;
        }

        public Sales(int financialYearId)
        {
            InitializeComponent();

            this.financialYearId = financialYearId;
        }





        private void btn_save_Click(object sender, EventArgs e)
        {
            if (salesInvoice.SalesInvoiceExists(Convert.ToInt32(txt_salesId.Text)))
            {
                UpdateSalesInvoiceHandler();
                txt_salesId.Text = salesInvoice.GetNextAvailableSalesInvoiceID().ToString();
            }
            else
            {
                SaveSalesInvoiceHandler();
                txt_salesId.Text=salesInvoice.GetNextAvailableSalesInvoiceID().ToString();
            }

        }

        private int TryConvertToInt(object value)
        {
            if (value == null || value == DBNull.Value || string.IsNullOrEmpty(value.ToString()))
                return 0; // Or a default value you want
            int result;
            if (int.TryParse(value.ToString(), out result))
                return result;
            return 0; // Or handle error
        }

        private decimal TryConvertToDecimal(object value)
        {
            if (value == null || value == DBNull.Value || string.IsNullOrEmpty(value.ToString()))
                return 0m; // Or a default value you want
            decimal result;
            if (decimal.TryParse(value.ToString(), out result))
                return result;
            return 0m; // Or handle error
        }

        private void SaveSalesInvoiceHandler()
        {
            // Validate the form data first
            if (!ValidateSalesInvoiceInput())
            {
                MessageBox.Show("Please correct the errors in the form.", "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            // Prepare SalesInvoice object
            SalesInvoice invoice = new SalesInvoice
            {
                SalesInvoiceID = Convert.ToInt32(txt_salesId.Text),
                AccountID = Convert.ToInt32(txt_accountId.Text),
                AccountName = txt_accountName.Text.Trim(),
                InvoiceDate = dtm_saleDate.Value,
                IncomeAccountID = Convert.ToInt32(txt_incomeAccountId.Text),
                GrossTotal = Convert.ToDecimal(txt_grossTotal.Text),
                AdditionalDiscount = Convert.ToDecimal(txt_additionDiscount.Text),
                CarriageAndFreight = Convert.ToDecimal(txt_carraigeFreight.Text),
                NetTotal = Convert.ToDecimal(txt_netTotal.Text),
                AmountReceived = Convert.ToDecimal(txt_amountReceived.Text),
                Balance = Convert.ToDecimal(txt_balance.Text),
                IsCancelled = false,
                FinancialYearID = financialYearId,
                EmployeeReference = cmbo_employeeRefference.Text,
                Address = txt_address.Text,
                Remarks = txt_salesRemarks.Text
            };

            // Prepare SalesInvoiceItem list
            List<SalesInvoiceItem> items = new List<SalesInvoiceItem>();
            foreach (DataGridViewRow row in dataGridView2.Rows)
            {
                if (row.IsNewRow) continue;

                SalesInvoiceItem item = new SalesInvoiceItem
                {
                    ItemID = row.Cells["itemId"].Value.ToString().Trim(),
                    ItemDiscription = row.Cells["itemName"].Value.ToString(),
                    Quantity = TryConvertToDecimal(row.Cells["quantity"].Value),
                    Unit = row.Cells["unit"].Value.ToString(),
                    Rate = TryConvertToDecimal(row.Cells["rate"].Value),
                    GrossAmount = TryConvertToDecimal(row.Cells["grossAmount"].Value),
                    Discount = TryConvertToDecimal(row.Cells["discount"].Value),
                    NetAmount = TryConvertToDecimal(row.Cells["netAmount"].Value)
                };

                items.Add(item);
            }


            // Construct the transaction description
            string description = string.Empty;
            foreach (var item in items)
            {
                description += $"({item.ItemDiscription}-{item.Quantity}{item.Unit}@{item.Rate}={item.NetAmount}) ";
            }

            // Trim any trailing spaces
            description = description.Trim();

            // Prepare Transaction list
            List<Transaction> transactions = new List<Transaction>();

            Transaction saleTransaction = new Transaction
            {
                AccountID = Convert.ToInt32(txt_accountId.Text),
                TransactionDate = dtm_saleDate.Value,
                TransactionType = "debit",
                Amount = Convert.ToDecimal(txt_netTotal.Text),
                Description = description,
                IsCancelled = false,
                FinancialYearID = financialYearId
            };

            transactions.Add(saleTransaction);

            if(Convert.ToDecimal(txt_amountReceived.Text)> 0)
            {
                Transaction cashReceiptTransaction = new Transaction
                {
                    AccountID = Convert.ToInt32(txt_accountId.Text),
                    TransactionDate = dtm_saleDate.Value,
                    TransactionType = "credit",
                    Amount = Convert.ToDecimal(txt_amountReceived.Text),
                    Description = description,
                    IsCancelled = false,
                    FinancialYearID = financialYearId
                };

                transactions.Add(cashReceiptTransaction);

                Transaction cashAccount = new Transaction
                {
                    AccountID = 3,
                    TransactionDate = dtm_saleDate.Value,
                    TransactionType = "debit",
                    Amount = Convert.ToDecimal(txt_amountReceived.Text),
                    Description = description,
                    IsCancelled = false,
                    FinancialYearID = financialYearId
                };

                transactions.Add(cashAccount);
            }

            

            Transaction incomeTransaction = new Transaction
            {
                AccountID = Convert.ToInt32(txt_incomeAccountId.Text),  // Income Account ID
                TransactionDate = dtm_saleDate.Value,
                TransactionType = "credit",
                Amount = Convert.ToDecimal(txt_netTotal.Text),
                Description = description,
                IsCancelled = false,
                FinancialYearID = financialYearId
            };

            transactions.Add(incomeTransaction);


            // Prepare InventoryTransaction list
            List<InventoryTransaction> inventoryTransactions = new List<InventoryTransaction>();

            foreach (DataGridViewRow row in dataGridView2.Rows)
            {
                if (row.IsNewRow) continue;

                InventoryTransaction itemsTransaction = new InventoryTransaction
                {
                    ItemID = row.Cells["itemId"].Value.ToString().Trim(),
                    partyName = txt_accountName.Text,
                    Quantity = TryConvertToDecimal(row.Cells["quantity"].Value),
                    Rate = TryConvertToDecimal(row.Cells["rate"].Value),
                    TransactionDate = dtm_saleDate.Value,
                    Unit = row.Cells["unit"].Value.ToString(),
                    
                };

                inventoryTransactions.Add(itemsTransaction);
            }

            // Save the SalesInvoice
            bool success = invoice.SaveSalesInvoice(invoice, items, transactions, inventoryTransactions);
            if (success)
            {
                MessageBox.Show("Sales invoice saved successfully.", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                //functions.ClearAllTextBoxes(this);
                ClearAndZeroOutTextBoxes();
            }
            else
            {
                MessageBox.Show("Failed to save sales invoice.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void UpdateSalesInvoiceHandler()
        {
            // Validate the form data first
            if (!ValidateSalesInvoiceInput())
            {
                MessageBox.Show("Please correct the errors in the form.", "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            // Prepare SalesInvoice object
            SalesInvoice invoice = new SalesInvoice
            {
                SalesInvoiceID = Convert.ToInt32(txt_salesId.Text),
                AccountID = Convert.ToInt32(txt_accountId.Text),
                AccountName = txt_accountName.Text.Trim(),
                InvoiceDate = dtm_saleDate.Value,
                IncomeAccountID = Convert.ToInt32(txt_incomeAccountId.Text),
                GrossTotal = Convert.ToDecimal(txt_grossTotal.Text),
                AdditionalDiscount = Convert.ToDecimal(txt_additionDiscount.Text),
                CarriageAndFreight = Convert.ToDecimal(txt_carraigeFreight.Text),
                NetTotal = Convert.ToDecimal(txt_netTotal.Text),
                AmountReceived = Convert.ToDecimal(txt_amountReceived.Text),
                Balance = Convert.ToDecimal(txt_balance.Text),
                IsCancelled = false,
                FinancialYearID = financialYearId,
                EmployeeReference = cmbo_employeeRefference.Text,
                Address = txt_address.Text,
                Remarks = txt_salesRemarks.Text
            };

            // Prepare SalesInvoiceItem list
            List<SalesInvoiceItem> items = new List<SalesInvoiceItem>();
            foreach (DataGridViewRow row in dataGridView2.Rows)
            {
                if (row.IsNewRow) continue;

                SalesInvoiceItem item = new SalesInvoiceItem
                {
                    ItemID = row.Cells["itemId"].Value.ToString().Trim(),
                    ItemDiscription = row.Cells["itemName"].Value.ToString(),
                    Quantity = TryConvertToDecimal(row.Cells["quantity"].Value),
                    Unit = row.Cells["unit"].Value.ToString(),
                    Rate = TryConvertToDecimal(row.Cells["rate"].Value),
                    GrossAmount = TryConvertToDecimal(row.Cells["grossAmount"].Value),
                    Discount = TryConvertToDecimal(row.Cells["discount"].Value),
                    NetAmount = TryConvertToDecimal(row.Cells["netAmount"].Value)
                };

                items.Add(item);
            }

            // Construct the transaction description
            string description = string.Empty;
            foreach (var item in items)
            {
                description += $"({item.ItemDiscription}-{item.Quantity}{item.Unit}@{item.Rate}={item.NetAmount}) ";
            }

            // Trim any trailing spaces
            description = description.Trim();

            // Prepare Transaction list
            List<Transaction> transactions = new List<Transaction>();

            Transaction saleTransaction = new Transaction
            {
                AccountID = Convert.ToInt32(txt_accountId.Text),
                TransactionDate = dtm_saleDate.Value,
                TransactionType = "debit",
                Amount = Convert.ToDecimal(txt_netTotal.Text),
                Description = description,
                IsCancelled = false,
                FinancialYearID = financialYearId
            };

            transactions.Add(saleTransaction);

            if (Convert.ToDecimal(txt_amountReceived.Text) > 0)
            {
                Transaction cashReceiptTransaction = new Transaction
                {
                    AccountID = Convert.ToInt32(txt_accountId.Text),
                    TransactionDate = dtm_saleDate.Value,
                    TransactionType = "credit",
                    Amount = Convert.ToDecimal(txt_amountReceived.Text),
                    Description = description,
                    IsCancelled = false,
                    FinancialYearID = financialYearId
                };

                transactions.Add(cashReceiptTransaction);


                Transaction cashAccount = new Transaction
                {
                    AccountID = 3,
                    TransactionDate = dtm_saleDate.Value,
                    TransactionType = "debit",
                    Amount = Convert.ToDecimal(txt_amountReceived.Text),
                    Description = description,
                    IsCancelled = false,
                    FinancialYearID = financialYearId
                };

                transactions.Add(cashAccount);
            }

            Transaction incomeTransaction = new Transaction
            {
                AccountID = Convert.ToInt32(txt_incomeAccountId.Text),
                TransactionDate = dtm_saleDate.Value,
                TransactionType = "credit",
                Amount = Convert.ToDecimal(txt_netTotal.Text),
                Description = description,
                IsCancelled = false,
                FinancialYearID = financialYearId
            };

            transactions.Add(incomeTransaction);

            // Prepare InventoryTransaction list
            List<InventoryTransaction> inventoryTransactions = new List<InventoryTransaction>();

            foreach (DataGridViewRow row in dataGridView2.Rows)
            {
                if (row.IsNewRow) continue;

                InventoryTransaction itemsTransaction = new InventoryTransaction
                {
                    ItemID = row.Cells["itemId"].Value.ToString().Trim(),
                    partyName = txt_accountName.Text,
                    Quantity = TryConvertToDecimal(row.Cells["quantity"].Value),
                    Rate = TryConvertToDecimal(row.Cells["rate"].Value),
                    TransactionDate = dtm_saleDate.Value,
                    Unit = row.Cells["unit"].Value.ToString()
                };

                inventoryTransactions.Add(itemsTransaction);
            }

            // Update the SalesInvoice
            bool success = invoice.UpdateSalesInvoice(invoice, items, transactions, inventoryTransactions);
            if (success)
            {
                MessageBox.Show("Sales invoice updated successfully.", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                ClearAndZeroOutTextBoxes();
            }
            else
            {
                MessageBox.Show("Failed to update sales invoice.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private bool ValidateSalesInvoiceInput()
        {
            int accountId;
            if (!int.TryParse(txt_accountId.Text, out accountId) || accountId <= 0)
            {
                MessageBox.Show("Please enter a valid Account ID.", "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txt_accountId.Focus();
                return false;
            }

            if (string.IsNullOrWhiteSpace(txt_accountName.Text))
            {
                MessageBox.Show("Account Name cannot be empty.", "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txt_accountName.Focus();
                return false;
            }

            if (dataGridView2.Rows.Count == 0 || !dataGridView2.Rows.Cast<DataGridViewRow>().Any(row => !row.IsNewRow))
            {
                MessageBox.Show("Please add at least one item to the invoice.", "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                dataGridView2.Focus();
                return false;
            }

            int incomeAccountId;
            if (!int.TryParse(txt_incomeAccountId.Text, out incomeAccountId) || incomeAccountId <= 0)
            {
                MessageBox.Show("Please enter a valid Income Account ID.", "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txt_incomeAccountId.Focus();
                return false;
            }

            if (string.IsNullOrWhiteSpace(txt_incomeAccountName.Text))
            {
                MessageBox.Show("Income Account Name cannot be empty.", "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txt_incomeAccountName.Focus();
                return false;
            }

            DateTime invoiceDate = dtm_saleDate.Value.Date;
            var dates = financialYear.GetFinancialYearDatesById(financialYearId); // Replace 1 with the actual ID
            DateTime startDate = dates.StartDate.Date;
            DateTime endDate = dates.EndDate.Date;

            // Assuming financialYearStartDate and financialYearEndDate are DateTime variables set based on your financial year.
            if (invoiceDate < dates.StartDate.Date || invoiceDate > dates.EndDate.Date)
            {
                MessageBox.Show("Invoice date must be within the financial year.", "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                dtm_saleDate.Focus();
                return false;
            }

            return true;
        }

        private void listBox1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void txt_accountId_TextChanged(object sender, EventArgs e)
        {
            if (txt_accountId.Text=="")
            {
                lstCustomers.Visible = false;
                return;
            }

            functions.ShowAccountSuggestions(txt_accountId, lstCustomers, "customer");
        }

        private void txt_accountId_KeyDown(object sender, KeyEventArgs e)
        {
            functions.HandleAccountSuggestionKeyDown(txt_accountId, txt_accountName, lstCustomers, e,txt_accountName);
        }

        private void txt_accountBalance_KeyPress(object sender, KeyPressEventArgs e)
        {
            // Allow control characters like backspace
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar))
            {
                e.Handled = true; // Reject the input
            }
        }

        private void txt_accountId_Leave(object sender, EventArgs e)
        {
            lstCustomers.Visible=false;
        }

        private void ClearAndZeroOutTextBoxes()
        {
            // Clear textboxes
            txt_accountId.Clear();
            txt_accountName.Clear();
            txt_address.Clear();
            txt_salesRemarks.Clear();

            // Zero out the textboxes
            txt_profitLoss.Text = "0.00";
            txt_additionDiscount.Text = "0.00";
            txt_grossTotal.Text = "0.00";
            txt_carraigeFreight.Text = "0.00";
            txt_netTotal.Text = "0.00";
            txt_amountReceived.Text = "0.00";
            txt_balance.Text = "0.00";

            txt_grossAmount.Text = "0.00";
            txt_discountTotal.Text = "0.00";
            txt_netAmount.Text = "0.00";

            txt_incomeAccountId.Text = "4";

            txt_incomeAccountName.Text = "Sales";

            // Clear DataGridView rows
            if (dataGridView2.Rows.Count > 0)
            {
                dataGridView2.Rows.Clear();
            }
        }

        private void txt_itemId_TextChanged(object sender, EventArgs e)
        {
            if (txt_itemId.Text == "")
            {
                lstInventoryItems.Visible = false;
                return;
            }

            functions.ShowAccountSuggestions(txt_itemId, lstInventoryItems, "inventory");
        }

        

        private void txt_quantity_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter || e.KeyCode == Keys.Tab)
            {
                txt_unit.Focus();
                e.SuppressKeyPress = true;
            }
            else if (e.KeyCode == Keys.Left)
            {
                txt_itemName.Focus();
                e.SuppressKeyPress = true;
            }
            else if (e.KeyCode == Keys.Right)
            {
                txt_unit.Focus();
                e.SuppressKeyPress = true;
            }

            
        }

        private void txt_unit_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter || e.KeyCode == Keys.Tab)
            {
                txt_rate.Focus();
                e.SuppressKeyPress = true;
            }
            else if (e.KeyCode == Keys.Left)
            {
                txt_quantity.Focus();
                e.SuppressKeyPress = true;
            }
            else if (e.KeyCode == Keys.Right)
            {
                txt_rate.Focus();
                e.SuppressKeyPress = true;
            }

            
        }

        private void txt_itemGrossAmount_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter || e.KeyCode == Keys.Tab)
            {
                txt_itemDiscount.Focus();
                e.SuppressKeyPress = true;
            }
            else if (e.KeyCode == Keys.Right)
            {
                txt_rate.Focus();
                e.SuppressKeyPress = true;
            }
            else if (e.KeyCode == Keys.Right)
            {
                txt_itemDiscount.Focus();
                e.SuppressKeyPress = true;
            }

            
        }

        private void txt_itemDiscount_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter || e.KeyCode == Keys.Tab)
            {
                txt_itemNetAmount.Focus();
                e.SuppressKeyPress = true;
            }
            else if (e.KeyCode == Keys.Left)
            {
                txt_itemGrossAmount.Focus();
                e.SuppressKeyPress = true;
            }
            else if (e.KeyCode == Keys.Right)
            {
                txt_itemNetAmount.Focus();
                e.SuppressKeyPress = true;
            }

            
        }

        private void txt_itemNetAmount_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter || e.KeyCode == Keys.Tab)
            {
                btn_addItem.Focus();
                e.SuppressKeyPress = true;
            }
            else if (e.KeyCode == Keys.Left)
            {
                txt_itemDiscount.Focus();
                e.SuppressKeyPress = true;
            }
            
            
        }

        private void txt_rate_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter || e.KeyCode == Keys.Tab)
            {
                txt_itemGrossAmount.Focus();
                e.SuppressKeyPress = true;
            }
            else if (e.KeyCode == Keys.Left)
            {
                txt_unit.Focus();
                e.SuppressKeyPress = true;
            }
            else if (e.KeyCode == Keys.Right)
            {
                txt_itemGrossAmount.Focus();
                e.SuppressKeyPress = true;
            }
        }

        private void guna2Button1_Click_1(object sender, EventArgs e)
        {
            this.Close();
        }

        private bool ValidateInput()
        {
            // Add necessary validation logic here (for example, check if required fields are filled)
            if (string.IsNullOrWhiteSpace(txt_itemId.Text) || string.IsNullOrWhiteSpace(txt_itemName.Text))
            {
                MessageBox.Show("Please fill in the required fields.");
                return false;
            }
            return true;
        }

        private void btn_addItem_Click(object sender, EventArgs e)
        {
            
            // Validate inputs
            if (ValidateInput())
            {
                if (editingRowIndex >= 0)
                {
                    // Update existing row
                    DataGridViewRow row = dataGridView2.Rows[editingRowIndex];

                    // Update the row with the values from the textboxes
                    row.Cells["itemId"].Value = txt_itemId.Text;
                    row.Cells["itemName"].Value = txt_itemName.Text;
                    row.Cells["quantity"].Value = txt_quantity.Text;
                    row.Cells["unit"].Value = txt_unit.Text;
                    row.Cells["rate"].Value = txt_rate.Text;
                    row.Cells["grossAmount"].Value = txt_itemGrossAmount.Text;
                    row.Cells["discount"].Value = txt_itemDiscount.Text;
                    row.Cells["netAmount"].Value = txt_itemNetAmount.Text;

                    // Reset the editing state
                    editingRowIndex = -1;
                }
                else
                {
                    // Add new row
                    dataGridView2.Rows.Add(
                        txt_itemId.Text,
                        txt_itemName.Text,
                        txt_quantity.Text,
                        txt_unit.Text,
                        txt_rate.Text,
                        txt_itemGrossAmount.Text,
                        txt_itemDiscount.Text,
                        txt_itemNetAmount.Text
                    );
                }

                RecalculateTotals();
                CalculateProfitOrLoss();
                ClearTextBoxes();
            }
            
        }

        private void Sales_Load(object sender, EventArgs e)
        {
            lstCustomers.Visible = false;
            lstInventoryItems.Visible = false;

            dtm_saleDate.Value = DateTime.Today;

            ClearAndZeroOutTextBoxes();

            txt_salesId.Text=salesInvoice.GetNextAvailableSalesInvoiceID().ToString();

            cmbo_employeeRefference.SelectedIndex = 0;

            txt_incomeAccountId.Text = "4";

            txt_incomeAccountName.Text = "Sales";

            if (salesInvoiceId != -1)
            {
                RetrieveSalesInvoiceById(salesInvoiceId, financialYearId);
            }

            dtm_saleDate.Value = DateTime.Now;
        }

        private int editingRowIndex = -1;

        private void dataGridView2_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0) // Make sure a valid row is clicked
            {
                DataGridViewRow row = dataGridView2.Rows[e.RowIndex];

                // Populate the textboxes with the selected row's values
                txt_itemId.Text = row.Cells["itemId"].Value.ToString();
                txt_itemName.Text = row.Cells["itemName"].Value.ToString();
                txt_quantity.Text = row.Cells["quantity"].Value.ToString();
                txt_unit.Text = row.Cells["unit"].Value.ToString();
                txt_rate.Text = row.Cells["rate"].Value.ToString();
                txt_itemGrossAmount.Text = row.Cells["grossAmount"].Value.ToString();
                txt_itemDiscount.Text = row.Cells["discount"].Value.ToString();
                txt_itemNetAmount.Text = row.Cells["netAmount"].Value.ToString();

                // Store the index of the row being edited in a class-level variable for later use
                editingRowIndex = e.RowIndex;
            }
        }

        private void ClearTextBoxes()
        {
            txt_itemId.Clear();
            txt_itemName.Clear();
            txt_quantity.Clear();
            txt_unit.Clear();
            txt_rate.Clear();
            txt_itemGrossAmount.Clear();
            txt_itemDiscount.Clear();
            txt_itemNetAmount.Clear();

            // Reset focus to the first textbox
            txt_itemId.Focus();
        }

        private void btn_removeItem_Click(object sender, EventArgs e)
        {
            if (dataGridView2.SelectedRows.Count > 0)
            {
                // Confirm deletion
                DialogResult result = MessageBox.Show("Are you sure you want to delete the selected item?", "Confirm Deletion", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
                if (result == DialogResult.Yes)
                {
                    // Remove the selected row(s)
                    foreach (DataGridViewRow row in dataGridView2.SelectedRows)
                    {
                        dataGridView2.Rows.Remove(row);
                    }

                    // Clear the textboxes in case the deleted item was being edited
                    ClearTextBoxes();
                    RecalculateTotals();
                    CalculateProfitOrLoss();
                }
            }
            else
            {
                MessageBox.Show("Please select a row to delete.");
            }
        }

        private void txt_quantity_TextChanged(object sender, EventArgs e)
        {
            RecalculateAmounts();
        }

        private void RecalculateAmounts()
        {
            if (decimal.TryParse(txt_quantity.Text, out decimal quantity) &&
                decimal.TryParse(txt_rate.Text, out decimal rate))
            {
                decimal grossAmount = quantity * rate;
                txt_itemGrossAmount.Text = grossAmount.ToString("0.00");

                // Update net amount after calculating gross amount
                RecalculateNetAmount();
            }
        }

        private void RecalculateNetAmount()
        {
            if (decimal.TryParse(txt_itemGrossAmount.Text, out decimal grossAmount) &&
                decimal.TryParse(txt_itemDiscount.Text, out decimal discount))
            {
                decimal netAmount = grossAmount - discount;
                txt_itemNetAmount.Text = netAmount.ToString("0.00");
            }
            else
            {
                // If no discount, net amount equals gross amount
                txt_itemNetAmount.Text = txt_itemGrossAmount.Text;
            }
        }

        private void txt_rate_TextChanged(object sender, EventArgs e)
        {
            RecalculateAmounts();
        }

        private void txt_itemDiscount_TextChanged(object sender, EventArgs e)
        {
            RecalculateNetAmount();
        }

        private void RecalculateTotals()
        {
            decimal grossAmountTotal = 0;
            decimal discountTotal = 0;
            decimal netAmountTotal = 0;

            foreach (DataGridViewRow row in dataGridView2.Rows)
            {
                if (row.Cells["grossAmount"].Value != null &&
                    row.Cells["discount"].Value != null &&
                    row.Cells["netAmount"].Value != null)
                {
                    grossAmountTotal += Convert.ToDecimal(row.Cells["grossAmount"].Value);
                    discountTotal += Convert.ToDecimal(row.Cells["discount"].Value);
                    netAmountTotal += Convert.ToDecimal(row.Cells["netAmount"].Value);
                }
            }

            txt_grossAmount.Text = grossAmountTotal.ToString("0.00");
            txt_discountTotal.Text = discountTotal.ToString("0.00");
            txt_netAmount.Text = netAmountTotal.ToString("0.00");
        }

        private void txt_additionDiscount_TextChanged(object sender, EventArgs e)
        {
            UpdateTotals();
        }

        private void txt_carraigeFreight_TextChanged(object sender, EventArgs e)
        {
            UpdateTotals();
        }

        private void txt_amountReceived_TextChanged(object sender, EventArgs e)
        {
            UpdateTotals();
        }

        private void txt_netAmount_TextChanged(object sender, EventArgs e)
        {
            UpdateTotals();
        }

        private void UpdateTotals()
        {
            int accountId = 0;
            int.TryParse(txt_accountId.Text, out accountId);

            

            // Parse the net amount
            decimal netAmount = 0;
            decimal.TryParse(txt_netAmount.Text, out netAmount);

            // Parse the additional discount
            decimal additionalDiscount = 0;
            decimal.TryParse(txt_additionDiscount.Text, out additionalDiscount);

            // Parse the carriage and freight
            decimal carriageFreight = 0;
            decimal.TryParse(txt_carraigeFreight.Text, out carriageFreight);


            // Calculate gross total (netAmount without additional discount)
            decimal grossTotal = netAmount-additionalDiscount;

            // Calculate net total (gross total - additional discount + carriage/freight)
            decimal netTotal = grossTotal + carriageFreight;

            // Parse the amount received
            if (accountId == 2)
            {
                txt_amountReceived.Text = netTotal.ToString("0.00");
                txt_amountReceived.Enabled = false;
            }
            else
            {
                txt_amountReceived.Enabled= true;
            }

            decimal amountReceived = 0;
            decimal.TryParse(txt_amountReceived.Text, out amountReceived);

            // Calculate balance (net total - amount received)
            decimal balance = netTotal - amountReceived;

            // Update the respective textboxes
            txt_grossTotal.Text = grossTotal.ToString("0.00");
            txt_netTotal.Text = netTotal.ToString("0.00");
            txt_balance.Text = balance.ToString("0.00");
        }

        private void txt_quantity_KeyPress(object sender, KeyPressEventArgs e)
        {
            // Allow control characters like backspace, digits, and one decimal point
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar) && e.KeyChar != '.')
            {
                e.Handled = true; // Reject the input
            }

            // If the decimal point is entered, ensure it's only allowed once
            if (e.KeyChar == '.' && (sender as Guna.UI2.WinForms.Guna2TextBox).Text.Contains("."))
            {
                e.Handled = true; // Reject the input if there's already a decimal point
            }
        }

        // get the sale invoice detail on id basis
        private void RetrieveSalesInvoiceById(int salesInvoiceId, int financialYearId)
        {
            Connection dbConnection=new Connection();

            try
            {
                // Open a connection to the database
                dbConnection.openConnection();

                // Retrieve SalesInvoice details
                string query = @"
                SELECT * FROM SalesInvoice
                WHERE SalesInvoiceID = @SalesInvoiceID AND financialYearId = @financialYearId";

                using (SqlCommand command = new SqlCommand(query, dbConnection.connection))
                {
                    command.Parameters.AddWithValue("@SalesInvoiceID", salesInvoiceId);
                    command.Parameters.AddWithValue("@financialYearId", financialYearId);

                    using (SqlDataReader reader = command.ExecuteReader())
                    {
                        if (reader.Read())
                        {
                            // Populate sales invoice fields
                            txt_salesId.Text = reader["SalesInvoiceID"].ToString();
                            txt_accountId.Text = reader["AccountID"].ToString();
                            txt_accountName.Text = reader["AccountName"].ToString();
                            dtm_saleDate.Value = Convert.ToDateTime(reader["InvoiceDate"]);
                            txt_incomeAccountId.Text = reader["IncomeAccountID"].ToString();
                            txt_grossTotal.Text = reader["GrossTotal"].ToString();
                            txt_additionDiscount.Text = reader["AdditionalDiscount"].ToString();
                            txt_carraigeFreight.Text = reader["CarriageAndFreight"].ToString();
                            txt_netTotal.Text = reader["NetTotal"].ToString();
                            txt_amountReceived.Text = reader["AmountReceived"].ToString();
                            txt_balance.Text = reader["Balance"].ToString();
                            cmbo_employeeRefference.Text = reader["EmployeeReference"].ToString();
                            txt_address.Text = reader["Address"].ToString();
                            txt_salesRemarks.Text = reader["Remarks"].ToString();
                        }
                        else
                        {
                            MessageBox.Show("Sales invoice not found.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                            return;
                        }
                    }
                }

                // Clear DataGridView before populating
                dataGridView2.Rows.Clear();

                // Retrieve SalesInvoiceItems
                //        string itemQuery = @"
                //SELECT * FROM SalesInvoiceItems
                //WHERE SalesInvoiceID = @SalesInvoiceID"
                //        ;

                string itemQuery = @"
                    SELECT 
                        sii.ItemID, 
                        sii.ItemDescription, 
                        sii.Quantity, 
                        ii.MeasurementUnit, 
                        sii.Rate, 
                        sii.GrossAmount, 
                        sii.Discount, 
                        sii.NetAmount
                    FROM SalesInvoiceItems sii
                    INNER JOIN InventoryItem ii ON sii.ItemID = ii.ItemID
                    WHERE sii.SalesInvoiceID = @SalesInvoiceID";


                using (SqlCommand itemCommand = new SqlCommand(itemQuery, dbConnection.connection))
                {
                    itemCommand.Parameters.AddWithValue("@SalesInvoiceID", salesInvoiceId);

                    using (SqlDataReader itemReader = itemCommand.ExecuteReader())
                    {
                        while (itemReader.Read())
                        {
                            dataGridView2.Rows.Add(
                                itemReader["ItemID"].ToString(),
                                itemReader["ItemDescription"].ToString(),
                                itemReader["Quantity"].ToString(),
                                itemReader["MeasurementUnit"].ToString(),
                                itemReader["Rate"].ToString(),
                                itemReader["GrossAmount"].ToString(),
                                itemReader["Discount"].ToString(),
                                itemReader["NetAmount"].ToString()
                            );
                        }
                    }
                }

                //MessageBox.Show("Sales invoice details retrieved successfully.", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error retrieving sales invoice: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally
            {
                // Ensure connection is closed
                dbConnection.closeConnection();
            }
        }

        // to retrive next available id
        private void GoToNextSalesInvoice(int currentInvoiceId, int financialYearID)
        {
            Connection dbConnection = new Connection();

            try
            {
                // Open the database connection
                dbConnection.openConnection();

                // Query to find the next available SalesInvoiceID greater than the current one
                string query = @"
            SELECT TOP 1 SalesInvoiceID 
            FROM SalesInvoice 
            WHERE SalesInvoiceID > @CurrentInvoiceID
            ORDER BY SalesInvoiceID ASC"
                ;

                using (SqlCommand command = new SqlCommand(query, dbConnection.connection))
                {
                    command.Parameters.AddWithValue("@CurrentInvoiceID", currentInvoiceId);

                    object result = command.ExecuteScalar();

                    if (result != null)
                    {
                        int nextInvoiceId = Convert.ToInt32(result);
                        RetrieveSalesInvoiceById(nextInvoiceId, financialYearID);  // Call the function to retrieve and populate the next invoice
                        RecalculateTotals();
                    }
                    else
                    {
                        MessageBox.Show("There are no more sales invoices after the current one.", "No More Invoices", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error retrieving next sales invoice: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally
            {
                // Ensure connection is closed
                dbConnection.closeConnection();
            }
        }

        private void GoToPreviousSalesInvoice(int currentInvoiceId, int financialYearID)
        {
            Connection dbConnection = new Connection();

            try
            {
                // Open the database connection
                dbConnection.openConnection();

                // Query to find the previous available SalesInvoiceID less than the current one
                string query = @"
            SELECT TOP 1 SalesInvoiceID 
            FROM SalesInvoice 
            WHERE SalesInvoiceID < @CurrentInvoiceID
            ORDER BY SalesInvoiceID DESC";

                using (SqlCommand command = new SqlCommand(query, dbConnection.connection))
                {
                    command.Parameters.AddWithValue("@CurrentInvoiceID", currentInvoiceId);

                    object result = command.ExecuteScalar();

                    if (result != null)
                    {
                        int previousInvoiceId = Convert.ToInt32(result);
                        RetrieveSalesInvoiceById(previousInvoiceId, financialYearID);  // Call the function to retrieve and populate the previous invoice
                        RecalculateTotals();
                    }
                    else
                    {
                        MessageBox.Show("There are no previous sales invoices before the current one.", "No More Invoices", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error retrieving previous sales invoice: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally
            {
                // Ensure connection is closed
                dbConnection.closeConnection();
            }
        }

        private void btn_forward_Click(object sender, EventArgs e)
        {
            int currentInvoiceId = Convert.ToInt32(txt_salesId.Text);  // Get the current SalesInvoiceID from the form
            GoToNextSalesInvoice(currentInvoiceId, financialYearId);

            CalculateProfitOrLoss();
        }

        private void btn_back_Click(object sender, EventArgs e)
        {
            int currentInvoiceId = Convert.ToInt32(txt_salesId.Text);  // Get the current SalesInvoiceID from the form
            GoToPreviousSalesInvoice(currentInvoiceId, financialYearId);

            CalculateProfitOrLoss();
        }

        private void btn_addNew_Click(object sender, EventArgs e)
        {
            ClearAndZeroOutTextBoxes();
            txt_salesId.Text = salesInvoice.GetNextAvailableSalesInvoiceID().ToString();
        }

        private void btn_delete_Click(object sender, EventArgs e)
        {
            if (salesInvoice.SalesInvoiceExists(Convert.ToInt32(txt_salesId.Text)))
            {
                salesInvoice.DeleteSalesInvoice(Convert.ToInt32(txt_salesId.Text.Trim()));
                ClearAndZeroOutTextBoxes();
                txt_salesId.Text = salesInvoice.GetNextAvailableSalesInvoiceID().ToString();
            }
        }

        public void CalculateProfitOrLoss()
        {
            try
            {
                decimal totalProfitLoss = 0;
                int itemsTotal = 0;

                // Loop through each row in the DataGridView
                foreach (DataGridViewRow row in dataGridView2.Rows)
                {
                    if (row.Cells["ItemID"].Value != null && row.Cells["Quantity"].Value != null && row.Cells["Rate"].Value != null)
                    {
                        string itemId = row.Cells["ItemID"].Value.ToString().Trim();
                        decimal quantity = Convert.ToDecimal(row.Cells["Quantity"].Value);
                        decimal sellingPrice = Convert.ToDecimal(row.Cells["Rate"].Value);
                        decimal discount = row.Cells["Discount"].Value != null ? Convert.ToDecimal(row.Cells["Discount"].Value) : 0;
                        decimal additionalDiscount = txt_additionDiscount.Text != "" ? Convert.ToDecimal(txt_additionDiscount.Text) : 0;

                        // Get the cost price of the item from the database
                        decimal costPrice = salesInvoice.GetAverageCost(itemId,financialYearId);

                        // Calculate profit/loss for this item
                        decimal itemProfitLoss = (sellingPrice - costPrice) * quantity - (discount+additionalDiscount);

                        // Add it to the total profit/loss
                        totalProfitLoss += itemProfitLoss;

                        if (quantity < 1)
                        {
                            itemsTotal += 1;
                        }
                        else
                        {
                            itemsTotal += (int)quantity;
                        }

                        
                    }
                }

                // Display the total profit/loss in the TextBox or Label
                txt_profitLoss.Text = totalProfitLoss.ToString("0.00");
                txt_itemTotal.Text = itemsTotal.ToString("0");


                if (totalProfitLoss >= 0)
                {
                    txt_profitLoss.ForeColor = Color.Green;  // Profit (positive)
                }
                else
                {
                    txt_profitLoss.ForeColor = Color.Red;    // Loss (negative)
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error calculating profit/loss: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }


        private void txt_itemId_TextChanged_1(object sender, EventArgs e)
        {
            if (txt_itemId.Text == "")
            {
                lstInventoryItems.Visible = false;
                return;
            }

            functions.ShowAccountSuggestions(txt_itemId, lstInventoryItems, "inventory");
        }

        private void txt_itemId_KeyDown(object sender, KeyEventArgs e)
        {
            functions.HandleAccountSuggestionKeyDown(txt_itemId, txt_itemName, lstInventoryItems, e, txt_itemName);

            //if (txt_itemId.Text != "")
            //{
            //    List<string> itemDetails = inventoryItems.GetItemPriceAndUnit(txt_itemId.Text.Trim());

            //    if (itemDetails.Count == 2)
            //    {
            //        // Populate the 'rate' and 'unit' cells
            //        txt_rate.Text = itemDetails[0];
            //        txt_unit.Text = itemDetails[1];

            //        txt_quantity.Text = "0.00";
            //        txt_itemGrossAmount.Text = "0.00";
            //        txt_itemDiscount.Text = "0.00";
            //        txt_itemNetAmount.Text = "0.00";

            //    }
            //}
        }

        private void txt_itemId_Leave(object sender, EventArgs e)
        {
            lstInventoryItems.Visible = false;

            if (txt_itemId.Text != "")
            {
                List<string> itemDetails = inventoryItems.GetItemPriceAndUnit(txt_itemId.Text.Trim());

                if (itemDetails.Count == 2)
                {
                    // Populate the 'rate' and 'unit' cells
                    txt_rate.Text = itemDetails[0];
                    txt_unit.Text = itemDetails[1];

                    txt_quantity.Text = "0.00";
                    txt_itemGrossAmount.Text = "0.00";
                    txt_itemDiscount.Text = "0.00";
                    txt_itemNetAmount.Text = "0.00";

                }
            }
        }

        private void txt_itemName_KeyDown_1(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter || e.KeyCode == Keys.Tab)
            {
                txt_quantity.Focus();
            }
            else if (e.KeyCode == Keys.Left)
            {
                txt_itemId.Focus();
            }
            else if (e.KeyCode == Keys.Right)
            {
                txt_quantity.Focus();
            }

            e.SuppressKeyPress = true;
        }

        private void btn_newItem_Click(object sender, EventArgs e)
        {
            AddInventory addInventory = new AddInventory();
            addInventory.ShowDialog();
        }

        private void btn_newCustomer_Click(object sender, EventArgs e)
        {
            //AddAccount addAccount = new AddAccount();
            //addAccount.ShowDialog();
            
        }

        private void txt_itemTotal_TextChanged(object sender, EventArgs e)
        {

        }
    }
}
