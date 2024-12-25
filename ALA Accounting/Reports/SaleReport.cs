using ALA_Accounting.UsersForm;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ALA_Accounting.Reports
{
    public partial class SaleReport : Form
    {
        MDIParent1 parent1;
        public SaleReport(MDIParent1 mDI)
        {
            InitializeComponent();

            this.parent1 = mDI;
        }

        private void SaleReport_Load(object sender, EventArgs e)
        {

        }
    }
}
