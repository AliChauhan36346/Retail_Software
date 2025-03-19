using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ALA_Accounting.transaction_classes
{
    

    internal class Connection
    {
        // Connection string for SQL Server database connection
        //retailStoreLocalD
        //private readonly string connectionString = @"Data Source=(Localdb)\local;AttachDbFilename=|DataDirectory|\RetailSystemDB2017.mdf;Integrated Security=True;Connect Timeout=30";

        private readonly string connectionString = (@"Data Source=DESKTOP-STAKJL9;Initial Catalog=RetailStoreDb;Integrated Security=True");

        // SqlConnection object
        public SqlConnection connection;

        // Constructor for connection class
        public Connection()
        {
            connection = new SqlConnection(connectionString);
        }

        public void openConnection()
        {
            try
            {
                if (connection.State != System.Data.ConnectionState.Open)
                {
                    connection.Open();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error opening connection with database " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        public void closeConnection()
        {
            try
            {
                if (connection.State != System.Data.ConnectionState.Closed)
                {
                    connection.Close();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error closing connection with database" + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        public string DatabaseName
        {
            get
            {
                SqlConnectionStringBuilder builder = new SqlConnectionStringBuilder(connectionString);
                return Path.GetFileNameWithoutExtension(builder.AttachDBFilename);
            }
        }

    }
}
