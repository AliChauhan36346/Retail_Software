using ALA_Accounting.transaction_classes;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ALA_Accounting.Addition
{
    public partial class ImportOpeningBalances : Form
    {
        Connection dbConnection = new Connection();

        int FinancialYearID;

        public ImportOpeningBalances(int financialYearID)
        {
            InitializeComponent();
            this.FinancialYearID = financialYearID;
        }

        private void LoadFinancialYearsIntoComboBox()
        {
            

            try
            {
                dbConnection.openConnection();

                string query = "SELECT FinancialYearID, YearName FROM FinancialYear ORDER BY StartDate DESC"; // Order by date if needed
                using (SqlCommand command = new SqlCommand(query, dbConnection.connection))
                {
                    using (SqlDataReader reader = command.ExecuteReader())
                    {
                        combo_financialYear.Items.Clear();

                        while (reader.Read())
                        {
                            // Create ListBoxItem for each financial year
                            ListBoxItem item = new ListBoxItem
                            {
                                ItemID = reader.GetInt32(0).ToString(), // FinancialYearID
                                ItemName = reader.GetString(1) // YearName
                            };

                            combo_financialYear.Items.Add(item);
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error loading financial years: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally
            {
                dbConnection.closeConnection();
            }
        }

        private void ImportOpeningBalances_Load(object sender, EventArgs e)
        {
            LoadFinancialYearsIntoComboBox();
        }

        private void btn_import_Click(object sender, EventArgs e)
        {
            if (combo_financialYear.SelectedItem == null)
            {
                MessageBox.Show("Please select a financial year to import from.", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            ListBoxItem selectedYear = (ListBoxItem)combo_financialYear.SelectedItem;
            int previousYearID = int.Parse(selectedYear.ItemID);

            try
            {
                dbConnection.openConnection();

                string query = @"
        ;WITH AccountBalance AS (
            SELECT 
                t.AccountID,
                SUM(CASE WHEN t.TransactionType = 'Debit' THEN t.Amount ELSE 0 END) 
                    + COALESCE(MAX(ob.Debit), 0) AS TotalDebit,
                SUM(CASE WHEN t.TransactionType = 'Credit' THEN t.Amount ELSE 0 END) 
                    + COALESCE(MAX(ob.Credit), 0) AS TotalCredit
            FROM Transactions t
            LEFT JOIN AccountsOpeningBalance ob ON t.AccountID = ob.AccountId 
                AND ob.financialYearID = @PreviousYearID
            WHERE t.FinancialYearID = @PreviousYearID
            GROUP BY t.AccountID
        )
        INSERT INTO AccountsOpeningBalance (AccountId, AccountName, Debit, Credit, financialYearID)
        SELECT 
            a.AccountID, 
            a.AccountName, 
            CASE WHEN (ab.TotalDebit - ab.TotalCredit) >= 0 THEN (ab.TotalDebit - ab.TotalCredit) ELSE 0 END AS Debit,
            CASE WHEN (ab.TotalCredit - ab.TotalDebit) > 0 THEN (ab.TotalCredit - ab.TotalDebit) ELSE 0 END AS Credit,
            @CurrentYearID
        FROM Accounts a
        INNER JOIN AccountBalance ab ON a.AccountID = ab.AccountID;
        ";

                using (SqlCommand cmd = new SqlCommand(query, dbConnection.connection))
                {
                    cmd.Parameters.AddWithValue("@PreviousYearID", previousYearID);
                    cmd.Parameters.AddWithValue("@CurrentYearID", FinancialYearID);  // Current year passed from constructor

                    int rowsAffected = cmd.ExecuteNonQuery();
                    if (rowsAffected > 0)
                    {
                        MessageBox.Show($"🎉 {rowsAffected} اکاؤنٹ بیلنس کامیابی سے امپورٹ ہو گیا ہے! 🎉",
                            "کامیابی", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                    else
                    {
                        MessageBox.Show("کوئی نیا اکاؤنٹ بیلنس امپورٹ نہیں ہوا۔",
                            "معلومات", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("⚠️ اکاؤنٹ بیلنس امپورٹ کرنے میں خرابی: " + ex.Message,
                    "خرابی", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally
            {
                dbConnection.closeConnection();
            }
        }


    }
}
