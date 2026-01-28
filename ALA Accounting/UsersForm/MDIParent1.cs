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

        private int financialYearId {  get; set; }

        // for storing instance
        private static MDIParent1 instance;


        

        private MDIParent1(int financialYearId)
        {
            this.financialYearId = financialYearId;
            InitializeComponent();
        }

        public static MDIParent1 GetInstance(int financialYearId)
        {
            if (instance == null)
            {
                instance=new MDIParent1(financialYearId);
            }
            return instance;
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
            Dashboard dashboard = new Dashboard(financialYearId);

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
            InventoryOpeningBalances inventory = new InventoryOpeningBalances(financialYearId);

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
            AccountsOpeningBalances accounts = new AccountsOpeningBalances(financialYearId);

            accounts.MdiParent=this;
            accounts.Show();
        }

        private void reportsToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        private void saleReportToolStripMenuItem_Click(object sender, EventArgs e)
        {
            // Check if the form is already open
            foreach (Form openForm in this.MdiChildren)
            {
                if (openForm is saleSummaryReportForm)
                {
                    // Restore if minimized
                    if (openForm.WindowState == FormWindowState.Minimized)
                    {
                        openForm.WindowState = FormWindowState.Normal;
                    }

                    // Bring to front
                    openForm.BringToFront();
                    return; // Exit, no need to create a new instance
                }
            }

            // If form is not open, create a new instance
            saleSummaryReportForm saleSummaryReportForm = new saleSummaryReportForm(financialYearId);
            saleSummaryReportForm.MdiParent = this;
            saleSummaryReportForm.Show();
        }


        private void purchaseSummaryToolStripMenuItem_Click(object sender, EventArgs e)
        {
            // Check if the form is already open
            foreach (Form openForm in this.MdiChildren)
            {
                if (openForm is PurchaseSummaryReport)
                {
                    // Restore if minimized
                    if (openForm.WindowState == FormWindowState.Minimized)
                    {
                        openForm.WindowState = FormWindowState.Normal;
                    }

                    // Bring to front
                    openForm.BringToFront();
                    return; // Exit, no need to create a new instance
                }
            }

            // If form is not open, create a new instance
            PurchaseSummaryReport purchaseSummaryReport = new PurchaseSummaryReport(financialYearId);
            purchaseSummaryReport.MdiParent = this;
            purchaseSummaryReport.Show();
        }


        private void purchaseReportToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        private void itemWiseProfitLossToolStripMenuItem_Click(object sender, EventArgs e)
        {
            // Check if the form is already open
            foreach (Form openForm in this.MdiChildren)
            {
                if (openForm is ItemWiseProfitLossForm)
                {
                    // Restore if minimized
                    if (openForm.WindowState == FormWindowState.Minimized)
                    {
                        openForm.WindowState = FormWindowState.Normal;
                    }

                    // Bring to front
                    openForm.BringToFront();
                    return; // Exit, no need to create a new instance
                }
            }

            // If form is not open, create a new instance
            ItemWiseProfitLossForm itemWiseProfitLossForm = new ItemWiseProfitLossForm(financialYearId);
            itemWiseProfitLossForm.MdiParent = this;
            itemWiseProfitLossForm.Show();
        }

        private void balanceSheetToolStripMenuItem_Click(object sender, EventArgs e)
        {
            // Check if the form is already open
            foreach (Form openForm in this.MdiChildren)
            {
                if (openForm is BalanceSheet)
                {
                    // Restore if minimized
                    if (openForm.WindowState == FormWindowState.Minimized)
                    {
                        openForm.WindowState = FormWindowState.Normal;
                    }

                    // Bring to front
                    openForm.BringToFront();
                    return; // Exit, no need to create a new instance
                }
            }

            // If form is not open, create a new instance
            BalanceSheet balanceSheet = new BalanceSheet(financialYearId);
            balanceSheet.MdiParent = this;
            balanceSheet.Show();
        }

        private void inventoryBalanceToolStripMenuItem_Click(object sender, EventArgs e)
        {
            // Check if the form is already open
            foreach (Form openForm in this.MdiChildren)
            {
                if (openForm is InventoryBalanceForm)
                {
                    // Restore if minimized
                    if (openForm.WindowState == FormWindowState.Minimized)
                    {
                        openForm.WindowState = FormWindowState.Normal;
                    }

                    // Bring to front
                    openForm.BringToFront();
                    return;
                }
            }

            // If form is not open, create a new instance
            InventoryBalanceForm inventoryBalanceForm = new InventoryBalanceForm(financialYearId);
            inventoryBalanceForm.MdiParent = this;
            inventoryBalanceForm.Show();
        }

        private void vendorBalanceToolStripMenuItem_Click(object sender, EventArgs e)
        {
            // Check if the form is already open
            foreach (Form openForm in this.MdiChildren)
            {
                if (openForm is VendorBalanceForm)
                {
                    // Restore if minimized
                    if (openForm.WindowState == FormWindowState.Minimized)
                    {
                        openForm.WindowState = FormWindowState.Normal;
                    }

                    // Bring to front
                    openForm.BringToFront();
                    return;
                }
            }

            // If form is not open, create a new instance
            VendorBalanceForm vendorBalanceForm = new VendorBalanceForm(financialYearId);
            vendorBalanceForm.MdiParent = this;
            vendorBalanceForm.Show();
        }

        private void MDIParent1_Load(object sender, EventArgs e)
        {
            toolStripStatusLabel.Text = "A Retail Accounting Software Developed by Ali Abbas. Contact us at alichauhan36346@gmail.com";
        }

        private void toolStripStatusLabel_Click(object sender, EventArgs e)
        {

        }
    }
}
