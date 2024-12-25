using ALA_Accounting.transaction_classes;
using ALA_Accounting.UsersForm;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Security.AccessControl;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ALA_Accounting.TransactionForms
{
    public partial class BankPayment : Form
    {
        MDIParent1 dIParent1;

        BankPaymentClass bankPaymentClass=new BankPaymentClass();

        CommonFunctions commonFunctions = new CommonFunctions();

        


        public BankPayment(MDIParent1 mDI)
        {
            InitializeComponent();

            this.dIParent1 = mDI;
        }

        private void BankPayment_Load(object sender, EventArgs e)
        {
            txt_bankPaymentId.Text=bankPaymentClass.GetNextAvailableBankPaymentID().ToString();

            lstAccounts.Visible = false;
            lstBankAccount.Visible = false;

            bankPaymentClass.LoadBankPayments(dataGridView1, dIParent1.financialYearId,dtm_paymentDate.Value.Date);

            txt_accountId.Focus();
        }

        private bool ValidateBankPaymentForm()
        {
            // Check if AccountID is provided and numeric
            if (string.IsNullOrWhiteSpace(txt_accountId.Text) || !int.TryParse(txt_accountId.Text, out _))
            {
                MessageBox.Show("Account ID is required and must be a valid number.", "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                txt_accountId.Focus();
                return false;
            }

            // Check if AccountName is provided
            if (string.IsNullOrWhiteSpace(txt_accountName.Text))
            {
                MessageBox.Show("Account Name is required.", "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                txt_accountName.Focus();
                return false;
            }

            // Check if Amount is provided and a valid decimal
            if (string.IsNullOrWhiteSpace(txt_amount.Text) || !decimal.TryParse(txt_amount.Text, out _))
            {
                MessageBox.Show("Amount is required and must be a valid decimal value.", "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                txt_amount.Focus();
                return false;
            }

            // Check if BankAccountID is provided and numeric
            if (string.IsNullOrWhiteSpace(txt_bankAccount.Text) || !int.TryParse(txt_bankAccount.Text, out _))
            {
                MessageBox.Show("Bank Account ID is required and must be a valid number.", "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                txt_bankAccount.Focus();
                return false;
            }

            // Check if BankAccountName is provided
            //if (string.IsNullOrWhiteSpace(txt_bankAccountName.Text))
            //{
            //    MessageBox.Show("Bank Account Name is required.", "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            //    txt_bankAccountName.Focus();
            //    return false;
            //}

            // Check if BankPaymentID is provided and numeric (if applicable, may not be required for new payments)
            if (!string.IsNullOrWhiteSpace(txt_bankPaymentId.Text) && !int.TryParse(txt_bankPaymentId.Text, out _))
            {
                MessageBox.Show("Bank Payment ID must be a valid number if provided.", "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                txt_bankPaymentId.Focus();
                return false;
            }

            // If all validations pass, return true
            return true;
        }


        private void SaveBankPaymentHandler()
        {
            if (!ValidateBankPaymentForm())
            {
                MessageBox.Show("Please correct the errors in the form.", "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            BankPaymentClass bankPayment = new BankPaymentClass
            {
                BankPaymentID = !string.IsNullOrWhiteSpace(txt_bankPaymentId.Text) ? Convert.ToInt32(txt_bankPaymentId.Text) : 0,
                AccountID = Convert.ToInt32(txt_accountId.Text),
                AccountName = txt_accountName.Text.Trim(),
                PaymentDate = dtm_paymentDate.Value,
                BankAccountID = Convert.ToInt32(txt_bankAccount.Text),
                ChequeDate = txt_chequeDate.Text,
                ChequeNumber = txt_chequeNo.Text,
                Amount = Convert.ToDecimal(txt_amount.Text),
                Description = txt_description.Text.Trim(),
                IsCancelled = false,
                FinancialYearID = dIParent1.financialYearId
            };

            List<Transaction> transactions = new List<Transaction>();

            Transaction accountTransaction = new Transaction
            {
                AccountID = Convert.ToInt32(txt_accountId.Text),
                TransactionDate = dtm_paymentDate.Value,
                TransactionType = "debit",
                Amount = Convert.ToDecimal(txt_amount.Text),
                Description = txt_description.Text.Trim(),
                IsCancelled = false,
                FinancialYearID = dIParent1.financialYearId
            };

            transactions.Add(accountTransaction);

            Transaction bankTransaction = new Transaction
            {
                AccountID = Convert.ToInt32(txt_bankAccount.Text),
                TransactionDate = dtm_paymentDate.Value,
                TransactionType = "credit",
                Amount = Convert.ToDecimal(txt_amount.Text),
                Description = txt_description.Text.Trim(),
                IsCancelled = false,
                FinancialYearID = dIParent1.financialYearId
            };

            transactions.Add(bankTransaction);

            bool success = bankPayment.SaveBankPayment(bankPayment, transactions);
            if (success)
            {
                string bankAccountID = txt_bankAccount.Text;
                string bankName = txt_bankAccountName.Text;

                MessageBox.Show("Bank payment saved successfully.", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                commonFunctions.ClearAllTextBoxes(this);
                bankPaymentClass.LoadBankPayments(dataGridView1, dIParent1.financialYearId, dtm_paymentDate.Value.Date);
                txt_bankPaymentId.Text = bankPaymentClass.GetNextAvailableBankPaymentID().ToString();
                txt_bankAccount.Text = bankAccountID;
                txt_bankAccountName.Text = bankName;
            }
            else
            {
                MessageBox.Show("Failed to save bank payment.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void UpdateBankPaymentHandler()
        {
            if (!ValidateBankPaymentForm())
            {
                MessageBox.Show("Please correct the errors in the form.", "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            BankPaymentClass bankPayment = new BankPaymentClass
            {
                BankPaymentID = !string.IsNullOrWhiteSpace(txt_bankPaymentId.Text) ? Convert.ToInt32(txt_bankPaymentId.Text) : 0,
                AccountID = Convert.ToInt32(txt_accountId.Text),
                AccountName = txt_accountName.Text.Trim(),
                PaymentDate = dtm_paymentDate.Value,
                BankAccountID = Convert.ToInt32(txt_bankAccount.Text),
                ChequeDate = txt_chequeDate.Text,
                ChequeNumber = txt_chequeNo.Text,
                Amount = Convert.ToDecimal(txt_amount.Text),
                Description = txt_description.Text.Trim(),
                IsCancelled = false,
                FinancialYearID = dIParent1.financialYearId
            };

            List<Transaction> updatedTransactions = new List<Transaction>();

            Transaction accountTransaction = new Transaction
            {
                AccountID = Convert.ToInt32(txt_accountId.Text),
                TransactionDate = dtm_paymentDate.Value,
                TransactionType = "debit",
                Amount = Convert.ToDecimal(txt_amount.Text),
                Description = txt_description.Text.Trim(),
                IsCancelled = false,
                FinancialYearID = dIParent1.financialYearId
            };

            updatedTransactions.Add(accountTransaction);

            Transaction bankTransaction = new Transaction
            {
                AccountID = Convert.ToInt32(txt_bankAccount.Text),
                TransactionDate = dtm_paymentDate.Value,
                TransactionType = "credit",
                Amount = Convert.ToDecimal(txt_amount.Text),
                Description = txt_description.Text.Trim(),
                IsCancelled = false,
                FinancialYearID = dIParent1.financialYearId
            };

            updatedTransactions.Add(bankTransaction);

            bool success = bankPayment.UpdateBankPayment(bankPayment, updatedTransactions);
            if (success)
            {
                string bankAccountID = txt_bankAccount.Text;
                string bankName = txt_bankAccountName.Text;

                MessageBox.Show("Bank payment updated successfully.", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                commonFunctions.ClearAllTextBoxes(this);
                bankPaymentClass.LoadBankPayments(dataGridView1, dIParent1.financialYearId, dtm_paymentDate.Value.Date);
                txt_bankPaymentId.Text = bankPaymentClass.GetNextAvailableBankPaymentID().ToString();
                txt_bankAccount.Text = bankAccountID; // Example ID
                txt_bankAccountName.Text = bankName;
            }
            else
            {
                MessageBox.Show("Failed to update bank payment.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btn_save_Click(object sender, EventArgs e)
        {
            if (bankPaymentClass.BankPaymentExists(Convert.ToInt32(txt_bankPaymentId.Text)))
            {
                UpdateBankPaymentHandler();
            }
            else
            {
                SaveBankPaymentHandler();
            }
        }

        private void btn_addNew_Click(object sender, EventArgs e)
        {
            commonFunctions.ClearAllTextBoxes(this);

            txt_bankPaymentId.Text = bankPaymentClass.GetNextAvailableBankPaymentID().ToString();

            txt_accountId.Focus();


        }

        private void btn_delete_Click(object sender, EventArgs e)
        {
            int bankPaymentID = Convert.ToInt32(txt_bankPaymentId.Text);

            if (bankPaymentClass.BankPaymentExists(bankPaymentID))
            {
                bankPaymentClass.DeleteBankPaymentById(bankPaymentID);
                bankPaymentClass.LoadBankPayments(dataGridView1, dIParent1.financialYearId, dtm_paymentDate.Value.Date);
                commonFunctions.ClearAllTextBoxes(this);
                //txtba.Text = "3";
                //txt_cashAccountName.Text = "Cash in hand";
                txt_bankPaymentId.Text = bankPaymentClass.GetNextAvailableBankPaymentID().ToString();

                bankPaymentClass.LoadBankPayments(dataGridView1,dIParent1.financialYearId,dtm_paymentDate.Value.Date);
            }
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void txt_accountId_TextChanged(object sender, EventArgs e)
        {
            if (txt_accountId.Text == "")
            {
                lstAccounts.Visible = false;
                return;
            }

            commonFunctions.ShowAccountSuggestions(txt_accountId, lstAccounts, "allAccount");
        }

        private void txt_accountId_KeyDown(object sender, KeyEventArgs e)
        {
            commonFunctions.HandleAccountSuggestionKeyDown(txt_accountId, txt_accountName, lstAccounts, e, this);
        }

        private void txt_bankAccount_TextChanged(object sender, EventArgs e)
        {
            if (txt_bankAccount.Text == "")
            {
                lstAccounts.Visible = false;
            }

            commonFunctions.ShowAccountSuggestions(txt_bankAccount, lstBankAccount, "allAccount");
        }

        private void txt_bankAccount_KeyDown(object sender, KeyEventArgs e)
        {
            commonFunctions.HandleAccountSuggestionKeyDown(txt_bankAccount,txt_bankAccountName, lstBankAccount, e, this);
        }

        private void txt_bankAccount_Leave(object sender, EventArgs e)
        {
            lstBankAccount.Visible = false;
        }

        private void txt_accountId_Leave(object sender, EventArgs e)
        {
            lstAccounts.Visible = false;
        }

        private void dataGridView1_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0 && dataGridView1.Rows[e.RowIndex].IsNewRow == false)
            {
                DataGridViewRow selectedRow = dataGridView1.Rows[e.RowIndex];

                // Populate text boxes with the selected row's values
                txt_bankPaymentId.Text = selectedRow.Cells["bankPaymentId"].Value?.ToString();
                dtm_paymentDate.Text = selectedRow.Cells["date"].Value?.ToString();
                txt_accountId.Text = selectedRow.Cells["accountId"].Value?.ToString();
                txt_accountName.Text = selectedRow.Cells["AccountName"].Value?.ToString();
                txt_amount.Text = selectedRow.Cells["amount"].Value?.ToString();
                txt_description.Text = selectedRow.Cells["description"].Value?.ToString();
                txt_bankAccount.Text = selectedRow.Cells["bankAccountID"].Value?.ToString();
                txt_chequeDate.Text = selectedRow.Cells["chequeDate"].Value?.ToString();
                txt_chequeNo.Text = selectedRow.Cells["chequeNumber"].Value?.ToString();
                //txt_bankAccount.Text = selectedRow.Cells["bankAccountID"].Value?.ToString();
            }
        }

        private void btn_back_Click(object sender, EventArgs e)
        {

        }

        private void btn_forward_Click(object sender, EventArgs e)
        {

        }
    }
}
