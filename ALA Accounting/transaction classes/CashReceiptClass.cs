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
    internal class CashReceiptClass
    {
        Connection dbConnection;

        public int CashReceiptID { get; set; } // This will be auto-generated in the database
        public int AccountID { get; set; } // The ID of the account to which Receipt is made
        public string AccountName { get; set; } // The ID of the account to which Receipt is made
        public int CashAccountID { get; set; } // The ID of the cash account
        public DateTime ReceiptDate { get; set; } // The date of the Receipt
        public decimal Amount { get; set; } // The Receipt amount
        public string Description { get; set; } // Optional description of the Receipt
        public int FinancialYearID { get; set; } // The financial year for the transaction
        public bool IsCancelled { get; set; } // Whether the Receipt is cancelled

        public CashReceiptClass()
        {
            dbConnection = new Connection();
        }

        public bool SaveCashReceipt(CashReceiptClass Receipt, List<Transaction> transactions)
        {
            SqlTransaction sqlTransaction = null;

            try
            {
                dbConnection.openConnection();

                // Start a transaction
                sqlTransaction = dbConnection.connection.BeginTransaction();

                // Insert into CashReceipt and get the CashReceiptID
                string insertReceiptQuery = @"
            INSERT INTO CashReceipt (AccountID, AccountName, CashAccountID, ReceiptDate, Amount, Description, FinancialYearID, IsCancelled)
            VALUES (@AccountID, @AccountName, @CashAccountID, @ReceiptDate, @Amount, @Description, @FinancialYearID, @IsCancelled);
            SELECT SCOPE_IDENTITY();"
                ;

                int CashReceiptID;
                using (SqlCommand ReceiptCommand = new SqlCommand(insertReceiptQuery, dbConnection.connection, sqlTransaction))
                {
                    ReceiptCommand.Parameters.AddWithValue("@AccountID", Receipt.AccountID);
                    ReceiptCommand.Parameters.AddWithValue("@AccountName", Receipt.AccountName);
                    ReceiptCommand.Parameters.AddWithValue("@CashAccountID", Receipt.CashAccountID);
                    ReceiptCommand.Parameters.AddWithValue("@ReceiptDate", Receipt.ReceiptDate);
                    ReceiptCommand.Parameters.AddWithValue("@Amount", Receipt.Amount);
                    ReceiptCommand.Parameters.AddWithValue("@Description", Receipt.Description ?? (object)DBNull.Value);
                    ReceiptCommand.Parameters.AddWithValue("@FinancialYearID", Receipt.FinancialYearID);
                    ReceiptCommand.Parameters.AddWithValue("@IsCancelled", Receipt.IsCancelled);

                    CashReceiptID = Convert.ToInt32(ReceiptCommand.ExecuteScalar());
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
                        transactionCommand.Parameters.AddWithValue("@SourceID", CashReceiptID); // Link to the CashReceipt
                        transactionCommand.Parameters.AddWithValue("@SourceTable", "CashReceipt");
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
                MessageBox.Show("Error saving cash Receipt: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);

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

        public bool UpdateCashReceipt(CashReceiptClass Receipt, List<Transaction> transactions)
        {
            SqlTransaction sqlTransaction = null;

            try
            {
                dbConnection.openConnection();

                // Start a transaction
                sqlTransaction = dbConnection.connection.BeginTransaction();

                // Update the existing CashReceipt
                string updateReceiptQuery = @"
        UPDATE CashReceipt
        SET AccountID = @AccountID,
            AccountName=@AccountName,
            CashAccountID = @CashAccountID,
            ReceiptDate = @ReceiptDate,
            Amount = @Amount,
            Description = @Description,
            FinancialYearID = @FinancialYearID,
            IsCancelled = @IsCancelled
        WHERE CashReceiptID = @CashReceiptID;";

                using (SqlCommand ReceiptCommand = new SqlCommand(updateReceiptQuery, dbConnection.connection, sqlTransaction))
                {
                    ReceiptCommand.Parameters.AddWithValue("@AccountID", Receipt.AccountID);
                    ReceiptCommand.Parameters.AddWithValue("@AccountName", Receipt.AccountName);
                    ReceiptCommand.Parameters.AddWithValue("@CashAccountID", Receipt.CashAccountID);
                    ReceiptCommand.Parameters.AddWithValue("@ReceiptDate", Receipt.ReceiptDate);
                    ReceiptCommand.Parameters.AddWithValue("@Amount", Receipt.Amount);
                    ReceiptCommand.Parameters.AddWithValue("@Description", Receipt.Description ?? (object)DBNull.Value);
                    ReceiptCommand.Parameters.AddWithValue("@FinancialYearID", Receipt.FinancialYearID);
                    ReceiptCommand.Parameters.AddWithValue("@IsCancelled", Receipt.IsCancelled);
                    ReceiptCommand.Parameters.AddWithValue("@CashReceiptID", Receipt.CashReceiptID);

                    ReceiptCommand.ExecuteNonQuery();
                }

                // Delete existing transactions related to the CashReceiptID
                string deleteTransactionQuery = "DELETE FROM Transactions WHERE SourceID = @SourceID AND SourceTable = 'CashReceipt';";
                using (SqlCommand deleteCommand = new SqlCommand(deleteTransactionQuery, dbConnection.connection, sqlTransaction))
                {
                    deleteCommand.Parameters.AddWithValue("@SourceID", Receipt.CashReceiptID);
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
                        transactionCommand.Parameters.AddWithValue("@SourceID", Receipt.CashReceiptID); // Link to the CashReceipt
                        transactionCommand.Parameters.AddWithValue("@SourceTable", "CashReceipt");
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
                MessageBox.Show("Error updating cash Receipt: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);

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

        public bool CashReceiptExists(int CashReceiptID)
        {
            try
            {
                dbConnection.openConnection();

                string query = "SELECT COUNT(1) FROM CashReceipt WHERE CashReceiptID = @CashReceiptID";

                using (SqlCommand command = new SqlCommand(query, dbConnection.connection))
                {
                    command.Parameters.AddWithValue("@CashReceiptID", CashReceiptID);
                    int count = (int)command.ExecuteScalar();
                    return count > 0;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error checking if Cash Receipt exists: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }
            finally
            {
                dbConnection.closeConnection();
            }
        }

        public int GetNextAvailableCashReceiptID()
        {
            try
            {
                dbConnection.openConnection();

                string query = "SELECT ISNULL(MAX(CashReceiptID), 0) + 1 FROM CashReceipt";

                using (SqlCommand command = new SqlCommand(query, dbConnection.connection))
                {
                    return (int)command.ExecuteScalar();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error getting next available Cash Receipt ID: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return 1;
            }
            finally
            {
                dbConnection.closeConnection();
            }
        }

        public void DeleteCashReceiptById(int CashReceiptID)
        {

            try
            {
                // Confirm deletion with the user
                var confirmResult = MessageBox.Show("Are you sure you want to delete this cash Receipt and all its associated transactions?",
                                                    "Confirm Deletion",
                                                    MessageBoxButtons.YesNo,
                                                    MessageBoxIcon.Warning);

                if (confirmResult != DialogResult.Yes)
                {
                    return; // Exit if the user does not confirm the deletion
                }

                // Open a connection to the database
                dbConnection.openConnection();

                // Start a transaction to ensure both the cash Receipt and its related transactions are deleted
                using (SqlTransaction transaction = dbConnection.connection.BeginTransaction())
                {
                    // Delete associated transactions from the Transactions table
                    string deleteTransactionQuery = @"
            DELETE FROM Transactions 
            WHERE SourceID = @CashReceiptID 
            AND SourceTable = 'CashReceipt'";

                    using (SqlCommand deleteTransactionCommand = new SqlCommand(deleteTransactionQuery, dbConnection.connection, transaction))
                    {
                        deleteTransactionCommand.Parameters.AddWithValue("@CashReceiptID", CashReceiptID);
                        deleteTransactionCommand.ExecuteNonQuery(); // Execute the command to delete the related transactions
                    }

                    // Delete the cash Receipt itself from the CashReceipt table
                    string deleteCashReceiptQuery = @"
            DELETE FROM CashReceipt 
            WHERE CashReceiptID = @CashReceiptID";

                    using (SqlCommand deleteCashReceiptCommand = new SqlCommand(deleteCashReceiptQuery, dbConnection.connection, transaction))
                    {
                        deleteCashReceiptCommand.Parameters.AddWithValue("@CashReceiptID", CashReceiptID);
                        deleteCashReceiptCommand.ExecuteNonQuery(); // Execute the command to delete the cash Receipt
                    }

                    // Commit the transaction to ensure that both deletions are applied
                    transaction.Commit();
                }

                MessageBox.Show("Cash Receipt and associated transactions deleted successfully.", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);

            }
            catch (Exception ex)
            {
                MessageBox.Show("Error deleting cash Receipt: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally
            {
                // Ensure connection is closed
                dbConnection.closeConnection();
            }
        }

        public void LoadCashReceipts(DataGridView dataGridView, int financialYearId, DateTime date)
        {
            try
            {
                dbConnection.openConnection();

                string query = "SELECT CashReceiptID, AccountID, AccountName, ReceiptDate, CashAccountID, Description, Amount " +
                       "FROM CashReceipt " +
                       "WHERE FinancialYearID = @FinancialYearID  AND ReceiptDate=@ReceiptDate " +
                       "ORDER BY CashReceiptID DESC";

                using (SqlCommand command = new SqlCommand(query, dbConnection.connection))
                {
                    command.Parameters.AddWithValue("@FinancialYearID", financialYearId);
                    command.Parameters.AddWithValue("@ReceiptDate", date);

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

                            dataGridViewRow.Cells["ReceiptId"].Value = row["CashReceiptID"];
                            dataGridViewRow.Cells["date"].Value = row["ReceiptDate"];
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
                MessageBox.Show("Error loading Cash Receipts: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally
            {
                dbConnection.closeConnection();
            }
        }


    }
}
