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
    /// Interaction logic for pop_NhapDiem.xaml
    /// </summary>
    public partial class pop_NhapDiem : Window
    {
        public pop_NhapDiem()
        {
            InitializeComponent();
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            Init();
        }

        private void Init()
        {
            Init_Sinhvien();
            // 2 cái combobox sau làm cũng tương tự
        }

        private void Init_Sinhvien()
        {
            DataTable dt = (new DAO.Database()).Select("SELECT MASINHVIEN, HOTENSINHVIEN,GIOITINH,NGAYSINH FROM SINHVIEN");
            for (int i = 0; i < dt.Rows.Count; i++)
            {
                StackPanel _stptemp = new StackPanel();

                TextBlock _txtmsv = new TextBlock();
                _txtmsv.Text = dt.Rows[i]["MASINHVIEN"].ToString();

                TextBlock _txthotensv = new TextBlock();
                _txthotensv.Text = "Họ tên sinh viên : " + dt.Rows[i]["HOTENSINHVIEN"].ToString();

                TextBlock _txtgioitinh = new TextBlock();
                _txtgioitinh.Text = "Giới tính : " + dt.Rows[i]["GIOITINH"].ToString();

                TextBlock _txtngaysinh = new TextBlock();
                _txtngaysinh.Text = "Ngày sinh : " + dt.Rows[i]["NGAYSINH"].ToString();


                if (i % 2 == 0)
                    _stptemp.Background = Brushes.Khaki;

                _stptemp.Width = 350;

                _stptemp.Children.Add(_txthotensv);
                _stptemp.Children.Add(_txtmsv);
                _stptemp.Children.Add(_txtgioitinh);
                _stptemp.Children.Add(_txtngaysinh);
                _stptemp.Tag = dt.Rows[i]["MASINHVIEN"].ToString();
                cbo_TenSinhVien.Items.Add(_stptemp);
            }
            if (dt.Rows.Count != 0)
                cbo_TenSinhVien.SelectedIndex = 0;
        }

        private void cmdDongY_Click(object sender, RoutedEventArgs e)
        {
            //2 cai combobox sau cũng vậy
            string _masv = ((StackPanel)cbo_TenSinhVien.SelectedItem).Tag.ToString();
            MessageBox.Show(_masv);
        }

        private void cmdExit_Click(object sender, RoutedEventArgs e)
        {

        }

    }
}
