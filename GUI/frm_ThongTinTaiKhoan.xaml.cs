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
using System.Windows.Navigation;
using System.Windows.Shapes;
using System.Data;
using DAO;

namespace GUI
{
    using setting = Properties.Settings;
    /// <summary>
    /// Interaction logic for frm_ThongTinTaiKhoan.xaml
    /// </summary>
    public partial class frm_ThongTinTaiKhoan : UserControl
    {
        public frm_ThongTinTaiKhoan()
        {
            InitializeComponent();
            txt_TenNguoiDung.Text = setting.Default.tennguoidung;
            txt_TenDangNhap.Text = setting.Default.iddangnhap;
            //txt_LoaiNguoiDung.Text = setting.Default.loainguoidung;
            pw_pass.Password = setting.Default.matkhau;
        }
            
        private void cmd_LuuThayDoi_Click(object sender, RoutedEventArgs e)
        {
            if (pw_pass1.Password != "")
            {
                if (pw_pass1.Password.Equals(pw_pass2.Password))
                {
                    if (txt_TenNguoiDung.Text != "")
                    {
                        string sql = "UPDATE NGUOIDUNG SET TENNGUOIDUNG = '" + txt_TenNguoiDung.Text + "', MATKHAU = '" + pw_pass1.Password + "' WHERE TENDANGNHAP = '" + txt_TenDangNhap.Text + "'";
                        (new DAO.Database()).Query(sql);
                        setting.Default.tennguoidung = txt_TenNguoiDung.Text;
                        setting.Default.Save();
                        pw_pass1.Password = "";
                        pw_pass2.Password = "";
                        MessageBox.Show("Cập nhật thành công!", "Thông báo");
                    }
                    else
                    {
                        MessageBox.Show("Tên người dùng không được bỏ trống!", "Thông báo");
                    }
                }
                else
                {
                    MessageBox.Show("Mật khẩu không trùng nhau!", "Thông báo");
                }
            }
            else
            {
                if (txt_TenNguoiDung.Text != "")
                {
                    string sql = "UPDATE NGUOIDUNG SET TENNGUOIDUNG = '" + txt_TenNguoiDung.Text + "' WHERE TENDANGNHAP = '" + txt_TenDangNhap.Text + "'";
                    (new DAO.Database()).Query(sql);
                    pw_pass1.Password = "";
                    pw_pass2.Password = "";
                    MessageBox.Show("Cập nhật thành công!", "Thông báo");
                }
                else
                {
                    MessageBox.Show("Tên người dùng không được bỏ trống!", "Thông báo");
                }
            }
        }

        private void cmd_HuyThayDoi_Click(object sender, RoutedEventArgs e)
        {
            pw_pass1.Password = "";
            pw_pass2.Password = "";
            txt_TenNguoiDung.Text = setting.Default.tennguoidung;
        }
    }
}
