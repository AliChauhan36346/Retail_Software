using ALA_Accounting.Addition;
using ALA_Accounting.transaction_classes;
using ALA_Accounting.UsersForm;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ALA_Accounting.TransactionForms
{
    public partial class CashReceipt : Form
    {
        CommonFunctions commonFunctions = new CommonFunctions();
        CashReceiptClass cashReceiptClass = new CashReceiptClass();
        FinancialYear financialYear = new FinancialYear();

        int financialYearId;
        int cashReceiptId = -1;

        public CashReceipt(int financialYearId)
        {
            InitializeComponent();
            this.financialYearId = financialYearId;
        }

        public CashReceipt(int financialYearId, int cashReceiptId)
        {
            InitializeComponent();
            this.financialYearId = financialYearId;
            this.cashReceiptId = cashReceiptId;
        }

        private void CashReceipt_Load(object sender, EventArgs e)
        {
            txt_cashReceiptId.Text = cashReceiptClass.GetNextAvailableCashReceiptID().ToString();
            cashReceiptClass.LoadCashReceipts(dataGridView1, financialYearId, dtm_receiptDate.Value.Date);
            lstAccounts.Visible = false;
            txt_cashAccount.Text = "3";
            txt_cashAccountName.Text = "Cash in hand";

            if (cashReceiptId != -1)
            {
                RetrieveCashReceiptById(cashReceiptId);
            }

            dtm_receiptDate.Value = DateTime.Now;
        }

        private void btn_save_Click(object sender, EventArgs e)
        {
            if (cashReceiptClass.CashReceiptExists(Convert.ToInt32(txt_cashReceiptId.Text)))
            {
                UpdateCashReceiptHandler();
            }
            else
            {
                SaveCashReceiptHandler();
            }
        }

        private bool ValidateCashReceiptForm()
        {
            DateTime invoiceDate = dtm_receiptDate.Value.Date;
            var dates = financialYear.GetFinancialYearDatesById(financialYearId); // Replace 1 with the actual ID
            DateTime startDate = dates.StartDate.Date;
            DateTime endDate = dates.EndDate.Date;

            // Assuming financialYearStartDate and financialYearEndDate are DateTime variables set based on your financial year.
            if (invoiceDate < dates.StartDate.Date || invoiceDate > dates.EndDate.Date)
            {
                MessageBox.Show("Payment date must be within the financial year.", "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                dtm_receiptDate.Focus();
                return false;
            }

            // Check if AccountID is provided and numeric
            if (string.IsNullOrWhiteSpace(txt_accountId.Text) || !int.TryParse(txt_accountId.Text, out _))
            {
                MessageBox.Show("Account ID is required and must be a valid number.", "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                txt_accountId.Focus();
                return false;
            }

            // Check if AccountName is provided
            if (string.IsNullOrWhiteSpace(txt_accountName.Text))
            {
                MessageBox.Show("Account Name is required.", "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                txt_accountName.Focus();
                return false;
            }

            // Check if Amount is provided and a valid decimal
            if (string.IsNullOrWhiteSpace(txt_amount.Text) || !decimal.TryParse(txt_amount.Text, out _))
            {
                MessageBox.Show("Amount is required and must be a valid decimal value.", "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                txt_amount.Focus();
                return false;
            }

            // Check if CashAccountID is provided and numeric
            if (string.IsNullOrWhiteSpace(txt_cashAccount.Text) || !int.TryParse(txt_cashAccount.Text, out _))
            {
                MessageBox.Show("Cash Account ID is required and must be a valid number.", "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                txt_cashAccount.Focus();
                return false;
            }

            // Check if CashAccountName is provided
            if (string.IsNullOrWhiteSpace(txt_cashAccountName.Text))
            {
                MessageBox.Show("Cash Account Name is required.", "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                txt_cashAccountName.Focus();
                return false;
            }

            // Check if CashReceiptID is provided and numeric (if applicable, may not be required for new Receipts)
            if (!string.IsNullOrWhiteSpace(txt_cashReceiptId.Text) && !int.TryParse(txt_cashReceiptId.Text, out _))
            {
                MessageBox.Show("Cash Receipt ID must be a valid number if provided.", "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                txt_cashReceiptId.Focus();
                return false;
            }

            // If all validations pass, return true
            return true;
        }

        private void SaveCashReceiptHandler()
        {
            // Validate the form data first
            if (!ValidateCashReceiptForm())
            {
                MessageBox.Show("Please correct the errors in the form.", "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            // Prepare the CashReceipt object
            CashReceiptClass cashReceipt = new CashReceiptClass
            {
                CashReceiptID = !string.IsNullOrWhiteSpace(txt_cashReceiptId.Text) ? Convert.ToInt32(txt_cashReceiptId.Text) : 0, // If editing or new Receipt
                AccountID = Convert.ToInt32(txt_accountId.Text),
                AccountName = txt_accountName.Text.Trim(),
                ReceiptDate = dtm_receiptDate.Value,
                CashAccountID = Convert.ToInt32(txt_cashAccount.Text),
                Amount = Convert.ToDecimal(txt_amount.Text),
                Description = txt_discription.Text.Trim(),
                IsCancelled = false,
                FinancialYearID = financialYearId // Assuming dIParent1 is your parent class containing financial year
            };

            // Prepare Transaction list
            List<Transaction> transactions = new List<Transaction>();

            // Transaction for Receipt to the account
            Transaction accountTransaction = new Transaction
            {
                AccountID = Convert.ToInt32(txt_accountId.Text),
                TransactionDate = dtm_receiptDate.Value,
                TransactionType = "credit",
                Amount = Convert.ToDecimal(txt_amount.Text),
                Description = txt_discription.Text.Trim(),
                IsCancelled = false,
                FinancialYearID = financialYearId
            };

            transactions.Add(accountTransaction);

            // Transaction for the cash account (debit)
            Transaction cashTransaction = new Transaction
            {
                AccountID = Convert.ToInt32(txt_cashAccount.Text),
                TransactionDate = dtm_receiptDate.Value,
                TransactionType = "debit",
                Amount = Convert.ToDecimal(txt_amount.Text),
                Description = txt_discription.Text.Trim(),
                IsCancelled = false,
                FinancialYearID = financialYearId
            };

            transactions.Add(cashTransaction);

            // Save the CashReceipt
            bool success = cashReceipt.SaveCashReceipt(cashReceipt, transactions);
            if (success)
            {
                MessageBox.Show("Cash Receipt saved successfully.", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                // Assuming this method clears your form
                commonFunctions.ClearAllTextBoxes(this);
                cashReceiptClass.LoadCashReceipts(dataGridView1, financialYearId, dtm_receiptDate.Value.Date);
                txt_cashReceiptId.Text = cashReceiptClass.GetNextAvailableCashReceiptID().ToString();
                txt_cashAccount.Text = "3";
                txt_cashAccountName.Text = "Cash in hand";
            }
            else
            {
                MessageBox.Show("Failed to save cash Receipt.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void UpdateCashReceiptHandler()
        {
            // Validate the form data first
            if (!ValidateCashReceiptForm())
            {
                MessageBox.Show("Please correct the errors in the form.", "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            // Prepare the CashReceipt object
            CashReceiptClass cashReceipt = new CashReceiptClass
            {
                CashReceiptID = !string.IsNullOrWhiteSpace(txt_cashReceiptId.Text) ? Convert.ToInt32(txt_cashReceiptId.Text) : 0, // The existing CashReceiptID
                AccountID = Convert.ToInt32(txt_accountId.Text),
                AccountName = txt_accountName.Text.Trim(),
                ReceiptDate = dtm_receiptDate.Value,
                CashAccountID = Convert.ToInt32(txt_cashAccount.Text),
                Amount = Convert.ToDecimal(txt_amount.Text),
                Description = txt_discription.Text.Trim(),
                IsCancelled = false,
                FinancialYearID = financialYearId
            };

            // Prepare Transaction list
            List<Transaction> updatedTransactions = new List<Transaction>();

            // Transaction for the account being paid (debit for recipient)
            Transaction accountTransaction = new Transaction
            {
                AccountID = Convert.ToInt32(txt_accountId.Text), // Account of the recipient
                TransactionDate = dtm_receiptDate.Value,
                TransactionType = "debit", // Debit to the recipient account
                Amount = Convert.ToDecimal(txt_amount.Text),
                Description = txt_discription.Text.Trim(),
                IsCancelled = false,
                FinancialYearID = financialYearId
            };

            updatedTransactions.Add(accountTransaction);

            // Transaction for the cash account (credit)
            Transaction cashTransaction = new Transaction
            {
                AccountID = Convert.ToInt32(txt_cashAccount.Text), // Cash or bank account from which Receipt is made
                TransactionDate = dtm_receiptDate.Value,
                TransactionType = "credit", // Credit to the source account
                Amount = Convert.ToDecimal(txt_amount.Text),
                Description = txt_discription.Text.Trim(),
                IsCancelled = false,
                FinancialYearID = financialYearId
            };

            updatedTransactions.Add(cashTransaction);

            // Update the CashReceipt and transactions
            bool success = cashReceipt.UpdateCashReceipt(cashReceipt, updatedTransactions);
            if (success)
            {
                MessageBox.Show("Cash Receipt updated successfully.", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                commonFunctions.ClearAllTextBoxes(this); // Clear form after successful update
                cashReceiptClass.LoadCashReceipts(dataGridView1, financialYearId, dtm_receiptDate.Value.Date);
                txt_cashReceiptId.Text = cashReceiptClass.GetNextAvailableCashReceiptID().ToString();
                txt_cashAccount.Text = "3";
                txt_cashAccountName.Text = "Cash in hand";
            }
            else
            {
                MessageBox.Show("Failed to update cash Receipt.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }


        private void RetrieveCashReceiptById(int cashReceiptId)
        {
            Connection dbConnection = new Connection();

            try
            {
                // Open a connection to the database
                dbConnection.openConnection();

                // Retrieve CashReceipt details
                string query = @"
        SELECT * FROM CashReceipt
        WHERE CashReceiptID = @CashReceiptID AND financialYearId=@financialYearId";

                using (SqlCommand command = new SqlCommand(query, dbConnection.connection))
                {
                    command.Parameters.AddWithValue("@CashReceiptID", cashReceiptId);
                    command.Parameters.AddWithValue("@financialYearId", financialYearId);

                    using (SqlDataReader reader = command.ExecuteReader())
                    {
                        if (reader.Read())
                        {
                            // Populate cash Receipt fields
                            txt_cashReceiptId.Text = reader["CashReceiptID"].ToString();
                            txt_accountId.Text = reader["AccountID"].ToString();
                            txt_accountName.Text = reader["AccountName"].ToString();
                            txt_cashAccount.Text = reader["CashAccountID"].ToString();
                            dtm_receiptDate.Value = Convert.ToDateTime(reader["ReceiptDate"]);
                            txt_amount.Text = reader["Amount"].ToString();
                            txt_discription.Text = reader["Description"].ToString();
                            //txt_financialYearID.Text = reader["FinancialYearID"].ToString();
                            //chk_isCancelled.Checked = Convert.ToBoolean(reader["IsCancelled"]);
                        }
                        else
                        {
                            MessageBox.Show("Cash Receipt not found.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                            return;
                        }
                    }
                }

                // Clear DataGridView before populating (if there are associated transactions)


                //MessageBox.Show("Cash Receipt details retrieved successfully.", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error retrieving cash Receipt: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally
            {
                // Ensure connection is closed
                dbConnection.closeConnection();
            }
        }

        private void GoToNextCashReceipt(int currentReceiptId)
        {
            Connection dbConnection = new Connection();

            try
            {
                // Open the database connection
                dbConnection.openConnection();

                // Query to find the next available CashReceiptID greater than the current one
                string query = @"
        SELECT TOP 1 CashReceiptID 
        FROM CashReceipt 
        WHERE CashReceiptID > @CurrentReceiptID
        ORDER BY CashReceiptID ASC";

                using (SqlCommand command = new SqlCommand(query, dbConnection.connection))
                {
                    command.Parameters.AddWithValue("@CurrentReceiptID", currentReceiptId);

                    object result = command.ExecuteScalar();

                    if (result != null)
                    {
                        int nextReceiptId = Convert.ToInt32(result);
                        RetrieveCashReceiptById(nextReceiptId);  // Call the function to retrieve and populate the next Receipt
                    }
                    else
                    {
                        MessageBox.Show("There are no more cash Receipts after the current one.", "No More Receipts", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error retrieving next cash Receipt: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally
            {
                // Ensure connection is closed
                dbConnection.closeConnection();
            }
        }

        private void GoToPreviousCashReceipt(int currentReceiptId)
        {
            Connection dbConnection = new Connection();

            try
            {
                // Open the database connection
                dbConnection.openConnection();

                // Query to find the previous available CashReceiptID less than the current one
                string query = @"
        SELECT TOP 1 CashReceiptID 
        FROM CashReceipt 
        WHERE CashReceiptID < @CurrentReceiptID
        ORDER BY CashReceiptID DESC";

                using (SqlCommand command = new SqlCommand(query, dbConnection.connection))
                {
                    command.Parameters.AddWithValue("@CurrentReceiptID", currentReceiptId);

                    object result = command.ExecuteScalar();

                    if (result != null)
                    {
                        int previousReceiptId = Convert.ToInt32(result);
                        RetrieveCashReceiptById(previousReceiptId);  // Call the function to retrieve and populate the previous Receipt
                    }
                    else
                    {
                        MessageBox.Show("There are no previous cash Receipts before the current one.", "No More Receipts", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error retrieving previous cash Receipt: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally
            {
                // Ensure connection is closed
                dbConnection.closeConnection();
            }
        }

        private void btn_back_Click(object sender, EventArgs e)
        {
            int currentReceiptId = Convert.ToInt32(txt_cashReceiptId.Text);  // Get the current SalesInvoiceID from the form
            GoToPreviousCashReceipt(currentReceiptId);
        }

        private void btn_forward_Click(object sender, EventArgs e)
        {
            int currentReceiptId = Convert.ToInt32(txt_cashReceiptId.Text);  // Get the current SalesInvoiceID from the form
            GoToNextCashReceipt(currentReceiptId);
        }

        private void btn_delete_Click(object sender, EventArgs e)
        {
            int cashReceiptID = Convert.ToInt32(txt_cashReceiptId.Text);

            if (cashReceiptClass.CashReceiptExists(cashReceiptID))
            {
                cashReceiptClass.DeleteCashReceiptById(cashReceiptID);
                cashReceiptClass.LoadCashReceipts(dataGridView1, financialYearId, dtm_receiptDate.Value.Date);
                commonFunctions.ClearAllTextBoxes(this);
                txt_cashAccount.Text = "3";
                txt_cashAccountName.Text = "Cash in hand";
                txt_cashReceiptId.Text = cashReceiptClass.GetNextAvailableCashReceiptID().ToString();
            }
        }

        private void btn_addNew_Click(object sender, EventArgs e)
        {
            commonFunctions.ClearAllTextBoxes(this);
            txt_cashAccount.Text = "3";
            txt_cashAccountName.Text = "Cash in hand";
            txt_cashReceiptId.Text = cashReceiptClass.GetNextAvailableCashReceiptID().ToString();
            txt_accountId.Focus();
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

        private void txt_accountId_KeyDown(object sender, KeyEventArgs e)
        {
            commonFunctions.HandleAccountSuggestionKeyDown(txt_accountId, txt_accountName, lstAccounts, e, txt_accountName);
        }

        private void dataGridView1_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            // Check if the row index is valid and not a new (empty) row
            if (e.RowIndex >= 0 && dataGridView1.Rows[e.RowIndex].IsNewRow == false)
            {
                DataGridViewRow selectedRow = dataGridView1.Rows[e.RowIndex];

                // Populate text boxes with the selected row's values
                txt_cashReceiptId.Text = selectedRow.Cells["receiptId"].Value?.ToString();
                dtm_receiptDate.Text = selectedRow.Cells["date"].Value?.ToString();
                txt_accountId.Text = selectedRow.Cells["accountId"].Value?.ToString();
                txt_accountName.Text = selectedRow.Cells["AccountName"].Value?.ToString();
                txt_amount.Text = selectedRow.Cells["amount"].Value?.ToString();
                txt_discription.Text = selectedRow.Cells["description"].Value?.ToString();
                txt_cashAccount.Text = selectedRow.Cells["cashAccountId"].Value?.ToString();
            }
        }
    }
}
