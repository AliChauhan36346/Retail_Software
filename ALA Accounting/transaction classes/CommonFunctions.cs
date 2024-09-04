using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ALA_Accounting.transaction_classes
{
    internal class CommonFunctions
    {
        Connection connection=new Connection();

        public List<string> GetFinancialYears()
        {
            List<string> financialYears = new List<string>();

            try
            {
                // Open the database connection
                connection.openConnection();

                // SQL query to retrieve the YearName from the FinancialYear table
                string query = "SELECT YearName FROM FinancialYear";

                // Using the SqlCommand object to execute the query
                using (SqlCommand command = new SqlCommand(query, connection.connection))
                {
                    // Execute the command and read the results
                    using (SqlDataReader reader = command.ExecuteReader())
                    {
                        // Loop through the data and add each year name to the list
                        while (reader.Read())
                        {
                            financialYears.Add(reader["YearName"].ToString());
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                // Handle any errors that occur during the query execution
                MessageBox.Show("Error retrieving financial years: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally
            {
                // Ensure the database connection is closed
                connection.closeConnection();
            }

            return financialYears;
        }


        public List<string> GetUserNames()
        {
            List<string> userNames = new List<string>();

            try
            {
                // Open the database connection
                connection.openConnection();

                // SQL query to retrieve the YearName from the FinancialYear table
                string query = "SELECT UserName FROM Users";

                // Using the SqlCommand object to execute the query
                using (SqlCommand command = new SqlCommand(query, connection.connection))
                {
                    // Execute the command and read the results
                    using (SqlDataReader reader = command.ExecuteReader())
                    {
                        // Loop through the data and add each year name to the list
                        while (reader.Read())
                        {
                            userNames.Add(reader["userName"].ToString());
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                // Handle any errors that occur during the query execution
                MessageBox.Show("Error retrieving financial years: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally
            {
                // Ensure the database connection is closed
                connection.closeConnection();
            }

            return userNames;
        }
    }
}
