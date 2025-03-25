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
    internal class ItemWiseProfitLossClass
    {
        Connection dbConnection;

        public ItemWiseProfitLossClass()
        {
            dbConnection = new Connection();
        }

        public DataTable LoadData(int financialYearID, int? categoryID = null, int? subCategoryID = null, string brand = null, DateTime? startDate = null, DateTime? endDate = null)
        {
            DataTable dataTable = new DataTable();
            try
            {
                dbConnection.openConnection();

                string query = @"
        WITH SalesData AS (
            SELECT 
                s.ItemID, 
                s.TransactionDate,
                SUM(s.Quantity) AS TotalSold, 
                SUM(s.Quantity * s.Rate) AS SalesValue
            FROM InventoryTransaction s
            JOIN SalesInvoice si ON s.SourceId = si.SalesInvoiceID
            WHERE s.TransactionType = 'Sale'
            AND si.FinancialYearID = @FinancialYearID
            GROUP BY s.ItemID, s.TransactionDate
        ),
        PurchaseData AS (
            SELECT 
                p.ItemID, 
                SUM(p.Quantity) AS TotalPurchased, 
                SUM(p.Quantity * p.Rate) AS TotalPurchaseCost
            FROM InventoryTransaction p
            WHERE p.TransactionType = 'Purchase'
            GROUP BY p.ItemID
        ),
        OpeningBalanceData AS (
            SELECT 
                ob.ItemID, 
                SUM(ob.Quantity) AS OpeningQuantity, 
                SUM(ob.Quantity * ob.Rate) AS OpeningCost
            FROM InventoryOpeningBalance ob
            GROUP BY ob.ItemID
        )
        SELECT 
            sd.TransactionDate, 
            i.ItemID AS [Item Code], 
            i.ItemName AS [Item Name],
            sic.InventoryCategoryID,  
            i.SubCategoryID,  
            i.BrandName AS Brand,  
            ISNULL(sd.TotalSold, 0) AS Quantity, 
            i.MeasurementUnit AS Unit,
            CASE 
                WHEN (ISNULL(pd.TotalPurchased, 0) + ISNULL(obd.OpeningQuantity, 0)) > 0 
                THEN (ISNULL(pd.TotalPurchaseCost, 0) + ISNULL(obd.OpeningCost, 0)) / 
                     (ISNULL(pd.TotalPurchased, 0) + ISNULL(obd.OpeningQuantity, 0))
                ELSE 0 
            END AS UnitCost,
            (CASE 
                WHEN (ISNULL(pd.TotalPurchased, 0) + ISNULL(obd.OpeningQuantity, 0)) > 0 
                THEN (ISNULL(pd.TotalPurchaseCost, 0) + ISNULL(obd.OpeningCost, 0)) / 
                     (ISNULL(pd.TotalPurchased, 0) + ISNULL(obd.OpeningQuantity, 0)) * ISNULL(sd.TotalSold, 0)
                ELSE 0 
            END) AS [Total Cost],
            ISNULL(sd.SalesValue, 0) AS [Sales Value],
            (ISNULL(sd.SalesValue, 0) - 
            (CASE 
                WHEN (ISNULL(pd.TotalPurchased, 0) + ISNULL(obd.OpeningQuantity, 0)) > 0 
                THEN (ISNULL(pd.TotalPurchaseCost, 0) + ISNULL(obd.OpeningCost, 0)) / 
                     (ISNULL(pd.TotalPurchased, 0) + ISNULL(obd.OpeningQuantity, 0)) * ISNULL(sd.TotalSold, 0)
                ELSE 0 
            END)) AS [Profit / (Loss)]
        FROM InventoryItem i
        JOIN SalesData sd ON i.ItemID = sd.ItemID -- ✅ Only include sold items
        LEFT JOIN SubInventoryCategory sic ON i.SubCategoryID = sic.SubCategoryID
        LEFT JOIN PurchaseData pd ON i.ItemID = pd.ItemID
        LEFT JOIN OpeningBalanceData obd ON i.ItemID = obd.ItemID
        WHERE 1=1";  // ✅ Ensures dynamic filters can be added easily

                // Dynamic filtering
                List<SqlParameter> parameters = new List<SqlParameter>
        {
            new SqlParameter("@FinancialYearID", financialYearID)
        };

                if (categoryID.HasValue)
                {
                    query += " AND sic.InventoryCategoryID = @CategoryID";
                    parameters.Add(new SqlParameter("@CategoryID", categoryID.Value));
                }
                if (subCategoryID.HasValue)
                {
                    query += " AND i.SubCategoryID = @SubCategoryID";
                    parameters.Add(new SqlParameter("@SubCategoryID", subCategoryID.Value));
                }
                if (!string.IsNullOrEmpty(brand))
                {
                    query += " AND i.BrandName = @Brand";
                    parameters.Add(new SqlParameter("@Brand", brand));
                }
                if (startDate.HasValue && endDate.HasValue)
                {
                    query += " AND sd.TransactionDate BETWEEN @StartDate AND @EndDate";
                    parameters.Add(new SqlParameter("@StartDate", startDate.Value));
                    parameters.Add(new SqlParameter("@EndDate", endDate.Value));
                }

               
                using (SqlCommand cmd = new SqlCommand(query, dbConnection.connection))
                {
                    cmd.Parameters.AddRange(parameters.ToArray());

                    using (SqlDataAdapter adapter = new SqlDataAdapter(cmd))
                    {
                        adapter.Fill(dataTable);
                    }
                }
                
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error loading profit/loss report: " + ex.Message);
            }
            finally
            {
                dbConnection.closeConnection();
            }
            return dataTable;
        }



        public List<KeyValuePair<int, string>> GetCategories()
        {
            List<KeyValuePair<int, string>> categories = new List<KeyValuePair<int, string>>();

            try
            {
                dbConnection.openConnection();

                string query = "SELECT InventoryCategoryID, CategoryName FROM InventoryCategory";

                using (SqlCommand command = new SqlCommand(query, dbConnection.connection))
                {
                    using (SqlDataReader reader = command.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            int id = Convert.ToInt32(reader["InventoryCategoryID"]);
                            string name = reader["CategoryName"].ToString();
                            categories.Add(new KeyValuePair<int, string>(id, name));
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error loading categories: " + ex.Message);
            }
            finally
            {
                dbConnection.closeConnection();
            }

            return categories;
        }

        public List<KeyValuePair<int, string>> GetSubCategories(int categoryId)
        {
            List<KeyValuePair<int, string>> subCategories = new List<KeyValuePair<int, string>>();

            try
            {
                dbConnection.openConnection();

                string query = "SELECT SubCategoryID, SubCategoryName FROM SubInventoryCategory WHERE InventoryCategoryID = @InventoryCategoryID";

                using (SqlCommand command = new SqlCommand(query, dbConnection.connection))
                {
                    command.Parameters.AddWithValue("@InventoryCategoryID", categoryId);

                    using (SqlDataReader reader = command.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            int id = Convert.ToInt32(reader["SubCategoryID"]);
                            string name = reader["SubCategoryName"].ToString();
                            subCategories.Add(new KeyValuePair<int, string>(id, name));
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error loading subcategories: " + ex.Message);
            }
            finally
            {
                dbConnection.closeConnection();
            }

            return subCategories;
        }

        public List<string> GetBrands()
        {
            List<string> brands = new List<string>();

            try
            {
                dbConnection.openConnection();

                string query = "SELECT BrandName FROM Brand";

                using (SqlCommand command = new SqlCommand(query, dbConnection.connection))
                {
                    using (SqlDataReader reader = command.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            brands.Add(reader["BrandName"].ToString());
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error loading brands: " + ex.Message);
            }
            finally
            {
                dbConnection.closeConnection();
            }

            return brands;
        }



    }
}
