using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data.OracleClient;
//using DevExpress.XtraEditors;
using System.Data;
using System.Data.SqlClient;

namespace DAO
{
	public class Database
	{
		public static string DataSource;
		public static string UserId;
		public static string PassWord;
		public static string Tendangnhap;
		SqlConnection connection;
		SqlDataAdapter datadapter;
		string connectionString = "Server=OS\\SQLEXPRESS;Database=PRN211;Trusted_Connection=Yes;uid=sa;pwd=123;";
		public bool CheckConnectionDatabase(string datasource, string id, string pass)
		{
			//You need to enter a valid Oracle connection string, below is the format
			//string connectionString = "Data Source=Oanhtran23;User ID=system;Unicode=True;Password=123456";
			//connectionString = "Data Source=" + datasource.Trim() + ";User ID=" + id.Trim() + ";Password=" + pass.Trim();
			//connectionString = "Server=OS\\SQLEXPRESS;Database=PRN211;Trusted_Connection=Yes;uid=sa;pwd=123;";

			connection = new SqlConnection(connectionString);
			try
			{
				connection.Open();
				return true;
			}
			catch(OracleException ex)
			{
				return false;
			}
		}
		void connect()
		{
			//string connectionString = "Data Source=" + DataSource + ";User ID=" +UserId + ";Unicode=True;Password=" + PassWord;
			// string connectionString = "Data Source=Oanhtran23;User ID=system;Unicode=True;Password=123456";
			//string connectionString = "Data Source=PRN211;User ID=sa;Unicode=True;Password=qwe";
			if(connection == null)
			{ 
				connection = new SqlConnection(connectionString);
			}
			connection.Open();
		}
		//Join Query Select
		public DataTable Select(string str)
		{
			connect();
			SqlDataAdapter da = new SqlDataAdapter(str, connection);
			DataSet ds = new DataSet();
			da.Fill(ds);
			connection.Close();
			return ds.Tables[0];
		}

		//Join Query Insert/update/delete
		public void Query(string str)
		{
			connect();
			SqlCommand cnn = new SqlCommand(str, connection);
			cnn.ExecuteNonQuery();
			connection.Close();
		}

		//Update
		public void Update(string strQuery, DataTable table)
		{
			connect();
			datadapter = new SqlDataAdapter(strQuery, connection);
			SqlCommandBuilder sqlcb = new SqlCommandBuilder(datadapter);
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
