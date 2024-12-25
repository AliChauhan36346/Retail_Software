using ALA_Accounting.Addition;
using ALA_Accounting.TransactionForms;
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
    public partial class Dashboard : Form
    {
        private MDIParent1 dIParent1;

        public Dashboard(MDIParent1 parent)
        {
            InitializeComponent();

            this.dIParent1 = parent;
        }

        private void btn_sales_Click(object sender, EventArgs e)
        {
            Sales sales = new Sales(this.dIParent1);

            sales.MdiParent = this.MdiParent;

            sales.Show();

            
        }

        private void btn_purchase_Click(object sender, EventArgs e)
        {
            purchase purchase = new purchase(this.dIParent1);
            purchase.MdiParent= this.MdiParent;
            purchase.Show();
        }

        private void btn_cashPayment_Click(object sender, EventArgs e)
        {
            CashPayment cashPayment = new CashPayment(this.dIParent1);
            cashPayment.MdiParent = this.MdiParent;
            cashPayment.Show();
        }

        private void btn_bankPayment_Click(object sender, EventArgs e)
        {
            BankPayment bankPayment= new BankPayment(this.dIParent1);
            bankPayment.MdiParent = this.MdiParent;
            bankPayment.Show();
        }

        private void cashReceipt_Click(object sender, EventArgs e)
        {
            CashReceipt cashReceipt = new CashReceipt(this.dIParent1);
            cashReceipt.MdiParent = this.MdiParent;
            cashReceipt.Show();
        }

        private void btn_bankReceipt_Click(object sender, EventArgs e)
        {
            bankReceipt bankReceipt=new bankReceipt(this.dIParent1);
            bankReceipt.MdiParent=this.MdiParent;
            bankReceipt.Show();
        }

        private void Dashboard_Load(object sender, EventArgs e)
        {
            //
        }
    }
}
