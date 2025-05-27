using System;
using System.Collections.Generic;
using System.Data.Common;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Guna.UI2.WinForms;

namespace ALA_Accounting.transaction_classes
{
    internal class SalesInvoice
    {
        Connection dbConnection;

        public int SalesInvoiceID {  get; set; }
        public int AccountID {  get; set; }
        public string AccountName {  get; set; }
        public DateTime InvoiceDate {  get; set; }
        public int IncomeAccountID {  get; set; }
        public decimal GrossTotal {  get; set; }
        public decimal AdditionalDiscount {  get; set; }
        public decimal CarriageAndFreight {  get; set; }
        public decimal NetTotal {  get; set; }
        public decimal AmountReceived {  get; set; }
        public bool IsCancelled {  get; set; }
        public int FinancialYearID {  get; set; }
        public string EmployeeReference {  get; set; }
        public string Address {  get; set; }
        public string Remarks {  get; set; }
        public decimal Balance {  get; set; }


        public SalesInvoice()
        {
            dbConnection = new Connection();
        }

        public bool SalesInvoiceExists(int salesInvoiceID)
        {
            try
            {
                dbConnection.openConnection();

                string query = "SELECT COUNT(1) FROM SalesInvoice WHERE SalesInvoiceID = @SalesInvoiceID";

                using (SqlCommand command = new SqlCommand(query, dbConnection.connection))
                {
                    command.Parameters.AddWithValue("@SalesInvoiceID", salesInvoiceID);
                    int count = (int)command.ExecuteScalar();
                    return count > 0;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error checking if sales invoice exists: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }
            finally
            {
                dbConnection.closeConnection();
            }
        }

        public int GetNextAvailableSalesInvoiceID()
        {
            try
            {
                dbConnection.openConnection();

                string query = "SELECT ISNULL(MAX(SalesInvoiceID), 0) + 1 FROM SalesInvoice";

                using (SqlCommand command = new SqlCommand(query, dbConnection.connection))
                {
                    return (int)command.ExecuteScalar();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error getting next available Sales Invoice ID: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return 1;
            }
            finally
            {
                dbConnection.closeConnection();
            }
        }

        public bool SaveSalesInvoice(SalesInvoice invoice, List<SalesInvoiceItem> items, List<Transaction> transactions, List<InventoryTransaction> inventoryTransactions)
        {
            SqlTransaction sqlTransaction = null;

            try
            {
                dbConnection.openConnection();

                // Start a transaction
                sqlTransaction = dbConnection.connection.BeginTransaction();

                // Insert SalesInvoice and get the SalesInvoiceID
                string insertInvoiceQuery = @"
                    INSERT INTO SalesInvoice (SalesInvoiceID ,AccountID, AccountName, InvoiceDate, IncomeAccountID, GrossTotal, AdditionalDiscount, CarriageAndFreight, NetTotal, AmountReceived, Balance, IsCancelled, FinancialYearID, employeeReference, Address, remarks)
                    VALUES (@SalesInvoiceID ,@AccountID, @AccountName, @InvoiceDate, @IncomeAccountID, @GrossTotal, @AdditionalDiscount, @CarriageAndFreight, @NetTotal, @AmountReceived, @Balance, @IsCancelled, @FinancialYearID, @employeeReference, @Address, @remarks);
                    SELECT SCOPE_IDENTITY();";

                using (SqlCommand invoiceCommand = new SqlCommand(insertInvoiceQuery, dbConnection.connection, sqlTransaction))
                {
                    invoiceCommand.Parameters.AddWithValue("@SalesInvoiceID", invoice.SalesInvoiceID);
                    invoiceCommand.Parameters.AddWithValue("@AccountID", invoice.AccountID);
                    invoiceCommand.Parameters.AddWithValue("@AccountName", invoice.AccountName);
                    invoiceCommand.Parameters.AddWithValue("@InvoiceDate", invoice.InvoiceDate);
                    invoiceCommand.Parameters.AddWithValue("@IncomeAccountID", invoice.IncomeAccountID);
                    invoiceCommand.Parameters.AddWithValue("@GrossTotal", invoice.GrossTotal);
                    invoiceCommand.Parameters.AddWithValue("@AdditionalDiscount", invoice.AdditionalDiscount);
                    invoiceCommand.Parameters.AddWithValue("@CarriageAndFreight", invoice.CarriageAndFreight);
                    invoiceCommand.Parameters.AddWithValue("@NetTotal", invoice.NetTotal);
                    invoiceCommand.Parameters.AddWithValue("@AmountReceived", invoice.AmountReceived);
                    invoiceCommand.Parameters.AddWithValue("@Balance", invoice.Balance);
                    invoiceCommand.Parameters.AddWithValue("@IsCancelled", invoice.IsCancelled);
                    invoiceCommand.Parameters.AddWithValue("@FinancialYearID", invoice.FinancialYearID);
                    invoiceCommand.Parameters.AddWithValue("@employeeReference", invoice.EmployeeReference);
                    invoiceCommand.Parameters.AddWithValue("@Address", invoice.Address);
                    invoiceCommand.Parameters.AddWithValue("@remarks", invoice.Remarks);

                    invoiceCommand.ExecuteNonQuery();


                    // Insert SalesInvoiceItems
                    string insertItemsQuery = @"
                        INSERT INTO SalesInvoiceItems (SalesInvoiceID, ItemID, ItemDescription, Quantity, Unit, Rate, GrossAmount, Discount, NetAmount)
                        VALUES (@SalesInvoiceID, @ItemID, @ItemDescription, @Quantity, @Unit, @Rate, @GrossAmount, @Discount, @NetAmount);";

                    foreach (var item in items)
                    {
                        using (SqlCommand itemCommand = new SqlCommand(insertItemsQuery, dbConnection.connection, sqlTransaction))
                        {
                            itemCommand.Parameters.AddWithValue("@SalesInvoiceID", invoice.SalesInvoiceID);
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
                            transactionCommand.Parameters.AddWithValue("@SourceID", invoice.SalesInvoiceID); // Link to the sales invoice
                            transactionCommand.Parameters.AddWithValue("@SourceTable", "SalesInvoice");
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
                            inventoryCommand.Parameters.AddWithValue("@TransactionType", "Sale");
                            inventoryCommand.Parameters.AddWithValue("@Quantity", inventoryTransaction.Quantity);
                            inventoryCommand.Parameters.AddWithValue("@Unit", inventoryTransaction.Unit);
                            inventoryCommand.Parameters.AddWithValue("@Rate", inventoryTransaction.Rate);
                            inventoryCommand.Parameters.AddWithValue("@PartyName", inventoryTransaction.partyName);
                            inventoryCommand.Parameters.AddWithValue("@SourceTable", "SalesInvoice");
                            inventoryCommand.Parameters.AddWithValue("@SourceId", invoice.SalesInvoiceID);
                            inventoryCommand.Parameters.AddWithValue("@TransactionDate", inventoryTransaction.TransactionDate);
                            inventoryCommand.ExecuteNonQuery();
                        }
                    }

                    // Commit the transaction
                    sqlTransaction.Commit();
                    return true;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error saving sales invoice: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);

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

        public bool UpdateSalesInvoice(SalesInvoice invoice, List<SalesInvoiceItem> items, List<Transaction> transactions, List<InventoryTransaction> inventoryTransactions)
        {
            SqlTransaction sqlTransaction = null;

            try
            {
                dbConnection.openConnection();

                // Start a transaction
                sqlTransaction = dbConnection.connection.BeginTransaction();

                // Update SalesInvoice
                string updateInvoiceQuery = @"
                UPDATE SalesInvoice
                SET AccountID = @AccountID,
                    AccountName = @AccountName,
                    InvoiceDate = @InvoiceDate, 
                    IncomeAccountID = @IncomeAccountID, 
                    GrossTotal = @GrossTotal, 
                    AdditionalDiscount = @AdditionalDiscount, 
                    CarriageAndFreight = @CarriageAndFreight, 
                    NetTotal = @NetTotal, 
                    AmountReceived = @AmountReceived, 
                    Balance = @Balance, 
                    IsCancelled = @IsCancelled, 
                    FinancialYearID = @FinancialYearID, 
                    employeeReference = @employeeReference, 
                    Address = @Address, 
                    remarks = @remarks
                WHERE SalesInvoiceID = @SalesInvoiceID;";

                using (SqlCommand invoiceCommand = new SqlCommand(updateInvoiceQuery, dbConnection.connection, sqlTransaction))
                {
                    invoiceCommand.Parameters.AddWithValue("@SalesInvoiceID", invoice.SalesInvoiceID);
                    invoiceCommand.Parameters.AddWithValue("@AccountID", invoice.AccountID);
                    invoiceCommand.Parameters.AddWithValue("@AccountName", invoice.AccountName);
                    invoiceCommand.Parameters.AddWithValue("@InvoiceDate", invoice.InvoiceDate);
                    invoiceCommand.Parameters.AddWithValue("@IncomeAccountID", invoice.IncomeAccountID);
                    invoiceCommand.Parameters.AddWithValue("@GrossTotal", invoice.GrossTotal);
                    invoiceCommand.Parameters.AddWithValue("@AdditionalDiscount", invoice.AdditionalDiscount);
                    invoiceCommand.Parameters.AddWithValue("@CarriageAndFreight", invoice.CarriageAndFreight);
                    invoiceCommand.Parameters.AddWithValue("@NetTotal", invoice.NetTotal);
                    invoiceCommand.Parameters.AddWithValue("@AmountReceived", invoice.AmountReceived);
                    invoiceCommand.Parameters.AddWithValue("@Balance", invoice.Balance);
                    invoiceCommand.Parameters.AddWithValue("@IsCancelled", invoice.IsCancelled);
                    invoiceCommand.Parameters.AddWithValue("@FinancialYearID", invoice.FinancialYearID);
                    invoiceCommand.Parameters.AddWithValue("@employeeReference", invoice.EmployeeReference);
                    invoiceCommand.Parameters.AddWithValue("@Address", invoice.Address);
                    invoiceCommand.Parameters.AddWithValue("@remarks", invoice.Remarks);

                    invoiceCommand.ExecuteNonQuery();
                }

                // Delete existing SalesInvoiceItems for this SalesInvoiceID
                string deleteItemsQuery = "DELETE FROM SalesInvoiceItems WHERE SalesInvoiceID = @SalesInvoiceID;";
                using (SqlCommand deleteItemsCommand = new SqlCommand(deleteItemsQuery, dbConnection.connection, sqlTransaction))
                {
                    deleteItemsCommand.Parameters.AddWithValue("@SalesInvoiceID", invoice.SalesInvoiceID);
                    deleteItemsCommand.ExecuteNonQuery();
                }

                // Insert updated SalesInvoiceItems
                string insertItemsQuery = @"
        INSERT INTO SalesInvoiceItems (SalesInvoiceID, ItemID, ItemDescription, Quantity, Unit, Rate, GrossAmount, Discount, NetAmount)
        VALUES (@SalesInvoiceID, @ItemID, @ItemDescription, @Quantity, @Unit, @Rate, @GrossAmount, @Discount, @NetAmount);";

                foreach (var item in items)
                {
                    using (SqlCommand itemCommand = new SqlCommand(insertItemsQuery, dbConnection.connection, sqlTransaction))
                    {
                        itemCommand.Parameters.AddWithValue("@SalesInvoiceID", invoice.SalesInvoiceID);
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
                string deleteTransactionsQuery = "DELETE FROM Transactions WHERE SourceID = @SourceID AND SourceTable = 'SalesInvoice';";
                using (SqlCommand deleteTransactionsCommand = new SqlCommand(deleteTransactionsQuery, dbConnection.connection, sqlTransaction))
                {
                    deleteTransactionsCommand.Parameters.AddWithValue("@SourceID", invoice.SalesInvoiceID);
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
                        transactionCommand.Parameters.AddWithValue("@SourceID", invoice.SalesInvoiceID);
                        transactionCommand.Parameters.AddWithValue("@SourceTable", "SalesInvoice");
                        transactionCommand.Parameters.AddWithValue("@IsCancelled", transaction.IsCancelled);
                        transactionCommand.ExecuteNonQuery();
                    }
                }

                // Delete existing InventoryTransactions for this SalesInvoiceID
                string deleteInventoryTransactionsQuery = "DELETE FROM InventoryTransaction WHERE SourceId = @SourceId AND SourceTable = 'SalesInvoice';";
                using (SqlCommand deleteInventoryTransactionsCommand = new SqlCommand(deleteInventoryTransactionsQuery, dbConnection.connection, sqlTransaction))
                {
                    deleteInventoryTransactionsCommand.Parameters.AddWithValue("@SourceId", invoice.SalesInvoiceID);
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
                        inventoryCommand.Parameters.AddWithValue("@TransactionType", "Sale");
                        inventoryCommand.Parameters.AddWithValue("@Quantity", inventoryTransaction.Quantity);
                        inventoryCommand.Parameters.AddWithValue("@Unit", inventoryTransaction.Unit);
                        inventoryCommand.Parameters.AddWithValue("@Rate", inventoryTransaction.Rate);
                        inventoryCommand.Parameters.AddWithValue("@PartyName", inventoryTransaction.partyName);
                        inventoryCommand.Parameters.AddWithValue("@SourceTable", "SalesInvoice");
                        inventoryCommand.Parameters.AddWithValue("@SourceId", invoice.SalesInvoiceID);
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
                MessageBox.Show("Error updating sales invoice: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);

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

        public bool DeleteSalesInvoice(int salesInvoiceID)
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

                // Delete InventoryTransactions first (if any)
                string deleteInventoryTransactionQuery = @"
            DELETE FROM InventoryTransaction
            WHERE SourceId = @SalesInvoiceID AND SourceTable = 'SalesInvoice';";

                using (SqlCommand inventoryCommand = new SqlCommand(deleteInventoryTransactionQuery, dbConnection.connection, sqlTransaction))
                {
                    inventoryCommand.Parameters.AddWithValue("@SalesInvoiceID", salesInvoiceID);
                    inventoryCommand.ExecuteNonQuery();
                }

                // Delete SalesInvoiceItems next
                string deleteItemsQuery = @"
            DELETE FROM SalesInvoiceItems
            WHERE SalesInvoiceID = @SalesInvoiceID;";

                using (SqlCommand itemCommand = new SqlCommand(deleteItemsQuery, dbConnection.connection, sqlTransaction))
                {
                    itemCommand.Parameters.AddWithValue("@SalesInvoiceID", salesInvoiceID);
                    itemCommand.ExecuteNonQuery();
                }

                // Delete Transactions next
                string deleteTransactionQuery = @"
            DELETE FROM Transactions
            WHERE SourceID = @SalesInvoiceID AND SourceTable = 'SalesInvoice';";

                using (SqlCommand transactionCommand = new SqlCommand(deleteTransactionQuery, dbConnection.connection, sqlTransaction))
                {
                    transactionCommand.Parameters.AddWithValue("@SalesInvoiceID", salesInvoiceID);
                    transactionCommand.ExecuteNonQuery();
                }

                // Finally, delete the SalesInvoice
                string deleteInvoiceQuery = @"
            DELETE FROM SalesInvoice
            WHERE SalesInvoiceID = @SalesInvoiceID;";

                using (SqlCommand invoiceCommand = new SqlCommand(deleteInvoiceQuery, dbConnection.connection, sqlTransaction))
                {
                    invoiceCommand.Parameters.AddWithValue("@SalesInvoiceID", salesInvoiceID);
                    int rowsAffected = invoiceCommand.ExecuteNonQuery();

                    if (rowsAffected == 0)
                    {
                        // If no rows are affected, the SalesInvoiceID might not exist
                        MessageBox.Show("Sales invoice not found or already deleted.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
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
                MessageBox.Show("Error deleting sales invoice: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);

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

        public decimal GetAverageCost(string itemId, int financialYearId)
        {
            decimal totalCost = 0;
            decimal totalQuantity = 0;

            string query = @"
WITH ItemTransactions AS (
    -- Opening balance
    SELECT 
        Quantity,
        Quantity * Rate AS Cost
    FROM InventoryOpeningBalance
    WHERE ItemID = @ItemID
    AND FinancialYearID = @FinancialYearID
    
    UNION ALL
    
    -- Purchases
    SELECT 
        p.Quantity,
        p.Quantity * p.Rate AS Cost
    FROM InventoryTransaction p
    JOIN PurchaseInvoice pi ON p.SourceID = pi.PurchaseInvoiceID
    WHERE p.ItemID = @ItemID
    AND p.TransactionType = 'Purchase'
    AND pi.FinancialYearID = @FinancialYearID
)
SELECT 
    SUM(Cost) AS TotalCost,
    SUM(Quantity) AS TotalQuantity
FROM ItemTransactions;";

            dbConnection.openConnection();

            using (SqlCommand cmd = new SqlCommand(query, dbConnection.connection))
            {
                cmd.Parameters.AddWithValue("@ItemID", itemId);
                cmd.Parameters.AddWithValue("@FinancialYearID", financialYearId);

                using (SqlDataReader reader = cmd.ExecuteReader())
                {
                    if (reader.Read())
                    {
                        totalCost = reader.IsDBNull(0) ? 0 : reader.GetDecimal(0);
                        totalQuantity = reader.IsDBNull(1) ? 0 : reader.GetDecimal(1);
                    }
                }
            }

            dbConnection.closeConnection();

            return totalQuantity > 0 ? totalCost / totalQuantity : 0; // Avoid division by zero
        }

        public decimal GetItemQuantity(int financialYear, string itemCode)
        {
            decimal totalQuantity = 0;
            try
            {
                string query = @"
            SELECT SUM(QuantityChange) AS TotalQuantity
            FROM (
                -- Sales: Outgoing (negative)
                SELECT -sii.Quantity AS QuantityChange
                FROM SalesInvoice si
                INNER JOIN SalesInvoiceItems sii ON si.SalesInvoiceID = sii.SalesInvoiceID
                WHERE si.FinancialYearID = @FinancialYearID AND sii.ItemID = @ItemCode

                UNION ALL

                -- Purchase: Incoming (positive)
                SELECT pii.Quantity
                FROM PurchaseInvoice pi
                INNER JOIN PurchaseInvoiceItems pii ON pi.PurchaseInvoiceID = pii.PurchaseInvoiceID
                WHERE pi.FinancialYearID = @FinancialYearID AND pii.ItemID = @ItemCode

                UNION ALL

                -- Opening Balance
                SELECT ob.Quantity
                FROM InventoryOpeningBalance ob
                WHERE ob.FinancialYearID = @FinancialYearID AND ob.ItemID = @ItemCode
            ) AS Combined";

                dbConnection.openConnection();
                using (SqlCommand cmd = new SqlCommand(query, dbConnection.connection))
                {
                    cmd.Parameters.AddWithValue("@FinancialYearID", financialYear);
                    cmd.Parameters.AddWithValue("@ItemCode", itemCode);

                    object result = cmd.ExecuteScalar();
                    if (result != DBNull.Value && result != null)
                        totalQuantity = Convert.ToDecimal(result);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error calculating item quantity: " + ex.Message);
            }
            finally
            {
                dbConnection.closeConnection();
            }

            return totalQuantity;
        }




    }
}
