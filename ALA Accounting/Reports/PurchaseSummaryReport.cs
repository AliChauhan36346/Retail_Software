using ALA_Accounting.Addition;
using ALA_Accounting.Reports_Classes;
using ALA_Accounting.TransactionForms;
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

namespace ALA_Accounting.Reports
{
    public partial class PurchaseSummaryReport : Form
    {
        PurchaseReportClass purchaseReport = new PurchaseReportClass();
        
        private int FinancialYearID;

        public PurchaseSummaryReport(int FinancialYearID)
        {
            this.FinancialYearID = FinancialYearID;
            InitializeComponent();
        }

        private void PurchaseSummaryReport_Load(object sender, EventArgs e)
        {
            cmbo_vendorType.Enabled = false;
            cmbo_employee.Enabled = false;
            txt_accountId.Enabled = false;
            txt_accountName.Enabled = false;
            dtmStart.Enabled = false;
            dtmEnd.Enabled = false;

            LoadVendorTypes();
            LoadPurchaseData(FinancialYearID);

            dtmStart.Value = dtmEnd.Value = DateTime.Now;
            
        }

        private void LoadVendorTypes()
        {
            string mainAccountId = "5"; // Set this to the correct ID for customers
            List<KeyValuePair<int, string>> customerTypes = new SalesReportClass().LoadSubAccountIdsAndNamesByMainAccountId(mainAccountId);

            cmbo_vendorType.DataSource = new BindingSource(customerTypes, null);
            cmbo_vendorType.DisplayMember = "Value";  // Show only the name
            cmbo_vendorType.ValueMember = "Key";      // Store only the ID

            cmbo_vendorType.SelectedIndex = -1;

        }

        private void btn_search_Click(object sender, EventArgs e)
        {
            ApplyFilters();
        }

        private void LoadPurchaseData(int financialYearId)
        {
            DataTable purchaseData = purchaseReport.GetPurchaseData(financialYearId);
            purchaseSummaryBindingSource.DataSource = purchaseData;

            dataGridView2.AutoGenerateColumns = false;

            dataGridView2.DataSource = purchaseSummaryBindingSource;

            CalculateTotals();
        }

        private void CalculateTotals()
        {
            decimal totalGross = 0;
            decimal totalNet = 0;

            foreach (DataGridViewRow row in dataGridView2.Rows)
            {
                if (row.Cells["GrossTotal"].Value != null)
                    totalGross += Convert.ToDecimal(row.Cells["GrossTotal"].Value);

                if (row.Cells["NetTotal"].Value != null)
                    totalNet += Convert.ToDecimal(row.Cells["NetTotal"].Value);
            }

            // Assign totals to textboxes
            txt_totalGross.Text = totalGross.ToString("N2");
            txt_totalNet.Text = totalNet.ToString("N2");
        }

        private void ApplyFilters()
        {
            List<string> filters = new List<string>();

            // Example: Filtering by Customer ID (if checkbox is checked)
            if (chk_customer.Checked && !string.IsNullOrWhiteSpace(txt_accountId.Text))
            {
                filters.Add($"AccountID = {txt_accountId.Text}");
            }

            // Example: Filtering by Employee Reference
            if (chk_employee.Checked && cmbo_employee.SelectedItem != null)
            {
                filters.Add($"employeeReference = '{cmbo_employee.SelectedItem}'");
            }

            // Example: Filtering by Date Range
            if (chk_date.Checked)
            {
                string startDate = dtmStart.Value.ToString("yyyy-MM-dd");
                string endDate = dtmEnd.Value.ToString("yyyy-MM-dd");
                filters.Add($"InvoiceDate >= '{startDate}' AND InvoiceDate <= '{endDate}'");
            }


            // Filter by Customer Type (Sub-Accounts of Customers)
            if (chk_vendorType.Checked && cmbo_vendorType.SelectedItem != null)
            {
                int subAccountId = (int)cmbo_vendorType.SelectedValue;  // Get only the ID
                List<int> accountIds = new SalesReportClass().GetAccountIdsBySubAccountId(subAccountId);

                if (accountIds.Count > 0)
                {
                    string accountIdList = string.Join(",", accountIds);
                    filters.Add($"AccountID IN ({accountIdList})");
                }
                else
                {
                    MessageBox.Show("No accounts found for this Vendor or Supplier type.");
                    return;
                }
            }

            // Apply filters to BindingSource
            purchaseSummaryBindingSource.Filter = string.Join(" AND ", filters);

            CalculateTotals();
        }

        private void chk_customerType_CheckedChanged(object sender, EventArgs e)
        {
            if(chk_vendorType.Checked)
            {
                cmbo_vendorType.Enabled = true;
            }
            else
            {
                cmbo_vendorType.Enabled = false;
            }  
        }

        private void chk_customer_CheckedChanged(object sender, EventArgs e)
        {
            if(chk_customer.Checked)
            {
                txt_accountId.Enabled = true;
                txt_accountName.Enabled = true;
            }
            else
            {
                txt_accountId.Enabled = false;
                txt_accountName.Enabled = false;
            }
        }

        private void chk_employee_CheckedChanged(object sender, EventArgs e)
        {
            if(chk_employee.Checked)
            {
                cmbo_employee.Enabled = true;
            }
            else
            {
                cmbo_employee.Enabled = false;
            }
        }

        private void chk_date_CheckedChanged(object sender, EventArgs e)
        {
            if(chk_date.Checked)
            {
                dtmStart.Enabled = true;
                dtmEnd.Enabled = true;
            }
            else
            {
                dtmStart.Enabled = false;
                dtmEnd.Enabled = false;
            }
        }

        private void dataGridView2_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {   // ensure the row is not a new row


            if (!dataGridView2.Rows[e.RowIndex].IsNewRow && e.RowIndex>=0)
            {

                DataGridViewRow selectedRow = dataGridView2.Rows[e.RowIndex];
                int purchaseInvoiceId = int.Parse(selectedRow.Cells["PurchaseInvoiceID"].Value.ToString()); // Get Transaction ID

                
                Form childForm = null; // Declare form variable

                // Open the respective form as an MDI child

                childForm = new purchase(FinancialYearID, purchaseInvoiceId);

                // If a form was created, open it in the parent as an MDI child
                if (childForm != null)
                {
                    childForm.MdiParent = this.MdiParent; // Set MDI parent
                    //childForm.WindowState = FormWindowState.Maximized; // Optional: Open maximized
                    childForm.Show();
                }
                
            }
        }
    }
}
