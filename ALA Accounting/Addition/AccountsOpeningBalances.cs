using ALA_Accounting.Addition_Classes;
using ALA_Accounting.transaction_classes;
using ALA_Accounting.UsersForm;
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
    public partial class AccountsOpeningBalances : Form
    {
        AccountsOpeningBalancessClass openingBalance=new AccountsOpeningBalancessClass();
        private MDIParent1 dIParent1;
        CommonFunctions commonFunctions=new CommonFunctions();


        public AccountsOpeningBalances(MDIParent1 parent)
        {
            InitializeComponent();
            this.dIParent1 = parent;
        }

        private void btn_save_Click(object sender, EventArgs e)
        {
            if (!ValidateForm())
            {
                return;
            }

            if (openingBalance.RecordExists(txt_openingId.Text.Trim()))
            {
                openingBalance.accountID = txt_accountId.Text;
                openingBalance.accountName=txt_AccountName.Text;
                openingBalance.debit= txt_debit.Text;
                openingBalance.credit= txt_credit.Text;

                openingBalance.openingId=txt_openingId.Text.Trim();

                openingBalance.UpdateAccountOpeningBalances(openingBalance);

                commonFunctions.ClearAllTextBoxes(this);

                txt_openingId.Text=openingBalance.GetNextAvailableAccountsOpeningBalancesID().ToString();

                txt_accountId.Focus();

                openingBalance.LoadAccountsOpeningBalances(dataGridView2, dIParent1.financialYearId);


            }
            else
            {
                openingBalance.accountID = txt_accountId.Text;
                openingBalance.accountName = txt_AccountName.Text;
                openingBalance.debit = txt_debit.Text;
                openingBalance.credit = txt_credit.Text;

                openingBalance.SaveAccountOpeningBalances(openingBalance,dIParent1.financialYearId);

                commonFunctions.ClearAllTextBoxes(this);

                txt_openingId.Text = openingBalance.GetNextAvailableAccountsOpeningBalancesID().ToString();

                txt_accountId.Focus();

                openingBalance.LoadAccountsOpeningBalances(dataGridView2, dIParent1.financialYearId);

            }
        }

        private void txt_credit_TextChanged(object sender, EventArgs e)
        {
            if (!string.IsNullOrEmpty(txt_credit.Text))
            {
                txt_debit.Enabled = false;
            }
            else
            {
                txt_debit.Enabled = true;
            }
        }

        private bool ValidateForm()
        {
            // Check if the Opening ID, Account ID, and Account Name fields are filled
            if (string.IsNullOrWhiteSpace(txt_openingId.Text))
            {
                MessageBox.Show("اوپننگ آئی ڈی درج کریں۔", "تصدیقی خرابی", MessageBoxButtons.OK, MessageBoxIcon.Error);
                txt_openingId.Focus();
                return false;
            }

            if (string.IsNullOrWhiteSpace(txt_accountId.Text))
            {
                MessageBox.Show("اکاؤنٹ آئی ڈی درج کریں۔", "تصدیقی خرابی", MessageBoxButtons.OK, MessageBoxIcon.Error);
                txt_accountId.Focus();
                return false;
            }

            if (string.IsNullOrWhiteSpace(txt_AccountName.Text))
            {
                MessageBox.Show("اکاؤنٹ کا نام درج کریں۔", "تصدیقی خرابی", MessageBoxButtons.OK, MessageBoxIcon.Error);
                txt_AccountName.Focus();
                return false;
            }

            // Ensure that either Debit or Credit is filled, but not both
            if (string.IsNullOrWhiteSpace(txt_debit.Text) && string.IsNullOrWhiteSpace(txt_credit.Text))
            {
                MessageBox.Show("ڈیبیٹ یا کریڈٹ میں سے ایک لازمی درج کریں۔", "تصدیقی خرابی", MessageBoxButtons.OK, MessageBoxIcon.Error);
                txt_debit.Focus();
                return false;
            }

            if (!string.IsNullOrWhiteSpace(txt_debit.Text) && !string.IsNullOrWhiteSpace(txt_credit.Text))
            {
                MessageBox.Show("ڈیبیٹ یا کریڈٹ میں سے صرف ایک درج کریں، دونوں نہیں۔", "تصدیقی خرابی", MessageBoxButtons.OK, MessageBoxIcon.Error);
                txt_debit.Focus();
                return false;
            }

            // Ensure that Debit and Credit values are numeric
            if (!string.IsNullOrWhiteSpace(txt_debit.Text) && !decimal.TryParse(txt_debit.Text, out _))
            {
                MessageBox.Show("ڈیبیٹ کے لیے درست عددی قدر درج کریں۔", "تصدیقی خرابی", MessageBoxButtons.OK, MessageBoxIcon.Error);
                txt_debit.Focus();
                return false;
            }

            if (!string.IsNullOrWhiteSpace(txt_credit.Text) && !decimal.TryParse(txt_credit.Text, out _))
            {
                MessageBox.Show("کریڈٹ کے لیے درست عددی قدر درج کریں۔", "تصدیقی خرابی", MessageBoxButtons.OK, MessageBoxIcon.Error);
                txt_credit.Focus();
                return false;
            }

            // If all validations pass
            return true;
        }

        private void btn_addNew_Click(object sender, EventArgs e)
        {
            commonFunctions.ClearAllTextBoxes(this);

            txt_openingId.Text=openingBalance.GetNextAvailableAccountsOpeningBalancesID().ToString();

            txt_accountId.Focus();
        }

        private void btn_cancel_Click(object sender, EventArgs e)
        {
            commonFunctions.ClearAllTextBoxes(this);

            txt_accountId.Focus();
        }

        private void btn_delete_Click(object sender, EventArgs e)
        {
            //if (ValidateForm())
            //{
                openingBalance.DeleteAccountsOpeningBalances(int.Parse(txt_openingId.Text.Trim()));

                openingBalance.LoadAccountsOpeningBalances(dataGridView2, dIParent1.financialYearId);

                btn_addNew_Click(sender, e);
            //}
        }

        private void AccountsOpeningBalances_Load(object sender, EventArgs e)
        {
            openingBalance.GetNextAvailableAccountsOpeningBalancesID();

            openingBalance.LoadAccountsOpeningBalances(dataGridView2, dIParent1.financialYearId);

            btn_addNew_Click(sender , e);

            lst_Accounts.Visible = false;
        }

        private void dataGridView2_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            // Ensure the clicked cell is valid
            if (e.RowIndex >= 0 && e.ColumnIndex >= 0 && dataGridView2.Rows[e.RowIndex].IsNewRow == false)
            {
                DataGridViewRow selectedRow = dataGridView2.Rows[e.RowIndex];

                // Assuming you have textboxes named txtAccountID, txtAccountName, txtDebit, and txtCredit
                txt_accountId.Text = selectedRow.Cells["AccountID"].Value.ToString();
                txt_AccountName.Text = selectedRow.Cells["AccountName"].Value.ToString();
                txt_openingId.Text = selectedRow.Cells["AccountsOpeningBalanceID"].Value.ToString();

                // Check if the Debit value is 0 and convert it to an empty string if it is
                decimal debitValue = Convert.ToDecimal(selectedRow.Cells["Debit"].Value);
                txt_debit.Text = debitValue == 0 ? "" : debitValue.ToString();

                // Check if the Credit value is 0 and convert it to an empty string if it is
                decimal creditValue = Convert.ToDecimal(selectedRow.Cells["Credit"].Value);
                txt_credit.Text = creditValue == 0 ? "" : creditValue.ToString();
            }
        }

        private void txt_accountId_TextChanged(object sender, EventArgs e)
        {
            commonFunctions.ShowAccountSuggestions(txt_accountId, lst_Accounts, "allAccount");

            if (txt_accountId.Text == "")
            {
                lst_Accounts.Visible = false;
            }
        }

        private void txt_accountId_KeyDown(object sender, KeyEventArgs e)
        {
            commonFunctions.HandleAccountSuggestionKeyDown(txt_accountId, txt_AccountName, lst_Accounts, e, txt_AccountName);
        }

        private void txt_accountId_Leave(object sender, EventArgs e)
        {
            lst_Accounts.Visible = false;
        }

        private void txt_debit_TextChanged_1(object sender, EventArgs e)
        {
            if (!string.IsNullOrEmpty(txt_debit.Text))
            {
                txt_credit.Enabled = false;
            }
            else
            {
                txt_credit.Enabled = true;
            }
        }


    }
}
