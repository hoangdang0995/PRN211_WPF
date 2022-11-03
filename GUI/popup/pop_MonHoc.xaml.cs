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
    /// Interaction logic for pop_MonHoc.xaml
    /// </summary>
    public partial class pop_MonHoc : Window
    {
        Database da = new Database();
        string type = "";
        string id = "";

        private string New_Id()
        {
            DataTable dt = (new Database()).Select("SELECT MAX(MAMONHOC) FROM MONHOC");
            if (dt.Rows.Count > 0)
            {
                string str = dt.Rows[0][0].ToString();
                str = str.Substring(2);
                return "MH" + (int.Parse(str) + 1).ToString("000");
            }
            else
                return "MH001";
        }

        void LoadChuyenNganh()
        {
            DataTable dt = (new DAO.Database()).Select("SELECT MACHUYENNGANH, TENCHUYENNGANH FROM CHUYENNGANH");
            for (int i = 0; i < dt.Rows.Count; i++)
            {
                TextBlock _txttemp = new TextBlock();
                _txttemp.Tag = dt.Rows[i]["MACHUYENNGANH"].ToString();
                _txttemp.Text = dt.Rows[i]["TENCHUYENNGANH"].ToString();
                cbx_machuyennganh.Items.Add(_txttemp);
            }
            if (dt.Rows.Count != 0)
                cbx_machuyennganh.SelectedIndex = 0;
        }

        void Init_add()
        {
            txt_mamonhoc.Text = New_Id();
            txt_mamonhoc.IsEnabled = false;
            txt_tenmonhoc.Text = "";
            txt_sotinchi.Text = "";
            txt_mota.Text = "";
            txt_tenmonhoc.Focus();
        }

        void Init_edit()
        {
            DataTable dt = (new DAO.Database()).Select("SELECT MAMONHOC,TENMONHOC,MONHOC.MACHUYENNGANH,MONHOC.MOTA,SOTINCHI,TENCHUYENNGANH FROM MONHOC,CHUYENNGANH WHERE MONHOC.MACHUYENNGANH=CHUYENNGANH.MACHUYENNGANH AND MAMONHOC= '" + id + "'");
            if (dt.Rows.Count > 0)
            {
                txt_mamonhoc.Text = dt.Rows[0]["MAMONHOC"].ToString();
                txt_mamonhoc.IsEnabled = false;
                txt_tenmonhoc.Text = dt.Rows[0]["TENMONHOC"].ToString();
                for (int i = 0; i < cbx_machuyennganh.Items.Count; i++)
                {
                    TextBlock _txttemp = (TextBlock)cbx_machuyennganh.Items[i];
                    if (_txttemp.Tag.ToString() == dt.Rows[0]["MACHUYENNGANH"].ToString())
                    {
                        cbx_machuyennganh.SelectedIndex = i;
                        break;
                    }
                }
                txt_sotinchi.Text = dt.Rows[0]["SOTINCHI"].ToString();
                txt_mota.Text = dt.Rows[0]["MOTA"].ToString();
            }
            txt_tenmonhoc.Focus();
        }

        void Init()
        {
            LoadChuyenNganh();
            if (type == "add")
                Init_add();
            else if (type == "edit")
                Init_edit();
        }

        public pop_MonHoc()
        {
            InitializeComponent();
            type = "add";
        }

        public pop_MonHoc(string id)
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
                string _idChuyenNganh= ((TextBlock)cbx_machuyennganh.SelectedItem).Tag.ToString();
                if (type == "add")
                {
                    string sql = "INSERT INTO MONHOC (MAMONHOC,TENMONHOC,MACHUYENNGANH,SOTINCHI,MOTA) VALUES ('" + txt_mamonhoc.Text + "','" + BUS.Bus.convertitle(txt_tenmonhoc.Text) + "','" + _idChuyenNganh.ToString() + "','" + txt_sotinchi.Text + "','" + txt_mota.Text + "')";
                    da.Query(sql);
                }
                else if (type == "edit")
                {
                    DataTable dt = (new DAO.Database()).Select("select * from MONHOC where MAMONHOC = '" + id + "'");
                    if (dt.Rows.Count > 0)
                    {
                        string sql = "UPDATE MONHOC SET TENMONHOC = '" + BUS.Bus.convertitle(txt_tenmonhoc.Text) + "', MOTA = '" + txt_mota.Text + "', MACHUYENNGANH = '" + _idChuyenNganh.ToString() + "', SOTINCHI = '" + txt_sotinchi.Text + "' WHERE MAMONHOC = '" + dt.Rows[0]["MAMONHOC"].ToString() + "'";
                        da.Query(sql);
                    }
                }
                this.DialogResult = true;
                Close();
            }
            catch
            {
                MessageBox.Show("Thông tin nhập chưa chính xác, xin vui lòng kiểm tra lại!\nChú ý: Tên môn học không được trùng!");
            }
        }

        private void cmdExit_Click(object sender, RoutedEventArgs e)
        {
            this.DialogResult = false;
            Close();
        }

        private void txt_sotinchi_TextChanged(object sender, TextChangedEventArgs e)
        {
            double tam;
            if (double.TryParse(txt_sotinchi.Text, out tam))
                txt_sotinchi.Text = txt_sotinchi.Text;
            else
                txt_sotinchi.Text = "";
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
