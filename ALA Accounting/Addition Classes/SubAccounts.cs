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
    public class SubAccounts
    {

        Connection dbConnection;


        public string SubAccountTypeId { get; set; }
        public string SubAccountTypeName { get; set; }
        public string MainAccountID { get; set; }
        public bool IsSystemAccount { get; set; }

        public SubAccounts()
        {
            dbConnection = new Connection();
        }


        public void SaveSubAccount(SubAccounts saveSubAccount)
        {
            try
            {
                dbConnection.openConnection();

                string query = "INSERT INTO SubAccounts (SubAccountTypeName, MainAccountID, IsSystemAccount) " +
                "VALUES (@SubAccountTypeName, @MainAccountID, @IsSystemAccount)";

                using (SqlCommand command = new SqlCommand(query, dbConnection.connection))
                {
                    command.Parameters.AddWithValue("@SubAccountTypeName", saveSubAccount.SubAccountTypeName);
                    command.Parameters.AddWithValue("@MainAccountID", saveSubAccount.MainAccountID);
                    command.Parameters.AddWithValue("@IsSystemAccount", saveSubAccount.IsSystemAccount);

                    command.ExecuteNonQuery();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("ذیلی اکاؤنٹ محفوظ کرتے ہوئے خرابی ہوگئی: " + ex.Message);
            }
            finally
            {
                dbConnection.closeConnection();
            }
        }


        public void UpdateSubAccount(SubAccounts updateSubAccount)
        {
            try
            {
                dbConnection.openConnection();

                string query = "UPDATE SubAccounts SET SubAccountTypeName = @SubAccountTypeName, MainAccountID = @MainAccountID, " +
                               "IsSystemAccount = @IsSystemAccount WHERE SubAccountTypeID = @SubAccountTypeID AND IsSystemAccount='0'";

                using (SqlCommand command = new SqlCommand(query, dbConnection.connection))
                {
                    command.Parameters.AddWithValue("@SubAccountTypeName", updateSubAccount.SubAccountTypeName);
                    command.Parameters.AddWithValue("@MainAccountID", updateSubAccount.MainAccountID);
                    command.Parameters.AddWithValue("@IsSystemAccount", updateSubAccount.IsSystemAccount);
                    command.Parameters.AddWithValue("@SubAccountTypeID", updateSubAccount.SubAccountTypeId);

                    command.ExecuteNonQuery();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("ذیلی اکاؤنٹ اپ ڈیٹ کرتے ہوئے خرابی ہوگئی: " + ex.Message);
            }
            finally
            {
                dbConnection.closeConnection();
            }
        }


        public void DeleteSubAccount(int subAccountTypeId)
        {
            try
            {
                dbConnection.openConnection();

                string query = "DELETE FROM SubAccounts WHERE SubAccountTypeID = @SubAccountTypeID AND IsSystemAccount='0'";

                using (SqlCommand command = new SqlCommand(query, dbConnection.connection))
                {
                    command.Parameters.AddWithValue("@SubAccountTypeID", subAccountTypeId);

                    command.ExecuteNonQuery();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("ذیلی اکاؤنٹ حذف کرتے ہوئے خرابی ہوگئی: " + ex.Message);
            }
            finally
            {
                dbConnection.closeConnection();
            }
        }

        public List<string> LoadSubAccountNamesByMainAccountId(string mainAccountId)
        {
            List<string> subAccountNames = new List<string>();

            try
            {
                dbConnection.openConnection();

                string query = "SELECT SubAccountTypeName FROM SubAccounts WHERE MainAccountID = @MainAccountID";

                using (SqlCommand command = new SqlCommand(query, dbConnection.connection))
                {
                    command.Parameters.AddWithValue("@MainAccountID", mainAccountId);

                    using (SqlDataReader reader = command.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            subAccountNames.Add(reader["SubAccountTypeName"].ToString());
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("ذیلی اکاؤنٹس لوڈ کرتے ہوئے خرابی ہوگئی: " + ex.Message);
            }
            finally
            {
                dbConnection.closeConnection();
            }

            return subAccountNames;
        }

        public int GetNextSubAccountId()
        {
            int nextMainAccountId = 0;

            try
            {
                dbConnection.openConnection();

                // Query to get the maximum MainAccountID from the database
                string query = "SELECT ISNULL(MAX(SubAccountTypeID), 0) + 1 FROM SubAccounts";

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

        public int GetSubAccountIdByName(string name)
        {
            int subAccountId = -1;

            try
            {
                dbConnection.openConnection();

                string query = "SELECT subAccountTypeID FROM SubAccounts WHERE SubAccountTypeName=@SubAccountTypeName";

                using(SqlCommand command=new SqlCommand(query, dbConnection.connection))
                {
                    command.Parameters.AddWithValue("@SubAccountTypeName", name);

                    subAccountId = Convert.ToInt32(command.ExecuteScalar());
                }
            }
            catch(Exception ex)
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
