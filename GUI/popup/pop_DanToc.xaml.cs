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
using DAO;
namespace GUI.popup
{
    /// <summary>
    /// Interaction logic for pop_DanhToc.xaml
    /// </summary>
    public partial class pop_DanhToc : Window
    {
        Database da = new Database();
        string type = "";
        string id = "";

        private string New_Id()
        {
            DataTable dt = (new Database()).Select("SELECT MAX(MADANTOC) FROM DANTOC");
            if (dt.Rows.Count > 0)
            {
                string str = dt.Rows[0][0].ToString();
                str = str.Substring(2);
                return "DT"+ (int.Parse(str) + 1).ToString("0000");
            }
            else
                return "DT0001";
        }

        public pop_DanhToc()
        {
            InitializeComponent();
            type = "add";
        }

        public pop_DanhToc(string id)
        {
            InitializeComponent();
            type = "edit";
            this.id = id;
        }

        void Init()
        {
            if (type == "add")
                Init_add();
            else if (type == "edit")
                Init_edit();                   
        }

        void Init_add()
        {
            txt_madantoc.Text = New_Id();
            txt_madantoc.IsEnabled = false;
            txt_tendantoc.Text = "";
        }

        void Init_edit()
        {
            DataTable dt = (new DAO.Database()).Select("select * from DANTOC where MADANTOC = '" + id + "'");
            if (dt.Rows.Count > 0)
            {
                txt_madantoc.Text = dt.Rows[0]["MADANTOC"].ToString();
                txt_madantoc.IsEnabled = false;
                txt_tendantoc.Text = dt.Rows[0]["TENDANTOC"].ToString();
            }
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            Init();
        }

        private void cmdDongY_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                if (type == "add")
                {
                    da.Query("INSERT INTO DANTOC (MADANTOC, TENDANTOC) VALUES ('" + txt_madantoc.Text + "','" + BUS.Bus.convertitle(txt_tendantoc.Text) + "')");
                }
                else if (type == "edit")
                {
                    DataTable dt = (new DAO.Database()).Select("select * from DANTOC where MADANTOC = '" + id + "'");
                    if (dt.Rows.Count > 0)
                    {
                        da.Query("UPDATE DANTOC SET MADANTOC = '" + txt_madantoc.Text + "', TENDANTOC = '" + BUS.Bus.convertitle(txt_tendantoc.Text) + "' WHERE MADANTOC = '" + dt.Rows[0]["MADANTOC"].ToString() + "'");
                    }
                }
                this.DialogResult = true;
                Close();
            }
            catch
            {
                MessageBox.Show("Thông tin nhập chưa chính xác, xin vui lòng kiểm tra lại!");
            }
        }

        private void cmdExit_Click(object sender, RoutedEventArgs e)
        {
            this.DialogResult = false;
            Close();
        }

        private void Window_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.Key == Key.Escape)
                this.Close();
            if (e.Key == Key.Enter)
                cmdDongY_Click(sender, e);
        }
    }
}
