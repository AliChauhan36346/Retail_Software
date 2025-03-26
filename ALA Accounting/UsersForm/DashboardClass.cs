using ALA_Accounting.transaction_classes;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ALA_Accounting.UsersForm
{
    internal class DashboardClass
    {
        Connection dbConnection;

        public DashboardClass()
        {
            dbConnection = new Connection();
        }

        public (decimal total, decimal percentageChange) GetTotalSales(DateTime startDate, DateTime endDate, int financialYearID)
        {
            return GetTransactionTotal("SalesInvoice", "NetTotal", "InvoiceDate", startDate, endDate, financialYearID);
        }

        public (decimal total, decimal percentageChange) GetTotalPurchases(DateTime startDate, DateTime endDate, int financialYearID)
        {
            return GetTransactionTotal("PurchaseInvoice", "NetTotal", "InvoiceDate", startDate, endDate, financialYearID);
        }

        public (decimal total, decimal percentageChange) GetTotalPayments(DateTime startDate, DateTime endDate, int financialYearID)
        {
            return GetTransactionTotal(new string[] { "CashPayment", "BankPayment" }, "Amount", "PaymentDate", startDate, endDate, financialYearID);
        }

        public (decimal total, decimal percentageChange) GetTotalReceipts(DateTime startDate, DateTime endDate, int financialYearID)
        {
            return GetTransactionTotal(new string[] { "CashReceipt", "BankReceipt" }, "Amount", "ReceiptDate", startDate, endDate, financialYearID);
        }

        private (decimal total, decimal percentageChange) GetTransactionTotal(string tableName, string columnName, string dateColumn, DateTime startDate, DateTime endDate, int financialYearID)
        {
            string queryCurrent = $@"
                SELECT COALESCE(SUM({columnName}), 0) 
                FROM {tableName} 
                WHERE {dateColumn} BETWEEN @StartDate AND @EndDate 
                AND FinancialYearID = @FinancialYearID;";

            string queryPrevious = $@"
                SELECT COALESCE(SUM({columnName}), 0) 
                FROM {tableName} 
                WHERE {dateColumn} BETWEEN DATEADD(DAY, DATEDIFF(DAY, @StartDate, @EndDate) * -1, @StartDate) 
                AND DATEADD(DAY, DATEDIFF(DAY, @StartDate, @EndDate) * -1, @EndDate)
                AND FinancialYearID = @FinancialYearID;";

            decimal current = ExecuteScalarQuery(queryCurrent, startDate, endDate, financialYearID);
            decimal previous = ExecuteScalarQuery(queryPrevious, startDate, endDate, financialYearID);

            decimal percentageChange = previous != 0 ? ((current - previous) / previous) * 100 : 0;
            return (current, percentageChange);
        }

        private (decimal total, decimal percentageChange) GetTransactionTotal(string[] tableNames, string columnName, string dateColumn, DateTime startDate, DateTime endDate, int financialYearID)
        {
            decimal currentTotal = 0, previousTotal = 0;

            foreach (string tableName in tableNames)
            {
                var (current, previous) = GetTransactionTotal(tableName, columnName, dateColumn, startDate, endDate, financialYearID);
                currentTotal += current;
                previousTotal += previous;
            }

            decimal percentageChange = previousTotal != 0 ? ((currentTotal - previousTotal) / previousTotal) * 100 : 0;
            return (currentTotal, percentageChange);
        }

        private decimal ExecuteScalarQuery(string query, DateTime startDate, DateTime endDate, int financialYearID)
        {

            dbConnection.openConnection();
            using (SqlCommand cmd = new SqlCommand(query, dbConnection.connection))
            {
                cmd.Parameters.AddWithValue("@StartDate", startDate);
                cmd.Parameters.AddWithValue("@EndDate", endDate);
                cmd.Parameters.AddWithValue("@FinancialYearID", financialYearID);

                object result = cmd.ExecuteScalar();
                dbConnection.closeConnection();
                return result != DBNull.Value ? Convert.ToDecimal(result) : 0;
            }
            
        }
    }
}
