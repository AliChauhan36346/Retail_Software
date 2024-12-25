using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Common;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ALA_Accounting.transaction_classes
{
    public class CashPaymentClass
    {
        Connection dbConnection;

        public int CashPaymentID { get; set; } // This will be auto-generated in the database
        public int AccountID { get; set; } // The ID of the account to which payment is made
        public string AccountName { get; set; } // The ID of the account to which payment is made
        public int CashAccountID { get; set; } // The ID of the cash account
        public DateTime PaymentDate { get; set; } // The date of the payment
        public decimal Amount { get; set; } // The payment amount
        public string Description { get; set; } // Optional description of the payment
        public int FinancialYearID { get; set; } // The financial year for the transaction
        public bool IsCancelled { get; set; } // Whether the payment is cancelled

        public CashPaymentClass()
        {
            dbConnection = new Connection(); 
        }

        public bool SaveCashPayment(CashPaymentClass payment, List<Transaction> transactions)
        {
            SqlTransaction sqlTransaction = null;

            try
            {
                dbConnection.openConnection();

                // Start a transaction
                sqlTransaction = dbConnection.connection.BeginTransaction();

                // Insert into CashPayment and get the CashPaymentID
                string insertPaymentQuery = @"
            INSERT INTO CashPayment (AccountID, AccountName, CashAccountID, PaymentDate, Amount, Description, FinancialYearID, IsCancelled)
            VALUES (@AccountID, @AccountName, @CashAccountID, @PaymentDate, @Amount, @Description, @FinancialYearID, @IsCancelled);
            SELECT SCOPE_IDENTITY();"
                ;

                int cashPaymentID;
                using (SqlCommand paymentCommand = new SqlCommand(insertPaymentQuery, dbConnection.connection, sqlTransaction))
                {
                    paymentCommand.Parameters.AddWithValue("@AccountID", payment.AccountID);
                    paymentCommand.Parameters.AddWithValue("@AccountName", payment.AccountName);
                    paymentCommand.Parameters.AddWithValue("@CashAccountID", payment.CashAccountID);
                    paymentCommand.Parameters.AddWithValue("@PaymentDate", payment.PaymentDate);
                    paymentCommand.Parameters.AddWithValue("@Amount", payment.Amount);
                    paymentCommand.Parameters.AddWithValue("@Description", payment.Description ?? (object)DBNull.Value);
                    paymentCommand.Parameters.AddWithValue("@FinancialYearID", payment.FinancialYearID);
                    paymentCommand.Parameters.AddWithValue("@IsCancelled", payment.IsCancelled);

                    cashPaymentID = Convert.ToInt32(paymentCommand.ExecuteScalar());
                }

                // Insert each transaction into Transactions
                string insertTransactionQuery = @"
            INSERT INTO Transactions (AccountID, TransactionDate, TransactionType, Amount, Description, FinancialYearID, SourceID, SourceTable, IsCancelled)
            VALUES (@AccountID, @TransactionDate, @TransactionType, @Amount, @Description, @FinancialYearID, @SourceID, @SourceTable, @IsCancelled);"
                ;

                foreach (var transaction in transactions)
                {
                    using (SqlCommand transactionCommand = new SqlCommand(insertTransactionQuery, dbConnection.connection, sqlTransaction))
                    {
                        transactionCommand.Parameters.AddWithValue("@AccountID", transaction.AccountID);
                        transactionCommand.Parameters.AddWithValue("@TransactionDate", transaction.TransactionDate);
                        transactionCommand.Parameters.AddWithValue("@TransactionType", transaction.TransactionType);
                        transactionCommand.Parameters.AddWithValue("@Amount", transaction.Amount);
                        transactionCommand.Parameters.AddWithValue("@Description", transaction.Description ?? (object)DBNull.Value);
                        transactionCommand.Parameters.AddWithValue("@FinancialYearID", transaction.FinancialYearID);
                        transactionCommand.Parameters.AddWithValue("@SourceID", cashPaymentID); // Link to the CashPayment
                        transactionCommand.Parameters.AddWithValue("@SourceTable", "CashPayment");
                        transactionCommand.Parameters.AddWithValue("@IsCancelled", transaction.IsCancelled);

                        transactionCommand.ExecuteNonQuery();
                    }
                }

                // Commit the transaction
                sqlTransaction.Commit();
                return true;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error saving cash payment: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);

                if (sqlTransaction != null)
                {
                    try
                    {
                        sqlTransaction.Rollback();
                    }
                    catch (Exception rollbackEx)
                    {
                        MessageBox.Show("Error rolling back transaction: " + rollbackEx.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }

                return false;
            }
            finally
            {
                dbConnection.closeConnection();
            }
        }

        public bool UpdateCashPayment(CashPaymentClass payment, List<Transaction> transactions)
        {
            SqlTransaction sqlTransaction = null;

            try
            {
                dbConnection.openConnection();

                // Start a transaction
                sqlTransaction = dbConnection.connection.BeginTransaction();

                // Update the existing CashPayment
                string updatePaymentQuery = @"
        UPDATE CashPayment
        SET AccountID = @AccountID,
            AccountName=@AccountName,
            CashAccountID = @CashAccountID,
            PaymentDate = @PaymentDate,
            Amount = @Amount,
            Description = @Description,
            FinancialYearID = @FinancialYearID,
            IsCancelled = @IsCancelled
        WHERE CashPaymentID = @CashPaymentID;";

                using (SqlCommand paymentCommand = new SqlCommand(updatePaymentQuery, dbConnection.connection, sqlTransaction))
                {
                    paymentCommand.Parameters.AddWithValue("@AccountID", payment.AccountID);
                    paymentCommand.Parameters.AddWithValue("@AccountName", payment.AccountName);
                    paymentCommand.Parameters.AddWithValue("@CashAccountID", payment.CashAccountID);
                    paymentCommand.Parameters.AddWithValue("@PaymentDate", payment.PaymentDate);
                    paymentCommand.Parameters.AddWithValue("@Amount", payment.Amount);
                    paymentCommand.Parameters.AddWithValue("@Description", payment.Description ?? (object)DBNull.Value);
                    paymentCommand.Parameters.AddWithValue("@FinancialYearID", payment.FinancialYearID);
                    paymentCommand.Parameters.AddWithValue("@IsCancelled", payment.IsCancelled);
                    paymentCommand.Parameters.AddWithValue("@CashPaymentID", payment.CashPaymentID);

                    paymentCommand.ExecuteNonQuery();
                }

                // Delete existing transactions related to the CashPaymentID
                string deleteTransactionQuery = "DELETE FROM Transactions WHERE SourceID = @SourceID AND SourceTable = 'CashPayment';";
                using (SqlCommand deleteCommand = new SqlCommand(deleteTransactionQuery, dbConnection.connection, sqlTransaction))
                {
                    deleteCommand.Parameters.AddWithValue("@SourceID", payment.CashPaymentID);
                    deleteCommand.ExecuteNonQuery();
                }

                // Insert the updated transactions
                string insertTransactionQuery = @"
        INSERT INTO Transactions (AccountID, TransactionDate, TransactionType, Amount, Description, FinancialYearID, SourceID, SourceTable, IsCancelled)
        VALUES (@AccountID, @TransactionDate, @TransactionType, @Amount, @Description, @FinancialYearID, @SourceID, @SourceTable, @IsCancelled);";

                foreach (var transaction in transactions)
                {
                    using (SqlCommand transactionCommand = new SqlCommand(insertTransactionQuery, dbConnection.connection, sqlTransaction))
                    {
                        transactionCommand.Parameters.AddWithValue("@AccountID", transaction.AccountID);
                        transactionCommand.Parameters.AddWithValue("@TransactionDate", transaction.TransactionDate);
                        transactionCommand.Parameters.AddWithValue("@TransactionType", transaction.TransactionType);
                        transactionCommand.Parameters.AddWithValue("@Amount", transaction.Amount);
                        transactionCommand.Parameters.AddWithValue("@Description", transaction.Description ?? (object)DBNull.Value);
                        transactionCommand.Parameters.AddWithValue("@FinancialYearID", transaction.FinancialYearID);
                        transactionCommand.Parameters.AddWithValue("@SourceID", payment.CashPaymentID); // Link to the CashPayment
                        transactionCommand.Parameters.AddWithValue("@SourceTable", "CashPayment");
                        transactionCommand.Parameters.AddWithValue("@IsCancelled", transaction.IsCancelled);

                        transactionCommand.ExecuteNonQuery();
                    }
                }

                // Commit the transaction
                sqlTransaction.Commit();
                return true;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error updating cash payment: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);

                if (sqlTransaction != null)
                {
                    try
                    {
                        sqlTransaction.Rollback();
                    }
                    catch (Exception rollbackEx)
                    {
                        MessageBox.Show("Error rolling back transaction: " + rollbackEx.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }

                return false;
            }
            finally
            {
                dbConnection.closeConnection();
            }
        }

        public bool CashPaymentExists(int cashPaymentId)
        {
            try
            {
                dbConnection.openConnection();

                string query = "SELECT COUNT(1) FROM CashPayment WHERE CashPaymentID = @CashPaymentID";

                using (SqlCommand command = new SqlCommand(query, dbConnection.connection))
                {
                    command.Parameters.AddWithValue("@CashPaymentID", cashPaymentId);
                    int count = (int)command.ExecuteScalar();
                    return count > 0;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error checking if Cash Payment exists: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }
            finally
            {
                dbConnection.closeConnection();
            }
        }

        public int GetNextAvailableCashPaymentID()
        {
            try
            {
                dbConnection.openConnection();

                string query = "SELECT ISNULL(MAX(CashPaymentID), 0) + 1 FROM CashPayment";

                using (SqlCommand command = new SqlCommand(query, dbConnection.connection))
                {
                    return (int)command.ExecuteScalar();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error getting next available Cash Payment ID: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return 1;
            }
            finally
            {
                dbConnection.closeConnection();
            }
        }

        public void DeleteCashPaymentById(int cashPaymentId)
        {

            try
            {
                // Confirm deletion with the user
                var confirmResult = MessageBox.Show("Are you sure you want to delete this cash payment and all its associated transactions?",
                                                    "Confirm Deletion",
                                                    MessageBoxButtons.YesNo,
                                                    MessageBoxIcon.Warning);

                if (confirmResult != DialogResult.Yes)
                {
                    return; // Exit if the user does not confirm the deletion
                }

                // Open a connection to the database
                dbConnection.openConnection();

                // Start a transaction to ensure both the cash payment and its related transactions are deleted
                using (SqlTransaction transaction = dbConnection.connection.BeginTransaction())
                {
                    // Delete associated transactions from the Transactions table
                    string deleteTransactionQuery = @"
            DELETE FROM Transactions 
            WHERE SourceID = @CashPaymentID 
            AND SourceTable = 'CashPayment'";

                    using (SqlCommand deleteTransactionCommand = new SqlCommand(deleteTransactionQuery, dbConnection.connection, transaction))
                    {
                        deleteTransactionCommand.Parameters.AddWithValue("@CashPaymentID", cashPaymentId);
                        deleteTransactionCommand.ExecuteNonQuery(); // Execute the command to delete the related transactions
                    }

                    // Delete the cash payment itself from the CashPayment table
                    string deleteCashPaymentQuery = @"
            DELETE FROM CashPayment 
            WHERE CashPaymentID = @CashPaymentID";

                    using (SqlCommand deleteCashPaymentCommand = new SqlCommand(deleteCashPaymentQuery, dbConnection.connection, transaction))
                    {
                        deleteCashPaymentCommand.Parameters.AddWithValue("@CashPaymentID", cashPaymentId);
                        deleteCashPaymentCommand.ExecuteNonQuery(); // Execute the command to delete the cash payment
                    }

                    // Commit the transaction to ensure that both deletions are applied
                    transaction.Commit();
                }

                MessageBox.Show("Cash payment and associated transactions deleted successfully.", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);

            }
            catch (Exception ex)
            {
                MessageBox.Show("Error deleting cash payment: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally
            {
                // Ensure connection is closed
                dbConnection.closeConnection();
            }
        }

        public void LoadCashPayments(DataGridView dataGridView, int financialYearId, DateTime date)
        {
            try
            {
                dbConnection.openConnection();

                string query = "SELECT CashPaymentID, AccountID, AccountName, PaymentDate, CashAccountID, Description, Amount " +
                       "FROM CashPayment " +
                       "WHERE FinancialYearID = @FinancialYearID  AND paymentDate=@paymentDate " +
                       "ORDER BY CashPaymentID DESC";

                using (SqlCommand command = new SqlCommand(query, dbConnection.connection))
                {
                    command.Parameters.AddWithValue("@FinancialYearID", financialYearId);
                    command.Parameters.AddWithValue("@paymentDate", date);

                    using (SqlDataAdapter adapter = new SqlDataAdapter(command))
                    {
                        DataTable dataTable = new DataTable();
                        adapter.Fill(dataTable);



                        // Clear the DataGridView before loading new data
                        dataGridView.Rows.Clear();

                        // Loop through the DataTable and add data to the DataGridView
                        foreach (DataRow row in dataTable.Rows)
                        {
                            int rowIndex = dataGridView.Rows.Add();
                            DataGridViewRow dataGridViewRow = dataGridView.Rows[rowIndex];

                            dataGridViewRow.Cells["PaymentId"].Value = row["cashPaymentID"];
                            dataGridViewRow.Cells["date"].Value = row["PaymentDate"];
                            dataGridViewRow.Cells["accountID"].Value = row["accountID"];
                            dataGridViewRow.Cells["accountName"].Value = row["AccountName"];
                            dataGridViewRow.Cells["description"].Value = row["description"];
                            dataGridViewRow.Cells["cashAccountID"].Value = row["cashAccountID"];
                            dataGridViewRow.Cells["amount"].Value = row["Amount"];
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error loading Cash Payments: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally
            {
                dbConnection.closeConnection();
            }
        }


    }
}
