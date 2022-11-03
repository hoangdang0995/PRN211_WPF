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
    /// Interaction logic for frm_Khoa.xaml
    /// </summary>
    public partial class frm_Khoa : UserControl
    {
        private void role()
        {
            DataTable dtpquyen = frm_HeThongQuanLy.dtquyen;
            if (frm_HeThongQuanLy.timtenformtrongdt("KHOA", dtpquyen) > -1)
            {
                cmdadd.IsEnabled = false;
                if (dtpquyen.Rows[frm_HeThongQuanLy.timtenformtrongdt("KHOA", dtpquyen)]["THEM"].ToString().ToLower() == "true")
                    cmdadd.IsEnabled = true;
                cmdedit.IsEnabled = false;
                if (dtpquyen.Rows[frm_HeThongQuanLy.timtenformtrongdt("KHOA", dtpquyen)]["SUA"].ToString().ToLower() == "true")
                    cmdedit.IsEnabled = true;
                cmddelete.IsEnabled = false;
                if (dtpquyen.Rows[frm_HeThongQuanLy.timtenformtrongdt("KHOA", dtpquyen)]["XOA"].ToString().ToLower() == "true")
                    cmddelete.IsEnabled = true;
            }
        }

        public frm_Khoa()
        {
            InitializeComponent();
        }

        void Init()
        {
            DataTable dt = (new DAO.Database()).Select("SELECT * FROM KHOA");
            gctrl_Khoa.ItemsSource = dt;
        }

        void Load_Khoa()
        {
            Init();
        }

        private void UserControl_Loaded(object sender, RoutedEventArgs e)
        {
            Init();
            role();
        }

        private void cmdadd_Click(object sender, RoutedEventArgs e)
        {
            popup.pop_Khoa _khoa = new popup.pop_Khoa();
            var res = _khoa.ShowDialog();
            if (res == true)
                Init();
        }

        private void cmdedit_Click(object sender, RoutedEventArgs e)
        {
            popup.pop_Khoa _khoa = new popup.pop_Khoa(gctrl_Khoa.GetFocusedRowCellValue("MAKHOA").ToString());
            var res = _khoa.ShowDialog();
            if (res == true)
                Init();
        }

        private void cmddelete_Click(object sender, RoutedEventArgs e)
        {
            var res = MessageBox.Show("Bạn có muốn xoá tên Khoa '" + gctrl_Khoa.GetFocusedRowCellValue("TENKHOA") + "' có mã là '" + gctrl_Khoa.GetFocusedRowCellValue("MAKHOA").ToString() + "' này không? \nNhấn YES để xoá - Nhấn NO để thoát.", "Thông báo", MessageBoxButton.YesNo);
            if (res == MessageBoxResult.Yes)
            {
                (new DAO.Database()).Query("DELETE FROM KHOA WHERE MAKHOA = '" + gctrl_Khoa.GetFocusedRowCellValue("MAKHOA").ToString() + "'");
                Init();
            }
        }

        private void cmdimport_Click(object sender, RoutedEventArgs e)
        {

        }

        private void cmdexport_Click(object sender, RoutedEventArgs e)
        {
            DataTable dtie = (new DAO.Database()).Select("SELECT MAKHOA AS MÃ_KHOA, TENKHOA AS TÊN_KHOA, SODIENTHOAI AS SỐ_ĐIỆN_THOẠI, EMAIL FROM KHOA");
            BUS.Bus.Export(dtie, "Khoa");
        }

    }
}
