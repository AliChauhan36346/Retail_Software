using ALA_Accounting.transaction_classes;
using ALA_Accounting.UsersForm;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Common;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ALA_Accounting.Addition_Classes
{
    internal class AddInventoryOpeningBalances
    {
        Connection dbConnection;

        public string itemId {  get; set; }
        public string openingId {  get; set; }
        public string Name {  get; set; }
        public string quantity {  get; set; }
        public string unit {  get; set; }
        public string rate {  get; set; }

        public AddInventoryOpeningBalances()
        {
            dbConnection = new Connection();
        }

        public void SaveInventoryOpeningBalance(AddInventoryOpeningBalances openingBalance, int financialYearID)
        {
            try
            {
                dbConnection.openConnection();

                string query = "INSERT INTO InventoryOpeningBalance (ItemID, FinancialYearID, Quantity, Unit, Rate) " +
                               "VALUES (@ItemID, @FinancialYearID, @Quantity, @Unit, @Rate)";

                using (SqlCommand command = new SqlCommand(query, dbConnection.connection))
                {
                    command.Parameters.AddWithValue("@ItemID", openingBalance.itemId);
                    command.Parameters.AddWithValue("@FinancialYearID", financialYearID);
                    command.Parameters.AddWithValue("@Quantity", Convert.ToDecimal(openingBalance.quantity));
                    command.Parameters.AddWithValue("@Unit", openingBalance.unit);
                    command.Parameters.AddWithValue("@Rate", Convert.ToDecimal(openingBalance.rate));

                    command.ExecuteNonQuery();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error saving inventory opening balance: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally
            {
                dbConnection.closeConnection();
            }
        }


        public void UpdateInventoryOpeningBalance(AddInventoryOpeningBalances openingBalance, int financialYearID)
        {
            try
            {
                dbConnection.openConnection();

                string query = "UPDATE InventoryOpeningBalance SET ItemID = @ItemID, FinancialYearID = @FinancialYearID, " +
                               "Quantity = @Quantity, Unit = @Unit, Rate = @Rate WHERE OpeningBalanceID = @OpeningBalanceID";

                using (SqlCommand command = new SqlCommand(query, dbConnection.connection))
                {
                    command.Parameters.AddWithValue("@ItemID", openingBalance.itemId);
                    command.Parameters.AddWithValue("@FinancialYearID", financialYearID);
                    command.Parameters.AddWithValue("@Quantity", Convert.ToDecimal(openingBalance.quantity));
                    command.Parameters.AddWithValue("@Unit", openingBalance.unit);
                    command.Parameters.AddWithValue("@Rate", Convert.ToDecimal(openingBalance.rate));
                    command.Parameters.AddWithValue("@OpeningBalanceID", openingBalance.openingId);

                    command.ExecuteNonQuery();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error updating inventory opening balance: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally
            {
                dbConnection.closeConnection();
            }
        }


        public void DeleteInventoryOpeningBalance(int openingBalanceID)
        {
            // Ask the user for confirmation before deleting
            DialogResult result = MessageBox.Show(
                "کیا آپ واقعی اس ریکارڈ کو حذف کرنا چاہتے ہیں؟",
                "تصدیق",
                MessageBoxButtons.YesNo,
                MessageBoxIcon.Warning
            );

            // If the user confirms, proceed with the deletion
            if (result == DialogResult.Yes)
            {
                try
                {
                    dbConnection.openConnection();

                    string query = "DELETE FROM InventoryOpeningBalance WHERE OpeningBalanceID = @OpeningBalanceID";

                    using (SqlCommand command = new SqlCommand(query, dbConnection.connection))
                    {
                        command.Parameters.AddWithValue("@OpeningBalanceID", openingBalanceID);

                        command.ExecuteNonQuery();
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("انوینٹری اوپننگ بیلنس کو حذف کرتے ہوئے خرابی: " + ex.Message, "خرابی", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                finally
                {
                    dbConnection.closeConnection();
                }
            }
        }



        public void LoadInventoryOpeningBalances(DataGridView dataGridView, int financialYearId, out decimal totalOpeningValue)
        {
            totalOpeningValue = 0;

            try
            {
                dbConnection.openConnection();
                string query = "SELECT OpeningBalanceID, ItemID, (SELECT ItemName FROM InventoryItem WHERE InventoryItem.ItemID = InventoryOpeningBalance.ItemID) AS ItemName, Quantity, Unit, Rate, Amount " +
                                "FROM InventoryOpeningBalance WHERE FinancialYearID = @FinancialYearID  ORDER BY OpeningBalanceId DESC";

                using (SqlCommand command = new SqlCommand(query, dbConnection.connection))
                {
                    command.Parameters.AddWithValue("@FinancialYearID", financialYearId);

                    SqlDataAdapter adapter = new SqlDataAdapter(command);
                    DataTable dt = new DataTable();
                    adapter.Fill(dt);

                    

                    // Clear the DataGridView before loading new data
                    dataGridView.Rows.Clear();

                    // Loop through the DataTable and add data to the existing columns
                    foreach (DataRow row in dt.Rows)
                    {
                        int rowIndex = dataGridView.Rows.Add();
                        DataGridViewRow dataGridViewRow = dataGridView.Rows[rowIndex];

                        dataGridViewRow.Cells["OpeningBalanceID"].Value = row["OpeningBalanceID"];
                        dataGridViewRow.Cells["itemId"].Value = row["ItemID"];
                        dataGridViewRow.Cells["itemName"].Value = row["ItemName"];
                        dataGridViewRow.Cells["quantity"].Value = row["Quantity"];
                        dataGridViewRow.Cells["unit"].Value = row["Unit"];
                        dataGridViewRow.Cells["rate"].Value = row["Rate"];
                        dataGridViewRow.Cells["amount"].Value = row["Amount"];

                        totalOpeningValue += Convert.ToDecimal(row["Amount"].ToString());
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error loading inventory opening balances: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally
            {
                dbConnection.closeConnection();
            }

            totalOpeningValue = Math.Round(totalOpeningValue, 2);
        }


        public (string rate, string unit) GetItemDetails(string itemId)
        {
            string rate = string.Empty;
            string unit = string.Empty;

            try
            {
                dbConnection.openConnection();
                string query = "SELECT PurchasePrice, MeasurementUnit FROM InventoryItem WHERE ItemID = @ItemID";

                using (SqlCommand command = new SqlCommand(query, dbConnection.connection))
                {
                    command.Parameters.AddWithValue("@ItemID", itemId);

                    using (SqlDataReader reader = command.ExecuteReader())
                    {
                        if (reader.Read())
                        {
                            rate = reader["PurchasePrice"].ToString();
                            unit = reader["MeasurementUnit"].ToString();
                        }
                        else
                        {
                            MessageBox.Show("Item not found.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error retrieving item details: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally
            {
                dbConnection.closeConnection();
            }

            return (rate, unit);
        }

        public bool RecordExists(string openingBalanceID)
        {
            bool exists = false;
            try
            {
                dbConnection.openConnection();
                string query = "SELECT COUNT(1) FROM InventoryOpeningBalance WHERE OpeningBalanceID = @OpeningBalanceID";

                using (SqlCommand command = new SqlCommand(query, dbConnection.connection))
                {
                    command.Parameters.AddWithValue("@OpeningBalanceID", openingBalanceID);

                    // ExecuteScalar returns the first column of the first row in the result set
                    int count = Convert.ToInt32(command.ExecuteScalar());
                    exists = count > 0;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error checking record existence: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally
            {
                dbConnection.closeConnection();
            }

            return exists;
        }

        public int GetNextAvailableOpeningBalanceID()
        {
            int nextID = 1; // Default starting ID

            try
            {
                dbConnection.openConnection();
                string query = "SELECT ISNULL(MAX(OpeningBalanceID), 0) + 1 FROM InventoryOpeningBalance";

                using (SqlCommand command = new SqlCommand(query, dbConnection.connection))
                {
                    nextID = (int)command.ExecuteScalar();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error retrieving the next available OpeningBalanceID: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally
            {
                dbConnection.closeConnection();
            }

            return nextID;
        }



    }
}
