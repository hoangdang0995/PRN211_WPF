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
using DevExpress.XtraEditors;
using System.Data;
using DAO;

namespace GUI
{
    using setting = Properties.Settings;
    /// <summary>
    /// Interaction logic for frm_DangNhap.xaml
    /// </summary>
    public partial class frm_DangNhap : Window
    {
        public frm_DangNhap()
        {
            InitializeComponent();
            txt_TenDangNhap.Focus();
        }

        private void cmd_DangNhap_Click(object sender, RoutedEventArgs e)
        {
            string str = string.Format("Select * From NGUOIDUNG where lower(TENDANGNHAP) = '{0}' and MATKHAU = '{1}'", txt_TenDangNhap.Text.ToLower(), pwd_MatKhau.Password);
            Database db = new Database();
            DataTable dt = db.Select(str);
            if (dt.Rows.Count > 0)
            {
                setting.Default.tennguoidung = dt.Rows[0]["TenNguoiDung"].ToString();
                setting.Default.iddangnhap = dt.Rows[0]["TENDANGNHAP"].ToString();
                setting.Default.matkhau = dt.Rows[0]["MATKHAU"].ToString();                

                DataTable dta = (new DAO.Database()).Select("SELECT * FROM LOAINGUOIDUNG, NGUOIDUNG WHERE LOAINGUOIDUNG.MALOAI=NGUOIDUNG.MALOAI AND TENDANGNHAP='" + dt.Rows[0]["TENDANGNHAP"].ToString() + "'");

                setting.Default.loainguoidung = dta.Rows[0]["TENLOAIND"].ToString();
                setting.Default.maloainguoidung = dta.Rows[0]["MALOAI"].ToString();

                setting.Default.Save();
                G_system.ShowForm("frm_HeThongQuanLy", "GUI");
                this.Close();
                return;
            }
            else
            {
                if (txt_TenDangNhap.Text == "" && pwd_MatKhau.Password != "")
                    MessageBox.Show("Tên đăng nhập không có! Xin vui lòng kiểm tra lại!", "Thông báo", MessageBoxButton.OK);
                else if (pwd_MatKhau.Password == "" && txt_TenDangNhap.Text != "")
                    MessageBox.Show("Mật khẩu không có! Xin vui lòng kiểm tra lại!", "Thông báo", MessageBoxButton.OK);
                else if (txt_TenDangNhap.Text == "" && pwd_MatKhau.Password == "")
                    MessageBox.Show("Tên đăng nhập và mật khẩu không có! Xin vui lòng kiểm tra lại!", "Thông báo", MessageBoxButton.OK);
                else
                    MessageBox.Show("Tên đăng nhập hoặc mật khẩu không đúng! Xin vui lòng kiểm tra lại!", "Thông báo", MessageBoxButton.OK);
            }
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            
        }

        private void cmd_CauHinhCSDL_Click(object sender, RoutedEventArgs e)
        {
            frm_CauHinhCSDL _cauhinh = new frm_CauHinhCSDL();
            _cauhinh.ShowDialog();
        }

        private void Window_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.Key == Key.Escape)
                this.Close();
            if (e.Key == Key.Enter)
                cmd_DangNhap_Click(sender, e);
        }
    }
}
