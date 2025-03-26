using ALA_Accounting.transaction_classes;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.Common;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ALA_Accounting.Addition
{
    public partial class ImportInventoryOpeningBalances : Form
    {
        Connection dbConnection;
        int financialYearId;

        public ImportInventoryOpeningBalances(int financialYearId)
        {
            InitializeComponent();
            dbConnection = new Connection();
            this.financialYearId = financialYearId;
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


        private void ImportInventoryOpeningBalances_Load(object sender, EventArgs e)
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
        ;WITH InventoryBalance AS (
            SELECT 
                it.ItemID,
                SUM(CASE 
                    WHEN it.TransactionType = 'Purchase' THEN it.Quantity 
                    ELSE -it.Quantity 
                END) + COALESCE(iob.Quantity, 0) AS ClosingBalance,
                (SUM(it.Quantity * it.Rate) + COALESCE(iob.Quantity * iob.Rate, 0)) 
                    / NULLIF((SUM(it.Quantity) + COALESCE(iob.Quantity, 0)), 0) AS AverageRate
            FROM InventoryTransaction it
            LEFT JOIN PurchaseInvoice pi ON it.SourceTable = 'PurchaseInvoice' AND it.SourceId = pi.PurchaseInvoiceID
            LEFT JOIN SalesInvoice si ON it.SourceTable = 'SalesInvoice' AND it.SourceId = si.SalesInvoiceID
            LEFT JOIN InventoryOpeningBalance iob ON it.ItemID = iob.ItemID 
                AND iob.FinancialYearID = @PreviousYearID
            WHERE (pi.FinancialYearID = @PreviousYearID OR si.FinancialYearID = @PreviousYearID)
            GROUP BY it.ItemID, iob.Quantity, iob.Rate
        )
        INSERT INTO InventoryOpeningBalance (ItemID, FinancialYearID, Quantity, Unit, Rate, Date)
        SELECT 
            ib.ItemID,
            @CurrentYearID,
            ib.ClosingBalance,
            ii.MeasurementUnit,
            ib.AverageRate,
            GETDATE()
        FROM InventoryBalance ib
        INNER JOIN InventoryItem ii ON ib.ItemID = ii.ItemID
        WHERE ib.ClosingBalance > 0;";

                using (SqlCommand cmd = new SqlCommand(query, dbConnection.connection))
                {
                    cmd.Parameters.AddWithValue("@PreviousYearID", previousYearID);
                    cmd.Parameters.AddWithValue("@CurrentYearID", financialYearId);  // Current year passed from constructor

                    int rowsAffected = cmd.ExecuteNonQuery();
                    if (rowsAffected > 0)
                    {
                        MessageBox.Show($"🎉 {rowsAffected} inventory balances successfully imported! 🎉",
                            "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                    else
                    {
                        MessageBox.Show("No new inventory balances were imported.",
                            "Information", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("⚠️ Error importing inventory balances: " + ex.Message,
                    "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally
            {
                dbConnection.closeConnection();
            }
        }
    }
}
