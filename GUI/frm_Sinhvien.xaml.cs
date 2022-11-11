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

namespace GUI
{
    /// <summary>
    /// Interaction logic for frm_Sinhvien.xaml
    /// </summary>
    public partial class frm_Sinhvien : UserControl
    {
        public frm_Sinhvien()
        {
            InitializeComponent();
        }

        void Init()
        {
            DataTable dt = (new DAO.Database()).Select("SELECT MASINHVIEN,HOTENSINHVIEN,GIOITINH,NGAYSINH,NOISINH,HOTENCHA,HOTENME,DIENTHOAI,EMAIL FROM SINHVIEN ORDER BY MASINHVIEN");
            gctrl_SinhVien.ItemsSource = dt;
        }

        void Load_SinhVien()
        {
            Init();
        }

        private void UserControl_Loaded(object sender, RoutedEventArgs e)
        {
            Load_SinhVien();
            View.Commands.ShowSearchPanel.Execute(null);
        }

        private void cmd_Add_Click(object sender, RoutedEventArgs e)
        {
            popup.pop_SinhVien _sinhvien = new popup.pop_SinhVien();
            var res = _sinhvien.ShowDialog();
            if (res == true)
                Init();
        }

        private void cmd_Edit_Click(object sender, RoutedEventArgs e)
        {
            popup.pop_SinhVien _sinhvien = new popup.pop_SinhVien(gctrl_SinhVien.GetFocusedRowCellValue("MASINHVIEN").ToString());
            var res = _sinhvien.ShowDialog();
            if (res == true)
                Init();
        }

        private void cmd_Delete_Click(object sender, RoutedEventArgs e)
        {
            var res = MessageBox.Show("Bạn có muốn xoá sinh viên tên '" + gctrl_SinhVien.GetFocusedRowCellValue("HOTENSINHVIEN") + "' có mã là '" + gctrl_SinhVien.GetFocusedRowCellValue("MASINHVIEN").ToString() + "' này không? \nNhấn YES để xoá - Nhấn NO để thoát.", "Thông báo", MessageBoxButton.YesNo);
            if (res == MessageBoxResult.Yes)
            {
                (new DAO.Database()).Query("DELETE FROM SINHVIEN WHERE MASINHVIEN = '" + gctrl_SinhVien.GetFocusedRowCellValue("MASINHVIEN").ToString() + "'");
                Init();
            }
        }
    }
}
