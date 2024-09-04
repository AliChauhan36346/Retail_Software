using ALA_Accounting.transaction_classes;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ALA_Accounting.Addition_Classes
{
    internal class Accounts
    {
        Connection dbConnection;

        public string accountId {  get; set; }
        public string accountName {  get; set; }
        public string subAccountTypeId {  get; set; }
        public bool isSystemAccount  {  get; set; }

        public Accounts()
        {
            dbConnection = new Connection();
        }

        public void SaveAccount(Accounts saveAccount)
        {
            try
            {
                dbConnection.openConnection();

                string query = "INSERT INTO Accounts (AccountName, SubAccountTypeID, IsSystemAccount) " +
                               "VALUES (@AccountName, @SubAccountTypeID, @IsSystemAccount)";

                using (SqlCommand command = new SqlCommand(query, dbConnection.connection))
                {
                    command.Parameters.AddWithValue("@AccountName", saveAccount.accountName);
                    command.Parameters.AddWithValue("@SubAccountTypeID", saveAccount.subAccountTypeId);
                    command.Parameters.AddWithValue("@IsSystemAccount", saveAccount.isSystemAccount);

                    command.ExecuteNonQuery();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("اکاؤنٹ محفوظ کرتے ہوئے خرابی ہوگئی: " + ex.Message);
            }
            finally
            {
                dbConnection.closeConnection();
            }
        }

        public void UpdateAccount(Accounts updateAccount)
        {
            try
            {
                dbConnection.openConnection();

                string query = "UPDATE Accounts SET AccountName = @AccountName, SubAccountTypeID = @SubAccountTypeID, " +
                               "IsSystemAccount = @IsSystemAccount WHERE AccountID = @AccountID";

                using (SqlCommand command = new SqlCommand(query, dbConnection.connection))
                {
                    command.Parameters.AddWithValue("@AccountName", updateAccount.accountName);
                    command.Parameters.AddWithValue("@SubAccountTypeID", updateAccount.subAccountTypeId);
                    command.Parameters.AddWithValue("@IsSystemAccount", updateAccount.isSystemAccount);
                    command.Parameters.AddWithValue("@AccountID", updateAccount.accountId);

                    command.ExecuteNonQuery();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("اکاؤنٹ کو اپ ڈیٹ کرتے ہوئے خرابی ہوگئی: " + ex.Message);
            }
            finally
            {
                dbConnection.closeConnection();
            }
        }

        public void DeleteAccount(string accountId)
        {
            try
            {
                dbConnection.openConnection();

                string query = "DELETE FROM Accounts WHERE AccountID = @AccountID";

                using (SqlCommand command = new SqlCommand(query, dbConnection.connection))
                {
                    command.Parameters.AddWithValue("@AccountID", accountId);

                    command.ExecuteNonQuery();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("اکاؤنٹ کو حذف کرتے ہوئے خرابی ہوگئی: " + ex.Message);
            }
            finally
            {
                dbConnection.closeConnection();
            }
        }

        public List<string> LoadAccountNamesBySubAccountTypeId(string subAccountTypeId)
        {
            List<string> accountNames = new List<string>();

            try
            {
                dbConnection.openConnection();

                string query = "SELECT AccountName FROM Accounts WHERE SubAccountTypeID = @SubAccountTypeID";

                using (SqlCommand command = new SqlCommand(query, dbConnection.connection))
                {
                    command.Parameters.AddWithValue("@SubAccountTypeID", subAccountTypeId);

                    using (SqlDataReader reader = command.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            accountNames.Add(reader["AccountName"].ToString());
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("اکاؤنٹس لوڈ کرتے ہوئے خرابی ہوگئی: " + ex.Message);
            }
            finally
            {
                dbConnection.closeConnection();
            }

            return accountNames;
        }

        public int GetNextAccountId()
        {
            int nextMainAccountId = 0;

            try
            {
                dbConnection.openConnection();

                // Query to get the maximum MainAccountID from the database
                string query = "SELECT ISNULL(MAX(AccountID), 0) + 1 FROM Accounts";

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

        public int GetAccountIdByName(string name)
        {
            int subAccountId = -1;

            try
            {
                dbConnection.openConnection();

                string query = "SELECT AccountID FROM Accounts WHERE AccountName=@AccountName";

                using (SqlCommand command = new SqlCommand(query, dbConnection.connection))
                {
                    command.Parameters.AddWithValue("@AccountName", name);

                    subAccountId = Convert.ToInt32(command.ExecuteScalar());
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("اکاؤنٹ کا ID حاصل کرتے ہوئے خرابی ہوگئی: " + ex.Message, "خرابی", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally
            {
                dbConnection.closeConnection();
            }

            return subAccountId;
        }



    }
}
