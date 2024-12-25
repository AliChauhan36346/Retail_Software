using System;
using System.Collections.Generic;
using System.Data.Common;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ALA_Accounting.transaction_classes
{
    public class InventoryTransaction
    {
        Connection dbConnection;

        public string ItemID {  get; set; }
        public decimal Quantity {  get; set; }
        public string Unit {  get; set; }
        public decimal Rate {  get; set; }
        public DateTime TransactionDate {  get; set; }
        public string partyName {  get; set; }
         



    }
}
