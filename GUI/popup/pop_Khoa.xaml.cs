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
    /// Interaction logic for pop_Khoa.xaml
    /// </summary>
    public partial class pop_Khoa : Window
    {
        Database da = new Database();
        string type = "";
        string id = "";

        private string New_Id()
        {
            DataTable dt = (new Database()).Select("SELECT MAX(MAKHOA) FROM KHOA");
            if (dt.Rows.Count > 0)
            {
                string str = dt.Rows[0][0].ToString();
                str = str.Substring(1);
                return "K" + (int.Parse(str) + 1).ToString("0000");
            }
            else
                return "K0001";
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
            txt_makhoa.Text = New_Id();
            txt_makhoa.IsEnabled = false;
            txt_tenkhoa.Text = "";
            txt_sodienthoai.Text = "";
            txt_email.Text = "";
            txt_tenkhoa.Focus();
        }

        void Init_edit()
        {
            DataTable dt = (new DAO.Database()).Select("select * from KHOA where MAKHOA = '" + id + "'");
            if (dt.Rows.Count > 0)
            {
                txt_makhoa.Text = dt.Rows[0]["MAKHOA"].ToString();
                txt_makhoa.IsEnabled = false;
                txt_tenkhoa.Text = dt.Rows[0]["TENKHOA"].ToString();
                txt_sodienthoai.Text = dt.Rows[0]["SODIENTHOAI"].ToString();
                txt_email.Text = dt.Rows[0]["EMAIL"].ToString();
            }
            txt_tenkhoa.Focus();
        }

        public pop_Khoa()
        {
            InitializeComponent();
            type = "add";
        }

        public pop_Khoa(string id)
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
                    da.Query("INSERT INTO KHOA (MAKHOA,TENKHOA,SODIENTHOAI,EMAIL) VALUES ('" + txt_makhoa.Text + "','" + BUS.Bus.convertitle(txt_tenkhoa.Text) + "','" + txt_sodienthoai.Text + "','" + BUS.Bus.convertitle(txt_email.Text) + "')");
                }
                else if (type == "edit")
                {
                    DataTable dt = (new DAO.Database()).Select("select * from KHOA where MAKHOA = '" + id + "'");
                    if (dt.Rows.Count > 0)
                    {
                        da.Query("UPDATE KHOA SET TENKHOA = '" + BUS.Bus.convertitle(txt_tenkhoa.Text) + "', EMAIL = '" + BUS.Bus.convertitle(txt_email.Text) + "', SODIENTHOAI = '" + txt_sodienthoai.Text + "' WHERE MAKHOA = '" + dt.Rows[0]["MAKHOA"].ToString() + "'");
                    }
                }
                this.DialogResult = true;
                Close();
            }
            catch
            {
                MessageBox.Show("Thông tin nhập chưa chính xác, xin vui lòng kiểm tra lại!\nChú ý: Tên khoa và e-mail không được trùng!");
            }
        }

        private void cmdExit_Click(object sender, RoutedEventArgs e)
        {
            this.DialogResult = false;
            Close();
        }

        private void txt_sodienthoai_TextChanged(object sender, TextChangedEventArgs e)
        {
            double tam;
            if (double.TryParse(txt_sodienthoai.Text, out tam))
                txt_sodienthoai.Text = txt_sodienthoai.Text;
            else
                txt_sodienthoai.Text = "";
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
