using ALA_Accounting.Reports_Classes;
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
    public partial class saleSummaryReportForm : Form
    {
        SalesReportClass salesReport = new SalesReportClass();

        private static saleSummaryReportForm saleSummaryReportFormInstance;

        int FinancialYearId;

        public static saleSummaryReportForm getInstance(int financialYearId)
        {
            if (saleSummaryReportFormInstance == null)
            {
                saleSummaryReportFormInstance = new saleSummaryReportForm(financialYearId);
            }

            return saleSummaryReportFormInstance;
        }

        private saleSummaryReportForm(int financialYearId)
        {
            InitializeComponent();
            this.FinancialYearId = financialYearId;
        }

        private void txt_accountName_TextChanged(object sender, EventArgs e)
        {

        }

        private void saleSummaryReport_Load(object sender, EventArgs e)
        {
            cmbo_customerType.Enabled = false;
            cmbo_employee.Enabled = false;
            dtmStart.Enabled = false;
            dtmEnd.Enabled = false;
            txt_accountId.Enabled = false;
            txt_accountName.Enabled = false;

            LoadSalesData(FinancialYearId);
            LoadCustomerTypes();


            
        }

        private void LoadCustomerTypes()
        {
            string mainAccountId = "2"; // Set this to the correct ID for customers
            List<KeyValuePair<int, string>> customerTypes = salesReport.LoadSubAccountIdsAndNamesByMainAccountId(mainAccountId);

            cmbo_customerType.DataSource = new BindingSource(customerTypes, null);
            cmbo_customerType.DisplayMember = "Value";  // Show only the name
            cmbo_customerType.ValueMember = "Key";      // Store only the ID

            cmbo_customerType.SelectedIndex = -1;

        }


        private void LoadSalesData(int financialYearID)
        {
            DataTable salesData = salesReport.GetSalesData(financialYearID); // Fetch data

            // Bind data to the BindingSource
            SaleSummaryBindingSource.DataSource = salesData;

            dataGridView2.AutoGenerateColumns = false;

            // Assign BindingSource to DataGridView
            dataGridView2.DataSource = SaleSummaryBindingSource;

            // Calculate totals
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

            // Filter by Specific Customer ID
            if (chk_customer.Checked && !string.IsNullOrWhiteSpace(txt_accountId.Text))
            {
                filters.Add($"AccountID = {txt_accountId.Text}"); // Ensure txt_accountId contains only numbers
            }

            // Filter by Customer Type (Sub-Accounts of Customers)
            if (chk_customerType.Checked && cmbo_customerType.SelectedItem != null)
            {
                int subAccountId = (int)cmbo_customerType.SelectedValue;  // Get only the ID
                List<int> accountIds = salesReport.GetAccountIdsBySubAccountId(subAccountId);

                if (accountIds.Count > 0)
                {
                    string accountIdList = string.Join(",", accountIds);
                    filters.Add($"AccountID IN ({accountIdList})");
                }
                else
                {
                    MessageBox.Show("No accounts found for this customer type.");
                    return;
                }
            }


            // Filter by Employee
            //if (chk_employee.Checked && cmbo_employee.SelectedItem != null)
            //{
            //    filters.Add($"employeeReference = '{cmbo_employee.SelectedItem.ToString().Replace("'", "''")}'");
            //}

            // Filter by Date Range
            if (chk_date.Checked)
            {
                string startDate = dtmStart.Value.ToString("yyyy-MM-dd");
                string endDate = dtmEnd.Value.ToString("yyyy-MM-dd");
                filters.Add($"InvoiceDate >= #{startDate}# AND InvoiceDate <= #{endDate}#"); // Use '#' for date filtering
            }

            // Apply the filter if there are any conditions
            if (filters.Count > 0)
            {
                SaleSummaryBindingSource.Filter = string.Join(" AND ", filters);
            }
            else
            {
                SaleSummaryBindingSource.RemoveFilter(); // Remove filter if no conditions
            }

            // Recalculate totals after filtering
            CalculateTotals();
        }


        private void btn_search_Click(object sender, EventArgs e)
        {
            ApplyFilters();
        }

        private void chk_customerType_CheckedChanged(object sender, EventArgs e)
        {
            if(chk_customerType.Checked)
            {
                cmbo_customerType.Enabled = true;
            }
            else
            {
                cmbo_customerType.Enabled = false;
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

        private void cmbo_customerType_SelectedIndexChanged(object sender, EventArgs e)
        {
            

            //label2.Text=cmbo_customerType.SelectedValue.ToString();
        }
    }
}
