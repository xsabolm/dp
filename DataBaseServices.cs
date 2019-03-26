using System;
using System.Collections.Generic;
using System.Data.SqlServerCe;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Data;

namespace connection
{
    public static class DataBaseServices
    {


        private static readonly log4net.ILog log = log4net.LogManager.GetLogger(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType);
        static SqlCeConnection dbConnection;

        static public void openConnection()
        {
            try
            {
                dbConnection = new SqlCeConnection(getConnestionString());
                dbConnection.Open();
                log.Info("Connected to database, databse path: " + getConnestionString());

            }
            catch (Exception e)
            {
                log.Error("Error during connecting to database" + e.ToString());
                MessageBox.Show("Error - during connecting to database");
            }
        }

        static public DataTable getDataFromDatabase(String selectQuerry)
        {
            DataTable table = new DataTable();
            dbConnection = new SqlCeConnection(getConnestionString());
            dbConnection.Open();
            using (SqlCeDataAdapter adapter = new SqlCeDataAdapter(selectQuerry, dbConnection))
            {
                adapter.Fill(table);
            }
            dbConnection.Close();
            return table;
        }

        static void closeConnection()
        {
            dbConnection.Close();
            log.Info("Close connection with database");
        }

        static String getConnestionString()
        {
            return @"Data Source=" + System.Environment.CurrentDirectory + DatabaseUtils.DATABASE_FILENAME + ";Max Database Size=2048";
        }
    }
}
