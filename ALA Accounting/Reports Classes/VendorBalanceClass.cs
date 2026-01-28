using ALA_Accounting.transaction_classes;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ALA_Accounting.Reports_Classes
{
    internal class VendorBalanceClass
    {
        Connection dbConnection;

        public VendorBalanceClass()
        {
            dbConnection = new Connection();
        }

        /// <summary>
        /// Load vendor balance with filters
        /// </summary>
        public DataTable LoadData(int financialYearID, DateTime? startDate = null, DateTime? endDate = null)
        {
            DataTable dataTable = new DataTable();
            try
            {
                dbConnection.openConnection();

                string query = @"
                    WITH OpeningBalance AS (
                        SELECT 
                            aob.AccountID,
                            SUM(ISNULL(aob.Debit, 0) - ISNULL(aob.Credit, 0)) AS OpeningBalance
                        FROM AccountsOpeningBalance aob
                        WHERE aob.FinancialYearID = @FinancialYearID
                        GROUP BY aob.AccountID
                    ),
                    Purchases AS (
                        SELECT 
                            t.AccountID,
                            SUM(CASE WHEN t.TransactionType = 'Debit' THEN t.Amount ELSE 0 END) AS PurchaseAmount
                        FROM Transactions t
                        WHERE t.FinancialYearID = @FinancialYearID
                        AND t.TransactionDate >= @StartDate
                        AND t.TransactionDate <= @EndDate
                        GROUP BY t.AccountID
                    ),
                    Payments AS (
                        SELECT 
                            t.AccountID,
                            SUM(CASE WHEN t.TransactionType = 'Credit' THEN t.Amount ELSE 0 END) AS PaymentAmount
                        FROM Transactions t
                        WHERE t.FinancialYearID = @FinancialYearID
                        AND t.TransactionDate >= @StartDate
                        AND t.TransactionDate <= @EndDate
                        GROUP BY t.AccountID
                    )
                    SELECT
                        a.AccountID AS [Vendor ID],
                        a.AccountName AS [Vendor Name],
                        ISNULL(ob.OpeningBalance, 0) AS [Opening Balance],
                        CASE WHEN ISNULL(ob.OpeningBalance, 0) > 0 THEN 'DR' ELSE 'CR' END AS [Opening Status],
                        ISNULL(p.PurchaseAmount, 0) AS [Debit],
                        ISNULL(pm.PaymentAmount, 0) AS [Credit],
                        (ISNULL(ob.OpeningBalance, 0) + ISNULL(p.PurchaseAmount, 0) - ISNULL(pm.PaymentAmount, 0)) AS [Closing Balance],
                        CASE WHEN (ISNULL(ob.OpeningBalance, 0) + ISNULL(p.PurchaseAmount, 0) - ISNULL(pm.PaymentAmount, 0)) > 0 THEN 'DR' ELSE 'CR' END AS [Closing Status]
                    FROM Accounts a
                    INNER JOIN SubAccounts sa ON a.SubAccountTypeID = sa.SubAccountTypeId
                    INNER JOIN MainAccounts ma ON sa.MainAccountID = ma.MainAccountID
                    LEFT JOIN OpeningBalance ob ON a.AccountID = ob.AccountID
                    LEFT JOIN Purchases p ON a.AccountID = p.AccountID
                    LEFT JOIN Payments pm ON a.AccountID = pm.AccountID
                    WHERE ma.MainAccountID = 5
                    ORDER BY a.AccountName";

                using (SqlCommand cmd = new SqlCommand(query, dbConnection.connection))
                {
                    cmd.Parameters.AddWithValue("@FinancialYearID", financialYearID);
                    cmd.Parameters.AddWithValue("@StartDate", startDate ?? new DateTime(2000, 1, 1));
                    cmd.Parameters.AddWithValue("@EndDate", endDate ?? DateTime.Now);

                    SqlDataAdapter adapter = new SqlDataAdapter(cmd);
                    adapter.Fill(dataTable);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error loading vendor balance data: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally
            {
                dbConnection.closeConnection();
            }

            return dataTable;
        }

        /// <summary>
        /// Get summary totals for the report
        /// </summary>
        public DataTable GetSummary(int financialYearID, DateTime? startDate = null, DateTime? endDate = null)
        {
            DataTable dataTable = new DataTable();
            try
            {
                dbConnection.openConnection();

                string query = @"
                    WITH OpeningBalance AS (
                        SELECT 
                            aob.AccountID,
                            SUM(ISNULL(aob.Debit, 0) - ISNULL(aob.Credit, 0)) AS OpeningBalance
                        FROM AccountsOpeningBalance aob
                        WHERE aob.FinancialYearID = @FinancialYearID
                        GROUP BY aob.AccountID
                    ),
                    Purchases AS (
                        SELECT 
                            t.AccountID,
                            SUM(CASE WHEN t.TransactionType = 'Debit' THEN t.Amount ELSE 0 END) AS PurchaseAmount
                        FROM Transactions t
                        WHERE t.FinancialYearID = @FinancialYearID
                        AND t.TransactionDate >= @StartDate
                        AND t.TransactionDate <= @EndDate
                        GROUP BY t.AccountID
                    ),
                    Payments AS (
                        SELECT 
                            t.AccountID,
                            SUM(CASE WHEN t.TransactionType = 'Credit' THEN t.Amount ELSE 0 END) AS PaymentAmount
                        FROM Transactions t
                        WHERE t.FinancialYearID = @FinancialYearID
                        AND t.TransactionDate >= @StartDate
                        AND t.TransactionDate <= @EndDate
                        GROUP BY t.AccountID
                    )
                    SELECT
                        COUNT(DISTINCT a.AccountID) AS TotalVendors,
                        SUM(ISNULL(ob.OpeningBalance, 0)) AS TotalOpeningBalance,
                        SUM(ISNULL(p.PurchaseAmount, 0)) AS TotalDebit,
                        SUM(ISNULL(pm.PaymentAmount, 0)) AS TotalCredit,
                        SUM(ISNULL(ob.OpeningBalance, 0) + ISNULL(p.PurchaseAmount, 0) - ISNULL(pm.PaymentAmount, 0)) AS TotalClosingBalance
                    FROM Accounts a
                    INNER JOIN SubAccounts sa ON a.SubAccountTypeID = sa.SubAccountTypeId
                    INNER JOIN MainAccounts ma ON sa.MainAccountID = ma.MainAccountID
                    LEFT JOIN OpeningBalance ob ON a.AccountID = ob.AccountID
                    LEFT JOIN Purchases p ON a.AccountID = p.AccountID
                    LEFT JOIN Payments pm ON a.AccountID = pm.AccountID
                    WHERE ma.MainAccountID = 5";

                using (SqlCommand cmd = new SqlCommand(query, dbConnection.connection))
                {
                    cmd.Parameters.AddWithValue("@FinancialYearID", financialYearID);
                    cmd.Parameters.AddWithValue("@StartDate", startDate ?? new DateTime(2000, 1, 1));
                    cmd.Parameters.AddWithValue("@EndDate", endDate ?? DateTime.Now);

                    SqlDataAdapter adapter = new SqlDataAdapter(cmd);
                    adapter.Fill(dataTable);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error loading summary: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally
            {
                dbConnection.closeConnection();
            }

            return dataTable;
        }
    }
}
