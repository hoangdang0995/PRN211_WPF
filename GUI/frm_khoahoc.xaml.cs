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
    /// Interaction logic for frm_khoahoc.xaml
    /// </summary>
    public partial class frm_khoahoc : UserControl
    {
        private void role()
        {
            DataTable dtpquyen = frm_HeThongQuanLy.dtquyen;
            if (frm_HeThongQuanLy.timtenformtrongdt("KHOAHOC", dtpquyen) > -1)
            {
                cmdadd.IsEnabled = false;
                if (dtpquyen.Rows[frm_HeThongQuanLy.timtenformtrongdt("KHOAHOC", dtpquyen)]["THEM"].ToString().ToLower() == "true")
                    cmdadd.IsEnabled = true;
                cmdedit.IsEnabled = false;
                if (dtpquyen.Rows[frm_HeThongQuanLy.timtenformtrongdt("KHOAHOC", dtpquyen)]["SUA"].ToString().ToLower() == "true")
                    cmdedit.IsEnabled = true;
                cmddelete.IsEnabled = false;
                if (dtpquyen.Rows[frm_HeThongQuanLy.timtenformtrongdt("KHOAHOC", dtpquyen)]["XOA"].ToString().ToLower() == "true")
                    cmddelete.IsEnabled = true;
            }
        }

        public frm_khoahoc()
        {
            InitializeComponent();
        }

        void Init()
        {
            DataTable dt = (new DAO.Database()).Select("SELECT * FROM KHOAHOC");
            gctrl_khoahoc.ItemsSource = dt;
        }

        void Load_KhoaHoc()
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
            popup.pop_KhoaHoc _khoahoc = new popup.pop_KhoaHoc();
            var res = _khoahoc.ShowDialog();
            if (res == true)
                Init();
        }

        private void cmdedit_Click(object sender, RoutedEventArgs e)
        {
            popup.pop_KhoaHoc _khoahoc = new popup.pop_KhoaHoc(gctrl_khoahoc.GetFocusedRowCellValue("MAKHOAHOC").ToString());
            var res = _khoahoc.ShowDialog();
            if (res == true)
                Init();
        }

        private void cmddelete_Click(object sender, RoutedEventArgs e)
        {
            var res = MessageBox.Show("Bạn có muốn xoá tên khoá học'" + gctrl_khoahoc.GetFocusedRowCellValue("TENKHOAHOC") + "' có mã là '" + gctrl_khoahoc.GetFocusedRowCellValue("MAKHOAHOC").ToString() + "' này không? \nNhấn YES để xoá - Nhấn NO để thoát.", "Thông báo", MessageBoxButton.YesNo);
            if (res == MessageBoxResult.Yes)
            {
                (new DAO.Database()).Query("DELETE FROM KHOAHOC WHERE MAKHOAHOC = '" + gctrl_khoahoc.GetFocusedRowCellValue("MAKHOAHOC").ToString() + "'");
                Init();
            }
        }

        private void cmdimport_Click(object sender, RoutedEventArgs e)
        {

        }

        private void cmdexport_Click(object sender, RoutedEventArgs e)
        {
            DataTable dtie = (new DAO.Database()).Select("SELECT MAKHOAHOC AS MÃ_KHOÁ_HỌC, TENKHOAHOC AS TÊN_KHOA_HỌC, NAMBATDAU AS NĂM_BẮT_ĐẦU, MOTA AS MÔ_TẢ FROM KHOAHOC");
            BUS.Bus.Export(dtie, "KhoaHoc");
        }

    }
}
