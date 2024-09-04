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
    public class Brand
    {
        Connection dbConnection;

        public string brandName {  get; set; }

        public Brand()
        {
            dbConnection=new Connection();
        }


        public void SaveBrand(string brandName)
        {
            try
            {
                dbConnection.openConnection();

                string query = "INSERT INTO Brand (BrandName) VALUES (@BrandName)";

                using (SqlCommand command = new SqlCommand(query, dbConnection.connection))
                {
                    command.Parameters.AddWithValue("@BrandName", brandName);
                    command.ExecuteNonQuery();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("برینڈ محفوظ کرتے ہوئے خرابی ہوگئی: " + ex.Message, "خرابی", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally
            {
                dbConnection.closeConnection();
            }
        }

        public void UpdateBrand(string oldBrandName, string newBrandName)
        {
            try
            {
                dbConnection.openConnection();

                string query = "UPDATE Brand SET BrandName = @NewBrandName WHERE BrandName = @OldBrandName";

                using (SqlCommand command = new SqlCommand(query, dbConnection.connection))
                {
                    command.Parameters.AddWithValue("@OldBrandName", oldBrandName);
                    command.Parameters.AddWithValue("@NewBrandName", newBrandName);
                    command.ExecuteNonQuery();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("برینڈ اپ ڈیٹ کرتے ہوئے خرابی ہوگئی: " + ex.Message, "خرابی", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally
            {
                dbConnection.closeConnection();
            }
        }


        public void DeleteBrand(string brandName)
        {
            try
            {
                dbConnection.openConnection();

                string query = "DELETE FROM Brand WHERE BrandName = @BrandName";

                using (SqlCommand command = new SqlCommand(query, dbConnection.connection))
                {
                    command.Parameters.AddWithValue("@BrandName", brandName);
                    command.ExecuteNonQuery();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("برینڈ حذف کرتے ہوئے خرابی ہوگئی: " + ex.Message, "خرابی", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally
            {
                dbConnection.closeConnection();
            }
        }


        public void LoadBrandsIntoComboBox(ComboBox combo)
        {
            try
            {
                dbConnection.openConnection();

                string query = "SELECT BrandName FROM Brand";

                using (SqlCommand command = new SqlCommand(query, dbConnection.connection))
                {
                    using (SqlDataReader reader = command.ExecuteReader())
                    {
                        combo.Items.Clear();

                        while (reader.Read())
                        {
                            combo.Items.Add(reader["BrandName"].ToString());
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("برینڈز لوڈ کرتے ہوئے خرابی ہوگئی: " + ex.Message, "خرابی", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally
            {
                dbConnection.closeConnection();
            }
        }

        public void LoadBrandsIntoListBox(ListBox list)
        {
            try
            {
                dbConnection.openConnection();

                string query = "SELECT BrandName FROM Brand";

                using (SqlCommand command = new SqlCommand(query, dbConnection.connection))
                {
                    using (SqlDataReader reader = command.ExecuteReader())
                    {
                        list.Items.Clear();

                        while (reader.Read())
                        {
                            list.Items.Add(reader["BrandName"].ToString());
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("برینڈز لوڈ کرتے ہوئے خرابی ہوگئی: " + ex.Message, "خرابی", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally
            {
                dbConnection.closeConnection();
            }
        }


    }
}
