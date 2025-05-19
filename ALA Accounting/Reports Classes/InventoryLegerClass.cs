using ALA_Accounting.transaction_classes;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ALA_Accounting.Reports_Classes
{
    internal class InventoryLegerClass
    {
        Connection dbConnection;

        public InventoryLegerClass()
        {
            dbConnection = new Connection();
        }

        public DataTable LoadData(int financialYear, string itemCode, DateTime? startDate, DateTime? endDate)
        {
            DataTable dataTable = new DataTable();
            try
            {
                string query = @"
WITH TransactionData AS (
    -- Sales Transactions
    SELECT 
        'SV' + CAST(si.SalesInvoiceID AS NVARCHAR) AS TransactionID,
        si.AccountName AS PartyName,
        si.InvoiceDate AS Date,
        -sii.Quantity AS QuantityChange,  -- Negative for sales (outgoing)
        sii.Rate,
        (sii.Quantity * sii.Rate) AS GrossAmount,
        sii.Discount,
        ((sii.Quantity * sii.Rate) - sii.Discount) AS NetAmount
    FROM SalesInvoice si
    INNER JOIN SalesInvoiceItems sii ON si.SalesInvoiceID = sii.SalesInvoiceID
    WHERE si.FinancialYearID = @FinancialYearID
    AND sii.ItemID = @ItemCode
    
    UNION ALL
    
    -- Purchase Transactions
    SELECT 
        'PV' + CAST(pi.PurchaseInvoiceID AS NVARCHAR) AS TransactionID,
        pi.AccountName AS PartyName,
        pi.InvoiceDate AS Date,
        pii.Quantity AS QuantityChange,  -- Positive for purchases (incoming)
        pii.Rate,
        (pii.Quantity * pii.Rate) AS GrossAmount,
        pii.Discount,
        ((pii.Quantity * pii.Rate) - pii.Discount) AS NetAmount
    FROM PurchaseInvoice pi
    INNER JOIN PurchaseInvoiceItems pii ON pi.PurchaseInvoiceID = pii.PurchaseInvoiceID
    WHERE pi.FinancialYearID = @FinancialYearID
    AND pii.ItemID = @ItemCode
    
    UNION ALL
    
    -- Opening Balance
    SELECT 
        'OB' + CAST(ob.OpeningBalanceID AS NVARCHAR) AS TransactionID,
        'Opening Balance' AS PartyName,
        ob.Date AS Date,
        ob.Quantity AS QuantityChange,
        ob.Rate,
        (ob.Quantity * ob.Rate) AS GrossAmount,
        0 AS Discount,
        (ob.Quantity * ob.Rate) AS NetAmount
    FROM InventoryOpeningBalance ob
    WHERE ob.FinancialYearID = @FinancialYearID
    AND ob.ItemID = @ItemCode
),
FilteredData AS (
    SELECT 
        td.TransactionID,
        td.PartyName,
        td.Date,
        CASE WHEN td.QuantityChange > 0 THEN td.QuantityChange ELSE NULL END AS QuantityIn,
        CASE WHEN td.QuantityChange < 0 THEN ABS(td.QuantityChange) ELSE NULL END AS QuantityOut,
        i.MeasurementUnit AS Unit,
        td.Rate,
        td.GrossAmount,
        td.Discount,
        td.NetAmount,
        td.QuantityChange
    FROM TransactionData td
    LEFT JOIN InventoryItem i ON i.ItemID = @ItemCode
    WHERE td.Date BETWEEN ISNULL(@StartDate, '1900-01-01') AND ISNULL(@EndDate, '9999-12-31')
)
SELECT 
    fd.TransactionID,
    fd.PartyName,
    fd.Date,
    fd.QuantityIn,
    fd.QuantityOut,
    fd.Unit,
    fd.Rate,
    fd.GrossAmount,
    fd.Discount,
    fd.NetAmount,
    SUM(fd.QuantityChange) OVER (
        ORDER BY 
            CASE WHEN fd.TransactionID LIKE 'OB%' THEN 0 ELSE 1 END,  -- Opening balance first
            fd.Date, 
            fd.TransactionID
        ROWS UNBOUNDED PRECEDING
    ) AS BalanceQty
FROM FilteredData fd
ORDER BY 
    CASE WHEN fd.TransactionID LIKE 'OB%' THEN 0 ELSE 1 END,
    fd.Date,
    fd.TransactionID;";

                dbConnection.openConnection();

                using (SqlCommand cmd = new SqlCommand(query, dbConnection.connection))
                {
                    cmd.Parameters.AddWithValue("@FinancialYearID", financialYear);
                    cmd.Parameters.AddWithValue("@ItemCode", itemCode);
                    cmd.Parameters.AddWithValue("@StartDate", startDate ?? (object)DBNull.Value);
                    cmd.Parameters.AddWithValue("@EndDate", endDate ?? (object)DBNull.Value);

                    using (SqlDataAdapter adapter = new SqlDataAdapter(cmd))
                    {
                        adapter.Fill(dataTable);
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error loading inventory ledger: " + ex.Message);
            }
            finally
            {
                dbConnection.closeConnection();
            }

            return dataTable;
        }



    }
}