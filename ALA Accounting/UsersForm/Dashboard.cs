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
        MDIParent1 mDI=new MDIParent1();

        public Dashboard()
        {
            InitializeComponent();
        }

        private void btn_sales_Click(object sender, EventArgs e)
        {
            Sales sales = new Sales();

            sales.MdiParent = this.MdiParent;

            sales.Show();
        }

        private void btn_purchase_Click(object sender, EventArgs e)
        {
            purchase purchase = new purchase();
            purchase.MdiParent= this.MdiParent;
            purchase.Show();
        }

        private void btn_cashPayment_Click(object sender, EventArgs e)
        {
            CashPayment cashPayment = new CashPayment();
            cashPayment.MdiParent = this.MdiParent;
            cashPayment.Show();
        }

        private void btn_bankPayment_Click(object sender, EventArgs e)
        {
            BankPayment bankPayment= new BankPayment();
            bankPayment.MdiParent =(this.MdiParent);
            bankPayment.Show();
        }

        private void cashReceipt_Click(object sender, EventArgs e)
        {
            CashReceipt cashReceipt = new CashReceipt();
            cashReceipt.MdiParent=(this.MdiParent);
            cashReceipt.Show();
        }

        private void btn_bankReceipt_Click(object sender, EventArgs e)
        {
            bankReceipt bankReceipt=new bankReceipt();
            bankReceipt.MdiParent=this.MdiParent;
            bankReceipt.Show();
        }
    }
}
