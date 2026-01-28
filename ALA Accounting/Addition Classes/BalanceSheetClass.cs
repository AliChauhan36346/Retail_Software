using ALA_Accounting.transaction_classes;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ALA_Accounting.Addition_Classes
{
    public class BalanceSheetClass
    {
        Connection dbConnection;

        public class BalanceSheetItem
        {
            public string AccountName { get; set; }
            public string MainAccountName { get; set; }
            public string FinancialStatementComponent { get; set; }
            public decimal Amount { get; set; }
            public string Level { get; set; } // Main, Sub, Detail
        }

        public class BalanceSheetSummary
        {
            public decimal TotalAssets { get; set; }
            public decimal TotalLiabilities { get; set; }
            public decimal TotalCapital { get; set; }
            public decimal CurrentAssets { get; set; }
            public decimal FixedAssets { get; set; }
            public decimal CurrentLiabilities { get; set; }
            public decimal LongTermLiabilities { get; set; }
            public decimal CurrentRatio { get; set; }
            public bool IsBalanced { get; set; }
        }

        public BalanceSheetClass()
        {
            dbConnection = new Connection();
        }

        /// <summary>
        /// Gets all balance sheet items for a specific financial year
        /// </summary>
        public DataTable GetBalanceSheetData(int financialYearID)
        {
            DataTable dt = new DataTable();
            try
            {
                dbConnection.openConnection();

                string query = @"
                    SELECT 
                        a.AccountID,
                        a.AccountName,
                        ma.MainAccountName,
                        ma.FinancialStatementComponent,
                        COALESCE(aob.Debit, 0) - COALESCE(aob.Credit, 0) AS ClosingBalance,
                        COALESCE(SUM(CASE WHEN t.TransactionType = 'Debit' THEN t.Amount ELSE 0 END), 0) -
                        COALESCE(SUM(CASE WHEN t.TransactionType = 'Credit' THEN t.Amount ELSE 0 END), 0) AS TransactionBalance,
                        COALESCE(sa.SubAccountTypeName, '') AS SubAccountTypeName
                    FROM Accounts a
                    INNER JOIN SubAccounts sa ON a.SubAccountTypeID = sa.SubAccountTypeId
                    INNER JOIN MainAccounts ma ON sa.MainAccountID = ma.MainAccountID
                    LEFT JOIN AccountsOpeningBalance aob ON a.AccountID = aob.AccountId AND aob.FinancialYearID = @FinancialYearID
                    LEFT JOIN Transactions t ON a.AccountID = t.AccountID AND t.FinancialYearID = @FinancialYearID
                    WHERE ma.FinancialStatementComponent IS NOT NULL
                    GROUP BY 
                        a.AccountID,
                        a.AccountName,
                        ma.MainAccountName,
                        ma.FinancialStatementComponent,
                        aob.Debit,
                        aob.Credit,
                        sa.SubAccountTypeName
                    ORDER BY ma.FinancialStatementComponent, ma.MainAccountName, a.AccountName";

                using (SqlCommand cmd = new SqlCommand(query, dbConnection.connection))
                {
                    cmd.Parameters.AddWithValue("@FinancialYearID", financialYearID);
                    SqlDataAdapter adapter = new SqlDataAdapter(cmd);
                    adapter.Fill(dt);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error loading balance sheet data: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally
            {
                dbConnection.closeConnection();
            }

            return dt;
        }

        /// <summary>
        /// Gets balance sheet summary with totals and ratios
        /// </summary>
        public BalanceSheetSummary GetBalanceSheetSummary(int financialYearID)
        {
            BalanceSheetSummary summary = new BalanceSheetSummary();

            try
            {
                dbConnection.openConnection();

                string query = @"
                    -- Get the financial year date range
                    DECLARE @StartDate DATETIME;
                    DECLARE @EndDate DATETIME;
                    
                    SELECT @StartDate = StartDate, @EndDate = EndDate 
                    FROM FinancialYear 
                    WHERE FinancialYearID = @FinancialYearID;

                    WITH AccountBalances AS (
                        SELECT 
                            ma.FinancialStatementComponent,
                            a.AccountID,
                            a.AccountName,
                            COALESCE(aob.Debit, 0) - COALESCE(aob.Credit, 0) + 
                            COALESCE(SUM(CASE WHEN t.TransactionType = 'Debit' THEN t.Amount ELSE 0 END), 0) -
                            COALESCE(SUM(CASE WHEN t.TransactionType = 'Credit' THEN t.Amount ELSE 0 END), 0) AS Balance,
                            COALESCE(sa.SubAccountTypeName, '') AS SubAccountTypeName
                        FROM Accounts a
                        INNER JOIN SubAccounts sa ON a.SubAccountTypeID = sa.SubAccountTypeId
                        INNER JOIN MainAccounts ma ON sa.MainAccountID = ma.MainAccountID
                        LEFT JOIN AccountsOpeningBalance aob ON a.AccountID = aob.AccountId AND aob.FinancialYearID = @FinancialYearID
                        LEFT JOIN Transactions t ON a.AccountID = t.AccountID AND t.FinancialYearID = @FinancialYearID
                        WHERE ma.FinancialStatementComponent IS NOT NULL
                        GROUP BY 
                            ma.FinancialStatementComponent,
                            a.AccountID,
                            a.AccountName,
                            aob.Debit,
                            aob.Credit,
                            sa.SubAccountTypeName
                    ),
                    InventoryValue AS (
                        SELECT 
                            COALESCE(SUM(iob.Quantity * iob.Rate), 0) +
                            COALESCE(SUM(CASE WHEN it.TransactionType = 'Purchase' THEN it.Quantity * it.Rate 
                                                ELSE -it.Quantity * it.Rate END), 0) AS InventoryBalance
                        FROM InventoryOpeningBalance iob
                        LEFT JOIN InventoryTransaction it ON iob.ItemID = it.ItemID 
                            AND it.TransactionDate >= @StartDate 
                            AND it.TransactionDate <= @EndDate
                        WHERE iob.FinancialYearID = @FinancialYearID
                    )
                    SELECT 
                        COALESCE(SUM(CASE WHEN FinancialStatementComponent LIKE '%Assets%' THEN ABS(Balance) ELSE 0 END), 0) + 
                        COALESCE((SELECT InventoryBalance FROM InventoryValue), 0) AS TotalAssets,
                        COALESCE(SUM(CASE WHEN FinancialStatementComponent LIKE '%Liabilities%' THEN ABS(Balance) ELSE 0 END), 0) AS TotalLiabilities,
                        COALESCE(SUM(CASE WHEN FinancialStatementComponent LIKE '%Capital%' OR FinancialStatementComponent LIKE '%Equity%' THEN ABS(Balance) ELSE 0 END), 0) AS TotalCapital,
                        COALESCE(SUM(CASE WHEN FinancialStatementComponent LIKE '%Current%Assets%' THEN ABS(Balance) ELSE 0 END), 0) +
                        COALESCE((SELECT InventoryBalance FROM InventoryValue), 0) AS CurrentAssets,
                        COALESCE(SUM(CASE WHEN FinancialStatementComponent LIKE '%Fixed%Assets%' OR FinancialStatementComponent LIKE '%Fixed%' THEN ABS(Balance) ELSE 0 END), 0) AS FixedAssets,
                        COALESCE(SUM(CASE WHEN FinancialStatementComponent LIKE '%Current%Liabilities%' THEN ABS(Balance) ELSE 0 END), 0) AS CurrentLiabilities,
                        COALESCE(SUM(CASE WHEN FinancialStatementComponent LIKE '%Liabilities%' AND FinancialStatementComponent NOT LIKE '%Current%' THEN ABS(Balance) ELSE 0 END), 0) AS LongTermLiabilities
                    FROM AccountBalances";

                using (SqlCommand cmd = new SqlCommand(query, dbConnection.connection))
                {
                    cmd.Parameters.AddWithValue("@FinancialYearID", financialYearID);

                    using (SqlDataReader reader = cmd.ExecuteReader())
                    {
                        if (reader.Read())
                        {
                            summary.TotalAssets = Convert.ToDecimal(reader["TotalAssets"] ?? 0);
                            summary.TotalLiabilities = Convert.ToDecimal(reader["TotalLiabilities"] ?? 0);
                            summary.TotalCapital = Convert.ToDecimal(reader["TotalCapital"] ?? 0);
                            summary.CurrentAssets = Convert.ToDecimal(reader["CurrentAssets"] ?? 0);
                            summary.FixedAssets = Convert.ToDecimal(reader["FixedAssets"] ?? 0);
                            summary.CurrentLiabilities = Convert.ToDecimal(reader["CurrentLiabilities"] ?? 0);
                            summary.LongTermLiabilities = Convert.ToDecimal(reader["LongTermLiabilities"] ?? 0);

                            // Calculate Current Ratio
                            summary.CurrentRatio = summary.CurrentLiabilities > 0 
                                ? summary.CurrentAssets / summary.CurrentLiabilities 
                                : 0;

                            // Check if balance sheet is balanced
                            summary.IsBalanced = Math.Abs(summary.TotalAssets - (summary.TotalLiabilities + summary.TotalCapital)) < 0.01m;
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error calculating balance sheet summary: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally
            {
                dbConnection.closeConnection();
            }

            return summary;
        }

        /// <summary>
        /// Gets grouped balance sheet data by financial statement component
        /// </summary>
        public Dictionary<string, List<BalanceSheetItem>> GetGroupedBalanceSheetData(int financialYearID)
        {
            Dictionary<string, List<BalanceSheetItem>> groupedData = new Dictionary<string, List<BalanceSheetItem>>();
            DataTable dt = GetBalanceSheetData(financialYearID);

            // Group by actual FinancialStatementComponent values from database
            var components = dt.AsEnumerable()
                .Select(r => r["FinancialStatementComponent"].ToString())
                .Distinct()
                .ToList();

            foreach (string component in components)
            {
                List<BalanceSheetItem> items = new List<BalanceSheetItem>();
                DataRow[] rows = dt.Select($"FinancialStatementComponent = '{component.Replace("'", "''")}'");

                foreach (DataRow row in rows)
                {
                    decimal closingBalance = Convert.ToDecimal(row["ClosingBalance"] ?? 0);
                    decimal transactionBalance = Convert.ToDecimal(row["TransactionBalance"] ?? 0);
                    decimal totalBalance = closingBalance + transactionBalance;

                    // Include accounts even if balance is zero for visibility
                    items.Add(new BalanceSheetItem
                    {
                        AccountName = row["AccountName"].ToString(),
                        MainAccountName = row["MainAccountName"].ToString(),
                        FinancialStatementComponent = component,
                        Amount = Math.Abs(totalBalance),
                        Level = "Detail"
                    });
                }

                if (items.Count > 0)
                {
                    groupedData[component] = items.OrderBy(x => x.MainAccountName).ToList();
                }
            }

            return groupedData;
        }

        /// <summary>
        /// Gets financial year information
        /// </summary>
        public DataTable GetFinancialYearInfo(int financialYearID)
        {
            DataTable dt = new DataTable();
            try
            {
                dbConnection.openConnection();

                string query = "SELECT FinancialYearID, YearName, StartDate, EndDate FROM FinancialYear WHERE FinancialYearID = @FinancialYearID";

                using (SqlCommand cmd = new SqlCommand(query, dbConnection.connection))
                {
                    cmd.Parameters.AddWithValue("@FinancialYearID", financialYearID);
                    SqlDataAdapter adapter = new SqlDataAdapter(cmd);
                    adapter.Fill(dt);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error loading financial year info: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally
            {
                dbConnection.closeConnection();
            }

            return dt;
        }
    }
}
