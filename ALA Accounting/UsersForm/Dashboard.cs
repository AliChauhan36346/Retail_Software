﻿using ALA_Accounting.Addition;
using ALA_Accounting.Reports;
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
        //private MDIParent1 dIParent1=MDIParent1.GetInstance();
        public int financialYearId;

        DashboardClass dashboardClass = new DashboardClass();

        public Dashboard(int financialYearId)
        {
            InitializeComponent();
            this.financialYearId = financialYearId;
        }

        private void btn_sales_Click(object sender, EventArgs e)
        {
            Sales sales = new Sales(financialYearId);

            sales.MdiParent = this.MdiParent;

            sales.Show();


        }

        private void btn_purchase_Click(object sender, EventArgs e)
        {
            purchase purchase = new purchase(financialYearId);
            purchase.MdiParent = this.MdiParent;
            purchase.Show();
        }

        private void btn_cashPayment_Click(object sender, EventArgs e)
        {
            CashPayment cashPayment = new CashPayment(financialYearId);
            cashPayment.MdiParent = this.MdiParent;
            cashPayment.Show();
        }

        private void btn_bankPayment_Click(object sender, EventArgs e)
        {
            BankPayment bankPayment = new BankPayment(financialYearId);
            bankPayment.MdiParent = this.MdiParent;
            bankPayment.Show();
        }

        private void cashReceipt_Click(object sender, EventArgs e)
        {
            CashReceipt cashReceipt = new CashReceipt(financialYearId);
            cashReceipt.MdiParent = this.MdiParent;
            cashReceipt.Show();
        }

        private void btn_bankReceipt_Click(object sender, EventArgs e)
        {
            bankReceipt bankReceipt = new bankReceipt();
            bankReceipt.MdiParent = this.MdiParent;
            bankReceipt.Show();
        }

        private void Dashboard_Load(object sender, EventArgs e)
        {
            dtm_startDate.Value = dtm_endDate.Value = DateTime.Now;
        }

        private void guna2Button4_Click(object sender, EventArgs e)
        {
            AccountsLegerForm accountsLegerForm = new AccountsLegerForm(financialYearId);
            accountsLegerForm.MdiParent = (this.MdiParent);
            accountsLegerForm.Show();
        }

        private void btn_inventoryLeger_Click(object sender, EventArgs e)
        {
            InventoryLegerForm inventoryLegerForm = new InventoryLegerForm(financialYearId);
            inventoryLegerForm.MdiParent = this.MdiParent;
            inventoryLegerForm.Show();
        }

        private void Dashboard_Activated(object sender, EventArgs e)
        {
            DateTime startDate = dtm_startDate.Value;
            DateTime endDate = dtm_endDate.Value;
            int financialYearID = Convert.ToInt32(financialYearId);

            var (totalSales, salesChange) = dashboardClass.GetTotalSales(startDate, endDate, financialYearID);
            lbl_sales.Text = $"{totalSales:C0}";
            lbl_salesPercent.Text = $"({salesChange:+0.##;-0.##;0}%)";

            var (totalPurchases, purchasesChange) = dashboardClass.GetTotalPurchases(startDate, endDate, financialYearID);
            lbl_purchase.Text = $"{totalPurchases:C0}";
            lbl_purchasePercent.Text = $"({purchasesChange:+0.##;-0.##;0}%)";

            var (totalPayments, paymentsChange) = dashboardClass.GetTotalPayments(startDate, endDate, financialYearID);
            lbl_payment.Text = $"{totalPayments:C0}";
            lbl_paymentPercent.Text = $"({paymentsChange:+0.##;-0.##;0}%)";

            var (totalReceipts, receiptsChange) = dashboardClass.GetTotalReceipts(startDate, endDate, financialYearID);
            lbl_receipt.Text = $"{totalReceipts:C0}";
            lbl_receiptPercent.Text = $"({receiptsChange:+0.##;-0.##;0}%)";

        }

        private void label15_Click(object sender, EventArgs e)
        {

        }

        private void dtm_startDate_ValueChanged(object sender, EventArgs e)
        {
            Dashboard_Activated(sender, e);
        }

        private void dtm_endDate_ValueChanged(object sender, EventArgs e)
        {
            Dashboard_Activated(sender, e);
        }
    }
}


