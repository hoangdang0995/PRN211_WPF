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
    /// Interaction logic for pop_LoaiNguoiDung.xaml
    /// </summary>
    public partial class pop_LoaiNguoiDung : Window
    {
        Database da = new Database();
        string type = "";
        string id = "";

        private string New_Id()
        {
            DataTable dt = (new Database()).Select("SELECT MAX(MALOAI) FROM LOAINGUOIDUNG");
            if (dt.Rows.Count > 0)
            {
                string str = dt.Rows[0][0].ToString();
                str = str.Substring(3);
                return "LND"+ (int.Parse(str) + 1).ToString("000");
            }
            else
                return "LND001";
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
            txt_maloainguoidung.Text = New_Id();
            txt_maloainguoidung.IsEnabled = false;
            txt_tenloainguoidung.Text = "";
        }

        void Init_edit()
        {
            DataTable dt = (new DAO.Database()).Select("select * from LOAINGUOIDUNG where MALOAI = '" + id + "'");
            if (dt.Rows.Count > 0)
            {
                txt_maloainguoidung.Text = dt.Rows[0]["MALOAI"].ToString();
                txt_maloainguoidung.IsEnabled = false;
                txt_tenloainguoidung.Text = dt.Rows[0]["TENLOAIND"].ToString();
            }
        }
        public pop_LoaiNguoiDung()
        {
            InitializeComponent();
            type = "add";
        }

        public pop_LoaiNguoiDung(string id)
        {
            InitializeComponent();
            type = "edit";
            this.id = id;
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            Init();
        }

        private void cmd_DongY_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                if (type == "add")
                {
                    da.Query("INSERT INTO LOAINGUOIDUNG (MALOAI, TENLOAIND) VALUES ('" + txt_maloainguoidung.Text + "','" + BUS.Bus.convertitle(txt_tenloainguoidung.Text) + "')");
                }
                else if (type == "edit")
                {
                    DataTable dt = (new DAO.Database()).Select("select * from LOAINGUOIDUNG where MALOAI = '" + id + "'");
                    if (dt.Rows.Count > 0)
                    {
                        da.Query("UPDATE LOAINGUOIDUNG SET MALOAI = '" + txt_maloainguoidung.Text + "', TENLOAIND = '" + BUS.Bus.convertitle(txt_tenloainguoidung.Text) + "' WHERE MALOAI = '" + dt.Rows[0]["MALOAI"].ToString() + "'");
                    }
                }
                this.DialogResult = true;
                Close();
            }
            catch
            {
                MessageBox.Show("Thông tin nhập chưa chính xác, xin vui lòng kiểm tra lại!\nChú ý: Tên loại người dùng không được trùng!");
            }
        }

        private void cmd_Exit_Click(object sender, RoutedEventArgs e)
        {
            this.DialogResult = false;
            Close();
        }

        private void Window_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.Key == Key.Escape)
                this.Close();
            if (e.Key == Key.Enter)
                cmd_DongY_Click(sender, e);
        }

    }
}
