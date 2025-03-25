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
                string query = @"WITH SalesData AS (
    SELECT 
        'SV' + CAST(s.SourceId AS NVARCHAR) AS TransactionID,
        si.AccountName AS PartyName,
        s.ItemID,
        s.TransactionDate AS Date,
        s.Quantity AS QuantityOut,
        NULL AS QuantityIn,
        s.Rate,
        (s.Quantity * s.Rate) AS GrossAmount,
        sii.Discount,
        ((s.Quantity * s.Rate) - sii.Discount) AS NetAmount
    FROM InventoryTransaction s
    INNER JOIN SalesInvoice si ON s.SourceID = si.SalesInvoiceID
    INNER JOIN SalesInvoiceItems sii ON s.SourceID = sii.SalesInvoiceID AND s.ItemID = sii.ItemID
    WHERE s.TransactionType = 'Sale' 
        AND si.FinancialYearID = @FinancialYearID
),
PurchaseData AS (
    SELECT 
        'PV' + CAST(p.SourceId AS NVARCHAR) AS TransactionID,
        pi.AccountName AS PartyName, 
        p.ItemID,
        p.TransactionDate AS Date,
        NULL AS QuantityOut,
        p.Quantity AS QuantityIn,
        p.Rate,
        (p.Quantity * p.Rate) AS GrossAmount,
        pii.Discount,
        ((p.Quantity * p.Rate) - pii.Discount) AS NetAmount
    FROM InventoryTransaction p
    INNER JOIN PurchaseInvoice pi ON p.SourceID = pi.PurchaseInvoiceID
    INNER JOIN PurchaseInvoiceItems pii ON p.SourceID = pii.PurchaseInvoiceID AND p.ItemID = pii.ItemID
    WHERE p.TransactionType = 'Purchase'
        AND pi.FinancialYearID = @FinancialYearID
),
OpeningBalanceData AS (
    SELECT 
        'OB' + CAST(ob.OpeningBalanceID AS NVARCHAR) AS TransactionID,
        'Opening balance' AS PartyName,
        ob.ItemID,
        DATEADD(DAY, -1, @StartDate) AS Date,  -- Assign one day before the user-selected start date
        NULL AS QuantityOut,
        ob.Quantity AS QuantityIn,
        ob.Rate,
        (ob.Quantity * ob.Rate) AS GrossAmount,
        0 AS Discount,
        (ob.Quantity * ob.Rate) AS NetAmount
    FROM InventoryOpeningBalance ob
    WHERE ob.FinancialYearID = @FinancialYearID
),
CombinedData AS (
    SELECT * FROM SalesData
    UNION ALL
    SELECT * FROM PurchaseData
    UNION ALL
    SELECT * FROM OpeningBalanceData
),
PreviousBalance AS (
    SELECT 
        t.ItemID,
        SUM(COALESCE(t.QuantityIn, 0) - COALESCE(t.QuantityOut, 0)) AS BalanceQty
    FROM CombinedData t
    WHERE t.ItemID = @ItemCode AND t.Date < @StartDate
    GROUP BY t.ItemID
),
FilteredData AS (
    SELECT 
        t.ItemID,
        t.Date,
        t.TransactionID,
        t.PartyName,
        t.QuantityIn,
        t.QuantityOut,
        i.MeasurementUnit AS Unit,
        t.Rate,
        t.GrossAmount,
        t.Discount,
        t.NetAmount
    FROM CombinedData t
    LEFT JOIN InventoryItem i ON t.ItemID = i.ItemID
    WHERE t.ItemID = @ItemCode 
        AND (@StartDate IS NULL OR t.Date >= @StartDate)
        AND (@EndDate IS NULL OR t.Date <= @EndDate)
)
SELECT 
    t.ItemID,
    t.Date,
    t.TransactionID,
    t.PartyName,
    t.QuantityIn,
    t.QuantityOut,
    t.Unit,
    t.Rate,
    t.GrossAmount,
    t.Discount,
    t.NetAmount,
    SUM(COALESCE(t.QuantityIn, 0) - COALESCE(t.QuantityOut, 0)) 
        OVER (PARTITION BY t.ItemID ORDER BY t.Date, t.TransactionID 
        ROWS BETWEEN UNBOUNDED PRECEDING AND CURRENT ROW) + COALESCE(pb.BalanceQty, 0) AS BalanceQty  
FROM FilteredData t
LEFT JOIN PreviousBalance pb ON t.ItemID = pb.ItemID
ORDER BY t.Date, t.TransactionID;


";


                dbConnection.openConnection();
                
                using (SqlCommand cmd = new SqlCommand(query, dbConnection.connection))
                {
                    cmd.Parameters.AddWithValue("@FinancialYearID", financialYear);
                    cmd.Parameters.AddWithValue("@ItemCode", itemCode);

                    if (startDate.HasValue)
                        cmd.Parameters.AddWithValue("@StartDate", startDate.Value);
                    else
                        cmd.Parameters.AddWithValue("@StartDate", DBNull.Value);

                    if (endDate.HasValue)
                        cmd.Parameters.AddWithValue("@EndDate", endDate.Value);
                    else
                        cmd.Parameters.AddWithValue("@EndDate", DBNull.Value);

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
