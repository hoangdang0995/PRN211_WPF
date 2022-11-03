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
    /// Interaction logic for pop_HocKy.xaml
    /// </summary>
    public partial class pop_HocKy : Window
    {
        Database da = new Database();
        string type = "";
        string id = "";

        private string New_Id()
        {
            DataTable dt = (new Database()).Select("SELECT MAX(MAHOCKY) FROM HOCKY");
            if (dt.Rows.Count > 0)
            {
                string str = dt.Rows[0][0].ToString();
                str = str.Substring(2);
                return "HK"+ (int.Parse(str) + 1).ToString("0000");
            }
            else
                return "HK0001";
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
            txt_mahocky.Text = New_Id();
            txt_mahocky.IsEnabled = false;
            txt_tenhocky.Text = "";
            txt_mota.Text = "";
            txt_tenhocky.Focus();
        }

        void Init_edit()
        {
            DataTable dt = (new DAO.Database()).Select("select * from HOCKY where MAHOCKY = '" + id + "'");
            if (dt.Rows.Count > 0)
            {
                txt_mahocky.Text = dt.Rows[0]["MAHOCKY"].ToString();
                txt_tenhocky.Text = dt.Rows[0]["TENHOCKY"].ToString();
                txt_mota.Text = dt.Rows[0]["MOTA"].ToString();
            }
            txt_tenhocky.Focus();
        }

        public pop_HocKy()
        {
            InitializeComponent();
            type = "add";
        }

        public pop_HocKy(string id)
        {
            InitializeComponent();
            type = "edit";
            this.id = id;
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
                    da.Query("INSERT INTO HOCKY (MAHOCKY, TENHOCKY, MOTA) VALUES ('" + txt_mahocky.Text + "','" + BUS.Bus.convertitle(txt_tenhocky.Text) + "','" + txt_mota.Text + "')");
                }
                else if (type == "edit")
                {
                    DataTable dt = (new DAO.Database()).Select("select * from HOCKY where MAHOCKY = '" + id + "'");
                    if (dt.Rows.Count > 0)
                    {
                        da.Query("UPDATE HOCKY SET TENHOCKY = '" + BUS.Bus.convertitle(txt_tenhocky.Text) + "',MOTA='" + txt_mota.Text + "' WHERE MAHOCKY = '" + dt.Rows[0]["MAHOCKY"].ToString() + "'");
                    }
                }
                this.DialogResult = true;
                Close();
            }
            catch
            {
                MessageBox.Show("Thông tin nhập chưa chính xác, xin vui lòng kiểm tra lại!\nChú ý: Tên học kỳ không được trùng!");
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
