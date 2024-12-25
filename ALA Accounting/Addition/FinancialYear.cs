using ALA_Accounting.transaction_classes;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ALA_Accounting.Addition
{
    public partial class FinancialYear : Form
    {
        Connection dbConnection=new Connection();

        DateTime startDate = new DateTime();
        DateTime endDate = new DateTime();
        string yearName;
        public FinancialYear()
        {
            InitializeComponent();
        }

        private void FinancialYear_Load(object sender, EventArgs e)
        {
            LoadFinancialYearNames(lstFinancialYears);

        }

        public void SaveFinancialYear(DateTime startDate, DateTime endDate, string yearName)
        {
            try
            {
                dbConnection.openConnection();

                string query = "INSERT INTO [dbo].[FinancialYear] (StartDate, EndDate, YearName) VALUES (@StartDate, @EndDate, @YearName)";

                using (SqlCommand command = new SqlCommand(query, dbConnection.connection))
                {
                    command.Parameters.AddWithValue("@StartDate", startDate);
                    command.Parameters.AddWithValue("@EndDate", endDate);
                    command.Parameters.AddWithValue("@YearName", yearName);
                    command.ExecuteNonQuery();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("خرابی محفوظ کرتے وقت: " + ex.Message, "خرابی", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally
            {
                dbConnection.closeConnection();
            }
        }


        public void UpdateFinancialYear(int financialYearID, DateTime startDate, DateTime endDate, string yearName)
        {
            try
            {
                dbConnection.openConnection();

                string query = "UPDATE [dbo].[FinancialYear] SET StartDate = @StartDate, EndDate = @EndDate, YearName = @YearName WHERE FinancialYearID = @FinancialYearID";

                using (SqlCommand command = new SqlCommand(query, dbConnection.connection))
                {
                    command.Parameters.AddWithValue("@StartDate", startDate);
                    command.Parameters.AddWithValue("@EndDate", endDate);
                    command.Parameters.AddWithValue("@YearName", yearName);
                    command.Parameters.AddWithValue("@FinancialYearID", financialYearID);
                    command.ExecuteNonQuery();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("خرابی اپ ڈیٹ کرتے وقت: " + ex.Message, "خرابی", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally
            {
                dbConnection.closeConnection();
            }
        }


        public void DeleteFinancialYear(int financialYearID)
        {
            try
            {
                dbConnection.openConnection();

                string query = "DELETE FROM [dbo].[FinancialYear] WHERE FinancialYearID = @FinancialYearID";

                using (SqlCommand command = new SqlCommand(query, dbConnection.connection))
                {
                    command.Parameters.AddWithValue("@FinancialYearID", financialYearID);
                    command.ExecuteNonQuery();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("خرابی حذف کرتے وقت: " + ex.Message, "خرابی", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally
            {
                dbConnection.closeConnection();
            }
        }


        public void LoadFinancialYearNames(ListBox listBox)
        {
            try
            {
                dbConnection.openConnection();

                string query = "SELECT FinancialYearID, YearName FROM [dbo].[FinancialYear]";

                using (SqlCommand command = new SqlCommand(query, dbConnection.connection))
                {
                    using (SqlDataReader reader = command.ExecuteReader())
                    {
                        listBox.Items.Clear();
                        while (reader.Read())
                        {
                            ListBoxItem item = new ListBoxItem
                            {
                                FinancialYearID = Convert.ToInt32(reader["FinancialYearID"]),
                                ItemName = reader["YearName"].ToString() // Use ItemName for YearName
                            };
                            listBox.Items.Add(item);
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("خرابی مالی سال کے نام لوڈ کرتے وقت: " + ex.Message, "خرابی", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally
            {
                dbConnection.closeConnection();
            }
        }


        public string GenerateFinancialYearName(DateTime startDate, DateTime endDate)
        {
            int startYear = startDate.Year;
            int endYear = endDate.Year;
            return $"{startYear}-{endYear}";
        }

        private void btn_addNew_Click(object sender, EventArgs e)
        {
            dtm_startDate.Value = DateTime.Now;
            dtm_endDate.Value= DateTime.Now;

            txt_YearName.Clear();
        }

        private void btn_save_Click(object sender, EventArgs e)
        {
            if (lstFinancialYears.SelectedItem != null)
            {
                ListBoxItem selectedItem = (ListBoxItem)lstFinancialYears.SelectedItem;

                if (selectedItem.FinancialYearID.HasValue)
                {
                    var financialYear = GetFinancialYearDetailsById(selectedItem.FinancialYearID.Value);

                    if (financialYear != null)
                    {
                        UpdateFinancialYear(selectedItem.FinancialYearID.Value, dtm_startDate.Value.Date, dtm_endDate.Value.Date, txt_YearName.Text);
                        LoadFinancialYearNames(lstFinancialYears);
                    }
                    else
                    {
                        SaveFinancialYear(dtm_startDate.Value.Date,dtm_endDate.Value.Date,txt_YearName.Text);
                        LoadFinancialYearNames(lstFinancialYears);

                    }
                }
            }
            else
            {
                SaveFinancialYear(dtm_startDate.Value.Date, dtm_endDate.Value.Date, txt_YearName.Text);
                LoadFinancialYearNames(lstFinancialYears);
            }
        }

        private bool DoesFinancialYearIDExist(int financialYearID)
        {
            bool exists = false;
            try
            {
                dbConnection.openConnection();

                string query = "SELECT COUNT(1) FROM [dbo].[FinancialYear] WHERE FinancialYearID = @FinancialYearID";
                using (SqlCommand command = new SqlCommand(query, dbConnection.connection))
                {
                    command.Parameters.AddWithValue("@FinancialYearID", financialYearID);

                    // Execute the query and get the result
                    int count = Convert.ToInt32(command.ExecuteScalar());
                    exists = (count > 0); // If count > 0, the ID exists
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("مالی سال کی شناخت کی جانچ کرتے ہوئے خرابی ہوئی: " + ex.Message, "خرابی", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally
            {
                dbConnection.closeConnection();
            }

            return exists;
        }


        private void dtm_startDate_ValueChanged(object sender, EventArgs e)
        {
            txt_YearName.Text=GenerateFinancialYearName(dtm_startDate.Value, dtm_endDate.Value);
        }

        private void dtm_endDate_ValueChanged(object sender, EventArgs e)
        {
            txt_YearName.Text=GenerateFinancialYearName(dtm_startDate.Value, dtm_endDate.Value);
        }

        private void lstFinancialYears_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (lstFinancialYears.SelectedItem != null)
            {
                ListBoxItem selectedItem = (ListBoxItem)lstFinancialYears.SelectedItem;

                if (selectedItem.FinancialYearID.HasValue)
                {
                    var financialYear = GetFinancialYearDetailsById(selectedItem.FinancialYearID.Value);

                    if (financialYear != null)
                    {
                        dtm_startDate.Value = financialYear.startDate;
                        dtm_endDate.Value = financialYear.endDate;
                        txt_YearName.Text = financialYear.yearName;
                    }
                    else
                    {
                        MessageBox.Show("Financial year details could not be loaded.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
            }
        }

        public FinancialYear GetFinancialYearDetailsById(int financialYearID)
        {
            FinancialYear financialYear = null;

            try
            {
                dbConnection.openConnection();

                string query = "SELECT StartDate, EndDate, YearName FROM [dbo].[FinancialYear] WHERE FinancialYearID = @FinancialYearID";
                using (SqlCommand command = new SqlCommand(query, dbConnection.connection))
                {
                    command.Parameters.AddWithValue("@FinancialYearID", financialYearID);

                    using (SqlDataReader reader = command.ExecuteReader())
                    {
                        if (reader.Read())
                        {
                            financialYear = new FinancialYear
                            {
                                startDate = Convert.ToDateTime(reader["StartDate"]),
                                endDate = Convert.ToDateTime(reader["EndDate"]),
                                yearName = reader["YearName"].ToString()
                            };
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("خرابی مالی سال کی تفصیلات لوڈ کرتے وقت: " + ex.Message, "خرابی", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally
            {
                dbConnection.closeConnection();
            }

            return financialYear;
        }

        private void btn_cancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        public (DateTime StartDate, DateTime EndDate) GetFinancialYearDatesById(int id)
        {
            DateTime startDate = DateTime.MinValue;
            DateTime endDate = DateTime.MinValue;

            try
            {
                dbConnection.openConnection();

                string query = "SELECT StartDate, EndDate FROM FinancialYear WHERE FinancialYearId = @Id";

                using (SqlCommand command = new SqlCommand(query, dbConnection.connection))
                {
                    command.Parameters.AddWithValue("@Id", id);

                    using (SqlDataReader reader = command.ExecuteReader())
                    {
                        if (reader.Read())
                        {
                            startDate = reader.GetDateTime(0); // Assuming StartDate is in the first column
                            endDate = reader.GetDateTime(1);   // Assuming EndDate is in the second column
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("خرابی ڈیٹا حاصل کرتے وقت: " + ex.Message, "خرابی", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally
            {
                dbConnection.closeConnection();
            }

            return (startDate, endDate);
        }

    }
}
