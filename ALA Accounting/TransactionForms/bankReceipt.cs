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

namespace ALA_Accounting.TransactionForms
{
    public partial class bankReceipt : Form
    {
        MDIParent1 dIParent1;

        public bankReceipt(MDIParent1 mDI)
        {
            InitializeComponent();

            this.dIParent1 = mDI;
        }

        private void bankReceipt_Load(object sender, EventArgs e)
        {

        }
    }
}
