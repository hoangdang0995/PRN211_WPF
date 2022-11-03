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
    /// Interaction logic for pop_GiangVien.xaml
    /// </summary>
    public partial class pop_GiangVien : Window
    {
        Database da = new Database();
        string type = "";
        string id = "";

        private string New_Id()
        {
            DataTable dt = (new Database()).Select("SELECT MAX(MAGIANGVIEN) FROM GIANGVIEN");
            if (dt.Rows.Count > 0)
            {
                string str = dt.Rows[0][0].ToString();
                str = str.Substring(2);
                return "GV" + (int.Parse(str) + 1).ToString("000");
            }
            else
                return "GV001";
        }

        public pop_GiangVien()
        {
            InitializeComponent();
            type = "add";
        }

        public pop_GiangVien(string id)
        {
            InitializeComponent();
            type = "edit";
            this.id = id;
        }

        void Init()
        {
            LoadHocHamVi();
            LoadLoaiGiangVien();
            if (type == "add")
                Init_add();
            else if (type == "edit")
                Init_edit();
        }

        void LoadHocHamVi()
        {
             DataTable dt = (new DAO.Database()).Select("SELECT MaHocViHocHam, TenHocViHocHam FROM HocViHocHam");
             for (int i = 0; i < dt.Rows.Count; i++)
             {
                 TextBlock _txttemp = new TextBlock();
                 _txttemp.Tag = dt.Rows[i]["MaHocViHocHam"].ToString();
                 _txttemp.Text = dt.Rows[i]["TenHocViHocHam"].ToString();
                 cbx_hocvihocham.Items.Add(_txttemp);
             }
             if (dt.Rows.Count != 0)
                 cbx_hocvihocham.SelectedIndex = 0;
        }

        void LoadLoaiGiangVien()
        {
            DataTable dt = (new DAO.Database()).Select("SELECT MALOAIGV, TENLOAIGV FROM LOAIGIANGVIEN");
            for (int i = 0; i < dt.Rows.Count; i++)
            {
                TextBlock _txttemp = new TextBlock();
                _txttemp.Tag = dt.Rows[i]["MALOAIGV"].ToString();
                _txttemp.Text = dt.Rows[i]["TENLOAIGV"].ToString();
                cbx_loaigv.Items.Add(_txttemp);
            }
            if (dt.Rows.Count != 0)
                cbx_loaigv.SelectedIndex = 0;
        }

        void Init_add()
        {
            txt_magiangvien.Text = New_Id();
            txt_magiangvien.IsEnabled = false;
            txt_tengiangvien.Text = "";
            rdb_gtNam.IsChecked = true;
            txt_diachi.Text = "";
            txt_sodienthoai.Text = "";
            txt_email.Text = "";
            txt_tengiangvien.Focus();
        }

        void Init_edit()
        {
            DataTable dt = (new DAO.Database()).Select("SELECT EMAIL,MAGIANGVIEN, TENGIANGVIEN, GIOITINH, DIACHI, DIENTHOAI, HOCVIHOCHAM.MAHOCVIHOCHAM,HOCVIHOCHAM.TENHOCVIHOCHAM,LOAIGIANGVIEN.MALOAIGV, LOAIGIANGVIEN.TENLOAIGV FROM GIANGVIEN,LOAIGIANGVIEN,HOCVIHOCHAM WHERE GIANGVIEN.MAHOCVIHOCHAM=HOCVIHOCHAM.MAHOCVIHOCHAM AND LOAIGIANGVIEN.MALOAIGV = GIANGVIEN.MALOAIGV AND MAGIANGVIEN = '" + id + "'");
            if (dt.Rows.Count > 0)
            {
                txt_magiangvien.Text = dt.Rows[0]["MAGIANGVIEN"].ToString();
                txt_magiangvien.IsEnabled = false;
                txt_tengiangvien.Text = dt.Rows[0]["TENGIANGVIEN"].ToString();
                rdb_gtNam.IsChecked = true;
                if (dt.Rows[0]["GIOITINH"].ToString() == "Nữ")
                    rdb_gtNu.IsChecked = true;

                for (int i = 0; i < cbx_hocvihocham.Items.Count; i++)
                {
                    TextBlock _txttemp = (TextBlock)cbx_hocvihocham.Items[i];
                    if (_txttemp.Tag.ToString() == dt.Rows[0]["MAHOCVIHOCHAM"].ToString())
                    {
                        cbx_hocvihocham.SelectedIndex = i;
                        break;
                    }
                }  

                for (int i = 0; i < cbx_loaigv.Items.Count; i++)
                {
                    TextBlock _txttemp = (TextBlock)cbx_loaigv.Items[i];
                    if (_txttemp.Tag.ToString() == dt.Rows[0]["MALOAIGV"].ToString())
                    {
                        cbx_loaigv.SelectedIndex = i;
                        break;
                    }
                }   

                txt_diachi.Text = dt.Rows[0]["DIACHI"].ToString();
                txt_sodienthoai.Text = dt.Rows[0]["DIENTHOAI"].ToString();
                txt_email.Text = dt.Rows[0]["EMAIL"].ToString();
            }
            txt_tengiangvien.Focus();
        }


        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            Init();
        }

        private void cmd_DongY_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                string _Gioitinh = "Nam";
                string _idhocvi = ((TextBlock)cbx_hocvihocham.SelectedItem).Tag.ToString();
                string _idloaigv = ((TextBlock)cbx_loaigv.SelectedItem).Tag.ToString();

                if (rdb_gtNu.IsChecked == true)
                    _Gioitinh = "Nữ";
                if (type == "add")
                {
                    da.Query("INSERT INTO GIANGVIEN VALUES('" + txt_magiangvien.Text + "','" + txt_tengiangvien.Text + "','" + _Gioitinh + "','" + txt_diachi.Text + "','" + txt_sodienthoai.Text + "','" + _idhocvi + "','" + _idloaigv + "','" + txt_email.Text + "')");
                }
                else if (type == "edit")
                {
                    da.Query("UPDATE GIANGVIEN SET TENGIANGVIEN = '" + txt_tengiangvien.Text + "',GIOITINH='" + _Gioitinh + "',DIACHI='" + txt_diachi.Text + "',DIENTHOAI='" + txt_sodienthoai.Text + "',MAHOCVIHOCHAM='" + _idhocvi + "',MALOAIGV='" + _idloaigv + "',EMAIL='" + txt_email.Text + "' WHERE MAGIANGVIEN = '" + txt_magiangvien.Text + "'");
                }
                this.DialogResult = true;
                Close();
            }
            catch
            {
                MessageBox.Show("Thông tin nhập chưa chính xác, xin vui lòng kiểm tra lại! \nChú ý: Địa chỉ e-mail không được trùng!");
            }
        }

        private void cmd_Exit_Click(object sender, RoutedEventArgs e)
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
                cmd_DongY_Click(sender, e);
        }
    }
}
