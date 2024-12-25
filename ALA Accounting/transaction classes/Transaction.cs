using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ALA_Accounting.transaction_classes
{
    public class Transaction
    {
        public int AccountID { get; set; }
        public DateTime TransactionDate { get; set; }
        public string TransactionType { get; set; }
        public decimal Amount { get; set; }
        public string Description { get; set; }
        public int FinancialYearID { get; set; }
        public bool IsCancelled { get; set; }

    }
}
