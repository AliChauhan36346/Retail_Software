using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ALA_Accounting.Addition
{
    public class ListBoxItem
    {
        public string ItemID { get; set; }
        public string ItemName { get; set; }

        public override string ToString()
        {
            return ItemName; // This will be displayed in the ListBox

        }
    }
}
