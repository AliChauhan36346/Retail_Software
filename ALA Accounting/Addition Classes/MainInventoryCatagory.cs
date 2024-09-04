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
    public class MainInventoryCatagory
    {
        Connection dbConnection;

        public MainInventoryCatagory()
        {
            dbConnection = new Connection();
        }


        public void SaveInventoryCategory(string categoryName)
        {
            try
            {
                dbConnection.openConnection();

                string query = "INSERT INTO InventoryCategory (CategoryName) VALUES (@CategoryName)";

                using (SqlCommand command = new SqlCommand(query, dbConnection.connection))
                {
                    command.Parameters.AddWithValue("@CategoryName", categoryName);
                    command.ExecuteNonQuery();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("زمرہ محفوظ کرتے ہوئے خرابی ہوگئی: " + ex.Message, "خرابی", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally
            {
                dbConnection.closeConnection();
            }
        }


        public void UpdateInventoryCategory(int categoryId, string newCategoryName)
        {
            try
            {
                dbConnection.openConnection();

                string query = "UPDATE InventoryCategory SET CategoryName = @NewCategoryName WHERE InventoryCategoryID = @CategoryID";

                using (SqlCommand command = new SqlCommand(query, dbConnection.connection))
                {
                    command.Parameters.AddWithValue("@CategoryID", categoryId);
                    command.Parameters.AddWithValue("@NewCategoryName", newCategoryName);
                    command.ExecuteNonQuery();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("زمرہ اپ ڈیٹ کرتے ہوئے خرابی ہوگئی: " + ex.Message, "خرابی", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally
            {
                dbConnection.closeConnection();
            }
        }


        public void DeleteInventoryCategory(int categoryId)
        {
            try
            {
                dbConnection.openConnection();

                string query = "DELETE FROM InventoryCategory WHERE InventoryCategoryID = @CategoryID";

                using (SqlCommand command = new SqlCommand(query, dbConnection.connection))
                {
                    command.Parameters.AddWithValue("@CategoryID", categoryId);
                    command.ExecuteNonQuery();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("زمرہ حذف کرتے ہوئے خرابی ہوگئی: " + ex.Message, "خرابی", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally
            {
                dbConnection.closeConnection();
            }
        }


        public void LoadInventoryCategoriesIntoListBox(ListBox listBox)
        {
            try
            {
                dbConnection.openConnection();

                string query = "SELECT CategoryName FROM InventoryCategory";

                using (SqlCommand command = new SqlCommand(query, dbConnection.connection))
                {
                    using (SqlDataReader reader = command.ExecuteReader())
                    {
                        listBox.Items.Clear();

                        while (reader.Read())
                        {
                            listBox.Items.Add(reader["CategoryName"].ToString());
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("زمرہ جات لوڈ کرتے ہوئے خرابی ہوگئی: " + ex.Message, "خرابی", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally
            {
                dbConnection.closeConnection();
            }
        }


        public int GetNextInventoryCategoryID()
        {
            int nextId = -1;

            try
            {
                dbConnection.openConnection();

                string query = "SELECT ISNULL(MAX(InventoryCategoryID), 0) + 1 FROM InventoryCategory";

                using (SqlCommand command = new SqlCommand(query, dbConnection.connection))
                {
                    nextId = Convert.ToInt32(command.ExecuteScalar());
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("اگلا زمرہ ID حاصل کرتے ہوئے خرابی ہوگئی: " + ex.Message, "خرابی", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally
            {
                dbConnection.closeConnection();
            }

            return nextId;
        }


        public int GetInventoryCategoryIDByName(string categoryName)
        {
            int categoryId = -1;

            try
            {
                dbConnection.openConnection();

                string query = "SELECT InventoryCategoryID FROM InventoryCategory WHERE CategoryName = @CategoryName";

                using (SqlCommand command = new SqlCommand(query, dbConnection.connection))
                {
                    command.Parameters.AddWithValue("@CategoryName", categoryName);
                    categoryId = Convert.ToInt32(command.ExecuteScalar());
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("زمرہ ID حاصل کرتے ہوئے خرابی ہوگئی: " + ex.Message, "خرابی", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally
            {
                dbConnection.closeConnection();
            }

            return categoryId;
        }


    }
}
