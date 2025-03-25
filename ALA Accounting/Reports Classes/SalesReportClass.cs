using ALA_Accounting.transaction_classes;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ALA_Accounting.Addition;
using System.Windows.Forms;

namespace ALA_Accounting.Reports_Classes
{
    internal class SalesReportClass
    {
        Connection dbConnection;

        public SalesReportClass()
        {
            dbConnection = new Connection();
        }

        // use dbConnection.connection to access the database

        public List<KeyValuePair<int, string>> LoadSubAccountIdsAndNamesByMainAccountId(string mainAccountId)
        {
            List<KeyValuePair<int, string>> subAccounts = new List<KeyValuePair<int, string>>();

            try
            {
                dbConnection.openConnection();

                string query = "SELECT SubAccountTypeID, SubAccountTypeName FROM SubAccounts WHERE MainAccountID = @MainAccountID";

                using (SqlCommand command = new SqlCommand(query, dbConnection.connection))
                {
                    command.Parameters.AddWithValue("@MainAccountID", mainAccountId);

                    using (SqlDataReader reader = command.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            int subAccountId = Convert.ToInt32(reader["SubAccountTypeID"]);
                            string subAccountName = reader["SubAccountTypeName"].ToString();
                            subAccounts.Add(new KeyValuePair<int, string>(subAccountId, subAccountName));
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("ذیلی اکاؤنٹس لوڈ کرتے ہوئے خرابی ہوگئی: " + ex.Message);
            }
            finally
            {
                dbConnection.closeConnection();
            }

            return subAccounts;
        }



        public DataTable GetSalesData(int financialYearId)
        {
            DataTable dtSales = new DataTable();

            try
            {
                dbConnection.openConnection();

                string query = $@"SELECT SI.SalesInvoiceID, SI.InvoiceDate, SI.AccountID, SI.AccountName, SI.employeeReference,
                                        SI.GrossTotal, SI.AdditionalDiscount, SI.CarriageAndFreight, SI.NetTotal
                                 FROM SalesInvoice SI WHERE financialYearID = {financialYearId}";

                SqlCommand cmd = new SqlCommand(query, dbConnection.connection);

                SqlDataAdapter adapter = new SqlDataAdapter(cmd);

                adapter.Fill(dtSales);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            finally
            {
                dbConnection.closeConnection();
            }

            return dtSales;
        }

            public List<int> GetAccountIdsBySubAccountId(int subAccountId)
            {
                List<int> accountIds = new List<int>();

                try
                {
                    dbConnection.openConnection();

                    string query = "SELECT AccountID FROM Accounts WHERE SubAccountTypeID = @SubAccountID";

                    using (SqlCommand command = new SqlCommand(query, dbConnection.connection))
                    {
                        command.Parameters.AddWithValue("@SubAccountID", subAccountId);

                        using (SqlDataReader reader = command.ExecuteReader())
                        {
                            while (reader.Read())
                            {
                                accountIds.Add(Convert.ToInt32(reader["AccountID"]));
                            }
                        }
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error loading Account IDs: " + ex.Message);
                }
                finally
                {
                    dbConnection.closeConnection();
                }

                return accountIds;
            }

    }
}
