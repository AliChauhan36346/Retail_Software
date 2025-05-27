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
    public partial class ItemWiseProfitLossForm : Form
    {
        int financialYearId;

        ItemWiseProfitLossClass profitLossClass;

        public ItemWiseProfitLossForm(int financialYearId)
        {
            InitializeComponent();
            this.financialYearId = financialYearId;
            profitLossClass = new ItemWiseProfitLossClass();
        }



        private void ItemWiseProfitLossForm_Load(object sender, EventArgs e)
        {
            LoadCategories();
            LoadBrands();  
            DisableControlsOnLoad();

            rdo_allInventory.Checked = true;

            dtmStart.Value = dtmEnd.Value = DateTime.Now;
        }

        private void DisableControlsOnLoad()
        {
            cmbo_catagory.Enabled = false;
            cmbo_subCatagory.Enabled = false;
            cmbo_brandName.Enabled = false;
            dtmStart.Enabled = false;
            dtmEnd.Enabled = false;
        }

        private void LoadCategories()
        {
            var categories = profitLossClass.GetCategories();
            cmbo_catagory.DataSource = new BindingSource(categories, null);
            cmbo_catagory.DisplayMember = "Value"; // Show category name
            cmbo_catagory.ValueMember = "Key"; // Store category ID
            cmbo_catagory.SelectedIndex = -1; // No default selection
        }

        private void LoadSubCategories(int categoryId)
        {
            cmbo_subCatagory.DataSource = new BindingSource().DataSource=profitLossClass.GetSubCategories(categoryId);
            cmbo_subCatagory.DisplayMember = "Value"; // Show subcategory name
            cmbo_subCatagory.ValueMember = "Key"; // Store subcategory ID
            cmbo_subCatagory.SelectedIndex = -1;
        }

        private void LoadBrands()
        {
            var brands = profitLossClass.GetBrands();
            cmbo_brandName.DataSource = brands;
            cmbo_brandName.SelectedIndex = -1;
        }

        private void btn_search_Click(object sender, EventArgs e)
        {
            // Get selected category ID (if applicable)

            int? categoryID = rdo_catagory.Checked && cmbo_catagory.SelectedValue != null
                ? (int?)Convert.ToInt32(cmbo_catagory.SelectedValue)
                : null;

            // Get selected subcategory ID (if applicable)
            int? subCategoryID = chk_subCatagory.Checked && cmbo_subCatagory.SelectedValue != null
                ? (int?)Convert.ToInt32(cmbo_subCatagory.SelectedValue)
                : null;

            // Get selected brand (if applicable)
            string brand = chk_brandName.Checked && cmbo_brandName.SelectedValue != null
                ? cmbo_brandName.SelectedValue.ToString()
                : null;

            // Get date range (if applicable)
            DateTime? startDate = chk_date.Checked ? (DateTime?)dtmStart.Value.Date : null;
            DateTime? endDate = chk_date.Checked ? (DateTime?)dtmEnd.Value.Date : null;

            // Load filtered data
            DataTable filteredData = profitLossClass.LoadData(financialYearId, categoryID, subCategoryID, brand, startDate, endDate);

            dataGridView2.AutoGenerateColumns = false;

            // Bind data to DataGridView
            dataGridView2.DataSource = filteredData;

            CalculateTotals();
        }

        private void CalculateTotals()
        {
            decimal totalProfitLoss = 0;
            decimal totalSalesValue = 0;
            decimal totalCost = 0;

            foreach (DataGridViewRow row in dataGridView2.Rows)
            {
                if (row.Cells["ProfitLoss"].Value != DBNull.Value)
                    totalProfitLoss += Convert.ToDecimal(row.Cells["ProfitLoss"].Value);

                if (row.Cells["SalesValue"].Value != DBNull.Value)
                    totalSalesValue += Convert.ToDecimal(row.Cells["SalesValue"].Value);

                if (row.Cells["TotalCost"].Value != DBNull.Value)
                    totalCost += Convert.ToDecimal(row.Cells["TotalCost"].Value);
            }


            txt_totalProfitLoss.Text = totalProfitLoss.ToString("N0");
            if(totalProfitLoss<0)
            {
                txt_totalProfitLoss.ForeColor = Color.Red;
            }
            else
            {
                txt_totalProfitLoss.ForeColor = Color.Green;
            }
            txt_totalSalesValue.Text = totalSalesValue.ToString("N0");
            txt_totalCost.Text = totalCost.ToString("N0");
        }


        private void rdo_allInventory_CheckedChanged(object sender, EventArgs e)
        {
            
        }

        private void rdo_catagory_CheckedChanged(object sender, EventArgs e)
        {
            if(rdo_catagory.Checked)
            {
                cmbo_catagory.Enabled = true;
                chk_subCatagory.Enabled = true;
            }
            else
            {
               chk_subCatagory.Enabled = false;
               cmbo_catagory.Enabled = false;
            }
        }

        private void chk_subCatagory_CheckedChanged(object sender, EventArgs e)
        {
            if(chk_subCatagory.Checked)
            {
                cmbo_subCatagory.Enabled = true;
            }
            else
            {
                cmbo_subCatagory.Enabled = false;
            }
        }

        private void chk_brandName_CheckedChanged(object sender, EventArgs e)
        {
            if(chk_brandName.Checked)
            {
                cmbo_brandName.Enabled = true;
            }
            else
            {
                cmbo_brandName.Enabled = false;
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

        private void cmbo_catagory_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cmbo_catagory.SelectedValue != null && cmbo_catagory.SelectedIndex!=-1)
            {
                if(int.TryParse(cmbo_catagory.SelectedValue.ToString(), out int selectedCategoryId))
                {
                    LoadSubCategories(selectedCategoryId);
                }
               
            }
        }

        private void guna2ShadowPanel1_Paint(object sender, PaintEventArgs e)
        {

        }
    }
}
