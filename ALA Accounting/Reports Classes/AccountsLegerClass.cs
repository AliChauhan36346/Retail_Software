using ALA_Accounting.transaction_classes;
using System;
using System.Data;
using System.Data.SqlClient;
using System.Windows.Forms;

namespace ALA_Accounting.Reports_Classes
{
    internal class AccountsLegerClass
    {
        private Connection dbConnection;

        public AccountsLegerClass()
        {
            dbConnection = new Connection();
        }

        public DataTable GetLedger(int accountId, int financialYearId, DateTime? startDate = null, DateTime? endDate = null)
        {
            DataTable ledgerTable = new DataTable();
            try
            {
                // Configure DataTable columns
                ledgerTable.Columns.Add("Date", typeof(DateTime));
                ledgerTable.Columns.Add("TransactionID", typeof(string));
                ledgerTable.Columns.Add("Description", typeof(string));
                ledgerTable.Columns.Add("Debit", typeof(decimal));
                ledgerTable.Columns.Add("Credit", typeof(decimal));
                ledgerTable.Columns.Add("Balance", typeof(decimal));
                ledgerTable.Columns.Add("Status", typeof(string));

                decimal openingDebit = 0;
                decimal openingCredit = 0;
                int openingId = 0;

                // Retrieve Opening Balance
                using (SqlConnection conn = dbConnection.connection)
                {
                    dbConnection.openConnection();

                    // Get Opening Balance
                    string openingQuery = @"SELECT OpeningId, Debit, Credit FROM AccountsOpeningBalance 
                                  WHERE AccountId = @AccountId AND financialYearID = @FinancialYearId";
                    SqlCommand cmd = new SqlCommand(openingQuery, conn);
                    cmd.Parameters.AddWithValue("@AccountId", accountId);
                    cmd.Parameters.AddWithValue("@FinancialYearId", financialYearId);

                    SqlDataReader reader = cmd.ExecuteReader();
                    if (reader.Read())
                    {
                        openingId = reader.GetInt32(0);
                        openingDebit = reader.GetDecimal(1);
                        openingCredit = reader.GetDecimal(2);
                    }
                    reader.Close();

                    // Calculate Balance Brought Forward (if date range is selected)
                    decimal balanceBroughtForward = openingDebit - openingCredit;
                    if (startDate.HasValue)
                    {
                        string balanceQuery = @"SELECT SUM(CASE WHEN TransactionType = 'Debit' THEN Amount ELSE 0 END) AS TotalDebit,
                                              SUM(CASE WHEN TransactionType = 'Credit' THEN Amount ELSE 0 END) AS TotalCredit
                                       FROM Transactions
                                       WHERE AccountID = @AccountId
                                       AND FinancialYearID = @FinancialYearId
                                       AND TransactionDate < @StartDate
                                       AND IsCancelled = 0";
                        cmd = new SqlCommand(balanceQuery, conn);
                        cmd.Parameters.AddWithValue("@AccountId", accountId);
                        cmd.Parameters.AddWithValue("@FinancialYearId", financialYearId);
                        cmd.Parameters.AddWithValue("@StartDate", startDate.Value);

                        reader = cmd.ExecuteReader();
                        if (reader.Read())
                        {
                            decimal totalDebitBefore = reader.IsDBNull(0) ? 0 : reader.GetDecimal(0);
                            decimal totalCreditBefore = reader.IsDBNull(1) ? 0 : reader.GetDecimal(1);
                            balanceBroughtForward += totalDebitBefore - totalCreditBefore;
                        }
                        reader.Close();
                    }

                    // Add Balance Brought Forward Entry (if date range is selected)
                    if (startDate.HasValue)
                    {
                        DataRow balanceRow = ledgerTable.NewRow();
                        balanceRow["Date"] = startDate.Value;
                        balanceRow["TransactionID"] = "Balance B/F";
                        balanceRow["Description"] = "Balance Brought Forward";
                        balanceRow["Debit"] = balanceBroughtForward > 0 ? balanceBroughtForward : 0;
                        balanceRow["Credit"] = balanceBroughtForward < 0 ? Math.Abs(balanceBroughtForward) : 0;
                        balanceRow["Balance"] = balanceBroughtForward;
                        balanceRow["Status"] = balanceBroughtForward > 0 ? "Debit" : "Credit";
                        ledgerTable.Rows.Add(balanceRow);
                    }

                    // Get Transactions
                    decimal currentBalance = balanceBroughtForward;

                    string transactionQuery = @"SELECT TransactionDate, TransactionType, Amount, Description, 
                                      SourceID, SourceTable 
                                      FROM Transactions 
                                      WHERE AccountID = @AccountId 
                                      AND FinancialYearID = @FinancialYearId 
                                      AND IsCancelled = 0";

                    if (startDate.HasValue && endDate.HasValue)
                    {
                        transactionQuery += " AND TransactionDate BETWEEN @StartDate AND @EndDate";
                    }

                    transactionQuery += " ORDER BY TransactionDate, TransactionID";

                    cmd = new SqlCommand(transactionQuery, conn);
                    cmd.Parameters.AddWithValue("@AccountId", accountId);
                    cmd.Parameters.AddWithValue("@FinancialYearId", financialYearId);

                    if (startDate.HasValue && endDate.HasValue)
                    {
                        cmd.Parameters.AddWithValue("@StartDate", startDate.Value);
                        cmd.Parameters.AddWithValue("@EndDate", endDate.Value);
                    }

                    reader = cmd.ExecuteReader();
                    while (reader.Read())
                    {
                        DateTime date = reader.GetDateTime(0);
                        string type = reader.GetString(1);
                        decimal amount = reader.GetDecimal(2);
                        string description = reader.IsDBNull(3) ? string.Empty : reader.GetString(3);
                        int sourceId = reader.GetInt32(4);
                        string sourceTable = reader.GetString(5);

                        string transactionPrefix = GetTransactionPrefix(sourceTable);
                        string formattedId = $"{transactionPrefix} {sourceId}";

                        decimal debit = 0;
                        decimal credit = 0;

                        if (type.Equals("Debit", StringComparison.OrdinalIgnoreCase))
                        {
                            debit = amount;
                            currentBalance += amount;
                        }
                        else
                        {
                            credit = amount;
                            currentBalance -= amount;
                        }

                        DataRow row = ledgerTable.NewRow();
                        row["Date"] = date;
                        row["TransactionID"] = formattedId;
                        row["Description"] = description;
                        row["Debit"] = debit;
                        row["Credit"] = credit;
                        row["Balance"] = currentBalance;
                        row["Status"] = type;
                        ledgerTable.Rows.Add(row);
                    }
                    reader.Close();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Ledger generation error: " + ex.Message);
            }
            finally
            {
                dbConnection.closeConnection();
            }

            return ledgerTable;
        }

        private string GetTransactionPrefix(string sourceTable)
        {
            switch (sourceTable.ToLower())
            {
                case "purchaseinvoice":
                    return "PV";
                case "salesinvoice":
                    return "SV";
                case "cashpayment":
                    return "CV";
                case "bankpayment":
                    return "BP";
                default:
                    return "TRN"; // Default for unknown types
            }
        }
    }
}