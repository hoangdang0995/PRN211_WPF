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
using DAO;
using System.Data;

namespace GUI
{
    /// <summary>
    /// Interaction logic for frm_CauHinhCSDL.xaml
    /// </summary>
    public partial class frm_CauHinhCSDL : Window
    {
        public frm_CauHinhCSDL()
        {
            InitializeComponent();
            txt_DataSource.Focus();
        }

        private void Window_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.Key == Key.Enter)
            {
                cmd_KetNoiCSDL_Click(sender, e);
            }
            if (e.Key == Key.Escape)
            {
                this.Close();
            }
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {

        }

        private void cmd_KetNoiCSDL_Click(object sender, RoutedEventArgs e)
        {
            Database.DataSource = txt_DataSource.Text.Trim();
            Database.UserId = txt_UserID.Text.Trim();
            Database.PassWord = txt_Password.Password.ToString().Trim();
            Database data = new Database();
            if (data.CheckConnectionDatabase(Database.DataSource, Database.UserId, Database.PassWord))
            {
                G_system.ShowForm("frm_DangNhap", "GUI");
                this.Close();
                //MessageBox.Show("Đăng nhập CSDL thành công!", "Thông báo");
            }
            else
            {
                if (txt_DataSource.Text == "" && txt_UserID.Text == "" && txt_Password.Password == "")
                    MessageBox.Show("Tên database và tên đăng nhập và tên mật khẩu không có! Xin vui lòng kiểm tra lại!", "Thông báo", MessageBoxButton.OK);
                else if (txt_UserID.Text == "" && txt_Password.Password == "")
                    MessageBox.Show("Tên đăng nhập và mật khẩu không có! Xin vui lòng kiểm tra lại!", "Thông báo", MessageBoxButton.OK);
                else if (txt_DataSource.Text == "" && txt_UserID.Text == "")
                    MessageBox.Show("Tên database và tên đăng nhập không có! Xin vui lòng kiểm tra lại!", "Thông báo", MessageBoxButton.OK);
                else if (txt_DataSource.Text == "" && txt_Password.Password == "")
                    MessageBox.Show("Tên database và mật khẩu không có! Xin vui lòng kiểm tra lại!", "Thông báo", MessageBoxButton.OK);
                else if (txt_DataSource.Text == "")
                    MessageBox.Show("Tên database không có! Xin vui lòng kiểm tra lại!", "Thông báo", MessageBoxButton.OK);
                else if (txt_UserID.Text == "")
                    MessageBox.Show("Tên đăng nhập không có! Xin vui lòng kiểm tra lại!", "Thông báo", MessageBoxButton.OK);
                else if (txt_Password.Password == "")
                    MessageBox.Show("Mật khẩu không có! Xin vui lòng kiểm tra lại!", "Thông báo", MessageBoxButton.OK);
                else
                    MessageBox.Show("Tên database hoặc tên đăng nhập hoặc mật khẩu không đúng! Xin vui lòng kiểm tra lại!", "Thông báo", MessageBoxButton.OK);
            }
        }
    }
}
