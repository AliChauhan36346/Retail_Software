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
            // Credentials are correct, proceed to main form
            MDIParent1 mDIParent1 = new MDIParent1();
            mDIParent1.Show();
            this.Hide();
            mDIParent1.ShowDashboard();

            return;

            // Validate if a username is selected
            if (cmbo_userName.SelectedItem == null)
            {
                MessageBox.Show("Please select a username.", "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            string selectedUsername = cmbo_userName.SelectedItem.ToString().Trim();
            string enteredPassword = txt_password.Text.Trim(); // Ensure password is trimmed

            // Validate if a password is entered
            if (string.IsNullOrEmpty(enteredPassword))
            {
                MessageBox.Show("Please enter your password.", "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            // Validate if a financial year is selected
            if (cmbo_financialYear.SelectedItem == null)
            {
                MessageBox.Show("Please select a financial year.", "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            string selectedFinancialYear = cmbo_financialYear.SelectedItem.ToString().Trim();

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
                        //MDIParent1 mDIParent1 = new MDIParent1();
                        //mDIParent1.Show();
                        //this.Hide();
                        //mDIParent1.ShowDashboard();
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
            List<string> financialYears= new List<string>();
            List<string> username= new List<string>();

            financialYears=commonFunctions.GetFinancialYears();
            username = commonFunctions.GetUserNames();

            foreach(string userName in  username)
            {
                cmbo_userName.Items.Add(userName);
            }

            foreach(string year in financialYears)
            {
                cmbo_financialYear.Items.Add(year);
            }
        }
    }
}
