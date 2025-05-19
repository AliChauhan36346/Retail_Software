using ALA_Accounting.Addition_Classes;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ALA_Accounting.Addition
{
    public partial class AddAccount : Form
    {

        Accounts account=new Accounts();
        SubAccounts subAccount=new SubAccounts();
        MainAccounts mainAccount = new MainAccounts();

        bool isEditing = true;
        bool isDeleting = false;

        

        public AddAccount()
        {
            InitializeComponent();
        }

        private void groupBox2_Enter(object sender, EventArgs e)
        {

        }

        public void EnableAllControls()
        {
            btn_addNewMainAcc.Enabled = true;
            btn_saveMainAcc.Enabled = true;
            btn_cancelMainAcc.Enabled = true;
            btn_deleteMainAcc.Enabled = true;

            btn_addNewSubAcc.Enabled = true;
            btn_saveSubAcc.Enabled = true;
            btn_cancelSubAcc.Enabled = true;
            btn_deleteSubAcc.Enabled = true;

            btn_addAccount.Enabled = true;
            btn_saveAcc.Enabled = true;
            btn_cancelAcc.Enabled = true;
            btn_DeleteAcc.Enabled = true;

            lstMainAccounts.Enabled = true;
            lstSubAccounts.Enabled = true;
            lstAccounts.Enabled = true;
        }


        public void DisableAllControlsExcept(Guna.UI2.WinForms.Guna2Button button1, Guna.UI2.WinForms.Guna2Button button2)
        {
            btn_addNewMainAcc.Enabled = false;
            btn_saveMainAcc.Enabled = false;
            btn_cancelMainAcc.Enabled = false;
            btn_deleteMainAcc.Enabled = false;

            btn_addNewSubAcc.Enabled = false;
            btn_saveSubAcc.Enabled = false;
            btn_cancelSubAcc.Enabled = false;
            btn_deleteSubAcc.Enabled = false;

            btn_addAccount.Enabled = false;
            btn_saveAcc.Enabled = false;
            btn_cancelAcc.Enabled = false;
            btn_DeleteAcc.Enabled = false;

            lstMainAccounts.Enabled = false;
            lstSubAccounts.Enabled = false;
            lstAccounts.Enabled = false;


            // Ensure the two provided buttons are enabled
            button1.Enabled = true;
            button2.Enabled = true;
        }


        private void AddAccount_Load(object sender, EventArgs e)
        {
            // Load all accounts into the list boxes
            loadAccounts(true, false, false);

            // Simulate the cancel button click to select the first item and display its details
            btn_cancelMainAcc_Click(sender, e);

            loadAccounts(false, true, false);

            btn_cancelSubAcc_Click(sender, e);

            loadAccounts(false, false, true);


        }

        private bool ValidateMainAccountForm()
        {
            // Check if Main Account Name textbox is empty
            if (string.IsNullOrWhiteSpace(txt_mainAccName.Text))
            {
                MessageBox.Show("براہ کرم مین اکاؤنٹ کا نام درج کریں۔", "غلطی", MessageBoxButtons.OK, MessageBoxIcon.Error);
                txt_mainAccName.Focus();
                return false;
            }

            // Check if Financial Statement Component is selected
            if (cmbo_financialStatComponent.SelectedIndex == -1)
            {
                MessageBox.Show("براہ کرم مالیاتی اسٹیٹمنٹ کا جزو منتخب کریں۔", "غلطی", MessageBoxButtons.OK, MessageBoxIcon.Error);
                cmbo_financialStatComponent.Focus();
                return false;
            }

            // If editing or deleting, ensure a Main Account ID is selected
            if ((isEditing || isDeleting) && string.IsNullOrWhiteSpace(txt_mainAccId.Text))
            {
                MessageBox.Show("براہ کرم ایک مین اکاؤنٹ منتخب کریں جسے آپ اپ ڈیٹ یا حذف کرنا چاہتے ہیں۔", "غلطی", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }

            // If everything is valid, return true
            return true;
        }

        private void btn_saveMainAcc_Click(object sender, EventArgs e)
        {
            if (ValidateMainAccountForm())
            {
                // Proceed with save or update operation
                if (isEditing)
                {
                    // Call update function here
                    mainAccount.mainAccountId = txt_mainAccId.Text;
                    mainAccount.MainAccountName = txt_mainAccName.Text;
                    mainAccount.FinancialStatementComponent=cmbo_financialStatComponent.SelectedItem.ToString().Trim();

                    mainAccount.UpdateMainAccount(mainAccount);

                    EnableAllControls();

                    loadAccounts(true, false, false);
                }
                else
                {
                    
                    mainAccount.MainAccountName = txt_mainAccName.Text;
                    mainAccount.FinancialStatementComponent = cmbo_financialStatComponent.SelectedItem.ToString().Trim();

                    // Call save function here
                    mainAccount.SaveMainAccount(mainAccount);
                    EnableAllControls();
                    loadAccounts(true, false, false);

                    isEditing = true;
                }
            }
        }

        private void btn_addNewMainAcc_Click(object sender, EventArgs e)
        {
            isEditing = false;
            // Get the next MainAccountID
            int nextMainAccountId = mainAccount.GetNextMainAccountId();

            // Set the text box with the new ID
            txt_mainAccId.Text = nextMainAccountId.ToString();

            DisableAllControlsExcept(btn_saveMainAcc, btn_cancelMainAcc);

            // Clear other fields to allow new data entry
            txt_mainAccName.Clear();
            cmbo_financialStatComponent.SelectedIndex = -1;
        }

        private void loadAccounts(bool main, bool subAcc, bool acc)
        {
            
            
            List<string> accounts = new List<String>();

            

            if (main)
            {
                lstMainAccounts.Items.Clear();

                List<string> mainAccounts = new List<string>();

                mainAccounts = mainAccount.LoadMainAccountNames();

                foreach (var item in mainAccounts)
                {
                    lstMainAccounts.Items.Add(item.ToString());
                }
            }

            if (subAcc)
            {
                lstSubAccounts.Items.Clear();

                List<string> subAccounts = new List<String>();

                subAccounts = subAccount.LoadSubAccountNamesByMainAccountId(txt_mainAccId.Text.Trim());
                
                foreach(var item in subAccounts)
                {
                    lstSubAccounts.Items.Add(item);
                }
            }

            if (acc)
            {
                lstAccounts.Items.Clear();
                List<string> listAcc = new List<String>();

                listAcc = account.LoadAccountNamesBySubAccountTypeId(txt_subAccId.Text.Trim());

                foreach(var item in  listAcc)
                {
                    lstAccounts.Items.Add(item);
                }
            }
        }

        private void lstMainAccounts_SelectedIndexChanged(object sender, EventArgs e)
        {
            string selectedAccountName = lstMainAccounts.SelectedItem.ToString().Trim();

            // Get both MainAccountID and FinancialStatementComponent using the modified function
            var mainAccountDetails = mainAccount.GetMainAccountDetailsByName(selectedAccountName);

            // Set the MainAccountID in the text box
            txt_mainAccId.Text = mainAccountDetails.MainAccountId.ToString();

            // Set the MainAccountName in the text box
            txt_mainAccName.Text = selectedAccountName;

            // Select the corresponding FinancialStatementComponent in the combo box
            cmbo_financialStatComponent.SelectedItem = mainAccountDetails.FinancialStatementComponent.ToString().Trim();


            loadAccounts(false, true, false);

            btn_cancelSubAcc_Click(sender, e);

            loadAccounts(false, false, true);

            btn_cancelAcc_Click(sender, e);

        }

        private void btn_deleteMainAcc_Click(object sender, EventArgs e)
        {
            isDeleting = true;

            if(ValidateMainAccountForm())
            {
                mainAccount.mainAccountId = txt_mainAccId.Text.Trim();

                mainAccount.DeleteMainAccount(mainAccount.mainAccountId);

                loadAccounts(true, false, false);

                isDeleting = false;
            }

            
        }

        private void btn_cancelMainAcc_Click(object sender, EventArgs e)
        {
            if (lstMainAccounts.Items.Count == 0)
            {
                txt_mainAccId.Clear();
                txt_mainAccName.Clear();
                return;
            }

            EnableAllControls();

            // Select the first item in the list
            lstMainAccounts.SelectedIndex = 0;

            // Get the name of the first selected account
            string selectedAccountName = lstMainAccounts.SelectedItem.ToString().Trim();

            // Get both MainAccountID and FinancialStatementComponent using the modified function
            var mainAccountDetails = mainAccount.GetMainAccountDetailsByName(selectedAccountName);

            // Set the MainAccountID in the text box
            txt_mainAccId.Text = mainAccountDetails.MainAccountId.ToString();

            // Set the MainAccountName in the text box
            txt_mainAccName.Text = selectedAccountName;

            // Select the corresponding FinancialStatementComponent in the combo box
            cmbo_financialStatComponent.SelectedItem = mainAccountDetails.FinancialStatementComponent.ToString().Trim();
        }




        // sub accounts code

        private bool ValidateSubAccountForm()
        {
            // Check if Sub Account Name textbox is empty
            if (string.IsNullOrWhiteSpace(txt_subAccName.Text))
            {
                MessageBox.Show("براہ کرم ذیلی اکاؤنٹ کا نام درج کریں۔", "غلطی", MessageBoxButtons.OK, MessageBoxIcon.Error);
                txt_subAccName.Focus();
                return false;
            }

            // Check if Main Account ID textbox is empty
            if (string.IsNullOrWhiteSpace(txt_mainAccId.Text))
            {
                MessageBox.Show("براہ کرم مین اکاؤنٹ منتخب کریں یا مین اکاؤنٹ آئی ڈی درج کریں۔", "غلطی", MessageBoxButtons.OK, MessageBoxIcon.Error);
                txt_mainAccId.Focus();
                return false;
            }

            // If editing or deleting, ensure a Sub Account ID is selected
            if ((isEditing || isDeleting) && string.IsNullOrWhiteSpace(txt_subAccId.Text))
            {
                MessageBox.Show("براہ کرم ایک ذیلی اکاؤنٹ منتخب کریں جسے آپ اپ ڈیٹ یا حذف کرنا چاہتے ہیں۔", "غلطی", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }

            // If everything is valid, return true
            return true;
        }


        private void btn_addNewSubAcc_Click(object sender, EventArgs e)
        {
            txt_subAccId.Text = subAccount.GetNextSubAccountId().ToString();
            txt_subAccName.Clear();
            isEditing = false;

            DisableAllControlsExcept(btn_saveSubAcc, btn_cancelSubAcc);
        }

        private void btn_saveSubAcc_Click(object sender, EventArgs e)
        {
            if (ValidateSubAccountForm())
            {
                // Proceed with save or update operation
                if (isEditing)
                {
                    // Call update function here
                    subAccount.SubAccountTypeId = txt_subAccId.Text;
                    subAccount.SubAccountTypeName = txt_subAccName.Text;
                    subAccount.MainAccountID = txt_mainAccId.Text;
                    

                    subAccount.UpdateSubAccount(subAccount);

                    EnableAllControls();
                    loadAccounts(false, true, false);
                }
                else
                {
                    // Assign values to subAccount object
                    subAccount.SubAccountTypeName = txt_subAccName.Text;
                    subAccount.MainAccountID = txt_mainAccId.Text;

                    // Call save function here
                    subAccount.SaveSubAccount(subAccount);

                    loadAccounts(false, true, false);

                    EnableAllControls();

                    isEditing = true;
                }
            }
        }

        private void btn_cancelSubAcc_Click(object sender, EventArgs e)
        {
            if (lstSubAccounts.Items.Count == 0)
            {
                txt_subAccId.Clear();
                txt_subAccName.Clear();
                return;
            }

            EnableAllControls();

            lstSubAccounts.SelectedIndex = 0;

            txt_subAccId.Text = subAccount.GetSubAccountIdByName(lstSubAccounts.SelectedItem.ToString().Trim()).ToString();

            txt_subAccName.Text=lstSubAccounts.SelectedItem.ToString();
        }

        private void lstSubAccounts_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (lstSubAccounts.SelectedItem == null)
            {
                return;
            }

            txt_subAccName.Text = lstSubAccounts.SelectedItem.ToString().Trim();

            txt_subAccId.Text = subAccount.GetSubAccountIdByName(txt_subAccName.Text.Trim()).ToString();

            loadAccounts(false, false, true);
        }

        private void btn_deleteSubAcc_Click(object sender, EventArgs e)
        {
            isDeleting = true;
            if (ValidateSubAccountForm())
            {
                subAccount.SubAccountTypeId = txt_subAccId.ToString().Trim();

                //subAccount.DeleteSubAccount(Convert.ToInt32(txt_subAccId.ToString().Trim()));
                subAccount.DeleteSubAccount(int.Parse(txt_subAccId.Text));

                loadAccounts(false, true, false);
            }
        }




        // accounts code 

        private bool ValidateAccountForm()
        {
            // Check if Account Name textbox is empty
            if (string.IsNullOrWhiteSpace(txt_accName.Text))
            {
                MessageBox.Show("براہ کرم ذیلی اکاؤنٹ کا نام درج کریں۔", "غلطی", MessageBoxButtons.OK, MessageBoxIcon.Error);
                txt_subAccName.Focus();
                return false;
            }

            // Check if sub Account ID textbox is empty
            if (string.IsNullOrWhiteSpace(txt_accId.Text))
            {
                MessageBox.Show("براہ کرم مین اکاؤنٹ منتخب کریں یا مین اکاؤنٹ آئی ڈی درج کریں۔", "غلطی", MessageBoxButtons.OK, MessageBoxIcon.Error);
                txt_mainAccId.Focus();
                return false;
            }

            // If editing or deleting, ensure a Sub Account ID is selected
            if ((isEditing || isDeleting) && string.IsNullOrWhiteSpace(txt_accId.Text))
            {
                MessageBox.Show("براہ کرم ایک ذیلی اکاؤنٹ منتخب کریں جسے آپ اپ ڈیٹ یا حذف کرنا چاہتے ہیں۔", "غلطی", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }

            // If everything is valid, return true
            return true;
        }

        private void btn_addAccount_Click(object sender, EventArgs e)
        {
            isEditing = false;

            txt_accId.Text = account.GetNextAccountId().ToString();
            txt_accName.Clear();

            DisableAllControlsExcept(btn_saveAcc, btn_cancelAcc);
        }

        private void btn_saveAcc_Click(object sender, EventArgs e)
        {
            if (ValidateAccountForm())
            {
                // Proceed with save or update operation
                if (isEditing)
                {
                    // Update existing account
                    account.accountId = txt_accId.Text;
                    account.accountName = txt_accName.Text;
                    account.subAccountTypeId = txt_subAccId.Text.ToString();
                    

                    account.UpdateAccount(account);

                    EnableAllControls();

                    // Reload accounts in the list after update
                    loadAccounts(false, false, true);
                }
                else
                {
                    // Save new account
                    account.accountName = txt_accName.Text;
                    account.subAccountTypeId = txt_subAccId.Text.Trim();

                    account.SaveAccount(account);

                    EnableAllControls();

                    // Reload accounts in the list after saving
                    loadAccounts(false, false, true);

                    // Set isEditing to true after saving to allow for editing
                    isEditing = true;
                }
            }
        }

        private void btn_cancelAcc_Click(object sender, EventArgs e)
        {
            if (lstAccounts.Items.Count == 0)
            {
                txt_accId.Clear();
                txt_accName.Clear();
                return;
            }

            EnableAllControls();

            lstAccounts.SelectedIndex = 0;

            txt_accId.Text = account.GetAccountIdByName(lstAccounts.SelectedItem.ToString().Trim()).ToString();

            txt_accName.Text = lstAccounts.SelectedItem.ToString();
        }

        private void btn_DeleteAcc_Click(object sender, EventArgs e)
        {
            isDeleting = true;
            if (ValidateSubAccountForm())
            {
                account.DeleteAccount(txt_accId.Text.Trim());

                loadAccounts(false, false, true);

                isDeleting = false;
            }
        }

        private void lstAccounts_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (lstAccounts.SelectedItem == null)
            {
                return;
            }

            txt_accName.Text = lstAccounts.SelectedItem.ToString().Trim();

            txt_accId.Text = account.GetAccountIdByName(txt_accName.Text.Trim()).ToString();

            
        }
    }
}
