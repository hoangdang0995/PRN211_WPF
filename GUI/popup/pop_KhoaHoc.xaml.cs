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
    /// Interaction logic for pop_KhoaHoc.xaml
    /// </summary>
    public partial class pop_KhoaHoc : Window
    {
        Database da = new Database();
        string type = "";
        string id = "";

        private string New_Id()
        {
            DataTable dt = (new Database()).Select("SELECT MAX(MAKHOAHOC) FROM KHOAHOC");
            if (dt.Rows.Count > 0)
            {
                string str = dt.Rows[0][0].ToString();
                str = str.Substring(2);
                return "KH" + (int.Parse(str) + 1).ToString("000");
            }
            else
                return "KH001";
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
            txt_makhoahoc.Text = New_Id();
            txt_makhoahoc.IsEnabled = false;
            txt_tenkhoahoc.Text = "";
            txt_nambatdau.Text = "";
            txt_mota.Text = "";
            txt_tenkhoahoc.Focus();
        }

        void Init_edit()
        {
            DataTable dt = (new DAO.Database()).Select("select * from KHOAHOC where MAKHOAHOC = '" + id + "'");
            if (dt.Rows.Count > 0)
            {
                txt_makhoahoc.Text = dt.Rows[0]["MAKHOAHOC"].ToString();
                txt_makhoahoc.IsEnabled = false;
                txt_tenkhoahoc.Text = dt.Rows[0]["TENKHOAHOC"].ToString() ;
                txt_nambatdau.Text = dt.Rows[0]["NAMBATDAU"].ToString();
                txt_mota.Text = dt.Rows[0]["MOTA"].ToString();
            }
            txt_tenkhoahoc.Focus();
        }

        public pop_KhoaHoc()
        {
            InitializeComponent();
            type = "add";
        }

        public pop_KhoaHoc(string id)
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
                    da.Query("INSERT INTO KHOAHOC (MAKHOAHOC,TENKHOAHOC,NAMBATDAU,MOTA) VALUES ('" + txt_makhoahoc.Text + "','" + BUS.Bus.convertitle(txt_tenkhoahoc.Text) + "','" + BUS.Bus.convertitle(txt_nambatdau.Text) + "','" + txt_mota.Text + "')");
                }
                else if (type == "edit")
                {
                    DataTable dt = (new DAO.Database()).Select("select * from KHOAHOC where MAKHOAHOC = '" + id + "'");
                    if (dt.Rows.Count > 0)
                    {
                        da.Query("UPDATE KHOAHOC SET TENKHOAHOC = '" + BUS.Bus.convertitle(txt_tenkhoahoc.Text) + "',NAMBATDAU = '" + BUS.Bus.convertitle(txt_nambatdau.Text) + "',MOTA = '" + txt_mota.Text + "' WHERE MAKHOAHOC = '" + dt.Rows[0]["MAKHOAHOC"].ToString() + "'");
                    }
                }
                this.DialogResult = true;
                Close();
            }
            catch
            {
                MessageBox.Show("Thông tin nhập chưa chính xác, xin vui lòng kiểm tra lại!\nChú ý: Tên khoá học và năm bắt đầu không được trùng!");
            }
        }

        private void cmdExit_Click(object sender, RoutedEventArgs e)
        {
            this.DialogResult = false;
            Close();
        }

        private void txt_nambatdau_TextChanged(object sender, TextChangedEventArgs e)
        {
            double tam;
            if (double.TryParse(txt_nambatdau.Text, out tam))
                txt_nambatdau.Text = txt_nambatdau.Text;
            else
                txt_nambatdau.Text = "";
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
