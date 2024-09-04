using ALA_Accounting.transaction_classes;
using System;
using System.Collections.Generic;
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
        public string Name {  get; set; }
        public string quantity {  get; set; }
        public string unit {  get; set; }
        public string rate {  get; set; }

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


        public void UpdateInventoryOpeningBalance(AddInventoryOpeningBalances openingBalance, int financialYearID, int openingBalanceID)
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
                    command.Parameters.AddWithValue("@OpeningBalanceID", openingBalanceID);

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
                MessageBox.Show("Error deleting inventory opening balance: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally
            {
                dbConnection.closeConnection();
            }
        }



    }
}
