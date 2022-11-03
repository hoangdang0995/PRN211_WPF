using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data.OracleClient;
//using DevExpress.XtraEditors;
using System.Data;

namespace DAO
{
    public class Database
    {
        public static string DataSource;
        public static string UserId;
        public static string PassWord;
        public static string Tendangnhap;
        OracleConnection connection;
        OracleDataAdapter datadapter;
        public bool CheckConnectionDatabase(string datasource, string id, string pass)
        {
            //You need to enter a valid Oracle connection string, below is the format
            //string connectionString = "Data Source=Oanhtran23;User ID=system;Unicode=True;Password=123456";
            string connectionString = "Data Source=" + datasource.Trim() + ";User ID=" + id.Trim() + ";Unicode=True;Password=" + pass.Trim();

            connection = new OracleConnection(connectionString);
            try
            {
                connection.Open();
                return true;
            }
            catch (OracleException ex)
            {
                return false;
            }
        }
        void connect()
        {
            //string connectionString = "Data Source=" + DataSource + ";User ID=" +UserId + ";Unicode=True;Password=" + PassWord;
           // string connectionString = "Data Source=Oanhtran23;User ID=system;Unicode=True;Password=123456";
            string connectionString = "Data Source=xe;User ID=system;Unicode=True;Password=123";
            connection = new OracleConnection(connectionString);
            connection.Open();
        }
        //Join Query Select
        public DataTable Select(string str)
        {
            connect();
            OracleDataAdapter da = new OracleDataAdapter(str,connection);
            DataSet ds = new DataSet();
            da.Fill(ds);
            connection.Close();
            return ds.Tables[0];
        }

        //Join Query Insert/update/delete
        public void Query(string str)
        {
            connect();
            OracleCommand cnn = new OracleCommand(str, connection);
            cnn.ExecuteNonQuery();
            connection.Close();
        }

        //Update
        public void Update(string strQuery, DataTable table)
        {
            connect();
            datadapter = new OracleDataAdapter(strQuery, connection);
            OracleCommandBuilder sqlcb = new OracleCommandBuilder(datadapter);
            datadapter.Update(table);
            connection.Close();
        }

        //// Connect
        //public void Connect()
        //{
        //    //connection.ConnectionString = connectionString;
        //    connection.Open();
        //}

        ////Disconnect
        //public void Disconnect()
        //{
        //    connection.Close();
        //}

        
    }
}
