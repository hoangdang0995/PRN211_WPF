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
    /// Interaction logic for pop_ChuyenNganh.xaml
    /// </summary>
    public partial class pop_ChuyenNganh : Window
    {
        Database da = new Database();
        string type = "";
        string id = "";

        private string New_Id()
        {
            DataTable dt = (new Database()).Select("SELECT MAX(MACHUYENNGANH) FROM CHUYENNGANH");
            if (dt.Rows.Count > 0)
            {
                string str = dt.Rows[0][0].ToString();
                str = str.Substring(2);
                return "CN" + (int.Parse(str) + 1).ToString("000");
            }
            else
                return "CN001";
        }

        public pop_ChuyenNganh()
        {
            InitializeComponent();
            type = "add";
        }

        public pop_ChuyenNganh(string id)
        {
            InitializeComponent();
            type = "edit";
            this.id = id;
        }

        void LoadMaKhoa()
        {
            DataTable dt = (new DAO.Database()).Select("SELECT MAKHOA, TENKHOA FROM KHOA");
            for (int i = 0; i < dt.Rows.Count; i++)
            {
                TextBlock _txttemp = new TextBlock();
                _txttemp.Tag = dt.Rows[i]["MAKHOA"].ToString();
                _txttemp.Text = dt.Rows[i]["TENKHOA"].ToString();
                cbx_makhoa.Items.Add(_txttemp);
            }
            if (dt.Rows.Count != 0)
                cbx_makhoa.SelectedIndex = 0;
        }

        void Init_add()
        {
            txt_machuyennganh.Text = New_Id();
            txt_machuyennganh.IsEnabled = false;
            txt_tenchuyennganh.Text = "";
            txt_mota.Text = "";
            txt_tenchuyennganh.Focus();
        }

        void Init_edit()
        {
            DataTable dt = (new DAO.Database()).Select("SELECT MACHUYENNGANH, TENCHUYENNGANH, MOTA, CHUYENNGANH.MAKHOA, TENKHOA FROM CHUYENNGANH, KHOA WHERE CHUYENNGANH.MAKHOA=KHOA.MAKHOA and MACHUYENNGANH = '" + id + "'");
            if (dt.Rows.Count > 0)
            {
                txt_machuyennganh.Text = dt.Rows[0]["MACHUYENNGANH"].ToString();
                txt_machuyennganh.IsEnabled = false;
                txt_tenchuyennganh.Text = dt.Rows[0]["TENCHUYENNGANH"].ToString();
                for (int i = 0; i < cbx_makhoa.Items.Count; i++)
                {
                    TextBlock _txttemp = (TextBlock)cbx_makhoa.Items[i];
                    if (_txttemp.Tag.ToString() == dt.Rows[0]["MAKHOA"].ToString())
                    {
                        cbx_makhoa.SelectedIndex = i;
                        break;
                    }
                }
                txt_mota.Text = dt.Rows[0]["MOTA"].ToString();
            }
            txt_tenchuyennganh.Focus();
        }

        void Init()
        {
            LoadMaKhoa();
            if (type == "add")
                Init_add();
            else if (type == "edit")
                Init_edit();
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            Init();
        }

        private void cmd_DongY_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                string _idMaKhoa = ((TextBlock)cbx_makhoa.SelectedItem).Tag.ToString();
                if (type == "add")
                {
                    string sql = "INSERT INTO CHUYENNGANH (MACHUYENNGANH, TENCHUYENNGANH, MOTA, MAKHOA) VALUES ('" + txt_machuyennganh.Text + "','" + BUS.Bus.convertitle(txt_tenchuyennganh.Text) + "','" + txt_mota.Text + "','" + _idMaKhoa.ToString() + "')";
                    da.Query(sql);
                }
                else if (type == "edit")
                {
                    DataTable dt = (new DAO.Database()).Select("select * from CHUYENNGANH where MACHUYENNGANH = '" + id + "'");
                    if (dt.Rows.Count > 0)
                    {
                        string sql = "UPDATE CHUYENNGANH SET TENCHUYENNGANH = '" + BUS.Bus.convertitle(txt_tenchuyennganh.Text) + "', MOTA = '" + txt_mota.Text + "', MAKHOA = '" + _idMaKhoa.ToString() + "' WHERE MACHUYENNGANH = '" + dt.Rows[0]["MACHUYENNGANH"].ToString() + "'";
                        da.Query(sql);
                    }
                }
                this.DialogResult = true;
                Close();
            }
            catch
            {
                MessageBox.Show("Thông tin nhập chưa chính xác, xin vui lòng kiểm tra lại! \nChú ý: Tên chuyên ngành không được trùng!");
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
