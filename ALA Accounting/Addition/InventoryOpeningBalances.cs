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
    public partial class InventoryOpeningBalances : Form
    {
        //MDIParent1 dIParent1 = new MDIParent1();

        AddInventoryOpeningBalances openingBalances = new AddInventoryOpeningBalances();

        CommonFunctions functions = new CommonFunctions();



        private MDIParent1 dIParent1;

        public InventoryOpeningBalances(MDIParent1 parent)
        {
            InitializeComponent();
            this.dIParent1 = parent;
        }



        private void InventoryOpeningBalances_Load(object sender, EventArgs e)
        {
            openingBalances.LoadInventoryOpeningBalances(dataGridView2, dIParent1.financialYearId,out decimal totalOpeningAmount);

            btn_addNew_Click(sender, e);
            txt_openingamount.Text= totalOpeningAmount.ToString();
            label9.Text = dIParent1.financialYearId.ToString();

            lstInventory.Visible = false;
        }

        private void btn_addNew_Click(object sender, EventArgs e)
        {
            ClearAllTextBoxes(this);

            txt_openingId.Text=openingBalances.GetNextAvailableOpeningBalanceID().ToString();

            txt_itemId.Focus();
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

        private void btn_save_Click(object sender, EventArgs e)
        {
            

            if (!ValidateFields())
            {
                return;
            }

            if (openingBalances.RecordExists(txt_openingId.Text.Trim()))
            {
                openingBalances.itemId = txt_itemId.Text;
                openingBalances.quantity = txt_quantity.Text;
                openingBalances.unit = txt_unit.Text;
                openingBalances.rate = txt_rate.Text;
                openingBalances.openingId = txt_openingId.Text;


                openingBalances.UpdateInventoryOpeningBalance(openingBalances, dIParent1.financialYearId);

                btn_addNew_Click(sender, e);

                openingBalances.LoadInventoryOpeningBalances(dataGridView2, dIParent1.financialYearId, out decimal totalOpeningAmount);

                txt_openingamount.Text = totalOpeningAmount.ToString();
            }
            else
            {
                openingBalances.itemId = txt_itemId.Text;
                openingBalances.quantity = txt_quantity.Text;
                openingBalances.unit = txt_unit.Text;
                openingBalances.rate = txt_rate.Text;
                openingBalances.openingId = txt_openingId.Text;


                openingBalances.SaveInventoryOpeningBalance(openingBalances, dIParent1.financialYearId);

                btn_addNew_Click(sender, e);

                openingBalances.LoadInventoryOpeningBalances(dataGridView2, dIParent1.financialYearId, out decimal totalOpeningAmount);

                txt_openingamount.Text= totalOpeningAmount.ToString();
            }

            txt_itemId.Focus();
        }

        private void txt_itemId_Leave(object sender, EventArgs e)
        {
            lstInventory.Visible = false;

            if (!string.IsNullOrWhiteSpace(txt_itemId.Text))
            {
                // Call the function and get the results
                (string rate, string unit) = openingBalances.GetItemDetails(txt_itemId.Text.Trim());

                // Populate the text boxes with the retrieved values
                txt_rate.Text = rate;
                txt_unit.Text = unit;
            }
        }

        private bool ValidateFields()
        {
            if (string.IsNullOrWhiteSpace(txt_itemId.Text))
            {
                MessageBox.Show("Item ID is required.", "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txt_itemId.Focus();
                return false;
            }

            if (string.IsNullOrWhiteSpace(txt_itemName.Text))
            {
                MessageBox.Show("Item Name is required.", "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txt_itemName.Focus();
                return false;
            }

            if (string.IsNullOrWhiteSpace(txt_quantity.Text) || !decimal.TryParse(txt_quantity.Text, out _))
            {
                MessageBox.Show("Valid Quantity is required.", "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txt_quantity.Focus();
                return false;
            }

            if (string.IsNullOrWhiteSpace(txt_rate.Text) || !decimal.TryParse(txt_rate.Text, out _))
            {
                MessageBox.Show("Valid Rate is required.", "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txt_rate.Focus();
                return false;
            }

            if (string.IsNullOrWhiteSpace(txt_unit.Text))
            {
                MessageBox.Show("Unit is required.", "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txt_unit.Focus();
                return false;
            }

            return true; // All validations passed
        }


        private void btn_cancel_Click(object sender, EventArgs e)
        {
            ClearAllTextBoxes(this);
            txt_itemId.Focus();
        }

        private void btn_delete_Click(object sender, EventArgs e)
        {
            //if (ValidateFields())
            //{
                openingBalances.DeleteInventoryOpeningBalance(int.Parse(txt_openingId.Text.Trim()));

                openingBalances.LoadInventoryOpeningBalances(dataGridView2, dIParent1.financialYearId, out decimal totalOpeningAmount);

                btn_addNew_Click(sender, e);
                txt_openingamount.Text= totalOpeningAmount.ToString();


            //}
        }

        private void dataGridView2_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            // Check if the row index is valid and not a new (empty) row
            if (e.RowIndex >= 0 && dataGridView2.Rows[e.RowIndex].IsNewRow == false)
            {
                DataGridViewRow selectedRow = dataGridView2.Rows[e.RowIndex];

                // Populate text boxes with the selected row's values
                txt_itemId.Text = selectedRow.Cells["ItemID"].Value?.ToString();
                txt_itemName.Text = selectedRow.Cells["itemName"].Value?.ToString();
                txt_quantity.Text = selectedRow.Cells["quantity"].Value?.ToString();
                txt_unit.Text = selectedRow.Cells["unit"].Value?.ToString();
                txt_rate.Text = selectedRow.Cells["rate"].Value?.ToString();
                txt_amount.Text = selectedRow.Cells["amount"].Value?.ToString();
                txt_openingId.Text = selectedRow.Cells["openingBalanceID"].Value?.ToString();
            }
        }

        private void txt_itemId_TextChanged(object sender, EventArgs e)
        {
            functions.ShowAccountSuggestions(txt_itemId, lstInventory, "inventory");

            if (txt_itemId.Text == "")
            {
                lstInventory.Visible = false;
            }
        }

        private void txt_itemId_KeyDown(object sender, KeyEventArgs e)
        {
            functions.HandleAccountSuggestionKeyDown(txt_itemId, txt_itemName, lstInventory, e, txt_itemName);

            if (e.KeyCode == Keys.Enter)
            {
                txt_itemName.Focus();
            }
        }

        private void txt_itemName_KeyDown(object sender, KeyEventArgs e)
        {
            if(e.KeyCode == Keys.Enter)
            {
                txt_quantity.Focus();
                e.SuppressKeyPress = true;
            }
        }

        private void txt_unit_KeyDown(object sender, KeyEventArgs e)
        {
            if(e.KeyCode== Keys.Enter)
            {
                txt_rate.Focus();

                e.SuppressKeyPress= true;
            }
        }

        private void txt_rate_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                btn_save.Focus();

                e.SuppressKeyPress = true;
            }
        }

        

        private void guna2TextBox1_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                txt_unit.Focus();

                e.SuppressKeyPress = true;
            }
        }
    }


}
