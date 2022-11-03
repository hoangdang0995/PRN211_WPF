using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;
using System.Data;
using Microsoft.Win32;
using ADOX;
using System.IO;

namespace GUI.popup
{
    /// <summary>
    /// Interaction logic for Import.xaml
    /// </summary>
    public partial class Import : Window
    {
        private int page = 0;
        private string SelectedTable = string.Empty;

        public string tuychinh = "";
        public DataTable datareturn;

        public Import()
        {
            InitializeComponent();
        }

        private void cmdExit_Click(object sender, RoutedEventArgs e)
        {
            this.DialogResult = false;
            Close();
        }

        private void chuyentrang(int pagei)
        {
            Nd1.Visibility = System.Windows.Visibility.Collapsed;
            Nd2.Visibility = System.Windows.Visibility.Collapsed;
            Nd3.Visibility = System.Windows.Visibility.Collapsed;
            cmdfinish.IsEnabled = false;
            cmdleft.IsEnabled = true;
            cmdright.IsEnabled = true;

            txttieude.Text = "";

            if (pagei == 0)
            {
                Nd1.Visibility= System.Windows.Visibility.Visible;
                cmdleft.IsEnabled = false;
                txttieude.Text = "Tùy chỉnh";
            }
            else if (pagei == 1)
            {
                Nd2.Visibility = System.Windows.Visibility.Visible;
                txttieude.Text = "Nhập dữ liệu tập tin";
            }
            else if (pagei == 2)
            {
                Nd3.Visibility = System.Windows.Visibility.Visible;
                txttieude.Text = "Hiệu chỉnh dữ liệu";
                cmdright.IsEnabled = false;
                cmdfinish.IsEnabled = true;
            }
        }

        private void cmdleft_Click(object sender, RoutedEventArgs e)
        {
            chuyentrang(--page);
        }

        private void cmdright_Click(object sender, RoutedEventArgs e)
        {
            if (page == 1)
            {
                if (lstsheet.Items.Count > 0)
                {
                    if (tableName != string.Empty)
                    {
                        SelectedTable = tableName;
                        if ((SelectedTable != string.Empty) && (SelectedTable != null))
                        {
                            DataTable dt = new DataTable();
                            dt = GetDataTableExcel(txtDuongdan.Text, SelectedTable);
                            DataColumn check = new DataColumn();

                            check.ColumnName = "CHECK";
                            check.DataType = typeof(bool);
                            check.DefaultValue = "1";

                            dt.Columns.Add(check);
                            datareturn = new DataTable();
                            datareturn = dt;
                            grdnoidung.Columns.Clear();
                            grdnoidung.ItemsSource = dt;
                        }
                    }
                    else
                    {
                        MessageBox.Show("Chọn trang trong Excel");
                        return;
                    }
                }
                else
                {
                    MessageBox.Show("Chưa chọn đường dẫn");
                    return;
                }
            }

            chuyentrang(++page);
        }

        private void cmdfinish_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                if (chk_boqua.IsChecked == true)
                    tuychinh = "boqua";
                else
                    tuychinh = "capnhat";

                this.DialogResult = true;
                Close();
            }
            catch
            {
                MessageBox.Show("Lấy dữ liệu không thành công !");
            }
        }

        private void cmdchon_Click(object sender, RoutedEventArgs e)
        {
            OpenFileDialog fdlg = new OpenFileDialog();
            fdlg.Title = "Select file";
            //fdlg.InitialDirectory = @"C:\";
            fdlg.FileName = txtDuongdan.Text;
            fdlg.Filter = "Excel Sheet(*.xlsx,*.xls,*.csv)|*.xlsx;*.xls;*.csv|All Files(*.*)|*.*";
            fdlg.FilterIndex = 1;
            fdlg.RestoreDirectory = true;
            if (fdlg.ShowDialog() == true)
            {
                txtDuongdan.Text = fdlg.FileName;
                _Import();
                //Application.DoEvents();
            } 
        }

        private void _Import()
        {
            if (txtDuongdan.Text.Trim() != string.Empty)
            {
                try
                {
                    string[] strTables = GetTableExcel(txtDuongdan.Text);
                    Tables = strTables;
                    loadsheet();
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message.ToString());
                }
            }
        }

        private void loadsheet()
        {
            lstsheet.Items.Clear();
            if (!DataTables)
            {
                if (Tables != null)
                {
                    for (int tables = 0; tables < Tables.Length; tables++)
                    {
                        try
                        {
                            TextBlock txttemp = new TextBlock();
                            //ListViewItem lv = new ListViewItem();
                            if (Tables[tables] != null)
                            {
                                txttemp.Text = Tables[tables].ToString();
                                txttemp.Tag = tables;
                                //lv.Text = Tables[tables].ToString();
                                //lv.Tag = tables;
                                lstsheet.Items.Add(txttemp);
                            }
                        }
                        catch (Exception ex)
                        {
                        }
                    }
                }
            }
            else
            {
                if (dtTable.Rows.Count > 0)
                {
                    for (int tables = 0; tables < dtTable.Rows.Count; tables++)
                    {
                        try
                        {
                           /* ListViewItem lv = new ListViewItem();
                            lv.Text = dtTable.Rows[tables][0].ToString();
                            lv.Tag = dtTable.Rows[tables][0];*/
                            TextBlock txttemp = new TextBlock();
                            txttemp.Text = dtTable.Rows[tables][0].ToString();
                            txttemp.Tag = dtTable.Rows[tables][0];

                            lstsheet.Items.Add(txttemp);
                        }
                        catch (Exception ex)
                        { }
                    }
                }
            }
        }

        public static string[] GetTableExcel(string strFileName)
        {
            string[] strTables = new string[100];
            Catalog oCatlog = new Catalog();
            ADOX.Table oTable = new ADOX.Table();
            ADODB.Connection oConn = new ADODB.Connection();
            //oConn.Open("Provider=Microsoft.Jet.OleDb.4.0; Data Source = " + strFileName + "; Extended Properties = \"Excel 8.0;HDR=Yes;IMEX=1\";", "", "", 0);
            oConn.Open("Provider=Microsoft.ACE.OLEDB.12.0; Data Source = " + strFileName + "; Extended Properties = \"Excel 8.0;HDR=Yes;IMEX=1\";", "", "", 0);

            oCatlog.ActiveConnection = oConn;
            if (oCatlog.Tables.Count > 0)
            {
                int item = 0;
                foreach (ADOX.Table tab in oCatlog.Tables)
                {
                    if (tab.Type == "TABLE")
                    {
                        strTables[item] = tab.Name;
                        item++;
                    }
                }
            }
            return strTables;
        }

        public static DataTable GetDataTableExcel(string strFileName, string Table)
        {
            //System.Data.OleDb.OleDbConnection conn = new System.Data.OleDb.OleDbConnection("Provider=Microsoft.Jet.OleDb.4.0; Data Source = " + strFileName + "; Extended Properties = \"Excel 8.0;HDR=Yes;IMEX=1\";");
            System.Data.OleDb.OleDbConnection conn = new System.Data.OleDb.OleDbConnection("Provider=Microsoft.ACE.OLEDB.12.0; Data Source = " + strFileName + "; Extended Properties = \"Excel 8.0;HDR=Yes;IMEX=1\";");
            conn.Open();
            string strQuery = "SELECT * FROM [" + Table + "]";
            System.Data.OleDb.OleDbDataAdapter adapter = new System.Data.OleDb.OleDbDataAdapter(strQuery, conn);
            System.Data.DataSet ds = new System.Data.DataSet();
            adapter.Fill(ds);
            conn.Close();
            return ds.Tables[0];
        }

        DataTable dtTable = new DataTable();
        string tableName = string.Empty;
        string[] Tables;
        bool DataTables = false;

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            chuyentrang(page);
        }

        private void lstsheet_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            tableName = ((TextBlock)lstsheet.SelectedItem).Text;
        }
    }
}
