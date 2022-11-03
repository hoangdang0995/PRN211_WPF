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
    /// Interaction logic for pop_LopHoc.xaml
    /// </summary>
    public partial class pop_LopHoc : Window
    {
        Database da = new Database();
        string type = "";
        string id = "";

        private string New_Id()
        {
            DataTable dt = (new Database()).Select("SELECT MAX(MALOP) FROM LOP");
            if (dt.Rows.Count > 0)
            {
                string str = dt.Rows[0][0].ToString();
                str = str.Substring(2);
                return "LH" + (int.Parse(str) + 1).ToString("000");
            }
            else
                return "LH001";
        }

        void LoadChuyenNganh()
        {
            DataTable dt = (new DAO.Database()).Select("SELECT MACHUYENNGANH, TENCHUYENNGANH FROM CHUYENNGANH");
            for (int i = 0; i < dt.Rows.Count; i++)
            {
                TextBlock _txttemp = new TextBlock();
                _txttemp.Tag = dt.Rows[i]["MACHUYENNGANH"].ToString();
                _txttemp.Text = dt.Rows[i]["TENCHUYENNGANH"].ToString();
                cbx_chuyennganh.Items.Add(_txttemp);
            }
            if (dt.Rows.Count != 0)
                cbx_chuyennganh.SelectedIndex = 0;
        }

        void LoadHocKy()
        {
            DataTable dt = (new DAO.Database()).Select("SELECT MAHOCKY, TENHOCKY FROM HOCKY");
            for (int i = 0; i < dt.Rows.Count; i++)
            {
                TextBlock _txttemp = new TextBlock();
                _txttemp.Tag = dt.Rows[i]["MAHOCKY"].ToString();
                _txttemp.Text = dt.Rows[i]["TENHOCKY"].ToString();
                cbx_hocky.Items.Add(_txttemp);
            }
            if (dt.Rows.Count != 0)
                cbx_hocky.SelectedIndex = 0;
        }

        void LoadKhoaHoc()
        {
            DataTable dt = (new DAO.Database()).Select("SELECT MAKHOAHOC, TENKHOAHOC FROM KHOAHOC");
            for (int i = 0; i < dt.Rows.Count; i++)
            {
                TextBlock _txttemp = new TextBlock();
                _txttemp.Tag = dt.Rows[i]["MAKHOAHOC"].ToString();
                _txttemp.Text = dt.Rows[i]["TENKHOAHOC"].ToString();
                cbx_khoahoc.Items.Add(_txttemp);
            }
            if (dt.Rows.Count != 0)
                cbx_khoahoc.SelectedIndex = 0;
        }

        void Init_add()
        {
            txt_malophoc.Text = New_Id();
            txt_malophoc.IsEnabled = false;
            txt_tenlophoc.Text = "";
            txt_soluong.Text = "";
            txt_tenlophoc.Focus();
        }

        void Init_edit()
        {
            string sql = "SELECT MALOP,TENLOP,LOP.MAHOCKY,LOP.MACHUYENNGANH,LOP.MAKHOAHOC,SOLUONG,TENHOCKY,TENCHUYENNGANH,TENKHOAHOC FROM LOP, HOCKY,KHOAHOC,CHUYENNGANH WHERE LOP.MAHOCKY=HOCKY.MAHOCKY AND LOP.MACHUYENNGANH=CHUYENNGANH.MACHUYENNGANH AND LOP.MAKHOAHOC=KHOAHOC.MAKHOAHOC AND MALOP = '" + id + "'";
            DataTable dt = (new DAO.Database()).Select(sql);
            if (dt.Rows.Count > 0)
            {
                txt_malophoc.Text = dt.Rows[0]["MALOP"].ToString();
                txt_malophoc.IsEnabled = false;
                txt_tenlophoc.Text = dt.Rows[0]["TENLOP"].ToString();

                for (int i = 0; i < cbx_hocky.Items.Count; i++)
                {
                    TextBlock _txttemp = (TextBlock)cbx_hocky.Items[i];
                    if (_txttemp.Tag.ToString() == dt.Rows[0]["MAHOCKY"].ToString())
                    {
                        cbx_hocky.SelectedIndex = i;
                        break;
                    }
                }

                for (int i = 0; i < cbx_khoahoc.Items.Count; i++)
                {
                    TextBlock _txttemp = (TextBlock)cbx_khoahoc.Items[i];
                    if (_txttemp.Tag.ToString() == dt.Rows[0]["MAKHOAHOC"].ToString())
                    {
                        cbx_khoahoc.SelectedIndex = i;
                        break;
                    }
                }

                for (int i = 0; i < cbx_chuyennganh.Items.Count; i++)
                {
                    TextBlock _txttemp = (TextBlock)cbx_chuyennganh.Items[i];
                    if (_txttemp.Tag.ToString() == dt.Rows[0]["MACHUYENNGANH"].ToString())
                    {
                        cbx_chuyennganh.SelectedIndex = i;
                        break;
                    }
                }
                
                txt_soluong.Text = dt.Rows[0]["SOLUONG"].ToString();
            }
            txt_tenlophoc.Focus();
        }

        void Init()
        {
            LoadChuyenNganh();
            LoadHocKy();
            LoadKhoaHoc();
            if (type == "add")
                Init_add();
            else if (type == "edit")
                Init_edit();
        }

        public pop_LopHoc()
        {
            InitializeComponent();
            type = "add";
        }

        public pop_LopHoc(string id)
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
                string _idchuyennganh = ((TextBlock)cbx_chuyennganh.SelectedItem).Tag.ToString();
                string _idhocky = ((TextBlock)cbx_hocky.SelectedItem).Tag.ToString();
                string _idkhoahoc = ((TextBlock)cbx_khoahoc.SelectedItem).Tag.ToString();

                if (type == "add")
                {
                    string sql = "INSERT INTO LOP VALUES('" + txt_malophoc.Text + "','" + BUS.Bus.convertitle(txt_tenlophoc.Text) + "','" + _idhocky.ToString() + "','" + _idchuyennganh.ToString() + "','" + _idkhoahoc.ToString() + "','" + txt_soluong.Text + "')";
                    da.Query(sql);
                }
                else if (type == "edit")
                {
                    string sql = "UPDATE LOP SET TENLOP = '" + BUS.Bus.convertitle(txt_tenlophoc.Text) + "',SOLUONG='" + txt_soluong.Text + "',MACHUYENNGANH='" + _idchuyennganh + "',MAHOCKY='" + _idhocky + "',MAKHOAHOC='" + _idkhoahoc.ToString() + "' WHERE MALOP = '" + txt_malophoc.Text + "'";
                    da.Query(sql);
                }
                this.DialogResult = true;
                Close();
            }
            catch
            {
                MessageBox.Show("Thông tin nhập chưa chính xác, xin vui lòng kiểm tra lại!\nChú ý: Tên lớp học không được trùng!");
            }
        }

        private void cmd_Exit_Click(object sender, RoutedEventArgs e)
        {
            this.DialogResult = false;
            Close();
        }

        private void txt_soluong_TextChanged(object sender, TextChangedEventArgs e)
        {
            double tam;
            if (double.TryParse(txt_soluong.Text, out tam))
                txt_soluong.Text = txt_soluong.Text;
            else
                txt_soluong.Text = "";
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
