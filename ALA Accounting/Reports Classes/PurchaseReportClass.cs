using ALA_Accounting.transaction_classes;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ALA_Accounting.Reports_Classes
{
    internal class PurchaseReportClass
    {
        Connection dbConnection;

        public PurchaseReportClass()
        {
            dbConnection = new Connection();
        }


        public DataTable GetPurchaseData(int financialYearID)
        {
            DataTable dtPurchase = new DataTable();

            try
            {
                dbConnection.openConnection();

                string query = $@"SELECT PI.PurchaseInvoiceID, PI.InvoiceDate, PI.AccountID, PI.AccountName, PI.employeeReference,
                                        PI.GrossTotal, PI.AdditionalDiscount, PI.CarriageAndFreight, PI.NetTotal
                                 FROM PurchaseInvoice PI WHERE FinancialYearID = {financialYearID}";

                SqlCommand cmd = new SqlCommand(query, dbConnection.connection);
                SqlDataAdapter adapter = new SqlDataAdapter(cmd);
                adapter.Fill(dtPurchase);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error fetching purchase data: " + ex.Message);
            }
            finally
            {
                dbConnection.closeConnection();
            }

            return dtPurchase;
        }

    }
}
