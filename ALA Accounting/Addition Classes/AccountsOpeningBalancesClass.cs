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
    internal class AccountsOpeningBalancessClass
    {
        Connection dbConnection;

        public string openingId {  get; set; }
        public string accountID {  get; set; }
        public string accountName {  get; set; }
        public string debit {  get; set; }
        public string credit { get; set; }
        


        public AccountsOpeningBalancessClass()
        {
            dbConnection = new Connection();
        }


        public void SaveAccountOpeningBalances(AccountsOpeningBalancessClass accountsOpeningBalances, int financialYearID)
        {
            try
            {
                dbConnection.openConnection();

                string query = "INSERT INTO AccountsOpeningBalance (AccountId, AccountName, Debit, Credit, FinancialYearID) " +
                               "VALUES (@AccountId, @AccountName, @Debit, @Credit, @FinancialYearID)";

                using (SqlCommand command = new SqlCommand(query, dbConnection.connection))
                {
                    command.Parameters.AddWithValue("@AccountId", int.Parse(accountsOpeningBalances.accountID));
                    command.Parameters.AddWithValue("@AccountName", accountsOpeningBalances.accountName);

                    // Check if debit is null or empty, then convert it to 0
                    decimal debitValue = string.IsNullOrEmpty(accountsOpeningBalances.debit) ? 0 : decimal.Parse(accountsOpeningBalances.debit);
                    command.Parameters.AddWithValue("@Debit", debitValue);

                    // Check if credit is null or empty, then convert it to 0
                    decimal creditValue = string.IsNullOrEmpty(accountsOpeningBalances.credit) ? 0 : decimal.Parse(accountsOpeningBalances.credit);
                    command.Parameters.AddWithValue("@Credit", creditValue);

                    command.Parameters.AddWithValue("@FinancialYearID", financialYearID);

                    command.ExecuteNonQuery();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error saving Account opening balance: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally
            {
                dbConnection.closeConnection();
            }
        }


        public AccountsOpeningBalancessClass GetOpeningBalanceDetails(int openingId)
        {
            AccountsOpeningBalancessClass openingBalance = null; // Initialize object as null

            try
            {
                dbConnection.openConnection();

                string query = "SELECT AccountId, AccountName, Debit, Credit, FinancialYearID " +
                               "FROM AccountsOpeningBalance WHERE OpeningId = @OpeningId";

                using (SqlCommand command = new SqlCommand(query, dbConnection.connection))
                {
                    command.Parameters.AddWithValue("@OpeningId", openingId);

                    using (SqlDataReader reader = command.ExecuteReader())
                    {
                        if (reader.Read()) // If data exists
                        {
                            openingBalance = new AccountsOpeningBalancessClass
                            {
                                accountID = reader["AccountId"].ToString(),
                                accountName = reader["AccountName"].ToString(),
                                debit = reader["Debit"] != DBNull.Value ? reader["Debit"].ToString() : "0",
                                credit = reader["Credit"] != DBNull.Value ? reader["Credit"].ToString() : "0",
                                //financialYearID = Convert.ToInt32(reader["FinancialYearID"])
                            };
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error retrieving account opening balance: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally
            {
                dbConnection.closeConnection();
            }

            return openingBalance; // Return the object
        }




        public void UpdateAccountOpeningBalances(AccountsOpeningBalancessClass accountsOpeningBalances)
        {
            try
            {
                dbConnection.openConnection();

                string query = "UPDATE AccountsOpeningBalance SET AccountId = @AccountId, AccountName = @AccountName, Debit = @Debit, Credit = @Credit WHERE OpeningId = @OpeningId";
                using (SqlCommand command = new SqlCommand(query, dbConnection.connection))
                {
                    command.Parameters.AddWithValue("@AccountId", int.Parse(accountsOpeningBalances.accountID));
                    command.Parameters.AddWithValue("@AccountName", accountsOpeningBalances.accountName);

                    // Check if debit is null or empty, then convert it to 0
                    decimal debitValue = string.IsNullOrEmpty(accountsOpeningBalances.debit) ? 0 : decimal.Parse(accountsOpeningBalances.debit);
                    command.Parameters.AddWithValue("@Debit", debitValue);

                    // Check if credit is null or empty, then convert it to 0
                    decimal creditValue = string.IsNullOrEmpty(accountsOpeningBalances.credit) ? 0 : decimal.Parse(accountsOpeningBalances.credit);
                    command.Parameters.AddWithValue("@Credit", creditValue);

                    command.Parameters.AddWithValue("@OpeningId", accountsOpeningBalances.openingId);

                    command.ExecuteNonQuery();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error updating account opening balance: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally
            {
                dbConnection.closeConnection();
            }
        }



        public void DeleteAccountsOpeningBalances(int accountsOpeningBalancesID)
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

                    string query = "DELETE FROM AccountsOpeningBalance WHERE openingId = @openingID";

                    using (SqlCommand command = new SqlCommand(query, dbConnection.connection))
                    {
                        command.Parameters.AddWithValue("@openingId", accountsOpeningBalancesID);

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



        public void LoadAccountsOpeningBalances(DataGridView dataGridView, int financialYearId)
        {
            try
            {
                dbConnection.openConnection();

                string query = "SELECT OpeningId, AccountID, AccountName, Debit, Credit " +
                       "FROM AccountsOpeningBalance " +
                       "WHERE FinancialYearID = @FinancialYearID " +
                       "ORDER BY OpeningId DESC";

                using (SqlCommand command = new SqlCommand(query, dbConnection.connection))
                {
                    command.Parameters.AddWithValue("@FinancialYearID", financialYearId);

                    using (SqlDataAdapter adapter = new SqlDataAdapter(command))
                    {
                        DataTable dataTable = new DataTable();
                        adapter.Fill(dataTable);

                        

                        // Clear the DataGridView before loading new data
                        dataGridView.Rows.Clear();

                        // Loop through the DataTable and add data to the DataGridView
                        foreach (DataRow row in dataTable.Rows)
                        {
                            int rowIndex = dataGridView.Rows.Add();
                            DataGridViewRow dataGridViewRow = dataGridView.Rows[rowIndex];

                            dataGridViewRow.Cells["AccountsOpeningBalanceID"].Value = row["OpeningId"];
                            dataGridViewRow.Cells["AccountID"].Value = row["AccountID"];
                            dataGridViewRow.Cells["AccountName"].Value = row["AccountName"];
                            dataGridViewRow.Cells["Debit"].Value = row["Debit"];
                            dataGridViewRow.Cells["Credit"].Value = row["Credit"];
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error loading account opening balances: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally
            {
                dbConnection.closeConnection();
            }
        }



        public bool RecordExists(string accountsOpeningBalancesID)
        {

            bool exists = false;
            try
            {
                dbConnection.openConnection();

                string query = "SELECT COUNT(*) FROM AccountsOpeningBalance WHERE OpeningId = @OpeningId";
                using (SqlCommand command = new SqlCommand(query, dbConnection.connection))
                {
                    command.Parameters.AddWithValue("@OpeningId", accountsOpeningBalancesID);

                    int count = (int)command.ExecuteScalar();
                    exists = count > 0;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error checking if record exists: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }
            finally
            {
                dbConnection.closeConnection();
            }

            return exists;
        }


        public int GetNextAvailableAccountsOpeningBalancesID()
        {
            try
            {
                dbConnection.openConnection();

                string query = "SELECT ISNULL(MAX(OpeningId), 0) + 1 FROM AccountsOpeningBalance";
                using (SqlCommand command = new SqlCommand(query, dbConnection.connection))
                {
                    int nextId = (int)command.ExecuteScalar();
                    return nextId;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error getting next available ID: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return 0;
            }
            finally
            {
                dbConnection.closeConnection();
            }
        }

    }
}
