using ALA_Accounting.transaction_classes;
using System;
using System.Data;
using System.Data.Common;
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



        public DataTable GetAccountLedger(int accountId, int financialYearId)
        {
            DataTable ledgerTable = new DataTable();
            ledgerTable.Columns.Add("Date", typeof(DateTime));
            ledgerTable.Columns.Add("TransactionID", typeof(string));
            ledgerTable.Columns.Add("Description", typeof(string));
            ledgerTable.Columns.Add("Debit", typeof(decimal));
            ledgerTable.Columns.Add("Credit", typeof(decimal));
            ledgerTable.Columns.Add("Balance", typeof(decimal));
            ledgerTable.Columns.Add("Status", typeof(string));

            decimal balance = 0;

            string query = @"
SELECT CAST(Date AS DATE) AS Date, 'OB' + CAST(OpeningId AS VARCHAR) AS TransactionID, 'Opening Balance' AS Description, 
       Debit, Credit 
FROM AccountsOpeningBalance 
WHERE AccountId = @AccountId AND financialYearID = @FinancialYearId
UNION ALL
SELECT CAST(TransactionDate AS DATE) AS Date, 
       CASE SourceTable 
           WHEN 'SalesInvoice' THEN 'SV' 
           WHEN 'PurchaseInvoice' THEN 'PV' 
           WHEN 'CashPayment' THEN 'CPV' 
           WHEN 'CashReceipt' THEN 'CRV'
           WHEN 'BankPayment' THEN 'BPV'
           WHEN 'BankReceipt' THEN 'BRV'
           ELSE 'TXN' 
       END + CAST(SourceID AS VARCHAR) AS TransactionID,
       Description, 
       CASE WHEN TransactionType = 'Debit' THEN Amount ELSE 0 END AS Debit,
       CASE WHEN TransactionType = 'Credit' THEN Amount ELSE 0 END AS Credit
FROM Transactions 
WHERE AccountID = @AccountId AND FinancialYearID = @FinancialYearId AND IsCancelled = 0
ORDER BY Date";


            dbConnection.openConnection();
            using (SqlCommand cmd = new SqlCommand(query, dbConnection.connection))
            {
                cmd.Parameters.AddWithValue("@AccountId", accountId);
                cmd.Parameters.AddWithValue("@FinancialYearId", financialYearId);

                using (SqlDataReader reader = cmd.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        DateTime date = reader.GetDateTime(0);
                        string transactionId = reader.GetString(1);
                        string description = reader.GetString(2);
                        decimal debit = reader.IsDBNull(3) ? 0 : reader.GetDecimal(3);
                        decimal credit = reader.IsDBNull(4) ? 0 : reader.GetDecimal(4);

                        balance += debit - credit;
                        string status = balance >= 0 ? "Debit" : "Credit";

                        ledgerTable.Rows.Add(date, transactionId, description, debit, credit, Math.Abs(balance), status);
                    }
                }
            }
            return ledgerTable;
        }

    }

}   