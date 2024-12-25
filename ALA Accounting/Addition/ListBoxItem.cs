using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ALA_Accounting.Addition
{
    public class ListBoxItem
    {
        public int? FinancialYearID { get; set; } // Nullable for financial year ID
        public string ItemID { get; set; }        // For inventory items
        public string ItemName { get; set; }      // Use ItemName to store YearName

        public override string ToString()
        {
            // Return only the financial year name for financial years
            return ItemName; // This will display only the YearName in the ListBox
        }
    }
}
