using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ALA_Accounting.transaction_classes
{
    internal class PurchaseInvoiceItems
    {
        Connection dbConnection;

        public int SalesInvoiceItemID { get; set; }
        public string ItemID { get; set; }
        public string ItemDiscription { get; set; }
        public int SalesInvoiceID { get; set; }
        public decimal Quantity { get; set; }
        public string Unit { get; set; }
        public decimal Rate { get; set; }
        public decimal GrossAmount { get; set; }
        public decimal Discount { get; set; }
        public decimal NetAmount { get; set; }

        public PurchaseInvoiceItems()
        {
            dbConnection = new Connection();
        }
    }
}
