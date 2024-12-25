using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ALA_Accounting.transaction_classes
{
    internal class BankPaymentClass
    {
        
        Connection dbConnection;

        public int BankPaymentID { get; set; }
        public int AccountID { get; set; }
        public string AccountName { get; set; }
        public int BankAccountID { get; set; }
        public DateTime PaymentDate { get; set; }
        public decimal Amount { get; set; }
        public string ChequeNumber { get; set; }
        public string ChequeDate { get; set; }
        public string Description { get; set; }
        public int FinancialYearID { get; set; }
        public bool IsCancelled { get; set; }

        public BankPaymentClass()
        {
            dbConnection = new Connection();
        }


        public bool SaveBankPayment(BankPaymentClass payment, List<Transaction> transactions)
        {
            SqlTransaction sqlTransaction = null;

            try
            {
                // Open database connection and begin transaction
                dbConnection.openConnection();
                sqlTransaction = dbConnection.connection.BeginTransaction();

                // Insert into BankPayment table and get the newly generated ID
                string insertPaymentQuery = @"
            INSERT INTO BankPayment (AccountID, AccountName, BankAccountID, PaymentDate, Amount, ChequeNumber, ChequeDate, Description, FinancialYearID, IsCancelled)
            VALUES (@AccountID, @AccountName, @BankAccountID, @PaymentDate, @Amount, @ChequeNumber, @ChequeDate, @Description, @FinancialYearID, @IsCancelled);
            SELECT SCOPE_IDENTITY();";

                int bankPaymentID;
                using (SqlCommand command = new SqlCommand(insertPaymentQuery, dbConnection.connection, sqlTransaction))
                {
                    command.Parameters.AddWithValue("@AccountID", payment.AccountID);
                    command.Parameters.AddWithValue("@AccountName", payment.AccountName);
                    command.Parameters.AddWithValue("@BankAccountID", payment.BankAccountID);
                    command.Parameters.AddWithValue("@PaymentDate", payment.PaymentDate);
                    command.Parameters.AddWithValue("@Amount", payment.Amount);
                    command.Parameters.AddWithValue("@ChequeNumber", payment.ChequeNumber ?? (object)DBNull.Value);
                    command.Parameters.AddWithValue("@ChequeDate", payment.ChequeDate ?? (object)DBNull.Value);
                    command.Parameters.AddWithValue("@Description", payment.Description ?? (object)DBNull.Value);
                    command.Parameters.AddWithValue("@FinancialYearID", payment.FinancialYearID);
                    command.Parameters.AddWithValue("@IsCancelled", payment.IsCancelled);

                    bankPaymentID = Convert.ToInt32(command.ExecuteScalar()); // Retrieve the newly created ID
                }

                // Insert transactions associated with the BankPayment
                InsertTransactions(transactions, bankPaymentID, sqlTransaction);

                // Commit the transaction
                sqlTransaction.Commit();
                return true;
            }
            catch (Exception ex)
            {
                // Rollback transaction in case of error
                sqlTransaction?.Rollback();
                MessageBox.Show("Error saving bank payment: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }
            finally
            {
                // Close the database connection
                dbConnection.closeConnection();
            }
        }

        private void InsertTransactions(List<Transaction> transactions, int sourceID, SqlTransaction sqlTransaction)
        {
            string insertTransactionQuery = @"
        INSERT INTO Transactions (AccountID, TransactionDate, TransactionType, Amount, Description, FinancialYearID, SourceID, SourceTable, IsCancelled)
        VALUES (@AccountID, @TransactionDate, @TransactionType, @Amount, @Description, @FinancialYearID, @SourceID, @SourceTable, @IsCancelled);";

            foreach (var transaction in transactions)
            {
                using (SqlCommand command = new SqlCommand(insertTransactionQuery, dbConnection.connection, sqlTransaction))
                {
                    command.Parameters.AddWithValue("@AccountID", transaction.AccountID);
                    command.Parameters.AddWithValue("@TransactionDate", transaction.TransactionDate);
                    command.Parameters.AddWithValue("@TransactionType", transaction.TransactionType);
                    command.Parameters.AddWithValue("@Amount", transaction.Amount);
                    command.Parameters.AddWithValue("@Description", transaction.Description ?? (object)DBNull.Value);
                    command.Parameters.AddWithValue("@FinancialYearID", transaction.FinancialYearID);
                    command.Parameters.AddWithValue("@SourceID", sourceID);
                    command.Parameters.AddWithValue("@SourceTable", "BankPayment");
                    command.Parameters.AddWithValue("@IsCancelled", transaction.IsCancelled);

                    command.ExecuteNonQuery();
                }
            }
        }


        public bool UpdateBankPayment(BankPaymentClass payment, List<Transaction> transactions)
        {
            SqlTransaction sqlTransaction = null;

            try
            {
                // Open database connection and begin transaction
                dbConnection.openConnection();
                sqlTransaction = dbConnection.connection.BeginTransaction();

                // Update the BankPayment table
                string updatePaymentQuery = @"
            UPDATE BankPayment
            SET AccountID = @AccountID, AccountName = @AccountName, BankAccountID = @BankAccountID, 
                PaymentDate = @PaymentDate, Amount = @Amount, ChequeNumber = @ChequeNumber, 
                ChequeDate = @ChequeDate, Description = @Description, FinancialYearID = @FinancialYearID, 
                IsCancelled = @IsCancelled
            WHERE BankPaymentID = @BankPaymentID;";

                using (SqlCommand command = new SqlCommand(updatePaymentQuery, dbConnection.connection, sqlTransaction))
                {
                    command.Parameters.AddWithValue("@AccountID", payment.AccountID);
                    command.Parameters.AddWithValue("@AccountName", payment.AccountName);
                    command.Parameters.AddWithValue("@BankAccountID", payment.BankAccountID);
                    command.Parameters.AddWithValue("@PaymentDate", payment.PaymentDate);
                    command.Parameters.AddWithValue("@Amount", payment.Amount);
                    command.Parameters.AddWithValue("@ChequeNumber", payment.ChequeNumber ?? (object)DBNull.Value);
                    command.Parameters.AddWithValue("@ChequeDate", payment.ChequeDate ?? (object)DBNull.Value);
                    command.Parameters.AddWithValue("@Description", payment.Description ?? (object)DBNull.Value);
                    command.Parameters.AddWithValue("@FinancialYearID", payment.FinancialYearID);
                    command.Parameters.AddWithValue("@IsCancelled", payment.IsCancelled);
                    command.Parameters.AddWithValue("@BankPaymentID", payment.BankPaymentID);

                    command.ExecuteNonQuery();
                }

                // Delete old transactions associated with this payment
                string deleteTransactionQuery = @"
            DELETE FROM Transactions 
            WHERE SourceID = @SourceID AND SourceTable = 'BankPayment';";

                using (SqlCommand command = new SqlCommand(deleteTransactionQuery, dbConnection.connection, sqlTransaction))
                {
                    command.Parameters.AddWithValue("@SourceID", payment.BankPaymentID);
                    command.ExecuteNonQuery();
                }

                // Insert updated transactions using the helper method
                InsertTransactions(transactions, payment.BankPaymentID, sqlTransaction);

                // Commit the transaction
                sqlTransaction.Commit();
                return true;
            }
            catch (Exception ex)
            {
                // Rollback transaction in case of error
                sqlTransaction?.Rollback();
                MessageBox.Show("Error updating bank payment: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }
            finally
            {
                // Close the database connection
                dbConnection.closeConnection();
            }
        }


        public void LoadBankPayments(DataGridView dataGridView, int financialYearId, DateTime date)
        {
            try
            {
                dbConnection.openConnection();

                string query = @"
            SELECT BankPaymentID, AccountID, AccountName, BankAccountID, PaymentDate, ChequeNumber, ChequeDate, Description, Amount
            FROM BankPayment
            WHERE FinancialYearID = @FinancialYearID AND PaymentDate = @PaymentDate
            ORDER BY BankPaymentID DESC;";

                using (SqlCommand command = new SqlCommand(query, dbConnection.connection))
                {
                    command.Parameters.AddWithValue("@FinancialYearID", financialYearId);
                    command.Parameters.AddWithValue("@PaymentDate", date);

                    using (SqlDataAdapter adapter = new SqlDataAdapter(command))
                    {
                        DataTable dataTable = new DataTable();
                        adapter.Fill(dataTable);

                        dataGridView.Rows.Clear();
                        foreach (DataRow row in dataTable.Rows)
                        {
                            int rowIndex = dataGridView.Rows.Add();
                            DataGridViewRow dgvRow = dataGridView.Rows[rowIndex];

                            dgvRow.Cells["bankPaymentId"].Value = row["BankPaymentID"];
                            dgvRow.Cells["AccountID"].Value = row["AccountID"];
                            dgvRow.Cells["accountName"].Value = row["AccountName"];
                            dgvRow.Cells["bankAccountID"].Value = row["BankAccountID"];
                            dgvRow.Cells["date"].Value = Convert.ToDateTime(row["PaymentDate"]).ToString("dd/MM/yyyy");

                            dgvRow.Cells["chequeNumber"].Value = row["ChequeNumber"];
                            dgvRow.Cells["chequeDate"].Value = row["ChequeDate"] != DBNull.Value
                                ? Convert.ToDateTime(row["chequeDate"]).ToString("dd/MM/yyyy")
                                : string.Empty;
                            dgvRow.Cells["description"].Value = row["Description"];
                            dgvRow.Cells["amount"].Value = row["Amount"];
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error loading bank payments: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally
            {
                dbConnection.closeConnection();
            }
        }

        public bool BankPaymentExists(int bankPaymentId)
        {
            try
            {
                dbConnection.openConnection();

                string query = "SELECT COUNT(1) FROM BankPayment WHERE BankPaymentID = @BankPaymentID";

                using (SqlCommand command = new SqlCommand(query, dbConnection.connection))
                {
                    command.Parameters.AddWithValue("@BankPaymentID", bankPaymentId);
                    int count = (int)command.ExecuteScalar();
                    return count > 0;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error checking if Bank Payment exists: " + ex.Message,
                                "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }
            finally
            {
                dbConnection.closeConnection();
            }
        }

        public int GetNextAvailableBankPaymentID()
        {
            try
            {
                dbConnection.openConnection();

                string query = "SELECT ISNULL(MAX(BankPaymentID), 0) + 1 FROM BankPayment";

                using (SqlCommand command = new SqlCommand(query, dbConnection.connection))
                {
                    return (int)command.ExecuteScalar();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error getting next available Bank Payment ID: " + ex.Message,
                                "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return 1;
            }
            finally
            {
                dbConnection.closeConnection();
            }
        }

        public void DeleteBankPaymentById(int bankPaymentId)
        {
            try
            {
                // Confirm deletion with the user
                var confirmResult = MessageBox.Show(
                    "Are you sure you want to delete this bank payment and all its associated transactions?",
                    "Confirm Deletion",
                    MessageBoxButtons.YesNo,
                    MessageBoxIcon.Warning);

                if (confirmResult != DialogResult.Yes)
                {
                    return; // Exit if the user does not confirm the deletion
                }

                // Open a connection to the database
                dbConnection.openConnection();

                // Start a transaction to ensure both the bank payment and its related transactions are deleted
                using (SqlTransaction transaction = dbConnection.connection.BeginTransaction())
                {
                    // Delete associated transactions from the Transactions table
                    string deleteTransactionQuery = @"
                        DELETE FROM Transactions 
                        WHERE SourceID = @BankPaymentID 
                        AND SourceTable = 'BankPayment'";

                    using (SqlCommand deleteTransactionCommand = new SqlCommand(deleteTransactionQuery, dbConnection.connection, transaction))
                    {
                        deleteTransactionCommand.Parameters.AddWithValue("@BankPaymentID", bankPaymentId);
                        deleteTransactionCommand.ExecuteNonQuery(); // Execute to delete the related transactions
                    }

                    // Delete the bank payment itself from the BankPayment table
                    string deleteBankPaymentQuery = @"
                        DELETE FROM BankPayment 
                        WHERE BankPaymentID = @BankPaymentID";

                    using (SqlCommand deleteBankPaymentCommand = new SqlCommand(deleteBankPaymentQuery, dbConnection.connection, transaction))
                    {
                        deleteBankPaymentCommand.Parameters.AddWithValue("@BankPaymentID", bankPaymentId);
                        deleteBankPaymentCommand.ExecuteNonQuery(); // Execute to delete the bank payment
                    }

                    // Commit the transaction to apply both deletions
                    transaction.Commit();
                }

                MessageBox.Show("Bank payment and associated transactions deleted successfully.", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error deleting bank payment: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally
            {
                // Ensure connection is closed
                dbConnection.closeConnection();
            }
        }



    }
}
