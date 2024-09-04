using ALA_Accounting.Addition;
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

        

        public MDIParent1()
        {
            InitializeComponent();
        }

        private void ShowNewForm(object sender, EventArgs e)
        {
            Form childForm = new Form();
            childForm.MdiParent = this;
            childForm.Text = "Window " + childFormNumber++;
            childForm.Show();
        }

        private void OpenFile(object sender, EventArgs e)
        {
            OpenFileDialog openFileDialog = new OpenFileDialog();
            openFileDialog.InitialDirectory = Environment.GetFolderPath(Environment.SpecialFolder.Personal);
            openFileDialog.Filter = "Text Files (*.txt)|*.txt|All Files (*.*)|*.*";
            if (openFileDialog.ShowDialog(this) == DialogResult.OK)
            {
                string FileName = openFileDialog.FileName;
            }
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
            Dashboard dashboard = new Dashboard();

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
    }
}
