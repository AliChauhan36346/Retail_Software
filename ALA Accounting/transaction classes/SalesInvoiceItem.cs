using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ALA_Accounting.transaction_classes
{
    internal class SalesInvoiceItem
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

        public SalesInvoiceItem()
        {
            dbConnection = new Connection();
        }

        //public SalesInvoiceItem(SalesInvoiceItem existingItem)
        //{
        //    dbConnection = new Connection();
        //    SalesInvoiceItemID = existingItem.SalesInvoiceItemID;
        //    ItemID = existingItem.ItemID;
        //    ItemDiscription = existingItem.ItemDiscription;
        //    SalesInvoiceID = existingItem.SalesInvoiceID;
        //    Quantity = existingItem.Quantity;
        //    Unit = existingItem.Unit;
        //    Rate = existingItem.Rate;
        //    GrossAmount = existingItem.GrossAmount;
        //    Discount = existingItem.Discount;
        //    NetAmount = existingItem.NetAmount;
        //}
    }
}
