using ALA_Accounting.Addition;
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

namespace ALA_Accounting.UsersForm
{
    public partial class UserLogin : Form
    {
        Connection Connection=new Connection();
        CommonFunctions commonFunctions = new CommonFunctions();

        MDIParent1 mDIParent1;

        public UserLogin()
        {
            InitializeComponent();
        }

        

        private void button1_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void btn_login_Click(object sender, EventArgs e)
        {
            // Validate if a financial year is selected
            ListBoxItem selectedFinancialYear = (ListBoxItem)cmbo_financialYear.SelectedItem;
            int financialYearID = int.Parse(selectedFinancialYear.ItemID);

            label15.Text = financialYearID.ToString();

            mDIParent1 = MDIParent1.GetInstance(financialYearID);

            // for testing purpose so not to enter password each time
            if (cmbo_userName.Items.Count <= 0)
            {
                mDIParent1.Show();
                this.Hide();
                mDIParent1.ShowDashboard();
            }

            // Validate if a username is selected
            if (cmbo_userName.SelectedItem == null)
            {
                MessageBox.Show("Please select a username.", "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            string selectedUsername = cmbo_userName.SelectedItem.ToString().Trim();
            string enteredPassword = txt_password.Text.Trim(); // Ensure password is trimmed

            // Validate if a financial year is selected
            if (cmbo_financialYear.SelectedItem == null)
            {
                MessageBox.Show("Please select a financial year.", "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            // Query to check if the username and password match
            string query = "SELECT COUNT(1) FROM Users WHERE Username = @Username AND PasswordHash = @PasswordHash AND IsActive = 1";

            try
            {
                Connection.openConnection();

                using (SqlCommand command = new SqlCommand(query, Connection.connection))
                {
                    command.Parameters.AddWithValue("@Username", selectedUsername);
                    command.Parameters.AddWithValue("@PasswordHash", enteredPassword);

                    int count = Convert.ToInt32(command.ExecuteScalar());

                    if (count == 1)
                    {
                        // Credentials are correct, proceed to main form
                        
                          // Pass the selected FinancialYearID to the parent form
                        mDIParent1.Show();
                        this.Hide();
                        mDIParent1.ShowDashboard();
                    }
                    else
                    {
                        // Show error message
                        MessageBox.Show("Invalid username or password. Please try again.", "Login Failed", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("An error occurred while trying to log in: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally
            {
                Connection.closeConnection();
            }
        }


        private void UserLogin_Load(object sender, EventArgs e)
        {
            
            List<string> username= new List<string>();
            username = commonFunctions.GetUserNames();

            foreach(string userName in  username)
            {
                cmbo_userName.Items.Add(userName);
            }


            LoadFinancialYearsIntoComboBox();

            if (cmbo_userName.Items.Count > 0)  // Ensure there are items in the combo box
            {
                cmbo_userName.SelectedIndex = 0;  // Select the first username
            }

            if (cmbo_financialYear.Items.Count > 0)  // Ensure there are items in the combo box
            {
                cmbo_financialYear.SelectedIndex = cmbo_financialYear.Items.Count - 1;  // Select the last financial year
            }

            txt_password.Focus();
            txt_password.Focus();
        }

        private void LoadFinancialYearsIntoComboBox()
        {
            try
            {
                Connection.openConnection();

                string query = "SELECT FinancialYearID, YearName FROM FinancialYear ORDER BY StartDate DESC"; // Order by date if needed
                using (SqlCommand command = new SqlCommand(query, Connection.connection))
                {
                    using (SqlDataReader reader = command.ExecuteReader())
                    {
                        cmbo_financialYear.Items.Clear();

                        while (reader.Read())
                        {
                            // Create ListBoxItem for each financial year
                            ListBoxItem item = new ListBoxItem
                            {
                                ItemID = reader.GetInt32(0).ToString(), // FinancialYearID
                                ItemName = reader.GetString(1) // YearName
                            };

                            cmbo_financialYear.Items.Add(item);
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error loading financial years: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally
            {
                Connection.closeConnection();
            }
        }

        private void txt_password_KeyDown(object sender, KeyEventArgs e)
        {
            if(e.KeyCode == Keys.Enter)
            {
                btn_login_Click(sender, e);

                e.SuppressKeyPress = true;
            }
        }

        private void cmbo_financialYear_SelectedIndexChanged(object sender, EventArgs e)
        {
            

        }
    }
}
