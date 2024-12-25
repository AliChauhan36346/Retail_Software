using ALA_Accounting.Addition_Classes;
using System;
using System.Collections.Generic;
using System.Data.Common;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ALA_Accounting.transaction_classes
{
    internal class CommonFunctions
    {
        Connection dbConnection;

        public CommonFunctions()
        {
            dbConnection = new Connection();
        }

        public List<string> GetFinancialYears()
        {
            List<string> financialYears = new List<string>();

            try
            {
                // Open the database connection
                dbConnection.openConnection();

                // SQL query to retrieve the YearName from the FinancialYear table
                string query = "SELECT YearName FROM FinancialYear";

                // Using the SqlCommand object to execute the query
                using (SqlCommand command = new SqlCommand(query, dbConnection.connection))
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
                dbConnection.closeConnection();
            }

            return financialYears;
        }


        public List<string> GetUserNames()
        {
            List<string> userNames = new List<string>();

            try
            {
                // Open the database connection
                dbConnection.openConnection();

                // SQL query to retrieve the YearName from the FinancialYear table
                string query = "SELECT UserName FROM Users";

                // Using the SqlCommand object to execute the query
                using (SqlCommand command = new SqlCommand(query, dbConnection.connection))
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
                dbConnection.closeConnection();
            }

            return userNames;
        }

        public void ClearAllTextBoxes(Control parent)
        {
            foreach (Control control in parent.Controls)
            {
                if (control is TextBox textBox)
                {
                    textBox.Clear();

                }
                else if (control is RichTextBox richTextBox)
                {
                    richTextBox.Clear();
                }
                else if (control.HasChildren)
                {
                    // Recursively clear text boxes in child controls
                    ClearAllTextBoxes(control);
                }
            }
        }

        public Dictionary<string, string> GetInventoryItemIdsAndNames()
        {
            Dictionary<string, string> inventoryItems = new Dictionary<string, string>();

            try
            {
                dbConnection.openConnection();

                string query = "SELECT ItemID, ItemName FROM InventoryItem";
                using (SqlCommand command = new SqlCommand(query, dbConnection.connection))
                {
                    using (SqlDataReader reader = command.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            string itemId = reader["ItemID"].ToString();
                            string itemName = reader["ItemName"].ToString();
                            inventoryItems.Add(itemId, itemName);
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error retrieving inventory items: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally
            {
                dbConnection.closeConnection();
            }

            return inventoryItems;
        }

        public Dictionary<int, string> GetAccountIdsAndNames()
        {
            Dictionary<int, string> accountIdsAndNames = new Dictionary<int, string>();

            try
            {
                dbConnection.openConnection();

                string query = "SELECT AccountID, AccountName FROM Accounts";
                using (SqlCommand command = new SqlCommand(query, dbConnection.connection))
                {
                    using (SqlDataReader reader = command.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            int accountId = Convert.ToInt32(reader["AccountID"]);
                            string accountName = reader["AccountName"].ToString();
                            accountIdsAndNames.Add(accountId, accountName);
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error retrieving accounts: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally
            {
                dbConnection.closeConnection();
            }

            return accountIdsAndNames;
        }

        public Dictionary<int, string> GetAccountIdsAndNamesMainBasis(string mainAccountName)
        {
            Dictionary<int, string> accountIdsAndNames = new Dictionary<int, string>();

            try
            {
                dbConnection.openConnection();

                // Adjusted query to retrieve sub-accounts based on the main account name
                string query = @"
            SELECT a.AccountID, a.AccountName 
            FROM Accounts a
            INNER JOIN SubAccounts sa ON a.SubAccountTypeID = sa.SubAccountTypeID
            INNER JOIN MainAccounts ma ON sa.MainAccountID = ma.MainAccountID
            WHERE ma.MainAccountName = @MainAccountName";

                using (SqlCommand command = new SqlCommand(query, dbConnection.connection))
                {
                    command.Parameters.AddWithValue("@MainAccountName", mainAccountName);

                    using (SqlDataReader reader = command.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            int accountId = Convert.ToInt32(reader["AccountID"]);
                            string accountName = reader["AccountName"].ToString();
                            accountIdsAndNames.Add(accountId, accountName);
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error retrieving accounts: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally
            {
                dbConnection.closeConnection();
            }

            return accountIdsAndNames;
        }

        public void HandleAccountSuggestionKeyDown(Guna.UI2.WinForms.Guna2TextBox id, Guna.UI2.WinForms.Guna2TextBox name, ListBox listBox, KeyEventArgs e, Control control)
        {
            if (e.KeyCode == Keys.Enter || e.KeyCode == Keys.Tab)
            {
                //listBox.Visible = true;

                if (listBox.Visible && listBox.SelectedItem != null)
                {
                    string selectedSuggestion = listBox.SelectedItem.ToString();
                    string[] parts = selectedSuggestion.Split(new[] { " - " }, StringSplitOptions.None);

                    // Transfer the selected suggestion to the TextBoxes
                    name.Text = parts[1]; // Name TextBox
                    id.Text = parts[0]; // ID TextBox

                    // Hide the suggestion list
                    listBox.Visible = false;

                    control.Focus();

                    // Prevent the Enter key from being processed further
                    e.SuppressKeyPress = true;

                    
                }
                else
                {
                    // Move focus to the next control0
                    listBox.Visible = false;

                    control.Focus();
                }
            }
            else if (e.KeyCode == Keys.Up)
            {
                if (listBox.Visible)
                {
                    int newIndex = listBox.SelectedIndex - 1;
                    if (newIndex >= 0)
                    {
                        listBox.SelectedIndex = newIndex;
                        e.Handled = true;
                        e.SuppressKeyPress = true;
                    }
                }
            }
            else if (e.KeyCode == Keys.Down)
            {
                if (listBox.Visible)
                {
                    int newIndex = listBox.SelectedIndex + 1;
                    if (newIndex < listBox.Items.Count)
                    {
                        listBox.SelectedIndex = newIndex;
                        e.Handled = true;
                        e.SuppressKeyPress = true;
                    }
                }
            }
        }

        public void ShowAccountSuggestions(Guna.UI2.WinForms.Guna2TextBox textBox, ListBox listBox, string accountType)
        {
            if (textBox.Focused)
            {
                listBox.Visible = true;
                string searchTerm = textBox.Text.Trim(); // Trim whitespace

                // Clear existing suggestions
                listBox.Items.Clear();

                // Declare a dictionary to hold account data
                Dictionary<string, string> accountIdsAndNames = new Dictionary<string, string>();

                // Get account IDs and names based on account type
                switch (accountType)
                {
                    case "allAccount":
                        accountIdsAndNames = GetAccountIdsAndNames().ToDictionary(k => k.Key.ToString(), v => v.Value);
                        break;
                    case "customer":
                        accountIdsAndNames = GetAccountIdsAndNamesMainBasis("Customers").ToDictionary(k => k.Key.ToString(), v => v.Value);
                        break;
                    case "vendor":
                        accountIdsAndNames = GetAccountIdsAndNamesMainBasis("Vendors / Suppliers").ToDictionary(k => k.Key.ToString(), v => v.Value);
                        break;
                    case "inventory":
                        accountIdsAndNames = GetInventoryItemIdsAndNames();
                        break;
                    default:
                        throw new ArgumentException("Invalid account type specified.");
                }

                // Store the best match and its score
                string bestMatch = null;
                int bestScore = int.MaxValue;

                foreach (var entry in accountIdsAndNames)
                {
                    string accountId = entry.Key;
                    string accountName = entry.Value;

                    // Perform case-insensitive search with ranking
                    int idMatchScore = accountId.IndexOf(searchTerm, StringComparison.OrdinalIgnoreCase);
                    int nameMatchScore = accountName.IndexOf(searchTerm, StringComparison.OrdinalIgnoreCase);

                    // If the search term matches either ID or Name
                    if (idMatchScore >= 0 || nameMatchScore >= 0)
                    {
                        listBox.Items.Add($"{accountId} - {accountName}");

                        // Choose the best match based on the closest (earliest) match
                        int score = Math.Min(idMatchScore >= 0 ? idMatchScore : int.MaxValue, nameMatchScore >= 0 ? nameMatchScore : int.MaxValue);
                        if (score < bestScore)
                        {
                            bestScore = score;
                            bestMatch = $"{accountId} - {accountName}";
                        }
                    }
                }

                
            }
        }


        public void ShowInventorySuggestions(string search, ListBox listBox, string accountType)
        {
            
            listBox.Visible = true;
            string searchTerm = search.Trim(); // Trim whitespace

            // Clear existing suggestions
            listBox.Items.Clear();

            // Declare a dictionary to hold account data
            Dictionary<string, string> accountIdsAndNames = new Dictionary<string, string>();

            // Get account IDs and names based on account type
            switch (accountType)
            {
                case "allAccount":
                    accountIdsAndNames = GetAccountIdsAndNames().ToDictionary(k => k.Key.ToString(), v => v.Value);
                    break;
                case "customer":
                    accountIdsAndNames = GetAccountIdsAndNamesMainBasis("Customers").ToDictionary(k => k.Key.ToString(), v => v.Value);
                    break;
                case "inventory":
                    accountIdsAndNames = GetInventoryItemIdsAndNames();
                    break;
                default:
                    throw new ArgumentException("Invalid account type specified.");
            }

            // Store the best match and its score
            string bestMatch = null;
            int bestScore = int.MaxValue;

            foreach (var entry in accountIdsAndNames)
            {
                string accountId = entry.Key;
                string accountName = entry.Value;

                // Perform case-insensitive search with ranking
                int idMatchScore = accountId.IndexOf(searchTerm, StringComparison.OrdinalIgnoreCase);
                int nameMatchScore = accountName.IndexOf(searchTerm, StringComparison.OrdinalIgnoreCase);

                // If the search term matches either ID or Name
                if (idMatchScore >= 0 || nameMatchScore >= 0)
                {
                    listBox.Items.Add($"{accountId} - {accountName}");

                    // Choose the best match based on the closest (earliest) match
                    int score = Math.Min(idMatchScore >= 0 ? idMatchScore : int.MaxValue, nameMatchScore >= 0 ? nameMatchScore : int.MaxValue);
                    if (score < bestScore)
                    {
                        bestScore = score;
                        bestMatch = $"{accountId} - {accountName}";
                    }
                }
            }

                
            
        }

        // This method should be wired up to the KeyDown event of your DataGridView


        





    }
}
