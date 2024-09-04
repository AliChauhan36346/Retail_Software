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
    public class subInventoryCatagory
    {
        Connection dbConnection;


        public subInventoryCatagory()
        {
            dbConnection = new Connection();
        }

        public void SaveSubInventoryCategory(int categoryId, string subCategoryName)
        {
            try
            {
                dbConnection.openConnection();

                string query = "INSERT INTO SubInventoryCategory (InventoryCategoryID, SubCategoryName) VALUES (@CategoryID, @SubCategoryName)";

                using (SqlCommand command = new SqlCommand(query, dbConnection.connection))
                {
                    command.Parameters.AddWithValue("@CategoryID", categoryId);
                    command.Parameters.AddWithValue("@SubCategoryName", subCategoryName);
                    command.ExecuteNonQuery();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("سب کیٹیگری محفوظ کرتے ہوئے خرابی ہوگئی: " + ex.Message, "خرابی", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally
            {
                dbConnection.closeConnection();
            }
        }


        public void UpdateSubInventoryCategory(int subCategoryId, string subCategoryName)
        {
            try
            {
                dbConnection.openConnection();

                string query = "UPDATE SubInventoryCategory SET SubCategoryName = @SubCategoryName WHERE SubCategoryID = @SubCategoryID";

                using (SqlCommand command = new SqlCommand(query, dbConnection.connection))
                {
                    command.Parameters.AddWithValue("@SubCategoryID", subCategoryId);
                    command.Parameters.AddWithValue("@SubCategoryName", subCategoryName);
                    command.ExecuteNonQuery();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("سب کیٹیگری اپ ڈیٹ کرتے ہوئے خرابی ہوگئی: " + ex.Message, "خرابی", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally
            {
                dbConnection.closeConnection();
            }
        }


        public void DeleteSubInventoryCategory(int subCategoryId)
        {
            try
            {
                dbConnection.openConnection();

                string query = "DELETE FROM SubInventoryCategory WHERE SubCategoryID = @SubCategoryID";

                using (SqlCommand command = new SqlCommand(query, dbConnection.connection))
                {
                    command.Parameters.AddWithValue("@SubCategoryID", subCategoryId);
                    command.ExecuteNonQuery();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("سب کیٹیگری حذف کرتے ہوئے خرابی ہوگئی: " + ex.Message, "خرابی", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally
            {
                dbConnection.closeConnection();
            }
        }


        public int GetNextSubInventoryCategoryID()
        {
            int nextId = 0;
            try
            {
                dbConnection.openConnection();

                string query = "SELECT ISNULL(MAX(SubCategoryID), 0) + 1 FROM SubInventoryCategory";

                using (SqlCommand command = new SqlCommand(query, dbConnection.connection))
                {
                    nextId = (int)command.ExecuteScalar();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("اگلا سب کیٹیگری آئی ڈی حاصل کرتے ہوئے خرابی ہوگئی: " + ex.Message, "خرابی", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally
            {
                dbConnection.closeConnection();
            }

            return nextId;
        }

        public int GetSubInventoryCategoryIDByName(string subCategoryName)
        {
            int subCategoryID = 0;
            try
            {
                dbConnection.openConnection();

                string query = "SELECT SubCategoryID FROM SubInventoryCategory WHERE SubCategoryName = @SubCategoryName";

                using (SqlCommand command = new SqlCommand(query, dbConnection.connection))
                {
                    command.Parameters.AddWithValue("@SubCategoryName", subCategoryName);
                    object result = command.ExecuteScalar();
                    subCategoryID = result != null ? (int)result : 0;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("سب کیٹیگری آئی ڈی حاصل کرتے ہوئے خرابی ہوگئی: " + ex.Message, "خرابی", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally
            {
                dbConnection.closeConnection();
            }

            return subCategoryID;
        }


        public void LoadSubInventoryCategoriesIntoListBox(ListBox listBox, string categoryId)
        {
            try
            {
                dbConnection.openConnection();

                string query = "SELECT SubCategoryName FROM SubInventoryCategory WHERE InventoryCategoryID = @CategoryID";

                using (SqlCommand command = new SqlCommand(query, dbConnection.connection))
                {
                    command.Parameters.AddWithValue("@CategoryID", categoryId);

                    using (SqlDataReader reader = command.ExecuteReader())
                    {
                        listBox.Items.Clear();

                        while (reader.Read())
                        {
                            listBox.Items.Add(reader["SubCategoryName"].ToString());
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("سب کیٹیگری لوڈ کرتے ہوئے خرابی ہوگئی: " + ex.Message, "خرابی", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally
            {
                dbConnection.closeConnection();
            }
        }

    }

}
