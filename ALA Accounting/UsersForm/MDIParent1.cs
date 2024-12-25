using ALA_Accounting.Addition;
using ALA_Accounting.Reports;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ALA_Accounting.UsersForm
{
    public partial class MDIParent1 : Form
    {
        private int childFormNumber = 0;

        public int financialYearId {  get; set; }

        

        public MDIParent1()
        {
            InitializeComponent();
        }

        

        private void SaveAsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            SaveFileDialog saveFileDialog = new SaveFileDialog();
            saveFileDialog.InitialDirectory = Environment.GetFolderPath(Environment.SpecialFolder.Personal);
            saveFileDialog.Filter = "Text Files (*.txt)|*.txt|All Files (*.*)|*.*";
            if (saveFileDialog.ShowDialog(this) == DialogResult.OK)
            {
                string FileName = saveFileDialog.FileName;
            }
        }

        
        

        

        

        

        

        private void dashboardToolStripMenuItem_Click(object sender, EventArgs e)
        {

            ShowDashboard();

        }

        private void myCompanyToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        public void ShowDashboard()
        {
            // Create a new instance of the dashboard form
            Dashboard dashboard = new Dashboard(this);

            // Set the MDI parent form
            dashboard.MdiParent = this;

            // Show the dashboard form
            dashboard.Show();

            
        }

        private void MDIParent1_FormClosing(object sender, FormClosingEventArgs e)
        {
            Application.Exit();
        }

        private void addAccountsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            AddAccount addAccount= new AddAccount();
            addAccount.ShowDialog();
        }

        private void addCustomersToolStripMenuItem_Click(object sender, EventArgs e)
        {
            AddCustomers addCustomers= new AddCustomers();
            addCustomers.ShowDialog();
        }

        private void addInventoryToolStripMenuItem_Click(object sender, EventArgs e)
        {
            AddInventory addInventory= new AddInventory();
            addInventory.ShowDialog();
        }

        private void inventoryBrandsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            AddBrands addBrands= new AddBrands();
            addBrands.ShowDialog();
        }

        private void inventoryOpeningBalanceToolStripMenuItem_Click(object sender, EventArgs e)
        {
            InventoryOpeningBalances inventory = new InventoryOpeningBalances(this);

            inventory.MdiParent=this;
            inventory.Show();
        }

        private void financialYearsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FinancialYear financialYear = new FinancialYear();
            financialYear.ShowDialog();
        }

        private void accountsOpeningBalanceToolStripMenuItem_Click(object sender, EventArgs e)
        {
            AccountsOpeningBalances accounts = new AccountsOpeningBalances(this);

            accounts.MdiParent=this;
            accounts.Show();
        }

        private void reportsToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        private void saleReportToolStripMenuItem_Click(object sender, EventArgs e)
        {
            SaleReport saleReport = new SaleReport(this);

            saleReport.MdiParent = this;
            saleReport.Show();
        }
    }
}
