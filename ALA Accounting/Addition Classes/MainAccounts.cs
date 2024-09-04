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
    public class MainAccounts
    {
        Connection dbConnection;

        public string mainAccountId { get; set; }
        public string MainAccountName { get; set; }
        public string MainAccountNameUrdu { get; set; }
        public string FinancialStatementComponent { get; set; }
        public bool IsSystemAccount { get; set; }




        public MainAccounts()
        {
            dbConnection = new Connection();
        }

        public void SaveMainAccount(MainAccounts saveMainAccount)
        {
            try
            {
                dbConnection.openConnection();

                string query = "INSERT INTO MainAccounts (MainAccountName, FinancialStatementComponent, IsSystemAccount) " +
                               "VALUES (@MainAccountName, @FinancialStatementComponent, @IsSystemAccount)";

                using (SqlCommand command = new SqlCommand(query, dbConnection.connection))
                {
                    command.Parameters.AddWithValue("@MainAccountName", saveMainAccount.MainAccountName);
                    
                    command.Parameters.AddWithValue("@FinancialStatementComponent", saveMainAccount.FinancialStatementComponent);
                    command.Parameters.AddWithValue("@IsSystemAccount", saveMainAccount.IsSystemAccount);

                    command.ExecuteNonQuery();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("مین اکاؤنٹ محفوظ کرتے ہوئے خرابی ہوگئی: " + ex.Message);
            }
            finally
            {
                dbConnection.closeConnection();
            }
        }

        public void UpdateMainAccount(MainAccounts updateMainAccount)
        {
            try
            {
                dbConnection.openConnection();

                string query = "UPDATE MainAccounts SET MainAccountName = @MainAccountName, " +
                               "FinancialStatementComponent = @FinancialStatementComponent, IsSystemAccount = @IsSystemAccount " +
                               "WHERE MainAccountID = @MainAccountID";

                using (SqlCommand command = new SqlCommand(query, dbConnection.connection))
                {
                    command.Parameters.AddWithValue("@MainAccountName", updateMainAccount.MainAccountName);
                    
                    command.Parameters.AddWithValue("@FinancialStatementComponent", updateMainAccount.FinancialStatementComponent);
                    command.Parameters.AddWithValue("@IsSystemAccount", updateMainAccount.IsSystemAccount);
                    command.Parameters.AddWithValue("@MainAccountID", updateMainAccount.mainAccountId);

                    command.ExecuteNonQuery();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("مین اکاؤنٹ اپ ڈیٹ کرتے ہوئے خرابی ہوگئی: " + ex.Message);
            }
            finally
            {
                dbConnection.closeConnection();
            }
        }


        public void DeleteMainAccount(string mainAccountId)
        {
            try
            {
                dbConnection.openConnection();

                string query = "DELETE FROM MainAccounts WHERE MainAccountID = @MainAccountID";

                using (SqlCommand command = new SqlCommand(query, dbConnection.connection))
                {
                    command.Parameters.AddWithValue("@MainAccountID", mainAccountId);

                    command.ExecuteNonQuery();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("مین اکاؤنٹ حذف کرتے ہوئے خرابی ہوگئی: " + ex.Message);
            }
            finally
            {
                dbConnection.closeConnection();
            }
        }

        public List<string> LoadMainAccountNames()
        {
            List<string> mainAccountNames = new List<string>();

            try
            {
                dbConnection.openConnection();

                string query = "SELECT MainAccountName FROM MainAccounts";

                using (SqlCommand command = new SqlCommand(query, dbConnection.connection))
                {
                    using (SqlDataReader reader = command.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            mainAccountNames.Add(reader["MainAccountName"].ToString());
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("مین اکاؤنٹس لوڈ کرتے ہوئے خرابی ہوگئی: " + ex.Message);
            }
            finally
            {
                dbConnection.closeConnection();
            }

            return mainAccountNames;
        }

        public (int MainAccountId, string FinancialStatementComponent) GetMainAccountDetailsByName(string mainAccountName)
        {
            int mainAccountId = 0;
            string financialStatementComponent = string.Empty;

            try
            {
                dbConnection.openConnection();

                string query = "SELECT MainAccountID, FinancialStatementComponent FROM MainAccounts WHERE MainAccountName=@MainAccountName";

                using (SqlCommand command = new SqlCommand(query, dbConnection.connection))
                {
                    command.Parameters.AddWithValue("@MainAccountName", mainAccountName);

                    using (SqlDataReader reader = command.ExecuteReader())
                    {
                        if (reader.Read())
                        {
                            mainAccountId = Convert.ToInt32(reader["MainAccountID"]);
                            financialStatementComponent = reader["FinancialStatementComponent"].ToString();
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                // Display an error message in Urdu
                MessageBox.Show("مین اکاؤنٹ کی تفصیلات حاصل کرتے ہوئے خرابی ہوگئی: " + ex.Message, "خرابی", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally
            {
                dbConnection.closeConnection();
            }

            return (mainAccountId, financialStatementComponent);
        }


        public int GetNextMainAccountId()
        {
            int nextMainAccountId = 0;

            try
            {
                dbConnection.openConnection();

                // Query to get the maximum MainAccountID from the database
                string query = "SELECT ISNULL(MAX(MainAccountID), 0) + 1 FROM MainAccounts";

                using (SqlCommand command = new SqlCommand(query, dbConnection.connection))
                {
                    // Execute the query and get the next MainAccountID
                    nextMainAccountId = Convert.ToInt32(command.ExecuteScalar());
                }
            }
            catch (Exception ex)
            {
                // Display an error message in Urdu
                MessageBox.Show("اگلا مین اکاؤنٹ ID حاصل کرتے ہوئے خرابی ہوگئی: " + ex.Message, "خرابی", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally
            {
                dbConnection.closeConnection();
            }

            return nextMainAccountId;
        }

    }
}
