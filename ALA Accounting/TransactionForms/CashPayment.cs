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
    public partial class CashPayment : Form
    {
        CommonFunctions commonFunctions=new CommonFunctions();
        CashPaymentClass cashPaymentClass=new CashPaymentClass();
        FinancialYear financialYear = new FinancialYear();
        int financialYearId;
        int cashPaymentId=-1;

        public CashPayment(int financialYearId)
        {
            this.financialYearId = financialYearId;
            InitializeComponent();
        }

        public CashPayment(int financialYearId, int cashPaymentId)
        {
            this.financialYearId = financialYearId;
            this.cashPaymentId = cashPaymentId;
            InitializeComponent();
        }

        private void txt_cashAccountBalance_TextChanged(object sender, EventArgs e)
        {

        }

        private void CashPayment_Load(object sender, EventArgs e)
        {
            txt_cashPaymentId.Text=cashPaymentClass.GetNextAvailableCashPaymentID().ToString();
            cashPaymentClass.LoadCashPayments(dataGridView2, financialYearId, dtm_paymentDate.Value.Date);
            lstAccounts.Visible = false;
            txt_cashAccount.Text = "3";
            txt_cashAccountName.Text = "Cash in hand";

            if (cashPaymentId != -1)
            {
                RetrieveCashPaymentById(cashPaymentId);
            }

            dtm_paymentDate.Value = DateTime.Now;
        }

        private bool ValidateCashPaymentForm()
        {
            DateTime invoiceDate = dtm_paymentDate.Value.Date;
            var dates = financialYear.GetFinancialYearDatesById(financialYearId); // Replace 1 with the actual ID
            DateTime startDate = dates.StartDate.Date;
            DateTime endDate = dates.EndDate.Date;

            // Assuming financialYearStartDate and financialYearEndDate are DateTime variables set based on your financial year.
            if (invoiceDate < dates.StartDate.Date || invoiceDate > dates.EndDate.Date)
            {
                MessageBox.Show("Payment date must be within the financial year.", "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                dtm_paymentDate.Focus();
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

            // Check if CashPaymentID is provided and numeric (if applicable, may not be required for new payments)
            if (!string.IsNullOrWhiteSpace(txt_cashPaymentId.Text) && !int.TryParse(txt_cashPaymentId.Text, out _))
            {
                MessageBox.Show("Cash Payment ID must be a valid number if provided.", "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                txt_cashPaymentId.Focus();
                return false;
            }

            // If all validations pass, return true
            return true;
        }

        private void SaveCashPaymentHandler()
        {
            // Validate the form data first
            if (!ValidateCashPaymentForm())
            {
                MessageBox.Show("Please correct the errors in the form.", "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            // Prepare the CashPayment object
            CashPaymentClass cashPayment = new CashPaymentClass
            {
                CashPaymentID = !string.IsNullOrWhiteSpace(txt_cashPaymentId.Text) ? Convert.ToInt32(txt_cashPaymentId.Text) : 0, // If editing or new payment
                AccountID = Convert.ToInt32(txt_accountId.Text),
                AccountName = txt_accountName.Text.Trim(),
                PaymentDate = dtm_paymentDate.Value,
                CashAccountID = Convert.ToInt32(txt_cashAccount.Text),
                Amount = Convert.ToDecimal(txt_amount.Text),
                Description = txt_discription.Text.Trim(),
                IsCancelled = false,
                FinancialYearID = financialYearId 
            };

            // Prepare Transaction list
            List<Transaction> transactions = new List<Transaction>();

            // Transaction for payment to the account
            Transaction accountTransaction = new Transaction
            {
                AccountID = Convert.ToInt32(txt_accountId.Text),
                TransactionDate = dtm_paymentDate.Value,
                TransactionType = "debit",
                Amount = Convert.ToDecimal(txt_amount.Text),
                Description = txt_discription.Text.Trim(),
                IsCancelled = false,
                FinancialYearID = financialYearId
            };

            transactions.Add(accountTransaction);

            // Transaction for the cash account
            Transaction cashTransaction = new Transaction
            {
                AccountID = Convert.ToInt32(txt_cashAccount.Text),
                TransactionDate = dtm_paymentDate.Value,
                TransactionType = "credit",
                Amount = Convert.ToDecimal(txt_amount.Text),
                Description = txt_discription.Text.Trim(),
                IsCancelled = false,
                FinancialYearID = financialYearId
            };

            transactions.Add(cashTransaction);

            // Save the CashPayment
            bool success = cashPayment.SaveCashPayment(cashPayment, transactions);
            if (success)
            {
                MessageBox.Show("Cash payment saved successfully.", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                 // Assuming this method clears your form
                commonFunctions.ClearAllTextBoxes(this);
                cashPaymentClass.LoadCashPayments(dataGridView2, financialYearId, dtm_paymentDate.Value.Date);
                txt_cashPaymentId.Text = cashPaymentClass.GetNextAvailableCashPaymentID().ToString();
                txt_cashAccount.Text = "3";
                txt_cashAccountName.Text = "Cash in hand";
            }
            else
            {
                MessageBox.Show("Failed to save cash payment.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void UpdateCashPaymentHandler()
        {
            // Validate the form data first
            if (!ValidateCashPaymentForm())
            {
                MessageBox.Show("Please correct the errors in the form.", "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            // Prepare the CashPayment object
            CashPaymentClass cashPayment = new CashPaymentClass
            {
                CashPaymentID = !string.IsNullOrWhiteSpace(txt_cashPaymentId.Text) ? Convert.ToInt32(txt_cashPaymentId.Text) : 0, // The existing CashPaymentID
                AccountID = Convert.ToInt32(txt_accountId.Text),
                AccountName = txt_accountName.Text.Trim(),
                PaymentDate = dtm_paymentDate.Value,
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
                TransactionDate = dtm_paymentDate.Value,
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
                AccountID = Convert.ToInt32(txt_cashAccount.Text), // Cash or bank account from which payment is made
                TransactionDate = dtm_paymentDate.Value,
                TransactionType = "credit", 
                Amount = Convert.ToDecimal(txt_amount.Text),
                Description = txt_discription.Text.Trim(),
                IsCancelled = false,
                FinancialYearID = financialYearId
            };

            updatedTransactions.Add(cashTransaction);

            // Update the CashPayment and transactions
            bool success = cashPayment.UpdateCashPayment(cashPayment, updatedTransactions);
            if (success)
            {
                MessageBox.Show("Cash payment updated successfully.", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                commonFunctions.ClearAllTextBoxes(this); // Clear form after successful update
                cashPaymentClass.LoadCashPayments(dataGridView2, financialYearId, dtm_paymentDate.Value.Date);
                txt_cashPaymentId.Text = cashPaymentClass.GetNextAvailableCashPaymentID().ToString();
                txt_cashAccount.Text = "3";
                txt_cashAccountName.Text = "Cash in hand";
            }
            else
            {
                MessageBox.Show("Failed to update cash payment.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }


        private void btn_save_Click(object sender, EventArgs e)
        {
            if (cashPaymentClass.CashPaymentExists(Convert.ToInt32(txt_cashPaymentId.Text)))
            {
                UpdateCashPaymentHandler();
            }
            else
            {
                SaveCashPaymentHandler();
            }

        }

        private void RetrieveCashPaymentById(int cashPaymentId)
        {
            Connection dbConnection = new Connection();

            try
            {
                // Open a connection to the database
                dbConnection.openConnection();

                // Retrieve CashPayment details
                string query = @"
        SELECT * FROM CashPayment
        WHERE CashPaymentID = @CashPaymentID AND financialYearId=@financialYearId";

                using (SqlCommand command = new SqlCommand(query, dbConnection.connection))
                {
                    command.Parameters.AddWithValue("@CashPaymentID", cashPaymentId);
                    command.Parameters.AddWithValue("@financialYearId", financialYearId);

                    using (SqlDataReader reader = command.ExecuteReader())
                    {
                        if (reader.Read())
                        {
                            // Populate cash payment fields
                            txt_cashPaymentId.Text = reader["CashPaymentID"].ToString();
                            txt_accountId.Text = reader["AccountID"].ToString();
                            txt_accountName.Text = reader["AccountName"].ToString();
                            txt_cashAccount.Text = reader["CashAccountID"].ToString();
                            dtm_paymentDate.Value = Convert.ToDateTime(reader["PaymentDate"]);
                            txt_amount.Text = reader["Amount"].ToString();
                            txt_discription.Text = reader["Description"].ToString();
                            //txt_financialYearID.Text = reader["FinancialYearID"].ToString();
                            //chk_isCancelled.Checked = Convert.ToBoolean(reader["IsCancelled"]);
                        }
                        else
                        {
                            MessageBox.Show("Cash payment not found.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                            return;
                        }
                    }
                }

                // Clear DataGridView before populating (if there are associated transactions)
                

                //MessageBox.Show("Cash payment details retrieved successfully.", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error retrieving cash payment: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally
            {
                // Ensure connection is closed
                dbConnection.closeConnection();
            }
        }

        private void GoToNextCashPayment(int currentPaymentId)
        {
            Connection dbConnection = new Connection();

            try
            {
                // Open the database connection
                dbConnection.openConnection();

                // Query to find the next available CashPaymentID greater than the current one
                string query = @"
        SELECT TOP 1 CashPaymentID 
        FROM CashPayment 
        WHERE CashPaymentID > @CurrentPaymentID
        ORDER BY CashPaymentID ASC";

                using (SqlCommand command = new SqlCommand(query, dbConnection.connection))
                {
                    command.Parameters.AddWithValue("@CurrentPaymentID", currentPaymentId);

                    object result = command.ExecuteScalar();

                    if (result != null)
                    {
                        int nextPaymentId = Convert.ToInt32(result);
                        RetrieveCashPaymentById(nextPaymentId);  // Call the function to retrieve and populate the next payment
                    }
                    else
                    {
                        MessageBox.Show("There are no more cash payments after the current one.", "No More Payments", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error retrieving next cash payment: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally
            {
                // Ensure connection is closed
                dbConnection.closeConnection();
            }
        }

        private void GoToPreviousCashPayment(int currentPaymentId)
        {
            Connection dbConnection = new Connection();

            try
            {
                // Open the database connection
                dbConnection.openConnection();

                // Query to find the previous available CashPaymentID less than the current one
                string query = @"
        SELECT TOP 1 CashPaymentID 
        FROM CashPayment 
        WHERE CashPaymentID < @CurrentPaymentID
        ORDER BY CashPaymentID DESC";

                using (SqlCommand command = new SqlCommand(query, dbConnection.connection))
                {
                    command.Parameters.AddWithValue("@CurrentPaymentID", currentPaymentId);

                    object result = command.ExecuteScalar();

                    if (result != null)
                    {
                        int previousPaymentId = Convert.ToInt32(result);
                        RetrieveCashPaymentById(previousPaymentId);  // Call the function to retrieve and populate the previous payment
                    }
                    else
                    {
                        MessageBox.Show("There are no previous cash payments before the current one.", "No More Payments", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error retrieving previous cash payment: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally
            {
                // Ensure connection is closed
                dbConnection.closeConnection();
            }
        }

        private void btn_back_Click(object sender, EventArgs e)
        {
            int currentPaymentId = Convert.ToInt32(txt_cashPaymentId.Text);  // Get the current SalesInvoiceID from the form
            GoToPreviousCashPayment(currentPaymentId);
        }

        private void btn_forward_Click(object sender, EventArgs e)
        {
            int currentPaymentId = Convert.ToInt32(txt_cashPaymentId.Text);  // Get the current SalesInvoiceID from the form
            GoToNextCashPayment(currentPaymentId);
        }

        private void btn_delete_Click(object sender, EventArgs e)
        {
            int cashPaymentID = Convert.ToInt32(txt_cashPaymentId.Text);

            if (cashPaymentClass.CashPaymentExists(cashPaymentID))
            {
                cashPaymentClass.DeleteCashPaymentById(cashPaymentID);
                cashPaymentClass.LoadCashPayments(dataGridView2, financialYearId, dtm_paymentDate.Value.Date);
                commonFunctions.ClearAllTextBoxes(this);
                txt_cashAccount.Text = "3";
                txt_cashAccountName.Text = "Cash in hand";
                txt_cashPaymentId.Text = cashPaymentClass.GetNextAvailableCashPaymentID().ToString();
            }
        }

        private void txt_accountName_TextChanged(object sender, EventArgs e)
        {

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

        private void btn_addNew_Click(object sender, EventArgs e)
        {
            commonFunctions.ClearAllTextBoxes(this);
            txt_cashAccount.Text = "3";
            txt_cashAccountName.Text = "Cash in hand";
            txt_cashPaymentId.Text = cashPaymentClass.GetNextAvailableCashPaymentID().ToString();
            txt_accountId.Focus();
        }

        private void txt_accountName_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                txt_amount.Focus();

                e.SuppressKeyPress = true;
            }
        }

        private void dataGridView2_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0 && dataGridView2.Rows[e.RowIndex].IsNewRow == false)
            {
                DataGridViewRow selectedRow = dataGridView2.Rows[e.RowIndex];

                // Populate text boxes with the selected row's values
                txt_cashPaymentId.Text = selectedRow.Cells["paymentId"].Value?.ToString();
                dtm_paymentDate.Text = selectedRow.Cells["date"].Value?.ToString();
                txt_accountId.Text = selectedRow.Cells["accountId"].Value?.ToString();
                txt_accountName.Text = selectedRow.Cells["AccountName"].Value?.ToString();
                txt_amount.Text = selectedRow.Cells["amount"].Value?.ToString();
                txt_discription.Text = selectedRow.Cells["description"].Value?.ToString();
                txt_cashAccount.Text = selectedRow.Cells["cashAccountId"].Value?.ToString();
            }
        }
    }
}
