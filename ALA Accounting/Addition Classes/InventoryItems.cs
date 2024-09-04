using ALA_Accounting.Addition;
using ALA_Accounting.transaction_classes;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ALA_Accounting.Addition_Classes
{
    internal class InventoryItems
    {
        Connection dbConnection;

        public string itemId {  get; set; }
        public string itemName {  get; set; }
        public string itemDiscription {  get; set; }
        public string brandName {  get; set; }
        public string rackNo {  get; set; }
        public string purchasePrice {  get; set; }
        public string salePrice {  get; set; }
        public string measurmentUnit {  get; set; }
        public string reOrderQuantity {  get; set; }
        public string subCatagoryId {  get; set; }

        public InventoryItems()
        {
            dbConnection = new Connection();
        }


        public void SaveInventoryItem(InventoryItems item)
        {
            try
            {
                dbConnection.openConnection();

                string query = @"
            INSERT INTO InventoryItem 
            (ItemID, SubCategoryId, ItemName, ItemDescription, BrandName, PurchasePrice, 
            SellingPrice, MeasurementUnit, ReOrderQuantity, RackNo) 
            VALUES 
            (@ItemID, @SubCategoryId, @ItemName, @ItemDescription, @BrandName, @PurchasePrice, 
            @SellingPrice, @MeasurementUnit, @ReOrderQuantity, @RackNo)";

                using (SqlCommand command = new SqlCommand(query, dbConnection.connection))
                {
                    command.Parameters.AddWithValue("@ItemID", item.itemId);
                    command.Parameters.AddWithValue("@SubCategoryId", item.subCatagoryId);
                    command.Parameters.AddWithValue("@ItemName", item.itemName);
                    command.Parameters.AddWithValue("@ItemDescription", item.itemDiscription);
                    command.Parameters.AddWithValue("@BrandName", item.brandName);
                    command.Parameters.AddWithValue("@PurchasePrice", item.purchasePrice ?? (object)DBNull.Value);
                    command.Parameters.AddWithValue("@SellingPrice", item.salePrice ?? (object)DBNull.Value);
                    command.Parameters.AddWithValue("@MeasurementUnit", item.measurmentUnit);
                    command.Parameters.AddWithValue("@ReOrderQuantity", item.reOrderQuantity ?? (object)DBNull.Value);
                    command.Parameters.AddWithValue("@RackNo", item.rackNo);

                    command.ExecuteNonQuery();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("آئٹم محفوظ کرتے وقت خرابی: " + ex.Message, "خرابی", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally
            {
                dbConnection.closeConnection();
            }
        }


        public void UpdateInventoryItem(InventoryItems item)
        {
            try
            {
                dbConnection.openConnection();

                string query = @"
            UPDATE InventoryItem 
            SET ItemName = @ItemName, 
                ItemDescription = @ItemDescription, 
                BrandName = @BrandName, 
                PurchasePrice = @PurchasePrice, 
                SellingPrice = @SellingPrice, 
                MeasurementUnit = @MeasurementUnit, 
                ReOrderQuantity = @ReOrderQuantity, 
                RackNo = @RackNo 
            WHERE ItemID = @ItemID";

                using (SqlCommand command = new SqlCommand(query, dbConnection.connection))
                {
                    command.Parameters.AddWithValue("@ItemID", item.itemId);
                    command.Parameters.AddWithValue("@ItemName", item.itemName);
                    command.Parameters.AddWithValue("@ItemDescription", item.itemDiscription);
                    command.Parameters.AddWithValue("@BrandName", item.brandName);
                    command.Parameters.AddWithValue("@PurchasePrice", item.purchasePrice ?? (object)DBNull.Value);
                    command.Parameters.AddWithValue("@SellingPrice", item.salePrice ?? (object)DBNull.Value);
                    command.Parameters.AddWithValue("@MeasurementUnit", item.measurmentUnit);
                    command.Parameters.AddWithValue("@ReOrderQuantity", item.reOrderQuantity ?? (object)DBNull.Value);
                    command.Parameters.AddWithValue("@RackNo", item.rackNo);

                    command.ExecuteNonQuery();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("آئٹم اپ ڈیٹ کرتے وقت خرابی: " + ex.Message, "خرابی", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally
            {
                dbConnection.closeConnection();
            }
        }


        public void DeleteInventoryItem(string itemId)
        {
            try
            {
                dbConnection.openConnection();

                string query = "DELETE FROM InventoryItem WHERE ItemID = @ItemID";

                using (SqlCommand command = new SqlCommand(query, dbConnection.connection))
                {
                    command.Parameters.AddWithValue("@ItemID", itemId);

                    command.ExecuteNonQuery();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("آئٹم حذف کرتے وقت خرابی: " + ex.Message, "خرابی", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally
            {
                dbConnection.closeConnection();
            }
        }


        public void LoadItemsIntoListBox(ListBox listBox, string subCategoryId)
        {
            try
            {
                dbConnection.openConnection();

                string query = "SELECT ItemID, ItemName FROM InventoryItem WHERE SubCategoryID = @SubCategoryID";

                using (SqlCommand command = new SqlCommand(query, dbConnection.connection))
                {
                    command.Parameters.AddWithValue("@SubCategoryID", subCategoryId);

                    SqlDataReader reader = command.ExecuteReader();
                    listBox.Items.Clear();

                    while (reader.Read())
                    {
                        ListBoxItem item = new ListBoxItem
                        {
                            ItemID = reader["ItemID"].ToString(),
                            ItemName = reader["ItemName"].ToString()
                        };
                        listBox.Items.Add(item);
                    }

                    reader.Close();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("آئٹم لوڈ کرتے وقت خرابی: " + ex.Message, "خرابی", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally
            {
                dbConnection.closeConnection();
            }
        }



        public InventoryItems GetItemDetailsById(string itemId)
        {
            InventoryItems item = null;

            try
            {
                dbConnection.openConnection();

                string query = @"
            SELECT ItemID, ItemName, ItemDescription, BrandName, PurchasePrice, 
                   SellingPrice, MeasurementUnit, ReOrderQuantity, RackNo
            FROM InventoryItem
            WHERE ItemID = @ItemID";

                using (SqlCommand command = new SqlCommand(query, dbConnection.connection))
                {
                    command.Parameters.AddWithValue("@ItemID", itemId);

                    SqlDataReader reader = command.ExecuteReader();

                    if (reader.Read())
                    {
                        item = new InventoryItems
                        {
                            itemId = reader["ItemID"].ToString(),
                            itemName = reader["ItemName"].ToString(),
                            itemDiscription = reader["ItemDescription"].ToString(),
                            brandName = reader["BrandName"].ToString(),
                            purchasePrice = reader["PurchasePrice"].ToString(),
                            salePrice = reader["SellingPrice"].ToString(),
                            measurmentUnit = reader["MeasurementUnit"].ToString(),
                            reOrderQuantity = reader["ReOrderQuantity"].ToString(),
                            rackNo = reader["RackNo"].ToString()
                        };
                    }

                    reader.Close();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("آئٹم کی تفصیلات حاصل کرتے وقت خرابی: " + ex.Message, "خرابی", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally
            {
                dbConnection.closeConnection();
            }

            return item;
        }


    }
}
