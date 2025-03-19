using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ALA_Accounting.transaction_classes
{
    internal class PurchaseInvoice
    {

        Connection dbConnection;

        public int PurchaseInvoiceID { get; set; }
        public int AccountID { get; set; }
        public string AccountName { get; set; }
        public DateTime InvoiceDate { get; set; }
        public int IncomeAccountID { get; set; }
        public decimal GrossTotal { get; set; }
        public decimal AdditionalDiscount { get; set; }
        public decimal CarriageAndFreight { get; set; }
        public decimal NetTotal { get; set; }
        public decimal AmountPaid { get; set; }
        public bool IsCancelled { get; set; }
        public int FinancialYearID { get; set; }
        public string EmployeeReference { get; set; }
        public string Address { get; set; }
        public string Remarks { get; set; }
        public decimal Balance { get; set; }


        public PurchaseInvoice()
        {
            dbConnection = new Connection();
        }

        public bool PurchaseInvoiceExists(int purchaseInvoiceID)
        {
            try
            {
                dbConnection.openConnection();

                string query = "SELECT COUNT(1) FROM PurchaseInvoice WHERE PurchaseInvoiceID = @PurchaseInvoiceID";

                using (SqlCommand command = new SqlCommand(query, dbConnection.connection))
                {
                    command.Parameters.AddWithValue("@PurchaseInvoiceID", purchaseInvoiceID);
                    int count = (int)command.ExecuteScalar();
                    return count > 0;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error checking if purchase invoice exists: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }
            finally
            {
                dbConnection.closeConnection();
            }
        }

        public int GetNextAvailablePurchaseInvoiceID()
        {
            try
            {
                dbConnection.openConnection();

                string query = "SELECT ISNULL(MAX(PurchaseInvoiceID), 0) + 1 FROM PurchaseInvoice";

                using (SqlCommand command = new SqlCommand(query, dbConnection.connection))
                {
                    return (int)command.ExecuteScalar();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error getting next available purchase Invoice ID: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return 1;
            }
            finally
            {
                dbConnection.closeConnection();
            }
        }

        public bool SavePurchaseInvoice(PurchaseInvoice invoice, List<PurchaseInvoiceItems> items, List<Transaction> transactions, List<InventoryTransaction> inventoryTransactions)
        {
            SqlTransaction sqlTransaction = null;

            try
            {
                dbConnection.openConnection();

                // Start a transaction
                sqlTransaction = dbConnection.connection.BeginTransaction();

                // Insert PurchaseInvoice and get the generated ID
                string insertInvoiceQuery = @"
            INSERT INTO PurchaseInvoice (AccountID, AccountName, InvoiceDate, ExpenseAccountID, GrossTotal, AdditionalDiscount, CarriageAndFreight, NetTotal, AmountPaid, Balance, IsCancelled, FinancialYearID, employeeReference, Address, remarks)
            VALUES (@AccountID, @AccountName, @InvoiceDate, @ExpenseAccountID, @GrossTotal, @AdditionalDiscount, @CarriageAndFreight, @NetTotal, @AmountPaid, @Balance, @IsCancelled, @FinancialYearID, @employeeReference, @Address, @remarks);
            SELECT SCOPE_IDENTITY();";

                using (SqlCommand invoiceCommand = new SqlCommand(insertInvoiceQuery, dbConnection.connection, sqlTransaction))
                {
                    invoiceCommand.Parameters.AddWithValue("@AccountID", invoice.AccountID);
                    invoiceCommand.Parameters.AddWithValue("@AccountName", invoice.AccountName);
                    invoiceCommand.Parameters.AddWithValue("@InvoiceDate", invoice.InvoiceDate);
                    invoiceCommand.Parameters.AddWithValue("@ExpenseAccountID", invoice.IncomeAccountID);
                    invoiceCommand.Parameters.AddWithValue("@GrossTotal", invoice.GrossTotal);
                    invoiceCommand.Parameters.AddWithValue("@AdditionalDiscount", invoice.AdditionalDiscount);
                    invoiceCommand.Parameters.AddWithValue("@CarriageAndFreight", invoice.CarriageAndFreight);
                    invoiceCommand.Parameters.AddWithValue("@NetTotal", invoice.NetTotal);
                    invoiceCommand.Parameters.AddWithValue("@AmountPaid", invoice.AmountPaid);
                    invoiceCommand.Parameters.AddWithValue("@Balance", invoice.Balance);
                    invoiceCommand.Parameters.AddWithValue("@IsCancelled", invoice.IsCancelled);
                    invoiceCommand.Parameters.AddWithValue("@FinancialYearID", invoice.FinancialYearID);
                    invoiceCommand.Parameters.AddWithValue("@employeeReference", invoice.EmployeeReference);
                    invoiceCommand.Parameters.AddWithValue("@Address", invoice.Address);
                    invoiceCommand.Parameters.AddWithValue("@remarks", invoice.Remarks);

                    // Retrieve the generated ID
                    invoice.PurchaseInvoiceID = Convert.ToInt32(invoiceCommand.ExecuteScalar());
                }

                // Insert PurchaseInvoiceItems
                string insertItemsQuery = @"
            INSERT INTO PurchaseInvoiceItems (PurchaseInvoiceID, ItemID, ItemDescription, Quantity, Unit, Rate, GrossAmount, Discount, NetAmount)
            VALUES (@PurchaseInvoiceID, @ItemID, @ItemDescription, @Quantity, @Unit, @Rate, @GrossAmount, @Discount, @NetAmount);";

                foreach (var item in items)
                {
                    using (SqlCommand itemCommand = new SqlCommand(insertItemsQuery, dbConnection.connection, sqlTransaction))
                    {
                        itemCommand.Parameters.AddWithValue("@PurchaseInvoiceID", invoice.PurchaseInvoiceID);
                        itemCommand.Parameters.AddWithValue("@ItemID", item.ItemID);
                        itemCommand.Parameters.AddWithValue("@ItemDescription", item.ItemDiscription);
                        itemCommand.Parameters.AddWithValue("@Quantity", item.Quantity);
                        itemCommand.Parameters.AddWithValue("@Unit", item.Unit);
                        itemCommand.Parameters.AddWithValue("@Rate", item.Rate);
                        itemCommand.Parameters.AddWithValue("@GrossAmount", item.GrossAmount);
                        itemCommand.Parameters.AddWithValue("@Discount", item.Discount);
                        itemCommand.Parameters.AddWithValue("@NetAmount", item.NetAmount);
                        itemCommand.ExecuteNonQuery();
                    }
                }

                // Insert Transactions
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
                        transactionCommand.Parameters.AddWithValue("@Description", transaction.Description);
                        transactionCommand.Parameters.AddWithValue("@FinancialYearID", transaction.FinancialYearID);
                        transactionCommand.Parameters.AddWithValue("@SourceID", invoice.PurchaseInvoiceID);
                        transactionCommand.Parameters.AddWithValue("@SourceTable", "PurchaseInvoice");
                        transactionCommand.Parameters.AddWithValue("@IsCancelled", transaction.IsCancelled);
                        transactionCommand.ExecuteNonQuery();
                    }
                }

                // Insert InventoryTransactions
                string insertInventoryTransactionQuery = @"
            INSERT INTO InventoryTransaction (ItemID, TransactionType, Quantity, Unit, Rate, PartyName, SourceTable, SourceId, TransactionDate)
            VALUES (@ItemID, @TransactionType, @Quantity, @Unit, @Rate, @PartyName, @SourceTable, @SourceId, @TransactionDate);";

                foreach (var inventoryTransaction in inventoryTransactions)
                {
                    using (SqlCommand inventoryCommand = new SqlCommand(insertInventoryTransactionQuery, dbConnection.connection, sqlTransaction))
                    {
                        inventoryCommand.Parameters.AddWithValue("@ItemID", inventoryTransaction.ItemID);
                        inventoryCommand.Parameters.AddWithValue("@TransactionType", "Purchase");
                        inventoryCommand.Parameters.AddWithValue("@Quantity", inventoryTransaction.Quantity);
                        inventoryCommand.Parameters.AddWithValue("@Unit", inventoryTransaction.Unit);
                        inventoryCommand.Parameters.AddWithValue("@Rate", inventoryTransaction.Rate);
                        inventoryCommand.Parameters.AddWithValue("@PartyName", inventoryTransaction.partyName);
                        inventoryCommand.Parameters.AddWithValue("@SourceTable", "PurchaseInvoice");
                        inventoryCommand.Parameters.AddWithValue("@SourceId", invoice.PurchaseInvoiceID);
                        inventoryCommand.Parameters.AddWithValue("@TransactionDate", inventoryTransaction.TransactionDate);
                        inventoryCommand.ExecuteNonQuery();
                    }
                }

                // Commit the transaction
                sqlTransaction.Commit();
                return true;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error saving purchase invoice: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);

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


        public bool UpdatePurchaseInvoice(PurchaseInvoice invoice, List<PurchaseInvoiceItems> items, List<Transaction> transactions, List<InventoryTransaction> inventoryTransactions)
        {
            SqlTransaction sqlTransaction = null;

            try
            {
                dbConnection.openConnection();

                // Start a transaction
                sqlTransaction = dbConnection.connection.BeginTransaction();

                // Update SalesInvoice
                string updateInvoiceQuery = @"
                UPDATE PurchaseInvoice
                SET AccountID = @AccountID,
                    AccountName = @AccountName,
                    InvoiceDate = @InvoiceDate, 
                    ExpenseAccountID = @ExpenseAccountID, 
                    GrossTotal = @GrossTotal, 
                    AdditionalDiscount = @AdditionalDiscount, 
                    CarriageAndFreight = @CarriageAndFreight, 
                    NetTotal = @NetTotal, 
                    AmountPaid = @AmountPaid, 
                    Balance = @Balance, 
                    IsCancelled = @IsCancelled, 
                    FinancialYearID = @FinancialYearID, 
                    employeeReference = @employeeReference, 
                    Address = @Address, 
                    remarks = @remarks
                WHERE PurchaseInvoiceID = @PurchaseInvoiceID;";

                using (SqlCommand invoiceCommand = new SqlCommand(updateInvoiceQuery, dbConnection.connection, sqlTransaction))
                {
                    invoiceCommand.Parameters.AddWithValue("@PurchaseInvoiceID", invoice.PurchaseInvoiceID);
                    invoiceCommand.Parameters.AddWithValue("@AccountID", invoice.AccountID);
                    invoiceCommand.Parameters.AddWithValue("@AccountName", invoice.AccountName);
                    invoiceCommand.Parameters.AddWithValue("@InvoiceDate", invoice.InvoiceDate);
                    invoiceCommand.Parameters.AddWithValue("@ExpenseAccountID", invoice.IncomeAccountID);
                    invoiceCommand.Parameters.AddWithValue("@GrossTotal", invoice.GrossTotal);
                    invoiceCommand.Parameters.AddWithValue("@AdditionalDiscount", invoice.AdditionalDiscount);
                    invoiceCommand.Parameters.AddWithValue("@CarriageAndFreight", invoice.CarriageAndFreight);
                    invoiceCommand.Parameters.AddWithValue("@NetTotal", invoice.NetTotal);
                    invoiceCommand.Parameters.AddWithValue("@AmountPaid", invoice.AmountPaid);
                    invoiceCommand.Parameters.AddWithValue("@Balance", invoice.Balance);
                    invoiceCommand.Parameters.AddWithValue("@IsCancelled", invoice.IsCancelled);
                    invoiceCommand.Parameters.AddWithValue("@FinancialYearID", invoice.FinancialYearID);
                    invoiceCommand.Parameters.AddWithValue("@employeeReference", invoice.EmployeeReference);
                    invoiceCommand.Parameters.AddWithValue("@Address", invoice.Address);
                    invoiceCommand.Parameters.AddWithValue("@remarks", invoice.Remarks);

                    invoiceCommand.ExecuteNonQuery();
                }

                // Delete existing SalesInvoiceItems for this SalesInvoiceID
                string deleteItemsQuery = "DELETE FROM PurchaseInvoiceItems WHERE PurchaseInvoiceID = @PurchaseInvoiceID;";
                using (SqlCommand deleteItemsCommand = new SqlCommand(deleteItemsQuery, dbConnection.connection, sqlTransaction))
                {
                    deleteItemsCommand.Parameters.AddWithValue("@PurchaseInvoiceID", invoice.PurchaseInvoiceID);
                    deleteItemsCommand.ExecuteNonQuery();
                }

                // Insert updated SalesInvoiceItems
                string insertItemsQuery = @"
        INSERT INTO PurchaseInvoiceItems (PurchaseInvoiceID, ItemID, ItemDescription, Quantity, Unit, Rate, GrossAmount, Discount, NetAmount)
        VALUES (@PurchaseInvoiceID, @ItemID, @ItemDescription, @Quantity, @Unit, @Rate, @GrossAmount, @Discount, @NetAmount);";

                foreach (var item in items)
                {
                    using (SqlCommand itemCommand = new SqlCommand(insertItemsQuery, dbConnection.connection, sqlTransaction))
                    {
                        itemCommand.Parameters.AddWithValue("@PurchaseInvoiceID", invoice.PurchaseInvoiceID);
                        itemCommand.Parameters.AddWithValue("@ItemID", item.ItemID);
                        itemCommand.Parameters.AddWithValue("@ItemDescription", item.ItemDiscription);
                        itemCommand.Parameters.AddWithValue("@Quantity", item.Quantity);
                        itemCommand.Parameters.AddWithValue("@Unit", item.Unit);
                        itemCommand.Parameters.AddWithValue("@Rate", item.Rate);
                        itemCommand.Parameters.AddWithValue("@GrossAmount", item.GrossAmount);
                        itemCommand.Parameters.AddWithValue("@Discount", item.Discount);
                        itemCommand.Parameters.AddWithValue("@NetAmount", item.NetAmount);
                        itemCommand.ExecuteNonQuery();
                    }
                }

                // Delete existing Transactions for this SalesInvoiceID
                string deleteTransactionsQuery = "DELETE FROM Transactions WHERE SourceID = @SourceID AND SourceTable = 'PUrchaseInvoice';";
                using (SqlCommand deleteTransactionsCommand = new SqlCommand(deleteTransactionsQuery, dbConnection.connection, sqlTransaction))
                {
                    deleteTransactionsCommand.Parameters.AddWithValue("@SourceID", invoice.PurchaseInvoiceID);
                    deleteTransactionsCommand.ExecuteNonQuery();
                }

                // Insert updated Transactions
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
                        transactionCommand.Parameters.AddWithValue("@Description", transaction.Description);
                        transactionCommand.Parameters.AddWithValue("@FinancialYearID", transaction.FinancialYearID);
                        transactionCommand.Parameters.AddWithValue("@SourceID", invoice.PurchaseInvoiceID);
                        transactionCommand.Parameters.AddWithValue("@SourceTable", "PurchaseInvoice");
                        transactionCommand.Parameters.AddWithValue("@IsCancelled", transaction.IsCancelled);
                        transactionCommand.ExecuteNonQuery();
                    }
                }

                // Delete existing InventoryTransactions for this SalesInvoiceID
                string deleteInventoryTransactionsQuery = "DELETE FROM InventoryTransaction WHERE SourceId = @SourceId AND SourceTable = 'PurchaseInvoice';";
                using (SqlCommand deleteInventoryTransactionsCommand = new SqlCommand(deleteInventoryTransactionsQuery, dbConnection.connection, sqlTransaction))
                {
                    deleteInventoryTransactionsCommand.Parameters.AddWithValue("@SourceId", invoice.PurchaseInvoiceID);
                    deleteInventoryTransactionsCommand.ExecuteNonQuery();
                }

                // Insert updated InventoryTransactions
                string insertInventoryTransactionQuery = @"
        INSERT INTO InventoryTransaction (ItemID, TransactionType, Quantity, Unit, Rate, PartyName, SourceTable, SourceId, TransactionDate)
        VALUES (@ItemID, @TransactionType, @Quantity, @Unit, @Rate, @PartyName, @SourceTable, @SourceId, @TransactionDate);";

                foreach (var inventoryTransaction in inventoryTransactions)
                {
                    using (SqlCommand inventoryCommand = new SqlCommand(insertInventoryTransactionQuery, dbConnection.connection, sqlTransaction))
                    {
                        inventoryCommand.Parameters.AddWithValue("@ItemID", inventoryTransaction.ItemID);
                        inventoryCommand.Parameters.AddWithValue("@TransactionType", "Purchase");
                        inventoryCommand.Parameters.AddWithValue("@Quantity", inventoryTransaction.Quantity);
                        inventoryCommand.Parameters.AddWithValue("@Unit", inventoryTransaction.Unit);
                        inventoryCommand.Parameters.AddWithValue("@Rate", inventoryTransaction.Rate);
                        inventoryCommand.Parameters.AddWithValue("@PartyName", inventoryTransaction.partyName);
                        inventoryCommand.Parameters.AddWithValue("@SourceTable", "PurchaseInvoice");
                        inventoryCommand.Parameters.AddWithValue("@SourceId", invoice.PurchaseInvoiceID);
                        inventoryCommand.Parameters.AddWithValue("@TransactionDate", inventoryTransaction.TransactionDate);
                        inventoryCommand.ExecuteNonQuery();
                    }
                }

                // Commit the transaction
                sqlTransaction.Commit();
                return true;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error updating Purchase invoice: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);

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

        public bool DeletePurchaseInvoice(int salesInvoiceID)
        {
            // Ask for confirmation before deletion
            DialogResult confirmationResult = MessageBox.Show("Are you sure you want to delete this sales invoice?",
                                                              "Confirm Deletion",
                                                              MessageBoxButtons.YesNo,
                                                              MessageBoxIcon.Warning);
            if (confirmationResult != DialogResult.Yes)
            {
                // If the user chooses No, return false and exit the function
                return false;
            }

            SqlTransaction sqlTransaction = null;

            try
            {
                dbConnection.openConnection();

                // Start a transaction
                sqlTransaction = dbConnection.connection.BeginTransaction();

                

                // Delete SalesInvoiceItems
                string deleteItemsQuery = @"
                    DELETE FROM PurchaseInvoiceItems
                    WHERE PurchaseInvoiceID = @PurchaseInvoiceID;";

                using (SqlCommand itemCommand = new SqlCommand(deleteItemsQuery, dbConnection.connection, sqlTransaction))
                {
                    itemCommand.Parameters.AddWithValue("@PurchaseInvoiceID", salesInvoiceID);
                    itemCommand.ExecuteNonQuery();
                }

                // Delete Transactions
                string deleteTransactionQuery = @"
                    DELETE FROM Transactions
                    WHERE SourceID = @PurchaseInvoiceID AND SourceTable = 'PurchaseInvoice';";

                using (SqlCommand transactionCommand = new SqlCommand(deleteTransactionQuery, dbConnection.connection, sqlTransaction))
                {
                    transactionCommand.Parameters.AddWithValue("@PurchaseInvoiceID", PurchaseInvoiceID);
                    transactionCommand.ExecuteNonQuery();
                }

                // Delete InventoryTransactions
                string deleteInventoryTransactionQuery = @"
                    DELETE FROM InventoryTransaction
                    WHERE SourceId = @SalesInvoiceID AND SourceTable = 'SalesInvoice';";

                using (SqlCommand inventoryCommand = new SqlCommand(deleteInventoryTransactionQuery, dbConnection.connection, sqlTransaction))
                {
                    inventoryCommand.Parameters.AddWithValue("@SalesInvoiceID", salesInvoiceID);
                    inventoryCommand.ExecuteNonQuery();
                }


                // Delete SalesInvoice
                string deleteInvoiceQuery = @"
                    DELETE FROM PurchaseInvoice
                    WHERE PurchaseInvoiceID = @PurchaseInvoiceID;";

                using (SqlCommand invoiceCommand = new SqlCommand(deleteInvoiceQuery, dbConnection.connection, sqlTransaction))
                {
                    invoiceCommand.Parameters.AddWithValue("@PurchaseInvoiceID", salesInvoiceID);
                    int rowsAffected = invoiceCommand.ExecuteNonQuery();
                    if (rowsAffected == 0)
                    {
                        // If no rows are affected, the SalesInvoiceID might not exist.
                        MessageBox.Show("Purchase invoice not found or already deleted.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        sqlTransaction.Rollback();
                        return false;
                    }
                }

                // Commit the transaction
                sqlTransaction.Commit();
                return true;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error deleting purchase invoice: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);

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
    }
}
