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
    /// Interaction logic for pop_NguoiDung.xaml
    /// </summary>
    public partial class pop_NguoiDung : Window
    {
        Database da = new Database();
        string type = "";
        string id = "";

        public pop_NguoiDung()
        {
            InitializeComponent();
            type = "add";
        }

        public pop_NguoiDung(string id)
        {
            InitializeComponent();
            type = "edit";
            this.id = id; 
        }

        void Init()
        {
            LoadNguoiDung();
            if (type == "add")
                Init_add();
            else if (type == "edit")
                Init_edit();
        }
        void LoadNguoiDung()
        {
            DataTable dt = (new DAO.Database()).Select("SELECT MALOAI, TENLOAIND FROM LOAINGUOIDUNG");
            for (int i = 0; i < dt.Rows.Count; i++)
            {
                TextBlock _txttemp = new TextBlock();
                _txttemp.Tag = dt.Rows[i]["MaLOAI"].ToString();
                _txttemp.Text = dt.Rows[i]["TENLOAIND"].ToString();
                cbx_maloainguoidung.Items.Add(_txttemp);
            }
            if (dt.Rows.Count != 0)
                cbx_maloainguoidung.SelectedIndex = 0;
        }

        void Init_add()
        {
            txt_tendangnhap.Text = "";
            pwd_matkhau.Password = "";
            txt_tennguoidung.Text = "";
            txt_tendangnhap.Focus();
        }

        void Init_edit()
        {
            DataTable dt = (new DAO.Database()).Select("SELECT TENDANGNHAP,MATKHAU,NGUOIDUNG.MALOAI,TENNGUOIDUNG, TENLOAIND FROM NGUOIDUNG,LOAINGUOIDUNG WHERE NGUOIDUNG.MALOAI=LOAINGUOIDUNG.MALOAI AND TENDANGNHAP='"+id+"'");
            if (dt.Rows.Count > 0)
            {
                txt_tendangnhap.Text = dt.Rows[0]["TENDANGNHAP"].ToString();
                txt_tendangnhap.IsEnabled = false;
                pwd_matkhau.Password = dt.Rows[0]["MATKHAU"].ToString();

                for (int i = 0; i < cbx_maloainguoidung.Items.Count; i++)
                {
                    TextBlock _txttemp = (TextBlock)cbx_maloainguoidung.Items[i];
                    if(_txttemp.Tag.ToString()==dt.Rows[0]["MALOAI"].ToString())
                    {
                        cbx_maloainguoidung.SelectedIndex=i;
                        break;
                    }
                }

                txt_tennguoidung.Text = dt.Rows[0]["TENNGUOIDUNG"].ToString();
            }
            txt_tendangnhap.Focus();
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            Init();
        }

        private void cmdDongY_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                string _idmaloaind = ((TextBlock)cbx_maloainguoidung.SelectedItem).Tag.ToString();
                if (type == "add")
                {
                    da.Query("INSERT INTO NGUOIDUNG VALUES('" + _idmaloaind.ToString() + "','" + txt_tennguoidung.Text + "','" + BUS.Bus.convertitle(txt_tendangnhap.Text) + "','" + pwd_matkhau.Password.ToString() + "')");
                }
                else if (type == "edit")
                {
                    da.Query("UPDATE NGUOIDUNG SET MATKHAU = '" + pwd_matkhau.Password.ToString() + "',MALOAI='" + _idmaloaind.ToString() + "',TENNGUOIDUNG='" + BUS.Bus.convertitle(txt_tennguoidung.Text) + "' WHERE TENDANGNHAP = '" + txt_tendangnhap.Text + "'");
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
