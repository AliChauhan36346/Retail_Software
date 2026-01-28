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
    internal class InventoryBalanceClass
    {
        Connection dbConnection;

        public InventoryBalanceClass()
        {
            dbConnection = new Connection();
        }

        /// <summary>
        /// Load inventory balance with filters
        /// </summary>
        public DataTable LoadData(int financialYearID, int? categoryID = null, int? subCategoryID = null,
            string brand = null, DateTime? startDate = null, DateTime? endDate = null)
        {
            DataTable dataTable = new DataTable();
            try
            {
                dbConnection.openConnection();

                string query = @"
                    WITH OpeningBalance AS (
                        SELECT 
                            iob.ItemID,
                            SUM(iob.Quantity) AS OpeningQty,
                            SUM(iob.Quantity * iob.Rate) AS OpeningCost,
                            AVG(iob.Rate) AS OpeningRate
                        FROM InventoryOpeningBalance iob
                        WHERE iob.FinancialYearID = @FinancialYearID
                        GROUP BY iob.ItemID
                    ),
                    PurchaseTransaction AS (
                        SELECT 
                            it.ItemID,
                            SUM(it.Quantity) AS QtyIn,
                            SUM(it.Quantity * it.Rate) AS PurchaseCost,
                            AVG(it.Rate) AS AvgPurchaseRate
                        FROM InventoryTransaction it
                        WHERE it.TransactionType = 'Purchase'
                        AND it.TransactionDate >= @StartDate
                        AND it.TransactionDate <= @EndDate
                        GROUP BY it.ItemID
                    ),
                    SaleTransaction AS (
                        SELECT 
                            it.ItemID,
                            SUM(it.Quantity) AS QtyOut,
                            SUM(it.Quantity * it.Rate) AS SaleValue
                        FROM InventoryTransaction it
                        WHERE it.TransactionType = 'Sale'
                        AND it.TransactionDate >= @StartDate
                        AND it.TransactionDate <= @EndDate
                        GROUP BY it.ItemID
                    )
                    SELECT
                        i.ItemID AS [Item ID],
                        i.ItemName AS [Item Name],
                        ISNULL(ob.OpeningQty, 0) AS [Opening Balance],
                        ISNULL(pt.QtyIn, 0) AS [Quantity In],
                        ISNULL(st.QtyOut, 0) AS [Quantity Out],
                        (ISNULL(ob.OpeningQty, 0) + ISNULL(pt.QtyIn, 0) - ISNULL(st.QtyOut, 0)) AS [Closing Balance],
                        i.MeasurementUnit AS [Unit],
                        CASE 
                            WHEN (ISNULL(ob.OpeningQty, 0) + ISNULL(pt.QtyIn, 0)) > 0
                            THEN (ISNULL(ob.OpeningCost, 0) + ISNULL(pt.PurchaseCost, 0)) / 
                                 (ISNULL(ob.OpeningQty, 0) + ISNULL(pt.QtyIn, 0))
                            ELSE 0
                        END AS [Cost],
                        (ISNULL(ob.OpeningQty, 0) + ISNULL(pt.QtyIn, 0) - ISNULL(st.QtyOut, 0)) *
                        CASE 
                            WHEN (ISNULL(ob.OpeningQty, 0) + ISNULL(pt.QtyIn, 0)) > 0
                            THEN (ISNULL(ob.OpeningCost, 0) + ISNULL(pt.PurchaseCost, 0)) / 
                                 (ISNULL(ob.OpeningQty, 0) + ISNULL(pt.QtyIn, 0))
                            ELSE 0
                        END AS [Value]
                    FROM InventoryItem i
                    LEFT JOIN SubInventoryCategory sic ON i.SubCategoryID = sic.SubCategoryID
                    LEFT JOIN OpeningBalance ob ON i.ItemID = ob.ItemID
                    LEFT JOIN PurchaseTransaction pt ON i.ItemID = pt.ItemID
                    LEFT JOIN SaleTransaction st ON i.ItemID = st.ItemID
                    WHERE 1=1
                    " + (categoryID.HasValue ? "AND sic.InventoryCategoryID = @CategoryID " : "") +
                        (subCategoryID.HasValue ? "AND i.SubCategoryID = @SubCategoryID " : "") +
                        (!string.IsNullOrEmpty(brand) ? "AND i.BrandName = @Brand " : "") +
                    @" ORDER BY i.ItemName";

                using (SqlCommand cmd = new SqlCommand(query, dbConnection.connection))
                {
                    cmd.Parameters.AddWithValue("@FinancialYearID", financialYearID);
                    cmd.Parameters.AddWithValue("@StartDate", startDate ?? new DateTime(2000, 1, 1));
                    cmd.Parameters.AddWithValue("@EndDate", endDate ?? DateTime.Now);

                    if (categoryID.HasValue)
                        cmd.Parameters.AddWithValue("@CategoryID", categoryID.Value);

                    if (subCategoryID.HasValue)
                        cmd.Parameters.AddWithValue("@SubCategoryID", subCategoryID.Value);

                    if (!string.IsNullOrEmpty(brand))
                        cmd.Parameters.AddWithValue("@Brand", brand);

                    SqlDataAdapter adapter = new SqlDataAdapter(cmd);
                    adapter.Fill(dataTable);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error loading inventory balance data: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally
            {
                dbConnection.closeConnection();
            }

            return dataTable;
        }

        /// <summary>
        /// Load all categories for dropdown
        /// </summary>
        public DataTable LoadCategories()
        {
            DataTable dataTable = new DataTable();
            try
            {
                dbConnection.openConnection();

                string query = "SELECT InventoryCategoryID, CategoryName FROM InventoryCategory ORDER BY CategoryName";

                using (SqlCommand cmd = new SqlCommand(query, dbConnection.connection))
                {
                    SqlDataAdapter adapter = new SqlDataAdapter(cmd);
                    adapter.Fill(dataTable);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error loading categories: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally
            {
                dbConnection.closeConnection();
            }

            return dataTable;
        }

        /// <summary>
        /// Load subcategories by category
        /// </summary>
        public DataTable LoadSubCategories(int categoryID)
        {
            DataTable dataTable = new DataTable();
            try
            {
                dbConnection.openConnection();

                string query = @"
                    SELECT SubCategoryID, SubCategoryName 
                    FROM SubInventoryCategory 
                    WHERE InventoryCategoryID = @CategoryID
                    ORDER BY SubCategoryName";

                using (SqlCommand cmd = new SqlCommand(query, dbConnection.connection))
                {
                    cmd.Parameters.AddWithValue("@CategoryID", categoryID);
                    SqlDataAdapter adapter = new SqlDataAdapter(cmd);
                    adapter.Fill(dataTable);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error loading subcategories: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally
            {
                dbConnection.closeConnection();
            }

            return dataTable;
        }

        /// <summary>
        /// Load all brands for dropdown
        /// </summary>
        public DataTable LoadBrands()
        {
            DataTable dataTable = new DataTable();
            try
            {
                dbConnection.openConnection();

                string query = "SELECT DISTINCT BrandName FROM InventoryItem WHERE BrandName IS NOT NULL ORDER BY BrandName";

                using (SqlCommand cmd = new SqlCommand(query, dbConnection.connection))
                {
                    SqlDataAdapter adapter = new SqlDataAdapter(cmd);
                    adapter.Fill(dataTable);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error loading brands: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
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
        public DataTable GetSummary(int financialYearID, int? categoryID = null, int? subCategoryID = null,
            string brand = null, DateTime? startDate = null, DateTime? endDate = null)
        {
            DataTable dataTable = new DataTable();
            try
            {
                dbConnection.openConnection();

                string query = @"
                    WITH OpeningBalance AS (
                        SELECT 
                            iob.ItemID,
                            SUM(iob.Quantity) AS OpeningQty,
                            SUM(iob.Quantity * iob.Rate) AS OpeningCost
                        FROM InventoryOpeningBalance iob
                        WHERE iob.FinancialYearID = @FinancialYearID
                        GROUP BY iob.ItemID
                    ),
                    PurchaseTransaction AS (
                        SELECT 
                            it.ItemID,
                            SUM(it.Quantity) AS QtyIn,
                            SUM(it.Quantity * it.Rate) AS PurchaseCost
                        FROM InventoryTransaction it
                        WHERE it.TransactionType = 'Purchase'
                        AND it.TransactionDate >= @StartDate
                        AND it.TransactionDate <= @EndDate
                        GROUP BY it.ItemID
                    ),
                    SaleTransaction AS (
                        SELECT 
                            it.ItemID,
                            SUM(it.Quantity) AS QtyOut,
                            SUM(it.Quantity * it.Rate) AS SaleValue
                        FROM InventoryTransaction it
                        WHERE it.TransactionType = 'Sale'
                        AND it.TransactionDate >= @StartDate
                        AND it.TransactionDate <= @EndDate
                        GROUP BY it.ItemID
                    )
                    SELECT
                        SUM(ISNULL(ob.OpeningQty, 0)) AS TotalOpeningBalance,
                        SUM(ISNULL(pt.QtyIn, 0)) AS TotalQtyIn,
                        SUM(ISNULL(st.QtyOut, 0)) AS TotalQtyOut,
                        SUM(ISNULL(ob.OpeningQty, 0) + ISNULL(pt.QtyIn, 0) - ISNULL(st.QtyOut, 0)) AS TotalClosingBalance,
                        SUM((ISNULL(ob.OpeningQty, 0) + ISNULL(pt.QtyIn, 0) - ISNULL(st.QtyOut, 0)) *
                            CASE 
                                WHEN (ISNULL(ob.OpeningQty, 0) + ISNULL(pt.QtyIn, 0)) > 0
                                THEN (ISNULL(ob.OpeningCost, 0) + ISNULL(pt.PurchaseCost, 0)) / 
                                     (ISNULL(ob.OpeningQty, 0) + ISNULL(pt.QtyIn, 0))
                                ELSE 0
                            END) AS TotalValue
                    FROM InventoryItem i
                    LEFT JOIN SubInventoryCategory sic ON i.SubCategoryID = sic.SubCategoryID
                    LEFT JOIN OpeningBalance ob ON i.ItemID = ob.ItemID
                    LEFT JOIN PurchaseTransaction pt ON i.ItemID = pt.ItemID
                    LEFT JOIN SaleTransaction st ON i.ItemID = st.ItemID
                    WHERE 1=1
                    " + (categoryID.HasValue ? "AND sic.InventoryCategoryID = @CategoryID " : "") +
                        (subCategoryID.HasValue ? "AND i.SubCategoryID = @SubCategoryID " : "") +
                        (!string.IsNullOrEmpty(brand) ? "AND i.BrandName = @Brand " : "");

                using (SqlCommand cmd = new SqlCommand(query, dbConnection.connection))
                {
                    cmd.Parameters.AddWithValue("@FinancialYearID", financialYearID);
                    cmd.Parameters.AddWithValue("@StartDate", startDate ?? new DateTime(2000, 1, 1));
                    cmd.Parameters.AddWithValue("@EndDate", endDate ?? DateTime.Now);

                    if (categoryID.HasValue)
                        cmd.Parameters.AddWithValue("@CategoryID", categoryID.Value);

                    if (subCategoryID.HasValue)
                        cmd.Parameters.AddWithValue("@SubCategoryID", subCategoryID.Value);

                    if (!string.IsNullOrEmpty(brand))
                        cmd.Parameters.AddWithValue("@Brand", brand);

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
